using System;
using System.EnterpriseServices;
using System.Reflection;

namespace GSBusFramework
{
	/// <summary>
	/// COMPlusTransactionManager is used to invoke methods that are
	/// transactionional.
	/// </summary>
#if DEBUG
	[TransactionAttribute(TransactionOption.Required, Timeout = 999)]
#else
	[TransactionAttribute(TransactionOption.Required)]
#endif
	[ObjectPooling]
	[JustInTimeActivation]
	public class COMPlusTransactionManager : System.EnterpriseServices.ServicedComponent
	{
		#region Constructors
		public COMPlusTransactionManager()
		{
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This method uses remoting to invoke the given service method in a transactional context.
		/// </summary>
		/// <param name="pSvcClass">[in] Instance of the service class.
		/// <param name="pMethodName">[in] Method name to invoke in the service class</param>
		/// <param name="args">[in] Parameters to the method</param>
		/// <returns>[out] Return value as a object - to be cast to actual return type by the
		/// caller.</returns>
		[AutoComplete]
		public Object ExecuteTransaction(Object pSvcClass, string pMethodName, params Object[] args )
		{
			Object retval = null;
			bool errStatus = false;
			string pSvcClassName = string.Empty;
			try
			{
				// Create an array of argument types
				System.Type[] theClientMethodParamTypes = null;
				if( args != null )
				{
					if( args.Length > 0 )
					{
						theClientMethodParamTypes = new System.Type[args.Length];
						for( int ix=0; ix<args.Length; ix++ )
							theClientMethodParamTypes[ix] = args[ix].GetType();
					}
				}
				if( pSvcClass != null )
				{
					pSvcClassName = pSvcClass.ToString();
					System.Reflection.MethodInfo mInfo = null;
					// Get target method info
					if( theClientMethodParamTypes == null )
						mInfo = pSvcClass.GetType().GetMethod( pMethodName,
							(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) );
					else
						mInfo = pSvcClass.GetType().GetMethod( pMethodName, 
							(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public), null,
							theClientMethodParamTypes, null );
					if( mInfo != null )
					{
						retval = mInfo.Invoke( pSvcClass, args );
					}
					else
						errStatus = true;
				}
				else
					errStatus = true;
			}
			catch (DomainException dx)
			{
				throw (dx);
			}
			catch (System.Reflection.TargetInvocationException ex )
			{
				// Unpackage target exception if available
				if( ex.InnerException != null ) throw ex.InnerException;
				else throw ex;
			}
			catch (Exception ex)
			{
				throw new DomainException( "Error invoking method [" + pSvcClassName + "." + pMethodName + "].", ex );
			}
			finally
			{
				// This is usually caused by not registering a DLL in the GAC
				// when used in a web application.  Throw an Exception instead
				// of a DomainException so it gets back correctly through the
				// remote call.
				if( errStatus )
					throw new Exception( "Error invoking method [" + pSvcClassName + "." + pMethodName + "].");
			}
			return retval;
		}
		#endregion
	}
}
