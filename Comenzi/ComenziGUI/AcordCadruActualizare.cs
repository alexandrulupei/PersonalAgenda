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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace ComenziGUI
{
    public partial class AcordCadruActualizare : GSFramework.Window
    {
        #region Constructor
        public AcordCadruActualizare()
        {
            InitializeComponent();
        }
        #endregion 


        #region Class Fields
        private AcordCadruDataSet mDataSet;
        private AcordCadruController mController;
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
        private AcordCadru mCallerHandle;
        private AcordCadruDataSet.tblAcordCadruRow drBase;
        private Utility mUtil = new Utility();
        #endregion

        #region Private Events
        private void gridViewAcordCadru_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow dr = view.GetDataRow(e.RowHandle);
            Guid gMaterialID = Guid.Empty;
            if (e.Column == colProduseID)
            {
                object obj = gridViewAcordCadru.GetRowCellValue(e.RowHandle, colProduseID);
                DataTable dtMaterial = (DataTable)repositoryItemButtonEditProdus.DataSource;
                if (obj != null && obj.ToString() != "")
                {
                    gMaterialID = (Guid)obj;
                    DataRow[] drs = dtMaterial.Select("ID='" + gMaterialID.ToString() + "'");
                    if (drs.Length > 0)
                    {
                        gridViewAcordCadru.SetRowCellValue(e.RowHandle, colCotaTVAID, drs[0]["CotaTVAID"]);
                        gridViewAcordCadru.SetRowCellValue(e.RowHandle, colPret, drs[0]["Pret"]);
                    }
                }
            }

            if (e.Column == colCantitate)
            {
                object objCant = gridViewAcordCadru.GetRowCellValue(e.RowHandle, colCantitate);
                object objPret = gridViewAcordCadru.GetRowCellValue(e.RowHandle, colPret);
                object objtva = gridViewAcordCadru.GetRowCellValue(e.RowHandle, colCotaTVAID);

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

                gridViewAcordCadru.SetRowCellValue(e.RowHandle, colValoare, mCantitate * mPret);
                gridViewAcordCadru.SetRowCellValue(e.RowHandle, colValoareTVA, mCantitate * mPret * mValoareTva / 100);
                gridViewAcordCadru.SetRowCellValue(e.RowHandle, colValoareCuTva, mCantitate * mPret + mCantitate * mPret * mValoareTva / 100);


            }
        }

        private void gridViewAcordCadru_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["ID"], Guid.NewGuid());
            view.SetRowCellValue(e.RowHandle, view.Columns["AcordCadruID"], mID);

        }
        private void ucDataLucru_Validated(object sender, EventArgs e)
        {
            if (IsLoading) return;
            drBase["DataStart"] = ucDataLucru.GetDateTime;
        }
        private void dateEditDataStop_Validated(object sender, EventArgs e)
        {
            if (IsLoading) return;
            if (mUtil.IsNotObjectEmpty(dateEditDataStop.EditValue))
            drBase["DataStop"] = dateEditDataStop.EditValue;
        }

        private void AcordCadruActualizare_Load(object sender, EventArgs e)
        {
            IsLoading = false;
        }

        private void gridViewAcordCadru_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
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

        private void simpleButtonSalvare_Click(object sender, EventArgs e)
        {
            mySaveData = true;
            this.Close();
        }

        private void simpleButtonRenunta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcordCadruActualizare_FormClosing(object sender, FormClosingEventArgs e)
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

        private void textEditDenumie_EditValueChanged(object sender, EventArgs e)
        {
            if (mUtil.IsNotObjectEmpty(textEditDenumie.EditValue))
            {
                drBase["Denumire"] = textEditDenumie.Text;
            }
        }

        private void lookUpEditTipCentru_EditValueChanged(object sender, EventArgs e)
        {
            if (mUtil.IsNotObjectEmpty(lookUpEditTipCentru.EditValue))
            {
                drBase["TipCentruID"] = lookUpEditTipCentru.EditValue;
            }
        }

        #endregion

        #region Private Methods

        private void RanduriNoi()
        {
            drBase = mDataSet.tblAcordCadru.NewtblAcordCadruRow(); ;
            mID = Guid.NewGuid();
            drBase["ID"] = mID;
            drBase["DataStart"] = ucDataLucru.GetDateTime;
            mDataSet.tblAcordCadru.AddtblAcordCadruRow(drBase);
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
            if (textEditDenumie.Text == string.Empty)
            {
                mySaveData = false;
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

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                base.Initialize();
                ucDataLucru.SetTimeForDate = false;
                ucDataLucru.Initialize();
                object obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.AcordCadru.CallerHandler");
                if (obj != null) this.mCallerHandle = (AcordCadru)obj;
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.AcordCadru.IsNew");
                if (obj != null) mIsNew = Convert.ToBoolean(obj);
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.AcordCadru.AcordCadruBaseID");
                if (obj != null && (!string.IsNullOrEmpty(obj.ToString())))
                    mID = new Guid(obj.ToString());

                mController =
                 (AcordCadruController)
                 Context.CreateController("CommonGUIControllers.GUI.AcordCadruController,CommonGUIControllers");
                mController.LoadDate = true;
                mController.AcordCadruBaseID = mID;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (AcordCadruDataSet)mController.DataSet;
                mDataSet.AcceptChanges();
                mDataView = new DataView(mDataSet.tblAcordCadru);
                mDataView.RowFilter = "ID='" + mID.ToString() + "'";
                if (mIsNew)
                {
                    RanduriNoi();
                }
                else
                {
                    drBase = mDataSet.tblAcordCadru.FindByID(mID);
                    if (mDataSet.tblAcordCadru.Rows.Count > 0)
                        ucDataLucru.UserDateTime = (DateTime)mDataSet.tblAcordCadru.Rows[0]["DataStart"];
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
            tblAcordCadruDetBindingSource.DataSource = mDataSet.tblAcordCadruDet.DefaultView;
            mUtil.SetDateTimeFormatFromConfig(dateEditDataStop);
            dateEditDataStop.DataBindings.Add("EditValue", mDataView, "DataStop", true, DataSourceUpdateMode.OnValidation, string.Empty);
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


            repositoryItemLookUpEditCotaTva.DataSource = mDataSet.Tables["tbxCotaTVA"];
            repositoryItemLookUpEditCotaTva.DisplayMember = "Abbreviation";
            repositoryItemLookUpEditCotaTva.ValueMember = "ID";
            lookUpEditTipCentru.DataBindings.Add("EditValue", mDataView, "TipCentruID", true, DataSourceUpdateMode.OnValidation, string.Empty);
            lookUpEditTipCentru.Properties.DataSource = mDataSet.tbxTipCentru.DefaultView;
            lookUpEditTipCentru.Properties.DisplayMember = "Description";
            lookUpEditTipCentru.Properties.ValueMember = "ID";

            mUtil.SetNumericMask(repositoryItemTextEditSuma,2, true);
        }

        #endregion

       

       
      
    }
}
