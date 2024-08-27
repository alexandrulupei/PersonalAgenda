using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GSFramework;

namespace CommonGUIControllers.GUI
{
    public class NomenclatoareController : Controller
    {
        #region Class Fields
        private bool mIsActive;
        private DataSet mDataSet;
        private string mDataTableName;
        private string mFilter = String.Empty;
        #endregion

        #region Properties
        public String DataTableName
        {
            set { this.mDataTableName = value; }
            get { return this.mDataTableName; }
        }
        public override DataSet DataSet
        {
            get
            {
                return mDataSet;
            }
            set
            {
                mDataSet = (DataSet)value;
            }
        }
        public bool IsActive
        {
            set { mIsActive = value; }
        }
        public String Filter
        {
            set { this.mFilter = value; }
            get { return this.mFilter; }
        }
        #endregion

        #region Initialization Methods
        public override void InitializeClient()
        {
            try
            {
                mDataSet = new DataSet();
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
                //mDataSet = new DataSet();
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
                LookupTableManagement.LookupTableBusSvc lookupSvc = new LookupTableManagement.LookupTableBusSvc();
                lookupSvc.FetchActive = false;
                if (mFilter == String.Empty)
                { lookupSvc.GetLookupList(mDataTableName, mDataSet, true, true); }
                else
                {
                    lookupSvc.GetLookupList(mDataTableName, mDataSet, mFilter);
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
                LookupTableManagement.LookupTableBusSvc lookupSvc = new LookupTableManagement.LookupTableBusSvc();
                lookupSvc.UpdateStandardLookupTable(mDataTableName, mDataSet);
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
