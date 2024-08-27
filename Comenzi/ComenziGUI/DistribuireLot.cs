using ComenziBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonDataSets.GUI;
using CommonGUIControllers.GUI;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using Utilities;

namespace ComenziGUI
{
    public partial class DistribuireLot : BaseWindow
    {
        #region Constructor
        public DistribuireLot()
        {
            InitializeComponent();
        }
       #endregion


        #region  Class Fields

        private DistribuireDataSet mDataSet;
        private DistribuireController mController;
        Utility mUtil = new Utility();
        #endregion

        private void RemoveRow()
        {
            DataRow dr = mUtil.GetSelectedRow(gridControlDistribuire);
    
            if (dr != null)
            {

                foreach (DataRow drdet in mDataSet.tblDistribuireLotDet.Select("DistribuireLotID='" + dr["ID"] + "'"))
                {
                    drdet.Delete();
                }

                foreach (DataRow drbase in mDataSet.tblDistribuireLot.Select("ID='" + dr["ID"] + "'"))
                {
                    drbase.Delete();
                }
            }

            mController.Perform();
            if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
            {
                try
                {
                    SqlException ex = (SqlException)mController.ServerException.InnerException;
                    if (ex.Number == 547)
                    {
                        dr.RejectChanges();
                        dr.RowError = string.Empty;
                        XtraMessageBox.Show(
                            "Aceasta inregistrare nu poate fi stearsa permanent din baza de date deoarece este folosita in alte tabele.",
                            "Comenzi", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            ReloadOnClose();
        }

        #region  Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize(gridControlDistribuire);
                navBarItemAlege.Visible = false;
                labelBaseWindowHeader.Text = "Distribuire Lot";
                navBarItemSalvare.Visible = false;
                //navBarItemSterge.Visible = false;
                navBarItemModifica.Visible = false;
                navBarItemActualizare_Custom1.Visible = true;
                navBarItemActualizare_Custom1.Caption = "Transfer";
                mController =
                    (DistribuireController)
                    Context.CreateController("CommonGUIControllers.GUI.DistribuireController,CommonGUIControllers");
                mController.LoadDate = false;
                mController.DataLucru = GSFramework.ContextUtilityClass.OnlyInstance.DataLucru;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (DistribuireDataSet)mController.DataSet;
                mDataSet.AcceptChanges();
                this.Bind();
                gridViewDistribuire.ExpandAllGroups();
                string sNrFormatString = string.Empty, sGeneralFormat = string.Empty;
                mUtil.FormatString(2, true, ref sNrFormatString, ref sGeneralFormat);
                GridGroupSummaryItemCollection collection = gridViewDistribuire.GroupSummary;
                foreach (GridGroupSummaryItem item in collection)
                {
                    if (item.Index >= 0)
                        item.DisplayFormat = sGeneralFormat;
                }

                GridColumnCollection cols = gridViewDistribuire.Columns;
                foreach (GridColumn col in cols)
                {
                    if (col.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                    {
                        col.SummaryItem.DisplayFormat = sGeneralFormat;
                    }
                }

            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }

        }

        public override void Bind()
        {
            base.Bind();
            tblHomeBindingSource.DataSource = mDataSet.tblHome.DefaultView;
            mUtil.SetNumericMask(repositoryItemTextEditsuma, 2, true);
            gridViewDistribuire.ExpandAllGroups();
        }


        public override void Iesire()
        {

            this.Close();
        }



        public override void Adauga()
        {
            base.Adauga();
            Context.AddUserContextParameterList("ComenziGUI.Lot.CallerHandler", this);
            Context.AddUserContextParameterList("ComenziGUI.Lot.IsNew", true);
            using (Context.CreateDialogWindow("ComenziGUI.DistrinuireLotActualizare, ComenziGUI"))
            {
                Context.CreatedWindow = null;
            }
            Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.CallerHandler");
            Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.IsNew");
        }

        public override void Modifica()
        {
            base.Modifica();
            DataRow dr = mUtil.GetSelectedRow(gridControlDistribuire);
            if (dr != null)
            {
                Context.AddUserContextParameterList("ComenziGUI.Lot.CallerHandler", this);
                Context.AddUserContextParameterList("ComenziGUI.Lot.IsNew", false);
                Context.AddUserContextParameterList("ComenziGUI.Lot.LotBaseID", dr["LotBaseID"]);
                Context.AddUserContextParameterList("ComenziGUI.Lot.ID", dr["ID"]);
                using (Context.CreateDialogWindow("ComenziGUI.DistrinuireLotActualizare, ComenziGUI"))
                {
                    Context.CreatedWindow = null;
                }
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.CallerHandler");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.IsNew");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.LotBaseID");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.ID");
            }
        }

        public override void Sterge()
        {
            if (new Utility().DeleteConfirmation())
            {
                RemoveRow();
            }
        }
        public void ReloadOnClose()
        {
            mDataSet.Clear();
            mController.LoadDate = false;
            mController.Load();
            if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
            {
                Context.HandleException(mController.ServerException.ToString());
                return;
            }
            gridViewDistribuire.ExpandAllGroups();
        }
        public override void ActualizareItem1()
        {
            base.ActualizareItem1();
         
            using (Context.CreateDialogWindow("ComenziGUI.Transfer, ComenziGUI"))
            {
                Context.CreatedWindow = null;
            }
          
        }
        #endregion
    }
}
