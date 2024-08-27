using System;
using System.Data;
using GSBusFramework;
using System.Data.SqlClient;

namespace LookupTableManagement
{
    /// <summary>
    /// Summary description for LookupTableBusSvc.
    /// </summary>
    public class LookupTableBusSvc : System.MarshalByRefObject
    {
        static LookupTableResult emptyResult = new LookupTableResult();

        #region Nested Classes
        public  class LookupDataService : GSBusFramework.DataService
        {
            #region Class Members
            protected System.Data.SqlClient.SqlConnection sqlConnection1;
            protected System.Data.SqlClient.SqlDataAdapter sqlGetDataAdapter;
            protected System.Data.SqlClient.SqlDataAdapter sqlListDataAdapter;
            protected System.Data.SqlClient.SqlDataAdapter sqlListByDescDataAdapter;
            protected System.Data.SqlClient.SqlDataAdapter sqlListByAbbrevDataAdapter;
            protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
            protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
            protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
            protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
            protected System.Data.SqlClient.SqlDataAdapter sqlListForDescDataAdapter;
            protected System.Data.SqlClient.SqlDataAdapter sqlListForAbbrevDataAdapter;
            protected System.Data.SqlClient.SqlDataAdapter sqlListForDescAbbrevDataAdapter;
            protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
            protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
            protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
            protected System.Data.SqlClient.SqlDataAdapter sqlListForAscOrderedAbbrevDescDataAdapter;
            protected System.Data.SqlClient.SqlDataAdapter sqlListForAscOrderedDescAbbrevDataAdapter;
            protected System.Data.SqlClient.SqlDataAdapter sqlListForDescOrderedDescAbbrevDataAdapter;
            protected System.Data.SqlClient.SqlDataAdapter sqlListForDescOrderedAbbrevDescDataAdapter;
            protected System.Data.SqlClient.SqlCommand sqlSelectAscOrderedAbbrevDescCommand;
            protected System.Data.SqlClient.SqlCommand sqlSelectAscOrderedDescAbbrevCommand;
            protected System.Data.SqlClient.SqlCommand sqlSelectDescOrderedDescAbbrevCommand;
            protected System.Data.SqlClient.SqlCommand sqlSelectDescOrderedAbbrevDescCommand;
            protected System.Data.SqlClient.SqlDataAdapter sqlListAscOrderedCustomColDataAdapter;
            protected System.Data.SqlClient.SqlDataAdapter sqlListDescOrderedCustomColDataAdapter;
            protected System.Data.SqlClient.SqlCommand sqlSelectAscOrderedCustColCommand;
            protected System.Data.SqlClient.SqlCommand sqlSelectDescOrderedCustColCommand;
            protected System.Data.SqlClient.SqlDataAdapter sqlSelectCustomFilterDataAdapter;
            protected System.Data.SqlClient.SqlCommand sqlSelectCustomFilterCommand;
            private System.Data.SqlClient.SqlDataAdapter sqlDataAdapterNomenclatoare;
            private System.Data.SqlClient.SqlCommand sqlInsertCommandNomenclatoare;
            private System.Data.SqlClient.SqlCommand sqlUpdateCommandNomenclatoare;
            private System.Data.SqlClient.SqlCommand sqlDeleteCommandNomenclatoare;
            
            private System.Data.SqlClient.SqlDataAdapter sqlDataAdapterCustomSqlQuery;
            private System.Data.SqlClient.SqlCommand sqlSelectCommandCustomSqlQuery;

            private SqlCommandBuilder sqlCB;
            public String customColumn;
            protected String dbTableName;
            public String customColumnFilter;
            public String customSqlQuery;
            #endregion

            #region Public & Protected Methods
            public LookupDataService(System.ComponentModel.IContainer container)
            {
                /// <summary>
                /// Required for Windows.Forms Class Composition Designer support
                /// </summary>
                // container.Add(this);
                InitializeComponent();

                //
                // TODO: Add any constructor code after InitializeComponent call
                //
                setupDataService ();
            }
            public LookupDataService ()
            {
                /// <summary>
                /// Required for Windows.Forms Class Composition Designer support
                /// </summary>
                InitializeComponent ();
                setupDataService ();
            }
            public void IntializeLookupDataService (String lookupTableName)
            {
                setupSQLCommandStrings (lookupTableName);
            }
            public void InitiliazeUpdateLookupDataService(String lookupTableName)
            {
                setupSQLUpdateCommandStrings(lookupTableName);
            }
            public virtual bool GetRow (LookupTableManagement.LookupTableDataSet userDataSet, Guid lookupID)
            {
                System.Collections.IList keyList = new System.Collections.ArrayList ();
                keyList.Add (new FilterInfo ("@LookupID", lookupID,
                    FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
                return (GetRow (userDataSet, keyList, this.sqlGetDataAdapter));
            }
            public virtual bool GetRow (LookupTableManagement.LookupTableDataSet userDataSet, String lookupStr, bool lookupByDesc)
            {
                System.Collections.IList keyList = new System.Collections.ArrayList ();
                keyList.Add (new FilterInfo ("@LookupStr", lookupStr, FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL));
                return (GetRow (userDataSet, keyList,
                    lookupByDesc ? this.sqlListByDescDataAdapter : this.sqlListByAbbrevDataAdapter));
            }
            public virtual bool GetList (LookupTableManagement.LookupTableDataSet userDataSet)
            {
                return (GetList (userDataSet, this.sqlListDataAdapter));
            }
            public virtual bool GetList (LookupTableManagement.LookupTableDataSet userDataSet, bool orderByDescription )
            {
                return (GetList (userDataSet, orderByDescription ? this.sqlListForDescDataAdapter : this.sqlListForAbbrevDataAdapter));
            }
            public virtual bool GetList (LookupTableManagement.LookupTableDataSet userDataSet, bool orderByAbbreviationDescription, bool ascending )
            {
                if( orderByAbbreviationDescription )
                {
                    return (GetList (userDataSet, ascending ? this.sqlListForAscOrderedAbbrevDescDataAdapter : this.sqlListForDescOrderedAbbrevDescDataAdapter));
                }
                else
                {
                    return (GetList (userDataSet, ascending ? this.sqlListForAscOrderedDescAbbrevDataAdapter : this.sqlListForDescOrderedDescAbbrevDataAdapter));
                }
            }
            public virtual bool GetList ( DataSet userDataSet, bool orderByAbbreviationDescription, bool ascending )
            {
                if( orderByAbbreviationDescription )
                {
                    return (GetList (userDataSet, ascending ? this.sqlListForAscOrderedAbbrevDescDataAdapter : this.sqlListForDescOrderedAbbrevDescDataAdapter));
                }
                else
                {
                    return (GetList (userDataSet, ascending ? this.sqlListForAscOrderedDescAbbrevDataAdapter : this.sqlListForDescOrderedDescAbbrevDataAdapter));
                }
            }
            public virtual bool GetList ( DataSet userDataSet, bool orderByDescription )
            {
                return (GetList (userDataSet, orderByDescription ? this.sqlListForDescDataAdapter : this.sqlListForAbbrevDataAdapter));
            }
            public virtual bool GetRow (DataSet userDataSet, Guid lookupID)
            {
                System.Collections.IList keyList = new System.Collections.ArrayList ();
                keyList.Add (new FilterInfo ("@LookupID", lookupID,
                    FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
                return (GetRow (userDataSet, keyList, this.sqlGetDataAdapter));
            }
            public virtual bool GetRow (DataSet userDataSet, String lookupStr, bool lookupByDesc)
            {
                System.Collections.IList keyList = new System.Collections.ArrayList ();
                keyList.Add (new FilterInfo ("@LookupStr", lookupStr,
                    FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL));
                return (GetRow (userDataSet, keyList,
                    lookupByDesc ? this.sqlListByDescDataAdapter : this.sqlListByAbbrevDataAdapter));
            }
            public virtual bool GetRow (DataSet userDataSet, string pCategory, string pDescription )
            {
                System.Collections.IList keyList = new System.Collections.ArrayList ();
                keyList.Add (new FilterInfo ("@Abbreviation", pCategory,
                    FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL));
                keyList.Add (new FilterInfo ("@Description", pDescription,
                    FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL));
                return ( GetRow ( userDataSet, keyList, this.sqlListForDescAbbrevDataAdapter ));
            }
            public virtual bool GetList (DataSet userDataSet)
            {
                return (GetList (userDataSet, this.sqlListDataAdapter));
            }
            public virtual bool GetList ( DataSet userDataSet, String lookupStr, bool lookupByDesc, int startingFrom, int numberOfRows )
            {
                try
                {
                    System.Collections.IList keyList = new System.Collections.ArrayList ();
                    if( lookupByDesc )
                    {
                        keyList.Add (new FilterInfo ("Description", lookupStr,
                            FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_LIKE_STARTWITH_NOREGEXP ));
                        return ( GetList ( userDataSet, startingFrom, numberOfRows, keyList, this.sqlListForDescDataAdapter ) );
                    }
                    else
                    {
                        keyList.Add (new FilterInfo ("Abbreviation", lookupStr,
                            FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_LIKE_STARTWITH_NOREGEXP ));
                        return ( GetList ( userDataSet, startingFrom, numberOfRows, keyList, this.sqlListForAbbrevDataAdapter ) );
                    }
                }
                catch
                {
                    throw;
                }

            }
            public virtual bool GetList ( DataSet userDataSet, String lookupCol, bool ascending )
            {
                return (GetList (userDataSet, ascending ? this.sqlListAscOrderedCustomColDataAdapter : this.sqlListDescOrderedCustomColDataAdapter));
            }
            public virtual bool GetList ( DataSet userDataSet, String pCustomColumnFilter)
            {
                return GetList(userDataSet, this.sqlSelectCustomFilterDataAdapter );
            }
            public virtual bool GetCustomList (DataSet userDataSet, String sqlQuery)
            {
                return GetList(userDataSet, this.sqlDataAdapterCustomSqlQuery );
            }
            public virtual bool UpdateLookup( DataSet userDataSet )
            {
                try
                {
                    AdapterList viewDataAdapters = new AdapterList();
                    this.sqlDataAdapterNomenclatoare.SelectCommand.CommandText = "select * from "+this.sqlTableName;
                    viewDataAdapters[this.sqlTableName] = sqlDataAdapterNomenclatoare;
                    DoCommandBuilder(this.sqlDataAdapterNomenclatoare);
                    if (!UpdateDS (userDataSet, viewDataAdapters))
                        return false;
                    return true;
                }
                catch
                {
                    throw;
                }
            }
            protected override void setupDataService ()
            {
                this.sqlTableName = "LookupTable";
            }

            private void DoCommandBuilder(SqlDataAdapter sqlDataAdapter)
            {
                sqlCB = new SqlCommandBuilder(sqlDataAdapter);
                sqlCB.QuotePrefix = "[";
                sqlCB.QuoteSuffix = "]";
            }
            #endregion
			
            #region Component Designer generated code
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>

            private void setupSQLCommandStrings (String lookupTableName)
            {
                this.sqlTableName = lookupTableName;
                String selClause =	"SELECT * FROM " + lookupTableName;
				
                String fetchActive = String.Empty;
                String fetchActiveAnd = String.Empty;
                String fetchActiveWhere = String.Empty;
                if( mFetchActive )
                {
                    fetchActive = " (IsActive = 1) ";
                    fetchActiveAnd = " and (IsActive = 1) ";
                    fetchActiveWhere = " WHERE (IsActive = 1) ";
                }
                // 
                // sqlSelectCommand1
                // 
                this.sqlSelectCommand1.CommandText = selClause + " WHERE (ID = @LookupID) " + fetchActiveAnd;
                // 
                // sqlSelectCommand2
                // 
                this.sqlSelectCommand2.CommandText = selClause + fetchActiveWhere;
                // 
                // sqlSelectCommand3
                // 
                this.sqlSelectCommand3.CommandText = selClause + " WHERE (Description = @LookupStr)" + fetchActiveAnd + " ORDER BY Description";
                // 
                // sqlSelectCommand4
                // 
                this.sqlSelectCommand4.CommandText = selClause + " WHERE (Abbreviation = @LookupStr)" + fetchActiveAnd + " ORDER BY Abbreviation";
                // 
                // sqlSelectCommand5
                // 
                this.sqlSelectCommand5.CommandText = selClause + fetchActiveWhere + " ORDER BY Description";
                // 
                // sqlSelectCommand6
                // 
                this.sqlSelectCommand6.CommandText = selClause + fetchActiveWhere + " ORDER BY Abbreviation";
                // 
                // sqlSelectCommand7
                // 
                this.sqlSelectCommand7.CommandText = selClause + " WHERE (Description = @Description) AND (Abbreviation = @Abbreviation) " + fetchActiveAnd + " ORDER BY Description";
                //
                // sqlSelectAscOrderedAbbrevDescCommand
                //
                sqlSelectAscOrderedAbbrevDescCommand.CommandText = selClause + fetchActiveWhere + " ORDER BY Abbreviation, Description ASC";
                //
                // sqlSelectAscOrderedAbbrevDescCommand
                //
                sqlSelectAscOrderedDescAbbrevCommand.CommandText = selClause + fetchActiveWhere + " ORDER BY Description, Abbreviation ASC";
                //
                // sqlSelectAscOrderedAbbrevDescCommand
                //
                sqlSelectDescOrderedDescAbbrevCommand.CommandText = selClause + fetchActiveWhere + " ORDER BY Abbreviation, Description DESC";
                //
                // sqlSelectAscOrderedAbbrevDescCommand
                //
                sqlSelectDescOrderedAbbrevDescCommand.CommandText = selClause + fetchActiveWhere + " ORDER BY Description, Abbreviation DESC";
                //
                // sqlSelectAscOrderedCustColCommand
                //
                sqlSelectAscOrderedCustColCommand.CommandText = selClause + fetchActiveWhere + " ORDER BY " + customColumn +" ASC";
                //
                // sqlSelectDescOrderedCustColCommand
                //
                sqlSelectDescOrderedCustColCommand.CommandText = selClause + fetchActiveWhere + " ORDER BY " + customColumn +" DESC";
                //
                // sqlSelectCustomFilterCommand
                //
                sqlSelectCustomFilterCommand.CommandText = selClause + " WHERE " + customColumnFilter + fetchActiveAnd;
                //
                // sqlSelectCommandCustomSqlQuery
                //
                sqlSelectCommandCustomSqlQuery.CommandText = this.customSqlQuery;

            }
            private void setupSQLUpdateCommandStrings(String lookupTableName)
            {
                this.sqlTableName = lookupTableName;
//                // 
//                // sqlInsertCommandNomenclatoare
//                // 
//                this.sqlInsertCommandNomenclatoare.CommandText = @"INSERT INTO "+lookupTableName+" (Abbreviation, Description, IsActive,  ExpirationDate) VALUES ( @Abbreviation, @Description, @IsActive,  @ExpirationDate); SELECT ID, Abbreviation, Description, IsActive, EffectiveDate, ExpirationDate FROM "+lookupTableName+" WHERE (ID = @ID)";
//                this.sqlInsertCommandNomenclatoare.Connection = this.sqlConnection1;
//                this.sqlInsertCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
//                this.sqlInsertCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Abbreviation", System.Data.SqlDbType.VarChar, 50, "Abbreviation"));
//                this.sqlInsertCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 50, "Description"));
//                this.sqlInsertCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 1, "IsActive"));
//                //this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EffectiveDate", System.Data.SqlDbType.DateTime, 8, "EffectiveDate"));
//                this.sqlInsertCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExpirationDate", System.Data.SqlDbType.DateTime, 8, "ExpirationDate"));
//                // 
//                // sqlUpdateCommand1
//                // 
//                this.sqlUpdateCommandNomenclatoare.CommandText = @"UPDATE "+lookupTableName+" SET ID = @ID, Abbreviation = @Abbreviation, Description = @Description, IsActive = @IsActive, EffectiveDate = @EffectiveDate, ExpirationDate = @ExpirationDate WHERE (ID = @Original_ID) AND (Abbreviation = @Original_Abbreviation OR @Original_Abbreviation IS NULL AND Abbreviation IS NULL) AND (Description = @Original_Description) AND (EffectiveDate = @Original_EffectiveDate) AND (ExpirationDate = @Original_ExpirationDate OR @Original_ExpirationDate IS NULL AND ExpirationDate IS NULL) AND (IsActive = @Original_IsActive); SELECT ID, Abbreviation, Description, IsActive, EffectiveDate, ExpirationDate FROM "+lookupTableName+" WHERE (ID = @ID)";
//                this.sqlUpdateCommandNomenclatoare.Connection = this.sqlConnection1;
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Abbreviation", System.Data.SqlDbType.VarChar, 50, "Abbreviation"));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 50, "Description"));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 1, "IsActive"));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EffectiveDate", System.Data.SqlDbType.DateTime, 8, "EffectiveDate"));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExpirationDate", System.Data.SqlDbType.DateTime, 8, "ExpirationDate"));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Abbreviation", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Abbreviation", System.Data.DataRowVersion.Original, null));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Description", System.Data.DataRowVersion.Original, null));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EffectiveDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EffectiveDate", System.Data.DataRowVersion.Original, null));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExpirationDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ExpirationDate", System.Data.DataRowVersion.Original, null));
//                this.sqlUpdateCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null));
//                // 
//                // sqlDeleteCommand1
//                // 
//                this.sqlDeleteCommandNomenclatoare.CommandText = @"DELETE FROM "+lookupTableName+" WHERE (ID = @Original_ID) AND (Abbreviation = @Original_Abbreviation OR @Original_Abbreviation IS NULL AND Abbreviation IS NULL) AND (Description = @Original_Description) AND (EffectiveDate = @Original_EffectiveDate) AND (ExpirationDate = @Original_ExpirationDate OR @Original_ExpirationDate IS NULL AND ExpirationDate IS NULL) AND (IsActive = @Original_IsActive)";
//                this.sqlDeleteCommandNomenclatoare.Connection = this.sqlConnection1;
//                this.sqlDeleteCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
//                this.sqlDeleteCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Abbreviation", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Abbreviation", System.Data.DataRowVersion.Original, null));
//                this.sqlDeleteCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Description", System.Data.DataRowVersion.Original, null));
//                this.sqlDeleteCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EffectiveDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EffectiveDate", System.Data.DataRowVersion.Original, null));
//                this.sqlDeleteCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExpirationDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ExpirationDate", System.Data.DataRowVersion.Original, null));
//                this.sqlDeleteCommandNomenclatoare.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null));
            }
            protected virtual void InitializeComponent()
            {
                this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
                this.sqlGetDataAdapter =
                    new System.Data.SqlClient.SqlDataAdapter();
                this.sqlSelectCommand1 =
                    new System.Data.SqlClient.SqlCommand();
                this.sqlListDataAdapter =
                    new System.Data.SqlClient.SqlDataAdapter();
                this.sqlSelectCommand2 =
                    new System.Data.SqlClient.SqlCommand();
                this.sqlListByDescDataAdapter =
                    new System.Data.SqlClient.SqlDataAdapter();
                this.sqlSelectCommand3 =
                    new System.Data.SqlClient.SqlCommand();
                this.sqlListByAbbrevDataAdapter =
                    new System.Data.SqlClient.SqlDataAdapter();
                this.sqlSelectCommand4 =
                    new System.Data.SqlClient.SqlCommand();

                this.sqlListForDescDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlListForAbbrevDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                sqlListForDescAbbrevDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
                this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
                this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
                this.sqlSelectAscOrderedAbbrevDescCommand = new System.Data.SqlClient.SqlCommand();
                this.sqlSelectAscOrderedDescAbbrevCommand = new System.Data.SqlClient.SqlCommand();
                this.sqlSelectDescOrderedDescAbbrevCommand = new System.Data.SqlClient.SqlCommand();
                this.sqlSelectDescOrderedAbbrevDescCommand = new System.Data.SqlClient.SqlCommand();
                this.sqlSelectAscOrderedCustColCommand =  new System.Data.SqlClient.SqlCommand();
                this.sqlSelectDescOrderedCustColCommand =  new System.Data.SqlClient.SqlCommand();
                this.sqlListForAscOrderedAbbrevDescDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlListForAscOrderedDescAbbrevDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlListForDescOrderedDescAbbrevDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlListForDescOrderedAbbrevDescDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlListAscOrderedCustomColDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlListDescOrderedCustomColDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlSelectCustomFilterDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlSelectCustomFilterCommand = new System.Data.SqlClient.SqlCommand();
            
                this.sqlDataAdapterNomenclatoare = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlInsertCommandNomenclatoare = new System.Data.SqlClient.SqlCommand();
                this.sqlUpdateCommandNomenclatoare = new System.Data.SqlClient.SqlCommand();
                this.sqlDeleteCommandNomenclatoare = new System.Data.SqlClient.SqlCommand();

                this.sqlDataAdapterCustomSqlQuery = new System.Data.SqlClient.SqlDataAdapter();
                this.sqlSelectCommandCustomSqlQuery = new System.Data.SqlClient.SqlCommand();
                // 
                // sqlConnection1
                // 
                this.sqlConnection1.ConnectionString =
                    "data source=NHA-DEV;initial catalog=ODVA;password=sqlsa;" +
                    "persist security info=True;user id=sa;workstation " +
                    "id=KMTP600;packet size=4096;enlist=false";
                // 
                // sqlDataAdapter1
                // 
                this.sqlGetDataAdapter.SelectCommand = this.sqlSelectCommand1;
                // 
                // sqlSelectCommand1
                // 
                this.sqlSelectCommand1.Connection = this.sqlConnection1;
                this.sqlSelectCommand1.Parameters.Add(
                    new System.Data.SqlClient.SqlParameter("@LookupID",
                    System.Data.SqlDbType.UniqueIdentifier, 16,
                    System.Data.ParameterDirection.Input, false,
                    ((System.Byte)(0)), ((System.Byte)(0)), "ID",
                    System.Data.DataRowVersion.Current, null));
                // 
                // sqlListDataAdapter
                // 
                this.sqlListDataAdapter.SelectCommand = this.sqlSelectCommand2;

                // 
                // sqlSelectCommand2
                // 
                this.sqlSelectCommand2.Connection = this.sqlConnection1;
                // 
                // sqlListByDescDataAdapter
                // 
                this.sqlListByDescDataAdapter.SelectCommand = this.sqlSelectCommand3;

                // 
                // sqlSelectCommand3
                // 
                this.sqlSelectCommand3.Connection = this.sqlConnection1;
                this.sqlSelectCommand3.Parameters.Add(
                    new System.Data.SqlClient.SqlParameter("@LookupStr",
                    System.Data.SqlDbType.VarChar, 50,
                    System.Data.ParameterDirection.Input, true,
                    ((System.Byte)(0)), ((System.Byte)(0)), "Description",
                    System.Data.DataRowVersion.Current, null));

                // 
                // sqlListByAbbrevDataAdapter
                //
                this.sqlListByAbbrevDataAdapter.SelectCommand = this.sqlSelectCommand4;

                // 
                // sqlSelectCommand4
                // 
                this.sqlSelectCommand4.Connection = this.sqlConnection1;
                this.sqlSelectCommand4.Parameters.Add(
                    new System.Data.SqlClient.SqlParameter("@LookupStr",
                    System.Data.SqlDbType.VarChar, 15,
                    System.Data.ParameterDirection.Input, true,
                    ((System.Byte)(0)), ((System.Byte)(0)), "Abbreviation",
                    System.Data.DataRowVersion.Current, null));
                //
                // sqlListForDescDataAdapter
                //
                this.sqlListForDescDataAdapter.SelectCommand = this.sqlSelectCommand5;
                //
                // sqlSelectCommand5
                //
                this.sqlSelectCommand5.Connection = this.sqlConnection1;
                //
                // sqlListForAbbrevDataAdapter
                //
                this.sqlListForAbbrevDataAdapter.SelectCommand = this.sqlSelectCommand6;
                //
                // sqlSelectCommand6
                //
                this.sqlSelectCommand6.Connection = this.sqlConnection1;
                //
                // sqlListForDescAbbrevDataAdapter
                //
                this.sqlListForDescAbbrevDataAdapter.SelectCommand = this.sqlSelectCommand7;
                //
                // sqlSelectCommand7
                //
                this.sqlSelectCommand7.Connection = this.sqlConnection1;
                this.sqlSelectCommand7.Parameters.Add(
                    new System.Data.SqlClient.SqlParameter("@Abbreviation",
                    System.Data.SqlDbType.VarChar, 100,
                    System.Data.ParameterDirection.Input, true,
                    ((System.Byte)(0)), ((System.Byte)(0)), "Abbreviation",
                    System.Data.DataRowVersion.Current, null));
                this.sqlSelectCommand7.Parameters.Add(
                    new System.Data.SqlClient.SqlParameter("@Description",
                    System.Data.SqlDbType.VarChar, 256,
                    System.Data.ParameterDirection.Input, true,
                    ((System.Byte)(0)), ((System.Byte)(0)), "Description",
                    System.Data.DataRowVersion.Current, null));
                this.sqlListForAscOrderedAbbrevDescDataAdapter.SelectCommand = this.sqlSelectAscOrderedAbbrevDescCommand;
                this.sqlListForAscOrderedDescAbbrevDataAdapter.SelectCommand = this.sqlSelectAscOrderedDescAbbrevCommand;
                this.sqlListForDescOrderedDescAbbrevDataAdapter.SelectCommand = this.sqlSelectDescOrderedDescAbbrevCommand;
                this.sqlListForDescOrderedAbbrevDescDataAdapter.SelectCommand = this.sqlSelectDescOrderedAbbrevDescCommand;
                this.sqlSelectAscOrderedAbbrevDescCommand.Connection = this.sqlConnection1;
                this.sqlSelectAscOrderedDescAbbrevCommand.Connection = this.sqlConnection1;
                this.sqlSelectDescOrderedDescAbbrevCommand.Connection = this.sqlConnection1;
                this.sqlSelectDescOrderedAbbrevDescCommand.Connection = this.sqlConnection1;
                this.sqlListAscOrderedCustomColDataAdapter.SelectCommand = this.sqlSelectAscOrderedCustColCommand;
                this.sqlListDescOrderedCustomColDataAdapter.SelectCommand = this.sqlSelectDescOrderedCustColCommand;
                this.sqlSelectAscOrderedCustColCommand.Connection = this.sqlConnection1;
                this.sqlSelectDescOrderedCustColCommand.Connection = this.sqlConnection1;
                this.sqlSelectCustomFilterCommand.Connection = this.sqlConnection1;
                this.sqlSelectCustomFilterDataAdapter.SelectCommand = this.sqlSelectCustomFilterCommand;
            
                this.sqlDataAdapterCustomSqlQuery.SelectCommand = this.sqlSelectCommandCustomSqlQuery;
                // 
                // sqlDataAdapterNomenclatoare 
                // 
                this.sqlDataAdapterNomenclatoare.SelectCommand = this.sqlSelectCommand2;
//                this.sqlDataAdapterNomenclatoare.DeleteCommand = this.sqlDeleteCommandNomenclatoare;
//                this.sqlDataAdapterNomenclatoare.InsertCommand = this.sqlInsertCommandNomenclatoare;
//                this.sqlDataAdapterNomenclatoare.UpdateCommand = this.sqlUpdateCommandNomenclatoare;

            }
            #endregion

            #region Private Members
            private bool mFetchActive = false;
            #endregion

            #region Public Properties
            /// <summary>
            /// Semnaleaza incarcarea randurilor pentru care coloana IsActive = 1
            /// </summary>
            public bool FetchActive
            {
                set
                {
                    mFetchActive = value;
                }
            }
            #endregion
        }

        [Serializable()]
            public class LookupTableResult
        {
            #region Member Variables
            private Guid mKey;
            private String mAbbreviation;
            private String mDescription;
            #endregion

            #region Properties
            public Guid Key 
            {
                get 
                {
                    return mKey;
                }
            }
            public String Abbreviation 
            {
                get 
                {
                    return mAbbreviation;
                }
            }
            internal String sAbbreviation
            {
                set
                {
                    mAbbreviation = value;
                }
            }
            public String Description 
            {
                get 
                {
                    return mDescription;
                }
            }
            internal String sDescription 
            {
                set
                {
                    mDescription = value;
                }
            }
            #endregion

            #region Constructors
            public LookupTableResult ()
            {
            }
            internal LookupTableResult (String tableName, Guid id)
            {
                LookupTableManagement.LookupTableDataSet lookupDS = new LookupTableManagement.LookupTableDataSet ();
                LookupDataService dataSvc = new LookupDataService ();
                dataSvc.IntializeLookupDataService (tableName);
                if (id != Guid.Empty && dataSvc.GetRow (lookupDS, id))
                {
                    if (lookupDS.Tables[tableName].Rows[0].Table.Columns.Contains ("ID"))
                    {
                        mKey = ( Guid ) lookupDS.Tables[tableName].Rows[0]["ID"];
                    }
                    if (lookupDS.Tables[tableName].Rows[0].Table.Columns.Contains ("Abbreviation"))
                    {
                        mAbbreviation = ( string ) (lookupDS.Tables[tableName].Rows[0].IsNull( "Abbreviation" ) ?
                            string.Empty : lookupDS.Tables[tableName].Rows[0]["Abbreviation"]);
                    }
                    if (lookupDS.Tables[tableName].Rows[0].Table.Columns.Contains ("Description"))
                    {
                        mDescription = ( string ) (lookupDS.Tables[tableName].Rows[0].IsNull( "Description" ) ?
                            string.Empty : lookupDS.Tables[tableName].Rows[0]["Description"]);
                    }
                }
                else
                {
                    mKey = id;
                    if (id != Guid.Empty)
                    {
                        mAbbreviation = "Not Found";
                        mDescription = "Lookup Key <" + id.ToString () + "> was not found.";
                    }
                    else
                    {
                        mAbbreviation = "";
                        mDescription = "";
                    }
                }
                dataSvc.Dispose ();
            }
            internal LookupTableResult (String tableName, String lookupStr,	bool lookupByDescription)
            {
                LookupTableManagement.LookupTableDataSet lookupDS = new LookupTableManagement.LookupTableDataSet ();
                LookupDataService dataSvc = new LookupDataService ();
                dataSvc.IntializeLookupDataService (tableName);
                if (dataSvc.GetRow (lookupDS, lookupStr, lookupByDescription))
                {
                    if (lookupDS.Tables[tableName].Rows[0].Table.Columns.Contains ("ID"))
                    {
                        mKey = ( Guid ) lookupDS.Tables[tableName].Rows[0]["ID"];
                    }
                    if (lookupDS.Tables[tableName].Rows[0].Table.Columns.Contains ("Abbreviation"))
                    {
                        mAbbreviation = ( string ) (lookupDS.Tables[tableName].Rows[0].IsNull( "Abbreviation" ) ?
                            string.Empty : lookupDS.Tables[tableName].Rows[0]["Abbreviation"]);
                    }
                    if (lookupDS.Tables[tableName].Rows[0].Table.Columns.Contains ("Description"))
                    {
                        mDescription = ( string ) (lookupDS.Tables[tableName].Rows[0].IsNull( "Description" ) ?
                            string.Empty : lookupDS.Tables[tableName].Rows[0]["Description"]);
                    }
                }
                else
                {
                    mKey = Guid.Empty;
                    if (lookupStr != null && lookupStr != "")
                    {
                        mAbbreviation = "Not Found";
                        mDescription = "Lookup Description: <" + lookupStr + "> was not found.";
                    }
                    else
                    {
                        mAbbreviation = "";
                        mDescription = "";
                    }
                }
                dataSvc.Dispose ();
            }
            internal LookupTableResult ( string tableName, string pCategory, string pDescription )
            {
                LookupTableManagement.LookupTableDataSet lookupDS = new LookupTableManagement.LookupTableDataSet ();
                LookupDataService dataSvc = new LookupDataService ();
                dataSvc.IntializeLookupDataService (tableName);
                if (dataSvc.GetRow ( lookupDS, pCategory, pDescription ))
                {
                    if (lookupDS.Tables[tableName].Rows[0].Table.Columns.Contains ("ID"))
                    {
                        mKey = ( Guid ) lookupDS.Tables[tableName].Rows[0]["ID"];
                    }
                    if (lookupDS.Tables[tableName].Rows[0].Table.Columns.Contains ("Abbreviation"))
                    {
                        mAbbreviation = ( string ) (lookupDS.Tables[tableName].Rows[0].IsNull( "Abbreviation" ) ?
                            string.Empty : lookupDS.Tables[tableName].Rows[0]["Abbreviation"]);
                    }
                    if (lookupDS.Tables[tableName].Rows[0].Table.Columns.Contains ("Description"))
                    {
                        mDescription = ( string ) (lookupDS.Tables[tableName].Rows[0].IsNull( "Description" ) ?
                            string.Empty : lookupDS.Tables[tableName].Rows[0]["Description"]);
                    }
                }
                else
                {
                    mKey = Guid.Empty;
                    if ( ( pCategory != null && pCategory != "" ) && ( pDescription != null && pDescription != "" ) )
                    {
                        mAbbreviation = "Lookup Description: <" + pCategory + "> was not found.";
                        mDescription = "Lookup Description: <" + pDescription + "> was not found.";
                    }
                    else
                    {
                        mAbbreviation = "";
                        mDescription = "";
                    }
                }
                dataSvc.Dispose ();
            }
            #endregion

        }

        protected class LookupTable
        {
            #region Member Variables
            private String mLookupTableName;
            private System.Collections.IList mLookupResults;
            private bool mFetchActive;
            #endregion

            #region Properties
            public String LookupTableName
            {
                get 
                {
                    return mLookupTableName;
                }
            }
            internal System.Collections.IList LookupResults
            {
                get 
                {
                    return mLookupResults;
                }
            }

            /// <summary>
            /// Semnaleaza incarcarea randurilor pentru care coloana IsActive = 1
            /// </summary>
            internal bool FetchActive
            {
                set
                {
                    mFetchActive = value;
                }
            }

            #endregion

            #region Public & Internal & Protected Methods
            public LookupTableResult GetResult (Guid key)
            {
                LookupTableResult result = null;
                bool Found = false;
                if (mLookupResults != null && !key.Equals (Guid.Empty))
                {
                    System.Collections.IEnumerator resultEnumerator =
                        mLookupResults.GetEnumerator ();
                    while (resultEnumerator.MoveNext ())
                    {
                        result = (LookupTableResult)resultEnumerator.Current;
                        if (result.Key == key)
                        {
                            Found = true;
                            break;
                        }
                    }
                    if (!Found)
                    {
                        result = new LookupTableResult (LookupTableName, key);
                        if (result != null)
                        {
                            mLookupResults.Add (result);
                        }
                    }
                }
                else if (key.Equals (Guid.Empty))
                {
                    result = new LookupTableResult ();
                    result.sAbbreviation = "";
                    result.sDescription = "";
                }
                return (result);
            }
            public LookupTableResult GetResult (String lookupStr, bool lookupByDescription)
            {
                LookupTableResult result = null;
                bool Found = false;
                if (mLookupResults != null)
                {
                    System.Collections.IEnumerator resultEnumerator =
                        mLookupResults.GetEnumerator ();
                    while (resultEnumerator.MoveNext ())
                    {
                        result = (LookupTableResult)resultEnumerator.Current;
                        if ((lookupByDescription && result.Description == lookupStr) ||
                            (!lookupByDescription && result.Abbreviation == lookupStr))
                        {
                            Found = true;
                            break;
                        }
                    }
                    if (!Found)
                    {
                        result = new LookupTableResult (LookupTableName, lookupStr,
                            lookupByDescription);
                        if (result != null && result.Key != Guid.Empty)
                        {
                            mLookupResults.Add (result);
                        }
                    }
                }
                return (result);
            }
            public LookupTableResult GetResult ( string pCategory, string pDescription )
            {
                LookupTableResult result = null;
                bool Found = false;
                if (mLookupResults != null)
                {
                    System.Collections.IEnumerator resultEnumerator =
                        mLookupResults.GetEnumerator ();
                    while (resultEnumerator.MoveNext ())
                    {
                        result = (LookupTableResult)resultEnumerator.Current;
                        if ( ( result.Description == pDescription ) &&
                            ( result.Abbreviation == pCategory ))
                        {
                            Found = true;
                            break;
                        }
                    }
                    if (!Found)
                    {
                        result = new LookupTableResult ( LookupTableName, pCategory,
                            pDescription );
                        if (result != null && result.Key != Guid.Empty)
                        {
                            mLookupResults.Add (result);
                        }
                    }
                }
                return (result);
            }
            internal bool GetList (LookupTableDataSet lookupTable)
            {
                bool retval = false;
                LookupDataService dataSvc = new LookupDataService ();
                dataSvc.IntializeLookupDataService (LookupTableName);
                dataSvc.FetchActive = mFetchActive;
                retval = dataSvc.GetList (lookupTable);
                dataSvc.Dispose ();
                return (retval);
            }
            internal bool GetList ( DataSet lookupTable )
            {
                bool retval = false;
                LookupDataService dataSvc = new LookupDataService ();
                dataSvc.FetchActive = mFetchActive;
                dataSvc.IntializeLookupDataService (LookupTableName);
                retval = dataSvc.GetList (lookupTable);
                dataSvc.Dispose ();
                return (retval);
            }
            internal bool GetList ( DataSet lookupTable, bool orderByDescription )
            {
                bool retval = false;
                LookupDataService dataSvc = new LookupDataService ();
                dataSvc.FetchActive = mFetchActive;
                dataSvc.IntializeLookupDataService (LookupTableName);
                retval = dataSvc.GetList ( lookupTable, orderByDescription );
                dataSvc.Dispose ();
                return (retval);
            }
            internal bool GetList ( DataSet lookupTable, bool orderByAbbreviationDescription, bool ascending )
            {
                bool retval = false;
                LookupDataService dataSvc = new LookupDataService ();
                dataSvc.FetchActive = mFetchActive;
                dataSvc.IntializeLookupDataService (LookupTableName);
                retval = dataSvc.GetList ( lookupTable, orderByAbbreviationDescription, ascending );
                dataSvc.Dispose ();
                return (retval);
            }
            internal bool GetList ( DataSet lookupTable, String lookupCol, bool ascending)
            {
                bool retval = false;
                LookupDataService dataSvc = new LookupDataService ();
                dataSvc.customColumn = lookupCol;
                dataSvc.FetchActive = mFetchActive;
                dataSvc.IntializeLookupDataService (LookupTableName);
                retval = dataSvc.GetList (lookupTable, lookupCol, ascending);
                dataSvc.Dispose ();
                return (retval);
            }
            internal bool GetList ( DataSet lookupTable, String lookupCustColFilter)
            {
                bool retval = false;
                LookupDataService dataSvc = new LookupDataService ();
                dataSvc.customColumnFilter = lookupCustColFilter;
                dataSvc.FetchActive = mFetchActive;
                dataSvc.IntializeLookupDataService (LookupTableName);
                retval = dataSvc.GetList (lookupTable, lookupCustColFilter);
                dataSvc.Dispose ();
                return (retval);
            }
            internal bool GetCustomList (DataSet lookupTable, String sqlQuery)
            {
                bool retval = false;
                LookupDataService dataSvc = new LookupDataService();
                dataSvc.customSqlQuery = sqlQuery;
                dataSvc.IntializeLookupDataService ( LookupTableName );
                retval = dataSvc.GetCustomList (lookupTable, sqlQuery);
                dataSvc.Dispose();
                return retval;
            }
            internal bool GetList ( DataSet lookupTable, String lookupStr, int startingFrom, int numberOfRows, bool lookupByDesc )
            {
                bool retval = false;
                LookupDataService dataSvc = new LookupDataService ();
                dataSvc.FetchActive = mFetchActive;
                dataSvc.IntializeLookupDataService (LookupTableName);
                retval = dataSvc.GetList ( lookupTable, lookupStr, lookupByDesc, startingFrom, numberOfRows );
                dataSvc.Dispose ();
                return (retval);
            }
            internal bool UpdateLookup(DataSet lookupTable)
            {
                bool retval = false;
                LookupDataService dataSvc = new LookupDataService();

                dataSvc.InitiliazeUpdateLookupDataService(LookupTableName);
                dataSvc.UpdateLookup(lookupTable);
                dataSvc.Dispose();
                return retval;
            }
            protected LookupTable ()
            {
            }
            internal LookupTable (String tableName)
            {
                mLookupResults = new System.Collections.ArrayList ();
                mLookupTableName = tableName;
            }
            #endregion
        }

        #endregion

        private System.Collections.IList mLookupTables = new System.Collections.ArrayList ();

        #region Static member variables and methods
        static private LookupTableBusSvc singleton = null;
        // Temporary - use an array here of known lookup tables.
        static public LookupTableBusSvc GetLookupTableBusSvc ()
        {
            if (singleton == null)
            {
                singleton = new LookupTableBusSvc ();
            }
            return (singleton);
        }
        // The following method should only be used when the LookupTableBusSvc
        // is being persisted, such as in a web application with the assembly
        // colocated with the web application
        static public void SetLookupTableBusSvc (LookupTableBusSvc newInst)
        {
            if (singleton == null)
            {
                singleton = newInst;
            }
        }
        #endregion

        #region Public Methods
        public void ClearTableResults (String tableName)
        {
            System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
            while (lookupEnumerator.MoveNext ())
            {
                LookupTable table = (LookupTable)lookupEnumerator.Current;
                if (table.LookupTableName == tableName)
                {
                    table.LookupResults.Clear ();
                    break;
                }
            }
        }

        /// <summary>
        /// Incarca o tabela de lookup intr-un dataset
        /// </summary>
        /// <param name="tableName">[in] Numele tabelei de lookup ce trebuie incarcata</param>
        /// <param name="lookupTable">[out] DataSet-ul in care se va incarca tabela</param>
        /// <returns></returns>
        public bool GetLookupList (String tableName, DataSet lookupTable)
        {
            try
            {
                bool retval = false;
                bool Found = false;
                System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
                while (lookupEnumerator.MoveNext ())
                {
                    LookupTable table = (LookupTable)lookupEnumerator.Current;
                    if (table.LookupTableName == tableName)
                    {
                        table.FetchActive = mFetchActive;
                        retval = table.GetList (lookupTable);
                        Found = true;
                        break;
                    }
                }
                if (!Found)
                {
                    LookupTable table = RegisterLookupTable (tableName);
                    table.FetchActive = mFetchActive;
                    if (table != null)
                    {
                        retval = table.GetList (lookupTable);
                    }
                }
		
                return (retval);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Incarca o tabela de lookup intr-un dataset ordonata dupa description
        /// </summary>
        /// <param name="tableName">[in] Numele tabelei de lookup ce trebuie incarcata</param>
        /// <param name="lookupTable">[out] DataSet-ul in care se va incarca tabela</param>
        /// <param name="orderByDescription">[in] </param>
        /// <returns></returns>
        public bool GetLookupList ( String tableName, DataSet lookupTable, bool orderByDescription )
        {
            bool retval = false;
            bool Found = false;
            System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
            while (lookupEnumerator.MoveNext ())
            {
                LookupTable table = (LookupTable)lookupEnumerator.Current;
                if (table.LookupTableName == tableName)
                {
                    table.FetchActive = mFetchActive;
                    retval = table.GetList ( lookupTable, orderByDescription );
                    Found = true;
                    break;
                }
            }
            if (!Found)
            {
                LookupTable table = RegisterLookupTable (tableName);
                if (table != null)
                {
                    table.FetchActive = mFetchActive;
                    retval = table.GetList ( lookupTable, orderByDescription );
                }
            }
			
            return (retval);
        }
		
        /// <summary>
        /// Incarca o tabela de lookup ordonata dupa abbreviation, description ASC sau ordonata dupa description, abbreviation ASC
        /// in functie de orderByAbbreviationDescription si valorile ascendente
        /// </summary>
        /// <param name="tableName">[in]Numele tabelei de lookup ce trebuie incarcata</param>
        /// <param name="lookupTable">[out] DataSet-ul in care se va incarca tabela</param>
        /// <param name="ascending">[in] Daca este true atunci lista va fi ordonata ASC daca nu invers</param>
        /// <param name="orderByAbbreviationDescription">[in] Daca este true atunci lookuptable-urile vor fi ordonate dupa abbreviation, description</param>
        /// <returns>[out] true daca este succes atfel o exceptie</returns>
        public bool GetLookupList ( String tableName, DataSet lookupTable, bool orderByAbbreviationDescription, bool ascending )
        {
            try
            {
                bool retval = false;
                bool Found = false;
                System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
                while (lookupEnumerator.MoveNext ())
                {
                    LookupTable table = (LookupTable)lookupEnumerator.Current;
                    if (table.LookupTableName == tableName)
                    {
                        table.FetchActive = mFetchActive;
                        retval = table.GetList ( lookupTable, orderByAbbreviationDescription, ascending );
                        Found = true;
                        break;
                    }
                }
                if (!Found)
                {
                    LookupTable table = RegisterLookupTable (tableName);
                    if (table != null)
                    {
                        table.FetchActive = mFetchActive;
                        retval = table.GetList ( lookupTable, orderByAbbreviationDescription, ascending );
                    }
                }				
                return (retval);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Incarca o tabela de lookup ordonata dupa o coloana specificata, ascending sau descending
        /// </summary>
        /// <param name="tableName">[in] Nume tabela</param>
        /// <param name="lookupTable">[out] DataSet-ul in care se va incarca tabela</param>
        /// <param name="orderByCol">[in] Nume coloana dupa care se face ordonarea</param>
        /// <param name="ascending">[in] Daca true atunci se ordoneaza ascending, altfel descending</param>
        /// <returns></returns>
        public bool GetLookupList ( String tableName, DataSet lookupTable, String orderByCol, bool ascending )
        {
            try
            {
                bool retval = false;
                bool Found = false;
                System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
                while (lookupEnumerator.MoveNext ())
                {
                    LookupTable table = (LookupTable)lookupEnumerator.Current;
                    if (table.LookupTableName == tableName)
                    {
                        table.FetchActive = mFetchActive;
                        retval = table.GetList( lookupTable, orderByCol, ascending);
                        Found = true;
                        break;
                    }
                }
                if (!Found)
                {
                    LookupTable table = RegisterLookupTable (tableName);
                    if (table != null)
                    {
                        table.FetchActive = mFetchActive;
                        retval = table.GetList( lookupTable, orderByCol, ascending);
                    }
                }				
                return (retval);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Incarca o tabela de lookup dupa o coloana specificata prin filtru
        /// </summary>
        /// <param name="tableName">Nume tabela</param>
        /// <param name="lookupTable">DataSet-ul in care se va incarca tabela</param>
        /// <param name="pCustomColumnFilter">Filtru dupa care se va face incarcare (ex: ID = 1)</param>
        /// <returns></returns>
        public bool GetLookupList ( String tableName, DataSet lookupTable, String pCustomColumnFilter )
        {
            try
            {
                bool retval = false;
                bool Found = false;
                System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
                while (lookupEnumerator.MoveNext ())
                {
                    LookupTable table = (LookupTable)lookupEnumerator.Current;
                    if (table.LookupTableName == tableName)
                    {
                        table.FetchActive = mFetchActive;
                        retval = table.GetList( lookupTable, pCustomColumnFilter);
                        Found = true;
                        break;
                    }
                }
                if (!Found)
                {
                    LookupTable table = RegisterLookupTable (tableName);
                    if (table != null)
                    {
                        table.FetchActive = mFetchActive;
                        retval = table.GetList( lookupTable, pCustomColumnFilter);
                    }
                }				
                return (retval);
            }
            catch
            {
                throw;
            }
        }
        public bool GetLookupList (String tableName, DataSet lookupTable, string filter, int startingFrom, int numberOfRows, bool lookupByDescription )
        {
            try
            {
                bool retval = false;
                bool Found = false;
                System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
                while (lookupEnumerator.MoveNext ())
                {
                    LookupTable table = (LookupTable)lookupEnumerator.Current;
                    if (table.LookupTableName == tableName)
                    {
                        table.FetchActive = mFetchActive;
                        retval = table.GetList ( lookupTable, filter, startingFrom, numberOfRows, lookupByDescription );
                        Found = true;
                        break;
                    }
                }
                if (!Found)
                {
                    LookupTable table = RegisterLookupTable (tableName);
                    if (table != null)
                    {
                        table.FetchActive = mFetchActive;
                        retval = table.GetList ( lookupTable, filter, startingFrom, numberOfRows, lookupByDescription );
                    }
                }			
                return (retval);
            }
            catch
            {
                throw;
            }
        }
        public bool GetLookupList (String tableName, String sqlQuery, DataSet lookupTable)
        {
            try
            {
                bool retval = false;
                LookupTable table = RegisterLookupTable (tableName);
                if (table != null)
                {
                    retval = table.GetCustomList ( lookupTable, sqlQuery );
                }

                return retval;
            }
            catch
            {
                throw;
            }
        }		
        public LookupTableResult LookupCode (String tableName, Guid code)
        {
            LookupTableResult result = null;
            bool Found = false;
            if (code == Guid.Empty)
            {
                return (emptyResult);
            }
            System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
            while (lookupEnumerator.MoveNext ())
            {
                LookupTable table = (LookupTable)lookupEnumerator.Current;
                if (table.LookupTableName == tableName)
                {
                    result = table.GetResult (code);
                    Found = true;
                    break;
                }
            }
            if (!Found)
            {
                LookupTable table = RegisterLookupTable (tableName);
                if (table != null)
                {
                    result = table.GetResult (code);
                }
            }
            return (result);
        }
		
        public LookupTableResult LookupCode (String tableName, String lookupStr, bool lookupByDescription)
        {
            LookupTableResult result = null;
            bool Found = false;
            if (lookupStr == String.Empty)
            {
                return (emptyResult);
            }
            System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
            while (lookupEnumerator.MoveNext ())
            {
                LookupTable table = (LookupTable)lookupEnumerator.Current;
                if (table.LookupTableName == tableName)
                {
                    result = table.GetResult (lookupStr, lookupByDescription);
                    Found = true;
                    break;
                }
            }
            if (!Found)
            {
                LookupTable table = RegisterLookupTable (tableName);
                if (table != null)
                {
                    result = table.GetResult (lookupStr, lookupByDescription);
                }
            }
			
            return (result);
        }

        public LookupTableResult LookupCode ( string tableName, string pCategory, string pDescription )
        {
            LookupTableResult result = null;
            bool Found = false;
            if ( ( pCategory == string.Empty ) || ( pDescription == string.Empty ) )
            {
                return (emptyResult);
            }
            System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
            while (lookupEnumerator.MoveNext ())
            {
                LookupTable table = (LookupTable)lookupEnumerator.Current;
                if (table.LookupTableName == tableName)
                {
                    result = table.GetResult (pCategory, pDescription);
                    Found = true;
                    break;
                }
            }
            if (!Found)
            {
                LookupTable table = RegisterLookupTable (tableName);
                if (table != null)
                {
                    result = table.GetResult (pCategory, pDescription);
                }
            }
		
            return (result);
        }

        public int MaxLength (string tableName, string columnName)
        {
            int lth;
            DataService svc = new DataService();
            lth = svc.MaxLength(tableName, columnName);
            return lth;
        }
		
        /// <summary>
        /// Update/Insert/Delete a standard lookup table
        /// </summary>
        /// <param name="tableName">[String]table name</param>
        /// <param name="lookupTable">[DataSet] the DataSet that contain the lookuptable</param>
        /// <returns></returns>
        public bool UpdateStandardLookupTable(String tableName, DataSet lookupTable)
        {
            try
            {
                bool retval = false;
                LookupTable table = RegisterLookupTable (tableName);
                retval = table.UpdateLookup(lookupTable);
                return retval;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Private Methods
        private LookupTable RegisterLookupTable (String tableName)
        {
            LookupTable theTable = null;
            theTable = new LookupTable (tableName);
            mLookupTables.Add (theTable);
            return (theTable);
        }
        #endregion

        #region Private Members
        private bool mFetchActive;
        #endregion

        #region Public Properties
        /// <summary>
        /// Semnaleaza incarcarea randurilor pentru care coloana IsActive = 1
        /// </summary>
        public bool FetchActive
        {
            set
            {
                mFetchActive = value;
            }
        }
        #endregion

        #region Constructors
        public LookupTableBusSvc()
        {
            //
            // TODO: Add constructor logic here
            //
            mLookupTables = new System.Collections.ArrayList ();
        }
        #endregion
    }
}