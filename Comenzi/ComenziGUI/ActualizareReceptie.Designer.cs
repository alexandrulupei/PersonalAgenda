namespace ComenziGUI
{
    partial class ActualizareReceptie
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
            this.simpleButtonRenunta = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSalvare = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlReceptie = new DevExpress.XtraGrid.GridControl();
            this.gridViewReceptie = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumarFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumarNir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataReceptie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEditData = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colComandaBaseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditListeaza = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReceptie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReceptie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditListeaza)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonRenunta);
            this.panelControl1.Controls.Add(this.simpleButtonSalvare);
            this.panelControl1.Controls.Add(this.gridControlReceptie);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(549, 358);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonRenunta
            // 
            this.simpleButtonRenunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonRenunta.Location = new System.Drawing.Point(469, 323);
            this.simpleButtonRenunta.Name = "simpleButtonRenunta";
            this.simpleButtonRenunta.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonRenunta.TabIndex = 4;
            this.simpleButtonRenunta.Text = "Renunta";
            this.simpleButtonRenunta.Click += new System.EventHandler(this.simpleButtonRenunta_Click);
            // 
            // simpleButtonSalvare
            // 
            this.simpleButtonSalvare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSalvare.Location = new System.Drawing.Point(388, 323);
            this.simpleButtonSalvare.Name = "simpleButtonSalvare";
            this.simpleButtonSalvare.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSalvare.TabIndex = 3;
            this.simpleButtonSalvare.Text = "Salvare";
            this.simpleButtonSalvare.Click += new System.EventHandler(this.simpleButtonSalvare_Click);
            // 
            // gridControlReceptie
            // 
            this.gridControlReceptie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlReceptie.Location = new System.Drawing.Point(0, 0);
            this.gridControlReceptie.MainView = this.gridViewReceptie;
            this.gridControlReceptie.Name = "gridControlReceptie";
            this.gridControlReceptie.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditListeaza,
            this.repositoryItemDateEditData});
            this.gridControlReceptie.Size = new System.Drawing.Size(549, 317);
            this.gridControlReceptie.TabIndex = 1;
            this.gridControlReceptie.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewReceptie});
            // 
            // gridViewReceptie
            // 
            this.gridViewReceptie.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colNumarFactura,
            this.colNumarNir,
            this.colDataReceptie,
            this.colComandaBaseID,
            this.colListare});
            this.gridViewReceptie.GridControl = this.gridControlReceptie;
            this.gridViewReceptie.Name = "gridViewReceptie";
            this.gridViewReceptie.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewReceptie_CellValueChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colNumarFactura
            // 
            this.colNumarFactura.Caption = "Numar Factura";
            this.colNumarFactura.FieldName = "NumarFactura";
            this.colNumarFactura.Name = "colNumarFactura";
            this.colNumarFactura.Visible = true;
            this.colNumarFactura.VisibleIndex = 1;
            // 
            // colNumarNir
            // 
            this.colNumarNir.Caption = "Numar Nir";
            this.colNumarNir.FieldName = "NumarNir";
            this.colNumarNir.Name = "colNumarNir";
            this.colNumarNir.Visible = true;
            this.colNumarNir.VisibleIndex = 2;
            // 
            // colDataReceptie
            // 
            this.colDataReceptie.Caption = "Data Receptie";
            this.colDataReceptie.ColumnEdit = this.repositoryItemDateEditData;
            this.colDataReceptie.FieldName = "DataReceptie";
            this.colDataReceptie.Name = "colDataReceptie";
            this.colDataReceptie.OptionsColumn.AllowEdit = false;
            this.colDataReceptie.OptionsColumn.ReadOnly = true;
            this.colDataReceptie.Visible = true;
            this.colDataReceptie.VisibleIndex = 3;
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
            // colComandaBaseID
            // 
            this.colComandaBaseID.FieldName = "ComandaBaseID";
            this.colComandaBaseID.Name = "colComandaBaseID";
            this.colComandaBaseID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colListare
            // 
            this.colListare.Caption = "Selectat";
            this.colListare.ColumnEdit = this.repositoryItemCheckEditListeaza;
            this.colListare.FieldName = "Selectat";
            this.colListare.Name = "colListare";
            this.colListare.Visible = true;
            this.colListare.VisibleIndex = 0;
            // 
            // repositoryItemCheckEditListeaza
            // 
            this.repositoryItemCheckEditListeaza.AutoHeight = false;
            this.repositoryItemCheckEditListeaza.Name = "repositoryItemCheckEditListeaza";
            // 
            // ActualizareReceptie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 358);
            this.Controls.Add(this.panelControl1);
            this.Name = "ActualizareReceptie";
            this.Text = "ActualizareReceptie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActualizareReceptie_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReceptie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReceptie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditListeaza)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlReceptie;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewReceptie;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNumarFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colNumarNir;
        private DevExpress.XtraGrid.Columns.GridColumn colDataReceptie;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditData;
        private DevExpress.XtraGrid.Columns.GridColumn colComandaBaseID;
        private DevExpress.XtraGrid.Columns.GridColumn colListare;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditListeaza;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRenunta;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSalvare;
    }
}