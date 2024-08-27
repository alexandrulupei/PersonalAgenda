using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using GSFramework;

namespace ComenziGUI
{
    public class ButtonEditAlege : ButtonEdit
    {
        #region Constructors

        #endregion

        #region Class Fields

        private object mDataSource;
        private string mValueMember;
        private string mDisplayMember;
        private DataTable mDataTable;
        private bool mAllowNull;
        private string mAssemblyName;
        private string mAssemblyParameters;
        private string mAlegeValue = string.Empty;
        private bool mSetFocusedValue;
        private SortedList<string, object> mButtonEditAlegeList = new SortedList<string, object>();
        private bool mIsAlege;
        private bool mUseDisplayMember;
        private object mValue;
        private bool mCausesValidation = true;
        private string mAdditionalSelectClause = string.Empty;
        private Guid mID;

        #endregion

        #region Properties

        /// <summary>
        /// Tabela cu care se valideaza
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
            set { mValueMember = value; }
        }

        /// <summary>
        /// Coloana Cod
        /// </summary>
        public string DisplayMember
        {
            set { mDisplayMember = value; }
        }

        /// <summary>
        /// Daca DataSource suporta null se seteaza pe true
        /// </summary>
        public bool AllowNull
        {
            set
            {
                mAllowNull = value;
                Properties.AllowNullInput = DefaultBoolean.True;
                Properties.NullText = string.Empty;
            }
        }

        /// <summary>
        /// Numele assembly-ului in clar ca la creare ferestre
        /// </summary>
        public string AssemblyName
        {
            set
            {
                mAssemblyName = value;

                ParseEditValue +=
                    ButtonEditAlege_ParseEditValue;
                FormatEditValue +=
                    ButtonEditAlege_FormatEditValue;
                Validating += ButtonEditAlege_Validating;
                ButtonClick +=
                    ButtonEditAlege_ButtonClick;
                InvalidValue +=
                    ButtonEditAlege_InvalidValue;
                KeyDown += ButtonEditAlege_KeyDown;

            }
        }

        /// <summary>
        /// Parametrii ferestrei apelate
        /// </summary>
        public string AssemblyParameters
        {
            set { mAssemblyParameters = value; }
        }

        public bool SetFocusedValue
        {
            set { mSetFocusedValue = value; }
        }

        public SortedList<string, object> CustomFieldsAlegeList
        {
            get { return mButtonEditAlegeList; }
            set
            {
                if (value == null) return;
                SyncButtonEditAlegeList(value);
            }
        }

        /// <summary>
        /// Daca este true atunci se foloseste DisplayMember la validare in datasource
        /// altfel se foloseste Cod
        /// </summary>
        public bool UseDisplayMember
        {
            set { mUseDisplayMember = value; }
        }

        public bool MyCausesValidation
        {
            set { mCausesValidation = value; }
        }

        public object ValueText
        {
            get { return mValue; }
        }

        public string AdditionalSelectClause
        {
            set { mAdditionalSelectClause = value; }
        }

        #endregion

        #region Events

        void ButtonEditAlege_Validating(object sender, CancelEventArgs e)
        {
            ButtonEdit button = sender as ButtonEdit;
            if ((button == null) || (button.EditValue == null)) return;
            object valoare = button.EditValue;
            if (valoare.GetType() == Type.GetType("System.Guid"))
            {
                return;
            }
            //in caz ca DataSource admite null DBNull.Value este o valoare valida
            //se adauga numai daca DataSource admite null
            if (mAllowNull)
            {
                if (valoare.Equals(DBNull.Value))
                {
                    SetButtonEditAlegeListToNull();
                    return;
                }
            }
            else
            {
                e.Cancel = true;
                using (Window wnd = String.IsNullOrEmpty(mAssemblyParameters)
                    ? ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName)
                    : (mSetFocusedValue
                        ? ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName, mAssemblyParameters + button.Text)
                        : ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName, mAssemblyParameters)))
                {
                    if (wnd.DialogResult == DialogResult.OK)
                    {
                        mIsAlege = true;
                        SetValuesFromAlegeWindow(wnd.Tag);
                        button.EditValue = mAlegeValue;
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                        mIsAlege = false;
                    }
                    ClientContext.OnlyInstance.CreatedWindow = null;
                }
                return;
            }

            DataRow[] drs = mDataTable.Select(mDisplayMember + "='" + valoare + "'");
            if (drs.Length == 0)
            {
                e.Cancel = true;
                using (Window wnd = String.IsNullOrEmpty(mAssemblyParameters)
                    ? ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName)
                    : (mSetFocusedValue
                        ? ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName, mAssemblyParameters + button.Text)
                        : ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName, mAssemblyParameters)))
                {
                    if (wnd.DialogResult == DialogResult.OK)
                    {
                        mIsAlege = true;
                        SetValuesFromAlegeWindow(wnd.Tag);
                        button.EditValue = mAlegeValue;
                        e.Cancel = false;
                    }
                    else
                    {
                        mIsAlege = false;
                        e.Cancel = true;
                    }
                    ClientContext.OnlyInstance.CreatedWindow = null;
                }
            }
        }

        void ButtonEditAlege_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            object obj = e.Value;
            if (obj == null)
                return;
            if (obj.GetType() != Type.GetType("System.Guid"))
            {
                //in caz ca din DataSource vine null (se pune daca DataSource admite null)
                if (mAllowNull)
                {
                    if (obj.Equals(DBNull.Value))
                    {
                        e.Value = string.Empty;
                    }
                }
            }
            else
            {
                DataRow dr = null;
                DataRow[] drs = mDataTable.Select(mValueMember + "='" + (Guid) obj + "'");
                if (drs.Length > 0)
                    dr = drs[0];
                if (dr != null)
                {
                    mIsAlege = false;
                    e.Value = dr[mDisplayMember].ToString();
                }
                else
                {
                    //posibil sa se ajunga aici prin schimbarea datasource-ului
                    //e.Value = string.Empty;
                    if (!mCausesValidation)
                        e.Value = mValue;
                    else
                    {
                        e.Value = string.Empty;
                    }

                }
            }
        }

        void ButtonEditAlege_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            ButtonEdit button = sender as ButtonEdit;
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
            if (!mID.Equals(Guid.Empty))
            {
                drs = mDataTable.DefaultView.ToTable().Select("ID='" + mID + "'");
            }
            else
            {
                if ( /*!mIsAlege && */!String.IsNullOrEmpty(mAdditionalSelectClause))
                    drs =
                        mDataTable.DefaultView.ToTable()
                            .Select(mDisplayMember + "='" + obj + "'" + mAdditionalSelectClause);
                else
                    drs = mDataTable.DefaultView.ToTable().Select(mDisplayMember + "='" + obj + "'");
            }
            //se pun  si conditiile de validare
            //daca se valideaza il fac Guid daca nu nu
            if (drs.Length == 1)
            {
                e.Value = (Guid) drs[0][mValueMember];
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
            //ma asigur ca nu ramane setat, altfel nu mai functioneaza corect daca se scrie valoarea direct, fara sa se deschida fereastra de alege
            mAdditionalSelectClause = string.Empty;
        }

        void ButtonEditAlege_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit button = sender as ButtonEdit;
            if (button == null) return;
            using (Window wnd = String.IsNullOrEmpty(mAssemblyParameters)
                ? ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName)
                : (mSetFocusedValue
                    ? ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName, mAssemblyParameters + button.Text)
                    : ClientContext.OnlyInstance.CreateDialogWindow(mAssemblyName, mAssemblyParameters)))
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

        void ButtonEditAlege_InvalidValue(object sender,
            InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Valoare incorecta!";
        }

        void ButtonEditAlege_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                ButtonEditAlege_ButtonClick(sender, null);
            }
        }

        #endregion

        #region Private Methods

        private void SetValuesFromAlegeWindow(object pTag)
        {
            if (pTag == null) return;
            //this.Tag = pTag;
            SyncButtonEditAlegeList((SortedList<string, object>) pTag);
            Tag = mButtonEditAlegeList;
            //mButtonEditAlegeList = (SortedList<string, object>)pTag;
            object objDataSource;
            if (mButtonEditAlegeList.TryGetValue("DataSource", out objDataSource))
            {
                mDataTable = (DataTable) objDataSource;
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
            if (mButtonEditAlegeList.TryGetValue("ID", out obj))
            {
                mID = (Guid) obj;
            }
        }

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

        #endregion

        #region Public Methods

        public void SetDataSource()
        {
            Window wnd;
            if (String.IsNullOrEmpty(mAssemblyParameters))
                wnd = ClientContext.OnlyInstance.InitializeWindow(mAssemblyName, "IsButtonEditAlege=1");
            else
                wnd =
                    ClientContext.OnlyInstance.InitializeWindow(mAssemblyName,
                        "IsButtonEditAlege=1&" + mAssemblyParameters);

            if (wnd != null)
            {
                SyncButtonEditAlegeList((SortedList<string, object>) wnd.Tag);
                Tag = mButtonEditAlegeList;
                object objDataSource;
                if (mButtonEditAlegeList.TryGetValue("DataSource", out objDataSource))
                {
                    mDataTable = (DataTable) objDataSource;
                }
            }
        }

        /// <summary>
        /// Atunci cnad se alege optiunea de allow null, pentru a salva valoarea in row 
        /// se apeleaza aceasta metoda
        /// </summary>
        public void EndCurrentEdit()
        {
            if (DataBindings.Count > 0)
            {
                object obj = DataBindings[0].BindingManagerBase.Current;
                try
                {
                    DataRow dr;
                    if (obj.GetType().Equals(typeof(DataRowView)))
                        dr = ((DataRowView) obj).Row;
                    else
                        dr = (DataRow) obj;
                    string bindingField = DataBindings[0].BindingMemberInfo.BindingField;
                    if (!EditValue.Equals(dr[bindingField]))
                        dr[bindingField] = EditValue;
                }
                catch
                {
                }
            }
        }

        #endregion
    }
}
