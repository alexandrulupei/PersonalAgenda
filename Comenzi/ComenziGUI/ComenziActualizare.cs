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
using GSFramework;
using Utilities;

namespace ComenziGUI
{
    public partial class ComenziActualizare : GSFramework.Window
    {
        #region  Constructor
        public ComenziActualizare()
        {
            InitializeComponent();
        }
        #endregion

        #region  Class Fields
        private ComenziDataSet mDataSet;
        private ComenziController mController;
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
        private Comenzi mCallerHandle;
        private ComenziDataSet.tblComandaBaseRow drBase;
        Utility mUtil = new Utility();
        #endregion

        #region Private Events
        private void lookUpEditLot_Validated(object sender, EventArgs e)
        {

            if (mIsNew)
            {


                if (mUtil.IsNotObjectEmpty(lookUpEditLot.EditValue))
                {
                    mDataSet.tblDetaliiComanda.Clear();
                    mDataSet.tblLotBase.Clear();
                    mController.LotBaseID = (Guid) lookUpEditLot.EditValue;
                    mController.Modifica = true;
                    mController.Load();
                    gridControlDetalii.RefreshDataSource();
                    drBase["LotID"] = (Guid) lookUpEditLot.EditValue;

                }
            }
        }

        private void ComenziActualizare_FormClosing(object sender, FormClosingEventArgs e)
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

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            mySaveData = true;
            this.Close();

        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridViewDetalii_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.Column == colCantitateComandata)
            {
                object objCant = gridViewDetalii.GetRowCellValue(e.RowHandle, colCantitateComandata);
                object objPret = gridViewDetalii.GetRowCellValue(e.RowHandle, colPret);
                object objtva = gridViewDetalii.GetRowCellValue(e.RowHandle, colCotaTVAID);
                object objcantInit = gridViewDetalii.GetRowCellValue(e.RowHandle, colCantitate);
                object objprod = gridViewDetalii.GetRowCellValue(e.RowHandle, colProduseID);
                decimal mPret = 0, mCantitate = 0, mValoareTva = 0, mCant = 0;
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
                if (objprod != null && objprod.ToString() != "")
                {
                    mprodus = (Guid)objprod;
                }
                if (objtva != null && objtva.ToString() != "")
                {
                    Guid mCotaTva = (Guid)objtva;
                    DataRow[] drTVA = mDataSet.Tables["tbxCotaTVA"].Select("ID='" + mCotaTva + "'");
                    if (drTVA.Length > 0)
                    {
                        if (mUtil.IsNotObjectEmpty(drTVA[0]["Valoare"]))
                        {
                            mValoareTva = Convert.ToDecimal(drTVA[0]["Valoare"]);
                        }
                    }
                }
                //if (mCantitate != 0)
                //{

                //    if (mDataSet.Tables["tblProdusComandat"].Select("ProduseID='" + mprodus + "'").Length > 0)
                //    {
                //        XtraMessageBox.Show("Produsul este comandat si nu este receptionat!");
                //        gridViewDetalii.SetRowCellValue(e.RowHandle, colCantitateComandata, 0);

                //    }
                //}

                if (mCant < mCantitate)
                {
                    XtraMessageBox.Show("Cantitatea dorita depaseste stocul");
                    gridViewDetalii.SetRowCellValue(e.RowHandle, colCantitateComandata, 0);
                    mCantitate = 0;

                }
                gridViewDetalii.SetRowCellValue(e.RowHandle, colValoare, mCantitate * mPret);
                gridViewDetalii.SetRowCellValue(e.RowHandle, colValoareTVA, mCantitate * mPret * mValoareTva / 100);
                gridViewDetalii.SetRowCellValue(e.RowHandle, colValoareCuTVA, mCantitate * mPret + mCantitate * mPret * mValoareTva / 100);
                gridViewDetalii.SetRowCellValue(e.RowHandle, colCantitateDisponibila, mCant - mCantitate)
                    ;
            }
        }

        private void ucDatadata_DateTimeChanged()
        {
            drBase["Data"] = ucDatadata.GetDateTime;
        }
        

        #endregion

        #region Private Methods

        private void RanduriNoi()
        {
            drBase = mDataSet.tblComandaBase.NewtblComandaBaseRow();
            mID = Guid.NewGuid();
            drBase["ID"] = mID;
            drBase["Data"] = ucDatadata.GetDateTime;
            drBase["CentruID"] = ContextUtilityClass.OnlyInstance.CentruID;
            mDataSet.tblComandaBase.AddtblComandaBaseRow(drBase);
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
            if (mIsNew)
            {

                ComenziDataSet.tblComandaDetRow drdet =
                    mDataSet.tblComandaDet.NewtblComandaDetRow();
                foreach (DataRow drRow in mDataSet.tblDetaliiComanda.Select("Valoare<>0"))
                {
                    drdet = mDataSet.tblComandaDet.NewtblComandaDetRow();
                    drdet["ID"] = drRow["ID"];
                    drdet["ComandaBaseID"] = mID;
                    drdet["ProduseID"] = drRow["ProduseID"];
                    drdet["Cantitate"] = drRow["CantitateComandata"];
                    drdet["Valoare"] = drRow["Valoare"];
                    drdet["ValoareTVA"] = drRow["ValoareTVA"];
                    mDataSet.tblComandaDet.AddtblComandaDetRow(drdet);
                }
            }

            else
            {
                foreach (DataRow drRow in mDataSet.tblDetaliiComanda.Select("Valoare<>0"))
                {
                    DataRow[] drsdet =
                        mDataSet.tblComandaDet.Select("ComandaBaseID='" + mID + "' AND ProduseID='" + drRow["ProduseID"] +
                                                      "'");
                    if (drsdet.Length>0)
                    {
                        foreach (DataRow drdet in drsdet)
                        {
                            drdet["Cantitate"] = drRow["CantitateComandata"];
                            drdet["Valoare"] = drRow["Valoare"];
                            drdet["ValoareTVA"] = drRow["ValoareTVA"];
                        }
                    }
                    else
                    {
                        ComenziDataSet.tblComandaDetRow drdet =
                    mDataSet.tblComandaDet.NewtblComandaDetRow();
                        drdet["ID"] = drRow["ID"];
                        drdet["ComandaBaseID"] = mID;
                        drdet["ProduseID"] = drRow["ProduseID"];
                        drdet["Cantitate"] = drRow["CantitateComandata"];
                        drdet["Valoare"] = drRow["Valoare"];
                        drdet["ValoareTVA"] = drRow["ValoareTVA"];
                        mDataSet.tblComandaDet.AddtblComandaDetRow(drdet);
                    }
                }

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
          
            return mySaveData;
        }


        private void PrelucrareDate()
        {
            decimal mValoareTva = 0, mCantCom = 0, mcantinit = 0, mpret = 0;
            foreach (DataRow dr in mDataSet.tblDetaliiComanda.Select())
            {
                Guid mCotaTva = (Guid) dr["CotaTVAID"];
                DataRow[] drTVA = mDataSet.Tables["tbxCotaTVA"].Select("ID='" + mCotaTva + "'");
                if (drTVA.Length > 0)
                {
                    if (mUtil.IsNotObjectEmpty(drTVA[0]["Valoare"]))
                    {
                        mValoareTva = Convert.ToDecimal(drTVA[0]["Valoare"]);
                    }
                }
                mCantCom = Convert.ToDecimal(dr["CantitateComandata"]);
                mcantinit = Convert.ToDecimal(dr["CantitateComandata"]);
                mpret = Convert.ToDecimal(dr["Pret"]);
                dr["Valoare"] = mCantCom * mpret;
                dr["ValoareTVA"] = mCantCom * mpret * mValoareTva / 100;
                dr["ValoareCuTVA"] = mCantCom * mpret + mCantCom * mpret * mValoareTva / 100;
                dr["CantitateDisponibila"] = mcantinit - mCantCom;
            }
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
                if (obj != null) this.mCallerHandle = (Comenzi)obj;
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Lot.IsNew");
                if (obj != null) mIsNew = Convert.ToBoolean(obj);
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Lot.LotBaseID");
                if (obj != null && (!string.IsNullOrEmpty(obj.ToString())))
                    mBaseID = new Guid(obj.ToString());
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Lot.ID");
                if (obj != null && (!string.IsNullOrEmpty(obj.ToString())))
                    mID = new Guid(obj.ToString());
                mController =
                 (ComenziController)
                 Context.CreateController("CommonGUIControllers.GUI.ComenziController,CommonGUIControllers");
                mController.LoadDate = false;
                mController.Modifica = !mIsNew;
                mController.LotBaseID = mBaseID;
                mController.ComadaBaseID = mID;
                mController.CentruID = ContextUtilityClass.OnlyInstance.CentruID;
                mController.Data = ucDatadata.GetDateTime.Date;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (ComenziDataSet)mController.DataSet;
                mDataSet.AcceptChanges();
                mDataView = new DataView(mDataSet.tblComandaBase);
                mDataView.RowFilter = "ID='" + mID.ToString() + "'";
                if (mIsNew)
                {
                    RanduriNoi();
                }
                else
                {
                    lookUpEditLot.EditValue = mBaseID;
                    lookUpEditLot.Enabled = false;
                    drBase = mDataSet.tblComandaBase.FindByID(mID);
                    if (mDataSet.tblComandaBase.Rows.Count > 0)
                    {
                        ucDatadata.UserDateTime = (DateTime) mDataSet.tblComandaBase.Rows[0]["Data"];
                        PrelucrareDate();
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
            tblDetaliiComandaBindingSource.DataSource = mDataSet.tblDetaliiComanda;
            tblLotBaseBindingSource.DataSource = mDataSet.tblLotBase;
            
            mUtil.SetNumericMask(repositoryItemTextEditSuma, 2, true);
       

        }

        #endregion

      
    }
}
