using System;

namespace GSBusFramework
{
	/// <summary>
	/// Summary description for BusinessService.
	/// </summary>
	public abstract class BusinessService : MarshalByRefObject, iDetailFactory, IMaintain
	{
		#region Nested Classes
		[Serializable()]
		public abstract class Info 
		{
			#region Member Variable
			private BusinessService.ObjState mState;
			private Guid mID;
			#endregion

			#region Properties
			private BusinessService.ObjState State
			{
				get 
				{
					return mState;
				}
				set 
				{
					mState = value;
				}
			}
			public bool Deleted
			{
				get 
				{
					return (State == BusinessService.ObjState.OBJSTATE_DELETED);
				}
			}
			public bool Modified
			{
				get 
				{
					return (State == BusinessService.ObjState.OBJSTATE_MODIFIED);
				}
			}
			public bool Created
			{
				get 
				{
					return (State == BusinessService.ObjState.OBJSTATE_CREATED);
				}
			}
			internal bool SetDeleted
			{
				set 
				{
					if (value)
					{
						State = BusinessService.ObjState.OBJSTATE_DELETED;
					}
				}
			}
			public bool SetModified
			{
				set 
				{
					if (State != BusinessService.ObjState.OBJSTATE_DELETED)
					{
						if (value && State != BusinessService.ObjState.OBJSTATE_CREATED)
						{
							State = BusinessService.ObjState.OBJSTATE_MODIFIED;
						}
						else if (!value)
						{
							State = BusinessService.ObjState.OBJSTATE_LOADED;
						}
					}
				}
			}
			protected internal Guid ID
			{
				get 
				{
					return mID;
				}
				set 
				{
					mID = value;
				}
			}
			#endregion

			#region Constructors
			public Info ()
			{
				State = BusinessService.ObjState.OBJSTATE_CREATED;
			}
			public Info(Guid pID)
			{
				ID = pID;
				State = BusinessService.ObjState.OBJSTATE_LOADED;
			}
			#endregion

			#region Public Methods
			public void Delete ()
			{
				SetDeleted = true;
			}
			#endregion
		}
		[Serializable()]
		public abstract class Detail 
		{
			#region Member Variable
			protected BusinessService.Info mInfoDelegate = null;
			#endregion

			#region Properties
			protected virtual BusinessService.Info InfoDelegate 
			{
				get 
				{
					return mInfoDelegate;
				}
			}

			#region Delegated Properties
			public bool Created
			{
				get 
				{
					return InfoDelegate.Created;
				}
			}
			public bool Deleted
			{
				get 
				{
					return InfoDelegate.Deleted;
				}
			}
			public bool Modified
			{
				get 
				{
					return InfoDelegate.Modified;
				}
			}
			internal bool SetDeleted
			{
				set
				{
					InfoDelegate.SetDeleted = value;
				}
			}
			public bool SetModified
			{
				set
				{
					InfoDelegate.SetModified = value;
				}
			}
			protected Guid ID
			{
				get 
				{
					return InfoDelegate.ID;
				}
				set
				{
					InfoDelegate.ID = value;
				}
			}
			#endregion

			#endregion

			#region Constructors & Casts
			public Detail ()
			{
			}
			public static implicit operator
				BusinessService.Info (BusinessService.Detail o)
			{
				return (o.InfoDelegate);
			}
			#endregion

			#region Public Methods
			public void Delete ()
			{
				SetDeleted = true;
			}
			#endregion
		}
		#endregion

		#region Member Variables and Enums
		private enum ObjState 
		{
			OBJSTATE_LOADED,
			OBJSTATE_CREATED,
			OBJSTATE_MODIFIED,
			OBJSTATE_DELETED
		};
		#endregion

		#region Constructors and Casts
		protected BusinessService()
		{
		}
		#endregion

		#region Public Methods
		public void SetDelete (BusinessService.Info obj)
		{
			obj.SetDeleted = true;
		}
		public void SetDelete (BusinessService.Detail obj)
		{
			obj.SetDeleted = true;
		}
		public Object NewDetail (System.Data.DataRow dsRow)
		{
			try
			{
				System.Type detailType = this.GetType().GetNestedType("Detail");
				if (detailType != null)
				{
					System.Type[] constructorParmTypes = new Type[1];
					constructorParmTypes[0] = dsRow.GetType();
					System.Reflection.ConstructorInfo constructor =
						detailType.GetConstructor(constructorParmTypes);
					if (constructor != null)
					{
						Object[] parms = new Object[1];
						parms[0] = dsRow;
						return (constructor.Invoke (parms));
					}
					throw new DomainException( "No constructor in nested Detail class, which takes System.Data.DataRow as a parameter" );
				}
				throw new DomainException( "No Detail nested class in " + this.ToString() );
			}
			catch( System.Exception excep )
			{
				throw new DomainException( "Failed to construct a NewDetail for " + this.ToString(), excep );
			}
		}
		public Object NewDetailForList (System.Data.DataRow dsRow,System.Collections.IList detailList)
		{
			try
			{
				Object detail = NewDetail(dsRow);
				detailList.Add (detail);
				return (detail);
			}
			catch
			{
				throw;
			}
		}
		public Object NewDetail ()
		{
			try
			{
				System.Type detailType = this.GetType().GetNestedType("Detail");
				if (detailType != null)
				{
					System.Type[] constructorParmTypes = new Type[0];
					System.Reflection.ConstructorInfo constructor =
						detailType.GetConstructor(constructorParmTypes);
					if (constructor != null)
					{
						return (constructor.Invoke (null));
					}
					throw new DomainException( "No constructor in nested Detail class, which takes no parameter" );
				}
				throw new DomainException( "No Detail nested class in " + this.ToString() );
			}
			catch( System.Exception excep )
			{
				throw new DomainException( "Failed to construct a NewDetail for " + this.ToString(), excep );
			}
		}
		public Object NewDetailForList (System.Collections.IList detailList)
		{
			try
			{
				Object detail = NewDetail();
				detailList.Add (detail);
				return (detail);
			}
			catch
			{
				throw;
			}
		}
		public Object NewDetail (Guid ID)
		{
			try
			{
				System.Type detailType = this.GetType().GetNestedType("Detail");
				if (detailType != null)
				{
					System.Type[] constructorParmTypes = new Type[1];
					constructorParmTypes[0] = ID.GetType();
					System.Reflection.ConstructorInfo constructor =
						detailType.GetConstructor(constructorParmTypes);
					if (constructor != null)
					{
						Object[] parms = new Object[1];
						parms[0] = ID;
						return (constructor.Invoke (parms));
					}
					throw new DomainException( "No constructor in nested Detail class, which takes Guid ID as a parameter" );
				}
				throw new DomainException( "No Detail nested class in " + this.ToString() );
			}
			catch( System.Exception excep )
			{
				throw new DomainException( "Failed to construct a NewDetail for " + this.ToString(), excep );
			}
		}
		public Object NewDetailForList (Guid ID, System.Collections.IList detailList)
		{
			try
			{
				Object detail = NewDetail(ID);
				detailList.Add (detail);
				return (detail);
			}
			catch
			{
				throw;
			}
		}
		public virtual bool Create (BusinessService.Detail pDetails)
		{
			System.Type myType = this.GetType();
			string myName = string.Empty;
			if (myType != null)
			{
				myName = myType.FullName;
			}
			throw new InsertException ("This method is not yet implemented [" + myName + "]." );
		}
		public virtual bool Update (BusinessService.Detail pDetails)
		{
			System.Type myType = this.GetType();
			string myName = string.Empty;
			if (myType != null)
			{
				myName = myType.FullName;
			}
			throw new UpdateException ("This method is not yet implemented [" + myName + "]." );
		}
		public virtual bool Update ( System.Collections.IList pDetailsList )
		{
			System.Type myType = this.GetType();
			string myName = string.Empty;
			if (myType != null)
			{
				myName = myType.FullName;
			}
			throw new UpdateException ("This method is not yet implemented [" + myName + "]." );
		}
		public virtual bool Delete (BusinessService.Detail pDetails)
		{
			System.Type myType = this.GetType();
			string myName = string.Empty;
			if (myType != null)
			{
				myName = myType.FullName;
			}
			throw new DeleteException ("This method is not yet implemented [" + myName + "]." );
		}
		/// <summary>
		/// This method uses remoting to invoke the given service method.
		/// </summary>
		/// <param name="pBusinessSvcName">[in] Qualified class name in the form "classname, assemblyname".
		/// e.g. "Person.Detail, Admissions"</param>
		/// <param name="pMethodName">[in] Method name to invoke in the data service</param>
		/// <param name="args">[in] Parameters to the method</param>
		/// <returns>[out] Return value as a object</returns>
		public static Object ExecuteService( string pBusinessSvcName, string pMethodName, 
			params Object[] args )
		{
			Object retval = null;
			bool errStatus = false;
			try
			{
				// Instantiate the class
				System.Reflection.Assembly classAssembly = null;
				Object newObject = null;
				string[] names;
				string assmName;
				string objName;
				names = pBusinessSvcName.Split(',');
				assmName = names[1].Trim();
				objName = assmName + "." + names[0].Trim();
				// Load the assembly containing the class
				classAssembly = System.Reflection.Assembly.Load(assmName);
				// Create an instance
				if( classAssembly != null )
					newObject = classAssembly.CreateInstance(objName);
				else 
					errStatus = true;
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
				if( newObject != null )
				{
					System.Reflection.MethodInfo mInfo = null;
					// Get target method info
					if( theClientMethodParamTypes == null )
						mInfo = newObject.GetType().GetMethod( pMethodName );
					else
						mInfo = newObject.GetType().GetMethod( pMethodName, theClientMethodParamTypes );
					if( mInfo != null )
					{
						retval = mInfo.Invoke( newObject, args );
					}
					else
						errStatus = true;
				}
				else
					errStatus = true;
			}
			catch (DomainException)
			{
				throw;
			}
			catch (System.Reflection.TargetInvocationException ex )
			{
				// Unpackage target exception if available
				if( ex.InnerException != null ) throw ex.InnerException;
				else throw ex;
			}
			catch (Exception ex)
			{
				throw new DomainException( "Error invoking method [" + pBusinessSvcName + "." + pMethodName + "].", ex );
			}
			finally
			{
				if( errStatus )
					throw new DomainException( "Error invoking method [" + pBusinessSvcName + "." + pMethodName + "].");
			}
			return retval;
		}
		#endregion
	}
}
