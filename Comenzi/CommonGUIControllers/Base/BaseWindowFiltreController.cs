using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CommonDataSets;
using CommonDataSets.Base;
using Common_DT.Base;
using GSFramework;

namespace CommonGUIControllers.Base
{
   public class BaseWindowFiltreController : Controller
    {
        #region Class Members
        private BaseWindowFiltreDataSet mDataSet;
        private string mAssemblyName;
        private Guid mInstitutieID;
        #endregion

        #region Public Properties
        public override DataSet DataSet
        {
            get
            {
                return mDataSet;
            }
            set
            {
                mDataSet = (BaseWindowFiltreDataSet)value;
            }
        }
        public string AssemblyName
        {
            set { mAssemblyName = value; }
        }
        public Guid InstitutieID
        {
            set { mInstitutieID = value; }
        }

        #endregion

        #region Initialization Methods
        public override void InitializeClient()
        {
            try
            {
                mDataSet = new BaseWindowFiltreDataSet();
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
                BaseWindowFiltreDataSvc svc = new BaseWindowFiltreDataSvc();
                svc.GetListe(mDataSet, mAssemblyName, mInstitutieID);
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
                BaseWindowFiltreDataSvc svc = new BaseWindowFiltreDataSvc();
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
