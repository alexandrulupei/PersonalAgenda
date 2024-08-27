using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;

namespace GSBusFramework
{
	/// <summary>
	/// Root exception object for the application domain.
	/// Any constraint voilation exception objects can be derived from this object.
	/// example unique key, nullable, and foreign key constraints
	/// </summary>
	[Serializable]
	public class DomainException : System.ApplicationException, ISerializable
	{
		#region Member Variables
		private ExceptionCodes mExceptionCode;
		#endregion

		#region Properties
		public ExceptionCodes ExceptionCode
		{
			get 
			{
				return mExceptionCode;
			}
		}
		#endregion

		#region constructor methods
		protected DomainException (SerializationInfo info, StreamingContext context)
		{
			mExceptionCode = (ExceptionCodes)info.GetValue ("mExceptionCode", typeof (int));
		}
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue ("mExceptionCode", (int)mExceptionCode);
			base.GetObjectData (info, context);
		}
		public DomainException()
			: base()
		{
			mExceptionCode = ExceptionCodes.EXECPTION_UNDEFINED;
		}

		public DomainException( string message )
			: base( message )
		{
		}

		public DomainException( string message, System.Exception inner )
			: base( message, inner )
		{
		}

		public DomainException( string message, string source, System.Exception inner )
			: base( message, inner )
		{
			this.Source = source;
		}
		public DomainException(ExceptionCodes pExceptionCode)
			: base()
		{
			mExceptionCode = pExceptionCode;
		}

		public DomainException( string message, ExceptionCodes pExceptionCode )
			: base( message )
		{
			mExceptionCode = pExceptionCode;
		}

		public DomainException( string message, System.Exception inner, ExceptionCodes pExceptionCode )
			: base( message, inner )
		{
			mExceptionCode = pExceptionCode;
		}

		public DomainException( string message, string source, System.Exception inner, ExceptionCodes pExceptionCode )
			: base( message, inner )
		{
			mExceptionCode = pExceptionCode;
			this.Source = source;
		}
		#endregion

		#region Enumerated Values
		[Serializable]
		public enum ExceptionCodes : int
		{
			EXECPTION_UNDEFINED = 0,

			BUSSVC_INSERTFAILURE = 10,
			BUSSVC_UPDATEFAILURE,
			BUSSVC_DELETEFAILURE,
			BUSSVC_SELECTFAILURE,

			// Generic Account Exceptions
			ACCT_INSUFFICIENTFORRESERVE = 20,
			ACCT_INSUFFICIENTRESERVE,

			// Trust account Exceptions
			TRUST_INSUFFICIENTRESERVE = 30,
			TRUST_INSUFFICIENTFUNDS,
			TRUST_WITHDRAWALLIMITSETBYERROR,
			TRUST_WITHDRAWALLIMITERROR,
			TRUST_SPENDINGEXCEEDSLIMITS,

			// Maintenance Account Exceptions
			MAINTACCT_EXCESSPAYMENT = 40,
			MAINTACCT_RESPONSIBLEPARTYNOTFOUND,
			MAINTACCT_NORESPONSIBLEPARTY,
			MAINTACCT_SUBACCOUNTEXISTS,

			// Census Exceptions
			CENSUS_NEEDBILLINGDAYS = 50,
			CENSUS_DATANOTRECONCILED,

			
			// Validation exceptions
			EXCEP_DATAVALIDATION = 500,

			// General Exceptions
			EXCEP_INVALIDBIRTHDATE = 1000,

			DATASVC_DBOPENFAILURE = 5000
		};
		#endregion

		#region public methods definitions
		
		//writes exception messages to console
		[Conditional( "DEBUG" )]
		public void WriteContentTo()
		{
			System.Exception traverse;
			try 
			{
				traverse = this;
				do
				{
					Console.WriteLine( traverse.Message );
					traverse = traverse.InnerException;
				} while( traverse != null );
			}
			catch ( System.Exception excep )
			{
				throw new DomainException( "Error while writing exception messages to console", excep );
			}
		}

		//writes exception messages to the filename in append mode
		[Conditional( "DEBUG" )]
		public void WriteContentTo( string filename )
		{
			System.Exception traverse;
			try 
			{
				StreamWriter writer = new StreamWriter( filename, true );
				traverse = this;
				do
				{
					writer.WriteLine( traverse.Message );
					traverse = traverse.InnerException;
				} while( traverse != null );
				writer.Close();
			}
			catch ( System.Exception excep )
			{
				throw new DomainException( "Error while writing exception messages to file", excep );;
			}
		}
		public void Log (string ApplicationName)
		{
			EventLog eLog = new EventLog ("Application");
			eLog.Source = ApplicationName;
			String ExceptionMessage = "";
			System.Exception traverse = this;
			do
			{
				ExceptionMessage += (traverse.Message + "\n");
				traverse = traverse.InnerException;
			} while (traverse != null);
			ExceptionMessage += ("\n\n" + this.StackTrace);
			eLog.WriteEntry (ExceptionMessage,EventLogEntryType.Error);
			eLog.Close ();
		}
		#endregion
	}
	[Serializable]
	public class DBOpenException : DomainException, ISerializable
	{
		#region constructor methods
		protected DBOpenException (SerializationInfo info, StreamingContext context)
		{
		}
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData (info, context);
		}
		public DBOpenException()
			: base(DomainException.ExceptionCodes.DATASVC_DBOPENFAILURE)
		{
		}

		public DBOpenException( string message )
			: base( message, DomainException.ExceptionCodes.DATASVC_DBOPENFAILURE )
		{
		}

		public DBOpenException( string message, System.Exception inner )
			: base( message, inner, DomainException.ExceptionCodes.DATASVC_DBOPENFAILURE )
		{
		}

		public DBOpenException( string message, string source, System.Exception inner )
			: base( message, source, inner, DomainException.ExceptionCodes.DATASVC_DBOPENFAILURE )
		{
		}
		#endregion
	}
	[Serializable]
	public class InsertException : DomainException, ISerializable
	{
		#region constructor methods
		protected InsertException (SerializationInfo info, StreamingContext context)
		{
		}
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData (info, context);
		}
		public InsertException()
			: base(DomainException.ExceptionCodes.BUSSVC_INSERTFAILURE)
		{
		}

		public InsertException( string message )
			: base( message, DomainException.ExceptionCodes.BUSSVC_INSERTFAILURE )
		{
		}

		public InsertException( string message, System.Exception inner )
			: base( message, inner, DomainException.ExceptionCodes.BUSSVC_INSERTFAILURE )
		{
		}

		public InsertException( string message, string source, System.Exception inner )
			: base( message, source, inner, DomainException.ExceptionCodes.BUSSVC_INSERTFAILURE )
		{
		}
		#endregion
	}
	[Serializable]
	public class UpdateException : DomainException, ISerializable
	{
		#region constructor methods
		protected UpdateException (SerializationInfo info, StreamingContext context)
		{
		}
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData (info, context);
		}
		public UpdateException()
			: base(DomainException.ExceptionCodes.BUSSVC_UPDATEFAILURE)
		{
		}

		public UpdateException( string message )
			: base( message, DomainException.ExceptionCodes.BUSSVC_UPDATEFAILURE )
		{
		}

		public UpdateException( string message, System.Exception inner )
			: base( message, inner, DomainException.ExceptionCodes.BUSSVC_UPDATEFAILURE )
		{
		}

		public UpdateException( string message, string source, System.Exception inner )
			: base( message, source, inner, DomainException.ExceptionCodes.BUSSVC_UPDATEFAILURE )
		{
		}
		#endregion
	}
	[Serializable]
	public class DeleteException : DomainException, ISerializable
	{
		#region constructor methods
		protected DeleteException (SerializationInfo info, StreamingContext context)
		{
		}
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData (info, context);
		}
		public DeleteException()
			: base(DomainException.ExceptionCodes.BUSSVC_DELETEFAILURE)
		{
		}

		public DeleteException( string message )
			: base( message, DomainException.ExceptionCodes.BUSSVC_DELETEFAILURE )
		{
		}

		public DeleteException( string message, System.Exception inner )
			: base( message, inner, DomainException.ExceptionCodes.BUSSVC_DELETEFAILURE )
		{
		}

		public DeleteException( string message, string source, System.Exception inner )
			: base( message, source, inner, DomainException.ExceptionCodes.BUSSVC_DELETEFAILURE )
		{
		}
		#endregion
	}
	[Serializable]
	public class SelectException : DomainException, ISerializable
	{
		#region constructor methods
		protected SelectException (SerializationInfo info, StreamingContext context)
		{
		}
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData (info, context);
		}
		public SelectException()
			: base(DomainException.ExceptionCodes.BUSSVC_SELECTFAILURE)
		{
		}

		public SelectException( string message )
			: base( message, DomainException.ExceptionCodes.BUSSVC_SELECTFAILURE )
		{
		}

		public SelectException( string message, System.Exception inner )
			: base( message, inner, DomainException.ExceptionCodes.BUSSVC_SELECTFAILURE )
		{
		}

		public SelectException( string message, string source, System.Exception inner )
			: base( message, source, inner, DomainException.ExceptionCodes.BUSSVC_SELECTFAILURE )
		{
		}
		#endregion
	}
}
