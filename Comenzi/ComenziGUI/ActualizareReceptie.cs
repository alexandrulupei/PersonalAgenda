using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonDataSets.GUI;
using CommonDataSets.Liste;
using CommonGUIControllers.GUI;
using CommonGUIControllers.Liste;
using DevExpress.Data.Access;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Utilities;

namespace ComenziGUI
{
    public partial class ActualizareReceptie : GSFramework.Window
    {

        public ActualizareReceptie()
        {
            InitializeComponent();
        }


        #region  Class Fields

        private ActualizareReceptieDataSet mDataSet;
        private ActualizareReceptieController mController;
        private Guid mComandaID = Guid.Empty;
        private bool mIsModifica = false;
        private Utility mUtil = new Utility();
        private bool mEventCanceled;

        #endregion

        #region Events

        private void gridViewReceptie_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow dr = view.GetDataRow(e.RowHandle);

            if (e.Column == colNumarFactura || e.Column == colNumarNir)
            {
                dr["Selectat"] = true;
            }

            gridControlReceptie.RefreshDataSource();
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

        private void ActualizareReceptie_FormClosing(object sender, FormClosingEventArgs e)
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
            if (mIsModifica)
            {
                DataRow[] drsSelectat = mDataSet.tblDate.Select("Selectat=1");
                foreach (DataRow drSelectat in drsSelectat)
                {
                    DataRow[] drsRecBase = mDataSet.tblReceptieComandaBase.Select("ID='" + drSelectat["ID"] + "'");
                    foreach (DataRow drBase in drsRecBase)
                    {
                        drBase["NumarFactura"] = drSelectat["NumarFactura"];
                        drBase["NumarNir"] = drSelectat["NumarNir"];

                    }

                }
            }
            else
            {
                {
                    DataRow[] drsSelectat = mDataSet.tblDate.Select("Selectat=1");
                    foreach (DataRow drSelectat in drsSelectat)
                    {
                        DataRow[] drsRecBase = mDataSet.tblReceptieComandaBase.Select("ID='" + drSelectat["ID"] + "'");
                        foreach (DataRow drBase in drsRecBase)
                        {
                            DataRow[] drsRecDet =
                                mDataSet.tblReceptieComandaDet.Select("ReceptieComandaBaseID='" + drBase["ID"] + "'");
                            foreach (DataRow drDet in drsRecDet)
                            {
                                drDet.Delete();
                            }
                            drBase.Delete();
                        }

                    }

                }

            }
        }



        #endregion
        #region  Public Methods

        public override void Initialize()
        {
            try
            {

                base.Initialize();
                object obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Comenzi.CallerHandler");
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Comenzi.ComandaBaseID");
                if (obj != null && (!string.IsNullOrEmpty(obj.ToString())))
                    mComandaID = new Guid(obj.ToString());
                obj = Context.GetParameterValueUserContextParameterList("ComenziGUI.Comenzi.IsModifica");
                if (obj != null && (!string.IsNullOrEmpty(obj.ToString())))
                    mIsModifica =Convert.ToBoolean(obj.ToString());

                if (mIsModifica) this.Text = "Modificare receptie";
                else
                {
                    this.Text = "Stergere Receptie";
                }
                mController =
                    (ActualizareReceptieController)
                    Context.CreateController("CommonGUIControllers.GUI.ActualizareReceptieController,CommonGUIControllers");
                mController.LoadDate = false;
                mController.ComandaBaseID = mComandaID;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());

                    return;
                }

                mDataSet = (ActualizareReceptieDataSet)mController.DataSet;
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
            gridControlReceptie.DataSource= mDataSet.tblDate;
            mUtil.SetDateTimeFormatFromConfig(repositoryItemDateEditData);
        }

        #endregion

        

      
    }
}
