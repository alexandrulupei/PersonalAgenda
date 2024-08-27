using CommonDataSets.GUI;
using GSBusFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Common_DT.GUI
{
    public partial class PartenerDataSvc : DataService
    {
        #region Constructor
        public PartenerDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public PartenerDataSvc(IContainer container)
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
            this.sqlTableName = "tblPartener";
            viewDataAdapters["tblPartener"] = sqlDataAdapter_GetParteneri;
        }
        #endregion

        #region Public Methods
        public bool GetPartener(Nomenclatoare pDataSet)
        {
            this.sqlTableName = "tblPartener";
            GetList(pDataSet, sqlDataAdapter_GetParteneri);
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
