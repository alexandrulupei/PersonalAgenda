using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GSFramework
{
    /// <summary>
    /// Summary description for Window.
    /// </summary>
    public class Window : System.Windows.Forms.Form
    {
        #region Form Designer Variables
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region Constructor and Dispose
        public Window()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            mParameterList = new System.Collections.ArrayList();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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
            IsDisposing = disposing;
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.SuspendLayout();
            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Window_HelpRequested);
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Window_KeyDown);
            this.ResumeLayout(false);

        }
        #endregion

        #region Private and Protected Variables
        protected bool mySaveData;
        protected GSFramework.ClientContext myClientContext;
        protected String myParameters;
        protected bool mDisplayByDefault;
        protected SortedList myParameterCollection;
        protected bool myLoading;
        protected bool myDisposing;
        protected Guid myWindowResidentID = Guid.Empty;
        protected object mWindowParamsObject;
        protected static System.Drawing.Color mHeaderPanelBackColor = System.Drawing.Color.Empty;
        protected static System.Drawing.Color mHeaderTextForeColor = System.Drawing.Color.Empty;
        protected static System.Drawing.Font mHeaderTextFont = null;
        private System.Collections.IList mParameterList;
        #endregion

        #region Public Properties
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

        public String Parameters
        {
            get
            {
                return myParameters;
            }
            set
            {
                myParameters = value;
                ParseParameters();
            }
        }

        public bool DisplayByDefault
        {
            get
            {
                return mDisplayByDefault;
            }
            set
            {
                mDisplayByDefault = value;
            }
        }

        public bool IsLoading
        {
            get
            {
                return myLoading;
            }
            set
            {
                myLoading = value;
            }
        }

        public bool IsDisposing
        {
            get
            {
                return myDisposing;
            }
            set
            {
                myDisposing = value;
            }
        }

        public Guid WindowResidentID
        {
            get { return myWindowResidentID; }
            set { myWindowResidentID = value; }
        }
        public static System.Drawing.Color HeaderPanelBackColor
        {
            get
            {
                if (mHeaderPanelBackColor == System.Drawing.Color.Empty)
                    mHeaderPanelBackColor = System.Drawing.Color.FromArgb(168, 200, 244);
                return mHeaderPanelBackColor;
            }
        }
        public static System.Drawing.Color HeaderTextForeColor
        {
            get
            {
                if (mHeaderTextForeColor == System.Drawing.Color.Empty)
                    mHeaderTextForeColor = System.Drawing.Color.Black;
                return mHeaderTextForeColor;
            }
        }
        public static System.Drawing.Font HeaderTextFont
        {
            get
            {
                if (mHeaderTextFont == null)
                    mHeaderTextFont = new System.Drawing.Font("Trebuchet MS", 20.25F, (System.Drawing.FontStyle.Bold /* | System.Drawing.FontStyle.Italic */), System.Drawing.GraphicsUnit.Point, (byte)0);
                return mHeaderTextFont;
            }
        }
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

        #region Private Event Handlers
        private void Window_Closing(Object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Context.HomeDesktop == this)
            {
                Context.HomeDesktop = null;
            }
        }
        #endregion

        #region Public Methods
        public virtual void Bind()
        {
        }

        public virtual void Reload()
        {
        }

        public virtual void Redisplay()
        {
        }

        public virtual void Unbind()
        {
        }

        public virtual void AddNote(String strDescription, Int32 intType)
        {
        }

        public virtual void AddNote(String strDescription, Int32 intType, String strUser)
        {
        }

        public virtual void Initialize()
        {
            mDisplayByDefault = true;
            this.mySaveData = false;
            if (HasChildren)
            {
                for (int ix = 0; ix < Controls.Count; ix++)
                {
                    if (Controls[ix].Name == "HeaderBar")
                    {
                        Control headerPanel = Controls[ix];
                        headerPanel.BackColor = HeaderPanelBackColor;
                        if (headerPanel.HasChildren)
                        {
                            for (int iy = 0; iy < headerPanel.Controls.Count; iy++)
                            {
                                if (headerPanel.Controls[iy].Name == "HeaderText")
                                {
                                    Control headerText = headerPanel.Controls[iy];
                                    headerText.ForeColor = HeaderTextForeColor;
                                    headerText.Font = HeaderTextFont;
                                    //TODO - the following statement expects headertext is set
                                    // before base Initialize method is invoked. A general sample code
                                    // review suggests that headertext is set in InitializeComponent method, there
                                    // might be a few cases where the above pattern falls through cracks.
                                    // These cases need to be isolated and fixed to follow the pattern.
                                    string header = this.GetParameter("Title");
                                    if (header != null)
                                    {
                                        headerText.Text = header;
                                    }
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        public virtual void Initialize(object WindowParamsObject)
        {
            mDisplayByDefault = true;
            this.mySaveData = false;
            this.mWindowParamsObject = WindowParamsObject;
        }

        public String GetParameter(String Name)
        {
            if (myParameterCollection == null)
                return null;
            else
            {
                try
                {
                    String val = (String)myParameterCollection[Name];
                    return val;
                }
                catch
                {
                    return null;
                }
            }
        }

        public virtual DialogResult TaskCompleteOK()
        {
            return MessageBox.Show(this, "Click Yes to save data, No to discard changes, or Cancel to go back",
                "Save, Don't Save, Cancel", MessageBoxButtons.YesNoCancel);
        }

        public virtual bool VerifyChildPanels()
        {
            //Insert code here to execute the VerifyData method on all child panels.
            //Return false if any fail.
            return true;
        }

        public virtual void CloseHomeDesktop()
        {
            Context.MDIParent.CloseHomeDesktop();
        }

        public virtual void OpenHomeDesktop()
        {
            Context.MDIParent.OpenHomeDesktop();
        }

        public object GetParameterValue(string pKey)
        {
            System.Collections.IEnumerator traverse = ParameterList.GetEnumerator();

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
                System.Collections.IEnumerator traverse = ParameterList.GetEnumerator();

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
            System.Collections.IEnumerator traverse = ParameterList.GetEnumerator();

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

        #region Private and Protected Methods
        protected virtual void InitController()
        {
        }
        private void ParseParameters()
        {
            if (myParameters == "")
            {
                myParameterCollection = null;
                return;
            }
            myParameterCollection = new SortedList();
            String[] parmPairs = myParameters.Split('&');

            String[] nvPair;
            foreach (String parmPair in parmPairs)
            {
                if (parmPair != "")
                {
                    nvPair = parmPair.Split('=');
                    if (nvPair.Length == 2)
                    {
                        if (nvPair[0] != "")
                        {
                            if (nvPair[1] != "")
                            {
                                // if the parameter is either the veteranid or the residentid then we want to save them
                                if ((nvPair[0] == "VeteranID") || (nvPair[0] == "ResidentID"))
                                {
                                    try
                                    {
                                        myWindowResidentID = new Guid(nvPair[1]);
                                    }
                                    catch
                                    {
                                        myWindowResidentID = Guid.Empty;
                                    }
                                }
                                myParameterCollection.Add(nvPair[0], nvPair[1]);
                            }
                        }
                    }
                }
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            UtilityClass uc = new UtilityClass();
            string pVal = uc.GetValueNameFromConfig("UseKeyPreview");
            if (pVal != null && pVal == "1")
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
        }
        private void Window_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

            UtilityClass uc = new UtilityClass();
            object[] attributes = this.GetType().GetCustomAttributes(typeof(ContextualHelpAttribute), true);
            if (attributes.Length == 1)
            {
                ContextualHelpAttribute helpAttribute = attributes[0] as ContextualHelpAttribute;
                if (helpAttribute.IsEnabled)
                {
                    uc.OpenHelpFile(this, helpAttribute.HelpPage);
                }
            }
            else
            {
                uc.OpenHelpFile(this, "index.htm");
            }
        }
        protected bool CheckLogin()
        {
            if (!(Context.UserIsLoggedIn()))
            {
                System.Windows.Forms.MessageBox.Show("Please Login", "ICS ",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        protected virtual void LoadPage(String project, String name)
        {
            LoadPage(project, name, null);
        }

        protected virtual void LoadPage(String project, String name, String strParameters)
        {
            if (CheckLogin())
            {
                InitController();
                ShowPage(project, name, strParameters);
            }
        }

        protected void ShowPage(String project, String name)
        {
            ShowPage(project, name, null);
        }

        protected void ShowPage(String project, String name, String strParameters)
        {
            String win;
            win = project + "." + name + ", " + project;
            Context.CreateWindow(win, strParameters);
        }

        protected SortedList ParseParameters(string parameter)
        {
            try
            {
                SortedList parameters;
                if (parameter == "")
                {
                    parameters = null;
                    return (parameters);
                }
                parameters = new SortedList();
                string[] parmPairs = parameter.Split('&');

                string[] nvPair;
                foreach (String parmPair in parmPairs)
                {
                    if (parmPair != "")
                    {
                        nvPair = parmPair.Split('=');
                        if (nvPair.Length == 2)
                        {
                            if (nvPair[0] != "")
                            {
                                if (nvPair[1] != "")
                                {
                                    parameters.Add(nvPair[0], nvPair[1]);
                                }
                            }
                        }
                    }
                }
                return (parameters);
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
