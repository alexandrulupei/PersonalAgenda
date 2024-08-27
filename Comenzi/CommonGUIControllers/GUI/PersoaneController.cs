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
   public class PersoaneController : Controller
    {
        #region Contructor
       public PersoaneController()
      {}
       #endregion

      #region Class Fields
      private PersoaneDataSet mDataSet;
      private Guid mCentruID = Guid.Empty;
    
      #endregion


      #region Properties
      public override DataSet DataSet
      {
          get
          { return mDataSet; }
          set
          { mDataSet = (PersoaneDataSet)value; }
      }


      public Guid CentruID
      {
          get { return mCentruID; }
          set { mCentruID = (Guid)value; }
      }

    
      #endregion

      #region Initialization Methods
      public override void InitializeClient()
      {
          try
          {
              mDataSet = new PersoaneDataSet();
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
            PersoaneDataSvc mDataSvc = new PersoaneDataSvc();
            mDataSvc.GetDate(mDataSet, mCentruID);
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
              PersoaneDataSvc svc = new PersoaneDataSvc();
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
