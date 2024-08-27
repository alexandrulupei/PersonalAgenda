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
    public partial class AdaugareReceptie : GSFramework.Window
    {
        #region Constructor

        public AdaugareReceptie()
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

        #region Events
        private void gridViewReceptie_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colCantitateRec)
            {
                object objCant = gridViewReceptie.GetRowCellValue(e.RowHandle, colCantitateRec);
                object objCantTot = gridViewReceptie.GetRowCellValue(e.RowHandle, colCantitateReceptionata);
                object objPret = gridViewReceptie.GetRowCellValue(e.RowHandle, colPret);
                object objtva = gridViewReceptie.GetRowCellValue(e.RowHandle, colCotaTVAID);
                object objcantInit = gridViewReceptie.GetRowCellValue(e.RowHandle, colCantitate);
                decimal mPret = 0, mCantitate = 0, mValoareTva = 0, mCant = 0, mcanttot = 0;
                if (objCant != null && objCant.ToString() != "")
                {
                    mCantitate = Convert.ToDecimal(objCant);
                }
                if (objCant != null && objCant.ToString() != "")
                {
                    mcanttot = Convert.ToDecimal(objCantTot);
                }
                if (objcantInit != null && objcantInit.ToString() != "")
                {
                    mCant = Convert.ToDecimal(objcantInit);
                }
                if (objPret != null && objPret.ToString() != "")
                {
                    mPret = Convert.ToDecimal(objPret);
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
                if (mCant < mCantitate + mcanttot)
                {
                    XtraMessageBox.Show("Cantitatea dorita depaseste stocul");
                    gridViewReceptie.SetRowCellValue(e.RowHandle, colCantitateRec,0);
                    return;
                }
                gridViewReceptie.SetRowCellValue(e.RowHandle, colValoare, mCantitate * mPret);
                gridViewReceptie.SetRowCellValue(e.RowHandle, colValoareTVA, mCantitate * mPret * mValoareTva / 100);
                gridViewReceptie.SetRowCellValue(e.RowHandle, colValoareCuTVA, mCantitate * mPret + mCantitate * mPret * mValoareTva / 100);
                gridViewReceptie.SetRowCellValue(e.RowHandle, colCantitateDisponibila, mCant - mCantitate);
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

        private void AdaugareReceptie_FormClosing(object sender, FormClosingEventArgs e)
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
           
            Validate();
            ComenziDataSet.tblReceptieComandaDetRow drdet = mDataSet.tblReceptieComandaDet.NewtblReceptieComandaDetRow();
            ComenziDataSet.tblReceptieComandaBaseRow drBase = mDataSet.tblReceptieComandaBase.NewtblReceptieComandaBaseRow();
            Guid mReceptieID= Guid.NewGuid();

            DataRow[] drReceptii = mDataSet.tblReceptieHome.Select("CantitateRec>0");
            if (drReceptii.Length > 0)
            {
                drBase["ID"] = mReceptieID;
                drBase["NumarFactura"] = textEditFactura.Text;
                drBase["NumarNir"] = textEditNir.Text;
                drBase["DataReceptie"] = ucDataReceptie.GetDateTime;
                drBase["ComandaBaseID"] = mBaseID;
                mDataSet.tblReceptieComandaBase.AddtblReceptieComandaBaseRow(drBase);

                foreach (DataRow drRow in mDataSet.tblReceptieHome.Select("CantitateRec>0"))
                {
                    drdet = mDataSet.tblReceptieComandaDet.NewtblReceptieComandaDetRow();
                    drdet["ID"] = Guid.NewGuid();
                    drdet["ReceptieComandaBaseID"] =mReceptieID;
                    drdet["ProduseID"] = drRow["ProduseID"];
                    drdet["CantitateReceptionata"] = drRow["CantitateRec"];
                    mDataSet.tblReceptieComandaDet.AddtblReceptieComandaDetRow(drdet);
                }
            }


        }
        private bool Validate()
        {
            mySaveData = true;
            if (!mUtil.IsNotObjectEmpty(textEditFactura.Text) || textEditFactura.Text== string.Empty)
            {
                textEditFactura.ErrorText = "Completati numarul facturii!";
                mySaveData = false;
                return mySaveData;

            }
            if (!mUtil.IsNotObjectEmpty(textEditNir.Text) || textEditNir.Text==string.Empty )
            {
                textEditNir.ErrorText = "Completati numarul Nir-ului!";
                mySaveData = false;
                return mySaveData;

            }
            return mySaveData;
        }

        #endregion

        #region Public Methods

        public override void Initialize()
        {

            try
            {
                base.Initialize();
                object obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Comenzi.CallerHandler");
                if (obj != null) this.mCallerHandle = (Comenzi)obj;

                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Comenzi.ComandaBaseID");
                if (obj != null && (!string.IsNullOrEmpty(obj.ToString())))
                    mBaseID = new Guid(obj.ToString());
                mController =
                    (ComenziController)
                    Context.CreateController("CommonGUIControllers.GUI.ComenziController,CommonGUIControllers");
                mController.LoadDate = false;
                mController.Receptie = true;
                mController.ComadaBaseID = mBaseID;
                mController.CentruID = ContextUtilityClass.OnlyInstance.CentruID;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());

                    return;
                }
                ucDataReceptie.Initialize();
                mDataSet = (ComenziDataSet)mController.DataSet;
                mDataSet.AcceptChanges();


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
            tblReceptieHomeBindingSource.DataSource = mDataSet.tblReceptieHome.DefaultView;
            mUtil.SetNumericMask(repositoryItemTextEditSuma, 2, true);
        }


        #endregion
      
      
    }

}
