using System;
using System.Diagnostics;
using System.Reflection;
using System.Data;


namespace GSFramework
{
	/// <summary>
	/// Summary description for Remote.
	/// </summary>
	public class Remote:MarshalByRefObject
	{
		public static void Configure(String theConfigFileName)
		{
			System.Runtime.Remoting.RemotingConfiguration.Configure(theConfigFileName, true);
		}

		public static  bool Load(Controller theController)
		{
			GSFramework.ClientContext savedContext = theController.Context;
			Controller savedController = theController;
			DataSet savedDataset = theController.DataSet;

			Remote theReceiver = new Remote();
			bool theResult  = theReceiver.RemoteLoad(theController);

			if( theController.DataSet != null )
				savedDataset.Merge(theController.DataSet);
			// copy other data members from theController to savedController
			theController.Context = savedContext;
			return theResult;
		}

		public static bool Perform(Controller theController)
		{
			GSFramework.ClientContext savedContext = theController.Context;
			Controller savedController = theController;
			DataSet savedDataset = theController.DataSet;

			Remote theReceiver = new Remote();
			bool theResult = theReceiver.RemotePerform(theController);
			if( theController.DataSet != null )
				savedDataset.Merge(theController.DataSet);
			// copy other data members from theController to savedController

			theController.Context = savedContext;
			return theResult;
		}

		public static bool Invoke(Controller theController , String theMethod)
		{
			GSFramework.ClientContext savedContext = theController.Context;
			Controller savedController = theController;
			DataSet savedDataset = theController.DataSet;

			Remote theReceiver = new Remote();
			bool theResult = theReceiver.RemoteInvoke(theController, theMethod);
			if( theController.DataSet != null )
				savedDataset.Merge(theController.DataSet);
			// copy other data members from theController to savedController

			theController.Context = savedContext;
			return theResult;
		}

		//TODO: CopyState needs to be tested and added to the Load, Perform and Invoke calls
		protected static void CopyState(Controller origController, Controller retController)
		{
			if (!(origController == retController))
			{
				DataSet saveDataSet = origController.DataSet;
				origController.DataSet.Merge(retController.DataSet);

				Type theType = origController.GetType();
				System.Reflection.FieldInfo[] theFields = theType.GetFields();
	            
				foreach( System.Reflection.FieldInfo theField in theFields)
				{
					switch(theField.Name)
					{
						case "myClientContext":
							break;
						default:
							theField.SetValue(origController, theField.GetValue(retController));
							break;
					}
				}
				origController.DataSet = saveDataSet;
			}
		}

		public  bool RemoteLoad(Controller theController)
		{
			GSFramework.ServerContext context = new GSFramework.ServerContext();
			theController.RequestContext = context;
			theController.InitializeServer();
			return (theController.LoadServer());
		}

		public bool RemotePerform(Controller theController)
		{
			GSFramework.ServerContext context = new GSFramework.ServerContext();
			theController.RequestContext = context;
			theController.InitializeServer();
			return (theController.PerformServer());
		}

		public bool RemoteInvoke(Controller theController, String theMethod)
		{
			Type theType = theController.GetType();
			System.Reflection.MethodInfo targetMethod = theType.GetMethod(theMethod);
			GSFramework.ServerContext context = new GSFramework.ServerContext();
			theController.RequestContext = context;
			theController.InitializeServer();
			targetMethod.Invoke(theController, null);
			return true;
		}

		public static bool Invoke(Controller theController, MethodInfo theMethodInfo , Object[] args)
		{
			Remote theReceiver = new Remote();
			bool theResult = theReceiver.RemoteInvoke(theController, theMethodInfo, args);
			return theResult;
		}

		public bool RemoteInvoke(Controller theController, MethodInfo theTargetMethod, Object[] args)
		{
			try
			{
				GSFramework.ServerContext context = new GSFramework.ServerContext();
				theController.RequestContext = context;
				theController.InitializeServer();
				theTargetMethod.Invoke(theController, args);
				return true;
			}
			catch(Exception ex)
			{
				//Always it will have target Invocation Exception, Look for more meaning full inner exception
				if (ex.InnerException != null)
					throw (ex.InnerException);
				else
					throw (ex);
			}
		}
	}
}
