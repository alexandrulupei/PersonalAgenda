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
    public partial class DistribuiteLotDataSvc : DataService
    {
        #region Constructor
        public DistribuiteLotDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public DistribuiteLotDataSvc(IContainer container)
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
            this.sqlTableName = "tblDistribuireLot";
            viewDataAdapters["tblDistribuireLot"] = sqlDataAdapter_DistribuireLot;
            viewDataAdapters["tblDistribuireLotDet"] = sqlDataAdapter_DistibuireDet;
        }
        #endregion

        #region Public Methods
        public bool GetLotBase(DistribuireDataSet pDataSet, Guid pLotBaseID)
        {
            this.sqlTableName = "tblLotBase";
            IList keyList = new ArrayList();
            if (pLotBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pLotBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pLotBaseID", pLotBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }

            GetList(pDataSet, keyList, sqlDataAdapter_LotBase);
            return true;
        }
        public bool GetHome(DistribuireDataSet pDataSet, DateTime pDataLucru)
        {
            this.sqlTableName = "tblHome";
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pDataLucru", pDataLucru, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            GetList(pDataSet,keyList, sqlDataAdapter_GetHome);
            return true;
        }

        public bool GetDistribuire(DistribuireDataSet pDataSet, Guid pLotBaseID,Guid pCentruID)
        {
            this.sqlTableName = "tblDistribuireLotDetalii";
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
            GetList(pDataSet, keyList, sqlDataAdapter_DistribuireLotDetDetalii);
            return true;
        }

        public bool GetDate(DistribuireDataSet pDataSet)
        {
            this.sqlTableName = "tblCentru";
            GetList(pDataSet, sqlDataAdapter_GetCentru);

            this.sqlTableName = "tblLotBase";
            GetList(pDataSet, sqlDataAdapter_LotBase);
            this.sqlTableName = "tblDistribuireLot";
            GetList(pDataSet, sqlDataAdapter_DistribuireLot);
            this.sqlTableName = "tblDistribuireLotDet";
            GetList(pDataSet, sqlDataAdapter_DistibuireDet);
            return true;
        }

      

        public bool UpdateDS(DistribuireDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion
    }
}
