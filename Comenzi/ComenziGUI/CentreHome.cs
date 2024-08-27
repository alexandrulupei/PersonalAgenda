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
    public partial class CentreHome : BaseWindow
    {
        #region Constructor

        public CentreHome()
        {
            InitializeComponent();
        }

        #endregion


        #region Class Fields

        private Nomenclatoare mDataSet;
        private CentreController mController;
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

        #endregion

        #region Private Events
        private void gridViewCentre_DoubleClick(object sender, EventArgs e)
        {
            Alege();
        }
        private void gridViewCentre_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            mIsNewRow = true;
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["ID"], Guid.NewGuid());
            view.SetRowCellValue(e.RowHandle, view.Columns["IsActive"], true);
            view.SetRowCellValue(e.RowHandle, view.Columns["ModulID"], ContextUtilityClass.OnlyInstance.ModulID);
            mID = new Guid(view.GetRowCellValue(e.RowHandle, colID).ToString());
        }

        private void CentreHome_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gridViewCentre_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Utility utiliy = new Utility();
            DataRow drSelected = ((DataRowView) e.Row).Row;
            GridView view = sender as GridView;
            if (!mAbbreviationAlowNull)
            {
                object tmpObject = view.GetRowCellValue(e.RowHandle, view.Columns["Cod"]);
                if (tmpObject.Equals(DBNull.Value) || tmpObject.Equals(string.Empty))
                {
                    e.ErrorText = "Nu ati precizat un cod!";
                    e.Valid = false;
                    view.ShowEditor();
                    return;
                }
            }
            Object tmpObj = view.GetRowCellValue(e.RowHandle, view.Columns["Cod"]);
            if (!tmpObj.Equals(DBNull.Value) && !tmpObj.Equals(string.Empty))
            {
                string sCod = tmpObj.ToString();
                foreach (DataRow dr in mDataSet.tblCentru.Rows)
                {
                    if ((string.Compare(sCod, dr["Cod"].ToString(), true) == 0) &&
                        (mID != new Guid(dr["ID"].ToString())))
                    {
                        if (Convert.ToBoolean(dr["IsActive"].ToString()))
                        {
                            e.ErrorText = "Acest cod exista deja in nomenclator.";
                            e.Valid = false;
                            view.ShowEditor();
                            return;
                        }
                        if (XtraMessageBox.Show(
                                "Acest cod exista deja in nomenclator, la o inregistrare dezactivata, avand denumirea " +
                                dr["Description"] + ".\n Doriti reactivarea acestei inregistrari?",
                                "Comenzi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            if (view.IsEditing)
                                view.HideEditor();
                            view.CancelUpdateCurrentRow();
                            dr["IsActive"] = true;
                            return;
                        }
                        e.Valid = false;
                        return;
                    }
                }
            }
            if (String.IsNullOrEmpty(drSelected["Denumire"].ToString()))
            {
                e.ErrorText = "Nu ati precizat denumirea!";
                e.Valid = false;
                view.ShowEditor();
                return;
            }

            if (String.IsNullOrEmpty(drSelected["TipCentruID"].ToString()))
            {
                e.ErrorText = "Nu ati precizat tipul de centru!";
                e.Valid = false;
                view.ShowEditor();
                return;
            }
            if (String.IsNullOrEmpty(drSelected["ModulId"].ToString()))
            {
                e.ErrorText = "Nu s a incarcat ModulId!";
                e.Valid = false;
                view.ShowEditor();
                return;
            }
            string sDenumire = drSelected["Denumire"].ToString();
            foreach (DataRow dr in mDataSet.tblCentru.Rows)
            {
                if ((string.Compare(sDenumire, dr["Denumire"].ToString(), true) == 0) &&
                    (mID != new Guid(dr["ID"].ToString())))
                {
                    if (Convert.ToBoolean(dr["IsActive"].ToString()))
                    {
                        e.ErrorText = "Aceasta denumire exista deja in nomenclator.";
                        e.Valid = false;
                        view.ShowEditor();
                        return;
                    }
                    if (XtraMessageBox.Show(
                            "Aceasta denumire exista deja in nomenclator, la o inregistrare dezactivata, avand codul " +
                            dr["Abbreviation"] + ".\n Doriti reactivarea acestei inregistrari?",
                            "Comenzi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        if (view.IsEditing)
                            view.HideEditor();
                        view.CancelUpdateCurrentRow();
                        dr["IsActive"] = true;
                        return;
                    }
                    e.Valid = false;
                    return;
                }
            }

            mIsNewRow = false;
 }

       
        private void gridViewCentre_InvalidRowException(object sender,
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

        private void gridViewCentre_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            mIsNewRow = false;
            if (gridViewCentre.FocusedRowHandle < 0)
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
            this.Tag = SetButtonEditAlegeList(mCod, mDataSet.tblCentru, mID);
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
            DataRow dr = utiliy.GetSelectedRow(gridControlPartener);
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

        #endregion

        #region Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize(gridControlPartener);
                navBarItemAlege.Visible = false;

                string sIsAlege = GetParameter("IsAlege");
                if (!String.IsNullOrEmpty(sIsAlege))
                {
                    mIsAlege = Convert.ToBoolean(sIsAlege);
                    navBarItemAlege.Visible = mIsAlege;
                }

                navBarGroupActualizare.Visible = true;

                labelBaseWindowHeader.Text = "Centre";

                mController =
                    (CentreController)
                    Context.CreateController("CommonGUIControllers.GUI.CentreController,CommonGUIControllers");
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
                    Tag = SetButtonEditAlegeList(mCod, mDataSet.tblCentru);
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
            tblCentruBindingSource.DataSource = mDataSet.tblCentru.DefaultView;
            repositoryItemLookUpEditTipCentru.DataSource = mDataSet.tbxTipCentru.DefaultView;
            repositoryItemLookUpEditTipCentru.ValueMember = "ID";
            repositoryItemLookUpEditTipCentru.DisplayMember = "Abbreviation";
        }

        public override void Alege()
        {
            if (mIsAlege && !gridViewCentre.IsEditing)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public override void Iesire()
        {
            if (!gridViewCentre.IsEditing && !gridViewCentre.IsEditorFocused && !mIsNewRow)
                Close();
        }

        public override void Salvare()
        {
            mySaveData = true;
            Close();
        }

        public override void Adauga()
        {
            gridControlPartener.EmbeddedNavigator.Buttons.DoClick(gridControlPartener.EmbeddedNavigator.Buttons.Append);
        }

        public override void Modifica()
        {
            GridView view = gridViewCentre;
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
