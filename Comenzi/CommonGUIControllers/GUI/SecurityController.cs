using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using CommonDataSets.Base;
using Common_DT.Base;
using GSFramework;
using LookupTableManagement;

namespace CommonGUIControllers.Base
{
    public  class SecurityController :  Controller
    {
        #region Class Fields
        private SecurityDataSet mDataSet;
        private Guid mAplicatiiID;
        private Guid mDeschidereBaseID;
        private bool mLoadInstitutie = false;
        private Guid mUsersID = Guid.Empty;
        #endregion

        #region Properties
        public override DataSet DataSet
        {
            get
            {
                return mDataSet;
            }
            set
            {
                mDataSet = (SecurityDataSet)value;
            }
        }
        public Guid AplicatiiID
        {
            set { this.mAplicatiiID = value; }
        }
        public Guid DeschidereBaseID
        {
            set { mDeschidereBaseID = value; }
        }
        public bool LoadInstitutie
        {
            set { mLoadInstitutie = value; }
        }
        public Guid UsersID
        {
            set { this.mUsersID = value; }
        }
        #endregion

        #region Initialization Methods
        public override void InitializeClient()
        {
            try
            {
                mDataSet = new SecurityDataSet();
                myAutoLoad = false;
            }
            catch (System.Exception excep)
            {
                HandleException(excep);
            }
        }
        public override void InitializeServer()
        {
            try
            {

            }
            catch (System.Exception excep)
            {
                HandleException(excep);
            }
        }
        #endregion

        #region Load Methods
        protected override bool LoadClientBefore()
        {
            try
            {
                return true;
            }
            catch (System.Exception exception)
            {
                HandleException(exception);
                return false;
            }
        }
        public override bool LoadServer()
        {
            try
            {
                SecurityDataSvc svc = new SecurityDataSvc();
                // Custom Load
                if (mLoadInstitutie)
                {
                    svc.GetActiveInstitutiiByDeschidereID(mDataSet, mDeschidereBaseID);
                    return true;
                }
                // Default Load
                LookupTableBusSvc svcLookup = new LookupTableBusSvc();
                if (mDataSet.tbxTipAcces.Count == 0) svcLookup.GetLookupList("tbxTipAcces", mDataSet);
                if (mDataSet.tbxTipDataBase.Count == 0) svcLookup.GetLookupList("tbxTipDataBase", mDataSet);
                svc.GetWorkData(mDataSet, mAplicatiiID, mUsersID);                
                return true;
            }
            catch (System.Exception exception)
            {
                myException = exception;
                myResultMessage = exception.Message;
                myResultCode = -1;
                return false;
            }
        }
        protected override bool LoadClientAfter()
        {
            try
            {
                return true;
            }
            catch (System.Exception exception)
            {
                HandleException(exception);
                return false;
            }
        }
        #endregion

        #region Perform Methods
        protected override bool PerformClientBefore()
        {
            try
            {
                return true;
            }
            catch (System.Exception excep)
            {
                HandleException(excep);
                return false;
            }
        }
        public override bool PerformServer()
        {
            try
            {
                SecurityDataSvc svc = new SecurityDataSvc();
                svc.UpdateDS(mDataSet);
                return true;
            }
            catch (System.Exception excep)
            {
                myException = excep;
                myResultMessage = excep.Message;
                myResultCode = -1;
                return false;
            }
        }
        protected override bool PerformClientAfter()
        {
            try
            {
                return true;
            }
            catch (System.Exception excep)
            {
                HandleException(excep);
                return false;
            }
        }
        #endregion

        #region Private Methods
        private void HandleException(System.Exception excep)
        {
            throw excep;
        }
        private void FillUserRightsTables()
        {
            DataTable dtUserRightsXmlClone = mDataSet.tblUserRightsXml.Clone();
            DataTable dtUserRightsSpecificXmlClone = mDataSet.tblUserRightsSpecificXml.Clone();
            foreach (DataRow dr in mDataSet.tblUserRights.Rows)
            {
                if (dr.IsNull("UserRights"))
                {
                    dtUserRightsXmlClone.Clear();
                    TextReader reader = new StringReader(dr["UserRights"].ToString());
                    dtUserRightsXmlClone.ReadXml(reader);
                    mDataSet.tblUserRightsXml.Merge(dtUserRightsXmlClone);
                }
                if (dr.IsNull("UserRightsSpecific"))
                {
                    dtUserRightsSpecificXmlClone.Clear();
                    TextReader reader = new StringReader(dr["UserRightsSpecific"].ToString());
                    dtUserRightsSpecificXmlClone.ReadXml(reader);
                    mDataSet.tblUserRightsSpecificXml.Merge(dtUserRightsSpecificXmlClone);
                }
            }
            //Fill tblUserRightsUsr
            foreach (DataRow dr in mDataSet.tblUserRightsXml.Rows)
            {
                DataRow drNew = mDataSet.tblUserRightsUsr.NewRow();
                drNew["ID"] = Guid.NewGuid();
                drNew["UserRightsID"] = dr["UserRightsID"];
                DataRow drUR = dr.GetParentRow("tblUserRights_tblUserRightsXml");
                if (drUR != null)
                {
                    drNew["UsersID"] = drUR["UsersID"];
                    drNew["AplicatiiID"] = drUR["AplicatiiID"];
                }
                drNew["ModulID"] = dr["ModulID"];
                drNew["CentruID"] = dr["CentruID"];
                drNew["RolesID"] = dr["RolesID"];
                mDataSet.tblUserRightsUsr.Rows.Add(drNew);
            }
            foreach (DataRow dr in mDataSet.tblUsers.Rows)
            {
                if (dr["UserName"].ToString().Equals("Admin", StringComparison.InvariantCultureIgnoreCase)
                    || !(Convert.ToBoolean(dr["IsActive"])))
                    continue;
                DataRow[] drsUserRights = mDataSet.tblUserRights.Select("UsersID='" + dr["ID"].ToString() + "'");
                if (drsUserRights.Length > 0)
                    continue;
                foreach (DataRow drDesch in mDataSet.tblDeschidereBase.Rows)
                {
                    foreach (DataRow drModul in mDataSet.tblModul.Rows)
                    {
                        if (drModul["CodIntern"].ToString() == "1")
                        {
                            DataRow drNew = mDataSet.tblUserRightsUsr.NewRow();
                            drNew["ID"] = Guid.NewGuid();
                            drNew["UsersID"] = dr["ID"];
                            drNew["AplicatiiID"] = mAplicatiiID;
                            drNew["ModulID"] = drModul["ModulID"];
                            drNew["DeschidereBaseID"] = drDesch["ID"];
                            //drNew["RolesID"] = 
                            mDataSet.tblUserRightsUsr.Rows.Add(drNew);
                        }
                        else
                        {
                            foreach (DataRow drInstit in mDataSet.tblCentru.Rows)
                            {
                                DataRow drNew = mDataSet.tblUserRightsUsr.NewRow();
                                drNew["ID"] = Guid.NewGuid();
                                drNew["UsersID"] = dr["ID"];
                                drNew["AplicatiiID"] = mAplicatiiID;
                                drNew["ModulID"] = drModul["ModulID"];
                                drNew["DeschidereBaseID"] = drDesch["ID"];
                                drNew["CentruID"] = drInstit["ID"];
                                //drNew["RolesID"] = 
                                mDataSet.tblUserRightsUsr.Rows.Add(drNew);
                            }
                        }
                    }                    
                }
            }
        }
        #endregion
    }
}
