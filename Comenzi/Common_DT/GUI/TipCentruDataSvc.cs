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
    public partial class TipCentruDataSvc : DataService
    {
        #region Constructor
        public TipCentruDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public TipCentruDataSvc(IContainer container)
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
            this.sqlTableName = "tbxTipCentru";
            viewDataAdapters["tbxTipCentru"] = sqlDataAdapter_TipCentru;
        }
        #endregion

        #region Public Methods
        public bool GetTipCentru(Nomenclatoare pDataSet)
        {
            this.sqlTableName = "tbxTipCentru";
            GetList(pDataSet, sqlDataAdapter_TipCentru);
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
