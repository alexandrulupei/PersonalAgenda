using DataSet;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AgendaContacte
{
    public partial class Report : DevExpress.XtraReports.UI.XtraReport
    {
        private ListeazaDS listeazaDS;
        public Report(DataSet.ListeazaDS listeazaDS)
        {
            
            InitializeComponent();
            this.listeazaDS = listeazaDS;
        }

    }
}
