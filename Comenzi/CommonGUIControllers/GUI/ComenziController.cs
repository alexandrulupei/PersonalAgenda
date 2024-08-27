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
    public  class ComenziController: Controller
    {
      #region Contructor
        public ComenziController()
      {}
       #endregion

      #region Class Fields
      private ComenziDataSet mDataSet;
      private  Guid mLotBaseID= Guid.Empty;
      private Guid mCentruID = Guid.Empty;
      private bool mLoadDate = false;
      private bool mReceptie = false;
      private  Guid mComandaBaseID = Guid.Empty;
      private bool mIsModifica = false;
      private DateTime mDataLucru = DateTime.Now;
      #endregion


      #region Properties
      public override DataSet DataSet
      {
          get
          { return mDataSet; }
          set
          { mDataSet = (ComenziDataSet)value; }
      }

      public Guid LotBaseID
      {
          get { return mLotBaseID; }
          set { mLotBaseID = (Guid) value; }
      }

      public Guid CentruID
      {
          get { return mCentruID; }
          set { mCentruID = (Guid)value; }
      }

      public Guid ComadaBaseID
      {
          get { return mComandaBaseID; }
          set { mComandaBaseID = (Guid)value; }
      }
      public bool LoadDate
      {
          get { return mLoadDate; }
          set { mLoadDate = value; }
      }
      public bool Receptie
      {
          get { return mReceptie; }
          set { mReceptie = value; }
      }
      public bool Modifica
      {
          get { return mIsModifica; }
          set { mIsModifica = value; }
      }
      public DateTime Data
      {
          get { return mDataLucru; }
          set { mDataLucru = value; }
      }
      #endregion

      #region Initialization Methods
      public override void InitializeClient()
      {
          try
          {
              mDataSet = new ComenziDataSet();
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
              ComenziDataSvc mDataSvc = new ComenziDataSvc();
           
              if (mLoadDate)
              {
                  mDataSvc.GetDistribuire(mDataSet, mLotBaseID, mCentruID, mComandaBaseID);
                  mLoadDate = false;

              }
               else if (mReceptie)
              {
                  mDataSvc.GetDateReceptie(mDataSet, mComandaBaseID);
                  mReceptie = false;
              }
              else
        
              {
                  mDataSvc.GetDate(mDataSet, mCentruID,mDataLucru);
              }
              if (mIsModifica)
              {
                  mDataSvc.GetDistribuire(mDataSet, mLotBaseID, mCentruID, mComandaBaseID);
                  mDataSvc.Comenzi(mDataSet, mComandaBaseID);
                  mIsModifica = false;
              }
              LookupTableManagement.LookupTableBusSvc lookupSvc = new LookupTableManagement.LookupTableBusSvc();
              lookupSvc.GetLookupList("tbxCotaTVA", mDataSet);
             
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
              ComenziDataSvc svc = new ComenziDataSvc();
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
