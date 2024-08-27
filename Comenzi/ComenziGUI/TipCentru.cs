using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ComenziBase;
using CommonDataSets.GUI;
using CommonGUIControllers.GUI;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using GSFramework;
using Utilities;

namespace ComenziGUI
{
    public partial class TipCentru : BaseWindow
    {
        #region Constructor
        public TipCentru()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields
        private Nomenclatoare mDataSet;
        private TipCentruController mController;
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

        #region Private Methods
        private void ToogleNavBarItems(bool pEnabled)
        {
            navBarItemModifica.Enabled = navBarItemSterge.Enabled = pEnabled;
        }
        private void RemoveRow()
        {
            Utility utiliy = new Utility();
            DataRow dr = utiliy.GetSelectedRow(gridControlTipCentru);
            if (dr != null)
            {
                dr.Delete();
                mController.Perform();
                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    try
                    {
                        SqlException ex = (SqlException)mController.ServerException.InnerException;
                        if (ex.Number == 547)
                        {
                            dr.RejectChanges();
                            dr.RowError = string.Empty;
                            if (XtraMessageBox.Show("Aceasta inregistrare nu poate fi stearsa permanent din baza de date deoarece este folosita in alte tabele.\n Doriti dezactivarea inregistrarii?",
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
                base.Initialize(gridControlTipCentru);
                navBarItemAlege.Visible = false;

                string sIsAlege = GetParameter("IsAlege");
                if (!String.IsNullOrEmpty(sIsAlege))
                {
                    mIsAlege = Convert.ToBoolean(sIsAlege);
                    navBarItemAlege.Visible = mIsAlege;
                }

                navBarGroupActualizare.Visible = true;

                labelBaseWindowHeader.Text = "Tip Centru";

                mController = (TipCentruController)Context.CreateController("CommonGUIControllers.GUI.TipCentruController,CommonGUIControllers");
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (Nomenclatoare)mController.DataSet;
                mDataSet.AcceptChanges();


                string sIsButtonEditAlege = GetParameter("IsButtonEditAlege");
                if (!String.IsNullOrEmpty(sIsButtonEditAlege))
                {
                    Tag = SetButtonEditAlegeList(mCod, mDataSet.tbxTipCentru);
                    return;
                }
                Bind();
                //string sSetFocusedColumn = GetParameter("SetFocusedColumn");
                //if (!String.IsNullOrEmpty(sSetFocusedColumn))
                //{
                //    Application.DoEvents();
                //    SendKeys.Flush();
                //    gridViewTipCentru.FocusedColumn = gridColumnAbbreviation;
                //    gridViewTipCentru.Focus();
                //    SendKeys.Send(sSetFocusedColumn);
                //}

            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }
        public override void Bind()
        {
            base.Bind();
            tbxTipCentruBindingSource.DataSource = mDataSet.tbxTipCentru.DefaultView;
        }
        public override void Alege()
        {
            if (mIsAlege && !gridViewTipCentru.IsEditing)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        public override void Iesire()
        {
            if (!gridViewTipCentru.IsEditing && !gridViewTipCentru.IsEditorFocused && !mIsNewRow)
                Close();
        }
        public override void Salvare()
        {
            mySaveData = true;
            Close();
        }
        public override void Adauga()
        {
            gridControlTipCentru.EmbeddedNavigator.Buttons.DoClick(gridControlTipCentru.EmbeddedNavigator.Buttons.Append);
        }
        public override void Modifica()
        {
            GridView view = gridViewTipCentru;
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

        private void TipCentru_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gridViewTipCentru_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            mIsNewRow = true;
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["ID"], Guid.NewGuid());
            view.SetRowCellValue(e.RowHandle, view.Columns["IsActive"], true);
            if (mDataSet.tbxTipCentru.Columns.Contains("EffectiveDate"))
                view.SetRowCellValue(e.RowHandle, view.Columns["EffectiveDate"], new DateTime(ContextUtilityClass.OnlyInstance.DataLucru.Year, 1, 1));
            mID = new Guid(view.GetRowCellValue(e.RowHandle, colID).ToString());
        }

        private void gridViewTipCentru_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            Utility utiliy = new Utility();
            DataRow drSelected = ((DataRowView)e.Row).Row;
            GridView view = sender as GridView;
            if (!mAbbreviationAlowNull)
            {
                object tmpObject = view.GetRowCellValue(e.RowHandle, view.Columns["Abbreviation"]);
                if (tmpObject.Equals(DBNull.Value) || tmpObject.Equals(string.Empty))
                {
                    e.ErrorText = "Nu ati precizat un cod!";
                    e.Valid = false;
                    view.ShowEditor();
                    return;
                }
            }
            Object tmpObj = view.GetRowCellValue(e.RowHandle, view.Columns["Abbreviation"]);
            if (!tmpObj.Equals(DBNull.Value) && !tmpObj.Equals(string.Empty))
            {
                string sCod = tmpObj.ToString();
                foreach (DataRow dr in mDataSet.tbxTipCentru.Rows)
                {
                    if ((string.Compare(sCod, dr["Abbreviation"].ToString(), true) == 0) && (mID != new Guid(dr["ID"].ToString())))
                    {
                        if (Convert.ToBoolean(dr["IsActive"].ToString()))
                        {
                            e.ErrorText = "Acest cod exista deja in nomenclator.";
                            e.Valid = false;
                            view.ShowEditor();
                            return;
                        }
                        if (XtraMessageBox.Show("Acest cod exista deja in nomenclator, la o inregistrare dezactivata, avand denumirea " + dr["Description"] + ".\n Doriti reactivarea acestei inregistrari?",
                                "Comenzi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            if (view.IsEditing)
                                view.HideEditor();
                            view.CancelUpdateCurrentRow();
                            dr["IsActive"] = true;
                            return;
                        }
                        e.Valid = false; return;
                    }
                }
            }
            if (String.IsNullOrEmpty(drSelected["Description"].ToString()))
            {
                e.ErrorText = "Nu ati precizat denumirea!";
                e.Valid = false;
                view.ShowEditor();
                return;
            }
            string sDenumire = drSelected["Description"].ToString();
            foreach (DataRow dr in mDataSet.tbxTipCentru.Rows)
            {
                if ((string.Compare(sDenumire, dr["Description"].ToString(), true) == 0) && (mID != new Guid(dr["ID"].ToString())))
                {
                    if (Convert.ToBoolean(dr["IsActive"].ToString()))
                    {
                        e.ErrorText = "Aceasta denumire exista deja in nomenclator.";
                        e.Valid = false;
                        view.ShowEditor();
                        return;
                    }
                    if (XtraMessageBox.Show("Aceasta denumire exista deja in nomenclator, la o inregistrare dezactivata, avand codul " + dr["Abbreviation"] + ".\n Doriti reactivarea acestei inregistrari?",
                            "Comenzi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        if (view.IsEditing)
                            view.HideEditor();
                        view.CancelUpdateCurrentRow();
                        dr["IsActive"] = true;
                        return;
                    }
                    e.Valid = false; return;
                }
            }

            mIsNewRow = false;
        }
    }
}
