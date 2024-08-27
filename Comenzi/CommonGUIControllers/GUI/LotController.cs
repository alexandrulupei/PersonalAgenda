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
  public  class LotController : Controller
  {

      #region Contructor
      public  LotController()
      {}
       #endregion

   

      #region Class Fields
      private LotDataSet mDataSet;
      private  Guid mLotBaseID= Guid.Empty;
      private Guid mAcordID = Guid.Empty;
      private bool mLoadDate = false;
      private DateTime mDataLucru;
      private bool mLoadAcord = false;
      private bool mLoadDateAcord=false;
      #endregion


      #region Properties
      public override DataSet DataSet
      {
          get
          { return mDataSet; }
          set
          { mDataSet = (LotDataSet)value; }
      }

      public Guid LotBaseID
      {
          get { return mLotBaseID; }
          set { mLotBaseID = (Guid) value; }
      }
      public Guid AcordID
      {
          get { return mAcordID; }
          set { mAcordID = (Guid)value; }
      }
      public bool LoadDate
      {
          get { return mLoadDate; }
          set { mLoadDate = value; }
      }
      public DateTime Data
      {
          get { return mDataLucru; }
      
          set { mDataLucru = value; }
      }
      public bool LoadDateAcord
      {
          get { return mLoadDate; }
          set { mLoadDateAcord = value; }
      }
      public bool LoadAcord
      {
          get { return mLoadAcord; }
          set { mLoadAcord= value; }
      }
      #endregion

      #region Initialization Methods
      public override void InitializeClient()
      {
          try
          {
              mDataSet = new LotDataSet();
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
              LotDataSvc mDataSvc = new LotDataSvc();

              if (mLoadAcord)
              {
                  mDataSet.tblAcordCadru.Clear();
                  mDataSvc.GetAcordCadru(mDataSet, mDataLucru);
                  mLoadAcord = false;
              }
              else if (mLoadDateAcord)
              {
                  mDataSvc.GetAcordDetalii(mDataSet, mLotBaseID, mAcordID);
              }
              else
              if (mLoadDate)
              {
                  mDataSvc.GetLotBase(mDataSet, mLotBaseID);
                  mDataSvc.GetLotDet(mDataSet, mLotBaseID);
                  mDataSvc.GetAcordCadru(mDataSet, mDataLucru);
              }
              else mDataSvc.GetLotHome(mDataSet,mDataLucru);
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
              LotDataSvc svc = new LotDataSvc();
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
