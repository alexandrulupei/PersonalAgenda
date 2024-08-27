using System;
using System.Data;
using System.Windows.Forms;
using ComenziBase;
using CommonDataSets.GUI;
using CommonGUIControllers.Admin;
using DevExpress.XtraEditors;
using GSFramework;

namespace ComenziGUI
{
    public partial class UsersHome : BaseWindow
    {
        #region Constructor
        public UsersHome()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields
        private UsersDataSet mDataSet;
        private UsersController mController;
        Guid mAplicatiiID;
        private DataTable TipConnectionTable;
        #endregion

        #region Events

        private void gridViewUsers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                ToogleNavBarItems(false);
            }
            else
            {
                ToogleNavBarItems(true);
                DataRow dr = new Utilities.Utility().GetSelectedRow(this.gridControlUsers);
                if (dr != null)
                {
                    if (Convert.ToBoolean(dr["IsActive"]))
                        base.navBarItemActualizare_Custom2.Enabled = false;
                    if (dr["UserName"].ToString().Equals("Admin", StringComparison.InvariantCultureIgnoreCase))
                    {
                        navBarItemSterge.Enabled = base.navBarItemActualizare_Custom1.Enabled = base.navBarItemActualizare_Custom2.Enabled = false;
                    }
                }
            }
        }
        private void UsersHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Context.ReleaseSharedController("CommonGUIControllers.Admin.UsersController, CommonGUIControllers");
            this.Context.SetCurrentConnection(ContextUtilityClass.OnlyInstance.DataBaseCurrentConnectionString);
        }


        #endregion

        #region Private Methods
        private void ToogleNavBarItems(bool pEnabled)
        {
            base.navBarItemModifica.Enabled = base.navBarItemSterge.Enabled = base.navBarItemActualizare_Custom2.Enabled = pEnabled;
        }
        private void SelectGridViewRow(DataRow pDataRow, Guid pUserID)
        {
            for (int i = 0; i < gridViewUsers.RowCount; i++)
            {
                pDataRow = gridViewUsers.GetDataRow(i);
                if ((Guid)pDataRow["ID"] == pUserID)
                {
                    gridViewUsers.FocusedRowHandle = i;
                    break;
                }
            }
        }
        private void DezactivareReactivare(DataRow pDataRow, bool pActiv)
        {
            Guid userID = (Guid)pDataRow["ID"];
            pDataRow["IsActive"] = pActiv;
            mController.Perform();
            if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
            {
                Context.HandleException(mController.ServerException.ToString());
                return;
            }
            mDataSet.tblUsers.Clear();
            mController.Load();
            if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
            {
                Context.HandleException(mController.ServerException.ToString());
                return;
            }
            mDataSet = (UsersDataSet)mController.DataSet;
            mDataSet.AcceptChanges();
            this.gridControlUsers.RefreshDataSource();
            SelectGridViewRow(pDataRow, userID);
        }

        /// <summary>
        /// Creates and binds TipConnectionTable
        /// </summary>
        private void BindConnectionField()
        {
            DataTable table = new DataTable();
            DataColumn c1 = new DataColumn("Description", Type.GetType("System.String"));
            table.Columns.Add(c1);
            DataColumn c2 = new DataColumn("Value", Type.GetType("System.Byte"));
            table.Columns.Add(c2);
            DataRow r1 = table.NewRow();
            r1["Description"] = "Local si remote";
            r1["Value"] = 0;
            table.Rows.Add(r1);
            DataRow r2 = table.NewRow();
            r2["Description"] = "Local";
            r2["Value"] = 1;
            table.Rows.Add(r2);
            this.TipConnectionTable = table;
            repositoryItemLookUpEditTipConexiune.DataSource = this.TipConnectionTable;
            repositoryItemLookUpEditTipConexiune.DisplayMember = "Description";
            repositoryItemLookUpEditTipConexiune.ValueMember = "Value";
        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                base.Initialize(this.gridControlUsers);
                this.Context.SetCurrentConnection(ContextUtilityClass.OnlyInstance.DataBaseCurrentConnectionString);
                mController = (UsersController)Context.GetSharedController("CommonGUIControllers.Admin.UsersController, CommonGUIControllers");
                mAplicatiiID = ContextUtilityClass.OnlyInstance.AplicatiiID;
                mController.AplicatiiID = mAplicatiiID;
                mController.Load();
                if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (UsersDataSet)mController.DataSet;

                base.navBarItemAlege.Visible = base.navBarItemSalvare.Visible = false;
                base.navBarItemSterge.Caption = "Dezactivare (Alt+X)";
                base.navBarItemActualizare_Custom2.Visible = true;
                base.navBarItemActualizare_Custom2.Caption = "Reactivare (Alt+R)";
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
            this.gridControlUsers.DataSource = mDataSet.tblUsers.DefaultView;
            // TipConnection table and binding
            this.BindConnectionField();
        }
        public override void Adauga()
        {
            using (Context.CreateDialogWindow("ComenziGUI.UsersActualizare, ComenziGUI", "pIsNew=true"))
            {
                Context.CreatedWindow = null;
            }
        }
        public override void Modifica()
        {
            DataRow dr = new Utilities.Utility().GetSelectedRow(this.gridControlUsers);
            if (dr == null)
            {
                XtraMessageBox.Show("Selectati linia pe care doriti sa o modificati!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Context.AddUserContextParameterList("UsersActualizare.SelectedRow", dr);
            using (Context.CreateDialogWindow("ComenziGUI.UsersActualizare, ComenziGUI", "pIsNew=false"))
            {
                Context.CreatedWindow = null;
            }
            Context.DeleteEntryFromUserContextParameterList("UsersActualizare.SelectedRow");
        }
        public override void Sterge()
        {
            base.Sterge();
            DataRow dr = new Utilities.Utility().GetSelectedRow(this.gridControlUsers);
            if (dr != null && XtraMessageBox.Show("Sunteti siguri ca doriti sa dezactivati acest utilizator?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                DezactivareReactivare(dr, false);
            }
        }
        /// <summary>
        /// Reactivare users
        /// </summary>
        public override void ActualizareItem2()
        {
            if (!base.navBarItemActualizare_Custom2.Enabled)
                return;
            DataRow dr = new Utilities.Utility().GetSelectedRow(this.gridControlUsers);
            if (dr != null && XtraMessageBox.Show("Sunteti siguri ca doriti sa reactivati acest utilizator?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                DezactivareReactivare(dr, true);
            }
        }
        public override void Iesire()
        {
            this.Close();
        }
        #endregion



    }
}
