namespace ComenziGUI
{
    partial class AcordCadru
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
            this.gridControlAcordCadru = new DevExpress.XtraGrid.GridControl();
            this.tblAcordCadruHomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewAcordCadru = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcordCadru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipCentruID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEditTipCentru = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEditData = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colDataStop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFurnizor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCantitateTotala = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisponibil = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAcordCadru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAcordCadruHomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAcordCadru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditTipCentru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlAcordCadru);
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
            // gridControlAcordCadru
            // 
            this.gridControlAcordCadru.DataSource = this.tblAcordCadruHomeBindingSource;
            this.gridControlAcordCadru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlAcordCadru.Location = new System.Drawing.Point(0, 0);
            this.gridControlAcordCadru.MainView = this.gridViewAcordCadru;
            this.gridControlAcordCadru.Name = "gridControlAcordCadru";
            this.gridControlAcordCadru.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma,
            this.repositoryItemDateEditData,
            this.repositoryItemGridLookUpEditTipCentru});
            this.gridControlAcordCadru.Size = new System.Drawing.Size(739, 456);
            this.gridControlAcordCadru.TabIndex = 1;
            this.gridControlAcordCadru.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAcordCadru});
            // 
            // tblAcordCadruHomeBindingSource
            // 
            this.tblAcordCadruHomeBindingSource.DataMember = "tblAcordCadruHome";
            this.tblAcordCadruHomeBindingSource.DataSource = typeof(CommonDataSets.GUI.AcordCadruDataSet);
            // 
            // gridViewAcordCadru
            // 
            this.gridViewAcordCadru.ColumnPanelRowHeight = 50;
            this.gridViewAcordCadru.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colAcordCadru,
            this.colTipCentruID,
            this.colData,
            this.colDataStop,
            this.colFurnizor,
            this.colProdus,
            this.colPret,
            this.colCantitateTotala,
            this.colValoare,
            this.colDisponibil});
            this.gridViewAcordCadru.GridControl = this.gridControlAcordCadru;
            this.gridViewAcordCadru.GroupCount = 1;
            this.gridViewAcordCadru.Name = "gridViewAcordCadru";
            this.gridViewAcordCadru.OptionsBehavior.Editable = false;
            this.gridViewAcordCadru.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAcordCadru, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colAcordCadru
            // 
            this.colAcordCadru.AppearanceHeader.Options.UseTextOptions = true;
            this.colAcordCadru.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAcordCadru.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colAcordCadru.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAcordCadru.FieldName = "AcordCadru";
            this.colAcordCadru.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colAcordCadru.Name = "colAcordCadru";
            this.colAcordCadru.Visible = true;
            this.colAcordCadru.VisibleIndex = 1;
            // 
            // colTipCentruID
            // 
            this.colTipCentruID.AppearanceHeader.Options.UseTextOptions = true;
            this.colTipCentruID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTipCentruID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTipCentruID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTipCentruID.Caption = "Tip Centru";
            this.colTipCentruID.ColumnEdit = this.repositoryItemGridLookUpEditTipCentru;
            this.colTipCentruID.FieldName = "TipCentruID";
            this.colTipCentruID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTipCentruID.Name = "colTipCentruID";
            this.colTipCentruID.Visible = true;
            this.colTipCentruID.VisibleIndex = 0;
            // 
            // repositoryItemGridLookUpEditTipCentru
            // 
            this.repositoryItemGridLookUpEditTipCentru.AutoHeight = false;
            this.repositoryItemGridLookUpEditTipCentru.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEditTipCentru.Name = "repositoryItemGridLookUpEditTipCentru";
            this.repositoryItemGridLookUpEditTipCentru.NullText = "";
            this.repositoryItemGridLookUpEditTipCentru.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colData
            // 
            this.colData.AppearanceHeader.Options.UseTextOptions = true;
            this.colData.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colData.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colData.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colData.ColumnEdit = this.repositoryItemDateEditData;
            this.colData.FieldName = "DataStart";
            this.colData.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colData.Name = "colData";
            this.colData.Visible = true;
            this.colData.VisibleIndex = 1;
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
            // colDataStop
            // 
            this.colDataStop.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataStop.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataStop.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDataStop.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDataStop.Caption = "Data Stop";
            this.colDataStop.ColumnEdit = this.repositoryItemDateEditData;
            this.colDataStop.FieldName = "DataStop";
            this.colDataStop.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDataStop.Name = "colDataStop";
            this.colDataStop.Visible = true;
            this.colDataStop.VisibleIndex = 2;
            // 
            // colFurnizor
            // 
            this.colFurnizor.AppearanceHeader.Options.UseTextOptions = true;
            this.colFurnizor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFurnizor.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colFurnizor.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colFurnizor.FieldName = "Furnizor";
            this.colFurnizor.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colFurnizor.Name = "colFurnizor";
            this.colFurnizor.Visible = true;
            this.colFurnizor.VisibleIndex = 3;
            // 
            // colProdus
            // 
            this.colProdus.AppearanceHeader.Options.UseTextOptions = true;
            this.colProdus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProdus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProdus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProdus.FieldName = "Produs";
            this.colProdus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colProdus.Name = "colProdus";
            this.colProdus.Visible = true;
            this.colProdus.VisibleIndex = 4;
            // 
            // colPret
            // 
            this.colPret.AppearanceHeader.Options.UseTextOptions = true;
            this.colPret.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPret.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colPret.FieldName = "Pret";
            this.colPret.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPret.Name = "colPret";
            this.colPret.Visible = true;
            this.colPret.VisibleIndex = 5;
            // 
            // repositoryItemTextEditSuma
            // 
            this.repositoryItemTextEditSuma.AutoHeight = false;
            this.repositoryItemTextEditSuma.Name = "repositoryItemTextEditSuma";
            // 
            // colCantitateTotala
            // 
            this.colCantitateTotala.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateTotala.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateTotala.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateTotala.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateTotala.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateTotala.FieldName = "CantitateTotala";
            this.colCantitateTotala.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateTotala.Name = "colCantitateTotala";
            this.colCantitateTotala.Visible = true;
            this.colCantitateTotala.VisibleIndex = 6;
            // 
            // colValoare
            // 
            this.colValoare.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoare.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoare.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoare.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoare.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoare.FieldName = "Valoare";
            this.colValoare.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoare.Name = "colValoare";
            this.colValoare.Visible = true;
            this.colValoare.VisibleIndex = 7;
            // 
            // colDisponibil
            // 
            this.colDisponibil.AppearanceHeader.Options.UseTextOptions = true;
            this.colDisponibil.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDisponibil.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDisponibil.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDisponibil.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colDisponibil.FieldName = "Disponibil";
            this.colDisponibil.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDisponibil.Name = "colDisponibil";
            this.colDisponibil.Visible = true;
            this.colDisponibil.VisibleIndex = 8;
            // 
            // AcordCadru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "AcordCadru";
            this.SetWindowTitle = "AcordCadru";
            this.Text = "AcordCadru";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAcordCadru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAcordCadruHomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAcordCadru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditTipCentru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlAcordCadru;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAcordCadru;
        private System.Windows.Forms.BindingSource tblAcordCadruHomeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colAcordCadru;
        private DevExpress.XtraGrid.Columns.GridColumn colTipCentruID;
        private DevExpress.XtraGrid.Columns.GridColumn colData;
        private DevExpress.XtraGrid.Columns.GridColumn colFurnizor;
        private DevExpress.XtraGrid.Columns.GridColumn colProdus;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateTotala;
        private DevExpress.XtraGrid.Columns.GridColumn colValoare;
        private DevExpress.XtraGrid.Columns.GridColumn colDisponibil;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditData;
        private DevExpress.XtraGrid.Columns.GridColumn colDataStop;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEditTipCentru;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
    }
}