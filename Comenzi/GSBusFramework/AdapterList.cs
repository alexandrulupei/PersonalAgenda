using System;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace GSBusFramework
{
	/// <summary>
	/// AdapterList holds a pair of name, SqlDataAdapter
	/// </summary>
    [Serializable]
	public class AdapterList : NameObjectCollectionBase
	{
		public AdapterList()
		{
		}

		public SqlDataAdapter this [string tableName]
		{
			get {return (SqlDataAdapter)BaseGet(tableName);}
			set {BaseSet(tableName, value);}
		}
	}
}
