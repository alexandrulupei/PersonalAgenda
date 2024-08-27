using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CommonDataSets.Liste;
using GSBusFramework;

namespace Common_DT.Liste
{
    public partial class NirDataSvc : DataService
    {
        #region Constructor
        public NirDataSvc()
        {
            InitializeComponent();
        }

        public NirDataSvc(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
       #endregion
        #region Class Fields

        protected AdapterList viewDataAdapters = new AdapterList();

        #endregion
        #region Public Methods
        public bool GetNirByComanda(NirDataSet pDataSet, Guid pComandaBaseID)
        {
            this.sqlTableName = "tblReceptieComandaBase";
            IList keyList = new ArrayList();
            if (pComandaBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", pComandaBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            return GetList(pDataSet, keyList, sqlDataAdapter_GetNirByComanda);
        }

        public bool GetDateNir(NirDataSet pDataSet, Guid pReceptieBaseID)
        {
            this.sqlTableName = "tblNir";
            IList keyList = new ArrayList();
            if (pReceptieBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pReceptieBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pReceptieBaseID", pReceptieBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            return GetList(pDataSet, keyList, sqlDataAdapter_tblDateNir);
        }

        public bool GetPersoane(NirDataSet pDataSet, Guid pCentruID)
        {
            this.sqlTableName = "tblPersoane";
            IList keyList = new ArrayList();
            if (pCentruID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pCentruID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pCentruID", pCentruID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            return GetList(pDataSet, keyList, sqlDataAdapter_GetPersoane);
        }
        public bool UpdateDS(NirDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion



    }
}
