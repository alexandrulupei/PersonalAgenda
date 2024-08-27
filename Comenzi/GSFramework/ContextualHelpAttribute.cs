using System;
using System.Collections.Generic;
using System.Text;

namespace GSFramework
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ContextualHelpAttribute : Attribute
    {
        #region Constructor
        public ContextualHelpAttribute(string helpPage, bool isEnabled)
        {
            mHelpPage = helpPage;
            mIsEnabled = isEnabled;
        }
        #endregion

        #region Fields
        private string mHelpPage;
        private bool mIsEnabled;
        #endregion

        #region Public Properties
        public string HelpPage
        {
            get { return mHelpPage; }
            set { mHelpPage = value; }
        }
        public bool IsEnabled
        {
            get { return mIsEnabled; }
            set { mIsEnabled = value; }
        }
        #endregion
    }
}
