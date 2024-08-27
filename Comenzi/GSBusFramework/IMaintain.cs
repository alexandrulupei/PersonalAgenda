using System;

namespace GSBusFramework
{
	/// <summary>
	/// Interface definition for create, delete, and update operations.
	/// </summary>
	public interface IMaintain
	{
		bool Create( BusinessService.Detail dataItem );
		bool Delete( BusinessService.Detail dataItem );
		bool Update( BusinessService.Detail dataItem );
		bool Update( System.Collections.IList detailsList );

	}
}
