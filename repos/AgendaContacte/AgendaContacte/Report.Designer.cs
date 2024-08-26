
namespace AgendaContacte
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.AgendaContacte = new DevExpress.XtraReports.UI.XRTable();
            this.headerRowAgendaContacte = new DevExpress.XtraReports.UI.XRTableRow();
            this.ID_DP = new DevExpress.XtraReports.UI.XRTableCell();
            this.Nume = new DevExpress.XtraReports.UI.XRTableCell();
            this.Prenume = new DevExpress.XtraReports.UI.XRTableCell();
            this.CNP = new DevExpress.XtraReports.UI.XRTableCell();
            this.Tara = new DevExpress.XtraReports.UI.XRTableCell();
            this.Judet = new DevExpress.XtraReports.UI.XRTableCell();
            this.Data = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.Id = new DevExpress.XtraReports.UI.XRTableCell();
            this.NumeColoana = new DevExpress.XtraReports.UI.XRTableCell();
            this.PrenumeColoana = new DevExpress.XtraReports.UI.XRTableCell();
            this.CNPColoana = new DevExpress.XtraReports.UI.XRTableCell();
            this.TaraColoana = new DevExpress.XtraReports.UI.XRTableCell();
            this.JudetColoana = new DevExpress.XtraReports.UI.XRTableCell();
            this.Randuri = new DevExpress.XtraReports.UI.XRLabel();
            this.Filtru = new DevExpress.XtraReports.UI.XRLabel();
            this.PrenumeLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.TaraLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.JudetLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.NumeLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.Ora = new DevExpress.XtraReports.UI.XRLabel();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.xpPageSelector1 = new DevExpress.Xpo.XPPageSelector(this.components);
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.AgendaContacte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 34F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 45F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.AgendaContacte});
            this.Detail.HeightF = 32.70832F;
            this.Detail.Name = "Detail";
            // 
            // AgendaContacte
            // 
            this.AgendaContacte.KeepTogether = true;
            this.AgendaContacte.LocationFloat = new DevExpress.Utils.PointFloat(34.375F, 0F);
            this.AgendaContacte.Name = "AgendaContacte";
            this.AgendaContacte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.AgendaContacte.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.headerRowAgendaContacte});
            this.AgendaContacte.SizeF = new System.Drawing.SizeF(582.2917F, 32.70832F);
            // 
            // headerRowAgendaContacte
            // 
            this.headerRowAgendaContacte.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.ID_DP,
            this.Nume,
            this.Prenume,
            this.CNP,
            this.Tara,
            this.Judet});
            this.headerRowAgendaContacte.Name = "headerRowAgendaContacte";
            this.headerRowAgendaContacte.Weight = 1D;
            // 
            // ID_DP
            // 
            this.ID_DP.Multiline = true;
            this.ID_DP.Name = "ID_DP";
            this.ID_DP.Text = "ID_DP";
            this.ID_DP.TextFormatString = "{0}";
            this.ID_DP.Weight = 0.54145811410728462D;
            // 
            // Nume
            // 
            this.Nume.Multiline = true;
            this.Nume.Name = "Nume";
            this.Nume.Text = "Nume";
            this.Nume.Weight = 1.079293533783882D;
            // 
            // Prenume
            // 
            this.Prenume.Multiline = true;
            this.Prenume.Name = "Prenume";
            this.Prenume.Text = "Prenume";
            this.Prenume.Weight = 1.0898347289191841D;
            // 
            // CNP
            // 
            this.CNP.Multiline = true;
            this.CNP.Name = "CNP";
            this.CNP.Text = "CNP";
            this.CNP.Weight = 1.3900582784053566D;
            // 
            // Tara
            // 
            this.Tara.Multiline = true;
            this.Tara.Name = "Tara";
            this.Tara.Text = "Tara";
            this.Tara.Weight = 0.8993553447842928D;
            // 
            // Judet
            // 
            this.Judet.Multiline = true;
            this.Judet.Name = "Judet";
            this.Judet.Text = "Judet";
            this.Judet.Weight = 1D;
            // 
            // Data
            // 
            this.Data.LocationFloat = new DevExpress.Utils.PointFloat(34.375F, 10.00001F);
            this.Data.Multiline = true;
            this.Data.Name = "Data";
            this.Data.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Data.SizeF = new System.Drawing.SizeF(157.2917F, 23F);
            this.Data.Text = "Data";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.Randuri,
            this.Filtru,
            this.PrenumeLabel,
            this.TaraLabel,
            this.JudetLabel,
            this.NumeLabel,
            this.Ora,
            this.Data});
            this.ReportHeader.HeightF = 227.2916F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(34.375F, 202.2916F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(582.2917F, 25F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.Id,
            this.NumeColoana,
            this.PrenumeColoana,
            this.CNPColoana,
            this.TaraColoana,
            this.JudetColoana});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // Id
            // 
            this.Id.Multiline = true;
            this.Id.Name = "Id";
            this.Id.Text = "Id";
            this.Id.Weight = 0.54145827365208965D;
            // 
            // NumeColoana
            // 
            this.NumeColoana.Multiline = true;
            this.NumeColoana.Name = "NumeColoana";
            this.NumeColoana.Text = "Nume";
            this.NumeColoana.Weight = 1.0792936927236942D;
            // 
            // PrenumeColoana
            // 
            this.PrenumeColoana.Multiline = true;
            this.PrenumeColoana.Name = "PrenumeColoana";
            this.PrenumeColoana.Text = "Prenume";
            this.PrenumeColoana.Weight = 1.089834435451335D;
            // 
            // CNPColoana
            // 
            this.CNPColoana.Multiline = true;
            this.CNPColoana.Name = "CNPColoana";
            this.CNPColoana.Text = "CNP";
            this.CNPColoana.Weight = 1.3900582656648917D;
            // 
            // TaraColoana
            // 
            this.TaraColoana.Multiline = true;
            this.TaraColoana.Name = "TaraColoana";
            this.TaraColoana.Text = "Tara";
            this.TaraColoana.Weight = 0.8993553325079896D;
            // 
            // JudetColoana
            // 
            this.JudetColoana.Multiline = true;
            this.JudetColoana.Name = "JudetColoana";
            this.JudetColoana.Text = "Judet";
            this.JudetColoana.Weight = 1D;
            // 
            // Randuri
            // 
            this.Randuri.LocationFloat = new DevExpress.Utils.PointFloat(34.375F, 179.2916F);
            this.Randuri.Multiline = true;
            this.Randuri.Name = "Randuri";
            this.Randuri.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Randuri.SizeF = new System.Drawing.SizeF(180.7368F, 23F);
            this.Randuri.Text = "Randuri gasite:";
            // 
            // Filtru
            // 
            this.Filtru.LocationFloat = new DevExpress.Utils.PointFloat(34.375F, 58.00001F);
            this.Filtru.Multiline = true;
            this.Filtru.Name = "Filtru";
            this.Filtru.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Filtru.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.Filtru.Text = "Filtre utilizate:";
            // 
            // PrenumeLabel
            // 
            this.PrenumeLabel.LocationFloat = new DevExpress.Utils.PointFloat(404.1667F, 58.00001F);
            this.PrenumeLabel.Multiline = true;
            this.PrenumeLabel.Name = "PrenumeLabel";
            this.PrenumeLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PrenumeLabel.SizeF = new System.Drawing.SizeF(212.5F, 23F);
            this.PrenumeLabel.Text = "Prenume";
            // 
            // TaraLabel
            // 
            this.TaraLabel.LocationFloat = new DevExpress.Utils.PointFloat(162.5F, 100.4584F);
            this.TaraLabel.Multiline = true;
            this.TaraLabel.Name = "TaraLabel";
            this.TaraLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TaraLabel.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.TaraLabel.Text = "Tara";
            // 
            // JudetLabel
            // 
            this.JudetLabel.LocationFloat = new DevExpress.Utils.PointFloat(404.1667F, 100.4584F);
            this.JudetLabel.Multiline = true;
            this.JudetLabel.Name = "JudetLabel";
            this.JudetLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.JudetLabel.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.JudetLabel.Text = "Judet";
            // 
            // NumeLabel
            // 
            this.NumeLabel.LocationFloat = new DevExpress.Utils.PointFloat(162.5F, 58.00001F);
            this.NumeLabel.Multiline = true;
            this.NumeLabel.Name = "NumeLabel";
            this.NumeLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NumeLabel.SizeF = new System.Drawing.SizeF(188.5417F, 23F);
            this.NumeLabel.Text = "Nume";
            // 
            // Ora
            // 
            this.Ora.LocationFloat = new DevExpress.Utils.PointFloat(215.1118F, 10.00001F);
            this.Ora.Multiline = true;
            this.Ora.Name = "Ora";
            this.Ora.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Ora.SizeF = new System.Drawing.SizeF(146.875F, 23F);
            this.Ora.Text = "Ora";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "HomeAgenda";
            this.objectDataSource1.DataSource = typeof(DataSet.HomeAgendaDS);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // PageFooter
            // 
            this.PageFooter.HeightF = 69.625F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1,
            this.xpPageSelector1});
            this.DataSource = this.objectDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(100, 101, 34, 45);
            this.Version = "21.2";
            ((System.ComponentModel.ISupportInitialize)(this.AgendaContacte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable AgendaContacte;
        private DevExpress.XtraReports.UI.XRTableRow headerRowAgendaContacte;
        private DevExpress.XtraReports.UI.XRTableCell ID_DP;
        private DevExpress.XtraReports.UI.XRTableCell Nume;
        private DevExpress.XtraReports.UI.XRTableCell Prenume;
        private DevExpress.XtraReports.UI.XRLabel Data;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRTableCell CNP;
        private DevExpress.XtraReports.UI.XRTableCell Tara;
        private DevExpress.XtraReports.UI.XRTableCell Judet;
        private DevExpress.XtraReports.UI.XRLabel Ora;
        private DevExpress.Xpo.XPPageSelector xpPageSelector1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel Filtru;
        private DevExpress.XtraReports.UI.XRLabel PrenumeLabel;
        private DevExpress.XtraReports.UI.XRLabel TaraLabel;
        private DevExpress.XtraReports.UI.XRLabel JudetLabel;
        private DevExpress.XtraReports.UI.XRLabel NumeLabel;
        private DevExpress.XtraReports.UI.XRLabel Randuri;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell Id;
        private DevExpress.XtraReports.UI.XRTableCell NumeColoana;
        private DevExpress.XtraReports.UI.XRTableCell PrenumeColoana;
        private DevExpress.XtraReports.UI.XRTableCell CNPColoana;
        private DevExpress.XtraReports.UI.XRTableCell TaraColoana;
        private DevExpress.XtraReports.UI.XRTableCell JudetColoana;
    }
}
