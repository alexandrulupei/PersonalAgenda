using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using GSProxy;

namespace GSFramework
{
    /// <summary>
    /// Summary description for ClientContext.
    /// </summary>
    [Serializable()]
    public class ClientContext
    {
        #region Nested Classes
        //User 
        private class User
        {
            internal User()
            {
            }

            private Guid mUserID;
            private String mUserDisplayName;
            private String mUserName;
            private String mUserPassword;
            private String mUserRights;
            private String mUserCNP;

            public Guid UserID
            {
                set
                {
                    this.mUserID = value;
                }
                get
                {
                    return this.mUserID;
                }
            }

            public String UserDisplayName
            {
                set
                {
                    this.mUserDisplayName = value;
                }
                get
                {
                    return this.mUserDisplayName;
                }
            }
            public String UserName
            {
                set
                {
                    this.mUserName = value;
                }
                get
                {
                    return this.mUserName;
                }
            }
            public String UserPassword
            {
                set
                {
                    this.mUserPassword = value;
                }
                get
                {
                    return this.mUserPassword;
                }
            }

            public String UserRights
            {
                set
                {
                    this.mUserRights = value;
                }
                get
                {
                    return this.mUserRights;
                }
            }

            public String UserCNP
            {
                set
                {
                    this.mUserCNP = value;
                }
                get
                {
                    return this.mUserCNP;
                }
            }

        }

        //ConnectionSQL - conexiunea la baza de date
        private class ConnectionSQL
        {
            internal ConnectionSQL()
            {
            }

            private String mConnectionString;
            private String mSrvDB;
            private String mServerName;
            private String mDataBase;
            private bool mIsIntegrated;
            private bool mIsDefault;
            private bool mIsDirty;

            public String ConnectionString
            {
                set
                {
                    this.mConnectionString = value;
                }
                get
                {
                    return this.mConnectionString;
                }
            }

            public String SrvDB
            {
                set
                {
                    this.mSrvDB = value;
                }
                get
                {
                    return this.mSrvDB;
                }
            }

            public String ServerName
            {
                set
                {
                    this.mServerName = value;
                }
                get
                {
                    return this.mServerName;
                }
            }

            public String DataBase
            {
                set
                {
                    this.mDataBase = value;
                }
                get
                {
                    return this.mDataBase;
                }
            }

            public bool IsIntegrated
            {
                set
                {
                    this.mIsIntegrated = value;
                }
                get
                {
                    return this.mIsIntegrated;
                }
            }
            public bool IsDefault
            {
                set
                {
                    this.mIsDefault = value;
                }
                get
                {
                    return this.mIsDefault;
                }
            }
            public bool IsDirty
            {
                set
                {
                    this.mIsDirty = value;
                }
                get
                {
                    return this.mIsDirty;
                }
            }

            public void SetConnectionString()
            {
                DBConnection retval = new DBConnection(this.mServerName.Trim(),
                    this.mDataBase.Trim(),
                    this.mIsIntegrated,
                    ClientContext.OnlyInstance.UserName,
                    ClientContext.OnlyInstance.UserPassword,
                    "");    
        
                this.ConnectionString = retval.ConnectionString;
                this.mSrvDB = this.mServerName.Trim() + "." + this.mDataBase.Trim() + ".dbo.";

                if(CanGetDatabases())
                {            
                    SqlConnection tstConn = null;
                    try
                    {
                        tstConn = new SqlConnection(this.ConnectionString);
                        tstConn.Open();

                        this.IsDirty = false;
                    }
                    catch
                    {
                        this.IsDirty = true;
                    }
                    if (tstConn != null)
                    {
                        tstConn.Dispose();
                        tstConn = null;
                    }            
                }
                else
                {
                    this.IsDirty = true;
                }
            }


            #region Protected Methods
            protected bool CanTestServer()
            {
                if (CanGetDatabases())
                {
                    if (this.mDataBase.Trim().Length > 0)
                    {
                        return true;
                    }	
                }
                return false;
            }

            protected bool CanGetDatabases()
            {
                if (this.mServerName.Trim().Length > 0)
                {
                    if ((this.mIsIntegrated)||
                        (ClientContext.OnlyInstance.UserName.Trim().Length > 0))
                    {
                        return true;
                    }
                }
                return false;
            }       
            #endregion
        }
        #endregion

        #region Constructor
        public ClientContext()
        {
            requestedObjects = new Hashtable();
            userInstance = new User();
            mParameterList = new System.Collections.ArrayList();
            mUserContextParameterList = new System.Collections.ArrayList();
        }
        #endregion

        #region Private and Protected Variables
        private User userInstance;
        protected System.Collections.Hashtable requestedObjects;
        private static GSFramework.ClientContext mOnlyInstance;
        protected GSFramework.Window myMDIParent;
        protected GSFramework.Window myHomeDesktop;
        private GSFramework.Window myCreatedWindow;
        private System.Collections.IList mParameterList;
        private System.Collections.IList mUserContextParameterList;
        private bool mAppExitCalled = false;
        #endregion

        #region Public Properties
        public Guid UserID
        {
            get
            {
                return userInstance.UserID;
            }
        }
        public String UserName
        {
            get
            {
                if (userInstance.UserName != null)
                {
                    return userInstance.UserName ;
                }
                else
                    return "(No User)";
            }  
        }
    
        public String UserDisplayName
        {
            get
            {
                if (userInstance.UserDisplayName  != null)
                    return userInstance.UserDisplayName;
                else
                    return "(No User)";
            }
        }
        public String UserPassword
        {
            get
            {
                if (userInstance.UserPassword  != null)
                    return userInstance.UserPassword;
                else
                    return string.Empty;
            }
        }
        public String UserRights
        {
            get
            {
                return userInstance.UserRights;
            }
            set
            {
                userInstance.UserRights = value;
            }
        }
        public String UserCNP
        {
            get
            {
                return userInstance.UserCNP;
            }
            set
            {
                userInstance.UserCNP = value;
            }
        }
        public static GSFramework.ClientContext OnlyInstance 
        {
            get	
            {
                if (mOnlyInstance == null) 
                {
                    mOnlyInstance = new ClientContext();
                }
                return mOnlyInstance;
            }
            set	
            {
                mOnlyInstance = value;
            }
        }
        public GSFramework.Window MDIParent
        {
            get
            {
                return myMDIParent;
            }
            set
            {
                myMDIParent = value;
            }
        }
        public GSFramework.Window HomeDesktop
        {
            get
            {
                return (myHomeDesktop);
            }
            set
            {
                myHomeDesktop = value;
            }
        }
        public GSFramework.Window CreatedWindow
        {
            get
            {
                return myCreatedWindow;
            }
            set
            {
                myCreatedWindow = value;
            }
        }
        public System.Collections.IList ContextParameterList
        {
            get
            {
                return( mParameterList );
            }
            set
            {
                mParameterList = value;
            }
        }
        public System.Collections.IList UserContextParameterList
        {
            set
            {
                mUserContextParameterList = value;
            }
            get
            {
                return mUserContextParameterList;
            }
        }
        #endregion
	
        #region Public Methods to Handle Logon, Security and Permissions
        public  bool UserIsLoggedIn()
        {
            if (userInstance.UserName == null)
                return false;
            else
                return true;
        }
        public void Logoff()
        {
            userInstance.UserName = null;
            userInstance.UserDisplayName = "";
            userInstance.UserPassword = String.Empty;

        }
        public bool Logon(String userName, String password)
        {
            try
            {
                //TODO: aici trebuie pus serviciul pentru login si setati membrii clasei User
                if(userName.Trim().Equals(String.Empty))
                {
                    userName = "(No User)";
                }
                userInstance.UserName = userName;
                userInstance.UserPassword = password;
                userInstance.UserDisplayName = UserDisplayName;
                
                return true;
            }
            catch
            {
                userInstance.UserName = null;
                userInstance.UserDisplayName = null;
                userInstance.UserPassword = null;
                return false;
            }
        }
        public void SetUserLogon(Guid userID, String userName, String userDisplayName)
        {
            userInstance.UserID = userID;
            userInstance.UserName = userName;
            userInstance.UserDisplayName = userDisplayName;
        
        }
        #endregion

        #region Public Methods to Set ConnectionSQL 
        public void SetCurrentConnection(String pConnectionString)
        {
            GSConnections.SetCurrentConnection(pConnectionString);
        }
        #endregion

        #region Public Methods to handle ContextParameterList and UserContextParameterList
        public object GetParameterValue ( string pKey )
        {
            System.Collections.IEnumerator traverse = ContextParameterList.GetEnumerator();

            while( traverse.MoveNext() )
            {
                UserHashEntry userHashEntry = ( UserHashEntry ) traverse.Current;

                if( pKey.CompareTo( userHashEntry.Key.ToString() ) == 0 )
                {
                    return( userHashEntry.Value );
                }
            }
            return( string.Empty );
        }
        public object GetParameterValue (object pKey)
        {
            System.Collections.IEnumerator traverse = ContextParameterList.GetEnumerator();

            while( traverse.MoveNext() )
            {
                UserHashEntry userHashEntry = ( UserHashEntry ) traverse.Current;

                if( pKey.Equals( userHashEntry.Key ) )
                {
                    return( userHashEntry.Value );
                }
            }
            return( string.Empty );
        }
        public void SetParameterValue ( string pKey, object pValue )
        {
            try
            {
                System.Collections.IEnumerator traverse = ContextParameterList.GetEnumerator();

                while( traverse.MoveNext() )
                {
                    UserHashEntry userHashEntry = ( UserHashEntry ) traverse.Current;

                    if( pKey.CompareTo( userHashEntry.Key.ToString() ) == 0 )
                    {
                        userHashEntry.Value = pValue;
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public object GetParameterHashEntry ( string pKey )
        {
            System.Collections.IEnumerator traverse = ContextParameterList.GetEnumerator();

            while( traverse.MoveNext() )
            {
                UserHashEntry userHashEntry = ( UserHashEntry ) traverse.Current;

                if( pKey.CompareTo( userHashEntry.Key.ToString() ) == 0 )
                {
                    return( userHashEntry );
                }
            }
            return( string.Empty );
        }

        public void SetUserContextParameterList(string pKey, object pValue)
        {
            try
            {
                System.Collections.IEnumerator traverse = mUserContextParameterList.GetEnumerator();

                while( traverse.MoveNext() )
                {
                    UserHashEntry userHashEntry = ( UserHashEntry ) traverse.Current;

                    if( pKey.CompareTo( userHashEntry.Key.ToString() ) == 0 )
                    {
                        userHashEntry.Value = pValue;
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void AddUserContextParameterList(string pKey, object pValue)
        {
            try
            {
                if(GetParameterValueUserContextParameterList(pKey).ToString() == string.Empty )
                    mUserContextParameterList.Add(new UserHashEntry(pKey, pValue));
            }
            catch
            {
                throw;
            }
        }
		public void DeleteEntryFromUserContextParameterList(string pKey)
		{
			try
			{
                object obj = GetUserHashEntryUserContextParameterList(pKey);
                if(obj.ToString().CompareTo(string.Empty) == 0 )
                    return;
				UserHashEntry userHashEntry = (UserHashEntry)obj;
				if(userHashEntry != null)
					mUserContextParameterList.Remove(userHashEntry);
			}
			catch
			{
				throw;
			}
		}
        public object GetParameterValueUserContextParameterList(object pKey)
        {
            System.Collections.IEnumerator traverse = mUserContextParameterList.GetEnumerator();

            while( traverse.MoveNext() )
            {
                UserHashEntry userHashEntry = ( UserHashEntry ) traverse.Current;

                if( pKey.Equals( userHashEntry.Key ) )
                {
                    return( userHashEntry.Value );
                }
            }
            return( string.Empty );
        }
		private object GetUserHashEntryUserContextParameterList(object pKey)
		{
			System.Collections.IEnumerator traverse = mUserContextParameterList.GetEnumerator();

			while( traverse.MoveNext() )
			{
				UserHashEntry userHashEntry = ( UserHashEntry ) traverse.Current;

				if( pKey.Equals( userHashEntry.Key ) )
				{
					return( userHashEntry );
				}
			}
			return( string.Empty );
		}
        #endregion

        #region Public Methods to Handle Windows and Controllers
        public Object CreateObject(String ObjectName)
        {
            try
            {
                System.Reflection.Assembly theAssembly;
                Object newObject;
                String[] names;
                String assmName;
                String objName;
                names = ObjectName.Split(',');
                assmName = names[1].Trim();
                objName = names[0].Trim();
                theAssembly = System.Reflection.Assembly.Load(assmName);
                newObject = theAssembly.CreateInstance(objName);
                return newObject;
            }
            catch(System.Reflection.TargetInvocationException targetEx)
            {
                if (targetEx.InnerException != null)
                    throw targetEx.InnerException;
                else
                    throw new Exception("Unable to create the object.");
						
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public GSFramework.Window CreateWindow(String ObjectName)
        {
            return CreateWindow(ObjectName, "", null);
        }
        public GSFramework.Window CreateWindow(String ObjectName, String ParameterString)
        {
            return CreateWindow(ObjectName, ParameterString, null);
        }
        public GSFramework.Window CreateWindow(String ObjectName, object ParameterObject)
        {
            return CreateWindow(ObjectName, "", ParameterObject);
        }

        public GSFramework.Window CreateWindow(String ObjectName, String ParameterString, object ParameterObject)
        {
            this.MDIParent.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            GSFramework.Window newWindow;
            newWindow = (GSFramework.Window)CreateObject(ObjectName);
            newWindow.IsLoading = true;
            newWindow.Context = this;
            newWindow.Parameters = ParameterString;
            if (newWindow.Name == "frmTest")
                newWindow.WindowState = System.Windows.Forms.FormWindowState.Normal;
            else
            {
                newWindow.MdiParent = MDIParent;
                newWindow.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            myCreatedWindow = newWindow;
            if (ParameterObject != null)
                newWindow.Initialize(ParameterObject);
            else
                newWindow.Initialize();
            if (newWindow.DisplayByDefault)
            {
                newWindow.Show();
                this.MDIParent.Cursor = System.Windows.Forms.Cursors.Default;
            }
            else
            {
                newWindow.Dispose();
                this.MDIParent.Cursor = System.Windows.Forms.Cursors.Default;
            }
            newWindow.IsLoading = false;
            return newWindow;
        }
        public GSFramework.Window CreateDialogWindow(String ObjectName) 
        {
            return CreateDialogWindow(ObjectName, "");
        }
        public GSFramework.Window CreateDialogWindow(String ObjectName, String ParameterString) 
        {
            return CreateDialogWindow(ObjectName, ParameterString, null);
        }
        public GSFramework.Window CreateDialogWindow(String ObjectName, object ParameterObject)
        {
            return CreateDialogWindow(ObjectName, "", ParameterObject);
        }
        public GSFramework.Window CreateDialogWindow(String ObjectName, String ParameterString, object ParameterObject)
        {
            if (MDIParent != null)
                this.MDIParent.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            GSFramework.Window newWindow;
            newWindow = (GSFramework.Window)CreateObject(ObjectName);
            newWindow.IsLoading = true;
            newWindow.Context = this;
            newWindow.Parameters = ParameterString;
            newWindow.StartPosition = FormStartPosition.CenterParent;
            if (ParameterObject != null)
                newWindow.Initialize(ParameterObject);
            else
                newWindow.Initialize();

            if (MDIParent != null)
                this.MDIParent.Cursor = System.Windows.Forms.Cursors.Default;

            myCreatedWindow = newWindow;
            if (newWindow.DisplayByDefault)
            {
                newWindow.ShowDialog();
                newWindow.IsLoading = false;
            }
            else
                newWindow.Dispose();
            return newWindow;
        }
        /// <summary>
        /// Se foloseste in cazurile in care este necesar a se chema doar intialize
        /// </summary>
        /// <param name="ObjectName"></param>
        /// <param name="ParameterString"></param>
        /// <returns></returns>
        public GSFramework.Window InitializeWindow(String ObjectName, String ParameterString)
        {
            GSFramework.Window newWindow;
            newWindow = (GSFramework.Window)CreateObject(ObjectName);
            newWindow.IsLoading = true;
            newWindow.Context = this;
            newWindow.Parameters = ParameterString;
            newWindow.Initialize();
            newWindow.Dispose();
            return newWindow;
        }
        public GSFramework.Window CreateNonMDIWindow( String ObjectName ) 
        {
            return CreateNonMDIWindow(ObjectName, "");
        }

        public GSFramework.Window CreateNonMDIWindow(String ObjectName, String ParameterString) 
        {
            this.MDIParent.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            GSFramework.Window newWindow = (GSFramework.Window)CreateObject(ObjectName);
            newWindow.IsLoading = true;
            newWindow.Context = this;
            newWindow.Parameters = ParameterString;
            newWindow.Initialize();
            this.MDIParent.Cursor = System.Windows.Forms.Cursors.Default;
            newWindow.Show();
            newWindow.IsLoading = false;
            return newWindow;
        }

        public GSFramework.Controller CreateController(String ObjectName)
        {
            GSFramework.Controller newController;
            newController = (GSFramework.Controller) CreateObject(ObjectName);
            newController.Context = this;
            newController.InitializeClient();
            if (newController.AutoLoad)
                GSFramework.Remote.Load(newController);
            return newController;
        }

        public GSFramework.Controller GetSharedController(String  ObjectName)
        {
            GSFramework.Controller theController;
            try
            {
                theController = (GSFramework.Controller)requestedObjects[ObjectName];
            }
            catch
            {
                theController = null;
            }
            if (theController == null)
            {
                theController = CreateController(ObjectName);
                requestedObjects.Add(ObjectName, theController);
            }
            return theController;
        }

        public void ReleaseSharedController(String ObjectName)
        {
            try
            {
                requestedObjects.Remove(ObjectName);
            }
            catch
            {
            }
        }
		public GSFramework.Window CreateActivateWindow(String pWindowName)
		{
			GSFramework.Window window = GetMDIFormHandleByName(pWindowName);
			return CreateActivateWindow(window, pWindowName, "", false);
		}
		public GSFramework.Window CreateActivateWindow(String pWindowName, String pParameterString)
		{
			GSFramework.Window window = GetMDIFormHandleByName(pWindowName);
			return CreateActivateWindow(window, pWindowName, pParameterString, false);
		}
        public GSFramework.Window CreateActivateWindow(GSFramework.Window window, String pWindowName)
        {
            return CreateActivateWindow(window, pWindowName, "", true);
        }
        public GSFramework.Window CreateActivateWindow(GSFramework.Window window, String pWindowName, String pParameterString)
        {
			return CreateActivateWindow(window, pWindowName, pParameterString, true);
        }
		public GSFramework.Window CreateActivateWindow(GSFramework.Window window, String pWindowName, String ParameterString, bool bShowWarning)
		{
			window = GetMDIFormHandleByName(pWindowName);
			if( window != null)
			{
				if( bShowWarning )
				{
					MessageBox.Show("Operatiune nepermisa! \n\rPentru a executa aceasta operatiune va rugam finalizati lucrul la fereastra " + window.Text + "!", 
						"Interzis!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
				window.Activate();
				return window;
			}
			if(window ==null)
			{
				window = CreateWindow(pWindowName, ParameterString);
			}
			else
			{			
				foreach (Form tempChild in MDIParent.MdiChildren)
				{
					if (tempChild.GetType()== window.GetType())
					{
						window.Activate();
						return window;
					}
				}
				window = CreateWindow(pWindowName, ParameterString);
			}
			return window;
		}
        /// <summary>
        /// Returneaza instanta unei ferestre dupa numele ei
        /// </summary>
        /// <param name="pWindowName">Nume fereastra (ex: [nume dll].[nume clasa])</param>
        /// <returns>Instanta ferestrei sau null daca nu este gasita</returns>
        public GSFramework.Window GetMDIFormHandleByName(String pWindowName)
        {
            String[] names;
            String assmName;
            assmName = pWindowName;
            names = pWindowName.Split(',');
            if( names.Length > 0 )
                assmName = names[0].Trim();

            foreach( Form tempChild in MDIParent.MdiChildren )
            {
                if( tempChild.GetType().FullName.Equals(assmName) )
                {
                    return (GSFramework.Window)tempChild;
                }
            }
            return null;
        }
        #endregion

        #region Handle Exceptions
        public void HandleException (string pExcepMessage) 
        {
            UtilityClass utility = new UtilityClass();
            if (!mAppExitCalled && utility.DisplayException(pExcepMessage))
            {
                mAppExitCalled = true;
                Application.Exit();
            }
        }
        public void HandleException (Control pParent, Exception pExcep)
        {
            HandleException(pParent, pParent.Name, pExcep);
        }
        public void HandleException (Control pnlParent, string strModuleName, System.Exception excep) 
        {
            UtilityClass utility = new UtilityClass();
            if (!mAppExitCalled && utility.DisplayException(pnlParent, strModuleName, excep))
            {
                mAppExitCalled = true;
                Application.Exit();
            }
        }
        #endregion
    }
}
