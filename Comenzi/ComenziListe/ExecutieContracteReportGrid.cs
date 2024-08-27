using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonDataSets.Liste;
using CommonGUIControllers.Liste;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using Utilities;

namespace ComenziListe
{
    public partial class ExecutieContracteReportGrid : BaseWindowGrid
    {
        #region Constructor
        public ExecutieContracteReportGrid()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields

        private string mAssemblyName = string.Empty;
        private ExecutieContracteDataSet mDataSet = new ExecutieContracteDataSet();
        private ExecutieContracteController mController = new ExecutieContracteController();
        private Guid mLotID = Guid.Empty;
        private Guid mCentruID = Guid.Empty;
        private Utility mUtil = new Utility();
        private bool mIsprocent = false;
        #endregion

        #region Public Methods

        public override void Initialize()
        {
            try
            {
                mAssemblyName= "Comenzi.ExecutieContracte, ComenziListe";
                base.AssemblyName = mAssemblyName;
                base.mCuDataListare = true;
                base.Initialize(gridControlLista);

           
                object obj = Context.GetParameterValueUserContextParameterList("ComenziListe.ExecutieContracte.CentruID");
                if (obj != null && obj.ToString() != string.Empty) mCentruID = (Guid)obj;
                obj = Context.GetParameterValueUserContextParameterList("ComenziListe.ExecutieContracte.LotID");
                if (obj != null && obj.ToString() != string.Empty)
                    mLotID = (Guid)obj;
                obj = Context.GetParameterValueUserContextParameterList("ComenziListe.ExecutieContracte.IsProcent");
                if (obj != null && obj.ToString() != string.Empty)
                    mIsprocent = (bool)obj;

                mController = (ExecutieContracteController)Context.CreateController("CommonGUIControllers.Liste.ExecutieContracteController,CommonGUIControllers");
                mController.LoadDate = true;
                mController.CentruID = mCentruID;
                mController.LotBaseID = mLotID;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

             
                mDataSet = (ExecutieContracteDataSet)mController.DataSet;
                mDataSet.AcceptChanges();
                string sNrFormatString = string.Empty, sGeneralFormat = string.Empty;
                mUtil.FormatString(2, true, ref sNrFormatString, ref sGeneralFormat);

                GridGroupSummaryItemCollection collection = gridViewDate.GroupSummary;
                foreach (GridGroupSummaryItem item in collection)
                {
                    if (item.Index >= 0)
                        item.DisplayFormat = sGeneralFormat;
                }

                GridColumnCollection cols = gridViewDate.Columns;
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
            if (mIsprocent)
            {
                gridControlLista.DataSource = mDataSet.tblListaProcent.DefaultView;
                gridControlLista.MainView = gridViewProcent;
                mListName = "Procent Executie Contracte";
                labelTitle.Text = "Procent Executie Contracte";
            }
            else
            {
                gridControlLista.DataSource = mDataSet.tblLista.DefaultView;
                gridControlLista.MainView = gridViewDate;
                mListName = "Executie Contracte";
                labelTitle.Text = "Executie Contracte";
            }
            //tblListaBindingSource.DataSource = mDataSet.tblLista;
            gridViewDate.ExpandAllGroups();
            mUtil.SetNumericMask(repositoryItemTextEditSuma,2, true);
            //gridViewDate.DataSource = mDataSet.tblListaProcent.DefaultView;
        }

        #endregion

        private void gridControlLista_Click(object sender, EventArgs e)
        {

        }
    }
}
