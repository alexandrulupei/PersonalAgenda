namespace ComenziGUI
{
	partial class RolesActualizare
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
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonListare = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRenunta = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSalveaza = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlDetalii = new DevExpress.XtraEditors.GroupControl();
            this.gridControlEvidente = new DevExpress.XtraGrid.GridControl();
            this.tblDeschidereBaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewEvidente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInclus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditInclus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNumeDeschidere = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBugetar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.memoEditRolDescription = new DevExpress.XtraEditors.MemoEdit();
            this.tblRolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditRolName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControlAccessMeniu = new DevExpress.XtraEditors.GroupControl();
            this.treeListMeniu = new DevExpress.XtraTreeList.TreeList();
            this.colNAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTipAccesID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemLookUpEditTipAcces = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tbxTipAccesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblNavigationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemTextEditReadOnly = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetalii)).BeginInit();
            this.groupControlDetalii.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEvidente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeschidereBaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEvidente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditInclus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditRolDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRolName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAccessMeniu)).BeginInit();
            this.groupControlAccessMeniu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListMeniu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTipAcces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipAccesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNavigationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditReadOnly)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.simpleButtonListare);
            this.panelControl.Controls.Add(this.simpleButtonRenunta);
            this.panelControl.Controls.Add(this.simpleButtonSalveaza);
            this.panelControl.Controls.Add(this.splitContainerControl1);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(770, 540);
            this.panelControl.TabIndex = 0;
            // 
            // simpleButtonListare
            // 
            this.simpleButtonListare.Location = new System.Drawing.Point(12, 490);
            this.simpleButtonListare.Name = "simpleButtonListare";
            this.simpleButtonListare.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonListare.TabIndex = 32;
            this.simpleButtonListare.Text = "Listare";
            this.simpleButtonListare.Click += new System.EventHandler(this.simpleButtonListare_Click);
            // 
            // simpleButtonRenunta
            // 
            this.simpleButtonRenunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonRenunta.Location = new System.Drawing.Point(669, 490);
            this.simpleButtonRenunta.Name = "simpleButtonRenunta";
            this.simpleButtonRenunta.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonRenunta.TabIndex = 31;
            this.simpleButtonRenunta.Text = "&Renunta";
            this.simpleButtonRenunta.Click += new System.EventHandler(this.simpleButtonRenunta_Click);
            // 
            // simpleButtonSalveaza
            // 
            this.simpleButtonSalveaza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSalveaza.Location = new System.Drawing.Point(570, 490);
            this.simpleButtonSalveaza.Name = "simpleButtonSalveaza";
            this.simpleButtonSalveaza.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSalveaza.TabIndex = 30;
            this.simpleButtonSalveaza.Text = "&Salveaza";
            this.simpleButtonSalveaza.Click += new System.EventHandler(this.simpleButtonSalveaza_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControlDetalii);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControlAccessMeniu);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(765, 451);
            this.splitContainerControl1.SplitterPosition = 243;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControlDetalii
            // 
            this.groupControlDetalii.Controls.Add(this.gridControlEvidente);
            this.groupControlDetalii.Controls.Add(this.labelControl3);
            this.groupControlDetalii.Controls.Add(this.memoEditRolDescription);
            this.groupControlDetalii.Controls.Add(this.labelControl2);
            this.groupControlDetalii.Controls.Add(this.textEditRolName);
            this.groupControlDetalii.Controls.Add(this.labelControl1);
            this.groupControlDetalii.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDetalii.Location = new System.Drawing.Point(0, 0);
            this.groupControlDetalii.Name = "groupControlDetalii";
            this.groupControlDetalii.Size = new System.Drawing.Size(243, 451);
            this.groupControlDetalii.TabIndex = 0;
            this.groupControlDetalii.Text = "Detalii  Rol";
            // 
            // gridControlEvidente
            // 
            this.gridControlEvidente.DataSource = this.tblDeschidereBaseBindingSource;
            this.gridControlEvidente.Location = new System.Drawing.Point(5, 175);
            this.gridControlEvidente.MainView = this.gridViewEvidente;
            this.gridControlEvidente.Name = "gridControlEvidente";
            this.gridControlEvidente.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditInclus});
            this.gridControlEvidente.Size = new System.Drawing.Size(233, 276);
            this.gridControlEvidente.TabIndex = 5;
            this.gridControlEvidente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEvidente});
            // 
            // tblDeschidereBaseBindingSource
            // 
            this.tblDeschidereBaseBindingSource.DataMember = "tblDeschidereBase";
            this.tblDeschidereBaseBindingSource.DataSource = typeof(CommonDataSets.GUI.RolesDataSet);
            // 
            // gridViewEvidente
            // 
            this.gridViewEvidente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colInclus,
            this.colNumeDeschidere,
            this.colIsBugetar});
            this.gridViewEvidente.GridControl = this.gridControlEvidente;
            this.gridViewEvidente.Name = "gridViewEvidente";
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colInclus
            // 
            this.colInclus.Caption = "Valabil";
            this.colInclus.ColumnEdit = this.repositoryItemCheckEditInclus;
            this.colInclus.FieldName = "Inclus";
            this.colInclus.Name = "colInclus";
            this.colInclus.Visible = true;
            this.colInclus.VisibleIndex = 0;
            // 
            // repositoryItemCheckEditInclus
            // 
            this.repositoryItemCheckEditInclus.AutoHeight = false;
            this.repositoryItemCheckEditInclus.Name = "repositoryItemCheckEditInclus";
            // 
            // colNumeDeschidere
            // 
            this.colNumeDeschidere.Caption = "Evidenta";
            this.colNumeDeschidere.FieldName = "NumeDeschidere";
            this.colNumeDeschidere.Name = "colNumeDeschidere";
            this.colNumeDeschidere.OptionsColumn.AllowEdit = false;
            this.colNumeDeschidere.OptionsColumn.ReadOnly = true;
            this.colNumeDeschidere.Visible = true;
            this.colNumeDeschidere.VisibleIndex = 1;
            // 
            // colIsBugetar
            // 
            this.colIsBugetar.FieldName = "IsBugetar";
            this.colIsBugetar.Name = "colIsBugetar";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 156);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(94, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Valabil in evidentele";
            // 
            // memoEditRolDescription
            // 
            this.memoEditRolDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblRolesBindingSource, "RolDescription", true));
            this.memoEditRolDescription.Location = new System.Drawing.Point(6, 88);
            this.memoEditRolDescription.Name = "memoEditRolDescription";
            this.memoEditRolDescription.Size = new System.Drawing.Size(221, 61);
            this.memoEditRolDescription.TabIndex = 3;
            // 
            // tblRolesBindingSource
            // 
            this.tblRolesBindingSource.DataMember = "tblRoles";
            this.tblRolesBindingSource.DataSource = typeof(CommonDataSets.GUI.RolesDataSet);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(4, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Descriere";
            // 
            // textEditRolName
            // 
            this.textEditRolName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditRolName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tblRolesBindingSource, "RolName", true));
            this.textEditRolName.Location = new System.Drawing.Point(6, 41);
            this.textEditRolName.Name = "textEditRolName";
            this.textEditRolName.Size = new System.Drawing.Size(221, 20);
            this.textEditRolName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nume";
            // 
            // groupControlAccessMeniu
            // 
            this.groupControlAccessMeniu.Controls.Add(this.treeListMeniu);
            this.groupControlAccessMeniu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlAccessMeniu.Location = new System.Drawing.Point(0, 0);
            this.groupControlAccessMeniu.Name = "groupControlAccessMeniu";
            this.groupControlAccessMeniu.Size = new System.Drawing.Size(517, 451);
            this.groupControlAccessMeniu.TabIndex = 0;
            this.groupControlAccessMeniu.Text = "Drepturi acces la meniu";
            // 
            // treeListMeniu
            // 
            this.treeListMeniu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colNAME,
            this.colDescription,
            this.colTipAccesID});
            this.treeListMeniu.DataSource = this.tblNavigationBindingSource;
            this.treeListMeniu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListMeniu.Location = new System.Drawing.Point(2, 21);
            this.treeListMeniu.Name = "treeListMeniu";
            this.treeListMeniu.ParentFieldName = "ParentGroupID";
            this.treeListMeniu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditTipAcces,
            this.repositoryItemTextEditReadOnly});
            this.treeListMeniu.Size = new System.Drawing.Size(513, 428);
            this.treeListMeniu.TabIndex = 0;
            this.treeListMeniu.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.treeListMeniu_CustomNodeCellEdit);
            // 
            // colNAME
            // 
            this.colNAME.Caption = "Nume";
            this.colNAME.FieldName = "NAME";
            this.colNAME.Name = "colNAME";
            this.colNAME.Visible = true;
            this.colNAME.VisibleIndex = 0;
            this.colNAME.Width = 70;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 70;
            // 
            // colTipAccesID
            // 
            this.colTipAccesID.Caption = "Tip Acces";
            this.colTipAccesID.ColumnEdit = this.repositoryItemLookUpEditTipAcces;
            this.colTipAccesID.FieldName = "TipAccesID";
            this.colTipAccesID.Name = "colTipAccesID";
            this.colTipAccesID.Visible = true;
            this.colTipAccesID.VisibleIndex = 1;
            this.colTipAccesID.Width = 71;
            // 
            // repositoryItemLookUpEditTipAcces
            // 
            this.repositoryItemLookUpEditTipAcces.AutoHeight = false;
            this.repositoryItemLookUpEditTipAcces.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditTipAcces.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbreviation", "Cod"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Descriere")});
            this.repositoryItemLookUpEditTipAcces.DataSource = this.tbxTipAccesBindingSource;
            this.repositoryItemLookUpEditTipAcces.DisplayMember = "Abbreviation";
            this.repositoryItemLookUpEditTipAcces.Name = "repositoryItemLookUpEditTipAcces";
            this.repositoryItemLookUpEditTipAcces.NullText = "";
            this.repositoryItemLookUpEditTipAcces.ValueMember = "ID";
            // 
            // tbxTipAccesBindingSource
            // 
            this.tbxTipAccesBindingSource.DataMember = "tbxTipAcces";
            this.tbxTipAccesBindingSource.DataSource = typeof(CommonDataSets.GUI.RolesDataSet);
            // 
            // tblNavigationBindingSource
            // 
            this.tblNavigationBindingSource.DataMember = "tblNavigation";
            this.tblNavigationBindingSource.DataSource = typeof(CommonDataSets.GUI.RolesDataSet);
            // 
            // repositoryItemTextEditReadOnly
            // 
            this.repositoryItemTextEditReadOnly.AutoHeight = false;
            this.repositoryItemTextEditReadOnly.Name = "repositoryItemTextEditReadOnly";
            // 
            // RolesActualizare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 540);
            this.Controls.Add(this.panelControl);
            this.Name = "RolesActualizare";
            this.Text = "RolesActualizare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RolesActualizare_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RolesActualizare_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.panelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetalii)).EndInit();
            this.groupControlDetalii.ResumeLayout(false);
            this.groupControlDetalii.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEvidente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeschidereBaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEvidente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditInclus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditRolDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRolesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRolName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAccessMeniu)).EndInit();
            this.groupControlAccessMeniu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListMeniu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTipAcces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipAccesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNavigationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditReadOnly)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.PanelControl panelControl;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControlAccessMeniu;
        private DevExpress.XtraTreeList.TreeList treeListMeniu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTipAccesID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditTipAcces;
        private System.Windows.Forms.BindingSource tbxTipAccesBindingSource;
        private System.Windows.Forms.BindingSource tblNavigationBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControlDetalii;
        private DevExpress.XtraGrid.GridControl gridControlEvidente;
        private System.Windows.Forms.BindingSource tblDeschidereBaseBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEvidente;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colInclus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditInclus;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeDeschidere;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBugetar;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit memoEditRolDescription;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditRolName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRenunta;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSalveaza;
        private DevExpress.XtraEditors.SimpleButton simpleButtonListare;
        private System.Windows.Forms.BindingSource tblRolesBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditReadOnly;
	}
}