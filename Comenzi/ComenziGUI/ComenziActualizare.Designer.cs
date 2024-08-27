namespace ComenziGUI
{
    partial class ComenziActualizare
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlDetalii = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetalii = new DevExpress.XtraGrid.GridControl();
            this.tblDetaliiComandaBindingSource = new System.Windows.Forms.BindingSource();
            this.gridViewDetalii = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodProdus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDenumire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCantitateComandata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateDisponibila = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareCuTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCotaTVAID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlDate = new DevExpress.XtraEditors.GroupControl();
            this.lookUpEditLot = new DevExpress.XtraEditors.LookUpEdit();
            this.tblLotBaseBindingSource = new System.Windows.Forms.BindingSource();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ucDatadata = new CommonGUIControllers.UC.UCData();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetalii)).BeginInit();
            this.groupControlDetalii.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetalii)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDetaliiComandaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetalii)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDate)).BeginInit();
            this.groupControlDate.SuspendLayout();
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
            this.panelControl1.Size = new System.Drawing.Size(842, 464);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Location = new System.Drawing.Point(726, 425);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 7;
            this.simpleButtonCancel.Text = "Renunta";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.Location = new System.Drawing.Point(621, 425);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSave.TabIndex = 6;
            this.simpleButtonSave.Text = "Salvare";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // groupControlDetalii
            // 
            this.groupControlDetalii.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlDetalii.Controls.Add(this.gridControlDetalii);
            this.groupControlDetalii.Location = new System.Drawing.Point(3, 81);
            this.groupControlDetalii.Name = "groupControlDetalii";
            this.groupControlDetalii.Size = new System.Drawing.Size(836, 338);
            this.groupControlDetalii.TabIndex = 5;
            this.groupControlDetalii.Text = "Detalii";
            // 
            // gridControlDetalii
            // 
            this.gridControlDetalii.DataSource = this.tblDetaliiComandaBindingSource;
            this.gridControlDetalii.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDetalii.Location = new System.Drawing.Point(2, 21);
            this.gridControlDetalii.MainView = this.gridViewDetalii;
            this.gridControlDetalii.Name = "gridControlDetalii";
            this.gridControlDetalii.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma});
            this.gridControlDetalii.Size = new System.Drawing.Size(832, 315);
            this.gridControlDetalii.TabIndex = 0;
            this.gridControlDetalii.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetalii});
            // 
            // tblDetaliiComandaBindingSource
            // 
            this.tblDetaliiComandaBindingSource.DataMember = "tblDetaliiComanda";
            this.tblDetaliiComandaBindingSource.DataSource = typeof(CommonDataSets.GUI.ComenziDataSet);
            // 
            // gridViewDetalii
            // 
            this.gridViewDetalii.ColumnPanelRowHeight = 35;
            this.gridViewDetalii.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colLotID,
            this.colCodProdus,
            this.colDenumire,
            this.colCantitate,
            this.colCantitateComandata,
            this.colCantitateDisponibila,
            this.colPret,
            this.colProduseID,
            this.colValoare,
            this.colValoareTVA,
            this.colValoareCuTVA,
            this.colCotaTVAID});
            this.gridViewDetalii.GridControl = this.gridControlDetalii;
            this.gridViewDetalii.Name = "gridViewDetalii";
            this.gridViewDetalii.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewDetalii_CellValueChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            // 
            // colLotID
            // 
            this.colLotID.FieldName = "LotID";
            this.colLotID.Name = "colLotID";
            // 
            // colCodProdus
            // 
            this.colCodProdus.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodProdus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodProdus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCodProdus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodProdus.FieldName = "CodProdus";
            this.colCodProdus.Name = "colCodProdus";
            this.colCodProdus.OptionsColumn.AllowEdit = false;
            this.colCodProdus.OptionsColumn.ReadOnly = true;
            this.colCodProdus.Visible = true;
            this.colCodProdus.VisibleIndex = 0;
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
            // colCantitate
            // 
            this.colCantitate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitate.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitate.FieldName = "Cantitate";
            this.colCantitate.Name = "colCantitate";
            this.colCantitate.OptionsColumn.AllowEdit = false;
            this.colCantitate.OptionsColumn.ReadOnly = true;
            this.colCantitate.Visible = true;
            this.colCantitate.VisibleIndex = 2;
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
            this.colCantitateComandata.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateComandata.FieldName = "CantitateComandata";
            this.colCantitateComandata.Name = "colCantitateComandata";
            this.colCantitateComandata.Visible = true;
            this.colCantitateComandata.VisibleIndex = 3;
            // 
            // colCantitateDisponibila
            // 
            this.colCantitateDisponibila.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDisponibila.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateDisponibila.FieldName = "CantitateDisponibila";
            this.colCantitateDisponibila.Name = "colCantitateDisponibila";
            this.colCantitateDisponibila.OptionsColumn.AllowEdit = false;
            this.colCantitateDisponibila.OptionsColumn.ReadOnly = true;
            this.colCantitateDisponibila.Visible = true;
            this.colCantitateDisponibila.VisibleIndex = 4;
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
            this.colPret.VisibleIndex = 5;
            // 
            // colProduseID
            // 
            this.colProduseID.AppearanceHeader.Options.UseTextOptions = true;
            this.colProduseID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProduseID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProduseID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProduseID.FieldName = "ProduseID";
            this.colProduseID.Name = "colProduseID";
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
            this.colValoare.VisibleIndex = 6;
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
            this.colValoareTVA.VisibleIndex = 7;
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
            this.colValoareCuTVA.VisibleIndex = 8;
            // 
            // colCotaTVAID
            // 
            this.colCotaTVAID.AppearanceHeader.Options.UseTextOptions = true;
            this.colCotaTVAID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCotaTVAID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCotaTVAID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCotaTVAID.Caption = "CotaTVA";
            this.colCotaTVAID.FieldName = "CotaTVAID";
            this.colCotaTVAID.Name = "colCotaTVAID";
            // 
            // groupControlDate
            // 
            this.groupControlDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlDate.Controls.Add(this.lookUpEditLot);
            this.groupControlDate.Controls.Add(this.labelControl2);
            this.groupControlDate.Controls.Add(this.labelControl1);
            this.groupControlDate.Controls.Add(this.ucDatadata);
            this.groupControlDate.Location = new System.Drawing.Point(3, 0);
            this.groupControlDate.Name = "groupControlDate";
            this.groupControlDate.Size = new System.Drawing.Size(836, 78);
            this.groupControlDate.TabIndex = 4;
            this.groupControlDate.Text = "Date";
            // 
            // lookUpEditLot
            // 
            this.lookUpEditLot.Location = new System.Drawing.Point(298, 39);
            this.lookUpEditLot.Name = "lookUpEditLot";
            this.lookUpEditLot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditLot.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Denumire", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditLot.Properties.DataSource = this.tblLotBaseBindingSource;
            this.lookUpEditLot.Properties.DisplayMember = "Denumire";
            this.lookUpEditLot.Properties.NullText = "";
            this.lookUpEditLot.Properties.ValueMember = "ID";
            this.lookUpEditLot.Size = new System.Drawing.Size(157, 20);
            this.lookUpEditLot.TabIndex = 7;
            this.lookUpEditLot.Validated += new System.EventHandler(this.lookUpEditLot_Validated);
            // 
            // tblLotBaseBindingSource
            // 
            this.tblLotBaseBindingSource.DataMember = "tblLotBase";
            this.tblLotBaseBindingSource.DataSource = typeof(CommonDataSets.GUI.ComenziDataSet);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(265, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(15, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Lot";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Data";
            // 
            // ucDatadata
            // 
            this.ucDatadata.DisplayController = null;
            this.ucDatadata.Location = new System.Drawing.Point(45, 34);
            this.ucDatadata.Name = "ucDatadata";
            this.ucDatadata.ParameterList = null;
            this.ucDatadata.Size = new System.Drawing.Size(201, 25);
            this.ucDatadata.TabIndex = 4;
            this.ucDatadata.UserDateTime = new System.DateTime(1, 1, 1, 14, 5, 54, 0);
            this.ucDatadata.DateTimeChanged += new CommonGUIControllers.UC.UCData.UCDataUserDateTimeChanged(this.ucDatadata_DateTimeChanged);
            // 
            // ComenziActualizare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 464);
            this.Controls.Add(this.panelControl1);
            this.Name = "ComenziActualizare";
            this.Text = "ComenziActualizare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComenziActualizare_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetalii)).EndInit();
            this.groupControlDetalii.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetalii)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDetaliiComandaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetalii)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDate)).EndInit();
            this.groupControlDate.ResumeLayout(false);
            this.groupControlDate.PerformLayout();
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
        private DevExpress.XtraGrid.GridControl gridControlDetalii;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetalii;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditLot;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private CommonGUIControllers.UC.UCData ucDatadata;
        private System.Windows.Forms.BindingSource tblDetaliiComandaBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colLotID;
        private DevExpress.XtraGrid.Columns.GridColumn colCodProdus;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumire;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitate;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateComandata;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDisponibila;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraGrid.Columns.GridColumn colProduseID;
        private DevExpress.XtraGrid.Columns.GridColumn colValoare;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareCuTVA;
        private System.Windows.Forms.BindingSource tblLotBaseBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCotaTVAID;
    }
}