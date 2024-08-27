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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Nodes;
using GSFramework;

namespace ComenziGUI
{
    public partial class PersoaneActualizare : GSFramework.Window
    {
        #region Constructor
        public PersoaneActualizare()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields

        PersoaneDataSet mDataSet;
        PersoaneController mController;
        private bool mIsNew = true;
        private Guid mPersonaBaseID = Guid.Empty;
        private Guid mTipPersoanaID = Guid.Empty;
        private bool mEventCanceled = false;
        private bool mEventNo = false;
        private PersoaneHome mCallerHandle;
        private PersoaneDataSet.tblPersoaneRow mPersoanaBaseRow;
 
       
        #endregion

        #region Private Methods
        private void Save()
        {
            try
            {
                if (!mySaveData)
                    return;

                SaveToDataSet();
                this.Cursor = Cursors.WaitCursor;
                if (mController.DataSet.HasChanges())
                {
                    mController.Perform();
                    if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        mySaveData = false;
                        return;
                    }
                    DialogResult = DialogResult.OK;
                    mCallerHandle.ReloadOnClose();
                 
                }
                mDataSet.AcceptChanges();
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private bool HasChanges()
        {
            bool bChanges = false;
            BindingContext[mDataSet.tblPersoane].EndCurrentEdit();
            bChanges = mController.DataSet.HasChanges();
            if (mIsNew)
            {
                if ((mPersoanaBaseRow.Nume != string.Empty) || (mPersoanaBaseRow.Prenume != string.Empty))
                    bChanges = true;
            }
            return bChanges;
        }
        private new bool Validate()
        {
            mySaveData = false;
            if (String.IsNullOrEmpty(this.textEditNume.Text.Trim()))
            {
                this.textEditNume.ErrorText = "Introduceti numele persoanei!";
                this.textEditNume.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.textEditPrenume.Text.Trim()))
            {
                this.textEditPrenume.ErrorText = "Introduceti prenumele persoanei!";
                this.textEditPrenume.Focus();
                return false;
            }
            return mySaveData = true;
        }
        private void SaveToDataSet()
        {
            BindingContext[mDataSet.tblPersoane].EndCurrentEdit();
            if (mIsNew)
            {
                mDataSet.tblPersoane.AddtblPersoaneRow(mPersoanaBaseRow);
            }

            #region Save to lnkTipPersoane
            foreach (CheckedListBoxItem item in checkedComboBoxEditTipPersoana.Properties.Items)
            {
                string Descriere = item.Value.ToString();
                // Obtine ID-ul Evidentei din tblDeschidereBase
                DataRow[] rows = mDataSet.tbxTipPersoana.Select("Description = '" +  Descriere+ "'");
                Guid DeschidereID = Guid.Empty; 
                if (rows.Length > 0)
                {
                    DeschidereID = (Guid)rows[0]["ID"];
                }

                DataRow[] rowsLnk = mDataSet.lnkPersoanaTipPersoana.Select("TipPersoanaID = '" + DeschidereID + "' and PersoanaID = '" + mPersonaBaseID + "'");
                if (item.CheckState == CheckState.Checked)
                {
                    if ((rowsLnk.Length == 0) && (DeschidereID != Guid.Empty))
                    {
                     
                        CommonDataSets.GUI.PersoaneDataSet.lnkPersoanaTipPersoanaRow newRow =
                            mDataSet.lnkPersoanaTipPersoana.NewlnkPersoanaTipPersoanaRow();
                        newRow.ID = Guid.NewGuid();
                        newRow.PersoanaID =mPersonaBaseID;
                        newRow.TipPersoanaID = DeschidereID;
                        newRow.CentruID = ContextUtilityClass.OnlyInstance.CentruID;
                        mDataSet.lnkPersoanaTipPersoana.AddlnkPersoanaTipPersoanaRow(newRow);
                    }
                }
                if (item.CheckState == CheckState.Unchecked)
                {
                    if (rowsLnk.Length != 0)
                    {
                        // Sterge randul gasit daca s-a debifat
                        rowsLnk[0].Delete();
                    }
                }
            }
           

            #endregion

            mySaveData = true;
        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                mEventCanceled = mEventNo;
                base.Initialize();
                object obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Persoane.CallerHandler");
                if (obj.ToString() != string.Empty)
                    mCallerHandle = (PersoaneHome)obj;
                mController = (PersoaneController)Context.GetSharedController("CommonGUIControllers.GUI.PersoaneController, CommonGUIControllers");
                mController.CentruID = ContextUtilityClass.OnlyInstance.CentruID;
                mController.Load();
                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
                mDataSet = (PersoaneDataSet)mController.DataSet;
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Persoane.IsNew");
                if (obj.ToString() != string.Empty)
                    this.mIsNew = Convert.ToBoolean(obj);
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Persoane.PersoanaID");
                if (obj.ToString() != string.Empty)
                    this.mPersonaBaseID = new Guid(obj.ToString());
            
                if (mIsNew)
                {
                    mPersonaBaseID = Guid.NewGuid();
                    mPersoanaBaseRow = mDataSet.tblPersoane.NewtblPersoaneRow();
                    mPersoanaBaseRow.ID = mPersonaBaseID;
                    mPersoanaBaseRow.Nume = string.Empty;
                    mPersoanaBaseRow.Prenume = string.Empty;
                    mPersoanaBaseRow.IsActive = true;
                    mPersoanaBaseRow.CentruID = ContextUtilityClass.OnlyInstance.CentruID;
                }
                else
                {
                    mPersoanaBaseRow = mDataSet.tblPersoane.FindByID(mPersonaBaseID);
               
                    mController.Load();
                 
                }
            
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
            this.textEditNume.DataBindings.Add("EditValue", mPersoanaBaseRow, "Nume", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            this.textEditPrenume.DataBindings.Add("EditValue", mPersoanaBaseRow, "Prenume", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            foreach (DataRow dr in mDataSet.tbxTipPersoana.Rows)
            {
                CheckedListBoxItem item = new CheckedListBoxItem();
                item.Value = dr["Description"];
                if (!mIsNew)
                {

                    DataRow[] rows = mDataSet.lnkPersoanaTipPersoana.Select("PersoanaID = '" + mPersonaBaseID + "' AND TipPersoanaID='"+dr["ID"]+"'");
                    if (rows.Length > 0)
                    {
                        item.CheckState = CheckState.Checked;
                    }
                }
                else
                    item.CheckState = CheckState.Unchecked;
                this.checkedComboBoxEditTipPersoana.Properties.Items.Add(item);
            }

        }
        #endregion

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            mySaveData = true;
            this.Close();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersoaneActualizare_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                mEventCanceled = false;
                mEventNo = false;
                DialogResult performSave = DialogResult.Yes;

                if (mySaveData)
                {
                    // performSave is Yes
                }
                else
                {
                    if (this.HasChanges())
                    {
                        performSave = XtraMessageBox.Show("Doriti sa salvati modificarile?",
                                                          "Econet",
                                                          MessageBoxButtons.YesNoCancel,
                                                          MessageBoxIcon.Question);
                        if (performSave == DialogResult.Yes)
                        {
                            // performSave is Yes
                        }
                        else if (performSave == DialogResult.Cancel)
                        {
                            mySaveData = false;
                            mEventCanceled = e.Cancel = true;
                        }
                        else
                        {
                            mEventNo = true;
                        }
                    }
                    else
                    {
                        performSave = DialogResult.No;
                        mEventNo = true;
                    }
                }

                // Save changes
                if (performSave == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (this.Validate())
                    {
                        this.Save();
                    }
                    // mySaveData este acelasi cu rezultatul lui Validate sau
                    // daca s-au salvat datele cu rezultatul lui Save
                    if (!mySaveData)
                    {
                        // e.Cancel = true anuleaza inchiderea ferestrei
                        mEventCanceled = e.Cancel = true;
                    }
                    this.Cursor = Cursors.Default;
                }
            }
            catch (System.Exception exception)
            {
                Context.HandleException(this, exception);
            }
        }
    }
}
