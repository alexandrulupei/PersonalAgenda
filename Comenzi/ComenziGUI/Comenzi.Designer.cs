namespace ComenziGUI
{
    partial class Comenzi
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControlComenzi = new DevExpress.XtraGrid.GridControl();
            this.tblHomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewComenzi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEditData = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colDenumire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodProdus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDenumireProdus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateDistribuita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCantitateComandata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateDisponibilaLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateReceptionata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateDispComanda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareCuTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel2)).BeginInit();
            this.splitContainerControlBaseWindow.Panel2.SuspendLayout();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlComenzi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewComenzi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            // 
            // splitContainerControlBaseWindow.Panel2
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlComenzi);
            // 
            // progressBarControlBaseWindow
            // 
            this.progressBarControlBaseWindow.Visible = false;
            // 
            // labelBaseWindowHeader
            // 
            this.labelBaseWindowHeader.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBaseWindowHeader.Appearance.Options.UseFont = true;
            this.labelBaseWindowHeader.Appearance.Options.UseTextOptions = true;
            this.labelBaseWindowHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelBaseWindowHeader.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelBaseWindowHeader.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            // 
            // gridControlComenzi
            // 
            this.gridControlComenzi.DataSource = this.tblHomeBindingSource;
            this.gridControlComenzi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlComenzi.Location = new System.Drawing.Point(0, 0);
            this.gridControlComenzi.MainView = this.gridViewComenzi;
            this.gridControlComenzi.Name = "gridControlComenzi";
            this.gridControlComenzi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma,
            this.repositoryItemDateEditData});
            this.gridControlComenzi.Size = new System.Drawing.Size(738, 456);
            this.gridControlComenzi.TabIndex = 1;
            this.gridControlComenzi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewComenzi});
            // 
            // tblHomeBindingSource
            // 
            this.tblHomeBindingSource.DataMember = "tblHome";
            this.tblHomeBindingSource.DataSource = typeof(CommonDataSets.GUI.ComenziDataSet);
            // 
            // gridViewComenzi
            // 
            this.gridViewComenzi.ColumnPanelRowHeight = 45;
            this.gridViewComenzi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colLotID,
            this.colData,
            this.colDenumire,
            this.colCodProdus,
            this.colDenumireProdus,
            this.colCantitateDistribuita,
            this.colCantitateComandata,
            this.colCantitateDisponibilaLot,
            this.colCantitateReceptionata,
            this.colCantitateDispComanda,
            this.colPret,
            this.colValoare,
            this.colValoareTVA,
            this.colValoareCuTVA});
            this.gridViewComenzi.GridControl = this.gridControlComenzi;
            this.gridViewComenzi.GroupCount = 1;
            this.gridViewComenzi.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CantitateComandata", this.colCantitateComandata, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CantitateDispComanda", this.colCantitateDispComanda, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CantitateReceptionata", this.colCantitateReceptionata, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Valoare", this.colValoare, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareCuTVA", this.colValoareCuTVA, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareTVA", this.colValoareTVA, "")});
            this.gridViewComenzi.Name = "gridViewComenzi";
            this.gridViewComenzi.OptionsBehavior.Editable = false;
            this.gridViewComenzi.OptionsBehavior.ReadOnly = true;
            this.gridViewComenzi.OptionsView.ShowAutoFilterRow = true;
            this.gridViewComenzi.OptionsView.ShowFooter = true;
            this.gridViewComenzi.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDenumire, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colData, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colLotID
            // 
            this.colLotID.FieldName = "LotID";
            this.colLotID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colLotID.Name = "colLotID";
            this.colLotID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colData
            // 
            this.colData.AppearanceHeader.Options.UseTextOptions = true;
            this.colData.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colData.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colData.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colData.Caption = "Data Comanda";
            this.colData.ColumnEdit = this.repositoryItemDateEditData;
            this.colData.FieldName = "Data";
            this.colData.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colData.Name = "colData";
            this.colData.Visible = true;
            this.colData.VisibleIndex = 0;
            this.colData.Width = 60;
            // 
            // repositoryItemDateEditData
            // 
            this.repositoryItemDateEditData.AutoHeight = false;
            this.repositoryItemDateEditData.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEditData.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemDateEditData.Name = "repositoryItemDateEditData";
            // 
            // colDenumire
            // 
            this.colDenumire.AppearanceHeader.Options.UseTextOptions = true;
            this.colDenumire.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDenumire.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDenumire.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDenumire.Caption = "Lot";
            this.colDenumire.FieldName = "Denumire";
            this.colDenumire.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDenumire.Name = "colDenumire";
            this.colDenumire.Visible = true;
            this.colDenumire.VisibleIndex = 1;
            // 
            // colCodProdus
            // 
            this.colCodProdus.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodProdus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodProdus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCodProdus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodProdus.Caption = "Cod Produs";
            this.colCodProdus.FieldName = "CodProdus";
            this.colCodProdus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCodProdus.Name = "colCodProdus";
            this.colCodProdus.Visible = true;
            this.colCodProdus.VisibleIndex = 1;
            this.colCodProdus.Width = 60;
            // 
            // colDenumireProdus
            // 
            this.colDenumireProdus.AppearanceHeader.Options.UseTextOptions = true;
            this.colDenumireProdus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDenumireProdus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDenumireProdus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDenumireProdus.Caption = "Denumire Produs";
            this.colDenumireProdus.FieldName = "DenumireProdus";
            this.colDenumireProdus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDenumireProdus.Name = "colDenumireProdus";
            this.colDenumireProdus.Visible = true;
            this.colDenumireProdus.VisibleIndex = 2;
            this.colDenumireProdus.Width = 60;
            // 
            // colCantitateDistribuita
            // 
            this.colCantitateDistribuita.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDistribuita.Caption = "Cantitate distribuita";
            this.colCantitateDistribuita.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateDistribuita.FieldName = "CantitateDistribuita";
            this.colCantitateDistribuita.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateDistribuita.Name = "colCantitateDistribuita";
            this.colCantitateDistribuita.OptionsColumn.ReadOnly = true;
            this.colCantitateDistribuita.Visible = true;
            this.colCantitateDistribuita.VisibleIndex = 3;
            this.colCantitateDistribuita.Width = 60;
            // 
            // repositoryItemTextEditSuma
            // 
            this.repositoryItemTextEditSuma.AutoHeight = false;
            this.repositoryItemTextEditSuma.Name = "repositoryItemTextEditSuma";
            // 
            // colCantitateComandata
            // 
            this.colCantitateComandata.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateComandata.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateComandata.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateComandata.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateComandata.Caption = "Cantitate comandata";
            this.colCantitateComandata.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateComandata.FieldName = "CantitateComandata";
            this.colCantitateComandata.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateComandata.Name = "colCantitateComandata";
            this.colCantitateComandata.OptionsColumn.ReadOnly = true;
            this.colCantitateComandata.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colCantitateComandata.Visible = true;
            this.colCantitateComandata.VisibleIndex = 4;
            this.colCantitateComandata.Width = 60;
            // 
            // colCantitateDisponibilaLot
            // 
            this.colCantitateDisponibilaLot.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDisponibilaLot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDisponibilaLot.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDisponibilaLot.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDisponibilaLot.Caption = "Cantitate disponibilia din lot";
            this.colCantitateDisponibilaLot.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateDisponibilaLot.FieldName = "CantitateDisponibilaLot";
            this.colCantitateDisponibilaLot.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateDisponibilaLot.Name = "colCantitateDisponibilaLot";
            this.colCantitateDisponibilaLot.OptionsColumn.ReadOnly = true;
            this.colCantitateDisponibilaLot.Visible = true;
            this.colCantitateDisponibilaLot.VisibleIndex = 5;
            this.colCantitateDisponibilaLot.Width = 60;
            // 
            // colCantitateReceptionata
            // 
            this.colCantitateReceptionata.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateReceptionata.Caption = "Cantitate receptionata";
            this.colCantitateReceptionata.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateReceptionata.FieldName = "CantitateReceptionata";
            this.colCantitateReceptionata.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateReceptionata.Name = "colCantitateReceptionata";
            this.colCantitateReceptionata.OptionsColumn.ReadOnly = true;
            this.colCantitateReceptionata.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colCantitateReceptionata.Visible = true;
            this.colCantitateReceptionata.VisibleIndex = 6;
            this.colCantitateReceptionata.Width = 68;
            // 
            // colCantitateDispComanda
            // 
            this.colCantitateDispComanda.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDispComanda.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDispComanda.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDispComanda.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDispComanda.Caption = "Cantitate disponibila comanda";
            this.colCantitateDispComanda.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateDispComanda.FieldName = "CantitateDispComanda";
            this.colCantitateDispComanda.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateDispComanda.Name = "colCantitateDispComanda";
            this.colCantitateDispComanda.OptionsColumn.ReadOnly = true;
            this.colCantitateDispComanda.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colCantitateDispComanda.Visible = true;
            this.colCantitateDispComanda.VisibleIndex = 7;
            this.colCantitateDispComanda.Width = 58;
            // 
            // colPret
            // 
            this.colPret.AppearanceHeader.Options.UseTextOptions = true;
            this.colPret.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPret.Caption = "Pret";
            this.colPret.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colPret.FieldName = "Pret";
            this.colPret.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPret.Name = "colPret";
            this.colPret.Visible = true;
            this.colPret.VisibleIndex = 8;
            this.colPret.Width = 58;
            // 
            // colValoare
            // 
            this.colValoare.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoare.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoare.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoare.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoare.Caption = "Valoare";
            this.colValoare.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoare.FieldName = "Valoare";
            this.colValoare.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoare.Name = "colValoare";
            this.colValoare.OptionsColumn.ReadOnly = true;
            this.colValoare.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colValoare.Visible = true;
            this.colValoare.VisibleIndex = 9;
            this.colValoare.Width = 58;
            // 
            // colValoareTVA
            // 
            this.colValoareTVA.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareTVA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareTVA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareTVA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareTVA.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareTVA.FieldName = "ValoareTVA";
            this.colValoareTVA.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareTVA.Name = "colValoareTVA";
            this.colValoareTVA.OptionsColumn.ReadOnly = true;
            this.colValoareTVA.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colValoareTVA.Visible = true;
            this.colValoareTVA.VisibleIndex = 10;
            this.colValoareTVA.Width = 58;
            // 
            // colValoareCuTVA
            // 
            this.colValoareCuTVA.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareCuTVA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareCuTVA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareCuTVA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareCuTVA.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareCuTVA.FieldName = "ValoareCuTVA";
            this.colValoareCuTVA.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareCuTVA.Name = "colValoareCuTVA";
            this.colValoareCuTVA.OptionsColumn.ReadOnly = true;
            this.colValoareCuTVA.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colValoareCuTVA.Visible = true;
            this.colValoareCuTVA.VisibleIndex = 11;
            this.colValoareCuTVA.Width = 61;
            // 
            // Comenzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "Comenzi";
            this.SetWindowTitle = "Comenzi";
            this.Text = "Comenzi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Comenzi_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel2)).EndInit();
            this.splitContainerControlBaseWindow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlComenzi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewComenzi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlComenzi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewComenzi;
        private System.Windows.Forms.BindingSource tblHomeBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditData;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colLotID;
        private DevExpress.XtraGrid.Columns.GridColumn colData;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumire;
        private DevExpress.XtraGrid.Columns.GridColumn colCodProdus;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumireProdus;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDistribuita;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateComandata;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDisponibilaLot;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateReceptionata;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDispComanda;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraGrid.Columns.GridColumn colValoare;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareCuTVA;
    }
}