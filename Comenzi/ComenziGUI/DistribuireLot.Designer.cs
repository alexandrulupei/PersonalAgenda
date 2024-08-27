namespace ComenziGUI
{
    partial class DistribuireLot
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
            this.gridControlDistribuire = new DevExpress.XtraGrid.GridControl();
            this.tblHomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewDistribuire = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateDistribuita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditsuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colValoare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotBaseID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDistribuire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDistribuire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditsuma)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlDistribuire);
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
            // gridControlDistribuire
            // 
            this.gridControlDistribuire.DataSource = this.tblHomeBindingSource;
            this.gridControlDistribuire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDistribuire.Location = new System.Drawing.Point(0, 0);
            this.gridControlDistribuire.MainView = this.gridViewDistribuire;
            this.gridControlDistribuire.Name = "gridControlDistribuire";
            this.gridControlDistribuire.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditsuma});
            this.gridControlDistribuire.Size = new System.Drawing.Size(739, 456);
            this.gridControlDistribuire.TabIndex = 1;
            this.gridControlDistribuire.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDistribuire});
            // 
            // tblHomeBindingSource
            // 
            this.tblHomeBindingSource.DataMember = "tblHome";
            this.tblHomeBindingSource.DataSource = typeof(CommonDataSets.GUI.DistribuireDataSet);
            // 
            // gridViewDistribuire
            // 
            this.gridViewDistribuire.ColumnPanelRowHeight = 35;
            this.gridViewDistribuire.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colLot,
            this.colCentru,
            this.colProduse,
            this.colCantitateDistribuita,
            this.colValoare,
            this.colLotBaseID});
            this.gridViewDistribuire.GridControl = this.gridControlDistribuire;
            this.gridViewDistribuire.GroupCount = 2;
            this.gridViewDistribuire.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CantitateDistribuita", this.colCantitateDistribuita, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Valoare", this.colValoare, "")});
            this.gridViewDistribuire.Name = "gridViewDistribuire";
            this.gridViewDistribuire.OptionsView.ShowAutoFilterRow = true;
            this.gridViewDistribuire.OptionsView.ShowFooter = true;
            this.gridViewDistribuire.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLot, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCentru, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            // colCentru
            // 
            this.colCentru.AppearanceHeader.Options.UseTextOptions = true;
            this.colCentru.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCentru.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCentru.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCentru.Caption = "Centru";
            this.colCentru.FieldName = "Centru";
            this.colCentru.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCentru.Name = "colCentru";
            this.colCentru.OptionsColumn.AllowEdit = false;
            this.colCentru.OptionsColumn.ReadOnly = true;
            this.colCentru.Visible = true;
            this.colCentru.VisibleIndex = 0;
            // 
            // colProduse
            // 
            this.colProduse.AppearanceHeader.Options.UseTextOptions = true;
            this.colProduse.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProduse.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProduse.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProduse.Caption = "Produs";
            this.colProduse.FieldName = "Produse";
            this.colProduse.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colProduse.Name = "colProduse";
            this.colProduse.OptionsColumn.AllowEdit = false;
            this.colProduse.OptionsColumn.ReadOnly = true;
            this.colProduse.Visible = true;
            this.colProduse.VisibleIndex = 0;
            // 
            // colCantitateDistribuita
            // 
            this.colCantitateDistribuita.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDistribuita.Caption = "Cantitate";
            this.colCantitateDistribuita.ColumnEdit = this.repositoryItemTextEditsuma;
            this.colCantitateDistribuita.FieldName = "CantitateDistribuita";
            this.colCantitateDistribuita.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateDistribuita.Name = "colCantitateDistribuita";
            this.colCantitateDistribuita.OptionsColumn.AllowEdit = false;
            this.colCantitateDistribuita.OptionsColumn.ReadOnly = true;
            this.colCantitateDistribuita.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colCantitateDistribuita.Visible = true;
            this.colCantitateDistribuita.VisibleIndex = 1;
            // 
            // repositoryItemTextEditsuma
            // 
            this.repositoryItemTextEditsuma.AutoHeight = false;
            this.repositoryItemTextEditsuma.Name = "repositoryItemTextEditsuma";
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
            this.colValoare.OptionsColumn.ReadOnly = true;
            this.colValoare.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colValoare.Visible = true;
            this.colValoare.VisibleIndex = 2;
            // 
            // colLotBaseID
            // 
            this.colLotBaseID.Caption = "gridColumn1";
            this.colLotBaseID.FieldName = "LotBaseID";
            this.colLotBaseID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colLotBaseID.Name = "colLotBaseID";
            // 
            // DistribuireLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "DistribuireLot";
            this.SetWindowTitle = "DistribuireLot";
            this.Text = "DistribuireLot";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDistribuire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDistribuire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditsuma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDistribuire;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDistribuire;
        private System.Windows.Forms.BindingSource tblHomeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colLot;
        private DevExpress.XtraGrid.Columns.GridColumn colCentru;
        private DevExpress.XtraGrid.Columns.GridColumn colProduse;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDistribuita;
        private DevExpress.XtraGrid.Columns.GridColumn colValoare;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditsuma;
        private DevExpress.XtraGrid.Columns.GridColumn colLotBaseID;
    }
}