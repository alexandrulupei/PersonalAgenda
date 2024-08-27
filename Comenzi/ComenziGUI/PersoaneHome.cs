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

namespace ComenziGUI
{
    public partial class PersoaneHome : BaseWindow
    {
        #region Constructor
        public PersoaneHome()
        {
            InitializeComponent();
        }

        #endregion

        #region  Class Fields

        private PersoaneDataSet mDataSet;
        private PersoaneController mController;
        Utility mUtil = new Utility();
        #endregion
        #region  Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize(gridControlPersoane);

                navBarItemAlege.Visible = false;
                labelBaseWindowHeader.Text = "Persoane";
                navBarItemSalvare.Visible = false;
              
                mController =
                    (PersoaneController)
                    Context.CreateController("CommonGUIControllers.GUI.PersoaneController,CommonGUIControllers");
                mController.CentruID = ContextUtilityClass.OnlyInstance.CentruID;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (PersoaneDataSet)mController.DataSet;
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
            tblPersoaneBindingSource.DataSource = mDataSet.tblPersoane.DefaultView;
 
            gridViewPersoane.ExpandAllGroups();
        }


        public override void Iesire()
        {

            this.Close();
        }



        public override void Adauga()
        {
            base.Adauga();
            Context.AddUserContextParameterList("ComenziGUI.Persoane.CallerHandler", this);
            Context.AddUserContextParameterList("ComenziGUI.Persoane.IsNew", true);
            using (Context.CreateDialogWindow("ComenziGUI.PersoaneActualizare, ComenziGUI"))
            {
                Context.CreatedWindow = null;
            }
            Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Persoane.CallerHandler");
            Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Persoane.IsNew");
        }

        public override void Modifica()
        {
            base.Modifica();
            DataRow dr = mUtil.GetSelectedRow(gridControlPersoane);
            if (dr != null)
            {
                Context.AddUserContextParameterList("ComenziGUI.Persoane.CallerHandler", this);
                Context.AddUserContextParameterList("ComenziGUI.Persoane.IsNew", false);
                Context.AddUserContextParameterList("ComenziGUI.Persoane.PersoanaID", dr["ID"]);
        
                using (Context.CreateDialogWindow("ComenziGUI.PersoaneActualizare, ComenziGUI"))
                {
                    Context.CreatedWindow = null;
                }
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Persoane.CallerHandler");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Persoane.IsNew");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Persoane.PersoanaID");
     
            }
        }

        public override void Sterge()
        {
                DataRow dr = new Utilities.Utility().GetSelectedRow(gridControlPersoane);
                if ((dr != null) && (new Utilities.Utility().DeleteConfirmation()))
                {
                    dr["IsActive"] = false;
                    mController.Perform();
                    if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        return;
                    }
                    ReloadOnClose();
                }
                mDataSet.RejectChanges();
            
        }
        public void ReloadOnClose()
        {
            mDataSet.Clear();
            mController.CentruID = ContextUtilityClass.OnlyInstance.CentruID;
            mController.Load();

            if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
            {
                Context.HandleException(mController.ServerException.ToString());
                return;
            }
        }

        #endregion


    }
}
