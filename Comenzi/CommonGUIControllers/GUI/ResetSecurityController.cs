using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CommonDataSets.GUI;
using Common_DT.GUI;
using GSFramework;

namespace CommonGUIControllers.GUI
{
   public class ResetSecurityController : Controller
    {
        #region Class Fields
        private ResetSecurityDataSet mDataSet;
        private Guid mAplicatiiID;

        #endregion

        #region Properties
        public override DataSet DataSet
        {
            get
            {
                return mDataSet;
            }
            set
            {
                mDataSet = (ResetSecurityDataSet)value;
            }
        }
        public Guid AplicatiiID
        {
            set { this.mAplicatiiID = value; }
        }
        #endregion

        #region Initialization Methods
        public override void InitializeClient()
        {
            try
            {
                mDataSet = new ResetSecurityDataSet();
                myAutoLoad = false;
            }
            catch (System.Exception excep)
            {
                HandleException(excep);
            }
        }
        public override void InitializeServer()
        {
            try
            {

            }
            catch (System.Exception excep)
            {
                HandleException(excep);
            }
        }
        #endregion

        #region Load Methods
        protected override bool LoadClientBefore()
        {
            try
            {
                return true;
            }
            catch (System.Exception excep)
            {
                HandleException(excep);
                return false;
            }
        }
        public override bool LoadServer()
        {
            try
            {
                ResetSecurityDataSvc svc = new ResetSecurityDataSvc();
                svc.GetUsers(mDataSet);
                mDataSet.AcceptChanges();
                return true;
            }
            catch (System.Exception excep)
            {
                myException = excep;
                myResultMessage = excep.Message;
                myResultCode = -1;

                return false; ;
            }
        }
        public bool LoadUsersRighs(Guid pUserID)
        {
            try
            {
                ResetSecurityDataSvc svc = new ResetSecurityDataSvc();
                svc.GetUserRights(mDataSet, pUserID, mAplicatiiID);
                mDataSet.AcceptChanges();
                return true;
            }
            catch (System.Exception excep)
            {
                myException = excep;
                myResultMessage = excep.Message;
                myResultCode = -1;

                return false;
            }
        }
        protected override bool LoadClientAfter()
        {
            try
            {
                return true;
            }
            catch (System.Exception excep)
            {
                HandleException(excep);
                return false;
            }
        }
        #endregion

        #region Perform Methods
        protected override bool PerformClientBefore()
        {
            try
            {
                return true;
            }
            catch (System.Exception excep)
            {
                HandleException(excep);
                return false;
            }
        }
        public override bool PerformServer()
        {
            try
            {
                ResetSecurityDataSvc svc = new ResetSecurityDataSvc();
                svc.UpdateDS(mDataSet);
                return true;
            }
            catch (System.Exception excep)
            {
                myException = excep;
                myResultMessage = excep.Message;
                myResultCode = -1;
                return false;
            }
        }
        protected override bool PerformClientAfter()
        {
            try
            {
                return true;
            }
            catch (System.Exception excep)
            {
                HandleException(excep);
                return false;
            }
        }
        #endregion

        #region Private Methods
        private void HandleException(System.Exception excep)
        {
            throw excep;
        }
        #endregion
    }
}
