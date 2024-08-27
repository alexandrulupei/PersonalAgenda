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
   public class ListaComenziController: Controller
    {
        #region Constructor

       public ListaComenziController()
        {
        }

        #endregion

        #region Class Fields
        private ListaComenziDataSet mDataSet;
        private  Guid mTipCentruID= Guid.Empty;
        private  bool mLoadLista= false;
        private bool mLoadListaDisponibil = false;
        private DateTime mDataStart;
        private DateTime mDataStop;
        private  Guid mFurnizorID = Guid.Empty;
        private  Guid mLotID= Guid.Empty;

        #endregion

        #region Properties
        public override DataSet DataSet
        {
            get
            { return mDataSet; }
            set
            { mDataSet = (ListaComenziDataSet)value; }
        }

        public Guid TipCentruID 
        {
            get { return mTipCentruID; }
            set
            {
                mTipCentruID = (Guid)value;
            }
        }

        public Guid FurnizorID
        {
            get { return mFurnizorID; }
            set
            {
                mFurnizorID = (Guid)value;
            }
        }
        public Guid LotID
        {
            get { return mLotID; }
            set
            {
                mLotID = (Guid)value;
            }
        }


        public bool LoadLista
        {
            get { return mLoadLista; }
            set { mLoadLista = (bool) value; }
        }
        public bool LoadListaDisponibil
        {
            get { return mLoadListaDisponibil; }
            set { mLoadListaDisponibil = (bool)value; }
        }
        public DateTime DataStart
        {
            get { return mDataStart; }
            set
            {
                mDataStart = (DateTime)value;
            }
        }
        public DateTime DataStop
        {
            get { return mDataStop; }
            set
            {
                mDataStop = (DateTime)value;
            }
        }
        #endregion

        #region Initialization Methods
        public override void InitializeClient()
        {
            try
            {
                mDataSet = new ListaComenziDataSet();
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
                ListaComenziDataSvc mDataSvc = new ListaComenziDataSvc();
                if (mLoadLista)
                {
                    mDataSvc.GetLista(mDataSet, mTipCentruID, mDataStart, mDataStop,mFurnizorID, mLotID);
                    mDataSvc.GetCentre(mDataSet, mTipCentruID);
                }
                else if (mLoadListaDisponibil)
                {
                    mDataSvc.GetListaDisponibil(mDataSet, mFurnizorID, mLotID);
                }
                mDataSvc.GetDate(mDataSet);
                LookupTableManagement.LookupTableBusSvc lookupSvc = new LookupTableManagement.LookupTableBusSvc();
                lookupSvc.GetLookupList("tbxTipCentru", mDataSet);
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
            catch (Exception excep)
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
            catch (Exception excep)
            {
                HandleException(excep);
                return false;
            }
        }
        public override bool PerformServer()
        {
            try
            {
                ListaComenziDataSvc svc = new ListaComenziDataSvc();
                svc.UpdateDS(mDataSet);
                mDataSet.AcceptChanges();
                return true;
            }
            catch (Exception excep)
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
            catch (Exception excep)
            {
                HandleException(excep);
                return false;
            }
        }
        #endregion

        #region Private Methods
        private void HandleException(Exception excep)
        {
            throw excep;
        }
        #endregion
    }
}
