using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CommonDataSets.GUI;
using Common_DT.Admin;
using GSFramework;
using LookupTableManagement;

namespace CommonGUIControllers.Admin
{
    public class RolesController : Controller
    {
        #region Class Fields
        private RolesDataSet mDataSet;
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
                mDataSet = (RolesDataSet)value;
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
                mDataSet = new RolesDataSet();
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
                RolesDataSvc svc = new RolesDataSvc();
                svc.GetWorkData(mDataSet, mAplicatiiID);
                LookupTableBusSvc svcLookup = new LookupTableBusSvc();
                svcLookup.FetchActive = true;
                if (mDataSet.tbxTipModul.Count == 0)
                    svcLookup.GetLookupList("tbxTipModul", mDataSet);
                if (mDataSet.tbxTipAcces.Count == 0)
                {
                    svcLookup.GetLookupList("tbxTipAcces", mDataSet);
                    foreach (DataRow dr in mDataSet.tbxTipAcces.Rows)
                    {
                        dr["Abbreviation"] = dr["Abbreviation"].ToString() + " - " + dr["Description"];
                    }
                }
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
                RolesDataSvc svc = new RolesDataSvc();
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
