namespace ComenziGUI
{
    partial class CoduriCPV
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
            this.gridControlCoduriCPV = new DevExpress.XtraGrid.GridControl();
            this.tblCPVCodesBindingSource = new System.Windows.Forms.BindingSource();
            this.gridViewCoduriCPV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescriereRO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescriereEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditValabil = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpirationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel2)).BeginInit();
            this.splitContainerControlBaseWindow.Panel2.SuspendLayout();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCoduriCPV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCPVCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCoduriCPV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditValabil)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            // 
            // splitContainerControlBaseWindow.Panel2
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlCoduriCPV);
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
            // gridControlCoduriCPV
            // 
            this.gridControlCoduriCPV.DataSource = this.tblCPVCodesBindingSource;
            this.gridControlCoduriCPV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCoduriCPV.Location = new System.Drawing.Point(0, 0);
            this.gridControlCoduriCPV.MainView = this.gridViewCoduriCPV;
            this.gridControlCoduriCPV.Name = "gridControlCoduriCPV";
            this.gridControlCoduriCPV.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditValabil});
            this.gridControlCoduriCPV.Size = new System.Drawing.Size(738, 456);
            this.gridControlCoduriCPV.TabIndex = 1;
            this.gridControlCoduriCPV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCoduriCPV});
            // 
            // tblCPVCodesBindingSource
            // 
            this.tblCPVCodesBindingSource.DataMember = "tblCPVCodes";
            this.tblCPVCodesBindingSource.DataSource = typeof(CommonDataSets.GUI.Nomenclatoare);
            // 
            // gridViewCoduriCPV
            // 
            this.gridViewCoduriCPV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCod,
            this.colDescriereRO,
            this.colDescriereEN,
            this.colIsActive,
            this.colEffectiveDate,
            this.colExpirationDate});
            this.gridViewCoduriCPV.GridControl = this.gridControlCoduriCPV;
            this.gridViewCoduriCPV.Name = "gridViewCoduriCPV";
            this.gridViewCoduriCPV.OptionsView.ShowAutoFilterRow = true;
            this.gridViewCoduriCPV.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewCoduriCPV_InitNewRow);
            this.gridViewCoduriCPV.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewCoduriCPV_FocusedRowChanged);
            this.gridViewCoduriCPV.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridViewCoduriCPV_InvalidRowException);
            this.gridViewCoduriCPV.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridViewCoduriCPV_ValidateRow);
            this.gridViewCoduriCPV.DoubleClick += new System.EventHandler(this.gridViewCoduriCPV_DoubleClick);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colID.Name = "colID";
            // 
            // colCod
            // 
            this.colCod.Caption = "Cod";
            this.colCod.FieldName = "Cod";
            this.colCod.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCod.Name = "colCod";
            this.colCod.Visible = true;
            this.colCod.VisibleIndex = 0;
            // 
            // colDescriereRO
            // 
            this.colDescriereRO.Caption = "Denumire RO";
            this.colDescriereRO.FieldName = "DescriereRO";
            this.colDescriereRO.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDescriereRO.Name = "colDescriereRO";
            this.colDescriereRO.Visible = true;
            this.colDescriereRO.VisibleIndex = 1;
            // 
            // colDescriereEN
            // 
            this.colDescriereEN.Caption = "Denumire EN";
            this.colDescriereEN.FieldName = "DescriereEN";
            this.colDescriereEN.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDescriereEN.Name = "colDescriereEN";
            this.colDescriereEN.Visible = true;
            this.colDescriereEN.VisibleIndex = 2;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Valabil";
            this.colIsActive.ColumnEdit = this.repositoryItemCheckEditValabil;
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 3;
            // 
            // repositoryItemCheckEditValabil
            // 
            this.repositoryItemCheckEditValabil.AutoHeight = false;
            this.repositoryItemCheckEditValabil.Name = "repositoryItemCheckEditValabil";
            // 
            // colEffectiveDate
            // 
            this.colEffectiveDate.FieldName = "EffectiveDate";
            this.colEffectiveDate.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colEffectiveDate.Name = "colEffectiveDate";
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.FieldName = "ExpirationDate";
            this.colExpirationDate.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colExpirationDate.Name = "colExpirationDate";
            // 
            // CoduriCPV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "CoduriCPV";
            this.SetWindowTitle = "CoduriCPV";
            this.Text = "CoduriCPV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CoduriCPV_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel2)).EndInit();
            this.splitContainerControlBaseWindow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCoduriCPV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCPVCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCoduriCPV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditValabil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCoduriCPV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCoduriCPV;
        private System.Windows.Forms.BindingSource tblCPVCodesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCod;
        private DevExpress.XtraGrid.Columns.GridColumn colDescriereRO;
        private DevExpress.XtraGrid.Columns.GridColumn colDescriereEN;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditValabil;
        private DevExpress.XtraGrid.Columns.GridColumn colEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpirationDate;
    }
}