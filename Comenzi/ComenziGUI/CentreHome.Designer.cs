namespace ComenziGUI
{
    partial class CentreHome
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
            this.tblCentruBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewCentre = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDenumire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditValabil = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colTipCentru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditTipCentru = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ColModulId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tbxTipCentruBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel2)).BeginInit();
            this.splitContainerControlBaseWindow.Panel2.SuspendLayout();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPartener)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCentruBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCentre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditValabil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTipCentru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipCentruBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            // 
            // splitContainerControlBaseWindow.Panel2
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
            this.labelBaseWindowHeader.Appearance.Options.UseFont = true;
            this.labelBaseWindowHeader.Appearance.Options.UseTextOptions = true;
            this.labelBaseWindowHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelBaseWindowHeader.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelBaseWindowHeader.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelBaseWindowHeader.Text = "Centre";
            // 
            // gridControlPartener
            // 
            this.gridControlPartener.DataSource = this.tblCentruBindingSource;
            this.gridControlPartener.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPartener.Location = new System.Drawing.Point(0, 0);
            this.gridControlPartener.MainView = this.gridViewCentre;
            this.gridControlPartener.Name = "gridControlPartener";
            this.gridControlPartener.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditValabil,
            this.repositoryItemLookUpEditTipCentru});
            this.gridControlPartener.Size = new System.Drawing.Size(738, 456);
            this.gridControlPartener.TabIndex = 1;
            this.gridControlPartener.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCentre});
            // 
            // tblCentruBindingSource
            // 
            this.tblCentruBindingSource.DataMember = "tblCentru";
            this.tblCentruBindingSource.DataSource = typeof(CommonDataSets.GUI.Nomenclatoare);
            // 
            // gridViewCentre
            // 
            this.gridViewCentre.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCod,
            this.colDenumire,
            this.colIsActive,
            this.colTipCentru,
            this.ColModulId});
            this.gridViewCentre.GridControl = this.gridControlPartener;
            this.gridViewCentre.Name = "gridViewCentre";
            this.gridViewCentre.OptionsView.ShowAutoFilterRow = true;
            this.gridViewCentre.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewCentre_InitNewRow);
            this.gridViewCentre.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewCentre_FocusedRowChanged);
            this.gridViewCentre.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridViewCentre_InvalidRowException);
            this.gridViewCentre.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridViewCentre_ValidateRow);
            this.gridViewCentre.DoubleClick += new System.EventHandler(this.gridViewCentre_DoubleClick);
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
            this.colCod.CustomizationCaption = "Cod";
            this.colCod.FieldName = "Cod";
            this.colCod.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCod.Name = "colCod";
            this.colCod.Visible = true;
            this.colCod.VisibleIndex = 0;
            // 
            // colDenumire
            // 
            this.colDenumire.Caption = "Denumire";
            this.colDenumire.CustomizationCaption = "Denumire";
            this.colDenumire.FieldName = "Denumire";
            this.colDenumire.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDenumire.Name = "colDenumire";
            this.colDenumire.Visible = true;
            this.colDenumire.VisibleIndex = 1;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Valabil";
            this.colIsActive.ColumnEdit = this.repositoryItemCheckEditValabil;
            this.colIsActive.CustomizationCaption = "Valabil";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 2;
            // 
            // repositoryItemCheckEditValabil
            // 
            this.repositoryItemCheckEditValabil.AutoHeight = false;
            this.repositoryItemCheckEditValabil.Name = "repositoryItemCheckEditValabil";
            // 
            // colTipCentru
            // 
            this.colTipCentru.Caption = "Tip Centru";
            this.colTipCentru.ColumnEdit = this.repositoryItemLookUpEditTipCentru;
            this.colTipCentru.FieldName = "TipCentruID";
            this.colTipCentru.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTipCentru.Name = "colTipCentru";
            this.colTipCentru.Visible = true;
            this.colTipCentru.VisibleIndex = 3;
            // 
            // repositoryItemLookUpEditTipCentru
            // 
            this.repositoryItemLookUpEditTipCentru.AutoHeight = false;
            this.repositoryItemLookUpEditTipCentru.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditTipCentru.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbreviation", "Cod"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Denumire")});
            this.repositoryItemLookUpEditTipCentru.Name = "repositoryItemLookUpEditTipCentru";
            this.repositoryItemLookUpEditTipCentru.NullText = "";
            // 
            // ColModulId
            // 
            this.ColModulId.Caption = "ModulID";
            this.ColModulId.ColumnEdit = this.repositoryItemCheckEditValabil;
            this.ColModulId.FieldName = "ModulID";
            this.ColModulId.Name = "ColModulId";
            // 
            // tbxTipCentruBindingSource
            // 
            this.tbxTipCentruBindingSource.DataMember = "tbxTipCentru";
            this.tbxTipCentruBindingSource.DataSource = typeof(CommonDataSets.GUI.Nomenclatoare);
            // 
            // CentreHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "CentreHome";
            this.SetWindowHeader = "Centre";
            this.SetWindowTitle = "CentreHome";
            this.Text = "CentreHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CentreHome_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel2)).EndInit();
            this.splitContainerControlBaseWindow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPartener)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCentruBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCentre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditValabil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTipCentru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipCentruBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPartener;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCentre;
        private System.Windows.Forms.BindingSource tbxTipCentruBindingSource;
        private System.Windows.Forms.BindingSource tblCentruBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCod;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumire;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditValabil;
        private DevExpress.XtraGrid.Columns.GridColumn colTipCentru;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditTipCentru;
        private DevExpress.XtraGrid.Columns.GridColumn ColModulId;
    }
}