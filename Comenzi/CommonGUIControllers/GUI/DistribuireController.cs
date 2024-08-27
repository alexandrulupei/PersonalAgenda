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
    public class DistribuireController : Controller
    {
        #region Contructor
        public DistribuireController()
        {}
       #endregion
        
        #region Class Fields
      private DistribuireDataSet mDataSet;
      private  Guid mLotBaseID= Guid.Empty;
      private  Guid mCentruId= Guid.Empty;
      private bool mLoadDate = false;
      private DateTime mDataLucru;
      #endregion
        
        #region Properties
      public override DataSet DataSet
      {
          get
          { return mDataSet; }
          set
          { mDataSet = (DistribuireDataSet)value; }
      }

      public Guid LotBaseID
      {
          get { return mLotBaseID; }
          set { mLotBaseID = (Guid) value; }
      }
      public Guid CentruID
      {
          get { return mCentruId; }
          set { mCentruId = (Guid)value; }
      }
      public bool LoadDate
      {
          get { return mLoadDate; }
          set { mLoadDate = value; }
      }
      public DateTime DataLucru
      {
          get { return mDataLucru; }
          set { mDataLucru =(DateTime) value; }
      }
      #endregion

        #region Initialization Methods
      public override void InitializeClient()
      {
          try
          {
              mDataSet = new DistribuireDataSet();
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
              DistribuiteLotDataSvc mDataSvc = new DistribuiteLotDataSvc();
              if (mLoadDate)
              {
                  //mDataSvc.GetLotBase(mDataSet, mLotBaseID);
                  mDataSvc.GetDistribuire(mDataSet, mLotBaseID,mCentruId);
              }
              else
                  mDataSvc.GetHome(mDataSet, mDataLucru);
              LookupTableManagement.LookupTableBusSvc lookupSvc = new LookupTableManagement.LookupTableBusSvc();
              lookupSvc.GetLookupList("tbxCotaTVA", mDataSet);
              mDataSvc.GetDate(mDataSet);
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
              DistribuiteLotDataSvc svc = new DistribuiteLotDataSvc();
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
