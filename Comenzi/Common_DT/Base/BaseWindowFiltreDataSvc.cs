using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CommonDataSets;
using CommonDataSets.Base;
using GSBusFramework;

namespace Common_DT.Base
{
    public partial class BaseWindowFiltreDataSvc : DataService
    {
        #region Constructor
        public BaseWindowFiltreDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public BaseWindowFiltreDataSvc(IContainer container)
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
            this.sqlTableName = "tblListeBase";
            viewDataAdapters["tblListeBase"] = sqlDataAdapterListeBase;
            viewDataAdapters["tblListeDet"] = sqlDataAdapterListeDet;
        }
        #endregion

        #region Public Methods
        public bool GetListe(BaseWindowFiltreDataSet pDataSet, string pAssemblyName, Guid pCentruID)
        {
            this.sqlTableName = "tblListeBase";
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pAssemblyName", pAssemblyName, FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL));
            GetList(pDataSet, keyList, sqlDataAdapterListeBase);
            if (pDataSet.tblListeBase.Count > 0)
            {
                DataRow dr = pDataSet.tblListeBase.Rows[0];
                keyList.Clear();
                this.sqlTableName = "tblListeDet";
                keyList.Add(new FilterInfo("@pListeBaseID", dr[0], FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
                if (pCentruID != Guid.Empty)
                    keyList.Add(new FilterInfo("@pCentruID", pCentruID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
                else
                    keyList.Add(new FilterInfo("@pCentruID", DBNull.Value, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
                GetList(pDataSet, keyList, sqlDataAdapterListeDet);
            }
            return true;
        }
        public bool UpdateDS(BaseWindowFiltreDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion
    }
}
