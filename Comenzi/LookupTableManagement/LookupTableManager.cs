using System;
using System.Data;
using GSBusFramework;

namespace LookupTableManagement
{
	/// <summary>
	/// Summary description for LookupTableManager.
	/// </summary>
	public class LookupTableManager : System.MarshalByRefObject
	{
		static LookupTableManager.LookupTableResult emptyResult =
			new LookupTableManager.LookupTableResult(Guid.Empty, String.Empty, String.Empty);

		#region Nested Classes
		public  class LookupDataService : GSBusFramework.DataService
		{
			protected System.Data.SqlClient.SqlConnection sqlConnection1;
			protected System.Data.SqlClient.SqlDataAdapter sqlGetDataAdapter;
			protected System.Data.SqlClient.SqlDataAdapter sqlListDataAdapter;
			protected System.Data.SqlClient.SqlDataAdapter sqlListByDescDataAdapter;
			protected System.Data.SqlClient.SqlDataAdapter sqlListByAbbrevDataAdapter;
			protected System.Data.SqlClient.SqlDataAdapter sqlListByAbbrevDescDataAdapter;
			protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
			protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
			protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
			protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
			protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
			protected String dbTableName;

			/// <summary>
			/// Required designer variable.
			/// </summary>
			//private System.ComponentModel.Container components = null;

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
				keyList.Add (new FilterInfo ("@LookupStr", lookupStr,
					FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL));
				return (GetRow (userDataSet, keyList,
					lookupByDesc ? this.sqlListByDescDataAdapter : this.sqlListByAbbrevDataAdapter));
			}
			public virtual bool GetRow (LookupTableManagement.LookupTableDataSet userDataSet, String abbrev, String desc)
			{
				System.Collections.IList keyList = new System.Collections.ArrayList ();
				keyList.Add (new FilterInfo ("@Abbrev", abbrev,
					FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL));
				keyList.Add (new FilterInfo ("@Desc", desc,
					FilterInfo.FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL));
				return (GetRow (userDataSet, keyList, sqlListByAbbrevDescDataAdapter));
			}
			public virtual bool GetList (LookupTableManagement.LookupTableDataSet userDataSet)
			{
				return (GetList (userDataSet, 0, int.MaxValue, null, this.sqlListDataAdapter));
			}
			protected override void setupDataService ()
			{
				this.sqlTableName = "LookupTable";
			}

			#region Component Designer generated code
			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>

			private void setupSQLCommandStrings (String lookupTableName)
			{
				String selClause =
					"SELECT ID, Abbreviation, Description FROM " + lookupTableName;

				// 
				// sqlSelectCommand1
				// 
				this.sqlSelectCommand1.CommandText = selClause + " WHERE (ID = @LookupID)";
				// 
				// sqlSelectCommand2
				// 
				this.sqlSelectCommand2.CommandText = selClause + " ORDER BY Description";
				// 
				// sqlSelectCommand3
				// 
				this.sqlSelectCommand3.CommandText = selClause + " WHERE (Description = @LookupStr)";
				// 
				// sqlSelectCommand4
				// 
				this.sqlSelectCommand4.CommandText = selClause + " WHERE (Abbreviation = @LookupStr)";
				// 
				// sqlSelectCommand5
				// 
				this.sqlSelectCommand5.CommandText = selClause + " WHERE (Abbreviation = @Abbrev AND [Description] = @Desc)";
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
				this.sqlListByAbbrevDescDataAdapter =
					new System.Data.SqlClient.SqlDataAdapter();
				this.sqlSelectCommand5 =
					new System.Data.SqlClient.SqlCommand();
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
				this.sqlGetDataAdapter.TableMappings.AddRange(
					new System.Data.Common.DataTableMapping[] {
						new System.Data.Common.DataTableMapping("Table",
								"LookupTable",
								new System.Data.Common.DataColumnMapping[] {
									new System.Data.Common.DataColumnMapping(
											"ID", "ID"),
									new System.Data.Common.DataColumnMapping(
											"Abbreviation", "Abbreviation"),
									new System.Data.Common.DataColumnMapping(
											"Description", "Description")})});
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
				this.sqlListDataAdapter.TableMappings.AddRange(
					new System.Data.Common.DataTableMapping[] {
						new System.Data.Common.DataTableMapping("Table",
								"LookupTable",
								new System.Data.Common.DataColumnMapping[] {
									new System.Data.Common.DataColumnMapping(
											"ID", "ID"),
									new System.Data.Common.DataColumnMapping(
											"Abbreviation", "Abbreviation"),
									new System.Data.Common.DataColumnMapping(
											"Description", "Description")})});
				// 
				// sqlSelectCommand2
				// 
				this.sqlSelectCommand2.Connection = this.sqlConnection1;
				// 
				// sqlListByDescDataAdapter
				// 
				this.sqlListByDescDataAdapter.SelectCommand = this.sqlSelectCommand3;
				this.sqlListByDescDataAdapter.TableMappings.AddRange(
					new System.Data.Common.DataTableMapping[] {
					new System.Data.Common.DataTableMapping("Table",
						"LookupTable",
						new System.Data.Common.DataColumnMapping[] {
							new System.Data.Common.DataColumnMapping(
									"ID", "ID"),
							new System.Data.Common.DataColumnMapping(
									"Abbreviation", "Abbreviation"),
							new System.Data.Common.DataColumnMapping(
									"Description", "Description")})});
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
				this.sqlListByAbbrevDataAdapter.TableMappings.AddRange(
					new System.Data.Common.DataTableMapping[] {
						new System.Data.Common.DataTableMapping("Table",
							"LookupTable",
							new System.Data.Common.DataColumnMapping[] {
								new System.Data.Common.DataColumnMapping(
										"ID", "ID"),
								new System.Data.Common.DataColumnMapping(
										"Abbreviation", "Abbreviation"),
								new System.Data.Common.DataColumnMapping(
										"Description", "Description")})});
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
				// sqlListByAbbrevDescDataAdapter
				//
				this.sqlListByAbbrevDescDataAdapter.SelectCommand = this.sqlSelectCommand5;
				this.sqlListByAbbrevDescDataAdapter.TableMappings.AddRange(
					new System.Data.Common.DataTableMapping[] {
							new System.Data.Common.DataTableMapping("Table",
						  "LookupTable",
					  new System.Data.Common.DataColumnMapping[] {
					 new System.Data.Common.DataColumnMapping(
						"ID", "ID"),
					 new System.Data.Common.DataColumnMapping(
						 "Abbreviation", "Abbreviation"),
					 new System.Data.Common.DataColumnMapping(
						 "Description", "Description")})});
				// 
				// sqlSelectCommand4
				// 
				this.sqlSelectCommand5.Connection = this.sqlConnection1;
				this.sqlSelectCommand5.Parameters.Add(
					new System.Data.SqlClient.SqlParameter("@Abbrev",
					System.Data.SqlDbType.VarChar, 15,
					System.Data.ParameterDirection.Input, true,
					((System.Byte)(0)), ((System.Byte)(0)), "Abbreviation",
					System.Data.DataRowVersion.Current, null));
				this.sqlSelectCommand5.Parameters.Add(
					new System.Data.SqlClient.SqlParameter("@Desc",
					System.Data.SqlDbType.VarChar, 50,
					System.Data.ParameterDirection.Input, true,
					((System.Byte)(0)), ((System.Byte)(0)), "Description",
					System.Data.DataRowVersion.Current, null));
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
					mKey = lookupDS.LookupTable[0].ID;
					mAbbreviation = (lookupDS.LookupTable[0].IsAbbreviationNull() ?
						String.Empty : lookupDS.LookupTable[0].Abbreviation);
					mDescription = (lookupDS.LookupTable[0].IsDescriptionNull() ?
						String.Empty : lookupDS.LookupTable[0].Description);
				}
				else
				{
					mKey = id;
					if (!id.Equals (Guid.Empty))
					{
						mAbbreviation = "Not Found";
						mDescription = "Lookup Key <" + id.ToString () + "> was not found.";
					}
					else
					{
						mAbbreviation = String.Empty;
						mDescription = String.Empty;
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
					mKey = lookupDS.LookupTable[0].ID;
					mAbbreviation = (lookupDS.LookupTable[0].IsAbbreviationNull() ?
						String.Empty : lookupDS.LookupTable[0].Abbreviation);
					mDescription = (lookupDS.LookupTable[0].IsDescriptionNull() ?
						String.Empty : lookupDS.LookupTable[0].Description);
				}
				else
				{
					mKey = Guid.Empty;
					if (lookupStr != null && !lookupStr.Equals (String.Empty))
					{
						mAbbreviation = "Not Found";
						mDescription = "Lookup Description: <" + lookupStr + "> was not found.";
					}
					else
					{
						mAbbreviation = String.Empty;
						mDescription = String.Empty;
					}
				}
				dataSvc.Dispose ();
			}
			internal LookupTableResult (String tableName, String abbrev, String desc)
			{
				LookupTableManagement.LookupTableDataSet lookupDS = new LookupTableManagement.LookupTableDataSet ();
				LookupDataService dataSvc = new LookupDataService ();
				dataSvc.IntializeLookupDataService (tableName);
				if (dataSvc.GetRow (lookupDS, abbrev, desc))
				{
					mKey = lookupDS.LookupTable[0].ID;
					mAbbreviation = (lookupDS.LookupTable[0].IsAbbreviationNull() ?
						String.Empty : lookupDS.LookupTable[0].Abbreviation);
					mDescription = (lookupDS.LookupTable[0].IsDescriptionNull() ?
						String.Empty : lookupDS.LookupTable[0].Description);
				}
				else
				{
					mKey = Guid.Empty;
					if (desc != null && !desc.Equals (String.Empty))
					{
						mAbbreviation = "Not Found";
						mDescription = "Lookup Description: <" + desc + "> was not found.";
					}
					else
					{
						mAbbreviation = "Not Found";
						mDescription = "Lookup Description: is empty";
					}
				}
				dataSvc.Dispose ();
			}
			internal LookupTableResult (Guid ID, String abbrev, String desc)
			{
				mKey = ID;
				mAbbreviation = abbrev;
				mDescription = desc;
			}
			#endregion

		}

		protected class LookupTable
		{
			#region Member Variables
			private String mLookupTableName;
			private System.Collections.IList mLookupResults;
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
			#endregion

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
					result = new LookupTableResult (key, String.Empty, String.Empty);
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
			public LookupTableResult GetResult (String abbrev, String desc)
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
						if (result.Description == desc
							&& result.Abbreviation == abbrev)
						{
							Found = true;
							break;
						}
					}
					if (!Found)
					{
						result = new LookupTableResult (LookupTableName, abbrev,
							desc);
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
				retval = dataSvc.GetList (lookupTable);
				dataSvc.Dispose ();
				return (retval);
			}
			protected LookupTable ()
			{
			}
			internal LookupTable (String tableName)
			{
				mLookupResults = new System.Collections.ArrayList ();
				mLookupTableName = tableName;
			}
		}

		#endregion

		private System.Collections.IList mLookupTables = new System.Collections.ArrayList ();

		#region Static member variables and methods
		static private LookupTableManager singleton = null;
		// Temporary - use an array here of known lookup tables.
		static public LookupTableManager GetLookupTableManager ()
		{
			if (singleton == null)
			{
				singleton = new LookupTableManager ();
			}
			return (singleton);
		}
		// The following method should only be used when the LookupTableManager
		// is being persisted, such as in a web application with the assembly
		// colocated with the web application
		static public void SetLookupTableManager (LookupTableManager newInst)
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
		public LookupTableResult LookupAbbrevDesc (String tableName, String abbrev, String desc)
		{
			LookupTableResult result = null;
			bool Found = false;
			if (abbrev == String.Empty)
			{
				return (emptyResult);
			}
			if (desc == String.Empty)
			{
				return (emptyResult);
			}
			System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
			while (lookupEnumerator.MoveNext ())
			{
				LookupTable table = (LookupTable)lookupEnumerator.Current;
				if (table.LookupTableName == tableName)
				{
					result = table.GetResult (abbrev, desc);
					Found = true;
					break;
				}
			}
			if (!Found)
			{
				LookupTable table = RegisterLookupTable (tableName);
				if (table != null)
				{
					result = table.GetResult (abbrev, desc);
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
		public bool GetLookupList (String tableName, LookupTableDataSet lookupTable)
		{
			bool retval = false;
			bool Found = false;
			System.Collections.IEnumerator lookupEnumerator = mLookupTables.GetEnumerator ();
			while (lookupEnumerator.MoveNext ())
			{
				LookupTable table = (LookupTable)lookupEnumerator.Current;
				if (table.LookupTableName == tableName)
				{
					retval = table.GetList (lookupTable);
					Found = true;
					break;
				}
			}
			if (!Found)
			{
				LookupTable table = RegisterLookupTable (tableName);
				if (table != null)
				{
					retval = table.GetList (lookupTable);
				}
			}
		
			return (retval);
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

		#region Constructors
		private LookupTableManager()
		{
			//
			// TODO: Add constructor logic here
			//
			mLookupTables = new System.Collections.ArrayList ();
		}
		#endregion
	}
}
