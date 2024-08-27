using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.EnterpriseServices;

namespace GSFramework
{
	/// <summary>
	/// Summary description for DomainComponent.
	/// </summary>
	[Transaction(TransactionOption.Supported)]
	public class DomainComponent : System.ComponentModel.Component
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DomainComponent(System.ComponentModel.IContainer container)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public DomainComponent()
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		protected GSFramework.ServerContext context;

		public GSFramework.ServerContext RequestContext
		{
			get
			{
				return context;
			}
			set
			{
				context = value;
			}
		}

		// Called after construction by the ServerContext
		public virtual void Initialize()
		{
		}
	}
}
