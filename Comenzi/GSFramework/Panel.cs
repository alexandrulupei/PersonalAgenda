using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
//using CrystalDecisions.Shared;
//using CrystalDecisions.ReportSource;
//using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;

namespace GSFramework
{
    /// <summary>
    /// Summary description for Panel.
    /// </summary>
    public class Panel : System.Windows.Forms.UserControl
    {
        #region Designer Variables
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region Constructor & Dispose
        public Panel()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitForm call

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

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

        #region Private Member Variables
        private System.Collections.IList mParameterList;
        #endregion

        #region Public Properties
        public System.Collections.IList ParameterList
        {
            get
            {
                return (mParameterList);
            }
            set
            {
                mParameterList = value;
            }
        }
        #endregion

        #region Public Methods
        public virtual void Initialize()
        {
        }

        public virtual void Bind()
        {
        }

        public virtual void Unbind()
        {
        }

        public virtual GSFramework.Controller DisplayController
        {
            get
            {
                //override this to return the correct DisplayController for the subclassed panel.
                return null;
            }
            set
            {
                // override this to set the correct DisplayController for the subclassed panel.
            }
        }

        public virtual GSFramework.Window ParentWindow
        {
            get
            {
                GSFramework.Window theWindow = (GSFramework.Window)this.ParentForm;
                return theWindow;
            }
        }

        public virtual void Reload()
        {
        }

        public virtual void Redisplay()
        {
        }

        public virtual bool VerifyData()
        {
            //Place code here to validate user control data.
            //Returns false if data is invalid.
            return true;
        }

        public virtual GSFramework.ClientContext Context
        {
            get
            {
                if (this.ParentWindow != null)
                {
                    return this.ParentWindow.Context;
                }
                else
                    return null;
            }
        }

        //public bool SelectPrinter(ReportDocument rdPassed)
        //{
        //    bool bReturn = true;
        //    //we will put this in an endless loop so the user can retry
        //    while (true)
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

        public void HandleException(Control pnlParent, string strModuleName, System.Exception excep)
        {
            UtilityClass utility = new UtilityClass();
            if (utility.DisplayException(pnlParent, strModuleName, excep))
                throw excep;
        }
        public object GetParameterValue(string pKey)
        {
            System.Collections.IEnumerator traverse = mParameterList.GetEnumerator();

            while (traverse.MoveNext())
            {
                UserHashEntry userHashEntry = (UserHashEntry)traverse.Current;

                if (pKey.CompareTo(userHashEntry.Key.ToString()) == 0)
                {
                    return (userHashEntry.Value);
                }
            }
            return (string.Empty);
        }
        public void SetParameterValue(string pKey, object pValue)
        {
            try
            {
                System.Collections.IEnumerator traverse = mParameterList.GetEnumerator();

                while (traverse.MoveNext())
                {
                    UserHashEntry userHashEntry = (UserHashEntry)traverse.Current;

                    if (pKey.CompareTo(userHashEntry.Key.ToString()) == 0)
                    {
                        userHashEntry.Value = pValue;
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public object GetParameterHashEntry(string pKey)
        {
            System.Collections.IEnumerator traverse = mParameterList.GetEnumerator();

            while (traverse.MoveNext())
            {
                UserHashEntry userHashEntry = (UserHashEntry)traverse.Current;

                if (pKey.CompareTo(userHashEntry.Key.ToString()) == 0)
                {
                    return (userHashEntry);
                }
            }
            return (string.Empty);
        }
        #endregion
    }
}
