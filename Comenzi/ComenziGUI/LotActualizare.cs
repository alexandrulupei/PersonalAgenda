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
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using GSFramework;

namespace ComenziGUI
{

    public partial class LotActualizare : GSFramework.Window
    {

        #region  Constructor
        public LotActualizare()
        {
            InitializeComponent();
        }
        #endregion

        #region  Class Fields
        private LotDataSet mDataSet;
        private LotController mController;
        private DataView mDataView = new DataView();
        private string mDataTableName = string.Empty;
        private string mWindowName = string.Empty;
        private Guid mFocusedID;
        private bool mIsAlege;
        private Guid mID;
        private String mDenumire;
        private string mCod;
        private bool mAbbreviationAlowNull = true;
        private bool mEventCanceled;
        private bool mUseCodAsReturnValue = true;
        private SortedList<string, object> mTagList = new SortedList<string, object>();
        private bool mIsNew;
        private Guid mPartenerID = Guid.Empty;
        private Lot mCallerHandle;
        private LotDataSet.tblLotBaseRow drBase;
        Utility mUtil = new Utility();
        private DateTime mData;
        #endregion

        #region Private Events
        private void ucDataLucru_Validated(object sender, EventArgs e)
        {
            if (IsLoading) return;
            drBase["Data"] = ucDataLucru.GetDateTime;
            mController.LoadAcord=true;
            mController.Data = ucDataLucru.GetDateTime;
            mController.Load();

            if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
            {
                Context.HandleException(mController.ServerException.ToString());
                return;
            }
        }

        private void LotActualizare_Load(object sender, EventArgs e)
        {
            IsLoading = false;
        }

        private void gridViewLotDet_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["ID"], Guid.NewGuid());
            view.SetRowCellValue(e.RowHandle, view.Columns["LotBaseID"], mID);
        }

        private void gridViewLotDet_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            if (
            XtraMessageBox.Show(e.ErrorText + " Doriti sa corectati?", "Eroare", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                e.ExceptionMode = ExceptionMode.NoAction;
            }
            else
            {
                e.ExceptionMode = ExceptionMode.Ignore;
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

        private void LotActualizare_FormClosing(object sender, FormClosingEventArgs e)
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
        private void gridViewLotDet_ColumnChanged(object sender, EventArgs e)
        {

        }

        private void gridViewLotDet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow dr = view.GetDataRow(e.RowHandle);
            Guid gMaterialID = Guid.Empty;
            if (e.Column == colProduseID)
            {
                object obj = gridViewLotDet.GetRowCellValue(e.RowHandle, colProduseID);
                DataTable dtMaterial = (DataTable)repositoryItemButtonEditProdus.DataSource;
                if (obj != null && obj.ToString() != "")
                {
                    gMaterialID = (Guid)obj;
                    DataRow[] drs = dtMaterial.Select("ID='" + gMaterialID.ToString() + "'");
                    if (drs.Length > 0)
                    {
                        gridViewLotDet.SetRowCellValue(e.RowHandle, colCotaTvaID, drs[0]["CotaTVAID"]);
                        gridViewLotDet.SetRowCellValue(e.RowHandle, colPret, drs[0]["Pret"]);
                    }
                }
            }

            if (e.Column == colCantitate)
            {
                object objCant = gridViewLotDet.GetRowCellValue(e.RowHandle, colCantitate);
                object objPret = gridViewLotDet.GetRowCellValue(e.RowHandle, colPret);
                object objtva = gridViewLotDet.GetRowCellValue(e.RowHandle, colCotaTvaID);
                object objCantitateDisp = gridViewLotDet.GetRowCellValue(e.RowHandle, colCantitateDisponibila);

                decimal mPret = 0, mCantitate = 0, mValoareTva = 0;
                if (objCant != null && objCant.ToString() != "")
                {
                    mCantitate = Convert.ToDecimal(objCant);
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

                if (objCantitateDisp != null && objCantitateDisp.ToString() != "")
                {
                    decimal mCantDisp = Convert.ToDecimal(objCantitateDisp);
                    if (mCantDisp < mCantitate)
                    {
                        gridViewLotDet.SetRowCellValue(e.RowHandle, colCantitate, 0);
                        XtraMessageBox.Show("Cantitatea totala mai mica decat cantitatea distribuita!");
                        return;
                    }
                    gridViewLotDet.SetRowCellValue(e.RowHandle, colCantitateRamasa, mCantDisp - mCantitate);
                
                }

                gridViewLotDet.SetRowCellValue(e.RowHandle, colValoare, mCantitate * mPret);
                gridViewLotDet.SetRowCellValue(e.RowHandle, colValoareTVA, mCantitate * mPret * mValoareTva / 100);
                gridViewLotDet.SetRowCellValue(e.RowHandle, colValoareCuTva, mCantitate * mPret + mCantitate * mPret * mValoareTva / 100);


            }
        }

        private void textEditDenumie_EditValueChanged(object sender, EventArgs e)
        {
            if (mUtil.IsNotObjectEmpty(textEditDenumie.EditValue))
            {
                drBase["Denumire"] = textEditDenumie.Text;
            }
        }
         

        private void buttonEditAlegeCodPartener_EditValueChanged(object sender, EventArgs e)
        {
            if (mUtil.IsNotObjectEmpty(buttonEditAlegeCodPartener.EditValue))
            {
                if (buttonEditAlegeCodPartener.EditValue.GetType() == typeof(Guid))
                    drBase["PartenerID"] = buttonEditAlegeCodPartener.EditValue;
            }
        }

        private void buttonEditAlegeCodPartener_Validated(object sender, EventArgs e)
        {
            if (mUtil.IsNotObjectEmpty(buttonEditAlegeCodPartener.EditValue))
            {
                drBase["PartenerID"] = buttonEditAlegeCodPartener.EditValue;
            }
        }


        private void lookUpEditTipCentru_EditValueChanged(object sender, EventArgs e)
        {
            if (mUtil.IsNotObjectEmpty(lookUpEditTipCentru.EditValue))
            {
                drBase["TipCentruID"] = lookUpEditTipCentru.EditValue;
            }
        }

        private void lookUpEditAcordCadru_EditValueChanged(object sender, EventArgs e)
        {
            if (IsLoading) return;

            if (mUtil.IsNotObjectEmpty(lookUpEditAcordCadru.EditValue))
            {
                foreach (DataRow drdel in mDataSet.tblLotDet.Select())
                    drdel.Delete();

                mController.LoadDateAcord = true;
                mController.AcordID = (Guid)lookUpEditAcordCadru.EditValue;
                mController.LotBaseID = mID;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
                foreach (DataRow dradd in mDataSet.tblLotDet.Select())
                    dradd.SetAdded();

                gridControlLotDet.RefreshDataSource();
                DataRow dr = mDataSet.tblAcordCadru.FindByID((Guid)lookUpEditAcordCadru.EditValue);
                drBase["AcordCadruID"] = lookUpEditAcordCadru.EditValue;
                buttonEditAlegeCodPartener.EditValue = (Guid)dr["PartenerID"];
                lookUpEditTipCentru.EditValue = (Guid)dr["TipCentruID"];
            }
        }
        #endregion

        #region Private Methods

        private void RanduriNoi()
        {
            drBase = mDataSet.tblLotBase.NewtblLotBaseRow();
            mID = Guid.NewGuid();
            drBase["ID"] = mID;
            drBase["Data"] = ucDataLucru.GetDateTime;
            mDataSet.tblLotBase.AddtblLotBaseRow(drBase);
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
        }
        private bool Validate()
        {
           if (textEditDenumie.Text== string.Empty)
           {
             mySaveData=false;
             textEditDenumie.ErrorText = "Completati denumirea";
             return mySaveData;
           }

           if (!mUtil.IsNotObjectEmpty(buttonEditAlegeCodPartener.EditValue))
           {
               mySaveData = false;
               buttonEditAlegeCodPartener.ErrorText = "Completati denumirea furnizorului";
               return mySaveData;
           }

           if (!mUtil.IsNotObjectEmpty(lookUpEditTipCentru.EditValue))
           {
               mySaveData = false;
               lookUpEditTipCentru.ErrorText = "Alegeti tipul de centru";
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
                ucDataLucru.SetTimeForDate = false;
                ucDataLucru.Initialize();
                object obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Lot.CallerHandler");
                if (obj != null) this.mCallerHandle = (Lot)obj;
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Lot.IsNew");
                if (obj != null) mIsNew = Convert.ToBoolean(obj);
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Lot.LotBaseID");
                if (obj != null && (!string.IsNullOrEmpty(obj.ToString())))
                    mID = new Guid(obj.ToString());
                mData = ContextUtilityClass.OnlyInstance.DataLucru;
                mController =
                 (LotController)
                 Context.CreateController("CommonGUIControllers.GUI.LotController,CommonGUIControllers");
                mController.LoadDate = true;
                mController.LotBaseID = mID;
                mController.Data = mData;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (LotDataSet)mController.DataSet;
                mDataSet.AcceptChanges();
                mDataView = new DataView(mDataSet.tblLotBase);
                mDataView.RowFilter = "ID='" + mID.ToString() + "'";
                if (mIsNew)
                {
                    RanduriNoi();
                }
                else
                {
                    drBase = mDataSet.tblLotBase.FindByID(mID);
                    if (mDataSet.tblLotBase.Rows.Count > 0)
                        ucDataLucru.UserDateTime = (DateTime)mDataSet.tblLotBase.Rows[0]["Data"];
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
            this.tblLotDetBindingSource.DataSource = mDataSet.tblLotDet.DefaultView;
            textEditDenumie.DataBindings.Add("EditValue", mDataView, "Denumire", true, DataSourceUpdateMode.OnValidation, string.Empty);
            buttonEditAlegeCodPartener.AssemblyName = "ComenziGUI.Partener, ComenziGUI";
            buttonEditAlegeCodPartener.AssemblyParameters = "IsAlege=true&PartenerID=" + mPartenerID.ToString() + "&SetFocusedColumn=";
            buttonEditAlegeCodPartener.SetDataSource();
            buttonEditAlegeCodPartener.UseDisplayMember = true;
            buttonEditAlegeCodPartener.DisplayMember = "Cod";
            buttonEditAlegeCodPartener.ValueMember = "ID";
            buttonEditAlegeCodPartener.AllowNull = true;
            buttonEditAlegeCodPartener.DataBindings.Add("EditValue", mDataView, "PartenerID", true, DataSourceUpdateMode.OnValidation, string.Empty);

            repositoryItemButtonEditProdus.AssemblyName = "ComenziGUI.Produse, ComenziGUI";
            repositoryItemButtonEditProdus.AssemblyParameters = "IsAlege=true";
            repositoryItemButtonEditProdus.SetDataSource();
            repositoryItemButtonEditProdus.UseDisplayMember = true;
            repositoryItemButtonEditProdus.DisplayMember = "Cod";
            repositoryItemButtonEditProdus.ValueMember = "ID";
            repositoryItemButtonEditProdus.AllowNull = true;

            repositoryItemButtonEditDenumireProdus.AssemblyName = "ComenziGUI.Produse, ComenziGUI";
            repositoryItemButtonEditDenumireProdus.AssemblyParameters = "IsAlege=true";
            repositoryItemButtonEditDenumireProdus.SetDataSource();
            repositoryItemButtonEditDenumireProdus.UseDisplayMember = true;
            repositoryItemButtonEditDenumireProdus.DisplayMember = "Denumire";
            repositoryItemButtonEditDenumireProdus.ValueMember = "ID";
            repositoryItemButtonEditDenumireProdus.AllowNull = true;

            repositoryItemLookUpEditCotaTva.DataSource = mDataSet.Tables["tbxCotaTVA"];
            repositoryItemLookUpEditCotaTva.DisplayMember = "Abbreviation";
            repositoryItemLookUpEditCotaTva.ValueMember = "ID";
            lookUpEditTipCentru.DataBindings.Add("EditValue", mDataView, "TipCentruID", true, DataSourceUpdateMode.OnValidation, string.Empty);
            lookUpEditTipCentru.Properties.DataSource = mDataSet.tbxTipCentru.DefaultView;
            lookUpEditTipCentru.Properties.DisplayMember = "Description";
            lookUpEditTipCentru.Properties.ValueMember = "ID";

            lookUpEditAcordCadru.DataBindings.Add("EditValue", mDataView, "AcordCadruID", true, DataSourceUpdateMode.OnValidation, string.Empty);
            lookUpEditAcordCadru.Properties.DataSource = mDataSet.tblAcordCadru.DefaultView;
            lookUpEditAcordCadru.Properties.DisplayMember = "Denumire";
            lookUpEditAcordCadru.Properties.ValueMember = "ID";

            dateEditDataStop.DataBindings.Add("EditValue", mDataView, "DataStop", true, DataSourceUpdateMode.OnValidation, string.Empty);
            mUtil.SetNumericMask(repositoryItemTextEditSuma,2,true);
            mUtil.SetDateTimeFormatFromConfig(dateEditDataStop);

        }

        #endregion

       
    }
   

}
