using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSFramework;
using CommonDataSets.GUI;
using System.Data;
using Common_DT.GUI;

namespace CommonGUIControllers.GUI
{
    public class TransferController : Controller
    {
       #region Contructor
        public TransferController()
      {}
       #endregion

      #region Class Fields
      private TransferDataSet mDataSet;
      private  Guid mLotBaseID= Guid.Empty;
      private Guid mCentruID = Guid.Empty;
      private bool mLoadDate = false;
      #endregion


      #region Properties
      public override DataSet DataSet
      {
          get
          { return mDataSet; }
          set
          { mDataSet = (TransferDataSet)value; }
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

      public bool LoadDate
      {
          get { return mLoadDate; }
          set { mLoadDate = (bool)value; }
      }
      #endregion

      #region Initialization Methods
      public override void InitializeClient()
      {
          try
          {
              mDataSet = new TransferDataSet();
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
              TransferDataSvc mDataSvc = new TransferDataSvc();
              if (mLoadDate)
              {
                  mDataSvc.GetDate(mDataSet, mLotBaseID, mCentruID);
              }
              else
              {
                  LookupTableManagement.LookupTableBusSvc lookupSvc = new LookupTableManagement.LookupTableBusSvc();
                  lookupSvc.GetLookupList("tbxTipCentru", mDataSet);
                  mDataSvc.GetCentru(mDataSet);
              }
             
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
              TransferDataSvc svc = new TransferDataSvc();
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
