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
    public partial class LotDataSvc : DataService
    {

        #region Constructor
        public LotDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public LotDataSvc(IContainer container)
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
            this.sqlTableName = "tblLotBase";
            viewDataAdapters["tblLotBase"] = sqlDataAdapter_LotBase;
            viewDataAdapters["tblLotDet"] = sqlDataAdapter_LotDet;
        }
        #endregion

        #region Public Methods
        public bool GetLotBase(LotDataSet pDataSet, Guid pLotBaseID)
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
        
            GetList(pDataSet, keyList,sqlDataAdapter_LotBase);
            return true;
        }
        public bool GetLotHome(LotDataSet pDataSet, DateTime pDataLucru)
        {
            this.sqlTableName = "tblLotHome";
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pDataLucru", pDataLucru, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            GetList(pDataSet,keyList, sqlDataAdapter_GetHome);
            return true;
        }

        public bool GetLotDet(LotDataSet pDataSet, Guid pLotBaseID)
        {
            this.sqlTableName = "tblLotDet";
            IList keyList = new ArrayList();
            if (pLotBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pLotBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pLotBaseID", pLotBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            GetList(pDataSet, keyList,sqlDataAdapter_LotDet);
            return true;
        }

        public bool GetDate(LotDataSet pDataSet)
        {
            this.sqlTableName = "tblPartener";
            GetList(pDataSet, sqlDataAdapter_GetPartener);

            this.sqlTableName = "tblCPVCodes";
            GetList(pDataSet, sqlDataAdapter_GetCodCPV);

            this.sqlTableName = "tblProduse";
            GetList(pDataSet, sqlDataAdapter_GetProduse);
            this.sqlTableName = "tbxTipCentru";
            GetList(pDataSet, sqlDataAdapter_tbxTipCentru);
            return true;
        }

        public bool GetAcordCadru(LotDataSet pDataSet, DateTime pDataLucru)
        {
            this.sqlTableName = "tblAcordCadru";
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pDataLucru", pDataLucru, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));

            return GetList(pDataSet, keyList, sqlDataAdapter_GetAcordBase);
        }
        public bool GetAcordDetalii(LotDataSet pDataSet,Guid @pLotBaseID, Guid @pAcordCadruID) 
        {
            this.sqlTableName = "tblLotDet";
            IList keyList = new ArrayList();
            if (pLotBaseID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pLotBaseID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pLotBaseID", pLotBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            if (pAcordCadruID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pAcordCadruID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pAcordCadruID", pAcordCadruID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            return GetList(pDataSet, keyList, sqlDataAdapterGetAcordDetalii);
        }
        public bool UpdateDS(LotDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion

    }
}
