namespace ComenziGUI
{
    partial class Lot
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
            this.gridControlLot = new DevExpress.XtraGrid.GridControl();
            this.tblLotHomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewLot = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodCPV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPartener = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditsuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCantitate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEditData = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colCantitateDistribuita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateRamasa = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLotHomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditsuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlLot);
            // 
            // progressBarControlBaseWindow
            // 
            this.progressBarControlBaseWindow.Visible = false;
            // 
            // labelBaseWindowHeader
            // 
            this.labelBaseWindowHeader.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBaseWindowHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelBaseWindowHeader.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelBaseWindowHeader.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            // 
            // gridControlLot
            // 
            this.gridControlLot.DataSource = this.tblLotHomeBindingSource;
            this.gridControlLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLot.Location = new System.Drawing.Point(0, 0);
            this.gridControlLot.MainView = this.gridViewLot;
            this.gridControlLot.Name = "gridControlLot";
            this.gridControlLot.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditsuma,
            this.repositoryItemDateEditData});
            this.gridControlLot.Size = new System.Drawing.Size(739, 456);
            this.gridControlLot.TabIndex = 1;
            this.gridControlLot.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLot});
            // 
            // tblLotHomeBindingSource
            // 
            this.tblLotHomeBindingSource.DataMember = "tblLotHome";
            this.tblLotHomeBindingSource.DataSource = typeof(CommonDataSets.GUI.LotDataSet);
            // 
            // gridViewLot
            // 
            this.gridViewLot.ColumnPanelRowHeight = 35;
            this.gridViewLot.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colLot,
            this.colCodCPV,
            this.colPartener,
            this.colProdus,
            this.colPret,
            this.colCantitate,
            this.colValoare,
            this.colData,
            this.colCantitateDistribuita,
            this.colCantitateRamasa});
            this.gridViewLot.GridControl = this.gridControlLot;
            this.gridViewLot.GroupCount = 1;
            this.gridViewLot.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Valoare", this.colValoare, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantitate", this.colCantitate, "")});
            this.gridViewLot.Name = "gridViewLot";
            this.gridViewLot.OptionsView.AllowCellMerge = true;
            this.gridViewLot.OptionsView.ShowAutoFilterRow = true;
            this.gridViewLot.OptionsView.ShowFooter = true;
            this.gridViewLot.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLot, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.ReadOnly = true;
            // 
            // colLot
            // 
            this.colLot.AppearanceHeader.Options.UseTextOptions = true;
            this.colLot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLot.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLot.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLot.Caption = "Lot";
            this.colLot.FieldName = "Lot";
            this.colLot.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colLot.Name = "colLot";
            this.colLot.OptionsColumn.AllowEdit = false;
            this.colLot.OptionsColumn.ReadOnly = true;
            this.colLot.Visible = true;
            this.colLot.VisibleIndex = 0;
            // 
            // colCodCPV
            // 
            this.colCodCPV.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodCPV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodCPV.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCodCPV.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodCPV.Caption = "Cod CPV";
            this.colCodCPV.FieldName = "CodCPV";
            this.colCodCPV.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCodCPV.Name = "colCodCPV";
            this.colCodCPV.OptionsColumn.AllowEdit = false;
            this.colCodCPV.OptionsColumn.ReadOnly = true;
            this.colCodCPV.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colPartener
            // 
            this.colPartener.AppearanceHeader.Options.UseTextOptions = true;
            this.colPartener.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPartener.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPartener.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPartener.Caption = "Furnizor";
            this.colPartener.FieldName = "Partener";
            this.colPartener.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPartener.Name = "colPartener";
            this.colPartener.OptionsColumn.AllowEdit = false;
            this.colPartener.OptionsColumn.ReadOnly = true;
            this.colPartener.Visible = true;
            this.colPartener.VisibleIndex = 1;
            // 
            // colProdus
            // 
            this.colProdus.AppearanceHeader.Options.UseTextOptions = true;
            this.colProdus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProdus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProdus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProdus.Caption = "Produs";
            this.colProdus.FieldName = "Produs";
            this.colProdus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colProdus.Name = "colProdus";
            this.colProdus.OptionsColumn.AllowEdit = false;
            this.colProdus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colProdus.OptionsColumn.ReadOnly = true;
            this.colProdus.Visible = true;
            this.colProdus.VisibleIndex = 2;
            // 
            // colPret
            // 
            this.colPret.AppearanceHeader.Options.UseTextOptions = true;
            this.colPret.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPret.Caption = "Pret";
            this.colPret.ColumnEdit = this.repositoryItemTextEditsuma;
            this.colPret.FieldName = "Pret";
            this.colPret.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPret.Name = "colPret";
            this.colPret.OptionsColumn.AllowEdit = false;
            this.colPret.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPret.OptionsColumn.ReadOnly = true;
            this.colPret.Visible = true;
            this.colPret.VisibleIndex = 3;
            // 
            // repositoryItemTextEditsuma
            // 
            this.repositoryItemTextEditsuma.AutoHeight = false;
            this.repositoryItemTextEditsuma.Name = "repositoryItemTextEditsuma";
            // 
            // colCantitate
            // 
            this.colCantitate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitate.Caption = "Cantitate";
            this.colCantitate.ColumnEdit = this.repositoryItemTextEditsuma;
            this.colCantitate.FieldName = "Cantitate";
            this.colCantitate.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitate.Name = "colCantitate";
            this.colCantitate.OptionsColumn.AllowEdit = false;
            this.colCantitate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCantitate.OptionsColumn.ReadOnly = true;
            this.colCantitate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colCantitate.Visible = true;
            this.colCantitate.VisibleIndex = 4;
            // 
            // colValoare
            // 
            this.colValoare.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoare.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoare.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoare.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoare.Caption = "Valoare";
            this.colValoare.ColumnEdit = this.repositoryItemTextEditsuma;
            this.colValoare.FieldName = "Valoare";
            this.colValoare.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoare.Name = "colValoare";
            this.colValoare.OptionsColumn.AllowEdit = false;
            this.colValoare.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValoare.OptionsColumn.ReadOnly = true;
            this.colValoare.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colValoare.Visible = true;
            this.colValoare.VisibleIndex = 5;
            // 
            // colData
            // 
            this.colData.AppearanceHeader.Options.UseTextOptions = true;
            this.colData.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colData.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colData.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colData.Caption = "Data";
            this.colData.ColumnEdit = this.repositoryItemDateEditData;
            this.colData.FieldName = "Data";
            this.colData.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colData.Name = "colData";
            this.colData.Visible = true;
            this.colData.VisibleIndex = 0;
            // 
            // repositoryItemDateEditData
            // 
            this.repositoryItemDateEditData.AutoHeight = false;
            this.repositoryItemDateEditData.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEditData.Name = "repositoryItemDateEditData";
            this.repositoryItemDateEditData.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colCantitateDistribuita
            // 
            this.colCantitateDistribuita.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDistribuita.Caption = "Total Distribuit";
            this.colCantitateDistribuita.ColumnEdit = this.repositoryItemTextEditsuma;
            this.colCantitateDistribuita.FieldName = "CantitateDistributa";
            this.colCantitateDistribuita.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateDistribuita.Name = "colCantitateDistribuita";
            this.colCantitateDistribuita.OptionsColumn.AllowEdit = false;
            this.colCantitateDistribuita.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCantitateDistribuita.OptionsColumn.ReadOnly = true;
            this.colCantitateDistribuita.Visible = true;
            this.colCantitateDistribuita.VisibleIndex = 6;
            // 
            // colCantitateRamasa
            // 
            this.colCantitateRamasa.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateRamasa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateRamasa.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateRamasa.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateRamasa.Caption = "Nedistribuit ";
            this.colCantitateRamasa.ColumnEdit = this.repositoryItemTextEditsuma;
            this.colCantitateRamasa.FieldName = "CantitateRamasa";
            this.colCantitateRamasa.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateRamasa.Name = "colCantitateRamasa";
            this.colCantitateRamasa.OptionsColumn.AllowEdit = false;
            this.colCantitateRamasa.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCantitateRamasa.OptionsColumn.ReadOnly = true;
            this.colCantitateRamasa.Visible = true;
            this.colCantitateRamasa.VisibleIndex = 7;
            // 
            // Lot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "Lot";
            this.SetWindowTitle = "Lot";
            this.Text = "Lot";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLotHomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditsuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlLot;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLot;
        private System.Windows.Forms.BindingSource tblLotHomeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colLot;
        private DevExpress.XtraGrid.Columns.GridColumn colCodCPV;
        private DevExpress.XtraGrid.Columns.GridColumn colPartener;
        private DevExpress.XtraGrid.Columns.GridColumn colProdus;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitate;
        private DevExpress.XtraGrid.Columns.GridColumn colValoare;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditsuma;
        private DevExpress.XtraGrid.Columns.GridColumn colData;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditData;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDistribuita;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateRamasa;
    }
}