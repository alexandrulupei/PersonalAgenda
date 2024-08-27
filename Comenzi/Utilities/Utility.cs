using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;

namespace Utilities
{
    /// <summary>
    /// Summary description for Utility.
    /// </summary>
    public class Utility
    {
        #region Class Fields
        private const string sGridLayoutXmlFolder = @"\GridLayoutXml";
        private const string sUserSetttingsFolder = @"\UserSettingsXml";
        private const string mDateTimeFormat = "dd.mm.yyyy";
        private const string mDateTimeWithHourFormat = "dd.mm.yyyy HH:mm";
        #endregion

        #region Public Methods

        #region General
        /// <summary>
        /// Functia primeste ca parametru un obiect si stabileste daca e empty (diferit de null, DBNull, string.Empty)
        /// </summary>
        public bool IsNotObjectEmpty(object pObj)
        {
            return (pObj != null) && (pObj != DBNull.Value) && (!string.IsNullOrEmpty(pObj.ToString()));
        }

        public bool CheckCNP(string pCNP)
        {
            if (pCNP.Length != 13)
                return false;
            try
            {
                double convertedCNP = Convert.ToDouble(pCNP);
            }
            catch (FormatException)
            {
                return false;
            }

            int[] myKeysArray = new int[12] { 2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9 };
            int sum = 0;
            int rest = 0;

            for (int i = 0; i < myKeysArray.Length; i++)
            {
                sum += Convert.ToInt16(pCNP.Substring(i, 1)) * myKeysArray[i];
            }
            rest = sum % 11;
            if (rest == 10)
                rest = 1;
            if (rest.ToString() != pCNP[pCNP.Length - 1].ToString())
                return false;

            String prefixAn = String.Empty;
            if (pCNP.Substring(0, 1) == "1" || pCNP.Substring(0, 1) == "2")
            {
                prefixAn = "19";
            }
            if (pCNP.Substring(0, 1) == "3" || pCNP.Substring(0, 1) == "4")
            {
                prefixAn = "18";
            }
            if (pCNP.Substring(0, 1) == "5" || pCNP.Substring(0, 1) == "6")
            {
                prefixAn = "20";
            }

            int day;
            int mounth;
            int year;
            day = Convert.ToInt16(pCNP.Substring(5, 1) + pCNP.Substring(6, 1));
            mounth = Convert.ToInt16(pCNP.Substring(3, 1) + pCNP.Substring(4, 1));
            year = Convert.ToInt16(prefixAn + pCNP.Substring(1, 1) + pCNP.Substring(2, 1));

            try
            {
                DateTime dt;
                dt = new DateTime(year, mounth, day);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public DataRow GetSelectedRow(GridControl pGridControl)
        {
            GridView gv = (GridView)pGridControl.FocusedView;
            if (gv.FocusedRowHandle < 0)
                return null;
            return gv.GetDataRow(gv.FocusedRowHandle);
        }
        /// <summary>
        /// Selecteaza un row in gridcontrol pentru un id trimis (ID este coloana cautata)
        /// </summary>
        /// <param name="pGridView">GridView-ul</param>
        /// <param name="pID">Guid-ul dupa care se face cautarea</param>
        public void SetSelectedRowByID(GridView pGridView, Guid pID)
        {
            for (int i = 0; i < pGridView.RowCount; i++)
            {
                SetSelectedRowByCustomColumn(pGridView, pID, "ID");
            }
        }
        /// <summary>
        /// Selecteaza un row in gridcontrol pentru un Guid trimis dupa o coloana specificata
        /// </summary>
        /// <param name="pGridView">GridView-ul</param>
        /// <param name="pID">Guid-ul dupa care se face cautarea</param>
        /// <param name="pGuidColumn">Coloana dupa care se face cautarea</param>
        public void SetSelectedRowByCustomColumn(GridView pGridView, Guid pID, string pGuidColumn)
        {
            for (int i = 0; i < pGridView.RowCount; i++)
            {
                DataRow dr = pGridView.GetDataRow(i);
                if (dr != null && (Guid)dr[pGuidColumn] == pID)
                {
                    pGridView.FocusedRowHandle = i;
                    return;
                }
            }
        }
        public bool DeleteConfirmation()
        {
            if (XtraMessageBox.Show("Sunteti siguri ca doriti sa stergeti aceasta inregistrare?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return false;
            return true;
        }
        /// <summary>
        /// Returneaza daca un ID intr-o tabela cu coloane de tipul ID, IDParinte este frunza sau nu.
        /// </summary>
        /// <param name="id">ID-ul din tabela</param>
        /// <param name="table">Tabela</param>
        /// <returns></returns>
        public bool IsLeafID(Guid pID, DataTable pTable)
        {
            if (IsLeafID(pID, pTable, "IDParinte"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Returneaza daca un ID intr-o tabela gen ID,IDParinte este frunza sau nu.
        /// </summary>
        /// <param name="id">ID-ul din tabela</param>
        /// <param name="table">Tabela</param>
        /// <param name="pIDParinteColumnName">Numele coloanei IDParinte</param>
        /// <returns></returns>
        public bool IsLeafID(Guid pID, DataTable pTable, string pIDParinteColumnName)
        {
            string sSelect = pIDParinteColumnName + " = '" + pID.ToString() + "'";
            if (pTable.Columns.Contains("IsActive"))
                sSelect += " and IsActive=true";
            DataRow[] dr = pTable.Select(sSelect);
            if (dr.Length > 0)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Returneaza true daca "(IsActive = 1) AND (DataStart <= pDataLucru) AND (ISNULL(DataStop, DATEADD(MONTH, 1, pDataLucru)) > pDataLucru)"
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="pTable"></param>
        /// <param name="pDataLucru"></param>
        /// <returns></returns>
        public bool IsValidInLunaDeLucru(Guid pID, DataTable pTable, DateTime pDataLucru)
        {
            DataRow[] drs = pTable.Select("ID = '" + pID.ToString() + "'");
            if (drs.Length > 0)
            {
                if ((bool)drs[0]["IsActive"] == false)
                    return false;
                //if ((DateTime)drs[0]["DataStart"] <= pDataLucru)
                //{
                //    DateTime dtStop;
                //    if (!drs[0].IsNull("DataStop"))
                //        dtStop = (DateTime)drs[0]["DataStop"];
                //    else
                //        dtStop = pDataLucru.AddMonths(1);
                //    if (dtStop > pDataLucru)
                //        return true;
                //    else
                //        return false;
                //}
                //else
                //    return false;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckCIF(string pCIF)
        {
            Decimal mProdus = 0;
            ArrayList mKey = new ArrayList();
            mKey.Add(2); mKey.Add(3);
            mKey.Add(5); mKey.Add(7);
            mKey.Add(1); mKey.Add(2);
            mKey.Add(3); mKey.Add(5); mKey.Add(7);

            pCIF = pCIF.Trim();
            int mLn = pCIF.Length;
            if (mLn > 10)
                return false;
            try
            {
                double convertedCIF = Convert.ToDouble(pCIF);
            }
            catch (FormatException)
            {
                return false;
            }
            ArrayList mCIF = new ArrayList();
            for (int i = 0; i <= mLn - 2; i++)
                mCIF.Add(Convert.ToInt16(pCIF.Substring((mLn - 2 - i), 1)));
            for (int i = 0; i <= mLn - 2; i++)
                mProdus += Convert.ToInt16(mCIF[i]) * Convert.ToInt16(mKey[i]);
            mProdus = mProdus * 10;
            mProdus = mProdus % 11;
            if (mProdus == 10)
                mProdus = 0;
            if (mProdus != Convert.ToInt16(pCIF.Substring(mLn - 1, 1)))
                return false;

            return true;
        }
        /// <summary>
        /// Returneaza true daca Contul/capitolul/articolul pChildID este egal sau fiu al pParentID
        /// </summary>
        /// <param name="pTable"></param>
        /// <param name="pParentID"></param>
        /// <param name="pChildID"></param>
        /// <returns></returns>
        public bool IsChildOF(DataTable pTable, Guid pParentID, Guid pChildID)
        {
            if (pParentID == pChildID)
            {
                return true;
            }
            else
            {
                DataRow dr = pTable.Rows.Find(pChildID);
                if ((dr != null) && (dr["IDParinte"] != DBNull.Value))
                    return IsChildOF(pTable, pParentID, new Guid(dr["IDParinte"].ToString()));
                else
                    return false;
            }
        }
        /// <summary>
        /// Returneaza string-ul de conexiune functie de datele din tblDeschidereDet cu timeout 100
        /// </summary>
        /// <param name="pDeschidereDetRow">[DataRow] row-ul din tblDeschidereDet</param>
        /// <returns>[string] strinng-ul de conexiune ce poate fi trimis framework-ului</returns>
        public string GetConnectionString(DataRow pDeschidereDetRow)
        {
            return GetConnectionString(pDeschidereDetRow, 100);
        }
        /// <summary>
        /// Returneaza string-ul de conexiune functie de datele din tblDeschidereDet cu timeout specificat
        /// </summary>
        /// <param name="pDeschidereDetRow">[DataRow] row-ul din tblDeschidereDet</param>
        /// <param name="pConnectionTimeOut">[int] timeout</param>
        /// <returns>[string] strinng-ul de conexiune ce poate fi trimis framework-ului</returns>
        public string GetConnectionString(DataRow pDeschidereDetRow, int pConnectionTimeOut)
        {
            return GetConnectionString(pDeschidereDetRow, pConnectionTimeOut, true);
        }
        public string GetConnectionString(DataRow pDeschidereDetRow, int pConnectionTimeOut, bool pUseServerName)
        {
            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
            if (pDeschidereDetRow["ServerName"] != DBNull.Value)
            {
                if (pUseServerName)
                    connectionBuilder.DataSource = pDeschidereDetRow["ServerName"].ToString();
                else
                    connectionBuilder.DataSource = pDeschidereDetRow["ServerNameLocal"].ToString();
            }
            if (pDeschidereDetRow["DataBaseName"] != DBNull.Value)
                connectionBuilder.InitialCatalog = pDeschidereDetRow["DataBaseName"].ToString();

            int tipAutentificare = 0;
            string user = "", parola = "";
            if (pDeschidereDetRow["TipAutentificare"] != DBNull.Value)
                tipAutentificare = Convert.ToInt32(pDeschidereDetRow["TipAutentificare"]);
            if (pDeschidereDetRow["UserNameServer"] != DBNull.Value)
                user = pDeschidereDetRow["UserNameServer"].ToString();
            if (pDeschidereDetRow["PaswordServer"] != DBNull.Value)
                parola = pDeschidereDetRow["PaswordServer"].ToString();

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

        public void GetChildrensID(DataTable pTable, Guid pParentID, ref string sContIDs)
        {
            DataRow[] dr = pTable.Select("IDParinte='" + pParentID.ToString() + "'");
            for (int i = 0; i < dr.Length; i++)
            {
                sContIDs = sContIDs + ", '" + dr[i]["ID"].ToString() + "'";
                GetChildrensID(pTable, new Guid(dr[i]["ID"].ToString()), ref sContIDs);
            }
        }

        /// <summary>
        /// Verifica daca obiectul este null, DBNull sau string.Empty
        /// </summary>
        public static bool Empty(object pObject)
        {
            return pObject == null || pObject.Equals(DBNull.Value) || pObject.ToString().Equals(string.Empty);
        }

        #endregion

        #region Format repositories
        public void SetDateTimeFormatFromConfig(DateEdit pDateEdit)
        {
            string sDateFormat = GetDateTimeFormatFromConfig();

            DateEditMaskProperties dateEditMask = new DateEditMaskProperties();
            dateEditMask.MaskType = MaskType.DateTime;
            dateEditMask.EditMask = sDateFormat;

            FormatInfo formatInfo = new FormatInfo();
            formatInfo.FormatType = FormatType.DateTime;
            formatInfo.FormatString = sDateFormat;

            pDateEdit.Properties.Mask.Assign(dateEditMask);
            pDateEdit.Properties.EditFormat.Assign(formatInfo);
            pDateEdit.Properties.DisplayFormat.Assign(formatInfo);
        }
        public void SetDateTimeFormatFromConfig(RepositoryItemDateEdit pRepositoryDateEdit)
        {
            string sDateFormat = GetDateTimeFormatFromConfig();

            DateEditMaskProperties dateEditMask = new DateEditMaskProperties();
            dateEditMask.MaskType = MaskType.DateTime;
            dateEditMask.EditMask = sDateFormat;

            FormatInfo formatInfo = new FormatInfo();
            formatInfo.FormatType = FormatType.DateTime;
            formatInfo.FormatString = sDateFormat;

            pRepositoryDateEdit.Mask.Assign(dateEditMask);
            pRepositoryDateEdit.EditFormat.Assign(formatInfo);
            pRepositoryDateEdit.DisplayFormat.Assign(formatInfo);
        }
        public void SetNumericMask(RepositoryItemTextEdit pRepositoryItemTextEdit, int pNrZecimale, int pNrIntregi, bool pCuSeparator)
        {
            string NumericFormat = string.Empty;
            string GeneralFormat = string.Empty;
            this.FormatString(pNrZecimale, pNrIntregi, pCuSeparator, ref  NumericFormat, ref  GeneralFormat);

            MaskProperties mask = new MaskProperties();
            mask.MaskType = MaskType.Numeric;
            mask.EditMask = NumericFormat;
            mask.UseMaskAsDisplayFormat = true;

            pRepositoryItemTextEdit.Mask.Assign(mask);
        }
        public void SetNumericMask(RepositoryItemTextEdit pRepositoryItemTextEdit, int pNrZecimale, bool pCuSeparator)
        {
            SetNumericMask(pRepositoryItemTextEdit, pNrZecimale, 12, pCuSeparator);
        }
        public string GetFormatStringNumeric(int pNrZecimale, int pNrIntregi, bool pCuSeparator)
        {
            string NumericFormat = string.Empty;
            string GeneralFormat = string.Empty;
            this.FormatString(pNrZecimale, pNrIntregi, pCuSeparator, ref  NumericFormat, ref  GeneralFormat);
            return NumericFormat;
        }
        public string GetFormatStringNumeric(int pNrZecimale, bool pCuSeparator)
        {
            return GetFormatStringNumeric(pNrZecimale, 12, pCuSeparator);
        }
        public string GetFormatString(int pNrZecimale, int pNrIntregi, bool pCuSeparator)
        {
            string NumericFormat = string.Empty;
            string GeneralFormat = string.Empty;
            this.FormatString(pNrZecimale, pNrIntregi, pCuSeparator, ref  NumericFormat, ref  GeneralFormat);
            return GeneralFormat;
        }
        public string GetFormatString(int pNrZecimale, bool pCuSeparator)
        {
            return GetFormatString(pNrZecimale, 12, pCuSeparator);
        }
        public void FormatString(int pNrZecimale, bool pCuSeparator, ref string pNumericFormat, ref string pGeneralFormat)
        {
            if (pCuSeparator)
            {
                pNumericFormat = "n" + pNrZecimale.ToString(); ;
            }
            else
            {
                pNumericFormat = "f" + pNrZecimale.ToString(); ;
            }
            pGeneralFormat = "{0:" + pNumericFormat + "}";
        }
        public void FormatString(int pNrZecimale, int pNrIntregi, bool pCuSeparator,
            ref string pNumericFormat, ref string pGeneralFormat)
        {
            string tmpString = string.Empty;
            for (int i = 0; i < pNrIntregi - 1; i++)
            {
                tmpString += "#";
            }
            if (pCuSeparator)
            {
                tmpString += ",";
            }
            tmpString += "0";

            string tmpZecString = string.Empty;
            for (int i = 0; i < pNrZecimale; i++)
            {
                tmpZecString += "0";
            }
            if (tmpZecString.Equals(string.Empty))
            {
                pNumericFormat = tmpString;
            }
            else
            {
                pNumericFormat = tmpString + "." + tmpZecString;
            }
            pGeneralFormat = "{0:" + pNumericFormat + "}";
        }
        #endregion

        #region Format textedit
        public void SetNumericMask(TextEdit pTextEdit, int pNrZecimale, int pNrIntregi, bool pCuSeparator)
        {
            string NumericFormat = string.Empty;
            string GeneralFormat = string.Empty;
            this.FormatString(pNrZecimale, pNrIntregi, pCuSeparator, ref  NumericFormat, ref  GeneralFormat);

            MaskProperties mask = new MaskProperties();
            mask.MaskType = MaskType.Numeric;
            mask.EditMask = NumericFormat;
            mask.UseMaskAsDisplayFormat = true;

            pTextEdit.Properties.Mask.Assign(mask);
        }
        public void SetNumericMask(TextEdit pTextEdit, int pNrZecimale, bool pCuSeparator)
        {
            SetNumericMask(pTextEdit, pNrZecimale, 12, pCuSeparator);
        }
        #endregion
        /// <summary>
        /// Diferenta in luni dintre doua date.
        /// </summary>
        /// <param name="startDate">StartDate</param>
        /// <param name="endDate">StopDate</param>
        /// <returns></returns>
        public int monthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public void AccessSuportGrupSoft()
        {
            string sGSSupport = "GS_TeamViewer.exe";
            if (File.Exists(sGSSupport))
                Process.Start(sGSSupport);
            else
                XtraMessageBox.Show("Nu aveti instalata aplicatia necesara pentru a accesa dispeceratul Grup Soft!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Salveaza mesajele de eroare int-un fisier log GD_Error.log
        /// Fisierul se va gasi in calea curenta unde se afla executabilul instalat
        /// </summary>
        /// <param name="logMessage">Mesajul de eroare</param>
        public static void Log(String logMessage)
        {
            StreamWriter w = File.AppendText("GS_ErrorLog.log");
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine(":");
            w.WriteLine(":{0}", logMessage);
            w.WriteLine("-------------------------------");
            // Update the underlying file.
            w.Flush();
            w.Close();
        }
        /// <summary>
        /// Control-ul ce trebuie adus in fata. Se foloseste in general pentru error provider
        /// Ex: Utilities.Utility.BringErrorToFront(this.txtNume); - unde txtNume este un control pe un tab
        /// </summary>
        /// <param name="control">Control-ul ce se aduce in fata</param>
        public static void BringErrorToFront(Control control)
        {
            Control ctrl = control.Parent;
            if (ctrl == null)
                return;
            if (ctrl.GetType() == typeof(TabPage))
            {
                ((TabControl)((TabPage)ctrl).Parent).SelectedTab = (TabPage)ctrl;
            }
            else if (ctrl.GetType() != typeof(Form))
                BringErrorToFront(ctrl);
        }
        /// <summary>
        /// pentru xtraTabcontrol
        /// </summary>
        /// <param name="control"></param>
        public static void BringErrorToFrontDevEx(Control control)
        {
            Control ctrl = control.Parent;
            if (ctrl == null)
                return;
            if (ctrl.GetType() == typeof(XtraTabPage))
            {
                ((XtraTabControl)((XtraTabPage)ctrl).Parent).SelectedTabPage = (XtraTabPage)ctrl;
            }
            else if (ctrl.GetType() != typeof(Form))
                BringErrorToFrontDevEx(ctrl);
        }
        /// <summary>
        /// Salvarea setarilor unui DevExpress.XtraGrid in format XML
        /// </summary>
        /// <param name="pGridControl">[DevExpress.XtraGrid.GridControl] gridControl</param>
        /// <param name="oThis">[object] this</param>
        /// <param name="pUserName">[string] username</param>
        public static void SaveGridLayoutToXml(GridControl pGridControl, object oThis, string pUserName)
        {
            SaveGridLayoutToXml(pGridControl, oThis, pUserName, string.Empty);
        }
        public static void SaveGridLayoutToXml(GridControl pGridControl, object oThis, string pUserName, string pReportName)
        {
            try
            {
                if (oThis == null)
                    return;
                if (pGridControl == null)
                    return;

                Type objType = oThis.GetType();
                string sFileToSave;
                string sAssemblyName = objType.FullName;
                string sStartupPath = Application.StartupPath;
                string sPath = sStartupPath + sGridLayoutXmlFolder;
                if (!Directory.Exists(sPath))
                    Directory.CreateDirectory(sPath);
                sPath += @"\" + pUserName + pReportName;
                if (!Directory.Exists(sPath))
                    Directory.CreateDirectory(sPath);

                //OptionsLayoutGrid opts = new OptionsLayoutGrid();
                //opts.Columns.StoreAllOptions = true;

                foreach (GridView gv in pGridControl.ViewCollection)
                {
                    sFileToSave = sPath + @"\" + sAssemblyName + gv.Name + ".xml";
                    gv.SaveLayoutToXml(sFileToSave);
                }
            }
            catch (Exception excep)
            {
                Log("Eroare salvare grid layout! Eroarea este: \n" + excep.Message);
            }
        }
        /// <summary>
        /// Restore DevExpress.XtraGrid din format-ul XML salvat prin metoda SaveGridLayoutToXml
        /// </summary>
        /// <param name="pGridControl">[DevExpress.XtraGrid.GridControl] gridControl</param>
        /// <param name="oThis">[object] this</param>
        /// <param name="pUserName">[string] username</param>
        public static void RestoreGridLayoutFromXml(GridControl pGridControl, object oThis, string pUserName)
        {
            RestoreGridLayoutFromXml(pGridControl, oThis, pUserName, string.Empty);
        }
        public static void RestoreGridLayoutFromXml(GridControl pGridControl, object oThis, string pUserName, string pReportName)
        {
            try
            {
                if (oThis == null)
                    return;
                if (pGridControl == null)
                    return;
                Type objType = oThis.GetType();
                string sFileToLoad;
                string sAssemblyName = objType.FullName;
                string sStartupPath = Application.StartupPath;
                string sPath = sStartupPath + sGridLayoutXmlFolder + @"\" + pUserName + pReportName;
                if (!Directory.Exists(sPath))
                    return;
                //OptionsLayoutGrid opts = new OptionsLayoutGrid();
                //opts.Columns.RemoveOldColumns = true;
                //opts.Columns.AddNewColumns = true;
                //opts.Columns.StoreAllOptions = true;

                foreach (GridView gv in pGridControl.ViewCollection)
                {
                    sFileToLoad = sPath + @"\" + sAssemblyName + gv.Name + ".xml";
                    if (File.Exists(sFileToLoad))
                        gv.RestoreLayoutFromXml(sFileToLoad);
                }
            }
            catch (Exception excep)
            {
                Log("Eroare incarcare fisier grid layout! Eroarea este: \n" + excep.Message);
            }
        }
        public static void DeleteGridLayoutXml(GridControl pGridControl, object oThis, string pUserName)
        {
            try
            {
                if (oThis == null)
                    return;
                if (pGridControl == null)
                    return;
                Type objType = oThis.GetType();
                string sFileToLoad;
                string sAssemblyName = objType.FullName;
                string sStartupPath = Application.StartupPath;
                string sPath = sStartupPath + sGridLayoutXmlFolder + @"\" + pUserName;
                if (!Directory.Exists(sPath))
                    return;
                foreach (GridView gv in pGridControl.ViewCollection)
                {
                    sFileToLoad = sPath + @"\" + sAssemblyName + gv.Name + ".xml";
                    if (File.Exists(sFileToLoad))
                        File.Delete(sFileToLoad);
                }
            }
            catch (Exception excep)
            {
                Log("Eroare stergere fisier grid layout! Eroarea este: \n" + excep.Message);
            }
        }
        public static void DeleteGridLayoutDirectory(string pUserName)
        {
            try
            {
                string sStartupPath = Application.StartupPath;
                string sPath = sStartupPath + sGridLayoutXmlFolder + @"\" + pUserName;
                if (!Directory.Exists(sPath))
                    return;
                Directory.Delete(sPath, true);
            }
            catch (Exception excep)
            {
                Log("Eroare stergere fisier grid layout! Eroarea este: \n" + excep.Message);
            }
        }
        public static void SaveDataSetToXmlFile(DataSet pDataSet, string pFileName, string pUserName)
        {
            SaveDataSetToXmlFile(pDataSet, pFileName, pUserName, XmlWriteMode.IgnoreSchema);
        }
        public static void SaveDataSetToXmlFile(DataSet pDataSet, string pFileName, string pUserName, XmlWriteMode pWriteMode)
        {
            try
            {
                if (pDataSet == null)
                    return;
                string sStartupPath = Application.StartupPath;
                string sPath = sStartupPath + sUserSetttingsFolder;
                if (!Directory.Exists(sPath))
                    Directory.CreateDirectory(sPath);
                sPath += @"\" + pUserName;
                if (!Directory.Exists(sPath))
                    Directory.CreateDirectory(sPath);
                sPath += @"\" + pFileName;
                pDataSet.WriteXml(sPath, pWriteMode);
            }
            catch (Exception excep)
            {
                Log("Eroare salvare dataset in xml! Eroarea este: \n" + excep.Message);
            }
        }
        public static void LoadDataSetFromXmlFile(DataSet pDataSet, string pFileName, string pUserName)
        {
            LoadDataSetFromXmlFile(pDataSet, pFileName, pUserName, XmlReadMode.Auto);
        }
        public static void LoadDataSetFromXmlFile(DataSet pDataSet, string pFileName, string pUserName, XmlReadMode pReadMode)
        {
            try
            {

                if (pDataSet == null)
                    return;
                string sStartupPath = Application.StartupPath;
                string sPath = sStartupPath + @"\" + sUserSetttingsFolder + @"\" + pUserName; ;
                if (!Directory.Exists(sPath))
                    return;
                sPath += @"\" + pFileName;
                if (File.Exists(sPath))
                    pDataSet.ReadXml(sPath, pReadMode);
            }
            catch (Exception excep)
            {
                Log("Eroare incarcare dataset in xml! Eroarea este: \n" + excep.Message);
                //throw (excep);
            }
        }
        public static string GetDateTimeFormatFromConfig()
        {
            try
            {
                AppSettingsReader appSettingsReader = new AppSettingsReader();
                String mValue = (String)appSettingsReader.GetValue("DateFormat", Type.GetType("System.String"));
                return (mValue);
            }
            catch (Exception excep)
            {
                Log(excep.Message);
                return mDateTimeFormat;
            }
        }
        public static string GetDateTimeWithHourFormatFromConfig()
        {
            try
            {
                AppSettingsReader appSettingsReader = new AppSettingsReader();
                String mValue = (String)appSettingsReader.GetValue("DateFormatWithHour", Type.GetType("System.String"));
                return (mValue);
            }
            catch (Exception excep)
            {
                Log(excep.Message);
                return mDateTimeWithHourFormat;
            }
        }

        /// <summary>
        /// Returneaza cifrele dintr-un sir de caractere (compus din cifre si litere), pana la intalnirea primului caracter care nu este numeric
        /// </summary>
        /// <param name="camp">sirul de caractere ce va fi convertit</param>
        /// <returns></returns>
        public static decimal ConvertStringToNr(string pCamp)
        {
            int Contor = 0;
            int N = 0;
            string Nr = "";
            pCamp = pCamp.Trim();
            if ((pCamp == string.Empty) || (pCamp == null))
            {
                return 0;
            }
            else
            {
                N = pCamp.Length;
                pCamp = pCamp.Replace('.', 'A');
                pCamp = pCamp.Replace('-', 'A');
                pCamp = pCamp.Replace(',', 'A');
                pCamp = pCamp.Replace('+', 'A');
                pCamp = pCamp.Replace('/', 'A');
                pCamp = pCamp.Replace('%', 'A');
                pCamp = pCamp.Replace('^', 'A');

                while (Contor < N)
                {
                    try
                    {
                        Nr = Nr + Convert.ToString(Convert.ToInt16(pCamp.Substring(Contor, 1)));
                        Contor = Contor + 1;
                    }
                    catch (Exception)
                    {
                        if (Nr == "")
                        {
                            Nr = "0";
                        }
                        Contor = N + 1;
                    }
                }
                try
                {
                    return Convert.ToDecimal(Nr);
                }
                catch (InvalidCastException e)
                {
                    MessageBox.Show(e.ToString());
                    throw;
                }

            }
        }
        public static string GetCodJudetDefault()
        {
            try
            {
                AppSettingsReader appSettingsReader = new AppSettingsReader();
                String mValue = (String)appSettingsReader.GetValue("CodJudetDefault", Type.GetType("System.String"));
                return mValue;
            }
            catch (Exception excep)
            {
                Log(excep.Message);
                return string.Empty;
            }
        }
        /// <summary>
        /// Cast generic
        /// </summary>
        /// <typeparam name="T">Tipul anonim la care se doreste cast-ul</typeparam>
        /// <param name="o">Obiectul pentru care se realizeaza cast-ul</param>
        /// <param name="tip">Tipul anonim la care se doreste cast-ul</param>
        /// <returns>Obiectul convertit la tipul T</returns>
        public static T Cast<T>(object o, T tip) where T : class
        {
            return o as T;
        }
        #endregion

        #region Convert Numar To Litere
        public static String ConvertNrToLitere(double pNr)
        {
            String retStr = String.Empty;
            String NrCZ = string.Empty;
            String[] TA = new String[8];
            TA[0] = "unmiliard";
            TA[1] = "miliarde";
            TA[2] = "unmilion";
            TA[3] = "milioane";
            TA[4] = "omie";
            TA[5] = "mii";
            TA[6] = "unu";
            TA[7] = "";
            NrCZ = pNr.ToString();
            NrCZ = pNr.ToString().PadLeft(12, '0');
            if (pNr < Math.Pow(10, 12))
            {
                for (int i = 1; i <= 4; i++)
                {
                    retStr += MMM(i, NrCZ, TA);
                }
            }
            return retStr;
        }
        private static String MMM(int i, String NrC, String[] TA)
        {
            String retStr = String.Empty;
            int j, k;
            j = (i - 1) * 3;
            k = (i - 1) * 2;
            if (NrC.Substring(j, 1).Equals("0") && NrC.Substring(j + 1, 1).Equals("0"))
            {
                if (NrC.Substring(j + 2, 1).Equals("1"))
                    retStr += TA[k];
                if (NrC.Substring(j + 2, 1) != "0" && NrC.Substring(j + 2, 1) != "1")
                {
                    retStr += SZU(Convert.ToInt16(NrC.Substring(j, 1)), Convert.ToInt16(NrC.Substring(j + 1, 1)),
                        Convert.ToInt16(NrC.Substring(j + 2, 1)), i);
                    retStr += TA[k + 1];
                }
            }
            else
            {
                retStr += SZU(Convert.ToInt16(NrC.Substring(j, 1)), Convert.ToInt16(NrC.Substring(j + 1, 1)),
                    Convert.ToInt16(NrC.Substring(j + 2, 1)), i);
                if (i != 4 && !(NrC.Substring(j + 1, 1) != "[01]"))
                {
                    retStr += "de";
                }
                retStr += TA[k + 1];
            }
            return retStr;
        }
        public static String ConvertNrToLitereRON(decimal pNr, bool baniInCifre)
        {
            String retStr = String.Empty;
            String[] TA = new String[8];
            TA[0] = "unmiliard";
            TA[1] = "miliarde";
            TA[2] = "unmilion";
            TA[3] = "milioane";
            TA[4] = "unamie";
            TA[5] = "mii";
            TA[6] = "unu";
            TA[7] = "";
            if (pNr < 0)
            {
                retStr = "minus ";
                pNr = -pNr;
            }

            int lei = Convert.ToInt32(Math.Truncate(pNr));
            if (pNr < Convert.ToDecimal(Math.Pow(10, 12)))
            {
                for (int i = 3; i >= 0; i--)
                {
                    retStr += MMM(i, ref pNr, TA);
                }
            }
            if (lei == 1)
                retStr += "leu";
            else if (lei == 0)
                retStr += "";
            else
                retStr += "lei";
            int bani = Convert.ToInt32(Math.Truncate(pNr * 100));
            if (bani != 0)
            {
                if (baniInCifre)
                {
                    retStr += ",";

                    if (bani == 1)
                        retStr += bani.ToString() + "ban";
                    else
                        retStr += bani.ToString() + "bani";
                }
                else
                {
                    decimal dBani = Convert.ToDecimal(bani);
                    retStr += "si";
                    retStr += MMM(0, ref dBani, TA);
                    if (bani == 1)
                        retStr += "ban";
                    else
                        retStr += "bani";
                }
            }
            return retStr;
        }
        public static String ConvertNrToLitereRON(decimal pNr)
        {
            return ConvertNrToLitereRON(pNr, false);
        }
        private static String MMM(int i, ref decimal NrC, String[] TA)
        {
            String retStr = String.Empty;
            int j, k;
            j = i * 3;
            k = (3 - i) * 2;
            int s = 0, z = 0, U = 0;
            s = Convert.ToInt32(Math.Truncate(NrC / Convert.ToDecimal(Math.Pow(10, j + 2))));
            if (s != 0)
                NrC -= Convert.ToDecimal(Math.Pow(10, j + 2)) * s;
            z = Convert.ToInt32(Math.Truncate(NrC / Convert.ToDecimal(Math.Pow(10, j + 1))));
            if (z != 0)
                NrC -= Convert.ToDecimal(Math.Pow(10, j + 1)) * z;

            U = Convert.ToInt32(Math.Truncate(NrC / Convert.ToDecimal(Math.Pow(10, j))));
            if (U != 0)
                NrC -= Convert.ToDecimal(Math.Pow(10, j)) * U;


            if (s == 0 && z == 0)
            {
                if (U == 1)
                    retStr += TA[k];
                if (U != 0 && U != 1)
                {
                    retStr += SZU(s, z, U, i + 4);
                    retStr += TA[k + 1];
                }
            }
            else
            {
                retStr += SZU(s, z, U, i + 4);
                if (i != 0)
                {
                    //retStr += "de";
                }
                retStr += TA[k + 1];
            }
            return retStr;
        }
        private static String SZU(int s, int z, int U, int i)
        {
            String retStr = String.Empty;
            String[] Scr = new String[10];
            Scr[0] = "";
            Scr[1] = "unu";
            Scr[2] = "doua";
            Scr[3] = "trei";
            Scr[4] = "patru";
            Scr[5] = "cinci";
            Scr[6] = "sase";
            Scr[7] = "sapte";
            Scr[8] = "opt";
            Scr[9] = "noua";

            //Analiza sute
            switch (s)
            {
                case 0:
                    break;
                case 1:
                    retStr += "unasuta";
                    break;
                default:
                    retStr += Scr[s] + "sute";
                    break;
            }
            //Analiza zeci
            switch (z)
            {
                case 0:
                    switch (U)
                    {
                        case 1:
                            retStr += Scr[U];
                            break;
                        case 2:
                            retStr += (i == 4 ? "doi" : Scr[U]);
                            break;
                        default:
                            retStr += Scr[U];
                            break;
                    }
                    break;
                case 1:
                    switch (U)
                    {
                        case 0:
                            break;
                        case 1:
                            retStr += "unspre";
                            break;
                        case 2:
                            retStr += (i == 4 ? "doi" : Scr[2]) + "spre";
                            break;
                        default:
                            retStr += Scr[U] + "spre";
                            break;
                    }
                    retStr += "zece";
                    break;
                default:
                    retStr += Scr[z] + "zeci";
                    if (U != 0)
                    {
                        retStr += "si";
                        switch (U)
                        {
                            case 1:
                                retStr += "unu";
                                break;
                            case 2:
                                retStr += (i == 4 ? "doi" : "doua");
                                break;
                            default:
                                retStr += Scr[U];
                                break;
                        }
                    }
                    break;
            }
            return retStr;

        }
        #endregion

        #region Validari
        public static bool ValidateIban(string iban)
        {
            if (iban.Trim() == string.Empty)        // iban gol
                return false;

            if (iban.Trim().Contains(" "))          // iban cu spatii
                return false;

            if (iban.Trim().Length != 24)           // lungime diferita de 24 de caractere
                return false;

            iban = iban.ToUpper();
            Dictionary<char, int> coduriLitere = new Dictionary<char, int>() 
            {
                {'A', 10},
                {'B', 11},
                {'C', 12},
                {'D', 13},
                {'E', 14},
                {'F', 15},
                {'G', 16},
                {'H', 17},
                {'I', 18},
                {'J', 19},
                {'K', 20},
                {'L', 21},
                {'M', 22},
                {'N', 23},
                {'O', 24},
                {'P', 25},
                {'Q', 26},
                {'R', 27},
                {'S', 28},
                {'T', 29},
                {'U', 30},
                {'V', 31},
                {'W', 32},
                {'X', 33},
                {'Y', 34},
                {'Z', 35}
            };

            StringBuilder pas1 = new StringBuilder();                   // pasul 1, se muta primele 4 caractere la dreapta codului IBAN
            pas1.Append(iban.Substring(4, iban.Length - 4));            
            pas1.Append(iban.Substring(0, 4));

            StringBuilder pas2 = new StringBuilder();                   // pasul 2, se face conversia literelor in numere
            foreach (char caracter in pas1.ToString().ToCharArray())
            {
                if (char.IsLetter(caracter))
                    pas2.Append(coduriLitere[caracter].ToString());
                else
                    pas2.Append(caracter);
            }

            long pas3 = 0;                                              // pasul 3, rezultatul impartirii numarului obtinut la 97 trebuie sa fie 1
            for (int i = 0; i < pas2.ToString().Length; i++)
            {
                long digit = pas2.ToString()[i] - '0';
                pas3 = ((pas3 * 10) + digit) % 97;
            }

            if (pas3 != 1)
                return false;
            return true;
        }
        #endregion
    }


    public enum TipBalantaStocuri { ANALITICA, SINTETICA, PECONTURI };

    public struct Constante
    {
        public const string TOATE_CAPITOLE = "--Toate capitolele--";
        public const string DEN_TOATE_SURSELE = "--Toate sursele--";
        public const string COD_TOATE_SURSELE = "00";
    }

    public enum TipBalantaContabilitate { SINTETICA = 0, ANALITICA = 1, ANALITICASINTETICA = 2, SINTETICA2 = 3, SINTETICA3 = 4 };
}
