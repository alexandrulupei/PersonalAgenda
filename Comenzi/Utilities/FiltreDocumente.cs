using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class FiltreDocumente
    {
        #region Class Fields
        private Guid mModulID = Guid.Empty;
        private Guid mInstitutieID = Guid.Empty;
        private Guid mDocumentID = Guid.Empty;
        private Guid mPartenerID = Guid.Empty;
        private Guid mTipDocumentID = Guid.Empty;
        private DateTime mDataDocument = DateTime.MinValue;
        private DateTime mDataDocumentMin = DateTime.MinValue;
        private DateTime mDataDocumentMax = DateTime.MaxValue;
        private DateTime mDataScadentaMin=DateTime.MinValue;
        private DateTime mDataScadentaMax=DateTime.MaxValue;
        private DateTime mDataDocMinWithDocProg = DateTime.MinValue;
        private string mCodArhiva=string.Empty;
        #endregion

        #region Properties
        public Guid PartenerID
        {
            set { this.mPartenerID = value; }
            get { return this.mPartenerID; }
        }
        public Guid InstitutieID
        {
            set { this.mInstitutieID = value; }
            get { return this.mInstitutieID; }
        }
        public Guid ModulID
        {
            set { this.mModulID = value;}
            get { return this.mModulID; }
        }
        public Guid DocumentID
        {
            set { this.mDocumentID = value; }
            get { return this.mDocumentID; }
        }
        public Guid TipDocumentID
        {
            set { this.mTipDocumentID = value; }
            get { return this.mTipDocumentID; }
        }
        public DateTime DataDocument
        {
            set { this.mDataDocument = value; }
            get { return this.mDataDocument; }
        }
        public DateTime DataDocumentMin
        {
            set { this.mDataDocumentMin = value; }
            get { return this.mDataDocumentMin; }
        }
        public DateTime DataDocumentMax
        {
            set { this.mDataDocumentMax = value; }
            get { return this.mDataDocumentMax; }
        }
        public DateTime DataScadentaMin
        {
            set { this.mDataScadentaMin = value; }
            get { return this.mDataScadentaMin; }
        }
        public DateTime DataScadentaMax
        {
            set { this.mDataScadentaMax = value; }
            get { return this.mDataScadentaMax; }
        }
        public DateTime DataDocumentMinWithDocProg
        {
            set { this.mDataDocMinWithDocProg = value; }
            get { return this.mDataDocMinWithDocProg; }
        }
        public String CodArhiva
        {
            set { this.mCodArhiva = value; }
            get { return this.mCodArhiva; }
        }
        #endregion
    }
}
