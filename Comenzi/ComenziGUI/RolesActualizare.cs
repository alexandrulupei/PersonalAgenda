using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComenziBase;
using CommonDataSets.GUI;
using CommonGUIControllers.Admin;
using DevExpress.XtraEditors;
using GSFramework;
using Utilities;

namespace ComenziGUI
{
    public partial class RolesActualizare : FrameworkWindow
    {

        #region Constructor
        public RolesActualizare()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields
        private RolesDataSet mDataSet;
        private RolesController mController;
        private Guid mID = Guid.Empty;
        private Utility mUtility = new Utility();
        private bool mIsNew = false;
        private DataView mDataView;
        private bool mEventCanceled = false;
        private bool mEventNo = false;
        private string mDefaultTipAccess = "0";
        #endregion
        
        #region Properties
        public Guid ID
        {
            get { return mID; }
        }
        #endregion

        #region Private Events

        private void treeListMeniu_CustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            if (e.Node.LastNode != null)
                e.RepositoryItem = repositoryItemTextEditReadOnly;
        }

        private void RolesActualizare_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool bValidate = true;
                mEventCanceled = false;
                mEventNo = false;
                DialogResult drChange = DialogResult.Yes;
                if (mySaveData == true)
                {
                    if (!Validate())
                    {
                        mySaveData = false;
                        mEventCanceled = e.Cancel = true;
                    }
                    else
                    {
                        Save();
                        if (!mySaveData)
                        {
                            mySaveData = false;
                            mEventCanceled = e.Cancel = true;
                        }
                    }
                }
                else
                {
                    if (HasChanges() == true)
                    {
                        if ((drChange = XtraMessageBox.Show("Doriti sa salvati modificarile?", "SALNET",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) == DialogResult.Yes)
                        {
                            if ((bValidate = Validate()))
                            {
                                Save();
                                if (!mySaveData)
                                {
                                    mySaveData = false;
                                    mEventCanceled = e.Cancel = true;
                                }
                            }
                            else
                            {
                                mySaveData = false;
                                mEventCanceled = e.Cancel = true;
                            }
                        }
                        else if (drChange == DialogResult.Cancel)
                        {
                            mySaveData = false;
                            mEventCanceled = e.Cancel = true;
                        }
                        else
                        {
                            mEventNo = true;
                            mEventCanceled = true;
                        }
                    }
                }
                this.Cursor = Cursors.Default;
            }
            catch (System.Exception excep)
            {
                Context.HandleException(this, excep);
            }
        }

        private void RolesActualizare_FormClosed(object sender, FormClosedEventArgs e)
        {
            mDataSet.RejectChanges();
        }

        private void simpleButtonRenunta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonSalveaza_Click(object sender, EventArgs e)
        {
            mySaveData = true;
            this.Close();
        }

        private void simpleButtonListare_Click(object sender, EventArgs e)
        {
            this.treeListMeniu.ShowPrintPreview();
        }

        #endregion

        #region Private Methods
        private void ReadDefaultRole()
        {
            try
            {
                System.Configuration.AppSettingsReader appSettingsReader = new System.Configuration.AppSettingsReader();
                mDefaultTipAccess = (String)appSettingsReader.GetValue("DefaultRole", Type.GetType("System.String"));
            }
            catch
            {
            }
        }
        private void PrepareDataForTree()
        {
            foreach (DataRow dr in mDataSet.tblNavigation.Select("ParentGroupID is null"))
            {
                DataRow drNav = mDataSet.tblNavigation.FindByID((Guid)dr["ModulID"]);
                if (drNav == null)
                {
                    DataRow drNew = mDataSet.tblNavigation.NewRow();
                    drNew["ID"] = dr["ModulID"];
                    drNew["NAME"] = "Modul - " + dr["ModulName"].ToString();
                    drNew["ModulOrder"] = dr["ModulOrder"];
                    drNew["ModulID"] = dr["ModulID"];
                    mDataSet.tblNavigation.Rows.Add(drNew);
                }
                dr["ParentGroupID"] = dr["ModulID"];
            }
        }
        private void FillTipAccesToTree()
        {
            Guid gTipAccessDefault = Guid.Empty;
            DataRow[] drsTipAcces = mDataSet.tbxTipAcces.Select("CodIntern=" + mDefaultTipAccess);
            if (drsTipAcces.Length > 0)
                gTipAccessDefault = (Guid)drsTipAcces[0]["ID"];
            foreach (DataRow dr in mDataSet.tblNavigation.Rows)
            {
                if (mUtility.IsLeafID((Guid)dr["ID"], mDataSet.tblNavigation, "ParentGroupID"))
                {
                    DataRow[] drsRol = mDataSet.lnkRolesNavigation.Select("NavigationID='" + dr["ID"].ToString() + "' and RolesID='" + mID.ToString() + "'");
                    if (drsRol.Length > 0)
                        dr["TipAccesID"] = drsRol[0]["TipAccesID"];
                    else if (gTipAccessDefault != Guid.Empty)
                        dr["TipAccesID"] = gTipAccessDefault;
                }
            }
        }
        private void PrepareDeschiderBase()
        {
            foreach (DataRow dr in mDataSet.tblDeschidereBase)
            {
                dr["Inclus"] = false;
            }

            foreach (DataRow dr in mDataSet.lnkRolesDeschidereBase.Select("RolesID='" + this.mID.ToString() + "'"))
            {
                DataRow drDesch = mDataSet.tblDeschidereBase.FindByID((Guid)dr["DeschidereBaseID"]);
                if (drDesch != null)
                    drDesch["Inclus"] = true;

            }
        }

        private void Save()
        {
            try
            {
                if (!mySaveData)
                    return;

                SaveToDataSet();
                this.Cursor = Cursors.WaitCursor;
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
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private bool HasChanges()
        {
            bool bChanges = false;
            BindingContext[mDataView].EndCurrentEdit();
            if (mIsNew)
            {
                if (!String.IsNullOrEmpty(textEditRolName.Text.Trim()))
                    return true;
                if (mDataSet.tblNavigation.GetChanges() != null)
                    return true;
                if (mDataSet.tblDeschidereBase.GetChanges() != null)
                    return true;
                return false;
            }
            else
                bChanges = mController.DataSet.HasChanges();
            return bChanges;
        }
        private new bool Validate()
        {
            BindingContext[mDataView].EndCurrentEdit();
            bool bHasDeschidere = false;
            mySaveData = false;
            if (String.IsNullOrEmpty(this.textEditRolName.Text.Trim()))
            {
                textEditRolName.ErrorText = "Introduceti numele rolului!";
                textEditRolName.Focus();
                return false;
            }
            foreach (DataRow dr in mDataSet.tblDeschidereBase.Rows)
            {
                if ((bool)dr["Inclus"])
                {
                    bHasDeschidere = true;
                    break;
                }
            }
            if (!bHasDeschidere)
            {
                XtraMessageBox.Show("Trebuie sa alegeti cel putin o evidenta!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridControlEvidente.Focus();
                return false;
            }
            return mySaveData = true;
        }
        private void SaveToDataSet()
        {
            BindingContext[mDataView].EndCurrentEdit();

            #region Roles - Deschidere
            foreach (DataRow dr in mDataSet.lnkRolesDeschidereBase.Select("RolesID='" + this.mID.ToString() + "'"))
            {
                dr.Delete();
            }
            foreach (DataRow dr in mDataSet.tblDeschidereBase.Rows)
            {
                if ((bool)dr["Inclus"])
                {
                    DataRow drDesch = mDataSet.lnkRolesDeschidereBase.NewRow();
                    drDesch["ID"] = Guid.NewGuid();
                    drDesch["RolesID"] = mID;
                    drDesch["DeschidereBaseID"] = dr["ID"];
                    mDataSet.lnkRolesDeschidereBase.Rows.Add(drDesch);
                }
            }
            #endregion

            #region Roles - Navigation
            foreach (DataRow dr in mDataSet.lnkRolesNavigation.Select("RolesID='" + mID.ToString() + "'"))
            {
                dr.Delete();
            }
            foreach (DataRow dr in mDataSet.tblNavigation.Rows)
            {
                if (mUtility.IsLeafID((Guid)dr["ID"], mDataSet.tblNavigation, "ParentGroupID"))
                {
                    DataRow drNav = mDataSet.lnkRolesNavigation.NewRow();
                    drNav["ID"] = Guid.NewGuid();
                    drNav["RolesID"] = this.mID;
                    drNav["NavigationID"] = dr["ID"];
                    drNav["TipAccesID"] = dr["TipAccesID"];
                    mDataSet.lnkRolesNavigation.Rows.Add(drNav);
                }
            }
            #endregion

            mySaveData = true;
        }

        #endregion

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                mEventCanceled = mEventNo;
                base.Initialize();
                string sID = GetParameter("ID");
                if (String.IsNullOrEmpty(sID))
                {
                    mID = Guid.NewGuid();
                    mIsNew = true;
                }
                else
                    this.mID = new Guid(sID);
                mController = (RolesController)Context.GetSharedController("CommonGUIControllers.Admin.RolesController, CommonGUIControllers");
                mDataSet = (RolesDataSet)mController.DataSet;
                ReadDefaultRole();
                PrepareDataForTree();
                FillTipAccesToTree();
                PrepareDeschiderBase();
                mDataSet.AcceptChanges();
                if (mIsNew)
                {
                    DataRow drNew = mDataSet.tblRoles.NewRow();
                    drNew["ID"] = mID;
                    drNew["AplicatiiID"] = ContextUtilityClass.OnlyInstance.AplicatiiID;
                    drNew["RolName"] = string.Empty;
                    mDataSet.tblRoles.Rows.Add(drNew);
                }
                mDataView = new DataView(mDataSet.tblRoles);
                mDataView.RowFilter = "ID='" + this.mID.ToString() + "'";
                this.Bind();
                treeListMeniu.ExpandAll();
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }
        public override void Bind()
        {
            base.Bind();
            this.tblRolesBindingSource.DataSource = mDataView;
            this.treeListMeniu.DataSource = mDataSet.tblNavigation;
            this.gridControlEvidente.DataSource = mDataSet.tblDeschidereBase;
            this.repositoryItemLookUpEditTipAcces.DataSource = mDataSet.tbxTipAcces;
        }
        #endregion


    }
}
