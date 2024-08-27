using System;
using GSBusFramework;

namespace GSProxy
{
	/// <summary>
	/// Proxy pentru realizarea legaturii dintre GSFramework si GSBusFramework
	/// </summary>
	public class GSConnections
    {
        #region Properties
        public string CurrentConnection
        {
            get { return TransactionManager.ReadOnlyConnectionString; }
        }
        #endregion

        #region Public Methods
        public static void SetCurrentConnection(String pConnection)
        {
            TransactionManager.ReadOnlyConnectionString = pConnection;
        }
        public static void SetCurrentSqlConnection(System.Data.SqlClient.SqlConnection pSqlConnection)
        {
            TransactionManager.CurrentConnection = pSqlConnection;
        }
        public static void SetCurrentSqlConnectionToNull()
        {
            TransactionManager.CurrentConnection = null;
        }
        public static System.Data.SqlClient.SqlConnection GetCurrentConnection()
        {
            return TransactionManager.ReadOnlyConnection;
        }
        public static int GetCurrentSessionID(String pConfigTableName)
        {
            int sessionID = 0;

            UtilityClass.ConfigDataService configDataSvc = new GSBusFramework.UtilityClass.ConfigDataService(pConfigTableName);
            sessionID = configDataSvc.GetSessionID();

            return sessionID;
        }
        #endregion
    }
}
