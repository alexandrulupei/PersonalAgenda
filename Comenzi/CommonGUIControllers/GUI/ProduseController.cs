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
   public class ProduseController : Controller
    {
       #region Constructor

       public ProduseController()
        {
        }

        #endregion

        #region Class Fields
        private Nomenclatoare mDataSet;
        private bool mLoadSimbol = false;
        private String mtableName = String.Empty;
        private String mtableColumn = String.Empty;
        private String mFiltru = String.Empty;
        #endregion

        #region Properties
        public override DataSet DataSet
        {
            get
            { return mDataSet; }
            set
            { mDataSet = (Nomenclatoare)value; }
        }
        #region Load Simbol Parameters
        public bool LoadSimbol
        {
            set { mLoadSimbol = value; }
        }

        public String TableName
        {
            set { mtableName = value; }
        }

        public String TableColumn
        {
            set { mtableColumn = value; }
        }

        public String Filtru
        {
            set { mFiltru = value; }
        }
        #endregion 

        #endregion

        #region Initialization Methods
        public override void InitializeClient()
        {
            try
            {
                mDataSet = new Nomenclatoare();
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
                ProduseDataSvc mDataSvc = new ProduseDataSvc();
                if (mLoadSimbol)
                {
                    mDataSet.tblMaxSimbol.Clear();
                    mDataSvc.Get_SimbolFromTable(mDataSet, mtableName, mtableColumn, mFiltru);
                    mLoadSimbol = false;
                }
                else
                {
                    mDataSvc.GetProduse(mDataSet);
                    mDataSvc.GetCotaTva(mDataSet); 
                }

                LookupTableManagement.LookupTableBusSvc lookupSvc = new LookupTableManagement.LookupTableBusSvc();
                lookupSvc.GetLookupList("tbxUMStandard", mDataSet);
 
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
                ProduseDataSvc svc = new ProduseDataSvc();
                svc.UpdateDS(mDataSet);
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
