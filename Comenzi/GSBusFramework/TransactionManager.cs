using System;
using System.Data;
using System.Xml;
using System.Collections;
using System.Data.SqlClient;
//using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace GSBusFramework
{
	/// <summary>
	/// Summary description for TransactionManager
	/// </summary>
//#if DEBUG
//	[TransactionAttribute(TransactionOption.Required, Timeout = 999)]
//#else
//	[TransactionAttribute(TransactionOption.Required)]
//#endif
	public class TransactionManager // : ServicedComponent
	{

		#region Member Variables
		private static TransactionManager mCurrentTM = null;
		private static SqlConnection mConnection = null;
		private static SqlConnection mReadOnlyConnection = null;
		private static string mConnectionString;
		private static string mReadOnlyConnectionString;
		private string mTransactionName = null;
		private static string mCurrentFacility;
		private short refCount = 0;
		private static bool mUseDynamicConnectionString = false;
		private static String mUserName;
		private static String mPassword;
		#endregion

		#region Properties
		public static string ConnectionString 
		{
			get 
			{
				if( mConnectionString == null )
				{
					try
					{
					//	System.Configuration.AppSettingsReader appSettingsReader =
					//		new System.Configuration.AppSettingsReader();
						mConnectionString = new GSBusFramework.GS_Config().GetConfigPropertyValue("connectionstring");
						if( mUseDynamicConnectionString )
						{
							mConnectionString += ";user id="+mUserName+";password="+mPassword;
						}
					}
					catch( System.Exception excep )
					{
						throw new DomainException( "Nu s-a putut citi stringul de configurare din fisierul de configurare", excep );
					}
				}
				return mConnectionString;
			}
		}
		public static string ReadOnlyConnectionString 
		{
			get
			{
				if( System.EnterpriseServices.ContextUtil.IsInTransaction == true )
				{
					mReadOnlyConnectionString = ConnectionString;
				}
				else
				{
					mReadOnlyConnectionString = ConnectionString + ";Enlist=false";
				}
				return mReadOnlyConnectionString;
			}
            set
            {
                mConnectionString = value;
            }
		}
		public static SqlConnection CurrentConnection
		{
			get { return mConnection; }
            set { mConnection = value; }
		}
		public static SqlConnection ReadOnlyConnection
		{
			get 
			{
				mReadOnlyConnection = new SqlConnection (ReadOnlyConnectionString);
				return mReadOnlyConnection;
			}
		}
		public static string CurrentFacility 
		{
			get 
			{
				if( mCurrentFacility == null )
				{
					try
					{
						// System.Configuration.AppSettingsReader appSettingsReader =
						// 	new System.Configuration.AppSettingsReader();
						// mCurrentFacility = ( string ) appSettingsReader.GetValue( "nha.ics.currentfacility", typeof( string ) );
						mCurrentFacility = new GSBusFramework.GS_Config().GetConfigPropertyValue("currentfacility");
					}
					catch( System.Exception excep )
					{
						throw new DomainException( "Failed to get current facility from configuration file", excep );
					}
				}
				return mCurrentFacility;
			}
		}
		public String TransactionName
		{
			get { return mTransactionName; }
		}
		public static bool UseDynamicConnectionString
		{
			set
			{
				mConnectionString = null;
				mUseDynamicConnectionString = value;
			}
		}
		public static String UserName 
		{
			set
			{
				mUserName = value;
			}
		}
		public static String Password
		{
			set 
			{
				mPassword = value;
			}
		}
		#endregion

		#region Constructors
		public TransactionManager()
		{
			// 
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Static Methods
		static public TransactionManager GetTransactionManager ()
		{
			if (mCurrentTM == null)
			{
				mCurrentTM = new TransactionManager ();
				mCurrentTM.refCount = 1;
//				mCurrentTM.BeginOrJoinTransaction();
			}
			else
			{
				++mCurrentTM.refCount;
			}
			return (mCurrentTM);
		}
		static public void ReleaseTransactionManager ()
		{
			if (mCurrentTM != null)
			{
				if (--mCurrentTM.refCount <= 0)
				{
					// mCurrentTM.CommitTransaction();
//					mCurrentTM.EndTransaction();
//					mCurrentTM.Dispose ();
					mCurrentTM = null;
				}
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// All methods that start transactions should create
		/// data services using this method using the transaction
		/// manager context returned by GetTransactionManager().
		/// </summary>
		public DataService GetDataService( string pDataServiceName )
		{
			DataService dataSvc = null;
			try
			{
				System.Reflection.Assembly pAssembly = System.Reflection.Assembly.Load( "AdmissionsDataServicesLib" );
				dataSvc = (DataService) pAssembly.CreateInstance ("Admissions." + pDataServiceName);
			}
			catch (Exception e)
			{
				String errMsg = e.Message;
			}
			return dataSvc;
		}
		public static SqlConnection BeginOrJoinTransaction( )
		{
			if( mConnection == null )
			{
				try
				{
					mConnection = new SqlConnection(ConnectionString);
					mConnection.Open();
				}
				catch( Exception e )
				{
					throw new DomainException( "An exception occurred establishing the database connection,\n Connection String = " +
						ConnectionString, e );
				}
			}
			return mConnection;
		}
		public void AbortTransaction ()
		{
		}
		public static void EndTransaction( )
		{
			if(mConnection != null)
			{
				if (mConnection.State == ConnectionState.Open )
				{
					try
					{
						mConnection.Close();
					}
					catch( SqlException e )
					{
						throw new DomainException( "An exception occurred closing the database connection,\n Connection String = " +
							ConnectionString, e );
					}
					mConnection.Dispose();
					mConnection = null;
				}
			}
		}
		#endregion

		#region Private methods
		private void FinalizeTransaction ()
		{
			EndTransaction();
			if (mReadOnlyConnection != null)
			{
				if (mReadOnlyConnection.State == ConnectionState.Open)
					mReadOnlyConnection.Close();
				mReadOnlyConnection.Dispose();
				mReadOnlyConnection = null;
			}
			mCurrentTM = null;
		}
		#endregion

	}
}
