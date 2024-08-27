using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComenziBase;
using CommonDataSets.GUI;
using CommonGUIControllers.Admin;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using GSCryptography;
using GSFramework;

namespace ComenziGUI
{
    public partial class UsersActualizare : FrameworkWindow
    {
        #region Constructor
        public UsersActualizare()
        {
            InitializeComponent();
        }
        #endregion 

        #region Class Fields
        private CommonGUIControllers.Admin.UsersController mController;
        private UsersDataSet mDataSet;
        private ResetSecurityController mResetSecurityController;
        private ResetSecurityDataSet mResetSecurityDataSet;
        private bool mIsNew = true;
        private DataRow mUsersRow;
        private bool mEventCanceled = false;
        private bool mEventNo = false;
        private bool mNewRowAdded = false;
        private Guid mUserID = Guid.Empty;
        private bool mIsBinding = false;
        #endregion

        #region Private Events
        private void UsersActualizare_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                mEventCanceled = false;
                mEventNo = false;
                DialogResult performSave = DialogResult.Yes;

                if (mySaveData)
                {
                    // performSave is Yes
                }
                else
                {
                    if (this.HasChanges())
                    {
                        performSave = XtraMessageBox.Show("Doriti sa salvati modificarile?",
                                                          "Econet",
                                                          MessageBoxButtons.YesNoCancel,
                                                          MessageBoxIcon.Question);
                        if (performSave == DialogResult.Yes)
                        {
                            // performSave is Yes
                        }
                        else if (performSave == DialogResult.Cancel)
                        {
                            mySaveData = false;
                            mEventCanceled = e.Cancel = true;
                        }
                        else
                        {
                            mEventNo = true;
                        }
                    }
                    else
                    {
                        performSave = DialogResult.No;
                        mEventNo = true;
                    }
                }

                // Save changes
                if (performSave == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (this.Validate())
                    {
                        this.Save();
                    }
                    // mySaveData este acelasi cu rezultatul lui Validate sau
                    // daca s-au salvat datele cu rezultatul lui Save
                    if (!mySaveData)
                    {
                        // e.Cancel = true anuleaza inchiderea ferestrei
                        mEventCanceled = e.Cancel = true;
                    }
                    this.Cursor = Cursors.Default;
                }
            }
            catch (System.Exception exception)
            {
                Context.HandleException(this, exception);
            }
        }
        private void UsersActualizare_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mEventNo) mDataSet.tblUsers.RejectChanges();
        }
        private void simpleButtonSalveaza_Click(object sender, EventArgs e)
        {
            mySaveData = true;
            this.Close();
        }

        private void simpleButtonRenunta_Click(object sender, EventArgs e)
        {
            mySaveData = false;
            this.Close();
        }

        private void textEditUserName_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
        }

        private void comboBoxEditTipConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.mIsBinding == false)
            {
                ComboBoxEdit combo = sender as ComboBoxEdit;
                mUsersRow["TipConnection"] = combo.SelectedIndex;
            }
        }


        #endregion

        #region Private Methods
        /// <summary>
        /// Verifica daca sunt schimbari.
        /// </summary>
        private bool HasChanges()
        {
            bool hasChanges = false;
            this.BindingContext[mDataSet.tblUsers].EndCurrentEdit();
            hasChanges = mController.DataSet.HasChanges();
            if (mIsNew)
            {
                if ((!String.IsNullOrEmpty(this.textEditUserName.Text)) ||
                    (!String.IsNullOrEmpty(this.textEditPassword.Text)) ||
                    (!String.IsNullOrEmpty(this.textEditRetypedPassword.Text)) ||
                    (!String.IsNullOrEmpty(this.textEditNume.Text)) ||
                    (!String.IsNullOrEmpty(this.textEditPrenume.Text)))
                    hasChanges = true;
            }
            else
            {
                if (this.textEditPassword.Text != ">:#empty#:")
                {
                    byte[] passwordMD5Hash = HashUtil.EncodeHash(this.textEditPassword.Text, HashUtil.HashType.MD5);
                    if (!BytesArraysEquals(passwordMD5Hash, (byte[])mUsersRow["Password"]))
                        hasChanges = true;
                }
            }
            return hasChanges;
        }

        /// <summary>
        /// Valideaza datele inainte de salvare.
        /// </summary>
        private new bool Validate()
        {
            mySaveData = false;
            if (String.IsNullOrEmpty(this.textEditUserName.Text.Trim()))
            {
                this.textEditUserName.ErrorText = "Introduceti un nume de utilizator!";
                this.textEditUserName.Focus();
                return false;
            }
            DataRow[] drs = mDataSet.tblUsers.Select("UserName='" + this.textEditUserName.Text + "' and ID<>'" + mUsersRow["ID"].ToString() + "'");
            if (drs.Length > 0)
            {
                this.textEditUserName.ErrorText = "Nume de utilizator existent!";
                this.textEditUserName.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.textEditPassword.Text.Trim()))
            {
                this.textEditPassword.ErrorText = "Introduceti o parola!";
                this.textEditPassword.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.textEditRetypedPassword.Text.Trim()))
            {
                this.textEditRetypedPassword.ErrorText = "Rescrieti parola!";
                this.textEditRetypedPassword.Focus();
                return false;
            }
            if (String.Compare(this.textEditPassword.Text, this.textEditRetypedPassword.Text, false) != 0)
            {
                this.textEditPassword.ErrorText = "Parola introdusa difera de parola rescrisa!";
                this.textEditPassword.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.textEditNume.Text.Trim()))
            {
                this.textEditNume.ErrorText = "Introduceti numele utilizatorului!";
                this.textEditNume.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.textEditPrenume.Text.Trim()))
            {
                this.textEditPrenume.ErrorText = "Introduceti prenumele utilizatorului!";
                this.textEditPrenume.Focus();
                return false;
            }
            return mySaveData = true;
        }

        /// <summary>
        /// Salveaza efectiv datele.
        /// </summary>
        private void Save()
        {
            try
            {
                if (!mySaveData) return;
                SaveToDataSet();
                mySaveData = true;
                if (mController.DataSet.HasChanges())
                {
                    mController.Perform();
                    if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        mySaveData = false;
                        return;
                    }
                    DialogResult = DialogResult.OK;
                }
                mDataSet.AcceptChanges();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Salveaza datele in dataset.
        /// </summary>
        private void SaveToDataSet()
        {
            this.BindingContext[mDataSet.tblUsers].EndCurrentEdit();

            if (mIsNew && !mNewRowAdded)
            {
                // Adauga randul nou in tabela tblUsers din dataset
                byte[] passwordMD5Hash = HashUtil.EncodeHash(this.textEditPassword.Text, HashUtil.HashType.MD5);
                mUsersRow["Password"] = passwordMD5Hash;
                mDataSet.tblUsers.Rows.Add(mUsersRow);
                mNewRowAdded = true;
            }
            else
            {
                if (this.textEditPassword.Text != ">:#empty#:")
                {
                    byte[] passwordMD5Hash = HashUtil.EncodeHash(this.textEditPassword.Text, HashUtil.HashType.MD5);
                    if (!BytesArraysEquals(passwordMD5Hash, (byte[])mUsersRow["Password"]))
                    {
                        mUsersRow["Password"] = passwordMD5Hash;
                    }
                }
            }

            // Salvare evidente in tabela lnkUsersDeschidere

        }

        /// <summary>
        /// Compara doua obiecte byteArray
        /// </summary>
        private bool BytesArraysEquals(byte[] pByteArray1, byte[] pByteArray2)
        {
            String s1 = Convert.ToBase64String(pByteArray1);
            String s2 = Convert.ToBase64String(pByteArray2);
            if (s1 != s2) return false;
            return true;
        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                base.Initialize();
                mEventCanceled = mEventNo;
                mController = (UsersController)Context.GetSharedController("CommonGUIControllers.Admin.UsersController, CommonGUIControllers");
                mDataSet = (UsersDataSet)mController.DataSet;
                string sIsNew = this.GetParameter("pIsNew");
                if (!String.IsNullOrEmpty(sIsNew))
                    this.mIsNew = Convert.ToBoolean(sIsNew);
                if (mIsNew)
                {
                    mUsersRow = mDataSet.tblUsers.NewRow();
                    mUserID = Guid.NewGuid();
                    mUsersRow["ID"] = mUserID;
                    mUsersRow["IsActive"] = true;   // Acest camp este default pentru un utilizator nou
                    mUsersRow["TipConnection"] = 0; // Valoare default 0 - Local si remote
                }
                else
                {
                    object obj = Context.GetParameterValueUserContextParameterList("UsersActualizare.SelectedRow");
                    if (obj != null)
                    {
                        mUsersRow = (DataRow)obj;
                        if (mUsersRow["UserName"].ToString().Equals("Admin", StringComparison.InvariantCultureIgnoreCase))
                        {
                            this.textEditUserName.Enabled = false;
                        }
                        mUserID = (Guid)mUsersRow["ID"];
                    }
                }
                this.Bind();

                #region Pentru operatiunea de Reset
                try
                {
                    //this.Context.SetCurrentConnection(ContextUtilityClass.OnlyInstance.DataBaseAccessConnectionString);
                    mResetSecurityController = (ResetSecurityController)Context.CreateController("CommonGUIControllers.GUI.ResetSecurityController, CommonGUIControllers");
                    mResetSecurityController.AplicatiiID = ContextUtilityClass.OnlyInstance.AplicatiiID;
                    mResetSecurityController.Load();
                    if (System.Convert.ToInt16(mResetSecurityController.ResultCode.ToString()) != 0)
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        return;
                    }
                    mResetSecurityDataSet = (ResetSecurityDataSet)mResetSecurityController.DataSet;
                }
                catch
                {
                }
                finally
                {
                    //this.Context.SetCurrentConnection(ContextUtilityClass.OnlyInstance.DataBaseAccessConnectionString);
                }
                # endregion
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }
        public override void Bind()
        {
            this.mIsBinding = true;
            base.Bind();
            // Automatic Bindings
            this.textEditUserName.DataBindings.Add("EditValue", mUsersRow, "UserName", true, DataSourceUpdateMode.OnValidation, string.Empty);
            this.textEditNume.DataBindings.Add("EditValue", mUsersRow, "Nume", true, DataSourceUpdateMode.OnValidation, string.Empty);
            this.textEditPrenume.DataBindings.Add("EditValue", mUsersRow, "Prenume", true, DataSourceUpdateMode.OnValidation, string.Empty);
          // Manual Bindings
            if (!mIsNew) this.textEditPassword.Text = this.textEditRetypedPassword.Text = ">:#empty#:";
            this.comboBoxEditTipConnection.SelectedIndex = Convert.ToInt32(mUsersRow["TipConnection"]);

            // Bind Evidente
            foreach (DataRow dr in mDataSet.tblDeschidereBase.Rows)
            {
                CheckedListBoxItem item = new CheckedListBoxItem();
                item.Value = dr["NumeDeschidere"];
                if (!mIsNew)
                {
                    Guid userid = (Guid)mUsersRow["ID"];
                    DataRow[] rows = mDataSet.lnkUsersDeschidere.Select("UsersID = '" + userid + "' and DeschidereID = '" + (Guid)dr["ID"] + "'");
                    if (rows.Length > 0)
                    {
                        item.CheckState = CheckState.Checked;
                    }
                }
                else
                    item.CheckState = CheckState.Unchecked;
                this.checkedComboBoxEditEvidente.Properties.Items.Add(item);
            }

            #region Pentru operatiunea de Reset
            foreach (DataRow drDeschidere in mDataSet.tblDeschidereBase.Rows)
            {
                CommonDataSets.GUI.UsersDataSet.lnkUsersDeschidereRoles1Row rowlnk =
                    mDataSet.lnkUsersDeschidereRoles1.NewlnkUsersDeschidereRoles1Row();

                rowlnk.UsersID = mUserID;
                rowlnk.DeschidereBaseID = (Guid)drDeschidere["ID"];
                //rowlnk.RolesID = DBNull.Value;
                mDataSet.lnkUsersDeschidereRoles1.AddlnkUsersDeschidereRoles1Row(rowlnk);

            }
            mDataSet.lnkUsersDeschidereRoles1.AcceptChanges();
            # endregion

            this.mIsBinding = false;
        }
        #endregion

        #region Zona Reset
        private void labelControl_btn_Reset_Click(object sender, EventArgs e)
        {

            int j = 0;
            labelControl_btn_Reset.Text = "Wait...";

            foreach (DataRow row in mResetSecurityDataSet.tblUsers.Rows)
            {
                Guid userID = (Guid)row["ID"];
                mResetSecurityDataSet.tblUserRights.Clear();

                mResetSecurityController.LoadUsersRighs(userID);

                if (System.Convert.ToInt16(mResetSecurityController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
                if (mResetSecurityDataSet.tblUserRights.Rows.Count == 0) continue;

                DataRow dr = mResetSecurityDataSet.tblUserRights.Rows[0];

                string s1 = dr["UserRights"].ToString();
                string s2 = dr["UserRightsSpecific"].ToString();

                TextReader reader1 = new StringReader(s1);
                TextReader reader2 = new StringReader(s2);

                //DataSet1 ds = new DataSet1();

                DataTable t1 = mResetSecurityDataSet.tblUserRightsXml.Clone();
                DataTable t2 = mResetSecurityDataSet.tblUserRightsSpecificXml.Clone();

                DataTable tmp_tblUserRightsXml = mResetSecurityDataSet.tblUserRightsXml.Clone();
                tmp_tblUserRightsXml.Clear();

                t1.ReadXml(reader1);
                t2.ReadXml(reader2);

                //mResetSecurityDataSet.tblUserRightsSpecificXml.Merge(t2);
                //mResetSecurityDataSet.tblUserRightsXml.Merge(t1);
                int count = 0;
                DataRow[] lnkRows = mResetSecurityDataSet.lnkUsersDeschidere.Select("UsersID = '" + userID + "'");
                foreach (DataRow lnkRow in lnkRows)
                {
                    count = t1.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DataRow dr1 = t1.Rows[i];
                        if ((Guid)dr1["DeschidereBaseID"] == (Guid)lnkRow["DeschidereID"])
                        {
                            tmp_tblUserRightsXml.ImportRow(dr1);
                        }
                    }
                }
                tmp_tblUserRightsXml.AcceptChanges();

                count = t2.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    DataRow row2 = t2.Rows[i];
                    DataRow[] rows = tmp_tblUserRightsXml.Select("ID='" + row2["UserRightsXmlID"] + "'");
                    if (rows.Length == 0)
                    {
                        row2.Delete();
                        count--;
                        i--;
                    }
                }
                t2.AcceptChanges();

                //SALVARE IN tblUserRights

                //UserRightsXml


                TextWriter stringWriterUserRightsXml = new StringWriter();
                tmp_tblUserRightsXml.WriteXml(stringWriterUserRightsXml);
                dr["UserRights"] = stringWriterUserRightsXml;


                //UserRightsSpecificXml
                TextWriter stringWriterUserRightsSpecificXml = new StringWriter();
                t2.WriteXml(stringWriterUserRightsSpecificXml);
                dr["UserRightsSpecific"] = stringWriterUserRightsSpecificXml;

                mResetSecurityController.Perform();
                labelControl_btn_Reset.Text = "Wait..." + (j++).ToString();

            }
            labelControl_btn_Reset.Text = "Finish";
            XtraMessageBox.Show("Securitate reinitializata!");
        }

        private void labelControl_btn_Reset_MouseHover(object sender, EventArgs e)
        {
            labelControl_btn_Reset.Text = "Reset security";
        }

        private void labelControl_btn_Reset_MouseLeave(object sender, EventArgs e)
        {
            labelControl_btn_Reset.Text = "";
        }
        #endregion



    }
}
