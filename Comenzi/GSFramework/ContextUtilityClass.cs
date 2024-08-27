using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace GSFramework
{
    public class ContextUtilityClass
    {
        #region Constructor
        public ContextUtilityClass()
        {
        }
        #endregion

        #region Class Fields
        private static ContextUtilityClass mOnlyInstance = null;
        private ClientContext Context = ClientContext.OnlyInstance;
      
        private string mDataBaseCurrentConnectionString;
  

        private DateTime mDataLucru = new DateTime(2017, 01, 01);
        private DateTime mDataDeschisa;
        private DateTime mDataInchisa;
        private DateTime mDataInitializare;
        private DateTime mDataInitializareDBCurent;
        private string mEvidentaName;
        private bool mIsTipEvidentaBugetar = false;
        private Guid mEvidentaID;
        private Guid mGrupID;
        private Guid mInstitutieID;
        private Guid mInstitutieIDDest;
        private Guid mMapID;
        private Guid mModulID;
        private Guid mAplicatiiID;
        private Guid mAplicatieExternaIDITx;
        private Guid mAplicatieExternaIDSalnet;
        private string mModulName;
        private string mModulCod;
        private static String mDateFormat;
        private static String mDateWithHourFormat;
        private Guid mMonedaID;
        private string mMonedaSimbol;
        private string mMonedaDenumire;
        private const string mUserNameSystem = "master";
        private int mNrZecimaleCtb = 2;
        private object mMainWindowHandle;
        private bool mGenereazaExecutieTVA = true;
        private string mCodInstitutie = string.Empty;
        private string mDenumireInstitutie = string.Empty;
        private string mCUI = string.Empty;
        private string mAdresa = string.Empty;
        private Dictionary<string, string> mGSComenziParams = new Dictionary<string, string>();
        private string mSursaFinantareInstitutie;   // old school
        private string mSursaFinantare;             // new school
        #endregion

        #region Properties
        public static ContextUtilityClass OnlyInstance
        {
            get
            {
                if (mOnlyInstance == null)
                {
                    mOnlyInstance = new ContextUtilityClass();
                    mDateFormat = Utilities.Utility.GetDateTimeFormatFromConfig();
                    mDateWithHourFormat = Utilities.Utility.GetDateTimeWithHourFormatFromConfig();
                }
                return mOnlyInstance;
            }
            set
            {
                mOnlyInstance = value;
            }
        }
        public string CUI
        {
            set
            {
                mCUI = value;
            }
            get
            {
                return mCUI;
            }
        }
        public string Adresa
        {
            set
            {
                mAdresa = value;
            }
            get
            {
                return mAdresa;
            }
        }
        public string CodInstitutie
        {
            get { return mCodInstitutie; }
            set { mCodInstitutie = value; }
        }
        public string DenumireInstitutie
        {
            get { return mDenumireInstitutie; }
            set { mDenumireInstitutie = value; }
        }
    
        public DateTime DataLucru
        {
            get { return mDataLucru; }
            set { mDataLucru = value; }
        }
        public DateTime DataDeschisa
        {
            get { return mDataDeschisa; }
            set { mDataDeschisa = value; }
        }
        public DateTime DataInchisa
        {
            get { return mDataInchisa; }
            set { mDataInchisa = value; }
        }
        public DateTime DataInitializare
        {
            get { return mDataInitializare; }
            set { mDataInitializare = value; }
        }
        public DateTime DataInitializareDBCurent
        {
            get { return mDataInitializareDBCurent; }
            set { this.mDataInitializareDBCurent = value; }
        }
        public Guid EvidentaID
        {
            get { return mEvidentaID; }
            set { mEvidentaID = value; }
        }
        public string EvidentaName
        {
            get { return mEvidentaName; }
            set { mEvidentaName = value; }
        }
        public bool IsTipEvidentaBugetar
        {
            set { this.mIsTipEvidentaBugetar = value; }
            get { return this.mIsTipEvidentaBugetar; }
        }
        public Guid ModulID
        {
            get { return mModulID; }
            set { mModulID = value; }
        }
        public string ModulName
        {
            set { this.mModulName = value; }
            get { return this.mModulName; }
        }
        public string ModulCod
        {
            set { mModulCod = value; }
            get { return this.mModulCod; }
        }
        public Guid GrupID
        {
            get { return mGrupID; }
            set { mGrupID = value; }
        }
        public Guid CentruID
        {
            get { return mInstitutieID; }
            set { mInstitutieID = value; }
        }
        public Guid InstitutieIDDest
        {
            get { return mInstitutieIDDest; }
            set { mInstitutieIDDest = value; }
        }
        public Guid MapID
        {
            get { return mMapID; }
            set { mMapID = value; }
        }
        public String DateFormat
        {
            get { return mDateFormat; }
        }
        public String DateWithHourFormat
        {
            get { return mDateWithHourFormat; }
        }
        public Guid AplicatiiID
        {
            set { this.mAplicatiiID = value; }
            get { return this.mAplicatiiID; }
        }
       
        public string UserNameSystem
        {
            get { return mUserNameSystem; }
        }
        public int NrZecimaleCtb
        {
            get { return mNrZecimaleCtb; }
            set { this.mNrZecimaleCtb = value; }
        }
        public object MainWindowHandle
        {
            set { this.mMainWindowHandle = value; }
            get { return mMainWindowHandle; }
        }
        public bool GenereazaExecutieTVA
        {
            set { this.mGenereazaExecutieTVA = value; }
            get { return this.mGenereazaExecutieTVA; }
        }
        public Guid AplicatieExternaIDITx
        {
            set { this.mAplicatieExternaIDITx = (Guid)value; }
            get { return this.mAplicatieExternaIDITx; }
        }
        public Guid AplicatieExternaIDSalnet
        {
            set { this.mAplicatieExternaIDSalnet = (Guid)value; }
            get { return this.mAplicatieExternaIDSalnet; }
        }
        public Dictionary<string, string> GSComenziParams
        {
            set { this.mGSComenziParams = value; }
            get { return this.mGSComenziParams; }
        }

        /// <summary>
        /// SursaFinantare in the Old School.
        /// </summary>
        public string SursaFinantareInstitutie
        {
            set { this.mSursaFinantareInstitutie = value; }
            get { return this.mSursaFinantareInstitutie; }
        }

        /// <summary>
        /// Sector in the New School is the same as SursaFinantareInstitutie in the Old School
        /// </summary>
        public string Sector
        {
            get { return SursaFinantareInstitutie; }
        }

        /// <summary>
        /// Sursa Finantare in the New School.
        /// </summary>
        public string SursaFinantare
        {
            set { mSursaFinantare = value; }
            get { return mSursaFinantare; }
        }

        public string DataBaseCurrentConnectionString
        {
            get { return mDataBaseCurrentConnectionString; }
            set { mDataBaseCurrentConnectionString = value; }
        }
        #endregion

        #region Public Methods
        public void LoadMoneda()
        {
            string sCurrentConnection = new GSProxy.GSConnections().CurrentConnection;
            try
            {
                GSProxy.GSConnections.SetCurrentConnection(this.mDataBaseCurrentConnectionString);
                GSProxy.AppSpecificProxyHelperClass gsProxy = new GSProxy.AppSpecificProxyHelperClass();
               
            }
            catch
            {
            }
            finally
            {
                GSProxy.GSConnections.SetCurrentConnection(sCurrentConnection);
            }

        }
        #endregion
    }

}