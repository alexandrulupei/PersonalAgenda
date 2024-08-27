using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class RolesHome : BaseWindow
    {

        #region Constructor
        public RolesHome()
        {
            InitializeComponent();
        }

        

        #endregion
        
        #region Class Fields
        private RolesDataSet mDataSet;
        private RolesController mController;
        private Guid mID = Guid.Empty;
        private Utility mUtility = new Utility();
        #endregion

        #region Events
        private void RolesHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Context.ReleaseSharedController("CommonGUIControllers.Admin.RolesController, CommonGUIControllers");
            this.Context.SetCurrentConnection(ContextUtilityClass.OnlyInstance.DataBaseCurrentConnectionString);
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                ToogleNavBarItems(false);
            }
            else
            {
                ToogleNavBarItems(true);
                DataRow dr = mUtility.GetSelectedRow(this.gridControl1);
                if (dr != null)
                    this.mID = (Guid)dr["RolesID"];
            }

        }
        #endregion

        #region Private Methods
        private void ToogleNavBarItems(bool pEnabled)
        {
            base.navBarItemModifica.Enabled = base.navBarItemSterge.Enabled = pEnabled;
        }
        private void SyncRoleDescription()
        {
            foreach (DataRow dr in mDataSet.tblRoles.Rows)
            {
                DataRow[] drs = dr.GetChildRows("FK_lnkRolesDeschidereBase_tblRoles");
                foreach (DataRow drRoles in drs)
                {
                    if (drRoles["RolDescription"].ToString() != dr["RolDescription"].ToString())
                        drRoles["RolDescription"] = dr["RolDescription"];
                }
            }
        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                base.Initialize(this.gridControl1);
                mController = (RolesController)Context.GetSharedController("CommonGUIControllers.Admin.RolesController, CommonGUIControllers");
                mController.AplicatiiID = ContextUtilityClass.OnlyInstance.AplicatiiID;
                mController.Load();
                if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
                mDataSet = (RolesDataSet)mController.DataSet;
                base.navBarItemAlege.Visible = base.navBarItemSalvare.Visible = false;
                ToogleNavBarItems(false);
                this.Bind();
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }
        public override void Bind()
        {
            base.Bind();
            mDataSet.lnkRolesDeschidereBase.DefaultView.Sort = "RolesID";
            this.gridControl1.DataSource = mDataSet.lnkRolesDeschidereBase.DefaultView;
            this.repositoryItemLookUpEditDeschidere.DataSource = mDataSet.tblDeschidereBase;
            this.repositoryItemLookUpEditRoles.DataSource = mDataSet.tblRoles;
        }
        public override void Adauga()
        {
            using (RolesActualizare wnd = (RolesActualizare)Context.CreateDialogWindow("ComenziGUI.RolesActualizare, ComenziGUI"))
            {
                if (wnd.DialogResult == DialogResult.OK)
                {
                    SyncRoleDescription();
                    mDataSet.AcceptChanges();
                    mUtility.SetSelectedRowByCustomColumn(gridView1, wnd.ID, "RolesID");
                }
                Context.CreatedWindow = null;
            }
        }
        public override void Modifica()

        {
            Guid gID = mID;
            using (RolesActualizare wnd = (RolesActualizare)Context.CreateDialogWindow("ComenziGUI.RolesActualizare, ComenziGUI", "ID=" + mID.ToString()))
            {
                if (wnd.DialogResult == DialogResult.OK)
                {
                    SyncRoleDescription();
                    mDataSet.AcceptChanges();
                    mUtility.SetSelectedRowByCustomColumn(gridView1, gID, "RolesID");
                }
                Context.CreatedWindow = null;
            }
        }
        public override void Sterge()
        {
            if (mUtility.DeleteConfirmation())
            {
                DataRow drRole = mDataSet.tblRoles.FindByID(mID);
                if (drRole != null)
                    drRole.Delete();
                foreach (DataRow dr in mDataSet.lnkRolesDeschidereBase.Select("RolesID='" + this.mID.ToString() + "'"))
                {
                    dr.Delete();
                }
                foreach (DataRow dr in mDataSet.lnkRolesNavigation.Select("RolesID='" + mID.ToString() + "'"))
                {
                    dr.Delete();
                }
                mController.Perform();
                if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    try
                    {
                        SqlException ex = (SqlException)mController.ServerException.InnerException;
                        if (ex.Number == 547)
                        {
                            mDataSet.RejectChanges();
                            XtraMessageBox.Show("Acest rol nu poate fi sters deoarece este folosit.\n" +
                                "Pentru a putea sterge eliminati toate inregistrarile care folosesc acest rol!",
                                "Comenzi", MessageBoxButtons.OK, MessageBoxIcon.None);
                            return;
                        }
                        else
                        {
                            Context.HandleException(mController.ServerException.ToString());
                            mySaveData = false;
                            return;
                        }
                    }
                    catch
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        mySaveData = false;
                        return;
                    }
                }
                mDataSet.AcceptChanges();
            }
            base.Sterge();
        }
        public override void Iesire()
        {
            this.Close();
        }
        #endregion



    }
}
