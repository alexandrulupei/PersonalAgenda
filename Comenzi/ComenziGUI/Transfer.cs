using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonDataSets.GUI;
using CommonGUIControllers.GUI;
using Utilities;
using DevExpress.XtraEditors;

namespace ComenziGUI
{
    public partial class Transfer : GSFramework.Window
    {
        #region Constructor
        public Transfer()
        {
            InitializeComponent();
        }
        #endregion


        #region  Class Fields
        private TransferDataSet mDataSet;
        private TransferController mController;
        private DataView mDataView = new DataView();
        private string mDataTableName = string.Empty;
        private string mWindowName = string.Empty;
        private Guid mFocusedID;
        private bool mIsAlege;
        private Guid mID;
        private Guid mBaseID;
        private String mDenumire;
        private string mCod;
        private bool mAbbreviationAlowNull = true;
        private bool mEventCanceled;
        private bool mUseCodAsReturnValue = true;
        private SortedList<string, object> mTagList = new SortedList<string, object>();
        private bool mIsNew;
        private Guid mPartenerID = Guid.Empty;
        private DistribuireLot mCallerHandle;
        private Utility mUtil = new Utility();
        #endregion

        #region Events
        private void lookUpEditLot_Validated(object sender, EventArgs e)
        {
            mDataSet.tblDate.Clear();
            if (mUtil.IsNotObjectEmpty(lookUpEditLot.EditValue))
            {
                mController.LotBaseID = (Guid)lookUpEditLot.EditValue;
            }
            if (mUtil.IsNotObjectEmpty(lookUpEditCentruSursa.EditValue))
            {
                mController.LoadDate = true;
                mController.CentruID = (Guid)lookUpEditCentruSursa.EditValue;
                mController.Load();


                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
            }
            gridControlDate.RefreshDataSource();
        }

        private void lookUpEditCentuSursa_Validated(object sender, EventArgs e)
        {
            mDataSet.tblDate.Clear();
            if (mUtil.IsNotObjectEmpty(lookUpEditCentruSursa.EditValue))
            {
                mController.LoadDate = true;
                mController.CentruID = (Guid)lookUpEditCentruSursa.EditValue;
                mController.Load();


                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
            }
            gridControlDate.RefreshDataSource();

        }

        private void lookUpEditTipCentru_Validated(object sender, EventArgs e)
        {
            if (mUtil.IsNotObjectEmpty(lookUpEditTipCentru.EditValue))
                mDataView.RowFilter = "TipCentruID='" + lookUpEditTipCentru.EditValue + "'";

        }

        private void lookUpEditCentruDestinatie_Validated(object sender, EventArgs e)
        {

        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            mySaveData = true;
            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Transfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool bValidate = true;
                DialogResult drChange = DialogResult.Yes;
                if (mySaveData)
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
                    if (HasChanges())
                    {
                        if ((drChange = XtraMessageBox.Show("Doriti sa salvati modificarile?", "Comenzi",
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
                            mEventCanceled = true;
                        }
                    }
                }
                Cursor = Cursors.Default;
                //mCallerHandle.ReloadOnClose();
            }
            catch (Exception excep)
            {
                Context.HandleException(this, excep);
            }

        }
        #endregion

        #region Private Methods

        private void Save()
        {
            try
            {
                if (!mySaveData)
                    return;

                SaveToDataSet();
                Cursor = Cursors.WaitCursor;
                if (mController.DataSet.HasChanges())
                {
                    mController.Perform();
                    if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        mySaveData = false;
                    }
                }
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool HasChanges()
        {
            bool bChanges = false;
            bChanges = mController.DataSet.HasChanges();
            mySaveData = true;
            return bChanges;
        }

        private void SaveToDataSet()
        {
            BindingContext[mDataView].EndCurrentEdit();
            Validate();
            TransferDataSet.tblTransferRow mRow = mDataSet.tblTransfer.NewtblTransferRow();

            foreach (DataRow dr in mDataSet.tblDate.Select("CantitateTranferata<> 0"))
            {
                mRow = mDataSet.tblTransfer.NewtblTransferRow();
                mRow["ID"] = Guid.NewGuid();
                mRow["Data"] = ucDatadata.GetDateTime;
                mRow["LotBaseID"] = lookUpEditLot.EditValue;
                mRow["CentruSursaID"] = lookUpEditCentruSursa.EditValue;
                mRow["CentruDestinatieID"] = lookUpEditCentruDestinatie.EditValue;
                mRow["ProduseID"] = dr["ProduseID"];
                mRow["CantitateTransfer"] = dr["CantitateTranferata"];
                mDataSet.tblTransfer.AddtblTransferRow(mRow);

            }

        }

        private bool Validate()
        {


            if (!mUtil.IsNotObjectEmpty(lookUpEditLot.EditValue))
            {
                mySaveData = false;
                lookUpEditLot.ErrorText = "Completati denumirea lotului";
                return mySaveData;
            }
            if (!mUtil.IsNotObjectEmpty(lookUpEditTipCentru.EditValue))
            {
                mySaveData = false;
                lookUpEditTipCentru.ErrorText = "Completati denumirea centrului destinatie";
                return mySaveData;
            }

            if (!mUtil.IsNotObjectEmpty(lookUpEditCentruDestinatie.EditValue))
            {
                mySaveData = false;
                lookUpEditCentruDestinatie.ErrorText = "Completati denumirea centrului destinatie";
                return mySaveData;
            }

            if (!mUtil.IsNotObjectEmpty(lookUpEditCentruSursa.EditValue))
            {
                mySaveData = false;
                lookUpEditCentruSursa.ErrorText = "Completati denumirea centrului sursa";
                return mySaveData;
            }
            return mySaveData;
        }

        #endregion

        #region Public Methods
        public override void Initialize()
        {
            base.Initialize();
            try
            {
                ucDatadata.SetTimeForDate = false;
                ucDatadata.Initialize();

                mController = (TransferController)
                     Context.CreateController("CommonGUIControllers.GUI.TransferController,CommonGUIControllers");

                mController.LoadDate = false;
                mController.Load();


                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
                mDataSet = (TransferDataSet)mController.DataSet;
                mDataView = new DataView(mDataSet.tblCentru);
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
            tblCentruBindingSource.DataSource = mDataView;
            tbxTipCentruBindingSource.DataSource = mDataSet.tbxTipCentru;
            tblLotBaseDataTableBindingSource.DataSource = mDataSet.tblLotBase;
            tblDateDataTableBindingSource.DataSource = mDataSet.tblDate;
            mUtil.SetNumericMask(repositoryItemTextEditSuma, 2, true);
        }
        #endregion

        private void gridViewDate_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colCantitateTranferata)
            {

                object objCant = gridViewDate.GetRowCellValue(e.RowHandle, colCantitateTranferata);
                object objPret = gridViewDate.GetRowCellValue(e.RowHandle, colPret);
                object objcantInit = gridViewDate.GetRowCellValue(e.RowHandle, colCantitateDisponibila);
                decimal mPret = 0, mCantitate = 0, mCant = 0;
                Guid mprodus = Guid.Empty;
                if (objCant != null && objCant.ToString() != "")
                {
                    mCantitate = Convert.ToDecimal(objCant);
                }
                if (objcantInit != null && objcantInit.ToString() != "")
                {
                    mCant = Convert.ToDecimal(objcantInit);
                }
                if (objPret != null && objPret.ToString() != "")
                {
                    mPret = Convert.ToDecimal(objPret);
                }
                if (mCant < mCantitate)
                {
                    XtraMessageBox.Show("Cantitatea dorita depaseste stocul");
                    gridViewDate.SetRowCellValue(e.RowHandle, colCantitateTranferata, 0);

                }
                gridViewDate.SetRowCellValue(e.RowHandle, colValoareTransferta, mCantitate * mPret);
                gridViewDate.SetRowCellValue(e.RowHandle, colCantitateRamasa, mCant - mCantitate);
            }

        }

       
    }
}
