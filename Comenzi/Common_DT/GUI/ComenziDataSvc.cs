using GSBusFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CommonDataSets.GUI;

namespace Common_DT.GUI
{
    public partial class ComenziDataSvc : DataService
    {
        #region Constructor

        public ComenziDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public ComenziDataSvc(IContainer container)
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
            this.sqlTableName = "tblComandaBase";
            viewDataAdapters["tblComandaBase"] = sqlDataAdapter_GetComandaBase;
            viewDataAdapters["tblComandaDet"] = sqlDataAdapter_GetComandaDet;
            viewDataAdapters["tblReceptieComandaBase"] = sqlDataAdapter_tblReceptieComenziBase;
            viewDataAdapters["tblReceptieComandaDet"] = sqlDataAdapter_tblReceptieComandaDet;
        }
        #endregion

        #region Public Methods

        public bool GetHome(ComenziDataSet pDataSet, DateTime pDataLucru)
        {
            this.sqlTableName = "tblHome";
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pDataLucru", pDataLucru, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            GetList(pDataSet, keyList, sqlDataAdapter_GetHome);
            return true;
        }

        public bool GetDistribuire(ComenziDataSet pDataSet, Guid pLotBaseID, Guid pCentruId,Guid pComandaBaseID)
        {
            this.sqlTableName = "tblDetaliiComanda";
            IList keyList = new ArrayList();
            if (pLotBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pLotBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pLotBaseID", pLotBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            if (pCentruId == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pCentruId", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pCentruId", pCentruId, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            if (pComandaBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", pComandaBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            GetList(pDataSet, keyList, sqlDataAdapter_DetaliiComanda);
            return true;
        }

        public bool GetDate(ComenziDataSet pDataSet, Guid pCentruId,DateTime pDataLucru)
        {

            this.sqlTableName = "tblHome";
            IList keyList = new ArrayList();
            if (pCentruId == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pCentruId", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pCentruId", pCentruId, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            keyList.Add(new FilterInfo("@pDataLucru", pDataLucru, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            GetList(pDataSet,keyList, sqlDataAdapter_GetHome);

            this.sqlTableName = "tblProdusComandat";
            this.GetList(pDataSet, keyList, sqlDataAdapter_getProduseComandate);

           
          
            this.sqlTableName = "tblLotBase";
            GetList(pDataSet, keyList, sqlDataAdapter_GetLot);

         
    


            return true;
        }

        public bool Comenzi(ComenziDataSet pDataSet,   Guid pComandaBaseID)
        {
            IList keyList = new ArrayList();
            if (pComandaBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", pComandaBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            this.sqlTableName = "tblComandaBase";
            GetList(pDataSet, keyList, sqlDataAdapter_GetComandaBase);
            this.sqlTableName = "tblComandaDet";
            GetList(pDataSet, keyList, sqlDataAdapter_GetComandaDet);
            return true;
        }

        public bool GetDateReceptie(ComenziDataSet pDataSet, Guid pComandaBaseID)
        {
            this.sqlTableName = "tblReceptieHome";
            IList keyList = new ArrayList();
            if (pComandaBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", pComandaBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            return  GetList(pDataSet, keyList, sqlDataAdapter_getReceptii);
        }

        public bool GetNirComanda(ComenziDataSet pDataSet, Guid pComandaBaseID)
        {
            this.sqlTableName = "tblNiruri";
            IList keyList = new ArrayList();
            if (pComandaBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pComandaBaseID", pComandaBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            return GetList(pDataSet, keyList, sqlDataAdapter_GetNirComanda);
        }

        public bool UpdateDS(ComenziDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion
    }
}
