namespace ComenziGUI
{
    partial class NirFiltre
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
            this.simpleButtonRenunta = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonListare = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlNir = new DevExpress.XtraGrid.GridControl();
            this.tblReceptieComandaBaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewNir = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReceptieComandaBaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditListeaza)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonRenunta);
            this.panelControl1.Controls.Add(this.simpleButtonListare);
            this.panelControl1.Controls.Add(this.gridControlNir);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(478, 337);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonRenunta
            // 
            this.simpleButtonRenunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonRenunta.Location = new System.Drawing.Point(391, 302);
            this.simpleButtonRenunta.Name = "simpleButtonRenunta";
            this.simpleButtonRenunta.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonRenunta.TabIndex = 2;
            this.simpleButtonRenunta.Text = "Renunta";
            this.simpleButtonRenunta.Click += new System.EventHandler(this.simpleButtonRenunta_Click);
            // 
            // simpleButtonListare
            // 
            this.simpleButtonListare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonListare.Location = new System.Drawing.Point(310, 302);
            this.simpleButtonListare.Name = "simpleButtonListare";
            this.simpleButtonListare.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonListare.TabIndex = 1;
            this.simpleButtonListare.Text = "Listare";
            this.simpleButtonListare.Click += new System.EventHandler(this.simpleButtonListare_Click);
            // 
            // gridControlNir
            // 
            this.gridControlNir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlNir.DataSource = this.tblReceptieComandaBaseBindingSource;
            this.gridControlNir.Location = new System.Drawing.Point(0, 0);
            this.gridControlNir.MainView = this.gridViewNir;
            this.gridControlNir.Name = "gridControlNir";
            this.gridControlNir.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditListeaza,
            this.repositoryItemDateEditData});
            this.gridControlNir.Size = new System.Drawing.Size(478, 277);
            this.gridControlNir.TabIndex = 0;
            this.gridControlNir.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNir});
            // 
            // tblReceptieComandaBaseBindingSource
            // 
            this.tblReceptieComandaBaseBindingSource.DataMember = "tblReceptieComandaBase";
            this.tblReceptieComandaBaseBindingSource.DataSource = typeof(CommonDataSets.Liste.NirDataSet);
            // 
            // gridViewNir
            // 
            this.gridViewNir.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colNumarFactura,
            this.colNumarNir,
            this.colDataReceptie,
            this.colComandaBaseID,
            this.colListare});
            this.gridViewNir.GridControl = this.gridControlNir;
            this.gridViewNir.Name = "gridViewNir";
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colNumarFactura
            // 
            this.colNumarFactura.FieldName = "NumarFactura";
            this.colNumarFactura.Name = "colNumarFactura";
            this.colNumarFactura.OptionsColumn.AllowEdit = false;
            this.colNumarFactura.OptionsColumn.ReadOnly = true;
            this.colNumarFactura.Visible = true;
            this.colNumarFactura.VisibleIndex = 1;
            // 
            // colNumarNir
            // 
            this.colNumarNir.FieldName = "NumarNir";
            this.colNumarNir.Name = "colNumarNir";
            this.colNumarNir.OptionsColumn.AllowEdit = false;
            this.colNumarNir.OptionsColumn.ReadOnly = true;
            this.colNumarNir.Visible = true;
            this.colNumarNir.VisibleIndex = 2;
            // 
            // colDataReceptie
            // 
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
            this.colListare.ColumnEdit = this.repositoryItemCheckEditListeaza;
            this.colListare.FieldName = "Listare";
            this.colListare.Name = "colListare";
            this.colListare.Visible = true;
            this.colListare.VisibleIndex = 0;
            // 
            // repositoryItemCheckEditListeaza
            // 
            this.repositoryItemCheckEditListeaza.AutoHeight = false;
            this.repositoryItemCheckEditListeaza.Name = "repositoryItemCheckEditListeaza";
            // 
            // NirFiltre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 337);
            this.Controls.Add(this.panelControl1);
            this.Name = "NirFiltre";
            this.Text = "NirFiltre";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReceptieComandaBaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditListeaza)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRenunta;
        private DevExpress.XtraGrid.GridControl gridControlNir;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNir;
        private DevExpress.XtraEditors.SimpleButton simpleButtonListare;
        private System.Windows.Forms.BindingSource tblReceptieComandaBaseBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNumarFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colNumarNir;
        private DevExpress.XtraGrid.Columns.GridColumn colDataReceptie;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditData;
        private DevExpress.XtraGrid.Columns.GridColumn colComandaBaseID;
        private DevExpress.XtraGrid.Columns.GridColumn colListare;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditListeaza;
    }
}