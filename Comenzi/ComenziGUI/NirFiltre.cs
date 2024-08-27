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
using GSFramework;
using Utilities;

namespace ComenziGUI
{
    public partial class NirFiltre : GSFramework.Window
    {
        #region Constructor
        public NirFiltre()
        {
            InitializeComponent();
        }
        #endregion


        #region  Class Fields

        private NirDataSet mDataSet;
        private NirController mController;
        private  Guid mComandaID= Guid.Empty;

        private  Utility mUtil = new Utility();

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
                mController =
                    (NirController)
                    Context.CreateController("CommonGUIControllers.Liste.NirController,CommonGUIControllers");
                mController.LoadDate = false;
                mController.ComandaBaseID = mComandaID;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());

                    return;
                }
             
                mDataSet = (NirDataSet)mController.DataSet;
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
            tblReceptieComandaBaseBindingSource.DataSource = mDataSet.tblReceptieComandaBase.DefaultView;
            mUtil.SetDateTimeFormatFromConfig(repositoryItemDateEditData);
        }

        #endregion

        private void simpleButtonListare_Click(object sender, EventArgs e)
        {
            DataRow[] drSelectat = mDataSet.tblReceptieComandaBase.Select("Listare=1");
            foreach (DataRow dr in drSelectat)
            {
                Context.AddUserContextParameterList("ComenziGUI.Nir.NirID", dr["ID"]);
                using (Context.CreateDialogWindow("ComenziListe.NIRHome, ComenziListe"))
                {
                    Context.CreatedWindow = null;
                }
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Nir.NirID");
            }
           
        }

        private void simpleButtonRenunta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
