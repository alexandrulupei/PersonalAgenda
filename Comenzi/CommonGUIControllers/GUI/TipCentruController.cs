﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CommonDataSets.GUI;
using Common_DT.GUI;
using GSFramework;

namespace CommonGUIControllers.GUI
{
    public  class TipCentruController : Controller
    {

        #region Constructor

        public TipCentruController()
        {
        }

        #endregion

        #region Class Fields
        private Nomenclatoare mDataSet;
        #endregion

        #region Properties
        public override DataSet DataSet
        {
            get
            { return mDataSet; }
            set
            { mDataSet = (Nomenclatoare)value; }
        }

       
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
                TipCentruDataSvc mDataSvc = new TipCentruDataSvc();
                mDataSvc.GetTipCentru(mDataSet);
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
                TipCentruDataSvc svc = new TipCentruDataSvc();
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
