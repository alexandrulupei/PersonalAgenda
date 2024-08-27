using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CommonDataSets.GUI;
using GSBusFramework;

namespace Common_DT.Admin
{
    public partial class RolesDataSvc : DataService
    {
        #region Constructor
        public RolesDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }
        public RolesDataSvc(IContainer container)
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
            this.sqlTableName = "tblRoles";
            viewDataAdapters["tblRoles"] = sqlDataAdapter_tblRoles;
            viewDataAdapters["lnkRolesDeschidereBase"] = sqlDataAdapter_lnkRolesDeschidereBase;
            viewDataAdapters["lnkRolesNavigation"] = sqlDataAdapter_lnkRolesNavigation;
        }
        #endregion

        #region Public Methods
        public bool GetDeschideriActive(DataSet pDataSet, string pTableName, Guid pAplicatiiID)
        {
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pAplicatiiID", pAplicatiiID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            this.sqlTableName = pTableName;
            GetList(pDataSet, keyList, sqlDataAdapter_GetDeschideriActive);
            return true;
        }
        public bool GetWorkData(RolesDataSet pDataSet, Guid pAplicatiiID)
        {
            GetDeschideriActive(pDataSet, "tblDeschidereBase", pAplicatiiID);
            this.sqlTableName = "lnkRolesDeschidereBase";
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pAplicatiiID", pAplicatiiID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            GetList(pDataSet, keyList, sqlDataAdapter_GetRolesDeschidereBase);
            this.sqlTableName = "tblRoles";
            GetList(pDataSet, keyList, sqlDataAdapter_tblRoles);
            //this.sqlTableName = "tblDeschidereBase";
            //GetList(pDataSet, keyList, sqlDataAdapter_tblDeschidereBase);
            this.sqlTableName = "tblAplicatii";
            GetList(pDataSet, keyList, sqlDataAdapter_tblAplicatii);
            this.sqlTableName = "tblNavigation";
            GetList(pDataSet, keyList, sqlDataAdapter_GetNavigationByAppID);
            this.sqlTableName = "tblModul";
            GetList(pDataSet, keyList, sqlDataAdapter_GetModul);
            this.sqlTableName = "lnkRolesNavigation";
            GetList(pDataSet, sqlDataAdapter_lnkRolesNavigation);
            return true;
        }
        public bool UpdateDS(RolesDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion
    }
}
