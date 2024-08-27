using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using CommonDataSets.GUI;
using CommonDataSets.Liste;
using Common_DT.Liste;
using DevExpress.XtraGrid.Helpers;
using GSFramework;

namespace CommonGUIControllers.Liste
{
   public class NirController : Controller
   {

       #region Constructor

       public NirController()
       {

       }

       #endregion

       #region Class Fields

       private NirDataSet mDataSet;
       private Guid mComandaBaseID;
       private Guid mReceptieBaseID;
       private bool mLoadDate = false;
       private Guid mCentruID;
       #endregion

       #region Public Proprietes
       public override DataSet DataSet
       {
           get
           { return mDataSet; }
           set
           { mDataSet = (NirDataSet)value; }
       }

       public Guid ComandaBaseID
       {
           get
           {
               return mComandaBaseID;
                   
           }
           set { mComandaBaseID = (Guid) value; }
       }

       public Guid ReceptieBaseID
       {
           get
           {
               return mReceptieBaseID;

           }
           set { mReceptieBaseID = (Guid)value; }
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
               mDataSet = new NirDataSet();
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
               NirDataSvc mDataSvc = new NirDataSvc();
               if (mLoadDate)
               {
                   mDataSvc.GetDateNir(mDataSet, mReceptieBaseID);
                   mDataSvc.GetPersoane(mDataSet, mCentruID);
               }
               else
               {
                   mDataSvc.GetNirByComanda(mDataSet, mComandaBaseID);
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
               NirDataSvc svc = new NirDataSvc();
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
