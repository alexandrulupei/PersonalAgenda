using System;
//using CrystalDecisions.Shared;
//using CrystalDecisions.ReportSource;
//using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Reflection;
using LookupTableManagement;
using System.Windows.Forms;
using System.Data;


namespace GSFramework
{
	/// <summary>
	/// Summary description for Controller.
	/// </summary>
	/// 
	[System.Serializable()]
	public class Controller
	{

		[System.NonSerialized()]
		protected GSFramework.ClientContext myClientContext;
		[System.NonSerialized()]
		protected GSFramework.ServerContext myServerContext;
		protected bool myAutoLoad;
		protected bool myLoaded;
		protected Exception myException;
		protected Int32 myResultCode;
		protected String myResultMessage;

		public Controller()
		{
		}

		public virtual void InitializeClient()
		{
			myAutoLoad = false;
			myLoaded = false;
			myResultCode = 0;
			myResultMessage = "Success";
		}

		public virtual void InitializeServer()
		{
		}

		public virtual DataSet DataSet
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
		public virtual DataSet LookupDataSet
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
		public virtual GSFramework.ClientContext Context
		{
			get
			{
				return myClientContext;
			}
			set
			{
				myClientContext = value;
			}
		}
		public virtual GSFramework.ServerContext RequestContext
		{
			get
			{
				return myServerContext;
			}
			set
			{
				myServerContext = value;
			}
		}

		public virtual bool AutoLoad
		{
			get
			{
				return myAutoLoad;
			}
			set
			{
				myAutoLoad = value;
			}
		}

		public virtual bool IsLoaded
		{
			get
			{
				return myLoaded;
			}
		}

		public Exception ServerException
		{
			get
			{
				return myException;
			}
		}
    
		public Int32 ResultCode
		{
			get
			{
				return myResultCode;
			}
		}

		public String ResultMessage
		{
			get
			{
				return myResultMessage;
			}
		}

		public virtual void Load()
		{
			this.myResultCode = 0;
			this.myResultMessage = "";
			this.myException = null;

			if (LoadClientBefore())
			{
				if (Remote.Load(this))
				{
					LoadClientAfter();
				}
			}
			myLoaded = true;
		}

		protected virtual bool LoadClientBefore()
		{
			return true;
		}

		public virtual bool LoadServer()
		{
			return true;
		}

		protected virtual bool LoadClientAfter()
		{
			return true;
		}

		public virtual void Perform()
		{
			this.myResultCode = 0;
			this.myResultMessage = "";
			this.myException = null;

			if (PerformClientBefore())
			{
				if (Remote.Perform(this))
				{
					PerformClientAfter();
				}
			}
		}

		protected virtual bool PerformClientBefore()
		{
			return true;
		}

		public virtual bool PerformServer()
		{
			return true;
		}

		protected virtual bool PerformClientAfter()
		{
			return true;
		}

		public void executeOnServer( params Object[] args)
		{
			StackFrame theStackFrame = new StackFrame(1);
			MethodBase theMethodBase = theStackFrame.GetMethod();
			ParameterInfo[] theClientMethodParams = theMethodBase.GetParameters();
			String theMethodName = theMethodBase.Name;
			String  theServerMethodName = theMethodBase.Name + "Server";
			MethodInfo theServerMethod = theMethodBase.DeclaringType.GetMethod(theServerMethodName);
			Remote.Invoke(this, theServerMethod, args);
		}

		/// <summary>
		/// Lookup and return the ID corresponding to a description.
		/// NOTE: This method should be called from server side code only
		/// (e.g. LoadServer, PerformServer or other server side method).
		/// </summary>
		/// <param name="tbx">[in] Lookup table name</param>
		/// <param name="desc">[in] Description</param>
		/// <returns>[out] ID of entry in lookup table</returns>
		public System.Guid LookupAbbrevDesc(String tbx, String abbrev, String desc)
		{
			LookupTableManager lookMgr;
			LookupTableManager.LookupTableResult res;
			lookMgr = LookupTableManager.GetLookupTableManager ();
			res = lookMgr.LookupAbbrevDesc(tbx, abbrev, desc);
			if (res.Abbreviation.Equals("Not Found"))
				throw new Exception("Cannot find " + desc + " in Table " + tbx + ", abbrev=" + abbrev);
			return res.Key;
		}

		/// <summary>
		/// Lookup and return the ID corresponding to a description.
		/// NOTE: This method should be called from server side code only
		/// (e.g. LoadServer, PerformServer or other server side method).
		/// </summary>
		/// <param name="tbx">[in] Lookup table name</param>
		/// <param name="desc">[in] Description</param>
		/// <returns>[out] ID of entry in lookup table</returns>
		public System.Guid LookupCode(String tbx , String desc )
		{
			LookupTableManager lookMgr;
			LookupTableManager.LookupTableResult res;
			lookMgr = LookupTableManager.GetLookupTableManager ();
			res = lookMgr.LookupCode(tbx, desc, true);
			if (res.Abbreviation.Equals("Not Found"))
				throw new Exception("Cannot find " + desc + " in Table " + tbx);
			return res.Key;
		}

		/// <summary>
		/// Lookup and return the description corresponding to a lookup entry ID.
		/// NOTE: This method should be called from server side code only
		/// (e.g. LoadServer, PerformServer or other server side method).
		/// </summary>
		/// <param name="tbx">[in] Lookup table name</param>
		/// <param name="ID">[in] ID of lookup entry</param>
		/// <returns>[out] Description</returns>
		public string LookupDesc(String tbx , Guid ID )
		{
			LookupTableManager lookMgr;
			LookupTableManager.LookupTableResult res;
			lookMgr = LookupTableManager.GetLookupTableManager ();
			res = lookMgr.LookupCode(tbx, ID);
			if (res.Abbreviation.Equals("Not Found"))
				throw new Exception("Cannot find " + ID.ToString() + " in Table " + tbx);
			return res.Description;
		}

		/// <summary>
		/// Lookup and return the abbreviation corresponding to a lookup entry ID.
		/// NOTE: This method should be called from server side code only
		/// (e.g. LoadServer, PerformServer or other server side method).
		/// </summary>
		/// <param name="tbx">[in] Lookup table name</param>
		/// <param name="ID">[in] ID of lookup entry</param>
		/// <returns>[out] Abbreviation</returns>
		public string LookupAbbr(String tbx , Guid ID )
		{
			LookupTableManager lookMgr;
			LookupTableManager.LookupTableResult res;
			lookMgr = LookupTableManager.GetLookupTableManager ();
			res = lookMgr.LookupCode(tbx, ID);
			if (res.Abbreviation.Equals("Not Found"))
				throw new Exception("Cannot find " + ID.ToString() + " in Table " + tbx);
			return res.Abbreviation;
		}

        //public bool SelectPrinter(ReportDocument rdPassed )
        //{
        //    bool bReturn = true;
        //    //we will put this in an endless loop so the user can retry
        //    while(true)
        //    {
        //        PrintDialog pdSelect = new PrintDialog();
        //        PrintDocument pdocSelect = new PrintDocument();
        //        pdSelect.Document = pdocSelect;

        //        if (pdSelect.ShowDialog() == DialogResult.OK)
        //        {
        //            PrinterSettings psSelect = pdSelect.PrinterSettings;
        //            String strPrinterName = psSelect.PrinterName;

        //            if (psSelect.IsValid == false)
        //            {
        //                if (MessageBox.Show("The printer you selected: " + strPrinterName + " is invalid.\n\nDo you want to select another printer?", "Invalid Printer", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
        //                {
        //                }
        //                else
        //                {
        //                    bReturn = false;
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                PrintOptions poSelect = rdPassed.PrintOptions;
        //                poSelect.PrinterName = strPrinterName;
        //                break;
        //            }
        //        }
        //        else
        //        {
        //            bReturn = false;
        //            break;
        //        }
        //    }
	        
        //    return bReturn;
        //}
	}
}
