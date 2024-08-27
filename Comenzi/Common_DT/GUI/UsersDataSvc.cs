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
    public partial class UsersDataSvc : DataService
    {
        #region Constructor
        public UsersDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }
        public UsersDataSvc(IContainer container)
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
            this.sqlTableName = "tblUsers";
            viewDataAdapters["tblUsers"] = sqlDataAdapterUsers;
            viewDataAdapters["lnkUsersDeschidere"] = sqlDataAdapter_lnkUsersCentru;
        }
        #endregion

        #region Public Methods

        public bool GetDeschideri(UsersDataSet pDataSet, Guid pAplicatiiID)
        {
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pAplicatiiID", pAplicatiiID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            this.sqlTableName = "tblDeschidereBase";
            GetList(pDataSet, keyList, sqlDataAdapter_get_tblUnitate);
            this.sqlTableName = "lnkUsersDeschidere";
            GetList(pDataSet, sqlDataAdapter_lnkUsersCentru);
            //this.sqlTableName = "tblRoles";
            //GetList(pDataSet, keyList, sqlDataAdapter_get_tblRoles);
            return true;
        }


        public bool UpdateDS(UsersDataSet userDataSet)
        {
            if (!UpdateDS(userDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion
    }
}
