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
using DevExpress.XtraEditors;
using Utilities;

namespace ComenziGUI
{
    public partial class DistrinuireLotActualizare : GSFramework.Window
    {
        #region Constructor
        public DistrinuireLotActualizare()
        {
            InitializeComponent();
        }
        #endregion


        #region  Class Fields
        private DistribuireDataSet mDataSet;
        private DistribuireController mController;
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
        private DistribuireDataSet.tblDistribuireLotRow drBase;
        Utility mUtil = new Utility();
        #endregion

        #region Private Methods

        private void RanduriNoi()
        {
            drBase = mDataSet.tblDistribuireLot.NewtblDistribuireLotRow();
            mID = Guid.NewGuid();
            drBase["ID"] = mID;
            drBase["Data"] = ucDatadata.GetDateTime;
            mDataSet.tblDistribuireLot.AddtblDistribuireLotRow(drBase);
        }

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
            DistribuireDataSet.tblDistribuireLotDetRow drdet =
                mDataSet.tblDistribuireLotDet.NewtblDistribuireLotDetRow();
            foreach (DataRow drRow in mDataSet.tblDistribuireLotDetalii.Select())
            {
                drdet = mDataSet.tblDistribuireLotDet.NewtblDistribuireLotDetRow();
                drdet["ID"] =drRow["ID"];
                drdet["DistribuireLotID"] = mID;
                drdet["ProduseID"] = drRow["ProduseID"];
                drdet["CantitateDistribuita"] = drRow["CantitateDistribuita"];
                mDataSet.tblDistribuireLotDet.AddtblDistribuireLotDetRow(drdet);
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
            if (!mUtil.IsNotObjectEmpty(lookUpEditCentru.EditValue))
            {
                mySaveData = false;
                lookUpEditCentru.ErrorText = "Completati denumirea centrului";
                return mySaveData;
            }
            return mySaveData;
        }

        #endregion

        #region  Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize();
                ucDatadata.SetTimeForDate = false;
                ucDatadata.Initialize();
                object obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Lot.CallerHandler");
                if (obj != null) this.mCallerHandle = (DistribuireLot)obj;
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Lot.IsNew");
                if (obj != null) mIsNew = Convert.ToBoolean(obj);
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Lot.LotBaseID");
                if (obj != null && (!string.IsNullOrEmpty(obj.ToString())))
                    mBaseID = new Guid(obj.ToString());
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Lot.ID");
                if (obj != null && (!string.IsNullOrEmpty(obj.ToString())))
                    mID = new Guid(obj.ToString());
                mController =
                 (DistribuireController)
                 Context.CreateController("CommonGUIControllers.GUI.DistribuireController,CommonGUIControllers");
                mController.LoadDate = !mIsNew;
                mController.LotBaseID = mBaseID;
                mController.DataLucru = ucDatadata.GetDateTime.Date;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (DistribuireDataSet)mController.DataSet;
                mDataSet.AcceptChanges();
                mDataView = new DataView(mDataSet.tblDistribuireLot);
                mDataView.RowFilter = "ID='" + mID.ToString() + "'";
                if (mIsNew)
                {
                    RanduriNoi();
                }
                else
                {
                    lookUpEditLot.EditValue = mID;
                    drBase = mDataSet.tblDistribuireLot.FindByID(mID);
                    if (mDataSet.tblDistribuireLot.Rows.Count > 0)
                        ucDatadata.UserDateTime = (DateTime)mDataSet.tblDistribuireLot.Rows[0]["Data"];
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
            tblCentruBindingSource.DataSource = mDataSet.tblCentru;
            tblLotBaseBindingSource.DataSource = mDataSet.tblLotBase;
            tblDistribuireLotDetaliiBindingSource.DataSource = mDataSet.tblDistribuireLotDetalii;
            mUtil.SetNumericMask(repositoryItemTextEditSuma, 2, true);

        }

        #endregion

        #region Events

        private void lookUpEditLot_Validated(object sender, EventArgs e)
        {
            if (mUtil.IsNotObjectEmpty(lookUpEditLot.EditValue))
            {
                Validate();
                mDataSet.tblDistribuireLotDetalii.Clear();
               
                mController.LotBaseID = (Guid)lookUpEditLot.EditValue;
                mController.LoadDate = true;
                mController.Load();
                gridControlDistibuie.RefreshDataSource();
                drBase["LotBaseID"] = (Guid)lookUpEditLot.EditValue;
                DataRow drLotBase = mDataSet.tblLotBase.FindByID((Guid)lookUpEditLot.EditValue);
                if (mUtil.IsNotObjectEmpty(drLotBase["TipCentruID"]))
                {
                    mDataSet.tblCentru.DefaultView.RowFilter = "TipCentruID='" + drLotBase["TipCentruID"] + "'";
                }
                else
                {
                    mDataSet.tblCentru.DefaultView.RowFilter = "";
                }
            }
        }

        private void lookUpEditCentru_Validated(object sender, EventArgs e)
        {
            if (mUtil.IsNotObjectEmpty(lookUpEditCentru.EditValue))
            {
                drBase["CentruID"] = (Guid)lookUpEditCentru.EditValue;
                mController.CentruID = (Guid)lookUpEditCentru.EditValue;
                mDataSet.tblDistribuireLotDetalii.Clear();
                mController.LoadDate = true;
                mController.Load();
                gridControlDistibuie.RefreshDataSource();
            }
        }

        private void gridViewDistribuie_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colCantitateDistribuita)
            {
                object objCant = gridViewDistribuie.GetRowCellValue(e.RowHandle, colCantitateDistribuita);
                object objcantt = gridViewDistribuie.GetRowCellValue(e.RowHandle, colCantitateTotala);
                if (objcantt != null && objcantt != string.Empty && objCant != null && objCant != string.Empty)
                {
                    decimal cantitate = Convert.ToDecimal(objcantt);
                    decimal cantitated = Convert.ToDecimal(objCant);
                    if (cantitate < cantitated)
                    {
                        XtraMessageBox.Show("Cantitatea totala mai mica decat cantitatea distribuita!");
                        return;
                    }
                    else
                    {
                        gridViewDistribuie.SetRowCellValue(e.RowHandle,colCantitateRamasa, cantitate- cantitated);
                    }
                }
            }
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

        private void DistrinuireLotActualizare_FormClosing(object sender, FormClosingEventArgs e)
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
                mCallerHandle.ReloadOnClose();
            }
            catch (Exception excep)
            {
                Context.HandleException(this, excep);
            }
        }
 
        #endregion

    
    }
}
