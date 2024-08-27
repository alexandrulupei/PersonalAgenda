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
    public partial class ExecutieContracteDataSvc : DataService
    {
        #region Constructor
        public ExecutieContracteDataSvc()
        {
            InitializeComponent();
        }

        public ExecutieContracteDataSvc(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region Class Fields

        protected AdapterList viewDataAdapters = new AdapterList();

        #endregion

        #region Public Methods

        public bool GetLista(ExecutieContracteDataSet pDataSet, Guid pLotBaseID, Guid pCentruID)
        {
            this.sqlTableName = "tblLista";
            IList keyList = new ArrayList();
            if (pLotBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pLotBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pLotBaseID", pLotBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }

            if (pCentruID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pCentruID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pCentruID", pCentruID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            GetList(pDataSet, keyList, sqlDataAdapter_GetLista);
            this.sqlTableName = "tblListaProcent";
            GetList(pDataSet, keyList, sqlDataAdapter_GetProcent);
            return true;
        }

        public bool GetNomenclatoare(ExecutieContracteDataSet pDataSet)
        {

            this.sqlTableName = "tblCentru";
            GetList(pDataSet, sqlDataAdapter_GetCentru);
            this.sqlTableName = "tblLotBase";
            GetList(pDataSet, sqlDataAdapter_GetLot);
            return true;
        }

        public bool UpdateDS(ExecutieContracteDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }

        #endregion
    }
}
