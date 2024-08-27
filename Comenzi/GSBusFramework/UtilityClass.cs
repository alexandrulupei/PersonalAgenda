using System;
using System.Data;
using System.Data.SqlClient;

namespace GSBusFramework
{
	/// <summary>
	/// Summary description for UtilityClass.
	/// </summary>
	public class UtilityClass
	{   
		#region Nested Classes
        public  class ConfigDataService : DataService
        {
            #region Private and protected Variables
            private SqlDataAdapter sqlConfigDataAdapter;
            private SqlCommand sqlSelectConfigCommand;
            private SqlCommand sqlUpdateConfigCommand;
            private SqlDataAdapter sqlResetSessionCntDataAdapter;
            private SqlCommand sqlUpdateResetSessionCntCommand;
            private string configTableName;
            #endregion

            #region Constructor
            public ConfigDataService()
            {
                InitializeComponent();

                //
                // TODO: Add any constructor code after InitializeComponent call
                //
            }
            public ConfigDataService(String pConfigTableName)
            {
                InitializeComponent();

                this.configTableName = pConfigTableName;

                setupSQLConfigCommandStrings();
                setupSQLConfigUpdateCommandStrings();
            }
            #endregion

            #region Component Designer generated code
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.sqlConfigDataAdapter = new SqlDataAdapter();
                this.sqlSelectConfigCommand =  new SqlCommand();
                this.sqlUpdateConfigCommand = new SqlCommand();

                this.sqlResetSessionCntDataAdapter = new SqlDataAdapter();                
                this.sqlUpdateResetSessionCntCommand = new SqlCommand();

                // 
                // sqlConfigDataAdapter
                // 
                this.sqlConfigDataAdapter.SelectCommand = this.sqlSelectConfigCommand;
                this.sqlConfigDataAdapter.UpdateCommand = this.sqlUpdateConfigCommand;

                // 
                // sqlResetSessionCntDataAdapter
                //                 
                this.sqlResetSessionCntDataAdapter.UpdateCommand = this.sqlUpdateResetSessionCntCommand;
            }            
            private void setupSQLConfigCommandStrings ()
            {
                this.sqlTableName = configTableName;

                String selClause = "SELECT * FROM " + configTableName;
                // 
                // sqlSelectConfigCommand
                // 
                this.sqlSelectConfigCommand.CommandText = selClause;
            }
            private void setupSQLConfigUpdateCommandStrings()
            {
                this.sqlTableName = configTableName;
                
                String updateClause = String.Empty;
                
                updateClause = "UPDATE " + configTableName + " SET SessionCnt = (SELECT sessionCnt FROM " + configTableName + " WHERE SessionID = 0) + 1";
                // 
                // sqlUpdateConfigCommand
                // 
                this.sqlUpdateConfigCommand.CommandText = updateClause;

                updateClause = "UPDATE " + configTableName + " SET SessionCnt = 0";
                // 
                // sqlUpdateResetSessionCntCommand
                // 
                this.sqlUpdateResetSessionCntCommand.CommandText = updateClause;
            }
            #endregion

            #region Public Methods
            public int GetSessionID()
            {
                int sessionID = 0;

                this.sqlTableName = configTableName;
                DataSet ds = new DataSet();
                
                try
                {
                    UpdateRowExec(ds, this.sqlConfigDataAdapter);
                }
                catch(SqlException e)
                {
					if( e.Number == 8115 ) //arithmetic overflow exception - se reseteaza sessioncnt si se porneste de la 1
					{
						UpdateRowExec(ds, this.sqlResetSessionCntDataAdapter);
						UpdateRowExec(ds, this.sqlConfigDataAdapter);
					}
                }
                
                if(ds.Tables[configTableName].Rows.Count > 0)
                {
                    sessionID = Convert.ToInt16(ds.Tables[configTableName].Rows[0]["SessionCnt"]);
                }
                return sessionID;
            }
            #endregion
        }

		#endregion

        #region Constructor
        public UtilityClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Public Methods
        #endregion
	}
}
