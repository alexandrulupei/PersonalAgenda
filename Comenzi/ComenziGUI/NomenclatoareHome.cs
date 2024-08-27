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
using CommonGUIControllers.Base;
using CommonGUIControllers.GUI;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using GSFramework;
using Utilities;

namespace ComenziGUI
{
    public partial class NomenclatoareHome : BaseWindow
    {
        #region Constructor

        public NomenclatoareHome()
        {
            InitializeComponent();
        }

        #endregion

        #region Class Fields

        private NomenclatoareController mController;
        private DataSet mDataSet;
        private string mDataTableName = string.Empty;
        private string mWindowName = string.Empty;
        private bool mIsAlege;

        private bool mUseCodAsReturnValue = true;
        private SortedList<string, object> mTagList = new SortedList<string, object>();
        private bool mIsNewRow = false;
        private string mFilter = string.Empty;

        #endregion

        #region Properties

        public Guid TbxID { get; set; }
        public string Denumire { get; set; }
        public string Cod { get; set; }
        public bool AbbreviationAllowNull { get; set; }

        #endregion

        #region Private Events
        private void gridViewNomenclator_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            mIsNewRow = true;
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["ID"], Guid.NewGuid());
            view.SetRowCellValue(e.RowHandle, view.Columns["IsActive"], true);
            if (mDataSet.Tables[mDataTableName].Columns.Contains("CodIntern"))
                view.SetRowCellValue(e.RowHandle, view.Columns["CodIntern"], 0);

            if (mDataSet.Tables[mDataTableName].Columns.Contains("DataStart"))
                view.SetRowCellValue(e.RowHandle, view.Columns["DataStart"],
                    new DateTime(ContextUtilityClass.OnlyInstance.DataLucru.Year, 1, 1));

            if (mDataSet.Tables[mDataTableName].Columns.Contains("EffectiveDate"))
                view.SetRowCellValue(e.RowHandle, view.Columns["EffectiveDate"],
                    new DateTime(ContextUtilityClass.OnlyInstance.DataLucru.Year, 1, 1));


            TbxID = new Guid(view.GetRowCellValue(e.RowHandle, gridColumnID).ToString());
            view.FocusedRowHandle = e.RowHandle;
            view.FocusedColumn = gridColumnAbbreviation;
            view.SelectCell(e.RowHandle, gridColumnAbbreviation);
            view.ShowEditor();
        }

        private void gridViewNomenclator_ValidateRow(object sender,
            DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Utility utiliy = new Utility();
            DataRow drSelected = ((DataRowView)e.Row).Row;
            GridView view = sender as GridView;
            if (!AbbreviationAllowNull)
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
                foreach (DataRow dr in this.mDataSet.Tables[mDataTableName].Rows)
                {
                    if ((string.Compare(sCod, dr["Abbreviation"].ToString(), true) == 0) &&
                        (TbxID != new Guid(dr["ID"].ToString())))
                    {
                        if (Convert.ToBoolean(dr["IsActive"].ToString()))
                        {
                            e.ErrorText = "Acest cod exista deja in nomenclator.";
                            e.Valid = false;
                            view.ShowEditor();
                            return;
                        }
                        else
                        {
                            if (XtraMessageBox.Show(
                                    "Acest cod exista deja in nomenclator, la o inregistrare dezactivata, avand denumirea " +
                                    dr["Description"].ToString() + ".\n Doriti reactivarea acestei inregistrari?",
                                    "ECONET", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                            {
                                if (view.IsEditing)
                                    view.HideEditor();
                                view.CancelUpdateCurrentRow();
                                dr["IsActive"] = true;
                                return;
                            }
                            else
                            {
                                e.Valid = false;
                                return;
                            }
                        }
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
            else
            {
                string sDenumire = drSelected["Description"].ToString();
                foreach (DataRow dr in this.mDataSet.Tables[mDataTableName].Rows)
                {
                    if ((string.Compare(sDenumire, dr["Description"].ToString(), true) == 0) &&
                        (TbxID != new Guid(dr["ID"].ToString())))
                    {
                        if (Convert.ToBoolean(dr["IsActive"].ToString()))
                        {
                            e.ErrorText = "Aceasta denumire exista deja in nomenclator.";
                            e.Valid = false;
                            view.ShowEditor();
                            return;
                        }
                        else
                        {
                            if (XtraMessageBox.Show(
                                    "Aceasta denumire exista deja in nomenclator, la o inregistrare dezactivata, avand codul " +
                                    dr["Abbreviation"].ToString() + ".\n Doriti reactivarea acestei inregistrari?",
                                    "Comenzi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                            {
                                if (view.IsEditing)
                                    view.HideEditor();
                                view.CancelUpdateCurrentRow();
                                dr["IsActive"] = true;
                                return;
                            }
                            else
                            {
                                e.Valid = false;
                                return;
                            }
                        }
                    }
                }
            }
            mIsNewRow = false;
        }

        private void gridViewNomenclator_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            mIsNewRow = false;
            if (gridViewNomenclator.FocusedRowHandle < 0)
                ToogleNavBarItems(false);
            else
                ToogleNavBarItems(true);

            GridView view = sender as GridView;
            object obj = view.GetRowCellValue(e.FocusedRowHandle, gridColumnID);
            if ((obj != null) && (obj != DBNull.Value))
            {
                TbxID = new Guid(obj.ToString());
                Denumire = view.GetRowCellValue(e.FocusedRowHandle, gridColumnDescription).ToString();
                Cod = view.GetRowCellValue(e.FocusedRowHandle, gridColumnAbbreviation).ToString();
                mTagList["ID"] = TbxID;
                mTagList["Cod"] = Cod;
                mTagList["Abbreviation"] = Cod;
                mTagList["Description"] = Denumire;
                mTagList["DataSource"] = mDataSet.Tables[mDataTableName];
                this.Tag = mTagList;
                //if (mUseCodAsReturnValue)
                //    this.Tag = SetButtonEditAlegeList(mCod, mDataSet.Tables[mDataTableName]);
                //else
                //    this.Tag = SetButtonEditAlegeList(Denumire, mDataSet.Tables[mDataTableName]);
            }
        }

        private void gridViewNomenclator_DoubleClick(object sender, EventArgs e)
        {
            Alege();
        }

        private void gridViewNomenclator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Alege();
            else if (e.KeyCode == Keys.Insert)
            {
                e.Handled = true;
                Adauga();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                Sterge();
            }
        }

        private void gridControlNomenclator_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                Utility utiliy = new Utility();
                e.Handled = true;
                if (utiliy.DeleteConfirmation())
                {
                    RemoveRow();
                }
            }
        }

        private void gridViewNomenclator_InvalidRowException(object sender,
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

        private void NomenclatoareHome_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                if (mySaveData)
                {
                    Cursor = Cursors.WaitCursor;
                    if (Validate())
                    {
                        Save();
                        if (!mySaveData)
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        mySaveData = false;
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (HasChanges() == true)
                    {
                        DialogResult drChange = XtraMessageBox.Show("Doriti sa salvati modificarile?", "COMENZI",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (drChange == DialogResult.Yes)
                        {
                            Cursor = Cursors.WaitCursor;
                            if (Validate())
                            {
                                Save();
                                if (!mySaveData)
                                {
                                    e.Cancel = true;
                                }
                            }
                            else
                            {
                                mySaveData = false;
                                e.Cancel = true;
                            }
                        }
                        else if (drChange == DialogResult.Cancel)
                        {
                            mySaveData = false;
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Context.HandleException(this, exception);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Private Methods

        private void ToogleNavBarItems(bool pEnabled)
        {
            base.navBarItemModifica.Enabled = base.navBarItemSterge.Enabled = pEnabled;
        }

        private void RemoveRow()
        {
            Utility utiliy = new Utility();
            DataRow dr = utiliy.GetSelectedRow(this.gridControlNomenclator);
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
                                    "Aceasta inregistrare nu poate fi stearsa permanent din baza de date deoarece este folosita in alte tabele.\nDoriti dezactivarea inregistrarii?",
                                    "ECONET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dr["IsActive"] = false;
                                mySaveData = true;
                                Save();
                            }
                            return;
                        }
                        else
                        {
                            Context.HandleException(mController.ServerException.ToString());
                            mySaveData = false;
                            return;
                        }
                    }
                    catch
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        mySaveData = false;
                        return;
                    }
                }
            }
        }

        private new bool Validate()
        {
            return mySaveData = true;
        }

        private void Save()
        {
            try
            {
                if (!mySaveData) return;

                SaveToDataSet();
                if (mController.DataSet.HasChanges())
                {
                    mController.Perform();
                    if (ControllerUtils.HandleResultCode(mController))
                    {
                        mySaveData = false;
                    }
                }
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }

        private bool HasChanges()
        {
            var bChanges = mController.DataSet.HasChanges();
            mySaveData = true;
            return bChanges;
        }

        private void SaveToDataSet()
        {
        }

        private void SetSelectedRow(Guid pFocusedID)
        {
            gridViewNomenclator.FocusedColumn = gridColumnID;
            if (pFocusedID != Guid.Empty)
            {
                for (int i = 0; i < gridViewNomenclator.RowCount; i++)
                {
                    DataRow dr = gridViewNomenclator.GetDataRow(i);
                    if ((Guid) dr["ID"] == pFocusedID)
                    {
                        gridViewNomenclator.FocusedRowHandle = i;
                        break;
                    }
                }
            }
            else
            {
                if (gridViewNomenclator.RowCount > 0)
                    gridViewNomenclator.FocusedRowHandle = 1;
            }
        }

        #endregion

        #region Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize(this.gridControlNomenclator);

                string sIsAlege = GetParameter("IsAlege");
                if (!string.IsNullOrEmpty(sIsAlege))
                {
                    mIsAlege = Convert.ToBoolean(sIsAlege);
                }
                string sReturnColumn = GetParameter("ReturnColumn");
                if (!String.IsNullOrEmpty(sReturnColumn))
                    mUseCodAsReturnValue = false;
                base.navBarItemAlege.Visible = mIsAlege;
                if (mIsAlege)
                {
                    gridColumnIsActive.Visible = false;
                    gridColumnIsActive.OptionsColumn.AllowEdit = false;
                    base.navBarItemSalvare.Visible = false;
                }
                else
                {
                    gridColumnIsActive.Visible = true;
                    gridColumnIsActive.OptionsColumn.AllowEdit = true;
                    //base.navBarItemSalvare.Visible = true;
                }
                string sDataTableName = GetParameter("pDataTable");
                if (!string.IsNullOrEmpty(sDataTableName))
                    mDataTableName = sDataTableName;
                else
                    return;
                string sWindowName = GetParameter("pNumeFereastra");
                if (!string.IsNullOrEmpty(sWindowName))
                    mWindowName = sWindowName;
                sWindowName = GetParameter("pFilter");
                if (!string.IsNullOrEmpty(sWindowName))
                    mFilter = sWindowName;
                base.labelBaseWindowHeader.Text = this.Text = mWindowName;


                mController =
                    (NomenclatoareController)
                    Context.CreateController(
                        "CommonGUIControllers.GUI.NomenclatoareController,CommonGUIControllers");
                mController.DataTableName = this.mDataTableName;
                mController.Filter = mFilter;
                mController.Load();
                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
                mDataSet = (DataSet) mController.DataSet;

                string sIsButtonEditAlege = GetParameter("IsButtonEditAlege");
                if (!String.IsNullOrEmpty(sIsButtonEditAlege))
                {
                    if (mUseCodAsReturnValue)
                        this.Tag = SetButtonEditAlegeList(Cod, mDataSet.Tables[mDataTableName]);
                    else
                        this.Tag = SetButtonEditAlegeList(Denumire, mDataSet.Tables[mDataTableName]);
                    return;
                }
                mDataSet.AcceptChanges();
                mDataSet.EnforceConstraints = false;
                string sSelectedID = GetParameter("pSelectedID");

                this.Bind();
                string sSetFocusedColumn = GetParameter("SetFocusedColumn");
                if (!String.IsNullOrEmpty(sSetFocusedColumn))
                {
                    Application.DoEvents();
                    SendKeys.Flush();
                    if (mUseCodAsReturnValue)
                        gridViewNomenclator.FocusedColumn = gridColumnAbbreviation;
                    else
                        gridViewNomenclator.FocusedColumn = gridColumnDescription;
                    gridViewNomenclator.Focus();
                    SendKeys.Send(sSetFocusedColumn);
                }

            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }

        public override void Bind()
        {
            base.Bind();
            mDataSet.Tables[mDataTableName].DefaultView.Sort = " Abbreviation, Description ASC";
            //if (mIsAlege)
            //{
            if (mDataSet.Tables[mDataTableName].Columns.Contains("CodIntern") &&
                mDataSet.Tables[mDataTableName].Columns["CodIntern"].DataType == typeof(string))
                mDataSet.Tables[mDataTableName].DefaultView.RowFilter = "IsActive=true and CodIntern like '0%'";
            else
                mDataSet.Tables[mDataTableName].DefaultView.RowFilter = "IsActive=true";
            //}
            gridControlNomenclator.DataSource = mDataSet.Tables[mDataTableName].DefaultView;
        }

        public override void Alege()
        {
            if (mIsAlege && !gridViewNomenclator.IsEditing)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public override void Iesire()
        {
            if (!gridViewNomenclator.IsEditing && !gridViewNomenclator.IsEditorFocused && !mIsNewRow)
            {
                mySaveData = false;
                Close();
            }
        }

        public override void Salvare()
        {
            mySaveData = true;
            Close();
        }

        public override void Adauga()
        {
            gridControlNomenclator.EmbeddedNavigator.Buttons.DoClick(
                gridControlNomenclator.EmbeddedNavigator.Buttons.Append);
        }

        public override void Modifica()
        {
            GridView view = gridViewNomenclator;
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

