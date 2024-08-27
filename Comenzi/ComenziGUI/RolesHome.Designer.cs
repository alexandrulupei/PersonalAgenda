namespace ComenziGUI
{
	partial class RolesHome
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.lnkRolesDeschidereBaseBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRolesID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditRoles = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tblRolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colRolDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeschidereBaseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditDeschidere = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tblDeschidereBaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lnkRolesDeschidereBaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkRolesDeschidereBaseBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditDeschidere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeschidereBaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkRolesDeschidereBaseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControl1);
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
            this.labelBaseWindowHeader.Text = "Roluri";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.lnkRolesDeschidereBaseBindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditRoles,
            this.repositoryItemLookUpEditDeschidere});
            this.gridControl1.Size = new System.Drawing.Size(739, 456);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // lnkRolesDeschidereBaseBindingSource1
            // 
            this.lnkRolesDeschidereBaseBindingSource1.DataMember = "lnkRolesDeschidereBase";
            this.lnkRolesDeschidereBaseBindingSource1.DataSource = typeof(CommonDataSets.GUI.RolesDataSet);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colRolesID,
            this.colRolDescription,
            this.colDeschidereBaseID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colRolesID
            // 
            this.colRolesID.Caption = "Rol";
            this.colRolesID.ColumnEdit = this.repositoryItemLookUpEditRoles;
            this.colRolesID.FieldName = "RolesID";
            this.colRolesID.Name = "colRolesID";
            this.colRolesID.Visible = true;
            this.colRolesID.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEditRoles
            // 
            this.repositoryItemLookUpEditRoles.AutoHeight = false;
            this.repositoryItemLookUpEditRoles.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditRoles.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RolName", "Nume Rol"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RolDescription", "Descriere")});
            this.repositoryItemLookUpEditRoles.DataSource = this.tblRolesBindingSource;
            this.repositoryItemLookUpEditRoles.DisplayMember = "RolName";
            this.repositoryItemLookUpEditRoles.Name = "repositoryItemLookUpEditRoles";
            this.repositoryItemLookUpEditRoles.ValueMember = "ID";
            // 
            // tblRolesBindingSource
            // 
            this.tblRolesBindingSource.DataMember = "tblRoles";
            this.tblRolesBindingSource.DataSource = typeof(CommonDataSets.GUI.RolesDataSet);
            // 
            // colRolDescription
            // 
            this.colRolDescription.Caption = "Descriere";
            this.colRolDescription.FieldName = "RolDescription";
            this.colRolDescription.Name = "colRolDescription";
            this.colRolDescription.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colRolDescription.Visible = true;
            this.colRolDescription.VisibleIndex = 2;
            // 
            // colDeschidereBaseID
            // 
            this.colDeschidereBaseID.Caption = "Evidenta";
            this.colDeschidereBaseID.ColumnEdit = this.repositoryItemLookUpEditDeschidere;
            this.colDeschidereBaseID.FieldName = "DeschidereBaseID";
            this.colDeschidereBaseID.Name = "colDeschidereBaseID";
            this.colDeschidereBaseID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDeschidereBaseID.Visible = true;
            this.colDeschidereBaseID.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEditDeschidere
            // 
            this.repositoryItemLookUpEditDeschidere.AutoHeight = false;
            this.repositoryItemLookUpEditDeschidere.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditDeschidere.DataSource = this.tblDeschidereBaseBindingSource;
            this.repositoryItemLookUpEditDeschidere.DisplayMember = "NumeDeschidere";
            this.repositoryItemLookUpEditDeschidere.Name = "repositoryItemLookUpEditDeschidere";
            this.repositoryItemLookUpEditDeschidere.ValueMember = "ID";
            // 
            // tblDeschidereBaseBindingSource
            // 
            this.tblDeschidereBaseBindingSource.DataMember = "tblDeschidereBase";
            this.tblDeschidereBaseBindingSource.DataSource = typeof(CommonDataSets.GUI.RolesDataSet);
            // 
            // lnkRolesDeschidereBaseBindingSource
            // 
            this.lnkRolesDeschidereBaseBindingSource.DataMember = "lnkRolesDeschidereBase";
            this.lnkRolesDeschidereBaseBindingSource.DataSource = typeof(CommonDataSets.GUI.RolesDataSet);
            // 
            // RolesHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "RolesHome";
            this.SetWindowHeader = "Roluri";
            this.SetWindowTitle = "RolesHome";
            this.Text = "RolesHome";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RolesHome_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkRolesDeschidereBaseBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRolesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditDeschidere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeschidereBaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkRolesDeschidereBaseBindingSource)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource lnkRolesDeschidereBaseBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colRolesID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditRoles;
        private System.Windows.Forms.BindingSource tblRolesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDeschidereBaseID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditDeschidere;
        private System.Windows.Forms.BindingSource tblDeschidereBaseBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colRolDescription;
        private System.Windows.Forms.BindingSource lnkRolesDeschidereBaseBindingSource1;
	}
}