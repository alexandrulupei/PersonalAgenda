using System;
using System.Data;

namespace GSBusFramework
{
	/// <summary>
	/// Summary description for TransactionalService.
	/// </summary>
	[Serializable()]
	public abstract class TransactionalService : IMaintain
	{
		#region Constructors
		public TransactionalService()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public methods
		public virtual bool Create (BusinessService.Detail objDetails)
		{
			bool retval = false;
			try
			{
				using (COMPlusTransactionManager transmgr = new COMPlusTransactionManager())
				{
					retval = (bool) transmgr.ExecuteTransaction( this, "TransactionalCreate", objDetails );
				}
			}
			catch (DomainException)
			{
				throw;
			}
			catch (ApplicationException ex)
			{
				// Unpackage target exception if available
				if( ex.InnerException != null ) throw ex.InnerException;
			}
			return retval;
		}
		protected virtual bool TransactionalCreate (BusinessService.Detail objDetails)
		{
			throw new DomainException("Create(details) - method not found.");
		}
		public virtual bool Update (BusinessService.Detail objDetails)
		{
			bool retval = false;
			try
			{
				using (COMPlusTransactionManager transmgr = new COMPlusTransactionManager())
				{
					retval = (bool) transmgr.ExecuteTransaction( this, "TransactionalUpdate", objDetails );
				}
			}
			catch (DomainException)
			{
				throw;
			}
			catch (ApplicationException ex)
			{
				// Unpackage target exception if available
				if( ex.InnerException != null ) throw ex.InnerException;
			}
			return retval;
		}
		protected virtual bool TransactionalUpdate (BusinessService.Detail objDetails)
		{
			throw new DomainException("Update(details) - method not found.");
		}
		public virtual bool Delete (BusinessService.Detail objDetails)
		{
			bool retval = false;
			try
			{
				using (COMPlusTransactionManager transmgr = new COMPlusTransactionManager())
				{
					retval = (bool) transmgr.ExecuteTransaction( this, "TransactionalDelete", objDetails );
				}
			}
			catch (DomainException)
			{
				throw;
			}
			catch (ApplicationException ex)
			{
				// Unpackage target exception if available
				if( ex.InnerException != null ) throw ex.InnerException;
			}
			return retval;
		}
		protected virtual bool TransactionalDelete (BusinessService.Detail objDetails)
		{
			throw new DomainException("Delete(details) - method not found.");
		}
		public virtual bool Update( System.Collections.IList detailsList )
		{
			bool retval = false;
			try
			{
				using (COMPlusTransactionManager transmgr = new COMPlusTransactionManager())
				{
					retval = (bool) transmgr.ExecuteTransaction( this, "TransactionalUpdate", detailsList );
				}
			}
			catch (DomainException)
			{
				throw;
			}
			catch (ApplicationException ex)
			{
				// Unpackage target exception if available
				if( ex.InnerException != null ) throw ex.InnerException;
			}
			return retval;
		}
		protected virtual bool TransactionalUpdate (System.Collections.IList detailsList)
		{
			throw new DomainException("Update(detailsList) - method not found.");
		}
		public void Execute (BusinessService inst, String Method)
		{
			Execute( inst, Method, null );
		}
		public Object Execute (Object inst, String pMethod, params Object[] args)
		{
			Object retval = null;
			try
			{
				if (inst != null)
				{
					using (COMPlusTransactionManager transmgr = new COMPlusTransactionManager())
					{
						retval = transmgr.ExecuteTransaction( inst, pMethod, args );
					}
				}
				else
				{
					throw (new DomainException ("Cannot invoke instance method " + pMethod + ". Did not have an instance.",
						"Transactional Service", null));
				}
			}
			catch (DomainException)
			{
				throw;
			}
			catch (ApplicationException ex)
			{
				// Unpackage target exception if available
				if( ex.InnerException != null ) throw ex.InnerException;
			}
			return retval;
		}
		#endregion
	}
}
