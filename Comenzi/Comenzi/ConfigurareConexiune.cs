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
using GSCryptography;
using GSFramework;

namespace Comenzi
{
    public partial class ConfigurareConexiune : Window
    {

        #region Constructor
        public ConfigurareConexiune()
        {
            InitializeComponent();
        }
       #endregion

        #region Fields

        private string[] AuthTypeTableStruct = new string[] 
            {
                "Description, System.String",
                "Type, System.Int32"
            };
        private DataTable AuthTypeTable;
        private const string sFileName = "AppConfig.dat";
        private bool bSave = false;


        #endregion


        #region Private Events


        private void buttonEditServer_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ShowSelectionForm(SelectorType.Server);

            object bIsAbort = Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.IsAbort");

            if (bIsAbort.ToString() != string.Empty)
            {
                if (!(bool)bIsAbort)
                {
                    if (Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.ServerName") != null)
                    {
                        buttonEditServerName.EditValue = Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.ServerName").ToString();
                    }
                    else
                    {
                        buttonEditServerName.EditValue = null;
                    }
                }
            }
        }

        private void buttonEditDataBase_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ShowSelectionForm(SelectorType.Database);

            object bIsAbort = Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.IsAbort");

            if (bIsAbort.ToString() != string.Empty)
            {
                if (!(bool)bIsAbort)
                {
                    if (Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.DatabaseList") != null)
                    {
                        buttonEditDataBase.EditValue = Context.GetParameterValueUserContextParameterList("Comenzi.ConnectionConfig.DatabaseList").ToString();
                    }
                    else
                    {
                        buttonEditServerName.EditValue = null;
                    }
                }
            }
        }

        private void lookUpEditAuthentication_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditAuthentication.EditValue != null)
            {
                ToggleAuthType((int)lookUpEditAuthentication.EditValue);
            }
        }

        private void buttonEditServerName_EditValueChanged(object sender, EventArgs e)
        {
            CheckServerExist();
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            bSave = true;
            this.Cursor = Cursors.WaitCursor;
            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            bSave = false;
            this.Close();
        }
        private void ConfigurareConexiune_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (bSave)
                {
                    TextWriter tw;
                    FileStream fs;
                    FileMode fmode;
                    string ConfigFilePath = Application.StartupPath + @"\" + sFileName;
                    string strToEncrypt = string.Empty;
                    if (File.Exists(ConfigFilePath))
                    {
                        fmode = FileMode.Truncate;
                    }
                    else
                    {
                        fmode = FileMode.Create;
                    }

                    fs = new FileStream(ConfigFilePath, fmode);
                    tw = new StreamWriter(fs);

                    string[] DatabaseList = buttonEditDataBase.Text.Split(new char[] { ',' });

                    if (DatabaseList.Length < 1)
                    {
                        MessageBox.Show("Trebuie sa alegeti cel putin o baze de date", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }

                    for (int i = 0; i < DatabaseList.Length; i++)
                    {
                        string InitialCatalog = DatabaseList[i].Trim();
                        SqlConnection Connection = CreateConnection(InitialCatalog);

                        strToEncrypt += Connection.ConnectionString;
                        if (textEditOptionalParameters.Text.Trim().Length > 0)
                        {
                            strToEncrypt += ";" + textEditOptionalParameters.Text.Trim();
                        }
                        strToEncrypt += "\r\n";
                    }

                    if (fs.CanWrite && fs.CanRead)
                    {
                        EncryptService encrSvc = new EncryptService(EncryptionAlgorithm.Des);
                        tw.WriteLine(Convert.ToBase64String(encrSvc.EncryptData(EncryptionUtil.StringToByteArray(strToEncrypt))));
                    }
                    tw.Close();
                }
            }
            catch (Exception excep)
            {
                Context.HandleException(this, "ConnectionConfig", excep);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Private Methods
        private void ShowSelectionForm(SelectorType selection)
        {
            switch (selection)
            {
                case SelectorType.Server:
                    AddKeyToContext("Comenzi.ConnectionConfig.SelectorWindowInfo", "Alegeti un server");
                    AddKeyToContext("Comenzi.ConnectionConfig.SelectorWindowText", "Selectie server");
                    AddKeyToContext("Comenzi.ConnectionConfig.EnableCheckboxes", false);
                    AddKeyToContext("Comenzi.ConnectionConfig.SelectorType", SelectorType.Server);
                    using (Context.CreateDialogWindow("Comenzi.SelectionForm, Comenzi"))
                    {
                        Context.CreatedWindow = null;
                    }
                    break;
                case SelectorType.Database:
                    if (CanSelectDatabase())
                    {
                        AddKeyToContext("Comenzi.ConnectionConfig.SelectorWindowInfo", "Alegeti bazele de date");
                        AddKeyToContext("Comenzi.ConnectionConfig.SelectorWindowText", "Selectie baze de date");
                        AddKeyToContext("Comenzi.ConnectionConfig.EnableCheckboxes", true);
                        AddKeyToContext("Comenzi.ConnectionConfig.SelectorType", SelectorType.Database);
                        AddKeyToContext("Comenzi.ConnectionConfig.Connection", CreateConnection());
                        using (Context.CreateDialogWindow("Comenzi.SelectionForm, Comenzi"))
                        {
                            Context.CreatedWindow = null;
                        }
                    }
                    break;
            }
        }
        public static DataTable CreateTable(string[] TableStruct, string TableName)
        {
            DataTable Table = new DataTable(TableName);

            for (int i = 0; i < TableStruct.Length; i++)
            {
                string ColumnInfo = TableStruct[i];
                string[] ColumnInfoSplit = ColumnInfo.Split(new char[] { ',' });
                string ColumnName = ColumnInfoSplit[0].Trim();
                string ColumnType = ColumnInfoSplit[1].Trim();

                DataColumn Column = new DataColumn(ColumnName, Type.GetType(ColumnType));
                Table.Columns.Add(Column);
            }

            return Table;
        }
        private void InitAuthTypes()
        {
            DataRow drs = AuthTypeTable.NewRow();
            drs["Description"] = "Autentificare Windows";
            drs["Type"] = 0;
            AuthTypeTable.Rows.Add(drs);

            DataRow drs1 = AuthTypeTable.NewRow();
            drs1["Description"] = "Autentificare SQL Server";
            drs1["Type"] = 1;
            AuthTypeTable.Rows.Add(drs1);

            lookUpEditAuthentication.Properties.DataSource = AuthTypeTable;
            lookUpEditAuthentication.Properties.DisplayMember = "Description";
            lookUpEditAuthentication.Properties.ValueMember = "Type";

            lookUpEditAuthentication.EditValue = 0;
        }
        private void ToggleAuthType(int AuthType)
        {
            switch (AuthType)
            {
                case 0:
                    textEditUser.Enabled = false;
                    textEditPassword.Enabled = false;
                    break;
                case 1:
                    textEditUser.Enabled = true;
                    textEditPassword.Enabled = true;
                    break;
            }
        }
        private void CheckServerExist()
        {
            if (buttonEditServerName.Text.Trim().Length == 0)
            {
                simpleButtonSave.Enabled = false;
                return;
            }
            simpleButtonSave.Enabled = true;
        }
        private void AddKeyToContext(string Key, object Value)
        {
            if (Context.GetParameterValueUserContextParameterList(Key).ToString() != string.Empty)
            {
                Context.DeleteEntryFromUserContextParameterList(Key);
            }
            Context.AddUserContextParameterList(Key, Value);
        }
        private bool CanSelectDatabase()
        {
            if (buttonEditServerName.Text.Trim() == string.Empty)
            {
                string ErrorMessage = "Trebuie sa introduceti numele serverului";
                MessageBox.Show(ErrorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private SqlConnection CreateConnection(string InitialCatalog)
        {
            SqlConnectionStringBuilder ConnectionBuilder = new SqlConnectionStringBuilder();

            ConnectionBuilder.DataSource = buttonEditServerName.Text.Trim();
            if (InitialCatalog.Trim().Length > 0)
            {
                ConnectionBuilder.InitialCatalog = InitialCatalog;
            }

            if (lookUpEditAuthentication.EditValue != null)
            {
                switch ((int)lookUpEditAuthentication.EditValue)
                {
                    case 0:
                        ConnectionBuilder.IntegratedSecurity = true;
                        break;
                    case 1:
                        ConnectionBuilder.IntegratedSecurity = false;
                        ConnectionBuilder.UserID = textEditUser.Text;
                        ConnectionBuilder.Password = textEditPassword.Text;
                        break;
                }
            }
            else
            {
                ConnectionBuilder.IntegratedSecurity = true;
            }

            return new SqlConnection(ConnectionBuilder.ConnectionString);
        }
        private SqlConnection CreateConnection()
        {
            return CreateConnection(string.Empty);
        }
        #endregion


        #region Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize();

                AuthTypeTable = CreateTable(AuthTypeTableStruct, "AuthTypeTable");
                InitAuthTypes();
                lookUpEditAuthentication.Properties.DropDownRows = AuthTypeTable.Rows.Count;

                CheckServerExist();

                this.Bind();
            }
            catch (Exception ex)
            {
                Context.HandleException(this, "", ex);
            }
        }
        public override void Bind()
        {
            try
            {
                base.Bind();
            }
            catch (Exception ex)
            {
                Context.HandleException(this, "", ex);
            }
        }

        #endregion        

        


    }
}
