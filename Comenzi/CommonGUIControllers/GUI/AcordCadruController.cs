using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDataSets.GUI;
using Common_DT.GUI;
using GSFramework;
using System.Data;
namespace CommonGUIControllers.GUI
{
    public class AcordCadruController: Controller
    {
      #region Contructor
        public AcordCadruController()
        { }
       #endregion

      #region Class Fields
      private AcordCadruDataSet mDataSet;
      private  Guid mAcordCadruBaseID= Guid.Empty;
      private bool mLoadDate = false;
      private DateTime mDataLucru;
      #endregion


      #region Properties
      public override DataSet DataSet
      {
          get
          { return mDataSet; }
          set
          { mDataSet = (AcordCadruDataSet)value; }
      }

      public Guid AcordCadruBaseID
      {
          get { return mAcordCadruBaseID; }
          set { mAcordCadruBaseID = (Guid) value; }
      }
      public bool LoadDate
      {
          get { return mLoadDate; }
          set { mLoadDate = value; }
      }
      public DateTime DataLucru
      {
          get { return mDataLucru; }
          set { mDataLucru = (DateTime) value; }
      }
      #endregion

      #region Initialization Methods
      public override void InitializeClient()
      {
          try
          {
              mDataSet = new AcordCadruDataSet();
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
              AcordCadruDataSvc mDataSvc = new AcordCadruDataSvc();
              if (mLoadDate)
              {
                  mDataSvc.GetBase(mDataSet, mAcordCadruBaseID);
                  mDataSvc.GetDet(mDataSet, mAcordCadruBaseID);
              }
              else
                  mDataSvc.GetAcordCadruHome(mDataSet, mDataLucru);
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
              AcordCadruDataSvc svc = new AcordCadruDataSvc();
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
