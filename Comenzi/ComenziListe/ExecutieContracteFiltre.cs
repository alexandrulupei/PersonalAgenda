using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComenziBase;
using CommonDataSets.Liste;
using CommonGUIControllers.Liste;
using Utilities;

namespace ComenziListe
{
    public partial class ExecutieContracteFiltre : FrameworkWindow
    {
        #region Constructor
        public ExecutieContracteFiltre()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields
        private  ExecutieContracteDataSet mDataSet= new ExecutieContracteDataSet();
        private  ExecutieContracteController mController= new ExecutieContracteController();
        private Guid mLotID= Guid.Empty;
        private Guid mCentruID= Guid.Empty;
        private Utility mUtil = new Utility();
        private bool mIsProcent = false;
        #endregion

        #region Private Events
        private void simpleButtonListare_Click(object sender, EventArgs e)
        {
            if (mUtil.IsNotObjectEmpty(lookUpEditLot.EditValue))
            {
                mLotID = (Guid)lookUpEditLot.EditValue;
            }

            if (mUtil.IsNotObjectEmpty(lookUpEditCentru.EditValue))
            {
                mCentruID = (Guid)lookUpEditCentru.EditValue;
            }

            if (radioGroupTipLista.SelectedIndex == 0)
            {
                mIsProcent = false;
            }
            else
            {
                mIsProcent = true;
            }
            Context.AddUserContextParameterList("ComenziListe.ExecutieContracte.CentruID", mCentruID);
            Context.AddUserContextParameterList("ComenziListe.ExecutieContracte.LotID", mLotID);
            Context.AddUserContextParameterList("ComenziListe.ExecutieContracte.IsProcent", mIsProcent);
            using (Context.CreateDialogWindow("ComenziListe.ExecutieContracteReportGrid, ComenziListe"))
            {
                Context.CreatedWindow = null;
            }
            Context.DeleteEntryFromUserContextParameterList("ComenziListe.ExecutieContracte.CentruID");
            Context.DeleteEntryFromUserContextParameterList("ComenziListe.ExecutieContracte.LotID");
            Context.DeleteEntryFromUserContextParameterList("ComenziListe.ExecutieContracte.IsProcent");
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion


        #region Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize();
                mController =(ExecutieContracteController)Context.CreateController("CommonGUIControllers.Liste.ExecutieContracteController,CommonGUIControllers");
                mController.LoadDate = false;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }


                mDataSet = (ExecutieContracteDataSet)mController.DataSet;
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
            
            lookUpEditLot.Properties.DataSource = mDataSet.tblLotBase;
            lookUpEditLot.Properties.DisplayMember = "Denumire";
            lookUpEditLot.Properties.ValueMember = "ID";

            lookUpEditCentru.Properties.DataSource = mDataSet.tblCentru;
            lookUpEditCentru.Properties.DisplayMember = "Denumire";
            lookUpEditCentru.Properties.ValueMember = "ID";

        }

        #endregion

     

    }
}
