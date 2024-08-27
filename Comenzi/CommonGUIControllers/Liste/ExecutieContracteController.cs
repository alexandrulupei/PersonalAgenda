using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CommonDataSets.Liste;
using Common_DT.Liste;
using GSFramework;

namespace CommonGUIControllers.Liste
{
  public  class ExecutieContracteController : Controller
    {
        #region Constructor
      public ExecutieContracteController()
       {

       }

       #endregion

       #region Class Fields

       private ExecutieContracteDataSet mDataSet;
       private Guid mLotBaseID;
       private bool mLoadDate = false;
       private Guid mCentruID;
       #endregion

       #region Public Proprietes
       public override DataSet DataSet
       {
           get
           { return mDataSet; }
           set
           { mDataSet = (ExecutieContracteDataSet)value; }
       }

       public Guid LotBaseID
       {
           get
           {
               return mLotBaseID;
                   
           }
           set { mLotBaseID = (Guid) value; }
       }
      
       public Guid CentruID
       {
           get
           {
               return mCentruID;

           }
           set { mCentruID = (Guid)value; }
       }
       public bool LoadDate
       {
           get
           {
               return mLoadDate;

           }
           set { mLoadDate = (bool)value; }
       }
       #endregion

       #region Initialization Methods
       public override void InitializeClient()
       {
           try
           {
               mDataSet = new ExecutieContracteDataSet();
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
               ExecutieContracteDataSvc mDataSvc = new ExecutieContracteDataSvc();
               if (mLoadDate)
               {
                   mDataSvc.GetLista(mDataSet, mLotBaseID, mCentruID);

               }
               else
               {
                   mDataSvc.GetNomenclatoare(mDataSet);
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
               ExecutieContracteDataSvc svc = new ExecutieContracteDataSvc();
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
