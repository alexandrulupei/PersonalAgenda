using System;
using System.Drawing;

namespace ComenziListe
{
    [Serializable]
    public class OptiuniFiltre
    {
        #region Class Fields
        private FontStyle mFontStyle;
        #endregion

        #region Properties
        public FontStyle FontStyle
        {
            set { this.mFontStyle = value; }
            get { return this.mFontStyle; }
        }
        #endregion
    }
}