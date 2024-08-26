using DataSet;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Data;

namespace AgendaContacte
{
    public partial class Report : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable filteredTable;

        public Report(DataTable listeazaDS, string nume, string prenume, string tara, string judet)
        {

            InitializeComponent();
            this.filteredTable = listeazaDS;

            this.DataSource = this.filteredTable;
            this.DataMember = "AgendaListare";

            this.NumeLabel.Text = $"Nume: '{nume}'";
            this.PrenumeLabel.Text = $"Prenume: '{prenume}'";
            this.TaraLabel.Text = $"Tara: '{tara}'";
            this.JudetLabel.Text = $"Judet: '{judet}'";
            //this.Randuri.Text = $"Numar Rezultate: {this.filteredTable.AgendaListare.Rows.Count}";

            this.Data.Text = $"Data: {DateTime.Now.ToString("dd/MM/yyyy")}";
            this.Ora.Text = $"Ora: {DateTime.Now.ToString("HH:mm:ss")}";

            this.ID_DP.DataBindings.Add("Text", this.filteredTable, "AgendaListare.ID_DP");
            this.Nume.DataBindings.Add("Text", this.filteredTable, "AgendaListare.Nume");
            this.Prenume.DataBindings.Add("Text", this.filteredTable, "AgendaListare.Prenume");
            this.CNP.DataBindings.Add("Text", this.filteredTable, "AgendaListare.CNP");
            this.Tara.DataBindings.Add("Text", this.filteredTable, "AgendaListare.Tara");
            this.Judet.DataBindings.Add("Text", this.filteredTable, "AgendaListare.Judet");


            DataTable agendaTable = listeazaDS;
            if (agendaTable != null)
            {
                this.Randuri.Text = $"Număr Rezultate: {agendaTable.Rows.Count}";
            }
            else
            {
                this.Randuri.Text = "AgendaListare nu este disponibilă.";
            }
            SetBorders();
        }

        private void SetBorders()
        {
            this.ID_DP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.ID_DP.BorderWidth = 1f;
            this.ID_DP.BorderColor = System.Drawing.Color.Black;

            this.Nume.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.Nume.BorderWidth = 1f;
            this.Nume.BorderColor = System.Drawing.Color.Black;

            this.Prenume.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.Prenume.BorderWidth = 1f;
            this.Prenume.BorderColor = System.Drawing.Color.Black;

            this.CNP.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.CNP.BorderWidth = 1f;
            this.CNP.BorderColor = System.Drawing.Color.Black;

            this.Tara.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.Tara.BorderWidth = 1f;
            this.Tara.BorderColor = System.Drawing.Color.Black;

            this.Judet.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.Judet.BorderWidth = 1f;
            this.Judet.BorderColor = System.Drawing.Color.Black;

            this.Id.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.Id.BorderWidth = 1f;
            this.Id.BorderColor = System.Drawing.Color.Black;

            this.NumeColoana.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.NumeColoana.BorderWidth = 1f;
            this.NumeColoana.BorderColor = System.Drawing.Color.Black;

            this.PrenumeColoana.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.PrenumeColoana.BorderWidth = 1f;
            this.PrenumeColoana.BorderColor = System.Drawing.Color.Black;

            this.CNPColoana.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.CNPColoana.BorderWidth = 1f;
            this.CNPColoana.BorderColor = System.Drawing.Color.Black;

            this.TaraColoana.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.TaraColoana.BorderWidth = 1f;
            this.TaraColoana.BorderColor = System.Drawing.Color.Black;

            this.JudetColoana.Borders = DevExpress.XtraPrinting.BorderSide.All;
            this.JudetColoana.BorderWidth = 1f;
            this.JudetColoana.BorderColor = System.Drawing.Color.Black;
        }
    }

    /*            this.NumeLabel.Text = $"Nume: {nume}";

                this.ID_DP.DataBindings.Add("Text", null, "ID_DP"); 
                this.Nume.DataBindings.Add("Text", null, "Nume");
                this.Prenume.DataBindings.Add("Text", null, "Prenume");
                this.Prenume.DataBindings.Add("Text", null, "CNP");
                this.Prenume.DataBindings.Add("Text", null, "Tara");
                this.Prenume.DataBindings.Add("Text", null, "Judet");

                this.headerRowAgendaContacte.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] { this.ID_DP, this.Nume, this.Prenume, this.CNP, this.Tara, this.Judet });
    */
}
