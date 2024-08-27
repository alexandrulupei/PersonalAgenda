using System;

namespace GSBusFramework
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public interface iDetailFactory
	{
		// Construct and Initialize from DataSet row
		Object NewDetail (System.Data.DataRow dsRow);
		Object NewDetailForList (System.Data.DataRow dsRow, System.Collections.IList detailList);

		// Construct with no Initialization
		Object NewDetail ();
		Object NewDetailForList (System.Collections.IList detailList);

		// Construct and initialize with ID
		Object NewDetail (Guid ID);
		Object NewDetailForList (Guid ID, System.Collections.IList detailList);
	}
}
