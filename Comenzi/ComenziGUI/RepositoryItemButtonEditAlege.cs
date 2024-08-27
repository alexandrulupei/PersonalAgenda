using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraVerticalGrid;
using GSFramework;

namespace ComenziGUI
{
    public partial class RepositoryItemButtonEditAlege : RepositoryItemButtonEdit
    {
        #region Constructors
        public RepositoryItemButtonEditAlege()
        {
            this.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(RepositoryItemButtonEditCustom_ParseEditValue);
            this.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(RepositoryItemButtonEditCustom_FormatEditValue);
            this.Validating += new CancelEventHandler(RepositoryItemButtonEditCustom_Validating);
            this.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(RepositoryItemButtonEditCustom_ButtonClick);
        }
        #endregion

        #region Class Fields
        private object mDataSource;
        private string mValueMember;
        private string mDisplayMember;
        private DataTable mDataTable;
        private bool mAllowNull = false;
        private string mAssemblyName;
        private string mAssemblyParameters;
        private string mAlegeValue = string.Empty;
        private bool mSetFocusedValue = false;
        private SortedList<string, object> mButtonEditAlegeList = new SortedList<string, object>();
        private bool mIsAlege = false;
        private BaseView mGridViewSource;
        private DevExpress.XtraVerticalGrid.VGridControl mVerticalGridControl;
        private bool mUseDisplayMember = false;
        private bool mCausesValidation = true;
        private string mValue = string.Empty;
        private string mAdditionalSelectClause = string.Empty;
        #endregion

        #region Properties
        /// <summary>
        /// Tabela cu care se valideaza: tblPlanCont
        /// </summary>
        public object DataSource
        {
            set
            {
                mDataSource = value;
                mDataTable = mDataSource as DataTable;
            }
            get { return mDataTable; }
        }
        /// <summary>
        /// Coloana ID
        /// </summary>
        public string ValueMember
        {
            set
            {
                mValueMember = value;
            }
        }
        /// <summary>
        /// Coloana Cod
        /// </summary>
        public string DisplayMember
        {
            set
            {
                mDisplayMember = value;
            }
        }
        /// <summary>
        /// Daca DataSource suporta null se seteaza pe true
        /// </summary>
        public bool AllowNull
        {
            set
            {
                mAllowNull = value;
            }
        }
        /// <summary>
        /// Numele assembly-ului in clar ca la creare ferestre
        /// </summary>
        public string AssemblyName
        {
            set { this.mAssemblyName = value; }
        }
        /// <summary>
        /// Parametrii ferestrei apelate
        /// </summary>
        public string AssemblyParameters
        {
            set { this.mAssemblyParameters = value; }
        }
        public bool SetFocusedValue
        {
            set { this.mSetFocusedValue = value; }
        }
        public SortedList<string, object> CustomFieldsAlegeList
        {
            get { return this.mButtonEditAlegeList; }
            set
            {
                if (value == null) return;
                SyncButtonEditAlegeList((SortedList<string, object>)value);
            }
        }
        /// <summary>
        /// Daca este true atunci se foloseste DisplayMember la validare in datasource
        /// altfel se foloseste Cod
        /// </summary>
        public bool UseDisplayMember
        {
            set { this.mUseDisplayMember = value; }
        }
        /// <summary>
        /// Ex: Document Primar vrem sa fie creat manual. Se testeaza prin Guid.Empty
        /// </summary>
        public bool CausesValidation
        {
            set { this.mCausesValidation = value; }
        }
        /// <summary>
        /// numarul Documentului Primar daca vrem sa fie creat manual
        /// </summary>
        public string DisplayText
        {
            get { return mValue; }
        }
        public string AdditionalSelectClause
        {
            set { this.mAdditionalSelectClause = value; }
        }
        #endregion

        #region Events
        void GridViewSource_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Alegeti o valoare!";
        }
        void VerticalGridControl_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Alegeti o valoare!";
        }
        void RepositoryItemButtonEditCustom_Validating(object sender, CancelEventArgs e)
        {
            ButtonEdit button = sender as ButtonEdit;
            if ((button == null) || (button.EditValue == null)) return;
            //GetGridViewSource((BaseView)((DevExpress.XtraGrid.GridControl)(((DevExpress.XtraEditors.TextEdit)(button)).Parent)).DefaultView);
            SetContainerEvent(button.Parent);
            object valoare = button.EditValue;
            if (valoare.GetType() == Type.GetType("System.Guid"))
            {
                //ma asigur ca nu ramane setat, altfel nu mai functioneaza corect daca se scrie valoarea direct, fara sa se deschida fereastra de alege
                mAdditionalSelectClause = string.Empty;
                return;
            }
            if (mAllowNull)
            {
                if (valoare.Equals(DBNull.Value))
                {
                    //ma asigur ca nu ramane setat, altfel nu mai functioneaza corect daca se scrie valoarea direct, fara sa se deschida fereastra de alege
                    mAdditionalSelectClause = string.Empty;
                    return;
                }
            }

            DataRow[] drs = mDataTable.Select(mDisplayMember + "='" + valoare.ToString() + "'");
            if (drs.Length == 0)
            {
                RepositoryItemButtonEditCustom_ButtonClick(sender, null);
            }
            //ma asigur ca nu ramane setat, altfel nu mai functioneaza corect daca se scrie valoarea direct, fara sa se deschida fereastra de alege
            mAdditionalSelectClause = string.Empty;
        }
        void RepositoryItemButtonEditCustom_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            object obj = e.Value;
            if (obj == null)
                return;
            if (obj.GetType() != Type.GetType("System.Guid"))
            {
                //in caz ca din DataSource vine null (se pune daca DataSource admite null)
                if (mAllowNull)
                    if (obj.Equals(DBNull.Value))
                        e.Value = string.Empty;
                return;
            }
            DataRow dr = null;
            DataRow[] drs = mDataTable.Select(mValueMember + "='" + (Guid)obj + "'");
            if (drs.Length > 0)
                dr = drs[0];
            if (dr != null)
            {
                mIsAlege = false;
                e.Value = dr[mDisplayMember].ToString();
            }
            else
            {
                if (!mCausesValidation)
                    e.Value = mValue;
                else
                {
                    e.Value = string.Empty;
                }
                //posibil sa se ajunga aici prin schimbarea datasource-ului
            }
        }
        void RepositoryItemButtonEditCustom_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            object obj = e.Value;
            if ((obj == null) || (obj.GetType() != Type.GetType("System.String")))
                return;
            //in caz ca DataSource admite null string.Empty e transformat in DBNull.Value
            //se adauga numai daca DataSource admite null
            if (mAllowNull)
            {
                if (obj.ToString().Trim() == string.Empty)
                {
                    e.Value = DBNull.Value;
                    return;
                }
            }
            DataRow[] drs;
            if (/*!mIsAlege && */!String.IsNullOrEmpty(mAdditionalSelectClause))
                drs = mDataTable.DefaultView.ToTable().Select(mDisplayMember + "='" + obj.ToString() + "'" + mAdditionalSelectClause);
            else
                drs = mDataTable.DefaultView.ToTable().Select(mDisplayMember + "='" + obj.ToString() + "'");

            //DataRow[] drs = mDataTable.Select(mDisplayMember + "='" + obj.ToString() + "'");
            //se pun  si conditiile de validare
            //daca se valideaza il fac Guid daca nu nu.
            if (drs.Length > 0)
            {
                e.Value = (Guid)drs[0][mValueMember];
                for (int i = 0; i < mButtonEditAlegeList.Count; i++)
                {
                    string s = mButtonEditAlegeList.Keys[i];
                    if (mDataTable.Columns.Contains(s))
                    {
                        if (drs[0][s] != DBNull.Value)
                        {
                            mButtonEditAlegeList[s] = drs[0][s];
                        }
                        else
                        {
                            mButtonEditAlegeList[s] = string.Empty;
                        }
                    }
                    else if (s.CompareTo("Cod") != 0 && s.CompareTo("DataSource") != 0 && !mIsAlege)
                    {
                        //nu suntem din alege asa ca resetam campurile aditionale, campuri ce nu sunt in datasource
                        mButtonEditAlegeList[s] = string.Empty;
                    }
                }
            }
            else if (!mCausesValidation)
            {
                //suntem in situatia in care nu vrem popup la fereastra dar vrem sa pastram valoare scrisa
                //si testam prin Guid.Empty
                if (!e.Value.ToString().Equals(Guid.Empty.ToString()))
                    mValue = e.Value.ToString();
                e.Value = Guid.Empty;
            }

        }
        void RepositoryItemButtonEditCustom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit button = sender as ButtonEdit;
            if (button == null) return;

            using (Window wnd = String.IsNullOrEmpty(mAssemblyParameters) ?
                  ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName) :
                  (mSetFocusedValue ?
                  ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName, mAssemblyParameters + button.Text) :
                  ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName, mAssemblyParameters)))
            {
                if (wnd.DialogResult == DialogResult.OK)
                {
                    SetValuesFromAlegeWindow(wnd.Tag);
                    mIsAlege = true;
                    button.EditValue = button.Text = mAlegeValue;
                }
                else
                {
                    mIsAlege = false;
                }
                ClientContext.OnlyInstance.CreatedWindow = null;
            }
        }
        #endregion

        #region Private Methods
        private void GetGridViewSource(GridControl pGridView)
        {
            if (pGridView != null && pGridView.DefaultView != mGridViewSource)
            {
                this.mGridViewSource = pGridView.DefaultView;
                mGridViewSource.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(GridViewSource_InvalidValueException);
            }
        }
        private void GetGridViewSource(VGridControl pVerticalGridControl)
        {
            if (pVerticalGridControl == null)
                return;
            if (pVerticalGridControl != mVerticalGridControl)
            {
                mVerticalGridControl = pVerticalGridControl;
                mVerticalGridControl.InvalidValueException += new InvalidValueExceptionEventHandler(VerticalGridControl_InvalidValueException);
            }
        }
        private void SetContainerEvent(Object pContainer)
        {

            if (pContainer is VGridControl)
                GetGridViewSource((VGridControl)pContainer);
            if (pContainer is GridControl)
                GetGridViewSource((GridControl)pContainer);
        }

        /// <summary>
        /// Muta informatiile din pList in mButtonEditAlegeList.
        /// </summary>
        private void SyncButtonEditAlegeList(SortedList<string, object> pList)
        {
            if (pList == null) return;
            foreach (string s in pList.Keys)
            {
                object objOut = string.Empty;
                pList.TryGetValue(s, out objOut);
                mButtonEditAlegeList[s] = objOut;
            }
        }
        private void SetButtonEditAlegeListToNull()
        {
            if (mButtonEditAlegeList == null) return;
            for (int i = 0; i < mButtonEditAlegeList.Count; i++)
            {
                string s = mButtonEditAlegeList.Keys[i];
                mButtonEditAlegeList[s] = null;
            }
        }
        private void SetValuesFromAlegeWindow(object pTag)
        {
            if (pTag == null) return;
            SyncButtonEditAlegeList((SortedList<string, object>)pTag);
            mButtonEditAlegeList = (SortedList<string, object>)pTag;
            this.Tag = mButtonEditAlegeList;
            object objDataSource;
            if (mButtonEditAlegeList.TryGetValue("DataSource", out objDataSource))
            {
                mDataTable = (DataTable)objDataSource;
            }
            if (mUseDisplayMember)
            {
                if (mButtonEditAlegeList.TryGetValue(mDisplayMember, out objDataSource))
                {
                    mAlegeValue = objDataSource.ToString();
                }
            }
            else if (mButtonEditAlegeList.TryGetValue("Cod", out objDataSource))
            {
                mAlegeValue = objDataSource.ToString();
            }
            object obj;
            if (mButtonEditAlegeList.TryGetValue("AditionalSelectClause", out obj))
            {
                mAdditionalSelectClause = obj.ToString();
            }
        }
        private void SetValueToRow(object pValue)
        {
            if (mGridViewSource != null)
            {
                try
                {
                    Guid pGuid = (Guid)pValue;
                }
                catch (Exception excep)
                {
                    XtraMessageBox.Show(excep.Message);
                    throw;
                }
                //mGridViewSource.SetRowCellValue(mGridViewSource.FocusedRowHandle, mGridViewSource.FocusedColumn, pValue);
                //DoFormatEditValue(pValue);
            }
        }
        private Guid GetUnderlyingValue(string pValue)
        {
            DataRow[] drs = mDataTable.Select(mDisplayMember + "='" + pValue + "'");
            if (drs.Length > 0)
            {
                return (Guid)drs[0][mValueMember];
            }
            else
                return Guid.Empty;
        }
        #endregion

        #region Public Methods
        public void SetDataSource()
        {
            Window wnd;
            if (String.IsNullOrEmpty(mAssemblyParameters))
                wnd = (Window)ClientContext.OnlyInstance.InitializeWindow(mAssemblyName, "IsButtonEditAlege=1");
            else
                // TO DO: Se recomanda inlocuirea acestei linii de cod cu versiunea corecta
                // wnd = (Window)ClientContext.OnlyInstance.InitializeWindow(mAssemblyName, "IsButtonEditAlege=1&" + mAssemblyParameters);
                wnd = (Window)ClientContext.OnlyInstance.InitializeWindow(mAssemblyName, "IsButtonEditAlege=1&" + "&SetFocusedColumn=" + mAssemblyParameters);

            if (wnd != null)
            {
                SyncButtonEditAlegeList((SortedList<string, object>)wnd.Tag);
                this.Tag = mButtonEditAlegeList;
                object objDataSource;
                if (mButtonEditAlegeList.TryGetValue("DataSource", out objDataSource))
                {
                    mDataTable = (DataTable)objDataSource;
                }
            }
        }
        #endregion
    }
}
