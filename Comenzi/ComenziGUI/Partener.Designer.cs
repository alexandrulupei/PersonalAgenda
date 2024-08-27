namespace ComenziGUI
{
    partial class Partener
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
            this.gridControlPartener = new DevExpress.XtraGrid.GridControl();
            this.tblPartenerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewPartener = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDenumire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEditAdresa = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colDetalii = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEditDetalii = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCUI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditIsActive = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPartener)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPartenerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPartener)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditAdresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditDetalii)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditIsActive)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlPartener);
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
            // gridControlPartener
            // 
            this.gridControlPartener.DataSource = this.tblPartenerBindingSource;
            this.gridControlPartener.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPartener.Location = new System.Drawing.Point(0, 0);
            this.gridControlPartener.MainView = this.gridViewPartener;
            this.gridControlPartener.Name = "gridControlPartener";
            this.gridControlPartener.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditIsActive,
            this.repositoryItemMemoEditAdresa,
            this.repositoryItemMemoEditDetalii});
            this.gridControlPartener.Size = new System.Drawing.Size(739, 456);
            this.gridControlPartener.TabIndex = 1;
            this.gridControlPartener.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPartener});
            // 
            // tblPartenerBindingSource
            // 
            this.tblPartenerBindingSource.DataMember = "tblPartener";
            this.tblPartenerBindingSource.DataSource = typeof(CommonDataSets.GUI.Nomenclatoare);
            // 
            // gridViewPartener
            // 
            this.gridViewPartener.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCod,
            this.colDenumire,
            this.colAdresa,
            this.colDetalii,
            this.colCUI,
            this.colIsActive,
            this.colUserName});
            this.gridViewPartener.GridControl = this.gridControlPartener;
            this.gridViewPartener.Name = "gridViewPartener";
            this.gridViewPartener.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewPartener_InitNewRow);
            this.gridViewPartener.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewPartener_FocusedRowChanged);
            this.gridViewPartener.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridViewPartener_InvalidRowException);
            this.gridViewPartener.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridViewPartener_ValidateRow);
            this.gridViewPartener.DoubleClick += new System.EventHandler(this.gridViewPartener_DoubleClick);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colCod
            // 
            this.colCod.Caption = "Cod";
            this.colCod.FieldName = "Cod";
            this.colCod.Name = "colCod";
            this.colCod.Visible = true;
            this.colCod.VisibleIndex = 0;
            // 
            // colDenumire
            // 
            this.colDenumire.Caption = "Denumire";
            this.colDenumire.FieldName = "Denumire";
            this.colDenumire.Name = "colDenumire";
            this.colDenumire.Visible = true;
            this.colDenumire.VisibleIndex = 1;
            // 
            // colAdresa
            // 
            this.colAdresa.Caption = "Adresa";
            this.colAdresa.ColumnEdit = this.repositoryItemMemoEditAdresa;
            this.colAdresa.FieldName = "Adresa";
            this.colAdresa.Name = "colAdresa";
            this.colAdresa.Visible = true;
            this.colAdresa.VisibleIndex = 2;
            // 
            // repositoryItemMemoEditAdresa
            // 
            this.repositoryItemMemoEditAdresa.Name = "repositoryItemMemoEditAdresa";
            // 
            // colDetalii
            // 
            this.colDetalii.Caption = "Detalii";
            this.colDetalii.ColumnEdit = this.repositoryItemMemoEditDetalii;
            this.colDetalii.FieldName = "Detalii";
            this.colDetalii.Name = "colDetalii";
            this.colDetalii.Visible = true;
            this.colDetalii.VisibleIndex = 3;
            // 
            // repositoryItemMemoEditDetalii
            // 
            this.repositoryItemMemoEditDetalii.Name = "repositoryItemMemoEditDetalii";
            // 
            // colCUI
            // 
            this.colCUI.Caption = "CUI";
            this.colCUI.FieldName = "CUI";
            this.colCUI.Name = "colCUI";
            this.colCUI.Visible = true;
            this.colCUI.VisibleIndex = 4;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Valabil";
            this.colIsActive.ColumnEdit = this.repositoryItemCheckEditIsActive;
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 5;
            // 
            // repositoryItemCheckEditIsActive
            // 
            this.repositoryItemCheckEditIsActive.AutoHeight = false;
            this.repositoryItemCheckEditIsActive.Name = "repositoryItemCheckEditIsActive";
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            // 
            // Partener
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "Partener";
            this.SetWindowTitle = "Partener";
            this.Text = "Partener";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Partener_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPartener)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPartenerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPartener)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditAdresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditDetalii)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditIsActive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPartener;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPartener;
        private System.Windows.Forms.BindingSource tblPartenerBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCod;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumire;
        private DevExpress.XtraGrid.Columns.GridColumn colAdresa;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalii;
        private DevExpress.XtraGrid.Columns.GridColumn colCUI;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditIsActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEditAdresa;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEditDetalii;
    }
}