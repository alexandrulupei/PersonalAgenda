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
    public partial class CentreDataSvc : DataService
    {
        #region Constructor
        public CentreDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public CentreDataSvc(IContainer container)
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
            this.sqlTableName = "tblCentru";
            viewDataAdapters["tblCentru"] = sqlDataAdapter_GetCentre;
        }
        #endregion

        #region Public Methods
        public bool GetCentre(Nomenclatoare pDataSet)
        {
            this.sqlTableName = "tblCentru";
            GetList(pDataSet, sqlDataAdapter_GetCentre);
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
