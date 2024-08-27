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
    public partial class ProduseDataSvc : DataService
    {
        #region Constructor

        public ProduseDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public ProduseDataSvc(IContainer container)
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
            this.sqlTableName = "tblProduse";
            viewDataAdapters["tblProduse"] = sqlDataAdapter_GetProduse;
        }
        #endregion

        #region Public Methods
        public bool GetProduse(Nomenclatoare pDataSet)
        {
            this.sqlTableName = "tblProduse";
            GetList(pDataSet, sqlDataAdapter_GetProduse);
            return true;
        }
        public bool GetCotaTva(Nomenclatoare pDataSet)
        {
            this.sqlTableName = "tbxCotaTVA";
            GetList(pDataSet, sqlDataAdapter_CotaTva);
            return true;
        }
        public bool Get_SimbolFromTable(Nomenclatoare userDataSet, String ptableName, String ptableColumn, String pFiltru)
        {
            this.sqlTableName = "tblMaxSimbol";
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@tableName", ptableName, FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL_NOESCAPE));
            keyList.Add(new FilterInfo("@tableColumn", ptableColumn, FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL_NOESCAPE));
        keyList.Add(new FilterInfo("@Filtru", pFiltru, FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL_NOESCAPE));
            return GetList(userDataSet, keyList, sqlDataAdapter_GetSimbolFromTable);
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
