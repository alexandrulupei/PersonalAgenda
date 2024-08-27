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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using GSFramework;
using Utilities;

namespace ComenziGUI
{
    public partial class Produse : BaseWindow
    {
        #region Constructor

        public Produse()
        {
            InitializeComponent();
        }

        #endregion

        #region Class Fields

        private Nomenclatoare mDataSet;
        private ProduseController mController;
        private DataView mDataViewNomenclator = new DataView();
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
        private bool mIsNewRow;
        private Utilities.Utility mUtility = new Utility();

        #endregion

        #region Private Events
        private void gridViewProduse_DoubleClick(object sender, EventArgs e)
        {
            Alege();
        }

        private void Produse_FormClosing(object sender, FormClosingEventArgs e)
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
            }
            catch (Exception excep)
            {
                Context.HandleException(this, excep);
            }
        }


        private void gridViewProduse_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            mIsNewRow = true;
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["ID"], Guid.NewGuid());
            mID = new Guid(view.GetRowCellValue(e.RowHandle, colID).ToString());

        }


        private void gridViewProduse_InvalidRowException(object sender,
            DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
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

        private void gridViewProduse_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
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
        private void gridViewProduse_CellValueChanged(object sender,
            DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            decimal pret = 0, cotatva = 0, prettva;
            GridView view = sender as GridView;
            object obj;
            if (e.Column == colPret || e.Column == colCotaTVAID)
            {

                obj = view.GetRowCellValue(e.RowHandle, colPret);
                if (mUtility.IsNotObjectEmpty(obj))
                    pret = Convert.ToDecimal(obj);

                obj = view.GetRowCellValue(e.RowHandle, colCotaTVAID);
                DataRow[] drCota;
                if (mUtility.IsNotObjectEmpty(obj))
                {
                    drCota = mDataSet.tbxCotaTVA.Select("ID='" + obj.ToString() + "'");
                    if (drCota.Length > 0)
                        if (mUtility.IsNotObjectEmpty(drCota[0]["Valoare"]))
                            cotatva = Convert.ToDecimal((drCota[0]["Valoare"]));
                }


                prettva = pret + cotatva * pret / 100;
                view.SetRowCellValue(e.RowHandle, colPretCuTva, prettva);
            }
            if (e.Column == colDenumire)
            {
                string mSimbol = string.Empty;
                string mDenumire = string.Empty;
                obj = view.GetRowCellValue(e.RowHandle, colDenumire);
                if (mUtility.IsNotObjectEmpty(obj))
                {
                    mDenumire = obj.ToString();
                    mDenumire = mDenumire.Substring(0, 1);
                    mSimbol = GenerareSimbol(mDenumire);
                    view.SetRowCellValue(e.RowHandle, colCod, mSimbol);
                }
               
            }
        }

        private void gridControlProduse_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {

        }
        private void gridViewProduse_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            mIsNewRow = false;
            if (gridViewProduse.FocusedRowHandle < 0)
                ToogleNavBarItems(false);
            else
                ToogleNavBarItems(true);

            GridView view = sender as GridView;
            object obj = view.GetRowCellValue(e.FocusedRowHandle, colID);
            if ((obj != null) && (obj != DBNull.Value))
            {
                mID = new Guid(obj.ToString());
                mDenumire = view.GetRowCellValue(e.FocusedRowHandle, colDenumire).ToString();
                mCod = view.GetRowCellValue(e.FocusedRowHandle, colCod).ToString();
            }
            this.Tag = SetButtonEditAlegeList(mCod, mDataSet.tblProduse, mID);

        }


        #endregion

        #region Private Methods

        private void ToogleNavBarItems(bool pEnabled)
        {
            navBarItemModifica.Enabled = navBarItemSterge.Enabled = pEnabled;
        }

        private void RemoveRow()
        {
            Utility utiliy = new Utility();
            DataRow dr = utiliy.GetSelectedRow(gridControlProduse);
            if (dr != null)
            {
                dr.Delete();
                mController.Perform();
                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    try
                    {
                        SqlException ex = (SqlException) mController.ServerException.InnerException;
                        if (ex.Number == 547)
                        {
                            dr.RejectChanges();
                            dr.RowError = string.Empty;
                            if (XtraMessageBox.Show(
                                    "Aceasta inregistrare nu poate fi stearsa permanent din baza de date deoarece este folosita in alte tabele.\n Doriti dezactivarea inregistrarii?",
                                    "Comenzi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dr["IsActive"] = false;
                                mySaveData = true;
                                Save();
                            }
                        }
                        else
                        {
                            Context.HandleException(mController.ServerException.ToString());
                            mySaveData = false;
                        }
                    }
                    catch
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        mySaveData = false;
                    }
                }
            }
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
        }
        private string GenerareSimbol(string pDenumire)
        {

            String mFiltru = " Denumire LIKE '" + pDenumire + "%'";
            
            mController.LoadSimbol = true;
            mController.TableName = "tblProduse";
            mController.TableColumn = "Cod";
            mController.Filtru = mFiltru;
            mController.Load();

            // mDataSet.tblMaxSimbol.Merge(mController.DataSet.Tables["tblMaxSimbol"]);

            object objCodMax = '0';

            if (mDataSet.tblMaxSimbol.Rows.Count > 0)
                objCodMax = mDataSet.tblMaxSimbol.Rows[0][0].ToString();
            if (objCodMax.ToString() != "-1")
            {
                objCodMax = pDenumire + objCodMax;
            }
            string sCodMax;
            if (objCodMax != DBNull.Value)
                sCodMax = objCodMax.ToString();
            else sCodMax = string.Empty;

            string sSimbol = pDenumire;

            string s = string.Empty;
            for (int i = 0; i < sCodMax.Length; i++)
            {
                if (char.IsDigit(sCodMax[i])) s += sCodMax[i];
            }
            int iCod = 1;
            if (!string.IsNullOrEmpty(s))
            {
                iCod = Convert.ToInt32(s) + 1;
            }
            s = iCod.ToString();
            while (s.Length < 3) s = "0" + s;

            sSimbol += s;

            return sSimbol;
        }
        #endregion

        #region Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize(gridControlProduse);
                navBarItemAlege.Visible = false;

                string sIsAlege = GetParameter("IsAlege");
                if (!String.IsNullOrEmpty(sIsAlege))
                {
                    mIsAlege = Convert.ToBoolean(sIsAlege);
                    navBarItemAlege.Visible = mIsAlege;
                }

                navBarGroupActualizare.Visible = true;

                labelBaseWindowHeader.Text = "Produse";

                mController =
                    (ProduseController)
                    Context.CreateController("CommonGUIControllers.GUI.ProduseController,CommonGUIControllers");
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (Nomenclatoare) mController.DataSet;
                mDataSet.AcceptChanges();


                string sIsButtonEditAlege = GetParameter("IsButtonEditAlege");
                if (!String.IsNullOrEmpty(sIsButtonEditAlege))
                {
                    Tag = SetButtonEditAlegeList(mCod, mDataSet.tblProduse);
                    return;
                }
                Bind();

            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }

        public override void Bind()
        {
            base.Bind();
            tblProduseBindingSource.DataSource = mDataSet.tblProduse.DefaultView;
            repositoryItemLookUpEditUM.DataSource = mDataSet.Tables["tbxUMStandard"].DefaultView;
            repositoryItemLookUpEditUM.ValueMember = "ID";
            repositoryItemLookUpEditUM.DisplayMember = "Abbreviation";
            mUtility.SetNumericMask(repositoryItemTextEditSuma, 2, true);
            repositoryItemLookUpEditCotaTva.DataSource = mDataSet.tbxCotaTVA.DefaultView;
            repositoryItemLookUpEditCotaTva.ValueMember = "ID";
            repositoryItemLookUpEditCotaTva.DisplayMember = "Abbreviation";

        }

        public override void Alege()
        {
            if (mIsAlege && !gridViewProduse.IsEditing)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public override void Iesire()
        {
            if (!gridViewProduse.IsEditing && !gridViewProduse.IsEditorFocused && !mIsNewRow)
                Close();
        }

        public override void Salvare()
        {
            mySaveData = true;
            Close();
        }

        public override void Adauga()
        {
            gridControlProduse.EmbeddedNavigator.Buttons.DoClick(gridControlProduse.EmbeddedNavigator.Buttons.Append);
        }

        public override void Modifica()
        {
            GridView view = gridViewProduse;
            view.ShowEditor();
        }

        public override void Sterge()
        {
            if (new Utility().DeleteConfirmation())
            {
                RemoveRow();
            }
        }



        #endregion



    }
}
