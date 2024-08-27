using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CommonDataSets.GUI;
using GSBusFramework;

namespace Common_DT.GUI
{
    public partial class PersoaneDataSvc : DataService
    {

        #region Constructor

        public PersoaneDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public PersoaneDataSvc(IContainer container)
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
            this.sqlTableName = "tblPersoane";
            viewDataAdapters["tblPersoane"] = sqlDataAdapter_Persoane;
            viewDataAdapters["lnkPersoanaTipPersoana"] = sqlDataAdapter_lnkPersoanaTipPersoana;
        }
        #endregion


        #region Public Methods
        public bool GetDate(PersoaneDataSet pDataSet, Guid pCentruId)
        {

            this.sqlTableName = "tblPersoane";
            IList keyList = new ArrayList();
            if (pCentruId == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pCentruId", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pCentruId", pCentruId, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            GetList(pDataSet, keyList, sqlDataAdapter_Persoane);

            this.sqlTableName = "lnkPersoanaTipPersoana";
            this.GetList(pDataSet, keyList, sqlDataAdapter_lnkPersoanaTipPersoana);

            this.sqlTableName = "tbxTipPersoana";
            this.GetList(pDataSet, sqlDataAdapter_TipPersoana);
            return true;
        }

        public bool UpdateDS(PersoaneDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }

        #endregion


    }
}
