namespace ComenziGUI
{
    partial class UsersHome
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
            this.gridControlUsers = new DevExpress.XtraGrid.GridControl();
            this.gridViewUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPrenume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTipConnection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditTipConexiune = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel2)).BeginInit();
            this.splitContainerControlBaseWindow.Panel2.SuspendLayout();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTipConexiune)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            // 
            // splitContainerControlBaseWindow.Panel2
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlUsers);
            // 
            // progressBarControlBaseWindow
            // 
            this.progressBarControlBaseWindow.Visible = false;
            // 
            // labelBaseWindowHeader
            // 
            this.labelBaseWindowHeader.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBaseWindowHeader.Appearance.Options.UseFont = true;
            this.labelBaseWindowHeader.Appearance.Options.UseTextOptions = true;
            this.labelBaseWindowHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelBaseWindowHeader.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelBaseWindowHeader.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelBaseWindowHeader.Text = "Utilizatori";
            // 
            // gridControlUsers
            // 
            this.gridControlUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlUsers.Location = new System.Drawing.Point(0, 0);
            this.gridControlUsers.MainView = this.gridViewUsers;
            this.gridControlUsers.Name = "gridControlUsers";
            this.gridControlUsers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditTipConexiune});
            this.gridControlUsers.Size = new System.Drawing.Size(738, 456);
            this.gridControlUsers.TabIndex = 1;
            this.gridControlUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUsers});
            // 
            // gridViewUsers
            // 
            this.gridViewUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnUserName,
            this.gridColumnNume,
            this.gridColumnPrenume,
            this.gridColumnActiv,
            this.gridColumnTipConnection});
            this.gridViewUsers.GridControl = this.gridControlUsers;
            this.gridViewUsers.Name = "gridViewUsers";
            this.gridViewUsers.OptionsBehavior.Editable = false;
            this.gridViewUsers.OptionsView.ShowAutoFilterRow = true;
            this.gridViewUsers.OptionsView.ShowGroupPanel = false;
            this.gridViewUsers.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewUsers_FocusedRowChanged);
            // 
            // gridColumnUserName
            // 
            this.gridColumnUserName.Caption = "Utilizator";
            this.gridColumnUserName.FieldName = "UserName";
            this.gridColumnUserName.Name = "gridColumnUserName";
            this.gridColumnUserName.Visible = true;
            this.gridColumnUserName.VisibleIndex = 0;
            // 
            // gridColumnNume
            // 
            this.gridColumnNume.Caption = "Nume";
            this.gridColumnNume.FieldName = "Nume";
            this.gridColumnNume.Name = "gridColumnNume";
            this.gridColumnNume.Visible = true;
            this.gridColumnNume.VisibleIndex = 1;
            // 
            // gridColumnPrenume
            // 
            this.gridColumnPrenume.Caption = "Prenume";
            this.gridColumnPrenume.FieldName = "Prenume";
            this.gridColumnPrenume.Name = "gridColumnPrenume";
            this.gridColumnPrenume.Visible = true;
            this.gridColumnPrenume.VisibleIndex = 2;
            // 
            // gridColumnActiv
            // 
            this.gridColumnActiv.Caption = "Activ";
            this.gridColumnActiv.FieldName = "IsActive";
            this.gridColumnActiv.Name = "gridColumnActiv";
            this.gridColumnActiv.Visible = true;
            this.gridColumnActiv.VisibleIndex = 3;
            // 
            // gridColumnTipConnection
            // 
            this.gridColumnTipConnection.Caption = "Tip Connection";
            this.gridColumnTipConnection.ColumnEdit = this.repositoryItemLookUpEditTipConexiune;
            this.gridColumnTipConnection.FieldName = "TipConnection";
            this.gridColumnTipConnection.Name = "gridColumnTipConnection";
            this.gridColumnTipConnection.Visible = true;
            this.gridColumnTipConnection.VisibleIndex = 4;
            // 
            // repositoryItemLookUpEditTipConexiune
            // 
            this.repositoryItemLookUpEditTipConexiune.AutoHeight = false;
            this.repositoryItemLookUpEditTipConexiune.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditTipConexiune.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description")});
            this.repositoryItemLookUpEditTipConexiune.Name = "repositoryItemLookUpEditTipConexiune";
            this.repositoryItemLookUpEditTipConexiune.NullText = "";
            // 
            // UsersHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "UsersHome";
            this.SetWindowHeader = "Utilizatori";
            this.SetWindowTitle = "UsersHome";
            this.Text = "UsersHome";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UsersHome_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel2)).EndInit();
            this.splitContainerControlBaseWindow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTipConexiune)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUsers;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNume;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrenume;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActiv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTipConnection;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditTipConexiune;
    }
}