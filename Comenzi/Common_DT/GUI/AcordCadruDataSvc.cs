using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GSBusFramework;
using CommonDataSets.GUI;
using System.Collections;

namespace Common_DT.GUI
{
    public partial class AcordCadruDataSvc : GSBusFramework.DataService
    {
        public AcordCadruDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public AcordCadruDataSvc(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Class Fields

        protected AdapterList viewDataAdapters = new AdapterList();

        #endregion

        #region Infrastructure Methods
        protected override void setupDataService()
        {
            this.sqlTableName = "tblACordCadru";
            viewDataAdapters["tblAcordCadru"] = sqlDataAdapter_tblAcordCadru;
            viewDataAdapters["tblAcordCadruDet"] = sqlDataAdapter_tblAcordCadruDet;
        }
        #endregion

        #region Pubic Methods
        public bool GetDate(AcordCadruDataSet pDataSet)
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
        public bool GetDet(AcordCadruDataSet pDataSet, Guid pID)
        {
            this.sqlTableName = "tblAcordCadruDet";
            IList keyList = new ArrayList();
            if (pID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pID", pID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            GetList(pDataSet, keyList, sqlDataAdapter_tblAcordCadruDet);
            return true;
        }
        public bool GetBase(AcordCadruDataSet pDataSet, Guid pID)
        {
            this.sqlTableName = "tblAcordCadru";
            IList keyList = new ArrayList();
            if (pID == Guid.Empty)
            {
                keyList.Add(new FilterInfo("@pID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            else
            {
                keyList.Add(new FilterInfo("@pID", pID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            }
            GetList(pDataSet, keyList, sqlDataAdapter_tblAcordCadru);
            return true;
        }
        public bool GetAcordCadruHome(AcordCadruDataSet pDataSet, DateTime pDataLucru)
        {
            this.sqlTableName = "tblAcordCadruHome";
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pDataLucru", pDataLucru, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            GetList(pDataSet, keyList, sqlDataAdapter_GetHome);
            return true;
        }
        public bool UpdateDS(AcordCadruDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion 
    }
}
