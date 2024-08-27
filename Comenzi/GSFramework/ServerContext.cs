using System;
using System.Collections;

namespace GSFramework
{
	/// <summary>
	/// Summary description for ServerContext.
	/// </summary>
	public class ServerContext
	{
		public ServerContext()
		{
			requestedComponents = new Hashtable();
		}
		protected Hashtable requestedComponents;


		protected DomainComponent CreateComponent(String ComponentName )
		{
			System.Reflection.Assembly theAssembly;
			DomainComponent newComponent;
			String[] names;
			String assmName;
			String objName;
			names = ComponentName.Split(',');
			assmName = names[1].Trim();
			objName = names[0].Trim();
			theAssembly = System.Reflection.Assembly.Load(assmName);
			newComponent = (DomainComponent)theAssembly.CreateInstance(objName);
			newComponent.RequestContext = this;
			newComponent.Initialize();
			return newComponent;
		}

		public DomainComponent GetComponent(String ComponentName )
		{
			DomainComponent comp;
			try
			{
				comp = (DomainComponent)requestedComponents[ComponentName];
			}
			catch
			{
				comp = null;
			}
			if (comp == null)
			{
				comp = CreateComponent(ComponentName);
				requestedComponents.Add(ComponentName, comp);
			}
			return comp;
		}
	}
}
