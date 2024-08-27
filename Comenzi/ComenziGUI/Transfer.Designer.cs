namespace ComenziGUI
{
    partial class Transfer
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlDetaliiTransfer = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDate = new DevExpress.XtraGrid.GridControl();
            this.tblDateDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewDate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLotBaseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentruSursaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDenumire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCantitateDisponibila = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateTranferata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareTransferta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateRamasa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlDate = new DevExpress.XtraEditors.GroupControl();
            this.lookUpEditCentruDestinatie = new DevExpress.XtraEditors.LookUpEdit();
            this.tblCentruBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditCentruSursa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControlCentruSursa = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditTipCentru = new DevExpress.XtraEditors.LookUpEdit();
            this.tbxTipCentruBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControlTipCentru = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditLot = new DevExpress.XtraEditors.LookUpEdit();
            this.tblLotBaseDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ucDatadata = new CommonGUIControllers.UC.UCData();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetaliiTransfer)).BeginInit();
            this.groupControlDetaliiTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDateDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDate)).BeginInit();
            this.groupControlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCentruDestinatie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCentruBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCentruSursa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTipCentru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipCentruBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLotBaseDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Controls.Add(this.simpleButtonSave);
            this.panelControl1.Controls.Add(this.groupControlDetaliiTransfer);
            this.panelControl1.Controls.Add(this.groupControlDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(698, 506);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Location = new System.Drawing.Point(611, 471);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "Renunta";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.Location = new System.Drawing.Point(506, 471);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSave.TabIndex = 8;
            this.simpleButtonSave.Text = "Salvare";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // groupControlDetaliiTransfer
            // 
            this.groupControlDetaliiTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlDetaliiTransfer.Controls.Add(this.gridControlDate);
            this.groupControlDetaliiTransfer.Location = new System.Drawing.Point(1, 82);
            this.groupControlDetaliiTransfer.Name = "groupControlDetaliiTransfer";
            this.groupControlDetaliiTransfer.Size = new System.Drawing.Size(697, 383);
            this.groupControlDetaliiTransfer.TabIndex = 1;
            this.groupControlDetaliiTransfer.Text = "Detalii Transfer";
            // 
            // gridControlDate
            // 
            this.gridControlDate.DataSource = this.tblDateDataTableBindingSource;
            this.gridControlDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDate.Location = new System.Drawing.Point(2, 21);
            this.gridControlDate.MainView = this.gridViewDate;
            this.gridControlDate.Name = "gridControlDate";
            this.gridControlDate.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma});
            this.gridControlDate.Size = new System.Drawing.Size(693, 360);
            this.gridControlDate.TabIndex = 0;
            this.gridControlDate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDate});
            // 
            // tblDateDataTableBindingSource
            // 
            this.tblDateDataTableBindingSource.DataSource = typeof(CommonDataSets.GUI.TransferDataSet.tblDateDataTable);
            // 
            // gridViewDate
            // 
            this.gridViewDate.ColumnPanelRowHeight = 30;
            this.gridViewDate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLotBaseID,
            this.colCentruSursaID,
            this.colProduseID,
            this.colCod,
            this.colDenumire,
            this.colPret,
            this.colCantitateDisponibila,
            this.colCantitateTranferata,
            this.colValoareTransferta,
            this.colCantitateRamasa});
            this.gridViewDate.GridControl = this.gridControlDate;
            this.gridViewDate.Name = "gridViewDate";
            this.gridViewDate.OptionsView.ShowGroupPanel = false;
            this.gridViewDate.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewDate_CellValueChanged);
            // 
            // colLotBaseID
            // 
            this.colLotBaseID.AppearanceHeader.Options.UseTextOptions = true;
            this.colLotBaseID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLotBaseID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLotBaseID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLotBaseID.FieldName = "LotBaseID";
            this.colLotBaseID.Name = "colLotBaseID";
            this.colLotBaseID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colCentruSursaID
            // 
            this.colCentruSursaID.AppearanceHeader.Options.UseTextOptions = true;
            this.colCentruSursaID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCentruSursaID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCentruSursaID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCentruSursaID.FieldName = "CentruSursaID";
            this.colCentruSursaID.Name = "colCentruSursaID";
            this.colCentruSursaID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colProduseID
            // 
            this.colProduseID.AppearanceHeader.Options.UseTextOptions = true;
            this.colProduseID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProduseID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProduseID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProduseID.FieldName = "ProduseID";
            this.colProduseID.Name = "colProduseID";
            this.colProduseID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colCod
            // 
            this.colCod.AppearanceHeader.Options.UseTextOptions = true;
            this.colCod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCod.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCod.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCod.Caption = "Cod Produs";
            this.colCod.FieldName = "Cod";
            this.colCod.Name = "colCod";
            this.colCod.OptionsColumn.AllowEdit = false;
            this.colCod.OptionsColumn.ReadOnly = true;
            this.colCod.Visible = true;
            this.colCod.VisibleIndex = 0;
            // 
            // colDenumire
            // 
            this.colDenumire.AppearanceHeader.Options.UseTextOptions = true;
            this.colDenumire.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDenumire.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDenumire.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDenumire.Caption = "Denumire Produs";
            this.colDenumire.FieldName = "Denumire";
            this.colDenumire.Name = "colDenumire";
            this.colDenumire.OptionsColumn.AllowEdit = false;
            this.colDenumire.OptionsColumn.ReadOnly = true;
            this.colDenumire.Visible = true;
            this.colDenumire.VisibleIndex = 1;
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
            this.colPret.Name = "colPret";
            this.colPret.OptionsColumn.AllowEdit = false;
            this.colPret.OptionsColumn.ReadOnly = true;
            this.colPret.Visible = true;
            this.colPret.VisibleIndex = 2;
            // 
            // repositoryItemTextEditSuma
            // 
            this.repositoryItemTextEditSuma.AutoHeight = false;
            this.repositoryItemTextEditSuma.Name = "repositoryItemTextEditSuma";
            // 
            // colCantitateDisponibila
            // 
            this.colCantitateDisponibila.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDisponibila.Caption = "Cantitate Disponibila";
            this.colCantitateDisponibila.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateDisponibila.FieldName = "CantitateDisponibila";
            this.colCantitateDisponibila.Name = "colCantitateDisponibila";
            this.colCantitateDisponibila.OptionsColumn.AllowEdit = false;
            this.colCantitateDisponibila.OptionsColumn.ReadOnly = true;
            this.colCantitateDisponibila.Visible = true;
            this.colCantitateDisponibila.VisibleIndex = 3;
            // 
            // colCantitateTranferata
            // 
            this.colCantitateTranferata.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateTranferata.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateTranferata.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateTranferata.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateTranferata.Caption = "Cantitate transferata";
            this.colCantitateTranferata.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateTranferata.FieldName = "CantitateTranferata";
            this.colCantitateTranferata.Name = "colCantitateTranferata";
            this.colCantitateTranferata.Visible = true;
            this.colCantitateTranferata.VisibleIndex = 4;
            // 
            // colValoareTransferta
            // 
            this.colValoareTransferta.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareTransferta.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareTransferta.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareTransferta.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareTransferta.Caption = "Valoare trasferata";
            this.colValoareTransferta.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareTransferta.FieldName = "ValoareTransferta";
            this.colValoareTransferta.Name = "colValoareTransferta";
            this.colValoareTransferta.OptionsColumn.AllowEdit = false;
            this.colValoareTransferta.OptionsColumn.ReadOnly = true;
            this.colValoareTransferta.Visible = true;
            this.colValoareTransferta.VisibleIndex = 5;
            // 
            // colCantitateRamasa
            // 
            this.colCantitateRamasa.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateRamasa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateRamasa.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateRamasa.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateRamasa.Caption = "Cantitate ramasa";
            this.colCantitateRamasa.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateRamasa.FieldName = "CantitateRamasa";
            this.colCantitateRamasa.Name = "colCantitateRamasa";
            this.colCantitateRamasa.OptionsColumn.AllowEdit = false;
            this.colCantitateRamasa.OptionsColumn.ReadOnly = true;
            this.colCantitateRamasa.Visible = true;
            this.colCantitateRamasa.VisibleIndex = 6;
            // 
            // groupControlDate
            // 
            this.groupControlDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlDate.Controls.Add(this.lookUpEditCentruDestinatie);
            this.groupControlDate.Controls.Add(this.labelControl3);
            this.groupControlDate.Controls.Add(this.lookUpEditCentruSursa);
            this.groupControlDate.Controls.Add(this.labelControlCentruSursa);
            this.groupControlDate.Controls.Add(this.lookUpEditTipCentru);
            this.groupControlDate.Controls.Add(this.labelControlTipCentru);
            this.groupControlDate.Controls.Add(this.lookUpEditLot);
            this.groupControlDate.Controls.Add(this.labelControl2);
            this.groupControlDate.Controls.Add(this.labelControl1);
            this.groupControlDate.Controls.Add(this.ucDatadata);
            this.groupControlDate.Location = new System.Drawing.Point(0, 0);
            this.groupControlDate.Name = "groupControlDate";
            this.groupControlDate.Size = new System.Drawing.Size(697, 83);
            this.groupControlDate.TabIndex = 0;
            this.groupControlDate.Text = "Date";
            // 
            // lookUpEditCentruDestinatie
            // 
            this.lookUpEditCentruDestinatie.Location = new System.Drawing.Point(270, 56);
            this.lookUpEditCentruDestinatie.Name = "lookUpEditCentruDestinatie";
            this.lookUpEditCentruDestinatie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCentruDestinatie.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Denumire")});
            this.lookUpEditCentruDestinatie.Properties.DataSource = this.tblCentruBindingSource;
            this.lookUpEditCentruDestinatie.Properties.DisplayMember = "Denumire";
            this.lookUpEditCentruDestinatie.Properties.NullText = "";
            this.lookUpEditCentruDestinatie.Properties.ValueMember = "ID";
            this.lookUpEditCentruDestinatie.Size = new System.Drawing.Size(157, 20);
            this.lookUpEditCentruDestinatie.TabIndex = 17;
            this.lookUpEditCentruDestinatie.Validated += new System.EventHandler(this.lookUpEditCentruDestinatie_Validated);
            // 
            // tblCentruBindingSource
            // 
            this.tblCentruBindingSource.DataMember = "tblCentru";
            this.tblCentruBindingSource.DataSource = typeof(CommonDataSets.GUI.TransferDataSet);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.Location = new System.Drawing.Point(238, 50);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 26);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "La centru";
            // 
            // lookUpEditCentruSursa
            // 
            this.lookUpEditCentruSursa.Location = new System.Drawing.Point(42, 56);
            this.lookUpEditCentruSursa.Name = "lookUpEditCentruSursa";
            this.lookUpEditCentruSursa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCentruSursa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Denumire")});
            this.lookUpEditCentruSursa.Properties.DataSource = this.tblCentruBindingSource;
            this.lookUpEditCentruSursa.Properties.DisplayMember = "Denumire";
            this.lookUpEditCentruSursa.Properties.NullText = "";
            this.lookUpEditCentruSursa.Properties.ValueMember = "ID";
            this.lookUpEditCentruSursa.Size = new System.Drawing.Size(190, 20);
            this.lookUpEditCentruSursa.TabIndex = 15;
            this.lookUpEditCentruSursa.Validated += new System.EventHandler(this.lookUpEditCentuSursa_Validated);
            // 
            // labelControlCentruSursa
            // 
            this.labelControlCentruSursa.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControlCentruSursa.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControlCentruSursa.Location = new System.Drawing.Point(4, 50);
            this.labelControlCentruSursa.Name = "labelControlCentruSursa";
            this.labelControlCentruSursa.Size = new System.Drawing.Size(32, 26);
            this.labelControlCentruSursa.TabIndex = 14;
            this.labelControlCentruSursa.Text = "De la centru";
            // 
            // lookUpEditTipCentru
            // 
            this.lookUpEditTipCentru.Location = new System.Drawing.Point(502, 26);
            this.lookUpEditTipCentru.Name = "lookUpEditTipCentru";
            this.lookUpEditTipCentru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTipCentru.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Denumire")});
            this.lookUpEditTipCentru.Properties.DataSource = this.tbxTipCentruBindingSource;
            this.lookUpEditTipCentru.Properties.DisplayMember = "Description";
            this.lookUpEditTipCentru.Properties.NullText = "";
            this.lookUpEditTipCentru.Properties.ValueMember = "ID";
            this.lookUpEditTipCentru.Size = new System.Drawing.Size(157, 20);
            this.lookUpEditTipCentru.TabIndex = 13;
            this.lookUpEditTipCentru.Validated += new System.EventHandler(this.lookUpEditTipCentru_Validated);
            // 
            // tbxTipCentruBindingSource
            // 
            this.tbxTipCentruBindingSource.DataMember = "tbxTipCentru";
            this.tbxTipCentruBindingSource.DataSource = typeof(CommonDataSets.GUI.TransferDataSet);
            // 
            // labelControlTipCentru
            // 
            this.labelControlTipCentru.Location = new System.Drawing.Point(446, 29);
            this.labelControlTipCentru.Name = "labelControlTipCentru";
            this.labelControlTipCentru.Size = new System.Drawing.Size(50, 13);
            this.labelControlTipCentru.TabIndex = 12;
            this.labelControlTipCentru.Text = "Tip Centru";
            // 
            // lookUpEditLot
            // 
            this.lookUpEditLot.Location = new System.Drawing.Point(270, 26);
            this.lookUpEditLot.Name = "lookUpEditLot";
            this.lookUpEditLot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditLot.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Denumire")});
            this.lookUpEditLot.Properties.DataSource = this.tblLotBaseDataTableBindingSource;
            this.lookUpEditLot.Properties.DisplayMember = "Denumire";
            this.lookUpEditLot.Properties.NullText = "";
            this.lookUpEditLot.Properties.ValueMember = "ID";
            this.lookUpEditLot.Size = new System.Drawing.Size(157, 20);
            this.lookUpEditLot.TabIndex = 11;
            this.lookUpEditLot.Validated += new System.EventHandler(this.lookUpEditLot_Validated);
            // 
            // tblLotBaseDataTableBindingSource
            // 
            this.tblLotBaseDataTableBindingSource.DataSource = typeof(CommonDataSets.GUI.TransferDataSet.tblLotBaseDataTable);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(238, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(15, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Lot";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Data";
            // 
            // ucDatadata
            // 
            this.ucDatadata.DisplayController = null;
            this.ucDatadata.Location = new System.Drawing.Point(42, 24);
            this.ucDatadata.Name = "ucDatadata";
            this.ucDatadata.ParameterList = null;
            this.ucDatadata.Size = new System.Drawing.Size(201, 25);
            this.ucDatadata.TabIndex = 8;
            this.ucDatadata.UserDateTime = new System.DateTime(1, 1, 1, 11, 58, 28, 0);
            // 
            // Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 506);
            this.Controls.Add(this.panelControl1);
            this.Name = "Transfer";
            this.Text = "Transfer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Transfer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetaliiTransfer)).EndInit();
            this.groupControlDetaliiTransfer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDateDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDate)).EndInit();
            this.groupControlDate.ResumeLayout(false);
            this.groupControlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCentruDestinatie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCentruBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCentruSursa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTipCentru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipCentruBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLotBaseDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControlDetaliiTransfer;
        private DevExpress.XtraEditors.GroupControl groupControlDate;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCentruDestinatie;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCentruSursa;
        private DevExpress.XtraEditors.LabelControl labelControlCentruSursa;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditTipCentru;
        private DevExpress.XtraEditors.LabelControl labelControlTipCentru;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditLot;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private CommonGUIControllers.UC.UCData ucDatadata;
        private System.Windows.Forms.BindingSource tblCentruBindingSource;
        private System.Windows.Forms.BindingSource tbxTipCentruBindingSource;
        private System.Windows.Forms.BindingSource tblLotBaseDataTableBindingSource;
        private System.Windows.Forms.BindingSource tblDateDataTableBindingSource;
        private DevExpress.XtraGrid.GridControl gridControlDate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLotBaseID;
        private DevExpress.XtraGrid.Columns.GridColumn colCentruSursaID;
        private DevExpress.XtraGrid.Columns.GridColumn colProduseID;
        private DevExpress.XtraGrid.Columns.GridColumn colCod;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumire;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDisponibila;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateTranferata;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareTransferta;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateRamasa;
    }
}