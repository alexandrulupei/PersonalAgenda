using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ComenziListe
{
    public partial class NIRReport : DevExpress.XtraReports.UI.XtraReport
    {
        public NIRReport()
        {
            InitializeComponent();
        }

        #region Class Fields
        private int mNrZecimaleCantitati = 0;
        private int mNrZecimaleSume = 0;

        #endregion

        #region Public Properties
        public int NrZecimaleCantitati
        {
            set { mNrZecimaleCantitati = value; }
        }
        public int NrZecimaleSume
        {
            set { mNrZecimaleSume = value; }
        }
       
        #endregion

        private void NIRReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string formatstringCantitate = "{0:f" + mNrZecimaleCantitati.ToString() + "}";
            string formatStringSuma = "{0:f" + mNrZecimaleSume.ToString() + "}"; ;

            //formatarea campurilor cu cantitati
            XRBinding binding = this.xrTableCell49.DataBindings["Text"];
            binding.FormatString = formatstringCantitate;

            binding = xrTableCell48.DataBindings["Text"];
            binding.FormatString = formatstringCantitate;

            //formatarea campurilor cu sume
            binding = xrTableCell50.DataBindings["Text"];
            binding.FormatString = formatStringSuma;
            binding = xrTableCell51.DataBindings["Text"];
            binding.FormatString = formatStringSuma;
            binding = xrTableCell53.DataBindings["Text"];
            binding.FormatString = formatStringSuma;
            binding = xrTableCell54.DataBindings["Text"];
            binding.FormatString = formatStringSuma;
            binding = xrTableCell55.DataBindings["Text"];
            binding.FormatString = formatStringSuma;
            binding = xrTableCell78.DataBindings["Text"];
            binding.FormatString = formatStringSuma;
            binding = xrTableCell79.DataBindings["Text"];
            binding.FormatString = formatStringSuma;
            //Summary
            xrTableCell65.Summary.FormatString = formatStringSuma;
            xrTableCell81.Summary.FormatString = formatStringSuma;
            xrTableCell68.Summary.FormatString = formatStringSuma;
            //labels
            xrLabel23.Summary.FormatString = formatStringSuma;
            xrLabel24.Summary.FormatString = formatStringSuma;
            xrLabel25.Summary.FormatString = formatStringSuma;
            xrLabel39.Summary.FormatString = formatStringSuma;
            xrLabel40.Summary.FormatString = formatStringSuma;
            xrLabel42.Summary.FormatString = formatStringSuma;
        }

    }
}
