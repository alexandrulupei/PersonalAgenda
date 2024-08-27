using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComenziBase;
using CommonDataSets.GUI;
using CommonGUIControllers.GUI;
using GSFramework;
using Utilities;

namespace ComenziListe
{
    public partial class DisponibilCentreFiltre : FrameworkWindow
    {
        #region Constructor
        public DisponibilCentreFiltre()
        {
            InitializeComponent();
        }
        #endregion 

        #region Class Fildes
        private Utility mUtil = new Utility();
        private ListaComenziDataSet mDataSet = new ListaComenziDataSet();
        private ListaComenziController mController = new ListaComenziController();
        private Guid mTipCentruID = Guid.Empty;
        private DateTime mDataStart;
        private DateTime mDataStop;
        private Guid mPartenerID = Guid.Empty;
        private Guid mLotID = Guid.Empty;
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                base.Initialize();
                mController =
                  (ListaComenziController)
                  Context.CreateController("CommonGUIControllers.GUI.ListaComenziController,CommonGUIControllers");
                mController.LoadLista = false;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }


                mDataSet = (ListaComenziDataSet)mController.DataSet;
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
            mDataStart = ContextUtilityClass.OnlyInstance.DataLucru;
            mDataStop = ContextUtilityClass.OnlyInstance.DataLucru;
            //dateEditDataStart.EditValue = mDataStart;
            //mUtil.SetDateTimeFormatFromConfig(dateEditDataStart);
          
            lookUpEditFurnizor.Properties.DataSource = mDataSet.tblPartener.DefaultView;
            lookUpEditFurnizor.Properties.DisplayMember = "Denumire";
            lookUpEditFurnizor.Properties.ValueMember = "ID";

            lookUpEditLot.Properties.DataSource = mDataSet.tblLotBase.DefaultView;
            lookUpEditLot.Properties.DisplayMember = "Denumire";
            lookUpEditLot.Properties.ValueMember = "ID";

        }

        #endregion

        private void simpleButtonListare_Click(object sender, EventArgs e)
        {

            if (mUtil.IsNotObjectEmpty(lookUpEditFurnizor.EditValue))
            {
                mPartenerID = (Guid) lookUpEditFurnizor.EditValue;
            }
           
            if (mUtil.IsNotObjectEmpty(lookUpEditLot.EditValue))
            {
                mLotID = (Guid) lookUpEditLot.EditValue;
            }
          
               
             
         
                Context.AddUserContextParameterList("ComenziListe.Lista.FurnizorID", mPartenerID);
                Context.AddUserContextParameterList("ComenziListe.Lista.LotID", mLotID);
                using (Context.CreateDialogWindow("ComenziListe.DisponibilCentreReportGrid, ComenziListe"))
                {
                    Context.CreatedWindow = null;
                }

                Context.DeleteEntryFromUserContextParameterList("ComenziListe.Lista.FurnizorID");
                Context.DeleteEntryFromUserContextParameterList("ComenziListe.Lista.LotID");

        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
