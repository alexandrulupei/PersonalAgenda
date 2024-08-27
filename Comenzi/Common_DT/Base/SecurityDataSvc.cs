using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CommonDataSets.Base;
using GSBusFramework;

namespace Common_DT.Base
{
    public partial class SecurityDataSvc : DataService
    {
        #region Constructor
        public SecurityDataSvc()
        {
            InitializeComponent();
            setupDataService();
        }
        public SecurityDataSvc(IContainer container)
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
            viewDataAdapters["tblUserRights"] = sqlDataAdapter_tblUserRights;
            viewDataAdapters["lnkUsersDeschidere"] = sqlDataAdapter_lnkUsersDeschidere;
            viewDataAdapters["tblDeschidereBase"] = sqlDataAdapter_tblDeschidereBase;
        }
        #endregion

        #region Private Methods

        private object IfEmpty(Guid value)
        {
            if (value.Equals(Guid.Empty)) return DBNull.Value;
            return value;
        }

        private object IfEmpty(String value)
        {
            if (value.Equals(String.Empty)) return DBNull.Value;
            return value;
        }

        private string GetSirRolesID(Guid pUsersID)
        {
            string pRoles = "(";
            DataSet tempDS = new DataSet();
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pUsersID", pUsersID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            GetList(tempDS, keyList, sqlDataAdapter_GetRolesByUsersID);
            int i = 0;
            if (tempDS != null)
            {
                foreach (DataRow dr in tempDS.Tables[0].Rows)
                {
                    if (i > 0)
                        pRoles += ",";
                    pRoles += "'" + dr["RolesID"].ToString() + "'";
                    i++;
                }
            }
            if (i == 0)
                pRoles = string.Empty;
            else
                pRoles += ")";
            return pRoles;
        }
        #endregion

        #region Public Methods
        public bool GetWorkData(SecurityDataSet pDataSet, Guid pAplicatiiID, Guid pUsersID)
        {
            string pRolesID = GetSirRolesID(pUsersID);

            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pAplicatiiID", pAplicatiiID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            keyList.Add(new FilterInfo("@pUsersID", IfEmpty(pUsersID), FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            keyList.Add(new FilterInfo("@pRolesID", IfEmpty(pRolesID), FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));


            this.sqlTableName = "tblUserRights";
            GetList(pDataSet, keyList, sqlDataAdapter_tblUserRights);
            this.sqlTableName = "tblUsers";
            GetList(pDataSet, sqlDataAdapter_tblUsers);
            this.sqlTableName = "tblModul";
            GetList(pDataSet, sqlDataAdapter_GetModule);
            this.sqlTableName = "tblDeschidereDet";
            GetList(pDataSet, sqlDataAdapter_GetDeschidereDet);
            this.sqlTableName = "tblRoles";
            if (pRolesID != string.Empty)
                sqlDataAdapter_tblRoles.SelectCommand.CommandText += " where CodIntern = '01' OR ID in " + pRolesID;
            GetList(pDataSet, sqlDataAdapter_tblRoles);
            this.sqlTableName = "lnkRolesNavigation";
            if (pRolesID != string.Empty)
                sqlDataAdapter_GetRolesNavigationByApplicationID.SelectCommand.CommandText += " and lnkRolesNavigation.RolesID in " + pRolesID;
            GetList(pDataSet, keyList, sqlDataAdapter_GetRolesNavigationByApplicationID);
            this.sqlTableName = "lnkRolesDeschidereBase";
            if (pRolesID != string.Empty)
                sqlDataAdapter_GetRolesDeschidereBase.SelectCommand.CommandText += " and lnkRolesDeschidereBase.RolesID in " + pRolesID;
            GetList(pDataSet, keyList, sqlDataAdapter_GetRolesDeschidereBase);
            this.sqlTableName = "tblNavigation";
            GetList(pDataSet, keyList, sqlDataAdapter_GetNavigationByApplicationID);
            this.sqlTableName = "tblDeschidereBase";
            GetList(pDataSet, keyList, sqlDataAdapter_tblDeschidereBase);
            this.sqlTableName = "lnkUsersDeschidere";
            GetList(pDataSet, sqlDataAdapter_lnkUsersDeschidere);
            return true;
        }

        public bool GetActiveInstitutiiByDeschidereID(SecurityDataSet pDataSet, Guid pDeschidereBaseID)
        {
            IList keyList = new ArrayList();
            keyList.Add(new FilterInfo("@pDeschidereBaseID", pDeschidereBaseID, FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
            this.sqlTableName = "tblCentru";
            GetList(pDataSet, keyList, sqlDataAdapter_tblCentru);
            return true;
        }

        public bool UpdateDS(SecurityDataSet pDataSet)
        {
            if (!UpdateDS(pDataSet, viewDataAdapters))
                return false;
            return true;
        }
        #endregion 
    }
}
