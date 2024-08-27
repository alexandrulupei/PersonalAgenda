namespace ComenziGUI
{
    partial class Produse
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
            this.gridControlProduse = new DevExpress.XtraGrid.GridControl();
            this.tblProduseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewProduse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDenumire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCotaTVAID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditCotaTva = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colPretCuTva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUMID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditUM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProduse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProduseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProduse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditCotaTva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditUM)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlProduse);
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
            // gridControlProduse
            // 
            this.gridControlProduse.DataSource = this.tblProduseBindingSource;
            this.gridControlProduse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProduse.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControlProduse_EmbeddedNavigator_ButtonClick);
            this.gridControlProduse.Location = new System.Drawing.Point(0, 0);
            this.gridControlProduse.MainView = this.gridViewProduse;
            this.gridControlProduse.Name = "gridControlProduse";
            this.gridControlProduse.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma,
            this.repositoryItemLookUpEditCotaTva,
            this.repositoryItemLookUpEditUM});
            this.gridControlProduse.Size = new System.Drawing.Size(739, 456);
            this.gridControlProduse.TabIndex = 1;
            this.gridControlProduse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProduse});
            // 
            // tblProduseBindingSource
            // 
            this.tblProduseBindingSource.DataMember = "tblProduse";
            this.tblProduseBindingSource.DataSource = typeof(CommonDataSets.GUI.Nomenclatoare);
            // 
            // gridViewProduse
            // 
            this.gridViewProduse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCod,
            this.colDenumire,
            this.colPret,
            this.colCotaTVAID,
            this.colPretCuTva,
            this.colUMID});
            this.gridViewProduse.GridControl = this.gridControlProduse;
            this.gridViewProduse.Name = "gridViewProduse";
            this.gridViewProduse.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCod, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewProduse.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewProduse_InitNewRow);
            this.gridViewProduse.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewProduse_FocusedRowChanged);
            this.gridViewProduse.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewProduse_CellValueChanged);
            this.gridViewProduse.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridViewProduse_InvalidRowException);
            this.gridViewProduse.DoubleClick += new System.EventHandler(this.gridViewProduse_DoubleClick);
            this.gridViewProduse.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gridViewProduse_InvalidValueException);
            // 
            // colID
            // 
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colCod
            // 
            this.colCod.AppearanceHeader.Options.UseTextOptions = true;
            this.colCod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCod.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCod.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.colCod.Caption = "Cod";
            this.colCod.FieldName = "Cod";
            this.colCod.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCod.Name = "colCod";
            this.colCod.Visible = true;
            this.colCod.VisibleIndex = 0;
            // 
            // colDenumire
            // 
            this.colDenumire.AppearanceHeader.Options.UseTextOptions = true;
            this.colDenumire.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDenumire.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDenumire.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.colDenumire.Caption = "Denumire";
            this.colDenumire.FieldName = "Denumire";
            this.colDenumire.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDenumire.Name = "colDenumire";
            this.colDenumire.Visible = true;
            this.colDenumire.VisibleIndex = 1;
            // 
            // colPret
            // 
            this.colPret.AppearanceHeader.Options.UseTextOptions = true;
            this.colPret.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPret.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.colPret.Caption = "Pret";
            this.colPret.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colPret.FieldName = "Pret";
            this.colPret.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPret.Name = "colPret";
            this.colPret.Visible = true;
            this.colPret.VisibleIndex = 3;
            // 
            // repositoryItemTextEditSuma
            // 
            this.repositoryItemTextEditSuma.AutoHeight = false;
            this.repositoryItemTextEditSuma.Name = "repositoryItemTextEditSuma";
            // 
            // colCotaTVAID
            // 
            this.colCotaTVAID.AppearanceHeader.Options.UseTextOptions = true;
            this.colCotaTVAID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCotaTVAID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCotaTVAID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.colCotaTVAID.Caption = "Cota TVA";
            this.colCotaTVAID.ColumnEdit = this.repositoryItemLookUpEditCotaTva;
            this.colCotaTVAID.FieldName = "CotaTVAID";
            this.colCotaTVAID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCotaTVAID.Name = "colCotaTVAID";
            this.colCotaTVAID.Visible = true;
            this.colCotaTVAID.VisibleIndex = 2;
            // 
            // repositoryItemLookUpEditCotaTva
            // 
            this.repositoryItemLookUpEditCotaTva.AutoHeight = false;
            this.repositoryItemLookUpEditCotaTva.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditCotaTva.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Valoare", "Valoare")});
            this.repositoryItemLookUpEditCotaTva.Name = "repositoryItemLookUpEditCotaTva";
            this.repositoryItemLookUpEditCotaTva.NullText = "";
            // 
            // colPretCuTva
            // 
            this.colPretCuTva.AppearanceHeader.Options.UseTextOptions = true;
            this.colPretCuTva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPretCuTva.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPretCuTva.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.colPretCuTva.Caption = "Pret cu tva";
            this.colPretCuTva.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colPretCuTva.FieldName = "PretCuTva";
            this.colPretCuTva.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPretCuTva.Name = "colPretCuTva";
            this.colPretCuTva.Visible = true;
            this.colPretCuTva.VisibleIndex = 5;
            // 
            // colUMID
            // 
            this.colUMID.AppearanceHeader.Options.UseTextOptions = true;
            this.colUMID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUMID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUMID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.colUMID.Caption = "U.M.";
            this.colUMID.ColumnEdit = this.repositoryItemLookUpEditUM;
            this.colUMID.FieldName = "UMID";
            this.colUMID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colUMID.Name = "colUMID";
            this.colUMID.Visible = true;
            this.colUMID.VisibleIndex = 4;
            // 
            // repositoryItemLookUpEditUM
            // 
            this.repositoryItemLookUpEditUM.AutoHeight = false;
            this.repositoryItemLookUpEditUM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditUM.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbreviation", "Cod"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Denumire")});
            this.repositoryItemLookUpEditUM.Name = "repositoryItemLookUpEditUM";
            this.repositoryItemLookUpEditUM.NullText = "";
            // 
            // Produse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "Produse";
            this.SetWindowTitle = "Produse";
            this.Text = "Produse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Produse_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProduse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblProduseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProduse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditCotaTva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditUM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlProduse;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProduse;
        private System.Windows.Forms.BindingSource tblProduseBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCod;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumire;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraGrid.Columns.GridColumn colCotaTVAID;
        private DevExpress.XtraGrid.Columns.GridColumn colPretCuTva;
        private DevExpress.XtraGrid.Columns.GridColumn colUMID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditCotaTva;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditUM;
    }
}