using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CommonDataSets.GUI;
using GSBusFramework;

namespace Common_DT.GUI
{
    public partial class CoduriCPVDataSvc : DataService
    {

        #region Constructor
        public CoduriCPVDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public CoduriCPVDataSvc(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region Class Fields

        protected AdapterList viewDataAdapters = new AdapterList();

        #endregion

        #region Infrastructure Methods
        protected override void setupDataService()
        {
            this.sqlTableName = "tblCPVCodes";
            viewDataAdapters["tblCPVCodes"] = sqlDataAdapter_GetCoduriCPV;
        }
        #endregion

        #region Public Methods
        public bool GetCodCPV(Nomenclatoare pDataSet)
        {
            this.sqlTableName = "tblCPVCodes";
            GetList(pDataSet, sqlDataAdapter_GetCoduriCPV);
            return true;
        }
        public bool UpdateDS(Nomenclatoare pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion
    }
}
