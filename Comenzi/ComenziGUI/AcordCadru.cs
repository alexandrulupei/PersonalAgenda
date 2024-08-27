using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComenziBase;
using CommonGUIControllers.GUI;
using CommonDataSets.GUI;
using Utilities;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;
using DevExpress.XtraEditors;


namespace ComenziGUI
{
    public partial class AcordCadru :BaseWindow
    {
        #region Constructor
        public AcordCadru()
        {
            InitializeComponent();
        }
        #endregion 

        #region Class Fields
        private AcordCadruDataSet mDataSet;
        private AcordCadruController mController;
        private Utility mUtil = new Utility();
        #endregion 

        #region Private Methods

        private void RemoveRow()
        {
            DataRow dr = mUtil.GetSelectedRow(gridControlAcordCadru);
            mController.LoadDate = true;
            if (mUtil.IsNotObjectEmpty(dr["ID"]))
            {
                mController.AcordCadruBaseID= (Guid)dr["ID"];
            }
            mController.Load();

            if (dr != null)
            {

                foreach (DataRow drdet in mDataSet.tblAcordCadruDet.Select("AcordCadruID='" + dr["ID"] + "'"))
                {
                    drdet.Delete();
                }

                foreach (DataRow drbase in mDataSet.tblAcordCadru.Select("ID='" + dr["ID"] + "'"))
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


        #region Public Methods
        public override void Initialize()
        {
            try
            {
                base.Initialize(gridControlAcordCadru);
                navBarItemAlege.Visible = false;
                labelBaseWindowHeader.Text = "Acord Cadru";
                navBarItemSalvare.Visible = false;
                //navBarItemSterge.Visible = false;
                mController =
                    (AcordCadruController)
                    Context.CreateController("CommonGUIControllers.GUI.AcordCadruController,CommonGUIControllers");
                mController.LoadDate = false;
                mController.DataLucru= GSFramework.ContextUtilityClass.OnlyInstance.DataLucru;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (AcordCadruDataSet)mController.DataSet;
                mDataSet.AcceptChanges();
                string sNrFormatString = string.Empty, sGeneralFormat = string.Empty;
                mUtil.FormatString(3, true, ref sNrFormatString, ref sGeneralFormat);
                GridGroupSummaryItemCollection collection = gridViewAcordCadru.GroupSummary;
                foreach (GridGroupSummaryItem item in collection)
                {
                    if (item.Index >= 0)
                        item.DisplayFormat = sGeneralFormat;
                }

                GridColumnCollection cols = gridViewAcordCadru.Columns;
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
            tblAcordCadruHomeBindingSource.DataSource = mDataSet.tblAcordCadruHome.DefaultView;
            mUtil.SetNumericMask(repositoryItemTextEditSuma, 2, true);
            mUtil.SetDateTimeFormatFromConfig(repositoryItemDateEditData);
            gridViewAcordCadru.ExpandAllGroups();
            repositoryItemGridLookUpEditTipCentru.DataSource = mDataSet.tbxTipCentru;
            repositoryItemGridLookUpEditTipCentru.DisplayMember = "Description";
            repositoryItemGridLookUpEditTipCentru.ValueMember = "ID";
        }


        public override void Iesire()
        {

            this.Close();
        }



        public override void Adauga()
        {
            base.Adauga();
            Context.AddUserContextParameterList("ComenziGUI.AcordCadru.CallerHandler", this);
            Context.AddUserContextParameterList("ComenziGUI.AcordCadru.IsNew", true);
            using (Context.CreateDialogWindow("ComenziGUI.AcordCadruActualizare, ComenziGUI"))
            {
                Context.CreatedWindow = null;
            }
            Context.DeleteEntryFromUserContextParameterList("ComenziGUI.AcordCadru.CallerHandler");
            Context.DeleteEntryFromUserContextParameterList("ComenziGUI.AcordCadru.IsNew");
        }

        public override void Modifica()
        {
            base.Modifica();
            DataRow dr = mUtil.GetSelectedRow(gridControlAcordCadru);
            if (dr != null)
            {
                Context.AddUserContextParameterList("ComenziGUI.AcordCadru.CallerHandler", this);
                Context.AddUserContextParameterList("ComenziGUI.AcordCadru.IsNew", false);
                Context.AddUserContextParameterList("ComenziGUI.AcordCadru.AcordCadruBaseID", dr["ID"]);
                using (Context.CreateDialogWindow("ComenziGUI.AcordCadruActualizare, ComenziGUI"))
                {
                    Context.CreatedWindow = null;
                }
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.AcordCadru.CallerHandler");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.AcordCadru.IsNew");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.AcordCadru.AcordCadruBaseID");
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
            gridViewAcordCadru.ExpandAllGroups();
        }
        #endregion 


    }
}
