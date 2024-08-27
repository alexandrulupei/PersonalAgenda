using GSFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonDataSets.Configurare;
using DevExpress.XtraEditors;
using GSCryptography;
using Utilities;

namespace Comenzi
{
    public partial class LoginWindow : Window
    {
        #region Constructor

        public LoginWindow()
        {
            InitializeComponent();
            textBoxPassword.Properties.PasswordChar = (char)0x25CF;
        }

        #endregion

        #region Class Members

        private const string sConfigName = "AppConfig.dat";
        private const string sUserNameFile = "user.txt";
        private ConfigDataSet myDataSet = new ConfigDataSet();

        #endregion

        #region Private Events

        private void barButtonItemConfigurare_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Context = ClientContext.OnlyInstance;
            Context.MDIParent = this;
            using (Context.CreateDialogWindow("Comenzi.ConfigurareConexiune, Comenzi"))
            {
                Context.CreatedWindow = null;
            }
        }

        private void dropDownButtonOptiuni_Click(object sender, EventArgs e)
        {
            Context = ClientContext.OnlyInstance;
            Context.MDIParent = this;
            using (Context.CreateDialogWindow("Comenzi.ConfigurareConexiune, Comenzi"))
            {
                Context.CreatedWindow = null;
            }
        }

        private void barButtonItemInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckAppConfig()) return;
            try
            {
                DataRow[] rows = myDataSet.tblConfig.Select();
                if (rows.Length < 1)
                {
                    XtraMessageBox.Show("Nu există informații.", "Comenzi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(rows[0]["ConnectionString"].ToString());
                    XtraMessageBox.Show(String.Format("Conexiunea este configurată pentru:" +
                        Environment.NewLine + "   - Server: " + builder.DataSource +
                        Environment.NewLine + "   - Baza de acces: " + builder.InitialCatalog),
                        "Comenzi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
        }

        private void simpleButtonLogin_Click(object sender, EventArgs e)
        {
            if (!CheckAppConfig()) return;
            if (textEditUser.Text.Trim().CompareTo(string.Empty) == 0)
            {
                XtraMessageBox.Show("Vă rog introduceți nume utilizator!", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textEditUser.Focus();
                return;
            }
            if (textBoxPassword.Text.Trim().CompareTo(string.Empty) == 0)
            {
                XtraMessageBox.Show("Vă rog introduceți parola!", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxPassword.Focus();
                return;
            }
            UtilityClass uc = new UtilityClass();
            string sDBAccess = uc.GetValueNameFromConfig("DataBaseAcces");
            if (sDBAccess == null)
            {
                XtraMessageBox.Show("Nu ați setat baza de date de access în fișierul de configurare!", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (CheckLogin(sDBAccess))
            {
                ClientContext.OnlyInstance.AddUserContextParameterList("Logon.DataSetConfig", myDataSet);
                SaveUserName();
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }
        private void LoginWindow_Load(object sender, EventArgs e)
        {
            lblVersiune.Text = BuildVersion.GetVersion();
            textEditUser.Text = ReadUserName();
            if (textEditUser.Text != string.Empty)
            {
                textBoxPassword.Select();
            }
            else
            {
                textEditUser.Select();
            }
        }
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            new Utility().AccessSuportGrupSoft();
        }

      
        #endregion

        #region Private Methods

        private bool CheckAppConfig()
        {
            try
            {
                StringBuilder sTextEnc = new StringBuilder();
                string fileName = Application.StartupPath + @"\" + sConfigName;
                if (!File.Exists(fileName))
                {
                    XtraMessageBox.Show("Nu s-a configurat conexiunea către baza de date!", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                using (StreamReader sr = File.OpenText(fileName))
                {
                    String input;
                    while ((input = sr.ReadLine()) != null)
                    {
                        sTextEnc.Append(input);
                    }
                    sr.Close();
                }
                DecryptService decrSvc = new DecryptService(EncryptionAlgorithm.Des);
                byte[] textToDecr = Convert.FromBase64String(sTextEnc.ToString());
                string inputDecrypted = EncryptionUtil.StringFromByteArray(decrSvc.DecryptData(textToDecr));
                SaveConfigStringToDataSet(inputDecrypted);
                return true;
            }
            catch (Exception exception)
            {
                Utility.Log(exception.Message);
                XtraMessageBox.Show("Fișierul de configurare al conexiunii este inaccesibil.", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveConfigStringToDataSet(String pInput)
        {
            myDataSet.tblConfig.Clear();
            string[] stringSeparators = new string[] { "\r\n" };
            string[] sLines = pInput.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sLines.Length; i++)
            {
                ConfigDataSet.tblConfigRow dr = myDataSet.tblConfig.NewtblConfigRow();
                dr.DataBaseName = string.Empty;
                dr.ConnectionString = sLines[i];
                dr.IntegratedSecurity = false;
                string[] sEntities = sLines[i].Split(';');
                for (int j = 0; j < sEntities.Length; j++)
                {
                    if (sEntities[j].IndexOf("Initial Catalog") == 0)
                    {
                        dr.DataBaseName = sEntities[j].Substring(sEntities[j].IndexOf('=') + 1);
                    }
                    if (sEntities[j].IndexOf("Integrated Security") == 0)
                    {
                        string result = sEntities[j].Substring(sEntities[j].IndexOf('=') + 1).ToLower();
                        if (result == "true")
                            dr.IntegratedSecurity = true;
                    }
                }
                myDataSet.tblConfig.AddtblConfigRow(dr);
            }
        }

        private void SaveUserName()
        {
            try
            {
                File.WriteAllText(Application.StartupPath + @"\" + sUserNameFile, this.textEditUser.Text, Encoding.UTF8);
            }
            catch (Exception exception)
            {
                Utility.Log(exception.Message);
            }
        }

        private string ReadUserName()
        {
            try
            {
                string sPath = Application.StartupPath + @"\" + sUserNameFile;
                if (File.Exists(sPath))
                {
                    return File.ReadAllText(sPath, Encoding.UTF8);
                }
            }
            catch (Exception exception)
            {
                Utility.Log(exception.Message);
            }
            return string.Empty;
        }

        private bool CheckLogin(string sDBAccess)
        {
            SqlDataAdapter sqlDataAdapterCheckUsernamePassword = new SqlDataAdapter();
            SqlCommand sqlSelectCommand = new SqlCommand();
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                DataRow[] drs = myDataSet.tblConfig.Select("DataBaseName = '" + sDBAccess + "'");
                if (drs.Length == 0)
                {
                    XtraMessageBox.Show("Nu există baza de date de access în configurarea internă!", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                sqlDataAdapterCheckUsernamePassword.SelectCommand = sqlSelectCommand;
                sqlSelectCommand.Connection = sqlConnection;
                sqlConnection.ConnectionString = drs[0]["ConnectionString"].ToString();
                sqlSelectCommand.CommandTimeout = sqlConnection.ConnectionTimeout;

                sqlSelectCommand.CommandText = "SELECT * FROM tblUsers WHERE (UserName = @pUserName) AND (Password = @pPassword) AND (IsActive=1)";
                sqlSelectCommand.Parameters.AddRange(new SqlParameter[] {
                            new SqlParameter("@pUserName", SqlDbType.NVarChar, 256, "UserName"),
                            new SqlParameter("@pPassword", SqlDbType.VarBinary, 64, "Password")});
                sqlDataAdapterCheckUsernamePassword.SelectCommand.Parameters["@pUsername"].Value = this.textEditUser.Text;
                sqlDataAdapterCheckUsernamePassword.SelectCommand.Parameters["@pPassword"].Value = HashUtil.EncodeHash(this.textBoxPassword.Text, HashUtil.HashType.MD5);

                int numRows = sqlDataAdapterCheckUsernamePassword.Fill(myDataSet, "tblUsers");

                if (myDataSet.tblUsers.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Ați introdus nume utilizator sau parola greșit!", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textEditUser.Focus();
                    return false;
                }
                ClientContext.OnlyInstance.SetCurrentConnection(drs[0]["ConnectionString"].ToString());
                ContextUtilityClass.OnlyInstance.DataBaseCurrentConnectionString = drs[0]["ConnectionString"].ToString();
            }
            catch (Exception exception)
            {
                Utility.Log(exception.Message);
                XtraMessageBox.Show("Eroare autentificare!", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return true;
        }

        #endregion

        #region Public Methods

        public override void Initialize()
        {
            base.Initialize();
          
            this.Bind();
        }

        public override void Bind()
        {
            base.Bind();
        }

        #endregion        

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            
        }

  

    
      

    }
}
