using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GSBusFramework;
using CommonDataSets.GUI;

namespace Common_DT.GUI
{
    public partial class ResetSecurityDataSvc : DataService
    {
        #region Constructors
        public ResetSecurityDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }

        public ResetSecurityDataSvc(IContainer container)
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
            this.sqlTableName = "tblUserRights";
            //viewDataAdapters["tblUserRights"] = sqlDataAdapter_tblUserRights;
        }
        #endregion

        #region Public Methods
        public bool GetUsers(ResetSecurityDataSet pDataSet)
        {
            this.sqlTableName = "tblUsers";
            GetList(pDataSet, sqlDataAdapter_tblUsers);
            this.sqlTableName = "lnkUsersDeschidere";
            GetList(pDataSet, sqlDataAdapter_lnkUsersCentru);

            return true;
        }

        public bool GetUserRights(ResetSecurityDataSet userDataSet, Guid pUsersID, Guid pAplicatiiID)
        {
            this.sqlTableName = "tblUserRights";
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pUsersID", pUsersID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            keyList.Add(new FilterInfo("@pAplicatiiID", pAplicatiiID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));

            //return GetList(userDataSet, keyList, sqlDataAdapter_tblUserRights);
            return true;
        }

        public bool UpdateDS( ResetSecurityDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion
    }
}
