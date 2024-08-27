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
using CommonGUIControllers.GUI;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraVerticalGrid.Utils;
using Utilities;

namespace ComenziGUI
{
    public partial class Lot : BaseWindow
    {
        #region Constructor
        public Lot()
        {
            InitializeComponent();
        }
        #endregion

        #region  Class Fields

        private LotDataSet mDataSet;
        private LotController mController;
        Utility mUtil = new Utility();
        #endregion

        #region Private Methods

        private void RemoveRow()
        {
            DataRow dr = mUtil.GetSelectedRow(gridControlLot);
            mController.LoadDate = true;
            if (mUtil.IsNotObjectEmpty(dr["ID"]))
            {
                mController.LotBaseID = (Guid) dr["ID"];
            }
            mController.Load();

            if (dr != null)
            {

                foreach (DataRow drdet in mDataSet.tblLotDet.Select("LotBaseID='"+dr["ID"]+"'"))
                {
                    drdet.Delete();
                }

                foreach (DataRow drbase in mDataSet.tblLotBase.Select("ID='"+dr["ID"]+"'"))
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

        #endregion

        #region  Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize(gridControlLot);
                navBarItemAlege.Visible = false;
                labelBaseWindowHeader.Text = "Loturi";
                navBarItemSalvare.Visible = false;
                //navBarItemSterge.Visible = false;
                mController =
                    (LotController)
                    Context.CreateController("CommonGUIControllers.GUI.LotController,CommonGUIControllers");
                mController.LoadDate = false;
                mController.Data = GSFramework.ContextUtilityClass.OnlyInstance.DataLucru;
                mController.Load();
                
                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (LotDataSet)mController.DataSet;
                mDataSet.AcceptChanges();
                string sNrFormatString = string.Empty, sGeneralFormat = string.Empty;
                mUtil.FormatString(2, true, ref sNrFormatString, ref sGeneralFormat);
                GridGroupSummaryItemCollection collection = gridViewLot.GroupSummary;
                foreach (GridGroupSummaryItem item in collection)
                {
                    if (item.Index >= 0)
                        item.DisplayFormat = sGeneralFormat;
                }

                GridColumnCollection cols = gridViewLot.Columns;
                foreach (GridColumn col in cols)
                {
                    if (col.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                    {
                        col.SummaryItem.DisplayFormat = sGeneralFormat;
                    }
                }
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
            tblLotHomeBindingSource.DataSource = mDataSet.tblLotHome.DefaultView;
            mUtil.SetNumericMask(repositoryItemTextEditsuma,2,true);
            mUtil.SetDateTimeFormatFromConfig(repositoryItemDateEditData);
            gridViewLot.ExpandAllGroups();
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
           using (Context.CreateDialogWindow("ComenziGUI.LotActualizare, ComenziGUI"))
           {
               Context.CreatedWindow = null;
           }
           Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.CallerHandler");
           Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.IsNew");
        }

        public override void Modifica()
        {
          base.Modifica();
            DataRow dr = mUtil.GetSelectedRow(gridControlLot);
            if (dr != null)
            {
                Context.AddUserContextParameterList("ComenziGUI.Lot.CallerHandler", this);
                Context.AddUserContextParameterList("ComenziGUI.Lot.IsNew", false);
                Context.AddUserContextParameterList("ComenziGUI.Lot.LotBaseID", dr["ID"]);
                using (Context.CreateDialogWindow("ComenziGUI.LotActualizare, ComenziGUI"))
                {
                    Context.CreatedWindow = null;
                }
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.CallerHandler");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.IsNew");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.LotBaseID");
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
            gridViewLot.ExpandAllGroups();
        }
        #endregion

    }
}
