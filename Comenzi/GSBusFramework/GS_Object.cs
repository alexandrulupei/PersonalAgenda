using System;

namespace GSBusFramework
{
	/// <summary>
	/// Base class for all inner classes in GS framework.
	/// </summary>
	[Serializable()]
	public class GS_Object 
	{
		#region member variables
		private Object mObject;
		private Object mOuterClass;
		private bool mOuterIsInfo;
		#endregion

		#region constructor
		private GS_Object ()
		{
		}
		public Object Clone (Object newParent)
		{
			GS_Object newInst = new GS_Object (newParent);
			if (this.mObject != null)
			{
				System.Type vType = this.mObject.GetType ();
				System.Type intfType = vType.GetInterface("ICloneable", false);
				if (intfType != null)
				{
					newInst.mObject = ((ICloneable)this.mObject).Clone ();
				}
				else
				{
					newInst.mObject = this.mObject;
				}
			}
			return ((Object)newInst);
		}

		// Constructor with outer class instance within which the object lives
		private GS_Object( Object OuterClass )
		{
			mOuterClass = OuterClass;
			if( typeof( BusinessService.Info ).IsInstanceOfType( mOuterClass ) )
			{
				mOuterIsInfo = true;
			}
			else
			{
				mOuterIsInfo = false;
			}
		}
		public GS_Object( BusinessService.Info OuterClass )
		{
			mOuterClass = OuterClass;
			mOuterIsInfo = true;
		}
		public GS_Object( BusinessService.Detail OuterClass )
		{
			mOuterClass = OuterClass;
			mOuterIsInfo = false;
		}

		#endregion

		#region properties
		// Defines the value of the object
		public Object Instance 
		{
			get
			{
				return( mObject );
			}
			set
			{
				try
				{
					if( Object.Equals( mObject, value ) == false )
					{
						mObject = value;
						if( this.mOuterIsInfo)
						{
							(( BusinessService.Info )mOuterClass ).SetModified = true;
						}
						else
						{
							(( BusinessService.Detail )mOuterClass ).SetModified = true;
						}
					}
				}
				catch( System.Exception excep )
				{
					throw new DomainException( "Failed in updating SetModified property of OuterClass", this.ToString(), excep );
				}
			}
		}
		#endregion

		#region implicit cast operator overloading methods
		public static implicit operator bool( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( bool ) rValue.Instance : (bool) false);
		}

		public static implicit operator byte( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( byte ) rValue.Instance : (byte) 0);
		}

		public static implicit operator char( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( char ) rValue.Instance : (char) 0);
		}

		public static implicit operator double( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( double ) rValue.Instance : (double)0.0);
		}

		public static implicit operator decimal( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( decimal ) rValue.Instance : (decimal)0.0);
		}

		public static implicit operator DateTime( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( DateTime ) rValue.Instance : DateTime.MinValue );
		}

		public static implicit operator float( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( float ) rValue.Instance : (float)0.0 );
		}

		public static implicit operator Guid( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( Guid ) rValue.Instance : Guid.Empty );
		}

		public static implicit operator short( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( short ) rValue.Instance : (short)0 );
		}

		public static implicit operator int( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( int ) rValue.Instance : (int)0 );
		}

		public static implicit operator long( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( long ) rValue.Instance : (long)0);
		}

		public static implicit operator sbyte( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( sbyte ) rValue.Instance : (sbyte)0 );
		}

		public static implicit operator string( GS_Object rValue )
		{
			return ( ( string ) rValue.Instance );
		}

		public static implicit operator uint( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( uint ) rValue.Instance : (uint)0);
		}

		public static implicit operator ulong( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( ulong ) rValue.Instance : (ulong)0);
		}

		public static implicit operator ushort( GS_Object rValue )
		{
			return ( rValue.Instance != null ? ( ushort ) rValue.Instance : (ushort)0);
		}
		#endregion

		#region overloading of ==, != operators
		public static bool operator !=( GS_Object lValue, Object rValue )
		{
			return ( lValue.Instance != rValue );
		}
		public static bool operator ==( GS_Object lValue, Object rValue )
		{
			return ( lValue.Instance == rValue );
		}
		//overloaded Equals method to make compiler :-)
		public override bool Equals( Object obj )
		{
			return( base.Equals( obj ) );
		}
		//overloaded GetHashCode method to make compiler :-)
		public override int GetHashCode()
		{
			return( base.GetHashCode() );
		}
		#endregion
	}
}