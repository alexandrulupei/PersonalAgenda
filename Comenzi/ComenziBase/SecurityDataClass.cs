using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using CommonDataSets.Base;
using CommonGUIControllers.Base;
using GSFramework;
using Utilities;

namespace ComenziBase
{
   public  class SecurityDataClass
    {
        #region Public Enum
        public enum AccessRights
        {
            NO_RIGHTS,
            FULL_RIGHTS,
            READING,
            ADD,
            ADD_MODIFY,
            MODIFY,
            MODIFY_DELETE,
            DELETE
        };

        public enum AccessRightsSpecific
        {
            //ALOP
            ADD_PA,                                 //01
            ADD_O,                                  //02
            MODIFY_PA,                              //03
            MODIFY_O,                               //04
            DELETE_P,                               //05
            DELETE_A,                               //06
            DELETE_O,                               //07
            VIZA_P,                                 //08
            VIZA_A,                                 //09
            VIZA_O,                                 //10
            VIZA_OCTB,                              //11 viza comaprtiment Contabilitate
            OBLIGATIE_ANGAJAMENT,                   //12
            PLATA_ORDONANTARE,                      //13
            GENERARE_ANGAJAMENT_STOC,               //14
            GENERARE_ORDONANTARE_STOC,              //15
            INTRARE_FURNIZOR_STOC,                  //16
            CONSUM_STOC,                            //17
            TRANSFER_STOC,                          //18
            BUGET_ACTUALIZARE,                      //19
            BUGET_FARA_DREPTURI,                    //20
            INTRARE_FURNIZORI_OBI,                  //21
            DARE_IN_FOLOSINTA_OBI,                  //22
            PREDARE_DEPOZIT_OBI,                    //23
            CASARE_DIN_LOC_FOLOSINTA,               //24
            CASARE_DIN_GESTIUNE,                    //25
            TRANSFER_INTRE_LOC_FOLOSINTA,           //26
            GENERARE_ANGAJAMENT_OBI,                //27
            GENERARE_ORDONANTARE_OBI,               //28
            EXPORT_DOCUMENTE_VIZUALIZARE_DOCUMENT,  //29
            EXPORT_DOCUMENTE_CONTRASEMNARE,         //30
            EXPORT_DOCUMENTE_RESPINGERE,            //31
            EXPORT_DOCUMENTE_VIZUALIZARE_EXPORTAT,  //32
            GENERARE_ORDONANTARE_CONTA,             //33
            ADD_P,                                  //34    
            ADD_A,                                  //35
            MODIFY_P,                               //36
            MODIFY_A,                               //37
            CUMUL_P,                                //38
            PROIECTBUGET_ACTUALIZARE                //39
        };

        public enum CodInternModul
        {
            ADMINISTRARE,
            BVC,
            ALOP,
            CONTABILITATE,
            STOC,
            OBI
        };
        #endregion

        #region Class Fields
        private static SecurityDataClass mOnlyInstance;
        private static SecurityDataSet mSecurityDataSet;
        private Guid mAplicatiiID = Guid.Empty;
        private SecurityController mController;
        private bool mIsAdmin;
        private readonly ContextUtilityClass mContextUtilityClass = ContextUtilityClass.OnlyInstance;
        private Guid mRoleID_Admin = Guid.Empty;
        private Guid mUserRightsID = Guid.Empty;
        private Guid mUserRightsRoleID = Guid.Empty;
        private Guid mUserRightsXmlID = Guid.Empty;
        private bool mUserHasAdminRole;
        private bool mIsLunaLucruBlocata;
        private readonly Utility mUtility = new Utility();
        private AccessRights mUserAccessRights;
        #endregion

        #region Properties
        /// <summary>
        /// Singleton access.
        /// </summary>
        public static SecurityDataClass OnlyInstance
        {
            get { return mOnlyInstance ?? (mOnlyInstance = new SecurityDataClass()); }
            set { mOnlyInstance = value; }
        }

        /// <summary>
        /// ReadOnly access to SecurityDataSet.
        /// </summary>
        public SecurityDataSet SecurityDataSet
        {
            get { return mSecurityDataSet; }
        }

        /// <summary>
        /// WriteOnly access to AplicatiiID
        /// </summary>
        public Guid AplicatiiID
        {
            set { this.mAplicatiiID = value; }
        }

        /// <summary>
        /// Checks if the user name is admin. The admin user has the admin role.
        /// </summary>
        public bool IsAdmin
        {
            get
            {
                if (ClientContext.OnlyInstance.UserName.Equals("admin", StringComparison.InvariantCultureIgnoreCase))
                {
                    mUserHasAdminRole = true;
                    return mIsAdmin = true;
                }
                return mIsAdmin = false;
            }
        }

        /// <summary>
        /// ReadOnly access to UserHasAdminRole
        /// </summary>
        public bool UserHasAdminRole
        {
            get { return mUserHasAdminRole; }
        }

        /// <summary>
        /// ReadOnly access to UserAccessRights
        /// </summary>
        public AccessRights UserAccessRights
        {
            get { return mUserAccessRights; }
        }

        /// <summary>
        /// ReadOnly access to SecurityController
        /// </summary>
        public SecurityController SecurityController
        {
            get { return mController; }
        }

        /// <summary>
        /// Access to IsLunaLucruBlocata. For the admin user always returns false.
        /// </summary>

        #endregion

        #region Private Methods
        /// <summary>
        /// Fills tblUserRightsXml and tblUserRightsSpecificXml in local SecurityDataSet from
        /// the xml content in columns UserRights and UserRightsSpecific in tblUserRights.
        /// Contains only values for the current user.
        /// </summary>
        private void FillUserRightsTables()
        {
            Guid gUserID = ClientContext.OnlyInstance.UserID;
            DataTable dtUserRightsXmlClone = mSecurityDataSet.tblUserRightsXml.Clone();
            DataTable dtUserRightsSpecificXmlClone = mSecurityDataSet.tblUserRightsSpecificXml.Clone();
            foreach (DataRow dr in mSecurityDataSet.tblUserRights.Select("UsersID='" + gUserID.ToString() + "'"))
            {
                if (!dr.IsNull("UserRights"))
                {
                    dtUserRightsXmlClone.Clear();
                    TextReader reader = new StringReader(dr["UserRights"].ToString());
                    dtUserRightsXmlClone.ReadXml(reader);
                    mSecurityDataSet.tblUserRightsXml.Merge(dtUserRightsXmlClone);
                }
                if (!dr.IsNull("UserRightsSpecific"))
                {
                    dtUserRightsSpecificXmlClone.Clear();
                    TextReader reader = new StringReader(dr["UserRightsSpecific"].ToString());
                    dtUserRightsSpecificXmlClone.ReadXml(reader);
                    mSecurityDataSet.tblUserRightsSpecificXml.Merge(dtUserRightsSpecificXmlClone);
                }
            }
        }

        /// <summary>
        /// Sets the admin role id in mRoleID_Admin.
        /// The row in tblRoles with CodIntern=01 is the admin role.
        /// </summary>
        private void SetAdminRole()
        {
            DataRow[] drs = mSecurityDataSet.tblRoles.Select("CodIntern='01'");
            if (drs.Length == 0)
                throw new Exception("Eroare securitate: cod eroare 01");
            mRoleID_Admin = (Guid)drs[0]["ID"];
        }

        /// <summary>
        /// Sets the id of the row in tblUserRights for the current user and application in mUserRightsID.
        /// </summary>
        private void SetUserRights()
        {
            DataRow[] drs = mSecurityDataSet.tblUserRights.Select("UsersID='" + ClientContext.OnlyInstance.UserID.ToString() +
                        "' and AplicatiiID='" + mAplicatiiID.ToString() + "'");
            if (drs.Length > 0)
                mUserRightsID = (Guid)drs[0]["ID"];
        }

        /// <summary>
        /// Sets the id of the row in local tblUserRightsXml for current user, application,
        /// deschidere, modul, institutie and role.
        /// Do not use if possible.
        /// </summary>
        private void SetUserRightsXmlID()
        {
            DataRow[] drs = mSecurityDataSet.tblUserRightsXml.Select(
                            "UserRightsID='" + mUserRightsID.ToString()
                            + "' and DeschidereBaseID='" + mContextUtilityClass.EvidentaID.ToString()
                            + "' and ModulID='" + mContextUtilityClass.ModulID.ToString()
                            + "' and CentruID='" + mContextUtilityClass.CentruID.ToString()
                            + "' and RolesID='" + mUserRightsRoleID.ToString() + "'");
            if (drs.Length > 0)
                mUserRightsID = (Guid)drs[0]["ID"];
        }

        /// <summary>
        /// Admin user always has admin role.
        /// Checks if the number of roles for the current user and application
        /// equals the number of roles for the current user and application which has the admin role.
        /// (i.e. User has admin role if all his rights has the admin role.)
        /// Sets mUserHasAdminRole.
        /// </summary>
        private void CheckUserHasAdminRole()
        {
            if (mIsAdmin)
            {
                mUserHasAdminRole = true;
                return;
            }
            DataRow[] drsAllRights = mSecurityDataSet.tblUserRightsXml.Select("UserRightsID='" + mUserRightsID.ToString() + "'");
            if (drsAllRights.Length == 0)
            {
                mUserHasAdminRole = false;
                return;
            }
            DataRow[] drsAllRightsAdminRole = mSecurityDataSet.tblUserRightsXml.Select("UserRightsID='" + mUserRightsID.ToString()
                            + "' and RolesID='" + mRoleID_Admin.ToString() + "'");

            mUserHasAdminRole = (drsAllRightsAdminRole.Length == drsAllRights.Length);
        }

        /// <summary>
        /// Looks in local tblUserRightsXml for the row for the current user, application, deschidere, modul
        /// and institutie (if exists) and sets the id in mUserRightsXmlID and the role id in mUserRightsRoleID.
        /// </summary>
        private void SetCurrentRoleID()
        {
            string sFilter = "UserRightsID='" + mUserRightsID.ToString() + "'" +
                             " and DeschidereBaseID='" + mContextUtilityClass.EvidentaID.ToString() + "'" +
                             " and ModulID='" + mContextUtilityClass.ModulID.ToString() + "'" +
                             (mContextUtilityClass.CentruID != Guid.Empty ?
                             " and CentruID='" + mContextUtilityClass.CentruID.ToString() + "'" :
                             "");
            DataRow[] drs = mSecurityDataSet.tblUserRightsXml.Select(sFilter);
            if (drs.Length > 0)
            {
                mUserRightsXmlID = (Guid)drs[0]["ID"];
                mUserRightsRoleID = (Guid)drs[0]["RolesID"];
            }
            else
            {
                mUserRightsRoleID = Guid.Empty;
            }
        }

        /// <summary>
        /// Converts an id of a row in tbxTipAcces to a value in enum AccessRights, using CodIntern.
        /// </summary>
        private AccessRights GetTipAccesRights(Guid pTipAccessID)
        {
            DataRow dr = mSecurityDataSet.tbxTipAcces.FindByID(pTipAccessID);
            switch (dr["CodIntern"].ToString())
            {
                case "0": return AccessRights.NO_RIGHTS;
                case "1": return AccessRights.FULL_RIGHTS;
                case "2": return AccessRights.READING;
                case "3": return AccessRights.ADD;
                case "4": return AccessRights.ADD_MODIFY;
                case "5": return AccessRights.MODIFY;
                case "6": return AccessRights.MODIFY_DELETE;
                case "7": return AccessRights.DELETE;
            }
            return AccessRights.NO_RIGHTS;
        }

        /// <summary>
        /// Converts an id of a row in tblModulSpecificRights to a value in enum AccessRightsSpecific, using CodIntern.
        /// </summary>
      

        /// <summary>
        /// Converts a value in enum AccessRightsSpecific to a string that contains CodIntern.
        /// </summary>
        private string GetAccessRightsSpecificCodIntern(AccessRightsSpecific pAccess)
        {
            if (pAccess == AccessRightsSpecific.ADD_PA)
                return "01";
            if (pAccess == AccessRightsSpecific.ADD_O)
                return "02";
            if (pAccess == AccessRightsSpecific.MODIFY_PA)
                return "03";
            if (pAccess == AccessRightsSpecific.MODIFY_O)
                return "04";
            if (pAccess == AccessRightsSpecific.DELETE_P)
                return "05";
            if (pAccess == AccessRightsSpecific.DELETE_A)
                return "06";
            if (pAccess == AccessRightsSpecific.DELETE_O)
                return "07";
            if (pAccess == AccessRightsSpecific.VIZA_P)
                return "08";
            if (pAccess == AccessRightsSpecific.VIZA_A)
                return "09";
            if (pAccess == AccessRightsSpecific.VIZA_O)
                return "10";
            if (pAccess == AccessRightsSpecific.VIZA_OCTB)
                return "11";
            if (pAccess == AccessRightsSpecific.OBLIGATIE_ANGAJAMENT)
                return "12";
            if (pAccess == AccessRightsSpecific.PLATA_ORDONANTARE)
                return "13";
            if (pAccess == AccessRightsSpecific.GENERARE_ANGAJAMENT_STOC)
                return "14";
            if (pAccess == AccessRightsSpecific.GENERARE_ORDONANTARE_STOC)
                return "15";
            if (pAccess == AccessRightsSpecific.INTRARE_FURNIZOR_STOC)
                return "16";
            if (pAccess == AccessRightsSpecific.CONSUM_STOC)
                return "17";
            if (pAccess == AccessRightsSpecific.TRANSFER_STOC)
                return "18";
            if (pAccess == AccessRightsSpecific.BUGET_ACTUALIZARE)
                return "19";
            if (pAccess == AccessRightsSpecific.BUGET_FARA_DREPTURI)
                return "20";
            if (pAccess == AccessRightsSpecific.INTRARE_FURNIZORI_OBI)
                return "21";
            if (pAccess == AccessRightsSpecific.DARE_IN_FOLOSINTA_OBI)
                return "22";
            if (pAccess == AccessRightsSpecific.PREDARE_DEPOZIT_OBI)
                return "23";
            if (pAccess == AccessRightsSpecific.CASARE_DIN_LOC_FOLOSINTA)
                return "24";
            if (pAccess == AccessRightsSpecific.CASARE_DIN_GESTIUNE)
                return "25";
            if (pAccess == AccessRightsSpecific.TRANSFER_INTRE_LOC_FOLOSINTA)
                return "26";
            if (pAccess == AccessRightsSpecific.GENERARE_ANGAJAMENT_OBI)
                return "27";
            if (pAccess == AccessRightsSpecific.GENERARE_ORDONANTARE_OBI)
                return "28";
            if (pAccess == AccessRightsSpecific.EXPORT_DOCUMENTE_VIZUALIZARE_DOCUMENT)
                return "29";
            if (pAccess == AccessRightsSpecific.EXPORT_DOCUMENTE_CONTRASEMNARE)
                return "30";
            if (pAccess == AccessRightsSpecific.EXPORT_DOCUMENTE_RESPINGERE)
                return "31";
            if (pAccess == AccessRightsSpecific.EXPORT_DOCUMENTE_VIZUALIZARE_EXPORTAT)
                return "32";
            if (pAccess == AccessRightsSpecific.GENERARE_ORDONANTARE_CONTA)
                return "33";
            if (pAccess == AccessRightsSpecific.ADD_P)
                return "34";
            if (pAccess == AccessRightsSpecific.ADD_A)
                return "35";
            if (pAccess == AccessRightsSpecific.MODIFY_P)
                return "36";
            if (pAccess == AccessRightsSpecific.MODIFY_A)
                return "37";
            if (pAccess == AccessRightsSpecific.CUMUL_P)
                return "38";
            if (pAccess == AccessRightsSpecific.PROIECTBUGET_ACTUALIZARE)
                return "39";
            return "00";
        }

        /// <summary>
        /// Returns if current user has a specific right for a given row in local tblUserRightsXml table.
        /// </summary>
      
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads the local SecurityDataSet, then expands tblUserRights in tblUserRightsXml and tblUserRightsSpecificXml.
        /// Then sets mRoleID_Admin, mUserRightsID, mUserHasAdminRole.
        /// </summary>
        public void LoadData()
        {
            mController = (SecurityController)ClientContext.OnlyInstance.CreateController("CommonGUIControllers.Base.SecurityController, CommonGUIControllers");
            mController.AplicatiiID = mAplicatiiID;
            mController.UsersID = ClientContext.OnlyInstance.UserID;
            mController.Load();
            if (ControllerUtils.HandleResultCode(mController)) return;
            mSecurityDataSet = (SecurityDataSet)mController.DataSet;
            FillUserRightsTables();
            mSecurityDataSet.AcceptChanges();
            SetAdminRole();
            SetUserRights();
            CheckUserHasAdminRole();
        }

        /// <summary>
        /// Loads table tblInstitutie into local SecurityDataSet.
        /// </summary>
        public bool LoadInstitutii()
        {
            mSecurityDataSet.tblCentru.Clear();
            mController = (SecurityController)ClientContext.OnlyInstance.CreateController("CommonGUIControllers.Base.SecurityController, CommonGUIControllers");
            mController.LoadInstitutie = true;
            mController.DeschidereBaseID = mContextUtilityClass.EvidentaID;
            mController.Load();
            if (ControllerUtils.HandleError(mController, "Incarcarea institutiilor nu a fost posibila. Va rugam contactati un administrator."))
            {
                return false;
            }
            mSecurityDataSet.Merge(mController.DataSet);
            mSecurityDataSet.AcceptChanges();
            return true;
        }

        /// <summary>
        /// Checks if navigation entry has AccessRights.NO_RIGHTS for current user, application, deschidere, modul,
        /// institutie and role. Admin user always can access the menu.
        /// </summary>
        public bool UserCanAccessMenu(DataRow pDataRowNavigation)
        {
            // Nu exista aplicatia
            if (mContextUtilityClass.AplicatiiID.Equals(Guid.Empty)) return false;

            if (mIsAdmin || mUserHasAdminRole) return true;

            // Nu exista deschiderea
            if (mContextUtilityClass.EvidentaID.Equals(Guid.Empty)) return false;

            DataRow[] drsUserRightsXml;
            DataRow[] drsRolesNavigation;

            // Nu exista modul            
            if (mContextUtilityClass.ModulID.Equals(Guid.Empty))
            {
                drsUserRightsXml = mSecurityDataSet.tblUserRightsXml.Select(
                    "UserRightsID='" + mUserRightsID + "'" +
                    " AND DeschidereBaseID='" + mContextUtilityClass.EvidentaID + "'" +
                    " AND ModulID IS NULL AND CentruID IS NULL");
                foreach (DataRow drUserRightsXml in drsUserRightsXml)
                {
                    if (mRoleID_Admin.Equals(drUserRightsXml["RolesID"])) return true;
                    drsRolesNavigation = mSecurityDataSet.lnkRolesNavigation.Select(
                        "NavigationID='" + pDataRowNavigation["ID"] + "'" +
                        " AND RolesID='" + drUserRightsXml["RolesID"] + "'");
                    if (drsRolesNavigation.Length == 0) continue;
                    if (GetTipAccesRights((Guid)drsRolesNavigation[0]["TipAccesID"]) == AccessRights.NO_RIGHTS)
                        return false;
                    return true;
                }
                return false;
            }

            // Nu exista institutie
            if (mContextUtilityClass.CentruID.Equals(Guid.Empty))
            {
                drsUserRightsXml = mSecurityDataSet.tblUserRightsXml.Select(
                    "UserRightsID='" + mUserRightsID + "'" +
                    " AND DeschidereBaseID='" + mContextUtilityClass.EvidentaID + "'" +
                    " AND ModulID='" + mContextUtilityClass.ModulID + "'");
                foreach (DataRow drUserRightsXml in drsUserRightsXml)
                {
                    if (mRoleID_Admin.Equals(drUserRightsXml["RolesID"])) return true;
                    if (pDataRowNavigation.IsNull("WindowString")) return true;
                    drsRolesNavigation = mSecurityDataSet.lnkRolesNavigation.Select(
                        "NavigationID='" + pDataRowNavigation["ID"] + "'" +
                        " AND RolesID='" + drUserRightsXml["RolesID"] + "'");
                    if (drsRolesNavigation.Length == 0) continue;
                    if (GetTipAccesRights((Guid)drsRolesNavigation[0]["TipAccesID"]) == AccessRights.NO_RIGHTS)
                        return false;
                    return true;
                }
                return false;
            }

            drsUserRightsXml = mSecurityDataSet.tblUserRightsXml.Select(
                "UserRightsID='" + mUserRightsID + "'" +
                " AND DeschidereBaseID='" + mContextUtilityClass.EvidentaID + "'" +
                " AND ModulID='" + mContextUtilityClass.ModulID + "'" +
                " AND CentruID='" + mContextUtilityClass.CentruID + "'");
            foreach (DataRow drUserRightsXml in drsUserRightsXml)
            {
                if (mRoleID_Admin.Equals(drUserRightsXml["RolesID"])) return true;
                if (pDataRowNavigation.IsNull("WindowString")) return true;
                drsRolesNavigation = mSecurityDataSet.lnkRolesNavigation.Select(
                    "NavigationID='" + pDataRowNavigation["ID"] + "'" +
                    " AND RolesID='" + drUserRightsXml["RolesID"] + "'");
                if (drsRolesNavigation.Length == 0) continue;
                if (GetTipAccesRights((Guid)drsRolesNavigation[0]["TipAccesID"]) == AccessRights.NO_RIGHTS)
                    return false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a string filter that contains all the evidente IDs the current user can access.
        /// Admin user can access everything with an empty string filter.
        /// </summary>
        public string GetEvidenteFilter()
        {
            if (mIsAdmin || mUserHasAdminRole) return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in mSecurityDataSet.tblDeschidereBase.Rows)
            {
                DataRow[] drsUserRights = mSecurityDataSet.tblUserRightsXml.Select(
                    "UserRightsID='" + mUserRightsID.ToString() + "'" +
                    " AND DeschidereBaseID='" + dr["ID"] + "'");
                foreach (DataRow drUserRights in drsUserRights)
                {
                    DataRow[] drsLnkRoles = mSecurityDataSet.lnkRolesDeschidereBase.Select(
                        "RolesID='" + drUserRights["RolesID"] + "'" +
                        " AND DeschidereBaseID='" + drUserRights["DeschidereBaseID"] + "'");
                    if (drsLnkRoles.Length > 0 || mRoleID_Admin.Equals(drUserRights["RolesID"]))
                    {
                        sb.Append(" ID='" + dr["ID"] + "'");
                        sb.Append(" OR");
                        break;
                    }
                }
            }
            if (sb.Length == 0) return "ID='" + Guid.Empty + "'";
            sb.Remove(sb.Length - 3, 3);  // removes the last OR          
            return sb.ToString();
        }

        /// <summary>
        /// Returns a string filter that contains all the modules IDs the current user can access.
        /// Admin user can access all the modules with a filter for the current application.
        /// The parameter is the key in the filter.
        /// </summary>
        public string GetModulRowFilter(string pColumn)
        {
            if (mIsAdmin || mUserHasAdminRole)
            {
                return "AplicatiiID='" + mContextUtilityClass.AplicatiiID + "'";
            }

            List<Guid> listModules = new List<Guid>();
            DataRow[] drs = mSecurityDataSet.tblUserRightsXml.Select(
                "UserRightsID='" + mUserRightsID + "'" +
                " AND DeschidereBaseID='" + mContextUtilityClass.EvidentaID + "'");
            foreach (DataRow dr in drs)
            {
                if (listModules.Contains((Guid)dr["ModulID"])) continue;
                if (mRoleID_Admin.Equals(dr["RolesID"]))
                {
                    listModules.Add((Guid)dr["ModulID"]);
                    continue;
                }
                DataRow[] drsLnkRoles = mSecurityDataSet.lnkRolesNavigation.Select(
                    "RolesID='" + dr["RolesID"] + "'" +
                    " AND CodIntern <> '0' AND ModulID='" + dr["ModulID"] + "'");
                if (drsLnkRoles.Length > 0)
                {
                    listModules.Add((Guid)dr["ModulID"]);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listModules.Count; i++)
            {
                sb.Append(pColumn + "='" + listModules[i] + "'");
                sb.Append(" OR ");
            }
            if (sb.Length == 0) return pColumn + "='" + Guid.Empty + "'";
            sb.Remove(sb.Length - 4, 3);
            return sb.ToString();
        }

        /// <summary>
        /// Returns a filter string with all the institutii IDs the user can access.
        /// </summary>
        /// <param name="pColumn"></param>
        /// <returns></returns>
        public string GetInstitutieRowFilter(string pColumn)
        {
            if (pColumn == "ModulID")
            {
                return GetInstitutieRowFilter(pColumn, ContextUtilityClass.OnlyInstance.ModulID, null);
            }
           else

            return GetInstitutieRowFilter(pColumn, Guid.Empty, null);
        }

        /// <summary>
        /// Returns a filter string with all the institutii IDs the user can access.
        /// (i.e. are active at the DataLucru)
        /// Parameter pColumn is the key in the filter.
        /// Parameters pDeschidereID and pInstitutieDataTable are optional (i.e can be set Guid.Empty and null).
        /// </summary>
        public string GetInstitutieRowFilter(string pColumn, Guid pDeschidereID, DataTable pInstitutieDataTable)
        {
            List<Guid> listInstitutie = new List<Guid>();

            if (mIsAdmin || mUserHasAdminRole)
            {
                // Admin
                foreach (DataRow dr in mSecurityDataSet.tblCentru.Select(
                    "ModulID='" + mContextUtilityClass.ModulID.ToString() + "'"))
                {
                    if (
                        !mUtility.IsValidInLunaDeLucru((Guid) dr["ID"], mSecurityDataSet.tblCentru,
                            mContextUtilityClass.DataLucru))
                        continue;
                    if (!listInstitutie.Contains((Guid) dr["ID"]))
                    {
                        listInstitutie.Add((Guid) dr["ID"]);
                    }
                }
            }
            else
            {
                // Not Admin
                string sFilterUserRightsXml;
                if (pDeschidereID.Equals(Guid.Empty))
                    sFilterUserRightsXml = "UserRightsID='" + mUserRightsID + "'" +
                                           " AND DeschidereBaseID='" + mContextUtilityClass.EvidentaID + "'" +
                                           " AND ModulID='" + mContextUtilityClass.ModulID + "'";
                else
                    sFilterUserRightsXml = "UserRightsID='" + mUserRightsID + "'" +
                                           " AND DeschidereBaseID='" + pDeschidereID + "'" +
                                           " AND ModulID='" + mContextUtilityClass.ModulID + "'";
                DataRow[] drs = mSecurityDataSet.tblUserRightsXml.Select(sFilterUserRightsXml);
                foreach (DataRow dr in drs)
                {
                    if (dr.IsNull("CentruID")) continue;
                    if (pInstitutieDataTable == null &&
                        !mUtility.IsValidInLunaDeLucru((Guid) dr["CentruID"], mSecurityDataSet.tblCentru,
                            mContextUtilityClass.DataLucru))
                        continue;
                    if (pInstitutieDataTable != null &&
                        !mUtility.IsValidInLunaDeLucru((Guid) dr["CentruID"], pInstitutieDataTable,
                            mContextUtilityClass.DataLucru))
                        continue;
                    if (!listInstitutie.Contains((Guid) dr["CentruID"]))
                    {
                        if (mRoleID_Admin.Equals(dr["RolesID"]))
                        {
                            listInstitutie.Add((Guid) dr["CentruID"]);
                            continue;
                        }
                        DataRow[] drsLnkRoles = mSecurityDataSet.lnkRolesNavigation.Select(
                            "RolesID='" + dr["RolesID"] + "'" +
                            " AND CodIntern <> '0' AND ModulID='" + dr["ModulID"] + "'");
                        if (drsLnkRoles.Length > 0)
                        {
                            //verificam tip access in lnk cu NO_RIGHTS
                            if (GetTipAccesRights((Guid) drsLnkRoles[0]["TipAccesID"]) == AccessRights.NO_RIGHTS)
                                continue;
                            
                            listInstitutie.Add((Guid) dr["CentruID"]);
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            if (listInstitutie.Count > 0)
            {
                sb.Append("(");
                for (int i = 0; i < listInstitutie.Count; i++)
                {
                    sb.Append(pColumn + "='" + listInstitutie[i] + "'");
                    if (i < listInstitutie.Count - 1)
                    {
                        sb.Append(" OR ");
                    }
                }
                sb.Append(")");
            }
            else
            {
                if (sb.Length == 0) sb.Append(pColumn + "='" + Guid.Empty + "'");
            }
           
            return sb.ToString();
        }

        /// <summary>
        /// Returns a filter string with all the finance sources for the given institution ID.
        /// </summary>
        public string GetSursaFinantareRowFilter(Guid pCentruID)
        {
            string result;
            if (pCentruID.Equals(Guid.Empty)) result = "1=0";
            else result = "GroupID='" + pCentruID + "' AND IsGroup=0";
            return result;
        }

        /// <summary>
        /// Checks user rights for a given navigation entry and sets mUserAccessRights.
        /// </summary>
        public void SetUserAccessRights(Guid pNavigationID)
        {
            if (mIsAdmin || mUserHasAdminRole)
            {
                mUserAccessRights = AccessRights.FULL_RIGHTS;
                return;
            }

            // Institutiile excluse din cumulare au drepturi depline: REVOKED
            DataRow[] dr = mSecurityDataSet.tblCentru.Select("ID='"+mContextUtilityClass.CentruID+"'");
            if (dr.Length>0 )
            {
                mUserAccessRights = AccessRights.FULL_RIGHTS;
                return;
            }

            DataRow drNav = mSecurityDataSet.tblNavigation.FindByID(pNavigationID);
            if (mIsLunaLucruBlocata && !drNav["Permission"].ToString().Equals("0"))
            {
                mUserAccessRights = AccessRights.READING;
                return;
            }

            SetCurrentRoleID();
            if (mUserRightsRoleID.Equals(mRoleID_Admin))
            {
                mUserAccessRights = AccessRights.FULL_RIGHTS;
            }

            DataRow[] drs = mSecurityDataSet.lnkRolesNavigation.Select(
                "RolesID='" + mUserRightsRoleID + "'" +
                " AND NavigationID='" + pNavigationID + "'");
            mUserAccessRights = drs.Length > 0 ? GetTipAccesRights((Guid)drs[0]["TipAccesID"]) : AccessRights.NO_RIGHTS;
        }

        /// <summary>
        /// Returns if current user has a specific right.
        /// </summary>
       
        /// <summary>
        /// Returns if current user has a specific right for a given institutie.
        /// </summary>
     

        /// <summary>
        /// Converts a value in enum CodInternModul to the Guid of the row in tblModul.
        /// </summary>
        public Guid GetModulIDByCodIntern(CodInternModul pCodInternModul)
        {
            string sCodIntern = "0";
            if (pCodInternModul == CodInternModul.ADMINISTRARE)
                sCodIntern = "0";
            else if (pCodInternModul == CodInternModul.BVC)
                sCodIntern = "1";
            else if (pCodInternModul == CodInternModul.ALOP)
                sCodIntern = "2";
            else if (pCodInternModul == CodInternModul.CONTABILITATE)
                sCodIntern = "3";
            else if (pCodInternModul == CodInternModul.STOC)
                sCodIntern = "4";
            else if (pCodInternModul == CodInternModul.OBI)
                sCodIntern = "5";
            DataRow[] drs = mSecurityDataSet.tblModul.Select("CodIntern='" + sCodIntern + "'");
            if (drs.Length > 0) return new Guid(drs[0]["ID"].ToString());
            return Guid.Empty;
        }

        /// <summary>
        /// Returns a connection string for a row in tblDeschidereDet.
        /// </summary>
        public string GetConnectionString(DataRow pDeschidereDetRow, int pConnectionTimeOut)
        {
            bool bUseServerName = true;
            if (mSecurityDataSet.tblUsers.Columns.Contains("TipConnection"))
            {
                DataRow drUser = mSecurityDataSet.tblUsers.FindByID(ClientContext.OnlyInstance.UserID);
                // TipConnection 
                // 0 - ServerName
                // 1 - ServerNameLocal
                if (!drUser.IsNull("TipConnection") && Convert.ToInt16(drUser["TipConnection"]) == 1)
                {
                    bUseServerName = false;
                }
            }

            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            if (bUseServerName)
            {
                if (pDeschidereDetRow["ServerName"] != DBNull.Value)
                {
                    connectionBuilder.DataSource = pDeschidereDetRow["ServerName"].ToString();
                }
            }
            else
            {
                if (pDeschidereDetRow["ServerNameLocal"] != DBNull.Value)
                {
                    connectionBuilder.DataSource = pDeschidereDetRow["ServerNameLocal"].ToString();
                }
            }

            if (pDeschidereDetRow["DataBaseName"] != DBNull.Value)
            {
                connectionBuilder.InitialCatalog = pDeschidereDetRow["DataBaseName"].ToString();
            }

            int tipAutentificare = 0;
            if (pDeschidereDetRow["TipAutentificare"] != DBNull.Value)
            {
                tipAutentificare = Convert.ToInt32(pDeschidereDetRow["TipAutentificare"]);
            }

            string user = "";
            if (pDeschidereDetRow["UserNameServer"] != DBNull.Value)
            {
                user = pDeschidereDetRow["UserNameServer"].ToString();
            }

            string parola = "";
            if (pDeschidereDetRow["PaswordServer"] != DBNull.Value)
            {
                parola = pDeschidereDetRow["PaswordServer"].ToString();
            }

            switch (tipAutentificare)
            {
                case 1:
                    connectionBuilder.IntegratedSecurity = true;
                    break;
                case 0:
                    connectionBuilder.IntegratedSecurity = false;
                    connectionBuilder.UserID = user;
                    connectionBuilder.Password = parola;
                    break;
            }
            connectionBuilder.ConnectTimeout = pConnectionTimeOut;
            return connectionBuilder.ConnectionString;
        }

        /// <summary>
        /// Checks if current user has right for evidenta, modul, institutie.
        /// </summary>
        public bool UserCanAccesInstitutie(Guid pEvidentaID, Guid pModulID, Guid pCentruID, DataTable pInstitutieDataTable)
        {
            if (mIsAdmin || mUserHasAdminRole) return true;

            string sSelect = "UserRightsID='" + mUserRightsID + "'" +
                             " AND DeschidereBaseID='" + pEvidentaID + "'" +
                             " AND ModulID='" + pModulID + "'" +
                             " AND CentruID='" + pCentruID.ToString() + "'";
            DataRow[] drs = mSecurityDataSet.tblUserRightsXml.Select(sSelect);
            if (drs.Length == 0) return false;

            string sFilterInstitutie = GetInstitutieRowFilter("ID", pEvidentaID, pInstitutieDataTable);
            if (sFilterInstitutie.Equals("ID='00000000-0000-0000-0000-000000000000'"))
                return false;

            //check roles access deschidere
            foreach (DataRow dr in drs)
            {
                DataRow[] drsLnkRolesDeschidere = mSecurityDataSet.lnkRolesDeschidereBase.Select(
                    "RolesID='" + dr["RolesID"] + "'" +
                    " AND DeschidereBaseID='" + pEvidentaID.ToString() + "'");
                if (drsLnkRolesDeschidere.Length == 0) return false;

                DataRow[] drsLnkRoles = mSecurityDataSet.lnkRolesNavigation.Select(
                    "RolesID='" + dr["RolesID"] + "'" +
                    " AND CodIntern <> '0' AND ModulID='" + pModulID + "'");
                if (drsLnkRoles.Length == 0) return false;

                //verificam tip access in lnk cu NO_RIGHTS
                if (GetTipAccesRights((Guid)drsLnkRoles[0]["TipAccesID"]) == AccessRights.NO_RIGHTS)
                    return false;

                
       
                return true;
            }
            return true;
        }
        #endregion

    }
}
