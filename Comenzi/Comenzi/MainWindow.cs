using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ComenziBase;
using CommonDataSets.Configurare;
using DevExpress.XtraEditors;
using GSFramework;
using LookupTableManagement;
using Utilities;
using CommonDataSets.Base;
using CommonDataSets.GUI;
using DevExpress.XtraBars;
using GSBusFramework;
using UtilityClass = GSFramework.UtilityClass;

namespace Comenzi
{
    public partial class MainWindow : ComenziBase.FrameworkWindow
    {

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields
        private ConfigDataSet mDataSet;
        private Guid mAplicatiiID = Guid.Empty;
        private Utility mUtility = new Utility();
        private const string mEvidentaNameDefault = "-- Alegeti Evidenta --";
        private const string mModulNameDefault = "-- Alegeti Modulul --";
        private const string mInstitutieNameDefault = "-- Alegeti Institutia --";
        private CultureInfo mCultureInfo = new CultureInfo("ro-RO", false);
        private const string mDateFormat = "MMMM - yyyy";
        private UsersJnkDataSet mUsersJnkDataSet = new UsersJnkDataSet();
        private const string mUsersJnkFileName = "UsersMainWindow.xml";
        private Dictionary<string, int> mMonthList = new Dictionary<string, int>();

        private bool mUpdateChecked = false;

        #endregion

        #region Private Events

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Initialize();
            UpdateApplication();
        }
        private void barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow[] drs = SecurityDataClass.OnlyInstance.SecurityDataSet.tblNavigation.Select("ID='" + barManager1.PressedLink.Item.Tag.ToString() + "'");
            if (drs.Length > 0)
            {
                SecurityDataSet.tblNavigationRow item = (SecurityDataSet.tblNavigationRow)drs[0];
                SecurityDataClass.OnlyInstance.SetUserAccessRights(item.ID);
                if (item.IsWindow)
                {
                    if (item.IsNull("QueryString"))
                        Context.CreateActivateWindow(item.WindowString);
                    else
                        Context.CreateActivateWindow(item.WindowString, item.QueryString);
                }
                else if (item.IsDialogWindow)
                {
                    if (item.IsNull("QueryString"))
                    {
                        using (Context.CreateDialogWindow(item.WindowString))
                        {
                            Context.CreatedWindow = null;
                        }
                    }
                    else
                    {
                        using (Context.CreateDialogWindow(item.WindowString, item.QueryString))
                        {
                            Context.CreatedWindow = null;
                        }
                    }
                }
                else if (item.IsWeb)
                {
                    Window wnd = item.IsNull("QueryString") ? Context.CreateNonMDIWindow(item.WindowString) : Context.CreateNonMDIWindow(item.WindowString, item.QueryString);
                    wnd.ShowInTaskbar = true;
                }
            }
        }
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveUsersJunk();
            SaveDataLucru();
        }

        private void barEditItemEvidente_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CloseMDIChildren();
                HideMenu();
                barEditItemModul.Enabled = barEditItemCentru.Enabled = false;
                barEditItemModul.EditValue = barEditItemCentru.EditValue = DBNull.Value;
                barEditItemModul.Caption = mModulNameDefault;
                barEditItemCentru.Caption = mInstitutieNameDefault;

                ContextUtilityClass.OnlyInstance.EvidentaID =
                ContextUtilityClass.OnlyInstance.ModulID =
                ContextUtilityClass.OnlyInstance.GrupID =
                ContextUtilityClass.OnlyInstance.CentruID = Guid.Empty;

                if (this.barEditItemEvidente.EditValue == DBNull.Value)
                {
                    barEditItemEvidente.Caption = mEvidentaNameDefault;
                }
                else
                {
                    if (!SetSessionDataForDeschidere())
                    {
                        //if (MessageBox.Show("Doriti sa actualizati bazele de date?", "Eroare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        //    using (Context.CreateDialogWindow("EconetAdmin.Users.UpdateDBHome, EconetAdmin"))
                        //    {
                        //        Context.CreatedWindow = null;
                        //    }
                        //}
                        return;
                    }
                    barEditItemModul.Enabled = true;
                    this.tblModulBindingSource.Filter = SecurityDataClass.OnlyInstance.GetModulRowFilter("ID");
                }

            }
            catch (Exception error)
            {
                //if (MessageBox.Show("Eroare: " + error.Message + Environment.NewLine + Environment.NewLine + "Doriti sa actualizati bazele de date?", "Eroare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    using (Context.CreateDialogWindow("EconetAdmin.Users.UpdateDBHome, EconetAdmin"))
                //    {
                //        Context.CreatedWindow = null;
                //    }
                //}
            }
        }

        private void barEditItemModul_EditValueChanged(object sender, EventArgs e)
        {
            {
                CloseMDIChildren();

                // Reset Institutie
                barEditItemCentru.Enabled = false;
                barEditItemCentru.EditValue = DBNull.Value;
                barEditItemCentru.Caption = mInstitutieNameDefault;

                ContextUtilityClass.OnlyInstance.GrupID =
                ContextUtilityClass.OnlyInstance.CentruID = Guid.Empty;

                if (this.barEditItemModul.EditValue == DBNull.Value)
                {
                    ContextUtilityClass.OnlyInstance.ModulID = Guid.Empty;
                }
                else
                {
                    ContextUtilityClass.OnlyInstance.ModulID = (Guid)barEditItemModul.EditValue;
                    DataRow drModul = SecurityDataClass.OnlyInstance.SecurityDataSet.tblModul.FindByID(ContextUtilityClass.OnlyInstance.ModulID);
                    ContextUtilityClass.OnlyInstance.ModulCod = drModul["CodIntern"].ToString();
                    ContextUtilityClass.OnlyInstance.ModulName = drModul["ModulName"].ToString();

                    if (!ContextUtilityClass.OnlyInstance.ModulCod.Equals("0") )
                    {
                        barEditItemCentru.Enabled = true;
                        tblCentruBindingSource.Filter = SecurityDataClass.OnlyInstance.GetInstitutieRowFilter("ID");

                    }
                    ShowMenuByUserRights();
                }
            }

        }

        private void barEditItemCentru_EditValueChanged(object sender, EventArgs e)
        {
            CloseMDIChildren();
            if (this.barEditItemCentru.EditValue == DBNull.Value)
            {
                ContextUtilityClass.OnlyInstance.GrupID = Guid.Empty;

            }
            else
            {
                ContextUtilityClass.OnlyInstance.CentruID = (Guid)barEditItemCentru.EditValue;

                // Retrieve extra information
                try
                {
                    object obj = repositoryItemLookUpEditCentru.DataSource;
                    if (obj != null)
                    {
                        //DataRow drInstitutie = SecurityDataClass.OnlyInstance.SecurityDataSet.tblCentru.FindByID(ContextUtilityClass.OnlyInstance.GrupID);
                        //if (drInstitutie != null)
                        //{
                        //    ContextUtilityClass.OnlyInstance.DenumireInstitutie = drInstitutie["Denumire"].ToString();
                        //    ContextUtilityClass.OnlyInstance.CodInstitutie = drInstitutie["Cod"].ToString();

                        //}
                    }
                }
                catch (Exception exception)
                {
                    Utilities.Utility.Log(exception.Message);
                }

            }

            ShowMenuByUserRights();
            //HideMenu();

        }


        private void barStaticItemLunaLucruValue_EditValueChanged(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CloseMDIChildren();
            int month;
            mMonthList.TryGetValue(barEditItemLunaLucru.EditValue.ToString(), out month);
            ContextUtilityClass.OnlyInstance.DataLucru = new DateTime(ContextUtilityClass.OnlyInstance.DataLucru.Year, month, 1);
            if (barEditItemAnLucru.EditValue != null)
                barEditItemLunaLucru.Caption = barEditItemLunaLucru.EditValue.ToString() + "-" + barEditItemAnLucru.EditValue.ToString();
            this.tblCentruBindingSource.Filter = SecurityDataClass.OnlyInstance.GetInstitutieRowFilter("ID");
        }

        private void barEditItemAnLucru_EditValueChanged(object sender, EventArgs e)
        {
            if (IsLoading) return;
            CloseMDIChildren();
            ContextUtilityClass.OnlyInstance.DataLucru = new DateTime(Convert.ToInt16(barEditItemAnLucru.EditValue), ContextUtilityClass.OnlyInstance.DataLucru.Month, 1);
            barEditItemLunaLucru.Caption = barEditItemLunaLucru.EditValue.ToString() + "-" + barEditItemAnLucru.EditValue.ToString();
            this.tblCentruBindingSource.Filter = SecurityDataClass.OnlyInstance.GetInstitutieRowFilter("ID");
        }

        #endregion

        #region Private  Methods

        #region Private Methods

        #region Menu
        private void HideMenu()
        {
            for (int i = 0; i < barMainMenu.LinksPersistInfo.Count; i++)
            {
                barMainMenu.LinksPersistInfo[i].Item.Visibility = BarItemVisibility.Never;
            }
            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].Tag == null) continue;
                barManager1.Items[i].Visibility = BarItemVisibility.Never;
            }
        }

        private void ShowMenuByUserRights()
        {
            Guid gNavigationID = Guid.Empty;
            DataRow drNavigation;
            for (int i = 0; i < barMainMenu.LinksPersistInfo.Count; i++)
            {
                gNavigationID = (Guid)barMainMenu.LinksPersistInfo[i].Item.Tag;
                drNavigation = SecurityDataClass.OnlyInstance.SecurityDataSet.tblNavigation.FindByID(gNavigationID);
                ShowSubMenuByUserRights(barMainMenu.LinksPersistInfo[i].Item, drNavigation);
            }
            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].Tag == null) continue;
                gNavigationID = (Guid)barManager1.Items[i].Tag;
                drNavigation = SecurityDataClass.OnlyInstance.SecurityDataSet.tblNavigation.FindByID(gNavigationID);
                ShowSubMenuByUserRights(barManager1.Items[i], drNavigation);
            }
            for (int i = 0; i < barManager1.Items.Count; i++)
            {
                if (barManager1.Items[i].Tag == null || barManager1.Items[i].Visibility == BarItemVisibility.Never) continue;
                gNavigationID = (Guid)barManager1.Items[i].Tag;
                drNavigation = SecurityDataClass.OnlyInstance.SecurityDataSet.tblNavigation.FindByID(gNavigationID);
                if (drNavigation.IsNull("ParentGroupID")) continue;
                Guid gParentID = GetRootForChildID((Guid)drNavigation["ParentGroupID"]);
                for (int j = 0; j < barMainMenu.LinksPersistInfo.Count; j++)
                {
                    gNavigationID = (Guid)barMainMenu.LinksPersistInfo[j].Item.Tag;
                    if (gNavigationID.Equals(gParentID))
                    {
                        barMainMenu.LinksPersistInfo[j].Item.Visibility = BarItemVisibility.Always;
                        break;
                    }
                }
            }
        }

        private void ShowSubMenuByUserRights(BarItem pBarItem, DataRow pDataRowNavigation)
        {
            if (ContextUtilityClass.OnlyInstance.EvidentaID.Equals(Guid.Empty))
            {
                if ((SecurityDataClass.OnlyInstance.IsAdmin || SecurityDataClass.OnlyInstance.UserHasAdminRole) &&
                                     (pDataRowNavigation["Permission"].ToString().Equals("0")))
                    pBarItem.Visibility = BarItemVisibility.Always;
                else
                    pBarItem.Visibility = BarItemVisibility.Never;
            }
            else if (ContextUtilityClass.OnlyInstance.ModulID.Equals(Guid.Empty))
            {
                if (SecurityDataClass.OnlyInstance.IsAdmin || SecurityDataClass.OnlyInstance.UserHasAdminRole)
                {
                    if (pDataRowNavigation["Permission"].ToString().Equals("0") || pDataRowNavigation["Permission"].ToString().Equals("1"))
                        pBarItem.Visibility = BarItemVisibility.Always;
                }
                else
                    pBarItem.Visibility = BarItemVisibility.Never;
            }
            else if (ContextUtilityClass.OnlyInstance.CentruID.Equals(Guid.Empty))
            {
                if ((pDataRowNavigation["Permission"].ToString().Equals("0") || pDataRowNavigation["Permission"].ToString().Equals("1") || pDataRowNavigation["Permission"].ToString().Equals("2"))
                        && (!pDataRowNavigation.IsNull("ModulID") && ((Guid)pDataRowNavigation["ModulID"]).Equals(ContextUtilityClass.OnlyInstance.ModulID)) && SecurityDataClass.OnlyInstance.UserCanAccessMenu(pDataRowNavigation))
                {
                    pBarItem.Visibility = BarItemVisibility.Always;
                }
                else
                    pBarItem.Visibility = BarItemVisibility.Never;
            }
            else if (!ContextUtilityClass.OnlyInstance.CentruID.Equals(Guid.Empty))
            {
                if (!pDataRowNavigation.IsNull("ModulID") && ((Guid)pDataRowNavigation["ModulID"]).Equals(ContextUtilityClass.OnlyInstance.ModulID) && SecurityDataClass.OnlyInstance.UserCanAccessMenu(pDataRowNavigation))
                    pBarItem.Visibility = BarItemVisibility.Always;
                else
                    pBarItem.Visibility = BarItemVisibility.Never;
            }
        }

        private void LoadRootMenu()
        {
            DataRow[] drs = SecurityDataClass.OnlyInstance.SecurityDataSet.tblNavigation.Select("ParentGroupID is null", "Node");
            foreach (DataRow dr in drs)
            {
                //if (dr.IsNull("ParentGroupID"))
                {
                    BarSubItem barSubItem = new BarSubItem(barManager1, dr["Name"].ToString());
                    barMainMenu.LinksPersistInfo.Add(new LinkPersistInfo(barSubItem));
                    barSubItem.Tag = dr["ID"];
                    LoadAllSubMenu((Guid)dr["ID"], barSubItem);
                }
            }
        }

        private void LoadAllSubMenu(Guid pParentGroupID, BarSubItem pBarSubItemParent)
        {
            DataRow[] drs = SecurityDataClass.OnlyInstance.SecurityDataSet.tblNavigation.Select("ParentGroupID='" + pParentGroupID.ToString() + "'", "Node");
            foreach (DataRow dr in drs)
            {
                DataRow[] drsSubs = SecurityDataClass.OnlyInstance.SecurityDataSet.tblNavigation.Select("ParentGroupID='" + dr["ID"].ToString() + "'", "Node");
                if (drsSubs.Length > 0)
                {
                    BarSubItem barSubItem = new BarSubItem(barManager1, dr["Name"].ToString());
                    pBarSubItemParent.LinksPersistInfo.Add(new LinkPersistInfo(barSubItem));
                    barSubItem.Tag = dr["ID"];
                    foreach (DataRow drSubs in drsSubs)
                    {
                        if (SecurityDataClass.OnlyInstance.SecurityDataSet.tblNavigation.Select("ParentGroupID='" + drSubs["ID"].ToString() + "'", "Node").Length > 0)
                            LoadAllSubMenu((Guid)drSubs["ID"], barSubItem);
                        else
                            CreateBarButtonItem(drSubs, barSubItem);
                    }
                }
                else
                {
                    CreateBarButtonItem(dr, pBarSubItemParent);
                }
            }

        }

        private BarButtonItem CreateBarButtonItem(DataRow pDataRow, BarSubItem pBarSubItemParent)
        {
            BarButtonItem barButtonItem = new BarButtonItem();
            barManager1.Items.Add(barButtonItem);
            barButtonItem.Caption = pDataRow["Name"].ToString();
            barButtonItem.Tag = pDataRow["ID"];
            barButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_ItemClick);
            pBarSubItemParent.LinksPersistInfo.Add(new LinkPersistInfo(barButtonItem));
            return barButtonItem;
        }
        #endregion

        #region Application Methods
        private void SetApplicationName()
        {
            try
            {
                System.Configuration.AppSettingsReader appSettingsReader = new System.Configuration.AppSettingsReader();
                String mValue = (String)appSettingsReader.GetValue("App", Type.GetType("System.String"));
                this.Context.SetCurrentConnection(ContextUtilityClass.OnlyInstance.DataBaseCurrentConnectionString);
                LookupTableBusSvc svc = new LookupTableBusSvc();
                svc.GetLookupList("tblAplicatii", mDataSet);
                DataRow[] drs = mDataSet.Tables["tblAplicatii"].Select("NumeAplicatie='" + mValue + "'");
                if (drs.Length == 0)
                {
                    XtraMessageBox.Show("Aplicatie inexistenta", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                ContextUtilityClass.OnlyInstance.AplicatiiID = mAplicatiiID = (Guid)drs[0]["ID"];


            }
            catch (Exception excep)
            {
                Utility.Log(excep.Message);
            }
        }

        private bool SetSessionDataForDeschidere()
        {

            ContextUtilityClass.OnlyInstance.EvidentaID = (Guid)barEditItemEvidente.EditValue;

            // Informatii din Deschidere Base
            DataRow drDeschidereBase =
                SecurityDataClass.OnlyInstance.SecurityDataSet.tblDeschidereBase.FindByID(
                    ContextUtilityClass.OnlyInstance.EvidentaID);
            ContextUtilityClass.OnlyInstance.EvidentaName = drDeschidereBase["NumeDeschidere"].ToString();
            ContextUtilityClass.OnlyInstance.DataInitializare = (DateTime)drDeschidereBase["DataInitializare"];
            ContextUtilityClass.OnlyInstance.DataDeschisa = (DateTime)drDeschidereBase["DataDeschisa"];
            ContextUtilityClass.OnlyInstance.DataInchisa = (drDeschidereBase.IsNull("DataInchisa")
                ? DateTime.MinValue
                : (DateTime)drDeschidereBase["DataInchisa"]);
            ContextUtilityClass.OnlyInstance.IsTipEvidentaBugetar = Convert.ToBoolean(drDeschidereBase["IsBugetar"]);

            // Testare Deschidere Detalii
            DataRow[] drsDeschidereDet =
                SecurityDataClass.OnlyInstance.SecurityDataSet.tblDeschidereDet.Select("DeschidereBaseID='" +
                                                                                       ContextUtilityClass.OnlyInstance
                                                                                           .EvidentaID.ToString() + "'");
            if (drsDeschidereDet.Length == 0)
            {
                XtraMessageBox.Show(
                    "Incarcarea detaliilor evidentei nu a fost posibila. Va rugam contactati un administrator.",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Get ConnectionTimeout from config
            int iConnectionTimeOut = 600;
            SqlConnection sqlConnection = new SqlConnection();
            UtilityClass uc = new UtilityClass();
            string sDBAccess = uc.GetValueNameFromConfig("DataBaseAcces");
            DataRow[] drs = mDataSet.tblConfig.Select("DataBaseName = '" + sDBAccess + "'");
            if (drs.Length > 0)
            {
                sqlConnection.ConnectionString = drs[0]["ConnectionString"].ToString();
                iConnectionTimeOut = sqlConnection.ConnectionTimeout;
            }

            // Initializare stringuri de conexiune
            foreach (DataRow drDeschidereDet in drsDeschidereDet)
            {
                DataRow drTipDataBase =
                    SecurityDataClass.OnlyInstance.SecurityDataSet.tbxTipDataBase.FindByID(
                        (Guid)drDeschidereDet["TipDataBaseID"]);
                if (drTipDataBase != null)
                {
                    switch (drTipDataBase["Abbreviation"].ToString())
                    {
                        case "1":
                            ContextUtilityClass.OnlyInstance.DataInitializareDBCurent =
                                (DateTime)drDeschidereDet["DataStart"];
                            ContextUtilityClass.OnlyInstance.DataBaseCurrentConnectionString =
                                SecurityDataClass.OnlyInstance.GetConnectionString(drDeschidereDet, iConnectionTimeOut);
                            break;

                        default:
                            break;
                    }
                }

                ////}

                // Activare conexiune catre baza de lucru
                Context.SetCurrentConnection(ContextUtilityClass.OnlyInstance.DataBaseCurrentConnectionString);

                // Regasire DataLucru
                DataRow[] drsUsersDeschidere =
                    SecurityDataClass.OnlyInstance.SecurityDataSet.lnkUsersDeschidere.Select("UsersID='" +
                                                                                             Context.UserID.ToString() +
                                                                                             "' and DeschidereID='" +
                                                                                             ContextUtilityClass
                                                                                                 .OnlyInstance
                                                                                                 .EvidentaID.ToString() +
                                                                                             "'");
                ContextUtilityClass.OnlyInstance.DataLucru =
                (drsUsersDeschidere.Length > 0
                    ? (DateTime)drsUsersDeschidere[0]["DataLucru"]
                    : ContextUtilityClass.OnlyInstance.DataDeschisa);

                SetDataLucru();

                // Incarcare Institutii
                if (!SecurityDataClass.OnlyInstance.LoadInstitutii()) return false;



            }
            return true;


        }

        private Guid GetRootForChildID(Guid pParentID)
        {
            DataRow[] drs = SecurityDataClass.OnlyInstance.SecurityDataSet.tblNavigation.Select("ID='" + pParentID.ToString() + "'");
            if (drs.Length > 0)
            {
                if (drs[0].IsNull("ParentGroupID"))
                {
                    return (Guid)drs[0]["ID"];
                }
                else
                    GetRootForChildID((Guid)drs[0]["ParentGroupID"]);
            }
            return pParentID;
        }

        private void CloseMDIChildren()
        {
            foreach (Form wndChild in this.MdiChildren)
            {
                wndChild.Close();
            }
        }

        /// <summary>
        /// Regaseste setarile din toolbar din XML.
        /// </summary>
        private void SetUsersJunk()
        {
            Utility.LoadDataSetFromXmlFile(mUsersJnkDataSet, mUsersJnkFileName, Context.UserName);
            DataRow[] drs = mUsersJnkDataSet.tblUsersJnk.Select("UserName='" + Context.UserName + "'");
            foreach (DataRow dr in drs)
            {
                if (!dr.IsNull("EvidentaID") && !Guid.Empty.Equals(dr["EvidentaID"]))
                {
                    if (SecurityDataClass.OnlyInstance.SecurityDataSet.tblDeschidereBase.FindByID((Guid)dr["EvidentaID"]) != null)
                        barEditItemEvidente.EditValue = dr["EvidentaID"];
                }
                if (!dr.IsNull("ModulID") && !Guid.Empty.Equals(dr["ModulID"]))
                {
                    if (SecurityDataClass.OnlyInstance.SecurityDataSet.tblModul.FindByID((Guid)dr["ModulID"]) != null)
                        barEditItemModul.EditValue = dr["ModulID"];
                }
                bool hasInstitutie = false;
                if (!dr.IsNull("CentruID") && !Guid.Empty.Equals(dr["CentruID"]))
                {
                    if (SecurityDataClass.OnlyInstance.SecurityDataSet.tblCentru.Select("ID='" +dr["CentruID"]+"'").Length>0)
                    {
                        barEditItemCentru.EditValue = dr["CentruID"];
                        hasInstitutie = true;
                    }
                }

            }
        }

        /// <summary>
        /// Salveaza setarile din toolbar in XML.
        /// </summary>
        private void SaveUsersJunk()
        {
            DataRow[] drs = mUsersJnkDataSet.tblUsersJnk.Select("UserName='" + Context.UserName + "'");
            if (drs.Length == 0)
            {
                DataRow drSave = mUsersJnkDataSet.tblUsersJnk.NewRow();
                drSave["UserName"] = Context.UserName;
                drSave["EvidentaID"] = ContextUtilityClass.OnlyInstance.EvidentaID;
                drSave["ModulID"] = ContextUtilityClass.OnlyInstance.ModulID;
                drSave["CentruID"] = ContextUtilityClass.OnlyInstance.GrupID;

                mUsersJnkDataSet.tblUsersJnk.Rows.Add(drSave);
            }
            else
            {
                if (barEditItemEvidente.EditValue == null)
                {
                    drs[0]["EvidentaID"] = drs[0]["ModulID"] = drs[0]["CentruID"] = DBNull.Value;
                }
                else
                {
                    drs[0]["EvidentaID"] = barEditItemEvidente.EditValue;
                    drs[0]["ModulID"] = barEditItemModul.EditValue;
                    drs[0]["CentruID"] = barEditItemCentru.EditValue;

                }
            }
            Utility.SaveDataSetToXmlFile(mUsersJnkDataSet, mUsersJnkFileName, Context.UserName);
        }

        private void SetDataLucru()
        {
            barEditItemLunaLucru.EditValue = this.repositoryItemComboBoxLunaLucru.Items[ContextUtilityClass.OnlyInstance.DataLucru.Month - 1];
            barEditItemAnLucru.EditValue = ContextUtilityClass.OnlyInstance.DataLucru.Year;
            barEditItemLunaLucru.Caption = barEditItemLunaLucru.EditValue.ToString() + "-" + barEditItemAnLucru.EditValue.ToString();
            repositoryItemSpinEditAnLucru.MinValue = ContextUtilityClass.OnlyInstance.DataInitializare.Year;

        }

        private void SaveDataLucru()
        {
            try
            {
                DataRow[] drs = SecurityDataClass.OnlyInstance.SecurityDataSet.lnkUsersDeschidere.Select("UsersID='" + Context.UserID.ToString() + "' and DeschidereID='" + ContextUtilityClass.OnlyInstance.EvidentaID.ToString() + "'");
                if (drs.Length == 0)
                {
                    DataRow dr = SecurityDataClass.OnlyInstance.SecurityDataSet.lnkUsersDeschidere.NewRow();
                    dr["ID"] = Guid.NewGuid();
                    dr["UsersID"] = Context.UserID;
                    dr["DeschidereID"] = ContextUtilityClass.OnlyInstance.EvidentaID;
                    dr["DataLucru"] = ContextUtilityClass.OnlyInstance.DataLucru;
                    SecurityDataClass.OnlyInstance.SecurityDataSet.lnkUsersDeschidere.Rows.Add(dr);
                }
                else
                {
                    if (!drs[0]["DataLucru"].Equals(ContextUtilityClass.OnlyInstance.DataLucru))
                        drs[0]["DataLucru"] = ContextUtilityClass.OnlyInstance.DataLucru;
                }
                if (SecurityDataClass.OnlyInstance.SecurityDataSet.HasChanges())
                {
                    Context.SetCurrentConnection(ContextUtilityClass.OnlyInstance.DataBaseCurrentConnectionString);
                    SecurityDataClass.OnlyInstance.SecurityController.DataSet = SecurityDataClass.OnlyInstance.SecurityDataSet;
                    SecurityDataClass.OnlyInstance.SecurityController.Perform();
                }
            }
            catch (System.Exception excep)
            {
                Utilities.Utility.Log(excep.Message);
            }
        }

        /// <summary>
        /// Fills mMonthList with the names of the 12 monthes.
        /// </summary>
        private void FillMonthList()
        {
            mMonthList.Add("IANUARIE", 1);
            mMonthList.Add("FEBRUARIE", 2);
            mMonthList.Add("MARTIE", 3);
            mMonthList.Add("APRILIE", 4);
            mMonthList.Add("MAI", 5);
            mMonthList.Add("IUNIE", 6);
            mMonthList.Add("IULIE", 7);
            mMonthList.Add("AUGUST", 8);
            mMonthList.Add("SEPTEMBRIE", 9);
            mMonthList.Add("OCTOMBRIE", 10);
            mMonthList.Add("NOIEMBRIE", 11);
            mMonthList.Add("DECEMBRIE", 12);
        }


        #endregion

        /// <summary>
        /// Actualizare aplicatia si baza de date
        /// </summary>
        public static void UpdateApplication()
        {
            try
            {
                string connectionString = TransactionManager.ConnectionString;

                bool isFirstRun = false;
                
                if (!SettingsModel.SettingsStoreExists())
                {
                    SettingsModel settings = new SettingsModel
                    {
                        UpdateApplication = false,
                        UpdateDatabase = true,
                        UpdateMirror = false,
                        UpdateTask = false,
                        UpdateInteractive = false,
                        ServiceUrl = @"http://www.grupsoft.ro/update/",
                        Notify = false,
                        SuggestedSettings = true
                    };

                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString)
                    {
                        InitialCatalog = "GS_Update"
                    };

                    settings.UpdateConnection = builder.ToString();
                    settings.Update = SettingsModel.UpdateType.Default;
                    settings.DatabaseConnections.Add(connectionString);

                    SettingsModel.SaveData(settings);

                    isFirstRun = true;
                }

                // Start update process
                string updateExecutable = Path.Combine(Application.StartupPath, "update.exe");
                if (File.Exists(updateExecutable))
                {
                    string arguments = "/a";

                    if (isFirstRun) arguments += " /f"; // To flex update

                    using (Process p = new Process
                           {
                               StartInfo = new ProcessStartInfo(updateExecutable, arguments) { UseShellExecute = false }
                           })
                    {
                        p.Start();
                    }
                }
            }
            catch { }
        }

        #endregion

        #endregion

        #region Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize();
                FillMonthList();
                IsLoading = true;
                this.Context = ClientContext.OnlyInstance;
                this.Context.MDIParent = this;
                object obj = this.Context.GetParameterValueUserContextParameterList("Logon.DataSetConfig");
                if (obj.Equals(null))
                {
                    XtraMessageBox.Show("Eroare acces configurare!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                mDataSet = (ConfigDataSet)obj;
                SetApplicationName();
                ConfigDataSet.tblUsersRow dr = (ConfigDataSet.tblUsersRow)mDataSet.tblUsers.Rows[0];
                this.Context.SetUserLogon(dr.ID, dr.UserName, dr.Nume + " " + dr.Prenume);
                this.Context.DeleteEntryFromUserContextParameterList("Logon.DataSetConfig");

                SecurityDataClass.OnlyInstance.AplicatiiID = mAplicatiiID;
                SecurityDataClass.OnlyInstance.LoadData();
                LoadRootMenu();
                ShowMenuByUserRights();
                this.barStaticItemUserDisplayName.Caption = Context.UserDisplayName;
                this.ShowInTaskbar = true;
                barEditItemModul.Enabled = false;
                this.Bind();
                SetUsersJunk();
                IsLoading = false;
                ContextUtilityClass.OnlyInstance.MainWindowHandle = this;
            }
            catch (System.Exception e)
            {
                ClientContext.OnlyInstance.HandleException(this, e);
            }
        }

        public override void Bind()
        {
            base.Bind();
            tblDeschidereBaseBindingSource.DataSource = SecurityDataClass.OnlyInstance.SecurityDataSet.tblDeschidereBase;
            tblModulBindingSource.DataSource = SecurityDataClass.OnlyInstance.SecurityDataSet.tblModul;
            tblCentruBindingSource.DataSource = new DataView(SecurityDataClass.OnlyInstance.SecurityDataSet.tblCentru);
    
        }

        #endregion

      
    }
}
