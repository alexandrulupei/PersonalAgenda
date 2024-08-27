namespace ComenziGUI
{
    partial class AdaugareReceptie
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
            this.gridControlReceptie = new DevExpress.XtraGrid.GridControl();
            this.tblReceptieHomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewReceptie = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colComandaBaseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDenumire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCantitateRec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateReceptionata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateDisponibila = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareCuTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCotaTVAID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControlDateReceptie = new DevExpress.XtraEditors.GroupControl();
            this.textEditNir = new DevExpress.XtraEditors.TextEdit();
            this.labelControlNrNir = new DevExpress.XtraEditors.LabelControl();
            this.textEditFactura = new DevExpress.XtraEditors.TextEdit();
            this.labelControlNrFactura = new DevExpress.XtraEditors.LabelControl();
            this.ucDataReceptie = new CommonGUIControllers.UC.UCData();
            this.labelControlData = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReceptie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReceptieHomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReceptie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDateReceptie)).BeginInit();
            this.groupControlDateReceptie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFactura.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlReceptie
            // 
            this.gridControlReceptie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlReceptie.DataSource = this.tblReceptieHomeBindingSource;
            this.gridControlReceptie.Location = new System.Drawing.Point(0, 99);
            this.gridControlReceptie.MainView = this.gridViewReceptie;
            this.gridControlReceptie.Name = "gridControlReceptie";
            this.gridControlReceptie.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma});
            this.gridControlReceptie.Size = new System.Drawing.Size(846, 348);
            this.gridControlReceptie.TabIndex = 0;
            this.gridControlReceptie.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewReceptie});
            // 
            // tblReceptieHomeBindingSource
            // 
            this.tblReceptieHomeBindingSource.DataMember = "tblReceptieHome";
            this.tblReceptieHomeBindingSource.DataSource = typeof(CommonDataSets.GUI.ComenziDataSet);
            // 
            // gridViewReceptie
            // 
            this.gridViewReceptie.ColumnPanelRowHeight = 35;
            this.gridViewReceptie.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colComandaBaseID,
            this.colCod,
            this.colDenumire,
            this.colProduseID,
            this.colCantitate,
            this.colCantitateRec,
            this.colCantitateReceptionata,
            this.colCantitateDisponibila,
            this.colPret,
            this.colValoare,
            this.colValoareTVA,
            this.colValoareCuTVA,
            this.colCotaTVAID});
            this.gridViewReceptie.GridControl = this.gridControlReceptie;
            this.gridViewReceptie.Name = "gridViewReceptie";
            this.gridViewReceptie.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewReceptie_CellValueChanged);
            // 
            // colComandaBaseID
            // 
            this.colComandaBaseID.FieldName = "ComandaBaseID";
            this.colComandaBaseID.Name = "colComandaBaseID";
            this.colComandaBaseID.OptionsColumn.AllowEdit = false;
            this.colComandaBaseID.OptionsColumn.FixedWidth = true;
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
            this.colCod.OptionsColumn.FixedWidth = true;
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
            this.colDenumire.OptionsColumn.FixedWidth = true;
            this.colDenumire.Visible = true;
            this.colDenumire.VisibleIndex = 1;
            // 
            // colProduseID
            // 
            this.colProduseID.AppearanceHeader.Options.UseTextOptions = true;
            this.colProduseID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProduseID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProduseID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProduseID.FieldName = "ProduseID";
            this.colProduseID.Name = "colProduseID";
            this.colProduseID.OptionsColumn.AllowEdit = false;
            this.colProduseID.OptionsColumn.FixedWidth = true;
            // 
            // colCantitate
            // 
            this.colCantitate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitate.Caption = "Cantitate comanda";
            this.colCantitate.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitate.FieldName = "Cantitate";
            this.colCantitate.Name = "colCantitate";
            this.colCantitate.OptionsColumn.AllowEdit = false;
            this.colCantitate.OptionsColumn.FixedWidth = true;
            this.colCantitate.OptionsColumn.ReadOnly = true;
            this.colCantitate.Visible = true;
            this.colCantitate.VisibleIndex = 2;
            // 
            // repositoryItemTextEditSuma
            // 
            this.repositoryItemTextEditSuma.AutoHeight = false;
            this.repositoryItemTextEditSuma.Name = "repositoryItemTextEditSuma";
            // 
            // colCantitateRec
            // 
            this.colCantitateRec.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateRec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateRec.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateRec.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateRec.Caption = "Cantitate receptie";
            this.colCantitateRec.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateRec.FieldName = "CantitateRec";
            this.colCantitateRec.Name = "colCantitateRec";
            this.colCantitateRec.Visible = true;
            this.colCantitateRec.VisibleIndex = 3;
            this.colCantitateRec.Width = 109;
            // 
            // colCantitateReceptionata
            // 
            this.colCantitateReceptionata.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateReceptionata.Caption = "Total receptii";
            this.colCantitateReceptionata.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateReceptionata.FieldName = "CantitateReceptionata";
            this.colCantitateReceptionata.Name = "colCantitateReceptionata";
            this.colCantitateReceptionata.OptionsColumn.AllowEdit = false;
            this.colCantitateReceptionata.OptionsColumn.FixedWidth = true;
            this.colCantitateReceptionata.OptionsColumn.ReadOnly = true;
            this.colCantitateReceptionata.Visible = true;
            this.colCantitateReceptionata.VisibleIndex = 4;
            // 
            // colCantitateDisponibila
            // 
            this.colCantitateDisponibila.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDisponibila.Caption = "Cantitate disponibila";
            this.colCantitateDisponibila.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateDisponibila.FieldName = "CantitateDisponibila";
            this.colCantitateDisponibila.Name = "colCantitateDisponibila";
            this.colCantitateDisponibila.OptionsColumn.AllowEdit = false;
            this.colCantitateDisponibila.OptionsColumn.FixedWidth = true;
            this.colCantitateDisponibila.OptionsColumn.ReadOnly = true;
            this.colCantitateDisponibila.Visible = true;
            this.colCantitateDisponibila.VisibleIndex = 5;
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
            this.colPret.OptionsColumn.FixedWidth = true;
            this.colPret.Visible = true;
            this.colPret.VisibleIndex = 6;
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
            this.colValoare.OptionsColumn.FixedWidth = true;
            this.colValoare.OptionsColumn.ReadOnly = true;
            this.colValoare.Visible = true;
            this.colValoare.VisibleIndex = 7;
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
            this.colValoareTVA.OptionsColumn.FixedWidth = true;
            this.colValoareTVA.OptionsColumn.ReadOnly = true;
            this.colValoareTVA.Visible = true;
            this.colValoareTVA.VisibleIndex = 8;
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
            this.colValoareCuTVA.OptionsColumn.FixedWidth = true;
            this.colValoareCuTVA.OptionsColumn.ReadOnly = true;
            this.colValoareCuTVA.Visible = true;
            this.colValoareCuTVA.VisibleIndex = 9;
            // 
            // colCotaTVAID
            // 
            this.colCotaTVAID.Caption = "CotaTVA";
            this.colCotaTVAID.FieldName = "CotaTVAID";
            this.colCotaTVAID.Name = "colCotaTVAID";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControlDateReceptie);
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Controls.Add(this.simpleButtonSave);
            this.panelControl1.Controls.Add(this.gridControlReceptie);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(851, 502);
            this.panelControl1.TabIndex = 1;
            // 
            // groupControlDateReceptie
            // 
            this.groupControlDateReceptie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlDateReceptie.Controls.Add(this.textEditNir);
            this.groupControlDateReceptie.Controls.Add(this.labelControlNrNir);
            this.groupControlDateReceptie.Controls.Add(this.textEditFactura);
            this.groupControlDateReceptie.Controls.Add(this.labelControlNrFactura);
            this.groupControlDateReceptie.Controls.Add(this.ucDataReceptie);
            this.groupControlDateReceptie.Controls.Add(this.labelControlData);
            this.groupControlDateReceptie.Location = new System.Drawing.Point(1, 1);
            this.groupControlDateReceptie.Name = "groupControlDateReceptie";
            this.groupControlDateReceptie.Size = new System.Drawing.Size(850, 92);
            this.groupControlDateReceptie.TabIndex = 10;
            this.groupControlDateReceptie.Text = "Date Receptie";
            // 
            // textEditNir
            // 
            this.textEditNir.Location = new System.Drawing.Point(587, 41);
            this.textEditNir.Name = "textEditNir";
            this.textEditNir.Size = new System.Drawing.Size(100, 20);
            this.textEditNir.TabIndex = 5;
            // 
            // labelControlNrNir
            // 
            this.labelControlNrNir.Location = new System.Drawing.Point(533, 44);
            this.labelControlNrNir.Name = "labelControlNrNir";
            this.labelControlNrNir.Size = new System.Drawing.Size(47, 13);
            this.labelControlNrNir.TabIndex = 4;
            this.labelControlNrNir.Text = "Numar Nir";
            // 
            // textEditFactura
            // 
            this.textEditFactura.Location = new System.Drawing.Point(410, 41);
            this.textEditFactura.Name = "textEditFactura";
            this.textEditFactura.Size = new System.Drawing.Size(100, 20);
            this.textEditFactura.TabIndex = 3;
            // 
            // labelControlNrFactura
            // 
            this.labelControlNrFactura.Location = new System.Drawing.Point(317, 44);
            this.labelControlNrFactura.Name = "labelControlNrFactura";
            this.labelControlNrFactura.Size = new System.Drawing.Size(71, 13);
            this.labelControlNrFactura.TabIndex = 2;
            this.labelControlNrFactura.Text = "Numar Factura";
            // 
            // ucDataReceptie
            // 
            this.ucDataReceptie.DisplayController = null;
            this.ucDataReceptie.Location = new System.Drawing.Point(86, 37);
            this.ucDataReceptie.Name = "ucDataReceptie";
            this.ucDataReceptie.ParameterList = null;
            this.ucDataReceptie.Size = new System.Drawing.Size(193, 25);
            this.ucDataReceptie.TabIndex = 1;
            this.ucDataReceptie.UserDateTime = new System.DateTime(1, 1, 1, 9, 54, 51, 0);
            // 
            // labelControlData
            // 
            this.labelControlData.Location = new System.Drawing.Point(12, 44);
            this.labelControlData.Name = "labelControlData";
            this.labelControlData.Size = new System.Drawing.Size(68, 13);
            this.labelControlData.TabIndex = 0;
            this.labelControlData.Text = "Data Receptie";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Location = new System.Drawing.Point(725, 467);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "Renunta";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.Location = new System.Drawing.Point(620, 467);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSave.TabIndex = 8;
            this.simpleButtonSave.Text = "Salvare";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // AdaugareReceptie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 502);
            this.Controls.Add(this.panelControl1);
            this.Name = "AdaugareReceptie";
            this.Text = "AdaugareReceptie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdaugareReceptie_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReceptie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReceptieHomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReceptie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDateReceptie)).EndInit();
            this.groupControlDateReceptie.ResumeLayout(false);
            this.groupControlDateReceptie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFactura.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlReceptie;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewReceptie;
        private System.Windows.Forms.BindingSource tblReceptieHomeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colComandaBaseID;
        private DevExpress.XtraGrid.Columns.GridColumn colCod;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumire;
        private DevExpress.XtraGrid.Columns.GridColumn colProduseID;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateRec;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateReceptionata;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDisponibila;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraGrid.Columns.GridColumn colValoare;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareCuTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colCotaTVAID;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.GroupControl groupControlDateReceptie;
        private DevExpress.XtraEditors.TextEdit textEditNir;
        private DevExpress.XtraEditors.LabelControl labelControlNrNir;
        private DevExpress.XtraEditors.TextEdit textEditFactura;
        private DevExpress.XtraEditors.LabelControl labelControlNrFactura;
        private CommonGUIControllers.UC.UCData ucDataReceptie;
        private DevExpress.XtraEditors.LabelControl labelControlData;
    }
}