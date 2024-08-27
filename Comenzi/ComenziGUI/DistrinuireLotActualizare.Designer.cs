namespace ComenziGUI
{
    partial class DistrinuireLotActualizare
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
            this.groupControlDetalii = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDistibuie = new DevExpress.XtraGrid.GridControl();
            this.tblDistribuireLotDetaliiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewDistribuie = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDistribuireLotID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDenumire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateTotala = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareCuTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateDistribuita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateRamasa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlDate = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditCentru = new DevExpress.XtraEditors.LookUpEdit();
            this.tblCentruBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUpEditLot = new DevExpress.XtraEditors.LookUpEdit();
            this.tblLotBaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ucDatadata = new CommonGUIControllers.UC.UCData();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetalii)).BeginInit();
            this.groupControlDetalii.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDistibuie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDistribuireLotDetaliiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDistribuie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDate)).BeginInit();
            this.groupControlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCentru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCentruBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLotBaseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Controls.Add(this.simpleButtonSave);
            this.panelControl1.Controls.Add(this.groupControlDetalii);
            this.panelControl1.Controls.Add(this.groupControlDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(841, 470);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Location = new System.Drawing.Point(723, 435);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 3;
            this.simpleButtonCancel.Text = "Renunta";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.Location = new System.Drawing.Point(618, 435);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSave.TabIndex = 2;
            this.simpleButtonSave.Text = "Salvare";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // groupControlDetalii
            // 
            this.groupControlDetalii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlDetalii.Controls.Add(this.gridControlDistibuie);
            this.groupControlDetalii.Location = new System.Drawing.Point(0, 85);
            this.groupControlDetalii.Name = "groupControlDetalii";
            this.groupControlDetalii.Size = new System.Drawing.Size(836, 338);
            this.groupControlDetalii.TabIndex = 1;
            this.groupControlDetalii.Text = "Detalii";
            // 
            // gridControlDistibuie
            // 
            this.gridControlDistibuie.DataSource = this.tblDistribuireLotDetaliiBindingSource;
            this.gridControlDistibuie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDistibuie.Location = new System.Drawing.Point(2, 21);
            this.gridControlDistibuie.MainView = this.gridViewDistribuie;
            this.gridControlDistibuie.Name = "gridControlDistibuie";
            this.gridControlDistibuie.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma});
            this.gridControlDistibuie.Size = new System.Drawing.Size(832, 315);
            this.gridControlDistibuie.TabIndex = 0;
            this.gridControlDistibuie.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDistribuie});
            // 
            // tblDistribuireLotDetaliiBindingSource
            // 
            this.tblDistribuireLotDetaliiBindingSource.DataMember = "tblDistribuireLotDetalii";
            this.tblDistribuireLotDetaliiBindingSource.DataSource = typeof(CommonDataSets.GUI.DistribuireDataSet);
            // 
            // gridViewDistribuie
            // 
            this.gridViewDistribuie.ColumnPanelRowHeight = 35;
            this.gridViewDistribuie.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colDistribuireLotID,
            this.colCod,
            this.colDenumire,
            this.colCantitateTotala,
            this.colPret,
            this.colValoare,
            this.colValoareTVA,
            this.colValoareCuTVA,
            this.colCantitateDistribuita,
            this.colCantitateRamasa});
            this.gridViewDistribuie.GridControl = this.gridControlDistibuie;
            this.gridViewDistribuie.Name = "gridViewDistribuie";
            this.gridViewDistribuie.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewDistribuie_CellValueChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.ReadOnly = true;
            // 
            // colDistribuireLotID
            // 
            this.colDistribuireLotID.FieldName = "DistribuireLotID";
            this.colDistribuireLotID.Name = "colDistribuireLotID";
            this.colDistribuireLotID.OptionsColumn.AllowEdit = false;
            this.colDistribuireLotID.OptionsColumn.ReadOnly = true;
            // 
            // colCod
            // 
            this.colCod.AppearanceHeader.Options.UseTextOptions = true;
            this.colCod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCod.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCod.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
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
            this.colDenumire.FieldName = "Denumire";
            this.colDenumire.Name = "colDenumire";
            this.colDenumire.OptionsColumn.AllowEdit = false;
            this.colDenumire.OptionsColumn.ReadOnly = true;
            this.colDenumire.Visible = true;
            this.colDenumire.VisibleIndex = 1;
            // 
            // colCantitateTotala
            // 
            this.colCantitateTotala.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateTotala.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateTotala.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateTotala.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateTotala.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateTotala.FieldName = "CantitateTotala";
            this.colCantitateTotala.Name = "colCantitateTotala";
            this.colCantitateTotala.OptionsColumn.AllowEdit = false;
            this.colCantitateTotala.OptionsColumn.ReadOnly = true;
            this.colCantitateTotala.Visible = true;
            this.colCantitateTotala.VisibleIndex = 2;
            // 
            // repositoryItemTextEditSuma
            // 
            this.repositoryItemTextEditSuma.AutoHeight = false;
            this.repositoryItemTextEditSuma.Name = "repositoryItemTextEditSuma";
            // 
            // colPret
            // 
            this.colPret.AppearanceHeader.Options.UseTextOptions = true;
            this.colPret.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPret.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colPret.FieldName = "Pret";
            this.colPret.Name = "colPret";
            this.colPret.OptionsColumn.AllowEdit = false;
            this.colPret.OptionsColumn.ReadOnly = true;
            this.colPret.Visible = true;
            this.colPret.VisibleIndex = 3;
            // 
            // colValoare
            // 
            this.colValoare.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoare.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoare.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoare.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoare.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoare.FieldName = "Valoare";
            this.colValoare.Name = "colValoare";
            this.colValoare.OptionsColumn.AllowEdit = false;
            this.colValoare.OptionsColumn.ReadOnly = true;
            this.colValoare.Visible = true;
            this.colValoare.VisibleIndex = 4;
            // 
            // colValoareTVA
            // 
            this.colValoareTVA.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareTVA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareTVA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareTVA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareTVA.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareTVA.FieldName = "ValoareTVA";
            this.colValoareTVA.Name = "colValoareTVA";
            this.colValoareTVA.OptionsColumn.AllowEdit = false;
            this.colValoareTVA.OptionsColumn.ReadOnly = true;
            this.colValoareTVA.Visible = true;
            this.colValoareTVA.VisibleIndex = 5;
            // 
            // colValoareCuTVA
            // 
            this.colValoareCuTVA.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareCuTVA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareCuTVA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareCuTVA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareCuTVA.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareCuTVA.FieldName = "ValoareCuTVA";
            this.colValoareCuTVA.Name = "colValoareCuTVA";
            this.colValoareCuTVA.OptionsColumn.AllowEdit = false;
            this.colValoareCuTVA.OptionsColumn.ReadOnly = true;
            this.colValoareCuTVA.Visible = true;
            this.colValoareCuTVA.VisibleIndex = 6;
            // 
            // colCantitateDistribuita
            // 
            this.colCantitateDistribuita.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDistribuita.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateDistribuita.FieldName = "CantitateDistribuita";
            this.colCantitateDistribuita.Name = "colCantitateDistribuita";
            this.colCantitateDistribuita.Visible = true;
            this.colCantitateDistribuita.VisibleIndex = 7;
            // 
            // colCantitateRamasa
            // 
            this.colCantitateRamasa.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateRamasa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateRamasa.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateRamasa.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateRamasa.Caption = "Cantitate Ramasa";
            this.colCantitateRamasa.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateRamasa.FieldName = "CantitateRamasa";
            this.colCantitateRamasa.Name = "colCantitateRamasa";
            this.colCantitateRamasa.OptionsColumn.AllowEdit = false;
            this.colCantitateRamasa.OptionsColumn.ReadOnly = true;
            this.colCantitateRamasa.Visible = true;
            this.colCantitateRamasa.VisibleIndex = 8;
            // 
            // groupControlDate
            // 
            this.groupControlDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlDate.Controls.Add(this.label1);
            this.groupControlDate.Controls.Add(this.lookUpEditCentru);
            this.groupControlDate.Controls.Add(this.lookUpEditLot);
            this.groupControlDate.Controls.Add(this.labelControl2);
            this.groupControlDate.Controls.Add(this.labelControl1);
            this.groupControlDate.Controls.Add(this.ucDatadata);
            this.groupControlDate.Location = new System.Drawing.Point(0, 0);
            this.groupControlDate.Name = "groupControlDate";
            this.groupControlDate.Size = new System.Drawing.Size(836, 78);
            this.groupControlDate.TabIndex = 0;
            this.groupControlDate.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Centru";
            // 
            // lookUpEditCentru
            // 
            this.lookUpEditCentru.Location = new System.Drawing.Point(574, 39);
            this.lookUpEditCentru.Name = "lookUpEditCentru";
            this.lookUpEditCentru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCentru.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Cod", "Cod"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Denumire"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TipCentru", "Tip Centru")});
            this.lookUpEditCentru.Properties.DataSource = this.tblCentruBindingSource;
            this.lookUpEditCentru.Properties.DisplayMember = "Cod";
            this.lookUpEditCentru.Properties.NullText = "";
            this.lookUpEditCentru.Properties.ValueMember = "ID";
            this.lookUpEditCentru.Size = new System.Drawing.Size(192, 20);
            this.lookUpEditCentru.TabIndex = 4;
            this.lookUpEditCentru.Validated += new System.EventHandler(this.lookUpEditCentru_Validated);
            // 
            // tblCentruBindingSource
            // 
            this.tblCentruBindingSource.DataMember = "tblCentru";
            this.tblCentruBindingSource.DataSource = typeof(CommonDataSets.GUI.DistribuireDataSet);
            // 
            // lookUpEditLot
            // 
            this.lookUpEditLot.Location = new System.Drawing.Point(304, 39);
            this.lookUpEditLot.Name = "lookUpEditLot";
            this.lookUpEditLot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditLot.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Denumire")});
            this.lookUpEditLot.Properties.DataSource = this.tblLotBaseBindingSource;
            this.lookUpEditLot.Properties.DisplayMember = "Denumire";
            this.lookUpEditLot.Properties.NullText = "";
            this.lookUpEditLot.Properties.ValueMember = "ID";
            this.lookUpEditLot.Size = new System.Drawing.Size(157, 20);
            this.lookUpEditLot.TabIndex = 3;
            this.lookUpEditLot.Validated += new System.EventHandler(this.lookUpEditLot_Validated);
            // 
            // tblLotBaseBindingSource
            // 
            this.tblLotBaseBindingSource.DataMember = "tblLotBase";
            this.tblLotBaseBindingSource.DataSource = typeof(CommonDataSets.GUI.DistribuireDataSet);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(271, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(15, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Lot";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Data";
            // 
            // ucDatadata
            // 
            this.ucDatadata.DisplayController = null;
            this.ucDatadata.Location = new System.Drawing.Point(51, 34);
            this.ucDatadata.Name = "ucDatadata";
            this.ucDatadata.ParameterList = null;
            this.ucDatadata.Size = new System.Drawing.Size(201, 25);
            this.ucDatadata.TabIndex = 0;
            this.ucDatadata.UserDateTime = new System.DateTime(1, 1, 1, 12, 32, 52, 0);
            // 
            // DistrinuireLotActualizare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 470);
            this.Controls.Add(this.panelControl1);
            this.Name = "DistrinuireLotActualizare";
            this.Text = "Distribuire Lot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DistrinuireLotActualizare_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetalii)).EndInit();
            this.groupControlDetalii.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDistibuie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDistribuireLotDetaliiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDistribuie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDate)).EndInit();
            this.groupControlDate.ResumeLayout(false);
            this.groupControlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCentru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCentruBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLotBaseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.GroupControl groupControlDetalii;
        private DevExpress.XtraEditors.GroupControl groupControlDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCentru;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditLot;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private CommonGUIControllers.UC.UCData ucDatadata;
        private System.Windows.Forms.BindingSource tblLotBaseBindingSource;
        private DevExpress.XtraGrid.GridControl gridControlDistibuie;
        private System.Windows.Forms.BindingSource tblDistribuireLotDetaliiBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDistribuie;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colDistribuireLotID;
        private DevExpress.XtraGrid.Columns.GridColumn colCod;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumire;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateTotala;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraGrid.Columns.GridColumn colValoare;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareCuTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDistribuita;
        private System.Windows.Forms.BindingSource tblCentruBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateRamasa;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
    }
}