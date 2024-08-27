using System;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Net;

namespace GSFramework
{
    public class UtilityClass
    {
        #region Public Methods
        public bool DisplayException(Control pnlParent, string strModuleName, Exception exception) 
        {
            bool bReturn = true;

            string strMessage = strModuleName + " Exceptie. Mesajul de eroare este:\n" + exception.Message + "\nDoriti sa inchideti aplicatia?";
            ExceptionDisplay edException = new ExceptionDisplay(strMessage, exception.StackTrace, pnlParent);
            if (edException.ShowDialog() == DialogResult.No) bReturn = false;

            //log the exception message and the inner exception also if there are
            string logMessage = "Exception Message: " + exception.Message + "\r\n" + "Exception Stack Trace: \r\n" + exception.StackTrace;
            if( exception.InnerException != null )
            {
                Exception innerException = exception.InnerException;
                while( innerException != null )
                {
                    if( innerException.StackTrace != null )
                    {
                        logMessage = "Exception Message: " + innerException.Message + "\r\n" + "Exception Stack Trace: \r\n" + innerException.StackTrace;
                    }
                    innerException = innerException.InnerException;
                }
            }
            Utilities.Utility.Log(logMessage);
            if(  (pnlParent.GetType()).BaseType ==  typeof(Window))
            {
                //handle the dialog window to show or not
                ((Window)pnlParent).DisplayByDefault = false;            
            }
            return bReturn;
        }
      
        public bool DisplayException(string pExcepMessage) 
        {
            bool bReturn = true;

            string strMessage = " Exceptie. Mesajul de eroare este:\n" + pExcepMessage + "\nDoriti sa inchideti aplicatia?";
            ExceptionDisplay edException = new ExceptionDisplay(strMessage, pExcepMessage);
            if (edException.ShowDialog() == DialogResult.No) bReturn = false;

            //log the exception message and the inner exception also if there are
            Utilities.Utility.Log(pExcepMessage);
            return bReturn;
        }
      
        public String GetValueNameFromConfig(String pKey)
        {
            try
            {
                System.Configuration.AppSettingsReader appSettingsReader = new System.Configuration.AppSettingsReader();
                String mValue = (String)appSettingsReader.GetValue(pKey, typeof(String));
                return(mValue);
            }
            catch(Exception exception)
            {
                Utilities.Utility.Log(exception.Message);
                return null;	         
            }
        }

        public bool OpenHelpFile(Form form, string pTopic)
        {
            bool bReturn = false;
            string pHelpVal = GetValueNameFromConfig("UseHelpKey");
            if( pHelpVal != null && pHelpVal == "1" )
            {
                string HelpFile = @".\Help.chm";

                if(File.Exists(HelpFile))
                {
                    bReturn = true;

                    HelpNavigator Navigator = HelpNavigator.Topic;
                    Help.ShowHelp(form, @".\Help.chm", Navigator, pTopic);                  
                }
                else
                {
                    MessageBox.Show("Fisierul de Help nu este instalat!", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return bReturn;
        }
        #endregion

        #region Public Static Methods

        /// <summary>
        /// Obtine un parametru din context.
        /// </summary>
        public static T GetContetxtParameter<T>(string key)
        {
            try
            {
                object parameter = ClientContext.OnlyInstance.GetParameterValueUserContextParameterList(key);
                if (parameter != null && (!(parameter is String) || parameter.ToString() != String.Empty))
                {
                    return (T)parameter;
                }
                throw new Exception();
            }
            catch
            {
                return typeof(T).IsValueType ? default(T) : (T)Convert.ChangeType(null, typeof(T));
            }
        }

        /// <summary>
        /// Obtine un parametru transmis ferestrei.
        /// </summary>
        public static T GetWindowParameter<T>(Window wnd, string key, T defaultValue)
        {
            T result = defaultValue;
            string parameter = wnd.GetParameter(key);
            if (!String.IsNullOrEmpty(parameter))
            {
                try
                {
                    result = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(parameter);
                }
                catch
                {
                    result = defaultValue;
                }
            }
            return result;
        }

        #endregion
    }


    public class SqlLocator
    {
        #region Private Members
        [DllImport("odbc32.dll")]
        private static extern short SQLAllocHandle(short hType, IntPtr inputHandle, out IntPtr outputHandle);
        [DllImport("odbc32.dll")]
        private static extern short SQLSetEnvAttr(IntPtr henv, int attribute, IntPtr valuePtr, int strLength);
        [DllImport("odbc32.dll")]
        private static extern short SQLFreeHandle(short hType, IntPtr handle); 
        [DllImport("odbc32.dll",CharSet=CharSet.Ansi)]
        private static extern short SQLBrowseConnect(IntPtr hconn, StringBuilder inString, 
            short inStringLength, StringBuilder outString, short outStringLength,
            out short outLengthNeeded);

        private const short SQL_HANDLE_ENV = 1;
        private const short SQL_HANDLE_DBC = 2;
        private const int SQL_ATTR_ODBC_VERSION = 200;
        private const int SQL_OV_ODBC3 = 3;
        private const short SQL_SUCCESS = 0;
		
        private const short SQL_NEED_DATA = 99;
        private const short DEFAULT_RESULT_SIZE = 1024;
        private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";
        #endregion
	
        #region Constructor
        private SqlLocator(){}

        #endregion

        #region Public Methods
        public static string[] GetServers()
        {
            string[] retval = null;
            string txt = string.Empty;
            IntPtr henv = IntPtr.Zero;
            IntPtr hconn = IntPtr.Zero;
            StringBuilder inString = new StringBuilder(SQL_DRIVER_STR);
            StringBuilder outString = new StringBuilder(DEFAULT_RESULT_SIZE);
            short inStringLength = (short) inString.Length;
            short lenNeeded = 0;

            try
            {
                if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_ENV, henv, out henv))
                {
                    if (SQL_SUCCESS == SQLSetEnvAttr(henv,SQL_ATTR_ODBC_VERSION,(IntPtr)SQL_OV_ODBC3,0))
                    {
                        if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_DBC, henv, out hconn))
                        {
                            if (SQL_NEED_DATA ==  SQLBrowseConnect(hconn, inString, inStringLength, outString, 
                                DEFAULT_RESULT_SIZE, out lenNeeded))
                            {
                                if (DEFAULT_RESULT_SIZE < lenNeeded)
                                {
                                    outString.Capacity = lenNeeded;
                                    if (SQL_NEED_DATA != SQLBrowseConnect(hconn, inString, inStringLength, outString, 
                                        lenNeeded,out lenNeeded))
                                    {
                                        throw new ApplicationException("Unabled to aquire SQL Servers from ODBC driver.");
                                    }	
                                }
                                txt = outString.ToString();
                                int start = txt.IndexOf("{") + 1;
                                int len = txt.IndexOf("}") - start;
                                if ((start > 0) && (len > 0))
                                {
                                    txt = txt.Substring(start,len);
                                }
                                else
                                {
                                    txt = string.Empty;
                                }
                            }						
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Throw away any error if we are not in debug mode
#if (DEBUG)
            MessageBox.Show(ex.Message,"Acquire SQL Server List Error");
#endif 
                txt = ex.Message; //remove the warning message when in release mode
                txt = string.Empty;
            }
            finally
            {
                if (hconn != IntPtr.Zero)
                {
                    SQLFreeHandle(SQL_HANDLE_DBC,hconn);
                }
                if (henv != IntPtr.Zero)
                {
                    SQLFreeHandle(SQL_HANDLE_ENV,henv);
                }
            }
	
            string hostName = Dns.GetHostName().ToUpper();
            if (txt.Length > 0)
            {
                txt = txt.Replace("(local)", hostName);
                retval = txt.Split(",".ToCharArray());
            }
            
            
            return retval;
        }
        #endregion
    }


    [Serializable]
    public class DBConnection
    {
        #region Private Members
        private string _serverName;
        private string _dbName;
        private bool _integratedSecurity;
        private string _userName;
        private string _password;
        private string _otherOptions;
//        private const string GET_DBNAMES = "SELECT CATALOG_NAME AS DbName FROM INFORMATION_SCHEMA.SCHEMATA ORDER BY DbName ASC"; 
       private const string GET_DBNAMES = "select Name as DbName from master.dbo.sysdatabases Order By 1"; 
        private const string GET_TABLENAMES = "SELECT NAME AS TableName FROM <db_name>.dbo.SYSOBJECTS WHERE TYPE = 'U' ORDER BY NAME ASC"; 
        #endregion

        #region Public Properties
        public bool IntegratedSecurity
        {
            get
            {
                return _integratedSecurity;
            }
            set
            {
                if (value)
                {
                    _userName = string.Empty;
                    _password = string.Empty;
                }
                _integratedSecurity = value;
            }
        }

        public string OtherOptions
        {
            get
            {
                return _otherOptions;
            }
            set
            {
                _otherOptions = value.Trim();
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value.Trim();
            }
        }

        public string DatabaseName
        {
            get
            {
                return _dbName;
            }
            set
            {
                _dbName = value.Trim();
            }
        }

        public string ServerName
        {
            get
            {
                return _serverName;
            }
            set
            {
                _serverName = value.Trim();
            }
        }
        public string ConnectionString
        {
            get
            {
                return DatabaseConnectionString();
            }
        }
        #endregion

        #region Private Methods
        private string DatabaseConnectionString()
        {
            //"Data Source=cip;Initial Catalog=pubs;Integrated Security=SSPI;" 
            //"Data Source=cip;Initial Catalog=pubs;User Id=sa;Password=asdasd;" 
            return  _integratedSecurity 
                ? 
                string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;{2}",
                _serverName,
                _dbName,
                _otherOptions)
                :
                _password.Length == 0 
                ?
                string.Format("Data Source={0};Initial Catalog={1};User Id={2};{3}",
                _serverName,
                _dbName,
                _userName,
                _otherOptions)
                :
                string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};{4}",
                _serverName,
                _dbName,
                _userName,
                _password,
                _otherOptions);
        }

        private string MasterDBConnectionString()
        {
            //"Data Source=cip;Initial Catalog=pubs;Integrated Security=SSPI;" 
            //"Data Source=cip;Initial Catalog=pubs;User Id=sa;Password=asdasd;" 
            return  _integratedSecurity 
                ? 
                string.Format("Data Source={0};Initial Catalog=master;Integrated Security=SSPI;{1}",
                _serverName,
                _otherOptions)
                :
                string.Format("Data Source={0};Initial Catalog=master;User Id={1};Password={2};{3}",
                _serverName,
                _userName,
                _password,
                _otherOptions);
        }
        #endregion

        #region Public Methods
        public bool HasValidData()
        {
            return ((_serverName.Length > 0)&&
                ((_integratedSecurity)||
                (_userName.Length > 0))&&
                (_dbName.Length > 0));
        }

        public DBConnection()
        {
            _serverName = string.Empty;
            _dbName = string.Empty;
            _integratedSecurity = true;
            _userName = string.Empty;
            _password = string.Empty;
            _otherOptions = string.Empty;
        }

        public DBConnection(string serverName, string dbName, bool integratedSecurity, string userName, string password, string otherOptions)
        {
            _serverName = serverName;
            _dbName = dbName;
            _integratedSecurity = integratedSecurity;
            if (_integratedSecurity)
            {
                _userName = string.Empty;
                _password = string.Empty;
            }
            else
            {
                _userName = userName;
                _password = password;
            }
            _otherOptions = otherOptions;
        }

        public SqlConnection DatabaseConnection(bool useMasterDB)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(useMasterDB ? MasterDBConnectionString(): DatabaseConnectionString());
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"SQL Connection Error",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                conn = null;
            }
            if( conn != null )
                conn.Close();
            return conn;
        }

        public DataSet GetDatabases()
        {
            DataSet retds = null;
            SqlConnection conn = DatabaseConnection(true);
            if (conn != null)
            {
                SqlDataAdapter da = null;
                try
                {
                    retds = new DataSet();
                    da = new SqlDataAdapter(GET_DBNAMES,conn);
                    da.Fill(retds);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"SQL Connection Error",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    if (retds != null)
                    {
                        retds.Dispose();
                        retds = null;
                    }
                }
                finally
                {
                    if (da != null)
                    {
                        da.Dispose();
                        da = null;
                    }
                    conn.Dispose();
                    conn = null;
                }
            }


            return retds;
        }
        public DataSet GetTables(string pDB)
        {
            DataSet retds = null;
            SqlConnection conn = DatabaseConnection(true);
            if (conn != null)
            {
                SqlDataAdapter da = null;
                try
                {
                    retds = new DataSet();
                    da = new SqlDataAdapter( GET_TABLENAMES.Replace("<db_name>", pDB) ,conn);
                    da.Fill(retds);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"SQL Connection Error",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    if (retds != null)
                    {
                        retds.Dispose();
                        retds = null;
                    }
                }
                finally
                {
                    if (da != null)
                    {
                        da.Dispose();
                        da = null;
                    }
                    conn.Dispose();
                    conn = null;
                }
            }


            return retds;
        }

        #endregion
    }
}
