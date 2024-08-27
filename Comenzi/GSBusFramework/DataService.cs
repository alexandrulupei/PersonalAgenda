using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Text.RegularExpressions;

namespace GSBusFramework
{
	/// <summary>
	/// Summary description for DataService.
	/// </summary>
	public class DataService : System.ComponentModel.Component
	{
		#region Member Variables
		protected String sqlTableName;
		private System.Collections.IList mSelListFilter;
		private System.Data.SqlClient.SqlCommand sqlSelectCommandMaxLength;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapterMaxLength;
		private System.Data.SqlClient.SqlConnection sqlConnection1 = null;
		private System.Data.SqlClient.SqlConnection sqlConnection2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Constructors
		public DataService(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public DataService()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		protected override void Dispose( bool disposing ) 
		{
			if( disposing ) 
			{
				if(components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommandMaxLength = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapterMaxLength = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// sqlDataAdapterMaxLength
			// 
			this.sqlDataAdapterMaxLength.SelectCommand = this.sqlSelectCommandMaxLength;

		}
		#endregion

		#region Class Infrastructure Methods
		// Class Methods
		/// <summary>
		/// Metoda setupDataService trebuie rescrise in subclase pentru
		/// pentru a seta conexiunea si adaptarele corespunzatoare
		/// </summary>
		protected virtual void setupDataService ()
		{
			mSelListFilter = null;
		}
		#endregion
	
		#region Protected Properties
		#endregion

		#region Protected Methods

		#region List-oriented methods
		protected bool FillOneTable (ref SqlConnection sqlConn, ref ConnectionState curConnState, ref DataSet userDataSet, IList keyList, AdapterList viewDataAdapter, string tbl)
		{
			int numRows;
			SqlDataAdapter getDataAdapter = viewDataAdapter [tbl];
			if (getDataAdapter == null)
				// TODO throw exception
				return false;
			SqlCommand selCommand = getDataAdapter.SelectCommand;
			setPrimaryKeys (ref selCommand, keyList);
			
			// Open connection
			if (curConnState != ConnectionState.Open)
			{
				try
				{
					sqlConn.Open();
					curConnState = ConnectionState.Open;
				}
				catch (System.Exception e)
				{
					throw (new DBOpenException (
						"Nu se poate deschide o conexiune catre baza de date: " +
						sqlConn.DataSource + "(" + sqlConn.Database + ").",
						"Data Service", e));
				}
			}
			getDataAdapter.SelectCommand.Connection = sqlConn;
            getDataAdapter.SelectCommand.CommandTimeout = sqlConn.ConnectionTimeout;

			// Fetch the data
			numRows = getDataAdapter.Fill (userDataSet, tbl);
			return numRows >= 0;
		}
		protected bool GetDS (DataSet userDataSet, IList firstKeyList, string tableName, string joinColumn, AdapterList viewDataAdapter)
		{
			bool bRetval = true;
			IList keyList = new ArrayList ();
			sqlConnection1 = TransactionManager.ReadOnlyConnection;
			ConnectionState curConnState = sqlConnection1.State;
			try
			{
				foreach (string tbl in viewDataAdapter.Keys)
				{
					bRetval &= FillOneTable (ref sqlConnection1, ref curConnState, ref userDataSet, 
						tbl.Equals(tableName) ? firstKeyList : keyList, viewDataAdapter, tbl);
					if (tbl.Equals(tableName))
					{
						if (userDataSet.Tables[tableName].Rows.Count > 0)
						{
							Guid joinID;
							if (!userDataSet.Tables[tableName].Columns.Contains("ID"))
								continue;
							joinID = (Guid)(userDataSet.Tables[tableName].Rows[0]["ID"]);
							keyList.Add (new FilterInfo(joinColumn, joinID,
								FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL));
						}
						CopyKeys(keyList, firstKeyList);
					}
				}
			}
			catch (DBOpenException dbExcep)
			{
				// Do not rewrapper a db open exception caught and wrappered earlier
				throw (dbExcep);
			}
			catch (System.Exception e)
			{
				throw new SelectException( "Metoda GetDS pentru  [" + userDataSet.DataSetName + "] a esuat; "
					+ e.Message, this.ToString(), e );
			}
			finally 
			{
				if (curConnState != ConnectionState.Open &&
					sqlConnection1.State == ConnectionState.Open)
				{
					sqlConnection1.Close ();
				}
			}
			return bRetval;
		}
		protected bool GetList (DataSet userDataSet, System.Data.SqlClient.SqlDataAdapter listDataAdapter)
		{
			return (GetList (userDataSet, 0, int.MaxValue, this.mSelListFilter, listDataAdapter));
		}
		protected bool GetList (DataSet userDataSet, System.Collections.IList filterList, System.Data.SqlClient.SqlDataAdapter listDataAdapter)
		{
			return (GetList (userDataSet, 0, int.MaxValue, filterList, listDataAdapter));
		}
		protected bool GetList (DataSet userDataSet, int startingFrom, int maxRec, System.Collections.IList filterList, SqlDataAdapter listDataAdapter)
		{
			int numRows;
			bool bRetval = false;
			sqlConnection1 = TransactionManager.ReadOnlyConnection;
			ConnectionState curConnState = sqlConnection1.State;
			try
			{
				if (curConnState != ConnectionState.Open)
				{
					try
					{
						sqlConnection1.Open();
					}
					catch (SqlException e)
					{
						if( e.Number == 18456 )
							throw new DBOpenException();
					}
					catch (System.Exception e)
					{
						throw (new DBOpenException (
							"Nu se poate deschide o conexiune catre baza de date: " +
							sqlConnection1.DataSource + "(" + sqlConnection1.Database + "). "
							+ e.Message, "Data Service", e));
					}
				}
				
				String oldSelCommand = null;
				if (filterList != null && filterList.Count != 0)
				{
					String newSelCommand;
					oldSelCommand = listDataAdapter.SelectCommand.CommandText;
					newSelCommand = (String) oldSelCommand.Clone();
					System.Collections.IEnumerator filterEnumerator = filterList.GetEnumerator();
					bool firstTime = true;
					bool hasParams = false;
					int orderIndex;
					while (filterEnumerator.MoveNext())
					{
						FilterInfo nextFilter = (FilterInfo)
							filterEnumerator.Current;
						if (listDataAdapter.SelectCommand.Parameters.Contains(nextFilter.FilterVar))
						{
							listDataAdapter.SelectCommand.Parameters[nextFilter.FilterVar].Value = nextFilter.FilterValue;
							hasParams = true;
							if (!firstTime)
							{
								newSelCommand = (String) oldSelCommand.Clone();
							}
						}
						else if (!hasParams)
						{
							orderIndex = newSelCommand.ToUpper().IndexOf( "ORDER" );
							if (firstTime)
							{
								firstTime = false;
								if( orderIndex >= 0 )
								{
									newSelCommand = newSelCommand.Insert( orderIndex, " WHERE " + nextFilter.RenderFilterForSQL() + " " );
								}
								else
								{
									newSelCommand = newSelCommand + " WHERE " +
										nextFilter.RenderFilterForSQL();
								}
							}
							else
							{
								if( orderIndex >= 0 )
								{
									newSelCommand = newSelCommand.Insert( orderIndex, " AND " + nextFilter.RenderFilterForSQL() + " " );
								}
								else
								{
									newSelCommand = newSelCommand + " AND " + nextFilter.RenderFilterForSQL();
								}
							}
						}
					}
					if (newSelCommand != oldSelCommand)
					{
						listDataAdapter.SelectCommand.CommandText = newSelCommand;
					}
				}
				listDataAdapter.SelectCommand.Connection = sqlConnection1;
                listDataAdapter.SelectCommand.CommandTimeout = sqlConnection1.ConnectionTimeout;
				numRows = listDataAdapter.Fill (userDataSet, startingFrom, maxRec, sqlTableName);
				if (oldSelCommand != null)
				{
					listDataAdapter.SelectCommand.CommandText = oldSelCommand;
				}
				bRetval = true;
			}
			catch (DBOpenException dbExcep)
			{
				// Do not rewrapper a db open exception caught and wrappered earlier
				throw (dbExcep);
			}
			catch (System.Data.ConstraintException excep)
			{
				throw new SelectException( "Metoda GetList pentru DataTable [" + sqlTableName + "] a esuat; "
					+ excep.Message, this.ToString(), excep.InnerException );
			}
			catch (System.Exception e)
			{
				throw new SelectException( "Metoda GetList pentru DataTable [" + sqlTableName + "] a esuat; "
					+ e.Message, this.ToString(), e );
			}
			finally 
			{
				if (curConnState != ConnectionState.Open &&
					sqlConnection1.State == ConnectionState.Open)
				{
					sqlConnection1.Close ();
				}
			}
			return (bRetval);
		}
		protected bool GetList (DataSet userDataSet, System.Collections.IList filterList, SqlDataAdapter listDataAdapter, String mUserName, String mPassword)
		{
			int numRows;
			bool bRetval = false;
			TransactionManager.UseDynamicConnectionString = true;
			TransactionManager.UserName = mUserName;
			TransactionManager.Password = mPassword;
			sqlConnection1 = TransactionManager.ReadOnlyConnection;
			ConnectionState curConnState = sqlConnection1.State;
			try
			{
				if (curConnState != ConnectionState.Open)
				{
					try
					{
						sqlConnection1.Open();
					}
					catch (SqlException e)
					{
						if( e.Number == 18456 || e.Number == 18452)
							throw new DBOpenException("Nu s-a putut stabili o conexiune catre baza de date. Nume utilizator sau parola au fost introduse gresit!");
						else
							throw new DBOpenException();
					}
					catch (System.Exception e)
					{
						throw (new DBOpenException (
							"Nu se poate deschide o conexiune catre baza de date: " +
							sqlConnection1.DataSource + "(" + sqlConnection1.Database + "). "
							+ e.Message, "Data Service", e));
					}
				}
				
				String oldSelCommand = null;
				if (filterList != null && filterList.Count != 0)
				{
					String newSelCommand;
					oldSelCommand = listDataAdapter.SelectCommand.CommandText;
					newSelCommand = (String) oldSelCommand.Clone();
					System.Collections.IEnumerator filterEnumerator = filterList.GetEnumerator();
					bool firstTime = true;
					bool hasParams = false;
					int orderIndex;
					while (filterEnumerator.MoveNext())
					{
						FilterInfo nextFilter = (FilterInfo)
							filterEnumerator.Current;
						if (listDataAdapter.SelectCommand.Parameters.Contains(nextFilter.FilterVar))
						{
							listDataAdapter.SelectCommand.Parameters[nextFilter.FilterVar].Value = nextFilter.FilterValue;
							hasParams = true;
							if (!firstTime)
							{
								newSelCommand = (String) oldSelCommand.Clone();
							}
						}
						else if (!hasParams)
						{
							orderIndex = newSelCommand.ToUpper().IndexOf( "ORDER" );
							if (firstTime)
							{
								firstTime = false;
								if( orderIndex >= 0 )
								{
									newSelCommand = newSelCommand.Insert( orderIndex, " WHERE " + nextFilter.RenderFilterForSQL() + " " );
								}
								else
								{
									newSelCommand = newSelCommand + " WHERE " +
										nextFilter.RenderFilterForSQL();
								}
							}
							else
							{
								if( orderIndex >= 0 )
								{
									newSelCommand = newSelCommand.Insert( orderIndex, " AND " + nextFilter.RenderFilterForSQL() + " " );
								}
								else
								{
									newSelCommand = newSelCommand + " AND " + nextFilter.RenderFilterForSQL();
								}
							}
						}
					}
					if (newSelCommand != oldSelCommand)
					{
						listDataAdapter.SelectCommand.CommandText = newSelCommand;
					}
				}
				listDataAdapter.SelectCommand.Connection = sqlConnection1;
                listDataAdapter.SelectCommand.CommandTimeout = sqlConnection1.ConnectionTimeout;
				numRows = listDataAdapter.Fill (userDataSet, sqlTableName);
				if (oldSelCommand != null)
				{
					listDataAdapter.SelectCommand.CommandText = oldSelCommand;
				}
				bRetval = true;
			}
			catch (DBOpenException dbExcep)
			{
				// Do not rewrapper a db open exception caught and wrappered earlier
				throw (dbExcep);
			}
			catch (System.Data.ConstraintException excep)
			{
				throw new SelectException( "Metoda GetList pentru DataTable [" + sqlTableName + "] a esuat; "
					+ excep.Message, this.ToString(), excep.InnerException );
			}
			catch (System.Exception e)
			{
				throw new SelectException( "Metoda GetList pentru DataTable [" + sqlTableName + "] a esuat; "
					+ e.Message, this.ToString(), e );
			}
			finally 
			{
				if (curConnState != ConnectionState.Open &&
					sqlConnection1.State == ConnectionState.Open)
				{
					sqlConnection1.Close ();
				}
			}
			return (bRetval);
		}

        protected bool ExecuteSQL(System.Collections.IList filterList, SqlDataAdapter listDataAdapter)
        {
            int numRows;
            bool bRetval = false;
            sqlConnection1 = TransactionManager.ReadOnlyConnection;
            ConnectionState curConnState = sqlConnection1.State;
            try
            {
                if (curConnState != ConnectionState.Open)
                {
                    try
                    {
                        sqlConnection1.Open();
                    }
                    catch (SqlException e)
                    {
                        if( e.Number == 18456 )
                            throw new DBOpenException();
                    }
                    catch (System.Exception e)
                    {
                        throw (new DBOpenException (
                            "Nu se poate deschide o conexiune catre baza de date: " +
                            sqlConnection1.DataSource + "(" + sqlConnection1.Database + "). "
                            + e.Message, "Data Service", e));
                    }
                }
				
                String oldSelCommand = null;
                if (filterList != null && filterList.Count != 0)
                {
                    String newSelCommand;
                    oldSelCommand = listDataAdapter.SelectCommand.CommandText;
                    newSelCommand = (String) oldSelCommand.Clone();
                    System.Collections.IEnumerator filterEnumerator = filterList.GetEnumerator();
                    bool firstTime = true;
                    bool hasParams = false;
                    int orderIndex;
                    while (filterEnumerator.MoveNext())
                    {
                        FilterInfo nextFilter = (FilterInfo)
                            filterEnumerator.Current;
                        if (listDataAdapter.SelectCommand.Parameters.Contains(nextFilter.FilterVar))
                        {
                            listDataAdapter.SelectCommand.Parameters[nextFilter.FilterVar].Value = nextFilter.FilterValue;
                            hasParams = true;
                            if (!firstTime)
                            {
                                newSelCommand = (String) oldSelCommand.Clone();
                            }
                        }
                        else if (!hasParams)
                        {
                            orderIndex = newSelCommand.ToUpper().IndexOf( "ORDER" );
                            if (firstTime)
                            {
                                firstTime = false;
                                if( orderIndex >= 0 )
                                {
                                    newSelCommand = newSelCommand.Insert( orderIndex, " WHERE " + nextFilter.RenderFilterForSQL() + " " );
                                }
                                else
                                {
                                    newSelCommand = newSelCommand + " WHERE " +
                                        nextFilter.RenderFilterForSQL();
                                }
                            }
                            else
                            {
                                if( orderIndex >= 0 )
                                {
                                    newSelCommand = newSelCommand.Insert( orderIndex, " AND " + nextFilter.RenderFilterForSQL() + " " );
                                }
                                else
                                {
                                    newSelCommand = newSelCommand + " AND " + nextFilter.RenderFilterForSQL();
                                }
                            }
                        }
                    }
                    if (newSelCommand != oldSelCommand)
                    {
                        listDataAdapter.SelectCommand.CommandText = newSelCommand;
                    }
                }
                listDataAdapter.SelectCommand.Connection = sqlConnection1;
                listDataAdapter.SelectCommand.CommandTimeout = sqlConnection1.ConnectionTimeout;

                numRows = listDataAdapter.SelectCommand.ExecuteNonQuery();
                //numRows = listDataAdapter.Fill (userDataSet, startingFrom, maxRec, sqlTableName);
                if (oldSelCommand != null)
                {
                    listDataAdapter.SelectCommand.CommandText = oldSelCommand;
                }
                bRetval = true;
            }
            catch (DBOpenException dbExcep)
            {
                // Do not rewrapper a db open exception caught and wrappered earlier
                throw (dbExcep);
            }
            catch (System.Data.ConstraintException excep)
            {
                throw new SelectException( "Metoda GetList pentru DataTable [" + sqlTableName + "] a esuat; "
                    + excep.Message, this.ToString(), excep.InnerException );
            }
            catch (System.Exception e)
            {
                throw new SelectException( "Metoda GetList pentru DataTable [" + sqlTableName + "] a esuat; "
                    + e.Message, this.ToString(), e );
            }
            finally 
            {
                if (curConnState != ConnectionState.Open &&
                    sqlConnection1.State == ConnectionState.Open)
                {
                    sqlConnection1.Close ();
                }
            }
            return (bRetval);
        }
        protected object ExecuteScalarFunctions(System.Collections.IList filterList, SqlDataAdapter listDataAdapter)
        {
            object objRetval;
            sqlConnection1 = TransactionManager.ReadOnlyConnection;
            ConnectionState curConnState = sqlConnection1.State;
            try
            {
                if (curConnState != ConnectionState.Open)
                {
                    try
                    {
                        sqlConnection1.Open();
                    }
                    catch (SqlException e)
                    {
                        if (e.Number == 18456)
                            throw new DBOpenException();
                    }
                    catch (System.Exception e)
                    {
                        throw (new DBOpenException(
                            "Nu se poate deschide o conexiune catre baza de date: " +
                            sqlConnection1.DataSource + "(" + sqlConnection1.Database + "). "
                            + e.Message, "Data Service", e));
                    }
                }

                String oldSelCommand = null;
                if (filterList != null && filterList.Count != 0)
                {
                    oldSelCommand = listDataAdapter.SelectCommand.CommandText;
                    System.Collections.IEnumerator filterEnumerator = filterList.GetEnumerator();
                    while (filterEnumerator.MoveNext())
                    {
                        FilterInfo nextFilter = (FilterInfo) filterEnumerator.Current;
                        if (listDataAdapter.SelectCommand.Parameters.Contains(nextFilter.FilterVar))
                        {
                            listDataAdapter.SelectCommand.Parameters[nextFilter.FilterVar].Value = nextFilter.FilterValue;
                        }
                    }
                }
                listDataAdapter.SelectCommand.Connection = sqlConnection1;
                listDataAdapter.SelectCommand.CommandTimeout = sqlConnection1.ConnectionTimeout;
                objRetval = listDataAdapter.SelectCommand.ExecuteScalar();
            }
            catch (DBOpenException dbExcep)
            {
                // Do not rewrapper a db open exception caught and wrappered earlier
                throw (dbExcep);
            }
            catch (System.Data.ConstraintException excep)
            {
                throw new SelectException("Metoda ExecuteScalarFunctions a esuat; "
                    + excep.Message, this.ToString(), excep.InnerException);
            }
            catch (System.Exception e)
            {
                throw new SelectException("Metoda ExecuteScalarFunctions a esuat; "
                    + e.Message, this.ToString(), e);
            }
            finally
            {
                if (curConnState != ConnectionState.Open &&
                    sqlConnection1.State == ConnectionState.Open)
                {
                    sqlConnection1.Close();
                }
            }
            return (objRetval);
        }
		#endregion
	
		#region Row-oriented methods
		protected bool GetRow (DataSet userDataSet, System.Collections.IList keyList, SqlDataAdapter getDataAdapter)
		{
			int numRows;
			bool bRetval = false;
			sqlConnection1 = TransactionManager.ReadOnlyConnection;
			ConnectionState curConnState = sqlConnection1.State;
			try
			{
				SqlCommand selCommand = getDataAdapter.SelectCommand;
				this.setPrimaryKeys (ref selCommand, keyList);
				if (curConnState != ConnectionState.Open)
				{
					try
					{
						sqlConnection1.Open();
					}
					catch (System.Exception e)
					{
						throw (new DBOpenException (
							"Nu se poate deschide o conexiune catre baza de date: " +
							sqlConnection1.DataSource + "(" + sqlConnection1.Database + ").",
							"Data Service", e));
					}
				}
				getDataAdapter.SelectCommand.Connection = sqlConnection1;
                getDataAdapter.SelectCommand.CommandTimeout = sqlConnection1.ConnectionTimeout;
				numRows = getDataAdapter.Fill (userDataSet, sqlTableName);
				if (numRows == 1)
				{
					bRetval = true;
				}
			}
			catch (DBOpenException dbExcep)
			{
				// Do not rewrapper a db open exception caught and wrappered earlier
				throw (dbExcep);
			}
			catch (System.Exception e)
			{
				throw new SelectException( "Metoda GetRow pentru DataTable [" + sqlTableName + "] a esuat; "
					+ e.Message, this.ToString(), e );
			}
			finally 
			{
				if (curConnState != ConnectionState.Open &&
					sqlConnection1.State == ConnectionState.Open)
				{
					sqlConnection1.Close ();
				}
			}
			return (bRetval);
		}
		
		#region Transaction oriented methods
		protected bool DeleteRow (DataSet userDataSet, SqlDataAdapter maintDataAdapter)
		{
			int numRows;
			bool bRetval = false;
			SqlConnection sqlConnection = null;
			bool bNeedToCloseConnection = false;
			if (maintDataAdapter.DeleteCommand == null)
			{
				throw (new DomainException ("Incercare de Delete cand Delete nu este suportat."));
			}
			try
			{
				if( TransactionManager.CurrentConnection == null )
				{
					try
					{
						sqlConnection = new SqlConnection (TransactionManager.ConnectionString);
						sqlConnection.Open ();
					}
					catch (System.Exception e)
					{
						throw (new DBOpenException (
							"Nu se poate deschide o conexiune catre baza de date: " +
							sqlConnection.DataSource + "(" + sqlConnection.Database + ").",
							"Data Service", e));
					}
					maintDataAdapter.DeleteCommand.Connection = sqlConnection;
					if (maintDataAdapter.InsertCommand != null)
					{
						maintDataAdapter.InsertCommand.Connection = null;
					}
					if (maintDataAdapter.UpdateCommand != null)
					{
						maintDataAdapter.UpdateCommand.Connection = null;
					}
					bNeedToCloseConnection = true;
				}
				else
				{
					maintDataAdapter.DeleteCommand.Connection = TransactionManager.CurrentConnection;
				}
				numRows = maintDataAdapter.Update (userDataSet, sqlTableName);
				if (numRows == 1)
				{
					bRetval = true;
				}
			}
			catch (DBOpenException dbExcep)
			{
				// Do not rewrapper a db open exception caught and wrappered earlier
				throw (dbExcep);
			}
			catch (System.Exception e)
			{
				throw new DeleteException( "Metoda DeleteRow pentru DataTable [" + sqlTableName + "] a esuat; "
					+ e.Message, this.ToString(), e );
			}
			finally 
			{
				if (bNeedToCloseConnection)
				{
					maintDataAdapter.DeleteCommand.Transaction = null;
					if (sqlConnection.State == ConnectionState.Open)
					{
						sqlConnection.Close ();
						sqlConnection.Dispose ();
					}
				}
				if (maintDataAdapter.DeleteCommand != null)
				{
					maintDataAdapter.DeleteCommand.Connection = null;
				}
			}
			return (bRetval);
		}
		protected bool InsertRow (DataSet userDataSet, SqlDataAdapter maintDataAdapter)
		{
			int numRows;
			bool bRetval = false;
			SqlConnection sqlConnection = null;
			bool bNeedToCloseConnection = false;
			if (maintDataAdapter.InsertCommand == null)
			{
				throw (new DomainException ("Incercare de Insert atunci cand Insert nu este suportat."));
			}
			try
			{
				if( TransactionManager.CurrentConnection == null )
				{
					try
					{
						sqlConnection = new SqlConnection (TransactionManager.ConnectionString);
						sqlConnection.Open ();
					}
					catch (System.Exception e)
					{
						throw (new DBOpenException (
							"Nu se poate deschide o conexiune catre baza de date: " +
							sqlConnection.DataSource + "(" + sqlConnection.Database + ").",
							"Data Service", e));
					}
					maintDataAdapter.InsertCommand.Connection = sqlConnection;
					if (maintDataAdapter.UpdateCommand != null)
					{
						maintDataAdapter.UpdateCommand.Connection = null;
					}
					if (maintDataAdapter.DeleteCommand != null)
					{
						maintDataAdapter.DeleteCommand.Connection = null;
					}
					bNeedToCloseConnection = true;
				}
				else
				{
					maintDataAdapter.InsertCommand.Connection = TransactionManager.CurrentConnection;
				}
				numRows = maintDataAdapter.Update (userDataSet, sqlTableName);
				if (numRows == 1)
				{
					bRetval = true;
				}
			}
			catch (DBOpenException dbExcep)
			{
				// Do not rewrapper a db open exception caught and wrappered earlier
				throw (dbExcep);
			}
			catch (System.Exception e)
			{
				throw new InsertException( "Metoda InsertRow pentru DataTable [" + sqlTableName + "] a esuat; "
					+ e.Message, this.ToString(), e );
			}
			finally 
			{
				if (bNeedToCloseConnection)
				{
					maintDataAdapter.InsertCommand.Transaction = null;
					if (sqlConnection.State == ConnectionState.Open)
					{
						sqlConnection.Close ();
						sqlConnection.Dispose ();
					}
				}
				if (maintDataAdapter.InsertCommand != null)
				{
					maintDataAdapter.InsertCommand.Connection = null;
				}
			}
			return (bRetval);
		}
		protected bool UpdateRow (DataSet userDataSet, SqlDataAdapter maintDataAdapter)
		{
			int numRows;
			bool bRetval = false;
			SqlConnection sqlConnection = null;
			bool bNeedToCloseConnection = false;
			if (maintDataAdapter.UpdateCommand == null)
			{
				throw (new DomainException ("Incercare de Update atunci cand Update nu este suportat."));
			}
			try
			{
				if( TransactionManager.CurrentConnection == null )
				{
					try
					{
						sqlConnection = new SqlConnection (TransactionManager.ConnectionString);
						sqlConnection.Open ();
					}
					catch (System.Exception e)
					{
						throw (new DBOpenException (
							"Nu se poate deschide o conexiune catre baza de date: " +
							sqlConnection.DataSource + "(" + sqlConnection.Database + ").",
							"Data Service", e));
					}
					maintDataAdapter.UpdateCommand.Connection = sqlConnection;
					if (maintDataAdapter.InsertCommand != null)
					{
						maintDataAdapter.InsertCommand.Connection = null;
					}
					if (maintDataAdapter.DeleteCommand != null)
					{
						maintDataAdapter.DeleteCommand.Connection = null;
					}
					bNeedToCloseConnection = true;
				}
				else
				{
					maintDataAdapter.UpdateCommand.Connection = TransactionManager.CurrentConnection;
				}
				numRows = maintDataAdapter.Update (userDataSet, sqlTableName);
				if (numRows == 1)
				{
					bRetval = true;
				}
			}
			catch (DBOpenException dbExcep)
			{
				// Do not rewrapper a db open exception caught and wrappered earlier
				throw (dbExcep);
			}
			catch (System.Exception e)
			{
				throw new UpdateException( "Metoda UpdateRow pentru DataTable [" + sqlTableName + "] a esuat; "
					+ e.Message, this.ToString(), e );
			}			
			finally 
			{
				if (bNeedToCloseConnection)
				{
					maintDataAdapter.UpdateCommand.Transaction = null;
					if (sqlConnection.State == ConnectionState.Open)
					{
						sqlConnection.Close ();
						sqlConnection.Dispose ();
					}
				}
				if (maintDataAdapter.UpdateCommand != null)
				{
					maintDataAdapter.UpdateCommand.Connection = null;
				}
			}
			return (bRetval);
		}
		/// <summary>
		/// Se utilizeaza in situatii nestandard de update/insert/delete (cu un subquerry in general)
		/// In situatia in care apare o exceptie sql se returneaza chiar exceptia. Este de datoria caller-ului
		/// sa faca re-wrapp la exceptie
		/// </summary>
		/// <param name="userDataSet">[DataSet]Se trimtie un data set in care se face insert
		/// folosind comanda de select a adapterului pasat ca parametru.</param>
		/// <param name="maintDataAdapter">[SqlDataAdapter]Adaptarul ce contine comanda de update/insert/delete
		///  si comanda de select folosita pentru returnarea row-ului updatat</param>
		/// <returns>[bool] true daca operatiunea s-a efectuat cu succes</returns>
		protected bool UpdateRowExec(DataSet userDataSet, SqlDataAdapter sqlAdapter)
		{
			bool bNeedToCloseConnection = false;
			bool bRetval = true;
			int numRows;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			if (sqlAdapter == null)
				throw new DomainException("System Error: DataService nu are adapter!");

			if (TransactionManager.CurrentConnection == null)  // we are not in a transaction
			{
				try
				{
					sqlConnection = new SqlConnection (TransactionManager.ConnectionString);
					sqlConnection.Open ();
				}
				catch (System.Exception e)
				{
					throw (new DBOpenException ( 
						"Nu se poate deschide o conexiune catre baza de date: " +
						sqlConnection.DataSource + "(" + sqlConnection.Database + ").",
						"Data Service", e));
				}
				if( !System.EnterpriseServices.ContextUtil.IsInTransaction )
				{
					sqlTransaction = sqlConnection.BeginTransaction( sqlTableName );
				}
				bNeedToCloseConnection = true;
			}
			else
			{
				if( !System.EnterpriseServices.ContextUtil.IsInTransaction )
				{
					sqlTransaction = TransactionManager.CurrentConnection.BeginTransaction( sqlTableName );
					sqlConnection = TransactionManager.CurrentConnection;
				}
			}
			try
			{
				if( sqlAdapter.SelectCommand != null )
				{
					sqlAdapter.SelectCommand.Connection = sqlConnection;
					sqlAdapter.SelectCommand.Transaction = sqlTransaction;
				}
				if (sqlAdapter.InsertCommand != null)
				{
					sqlAdapter.InsertCommand.Connection = sqlConnection;
					sqlAdapter.InsertCommand.Transaction = sqlTransaction;
				}
				if (sqlAdapter.UpdateCommand != null)
				{
					sqlAdapter.UpdateCommand.Connection = sqlConnection;
					sqlAdapter.UpdateCommand.Transaction = sqlTransaction;
				}
				if (sqlAdapter.DeleteCommand != null)
				{
					sqlAdapter.DeleteCommand.Connection = sqlConnection;
					sqlAdapter.DeleteCommand.Transaction = sqlTransaction;
				}
				numRows = sqlAdapter.UpdateCommand.ExecuteNonQuery();
				if( sqlAdapter.SelectCommand != null)
				{
					numRows = sqlAdapter.Fill (userDataSet, sqlTableName);
				}
				if( numRows == 1 )
					bRetval = true;
				if (sqlTransaction != null)
				{
					sqlTransaction.Commit ();
					sqlTransaction.Dispose ();
				}
			}
			catch( SqlException e)
			{
				if (sqlTransaction != null)
				{
					sqlTransaction.Rollback ();
					sqlTransaction.Dispose ();
				}
				throw e;
			}
			catch (Exception e)
			{
				if (sqlTransaction != null)
				{
					sqlTransaction.Rollback ();
					sqlTransaction.Dispose ();
				}
				throw new UpdateException( "Metoda UpdateDS pentru DataTable [" + sqlTableName + "] a esuat; "
					+ e.Message, this.ToString(), e );
			}
			finally 
			{
				if (bNeedToCloseConnection)
				{
					if (sqlConnection.State == ConnectionState.Open)
					{
						sqlConnection.Close ();
						sqlConnection.Dispose ();
					}
				}
				if (sqlAdapter != null)
				{
					if (sqlAdapter.SelectCommand != null)
					{
						sqlAdapter.SelectCommand.Connection = null;
						sqlAdapter.SelectCommand.Transaction = null;
					}
					if (sqlAdapter.InsertCommand != null)
					{
						sqlAdapter.InsertCommand.Connection = null;
						sqlAdapter.InsertCommand.Transaction = null;
					}
					if (sqlAdapter.UpdateCommand != null)
					{
						sqlAdapter.UpdateCommand.Connection = null;
						sqlAdapter.UpdateCommand.Transaction = null;
					}
					if (sqlAdapter.DeleteCommand != null)
					{
						sqlAdapter.DeleteCommand.Connection = null;
						sqlAdapter.DeleteCommand.Transaction = null;
					}
				}
			}
			return (bRetval);
		}
		protected bool UpdateDS (DataSet userDataSet, AdapterList viewDataAdapter)
		{
			bool bNeedToCloseConnection = false;
			bool bRetval = true;
			int numRowsAffected, numRowsBefore;
			DataTable dt;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			SqlDataAdapter sqlAdapter = null;

			if (TransactionManager.CurrentConnection == null)  // we are not in a transaction
			{
				try
				{
					sqlConnection = new SqlConnection (TransactionManager.ConnectionString);
					sqlConnection.Open ();
				}
				catch (System.Exception e)
				{
					throw (new DBOpenException ( 
						"Nu se poate deschide o conexiune catre baza de date: " +
						sqlConnection.DataSource + "(" + sqlConnection.Database + ").",
						"Data Service", e));
				}
				if( !System.EnterpriseServices.ContextUtil.IsInTransaction )
				{
					sqlTransaction = sqlConnection.BeginTransaction( sqlTableName );
				}
				bNeedToCloseConnection = true;
			}
			else
			{
				if( !System.EnterpriseServices.ContextUtil.IsInTransaction )
				{
					sqlTransaction = TransactionManager.CurrentConnection.BeginTransaction( sqlTableName );
					sqlConnection = TransactionManager.CurrentConnection;
				}
			}
			try
			{
				foreach (string tbl in viewDataAdapter.Keys)
				{
					dt = userDataSet.Tables[tbl];
					if (dt == null)
						throw new DomainException("System Error: DataSet nu are tabela " + tbl);
					sqlTableName = dt.TableName;
					numRowsBefore = dt.Rows.Count;
					if (numRowsBefore==0) continue;
					sqlAdapter = viewDataAdapter [tbl];
					if (sqlAdapter == null)
                        throw new DomainException("System Error: DataService nu are adapter pentru tabela " + tbl);
                    if (sqlAdapter.SelectCommand != null)
                    {
                        sqlAdapter.SelectCommand.Connection = sqlConnection;
                        sqlAdapter.SelectCommand.Transaction = sqlTransaction;
                    }
					if (sqlAdapter.InsertCommand != null)
					{
						sqlAdapter.InsertCommand.Connection = sqlConnection;
						sqlAdapter.InsertCommand.Transaction = sqlTransaction;
					}
					if (sqlAdapter.UpdateCommand != null)
					{
						sqlAdapter.UpdateCommand.Connection = sqlConnection;
						sqlAdapter.UpdateCommand.Transaction = sqlTransaction;
					}
                    if (sqlAdapter.DeleteCommand != null)
                    {
                        sqlAdapter.DeleteCommand.Connection = sqlConnection;
                        sqlAdapter.DeleteCommand.Transaction = sqlTransaction;
                    }
					//numRowsAffected = sqlAdapter.Update (userDataSet, dt.TableName);
                    numRowsAffected = sqlAdapter.Update(dt.Select(null, null, DataViewRowState.Added | DataViewRowState.ModifiedCurrent));
					bRetval &= (numRowsAffected == numRowsBefore);
				}
                for (int i = viewDataAdapter.Count; i > 0; i--)
                {
                    string tbl = viewDataAdapter.Keys[i-1];
                    dt = userDataSet.Tables[tbl];
                    if (dt == null)
                        throw new DomainException("System Error: DataSet nu are tabela " + tbl);
                    sqlTableName = dt.TableName;
                    numRowsBefore = dt.Rows.Count;
                    if (numRowsBefore == 0) continue;
                    sqlAdapter = viewDataAdapter[tbl];
                    if (sqlAdapter.SelectCommand.CommandType == CommandType.StoredProcedure)
                        numRowsAffected = sqlAdapter.Fill(dt);
                    else
                        numRowsAffected = sqlAdapter.Update(dt.Select(null, null, DataViewRowState.Deleted));
                    bRetval &= (numRowsAffected == numRowsBefore);
                }
				if (sqlTransaction != null)
				{
					sqlTransaction.Commit ();
					sqlTransaction.Dispose ();
				}
			}
			catch(SqlException sqlExcep)
			{
				if (sqlTransaction != null)
				{
					sqlTransaction.Rollback ();
					sqlTransaction.Dispose ();
				}
				switch( sqlExcep.Number.ToString())
				{
					case "2627" :
						throw new UpdateException("Valoare introdusa existenta");
					default:
						throw new UpdateException("Cod eroare: " + sqlExcep.Number.ToString(), this.ToString(), sqlExcep);
				}
			}
			catch (Exception e)
			{
				if (sqlTransaction != null)
				{
					sqlTransaction.Rollback ();
					sqlTransaction.Dispose ();
				}
				throw new UpdateException( "Metoda UpdateDS pentru DataTable [" + sqlTableName + "] a esuat; "
					+ e.Message, this.ToString(), e );
			}
			finally 
			{
				if (bNeedToCloseConnection)
				{
					if (sqlConnection.State == ConnectionState.Open)
					{
						sqlConnection.Close ();
						sqlConnection.Dispose ();
					}
				}
				if (sqlAdapter != null)
				{
					if (sqlAdapter.SelectCommand != null)
					{
						sqlAdapter.SelectCommand.Connection = null;
						sqlAdapter.SelectCommand.Transaction = null;
					}
					if (sqlAdapter.InsertCommand != null)
					{
						sqlAdapter.InsertCommand.Connection = null;
						sqlAdapter.InsertCommand.Transaction = null;
					}
					if (sqlAdapter.UpdateCommand != null)
					{
						sqlAdapter.UpdateCommand.Connection = null;
						sqlAdapter.UpdateCommand.Transaction = null;
					}
					if (sqlAdapter.DeleteCommand != null)
					{
						sqlAdapter.DeleteCommand.Connection = null;
						sqlAdapter.DeleteCommand.Transaction = null;
					}
				}
			}
			return (bRetval);
		}
		protected bool UpdateRows (DataSet uds, SqlDataAdapter da)
		{
			return UpdateRows (uds, da, sqlTableName);
		}
		protected bool UpdateRows (DataSet userDataSet, SqlDataAdapter maintDataAdapter, string tbl)
		{
			bool bRetval = false;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			bool bNeedToCloseConnection = false;
			if (TransactionManager.CurrentConnection == null)  // we are not in a transaction
			{
				try
				{
					sqlConnection = new SqlConnection (TransactionManager.ConnectionString);
					sqlConnection.Open ();
				}
				catch (System.Exception e)
				{
					throw (new DBOpenException (
						"Nu se poate deschide o conexiune catre baza de date: " +
						sqlConnection.DataSource + "(" + sqlConnection.Database + ").",
						"Data Service", e));
				}
				if( !System.EnterpriseServices.ContextUtil.IsInTransaction )
				{
					sqlTransaction = sqlConnection.BeginTransaction( tbl );
				}
				if (maintDataAdapter.InsertCommand != null)
				{
					maintDataAdapter.InsertCommand.Connection = sqlConnection;
					maintDataAdapter.InsertCommand.Transaction = sqlTransaction;
				}
				if (maintDataAdapter.UpdateCommand != null)
				{
					maintDataAdapter.UpdateCommand.Connection = sqlConnection;
					maintDataAdapter.UpdateCommand.Transaction = sqlTransaction;
				}
				if (maintDataAdapter.DeleteCommand != null)
				{
					maintDataAdapter.DeleteCommand.Connection = sqlConnection;
					maintDataAdapter.DeleteCommand.Transaction = sqlTransaction;
				}
				bNeedToCloseConnection = true;
			}
			else
			{
				if( !System.EnterpriseServices.ContextUtil.IsInTransaction )
				{
					sqlTransaction = TransactionManager.CurrentConnection.BeginTransaction( tbl );
				}
				if (maintDataAdapter.InsertCommand != null)
				{
					maintDataAdapter.InsertCommand.Connection = TransactionManager.CurrentConnection;
					maintDataAdapter.InsertCommand.Transaction = sqlTransaction;
				}
				if (maintDataAdapter.UpdateCommand != null)
				{
					maintDataAdapter.UpdateCommand.Connection = TransactionManager.CurrentConnection;
					maintDataAdapter.UpdateCommand.Transaction = sqlTransaction;
				}
				if (maintDataAdapter.DeleteCommand != null)
				{
					maintDataAdapter.DeleteCommand.Connection = TransactionManager.CurrentConnection;
					maintDataAdapter.DeleteCommand.Transaction = sqlTransaction;
				}
			}
			try
			{
				int numRowsAffected, numRowsBefore;
				numRowsBefore = userDataSet.Tables[tbl].Rows.Count;
				numRowsAffected = maintDataAdapter.Update (userDataSet, tbl);
				if (numRowsAffected == numRowsBefore)
				{
					bRetval = true;
				}
				if (sqlTransaction != null)
				{
					sqlTransaction.Commit ();
					sqlTransaction.Dispose ();
				}
			}
			catch (Exception e)
			{
				if (sqlTransaction != null)
				{
					sqlTransaction.Rollback ();
					sqlTransaction.Dispose ();
				}
				throw new UpdateException( "Metoda UpdateRows pentru DataTable [" + tbl + "] a esuat; "
					+ e.Message, this.ToString(), e );
			}
			finally
			{
				if (bNeedToCloseConnection)
				{
					if (sqlConnection.State == ConnectionState.Open)
					{
						sqlConnection.Close ();
						sqlConnection.Dispose();
					}
				}
				if (maintDataAdapter.InsertCommand != null)
				{
					maintDataAdapter.InsertCommand.Connection = null;
					maintDataAdapter.InsertCommand.Transaction = null;
				}
				if (maintDataAdapter.UpdateCommand != null)
				{
					maintDataAdapter.UpdateCommand.Connection = null;
					maintDataAdapter.UpdateCommand.Transaction = null;
				}
				if (maintDataAdapter.DeleteCommand != null)
				{
					maintDataAdapter.DeleteCommand.Connection = null;
					maintDataAdapter.DeleteCommand.Transaction = null;
				}
			}
			return (bRetval);
		}
        /// <summary>
        /// Executa un statement de sql specificat prin comanda de select a adapterului
        /// </summary>
        /// <param name="sqlAdapter">[SqlDataAdapter] sqlAdapter</param>
        /// <returns>[bool]true/false</returns>
        protected bool ExecTransactSQL(SqlDataAdapter sqlAdapter)
        {
            return( ExecTransactSQL(null, sqlAdapter));
        }
        /// <summary>
        /// Executa un statement de sql specificat prin comanda de select a adapterului
        /// </summary>
        /// <param name="filterList">{IList] filter list</param>
        /// <param name="sqlAdapter">[SqlDataAdapter] sqlAdapter</param>
        /// <returns>[bool]true/false</returns>
        protected bool ExecTransactSQL(System.Collections.IList filterList, SqlDataAdapter sqlAdapter)
        {
            bool bRetval = false;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            bool bNeedToCloseConnection = false;
            if (TransactionManager.CurrentConnection == null)  // we are not in a transaction
            {
                try
                {
                    sqlConnection = new SqlConnection (TransactionManager.ConnectionString);
                    sqlConnection.Open ();
                }
                catch (System.Exception e)
                {
                    throw (new DBOpenException (
                        "Nu se poate deschide o conexiune catre baza de date: " +
                        sqlConnection.DataSource + "(" + sqlConnection.Database + ").",
                        "Data Service", e));
                }
                if( !System.EnterpriseServices.ContextUtil.IsInTransaction )
                {
                    sqlTransaction = sqlConnection.BeginTransaction();
                }
                if( sqlAdapter.SelectCommand != null )
                {
                    sqlAdapter.SelectCommand.Connection = sqlConnection;
                    sqlAdapter.SelectCommand.Transaction = sqlTransaction;
                }
                bNeedToCloseConnection = true;
            }
            else
            {
                if( !System.EnterpriseServices.ContextUtil.IsInTransaction )
                {
                    sqlTransaction = TransactionManager.CurrentConnection.BeginTransaction();
                }
                if( sqlAdapter.SelectCommand != null )
                {
                    sqlAdapter.SelectCommand.Connection = sqlConnection;
                    sqlAdapter.SelectCommand.Transaction = sqlTransaction;
                }
            }
            try
            {
                String oldSelCommand = null;
                if (filterList != null && filterList.Count != 0)
                {
                    String newSelCommand;
                    oldSelCommand = sqlAdapter.SelectCommand.CommandText;
                    newSelCommand = (String) oldSelCommand.Clone();
                    System.Collections.IEnumerator filterEnumerator = filterList.GetEnumerator();
                    bool firstTime = true;
                    bool hasParams = false;
                    int orderIndex;
                    while (filterEnumerator.MoveNext())
                    {
                        FilterInfo nextFilter = (FilterInfo)
                            filterEnumerator.Current;
                        if (sqlAdapter.SelectCommand.Parameters.Contains(nextFilter.FilterVar))
                        {
                            sqlAdapter.SelectCommand.Parameters[nextFilter.FilterVar].Value = nextFilter.FilterValue;
                            hasParams = true;
                            if (!firstTime)
                            {
                                newSelCommand = (String) oldSelCommand.Clone();
                            }
                        }
                        else if (!hasParams)
                        {
                            orderIndex = newSelCommand.ToUpper().IndexOf( "ORDER" );
                            if (firstTime)
                            {
                                firstTime = false;
                                if( orderIndex >= 0 )
                                {
                                    newSelCommand = newSelCommand.Insert( orderIndex, " WHERE " + nextFilter.RenderFilterForSQL() + " " );
                                }
                                else
                                {
                                    newSelCommand = newSelCommand + " WHERE " +
                                        nextFilter.RenderFilterForSQL();
                                }
                            }
                            else
                            {
                                if( orderIndex >= 0 )
                                {
                                    newSelCommand = newSelCommand.Insert( orderIndex, " AND " + nextFilter.RenderFilterForSQL() + " " );
                                }
                                else
                                {
                                    newSelCommand = newSelCommand + " AND " + nextFilter.RenderFilterForSQL();
                                }
                            }
                        }
                    }
                    if (newSelCommand != oldSelCommand)
                    {
                        sqlAdapter.SelectCommand.CommandText = newSelCommand;
                    }
                }
                sqlAdapter.SelectCommand.CommandTimeout = sqlConnection.ConnectionTimeout;
                int numRowsAffected = sqlAdapter.SelectCommand.ExecuteNonQuery();
                bRetval = true;
                if (sqlTransaction != null)
                {
                    sqlTransaction.Commit ();
                    sqlTransaction.Dispose ();
                }
            }
            catch (Exception e)
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Rollback ();
                    sqlTransaction.Dispose ();
                }
                throw new UpdateException( "Metoda ExecuteNonQuery a esuat; "
                    + e.Message, this.ToString(), e );
            }
            finally
            {
                if (bNeedToCloseConnection)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close ();
                        sqlConnection.Dispose();
                    }
                }
                if( sqlAdapter.SelectCommand != null )
                {
                    sqlAdapter.SelectCommand.Connection = null;
                    sqlAdapter.SelectCommand.Transaction = null;
                }

            }
            return (bRetval);
        }
        protected void ExecTransactCustomSQLScripts(String pSqlScript)
        {
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            bool bNeedToCloseConnection = false;
            if (TransactionManager.CurrentConnection == null)  // we are not in a transaction
            {
                try
                {
                    sqlConnection = new SqlConnection(TransactionManager.ConnectionString);
                    sqlConnection.Open();
                }
                catch (System.Exception e)
                {
                    throw (new DBOpenException(
                        "Nu se poate deschide o conexiune catre baza de date: " +
                        sqlConnection.DataSource + "(" + sqlConnection.Database + ").",
                        "Data Service", e));
                }
                if (!System.EnterpriseServices.ContextUtil.IsInTransaction)
                {
                    sqlTransaction = sqlConnection.BeginTransaction();
                }
                bNeedToCloseConnection = true;
            }
            else
            {
                if (!System.EnterpriseServices.ContextUtil.IsInTransaction)
                {
                    sqlTransaction = TransactionManager.CurrentConnection.BeginTransaction();
                }
            }
            try
            {
                Regex regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                string[] lines = regex.Split(pSqlScript);
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandTimeout = sqlConnection.ConnectionTimeout;
                    cmd.Transaction = sqlTransaction;
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            cmd.CommandText = line;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                if (sqlTransaction != null)
                {
                    sqlTransaction.Commit();
                    sqlTransaction.Dispose();
                }
            }
            catch (Exception e)
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Rollback();
                    sqlTransaction.Dispose();
                }
                throw new UpdateException("Metoda ExecTransactCustomSQLScripts a esuat; "
                    + e.Message, this.ToString(), e);
            }
            finally
            {
                if (bNeedToCloseConnection)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                    }
                }
            }
        }
        #endregion
        
		#endregion

		#endregion

		#region Private Methods
		protected void CopyKeys(IList keyList, IList firstList)
		{
			IEnumerator enumerator = firstList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				FilterInfo key = (FilterInfo)enumerator.Current;
				if (!keyList.Contains(key.FilterVar))
				{
					FilterInfo k = new FilterInfo(key.FilterVar, key.FilterValue, 
						FilterInfo.FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL);
					keyList.Add(k);
				}
			}
		}
		private void setPrimaryKeys (ref System.Data.SqlClient.SqlCommand currentCommand, System.Collections.IList keyList)
		{
			System.Collections.IEnumerator enumerator = keyList.GetEnumerator ();
			while (enumerator.MoveNext ())
			{
				FilterInfo key = (FilterInfo) enumerator.Current;
				if (currentCommand.Parameters.Contains (key.FilterVar))
				{
					// The filter class replaces single quotes with two single quotes
					// When assigning to a parameter, we only want one single quote
					object fValue = key.FilterValue;
					currentCommand.Parameters[key.FilterVar].Value =
						( fValue == null ) ? fValue : (
						fValue.GetType ().IsInstanceOfType(String.Empty) ?
						((String)fValue).Replace ( "''", "'" ) : fValue );
				}
			}
		}
		#endregion

		#region Public Methods

		public int MaxLength (string tableName, string columnName)
		{
			int lth = 50;
			object obj;
			System.Configuration.AppSettingsReader appSettingsReader = new System.Configuration.AppSettingsReader();
			string sconn = (String)appSettingsReader.GetValue("nha.ics.connectionstring", Type.GetType("System.String") );
			if (sconn.Equals(""))
				throw new Exception("System Error: DataService: Null connection string");
			SqlConnection conn = new SqlConnection(sconn);
			try
			{
				conn.Open();
				sqlSelectCommandMaxLength.Connection = conn;
				if (sqlSelectCommandMaxLength.Parameters.Contains("@tableName"))
					sqlSelectCommandMaxLength.Parameters["@tableName"].Value = tableName;
				if (sqlSelectCommandMaxLength.Parameters.Contains("@columnName"))
					sqlSelectCommandMaxLength.Parameters["@columnName"].Value = columnName;
				obj = sqlSelectCommandMaxLength.ExecuteScalar();
				if (obj != DBNull.Value)
					lth = Convert.ToInt32(obj);
			}
			catch (Exception excep)
			{
				throw new Exception("System Error: DataService: " + excep.Message, excep);
			}
			finally
			{
				if (conn.State != ConnectionState.Closed)
					conn.Close();
			}
			return lth;
		}

		#endregion

	}
}
