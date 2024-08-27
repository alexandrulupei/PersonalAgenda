namespace ComenziGUI
{
    partial class NomenclatoareHome
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
            this.gridControlNomenclator = new DevExpress.XtraGrid.GridControl();
            this.gridViewNomenclator = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAbbreviation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditAbbreviation = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditDescription = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditIsActive = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumnCodIntern = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNomenclator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNomenclator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditAbbreviation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditIsActive)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlNomenclator);
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
            // gridControlNomenclator
            // 
            this.gridControlNomenclator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlNomenclator.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControlNomenclator.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControlNomenclator.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControlNomenclator.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControlNomenclator.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gridControlNomenclator.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControlNomenclator.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gridControlNomenclator.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControlNomenclator.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControlNomenclator_EmbeddedNavigator_ButtonClick);
            this.gridControlNomenclator.Location = new System.Drawing.Point(0, 0);
            this.gridControlNomenclator.MainView = this.gridViewNomenclator;
            this.gridControlNomenclator.Name = "gridControlNomenclator";
            this.gridControlNomenclator.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditAbbreviation,
            this.repositoryItemTextEditDescription,
            this.repositoryItemCheckEditIsActive});
            this.gridControlNomenclator.Size = new System.Drawing.Size(739, 456);
            this.gridControlNomenclator.TabIndex = 1;
            this.gridControlNomenclator.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNomenclator});
            // 
            // gridViewNomenclator
            // 
            this.gridViewNomenclator.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnAbbreviation,
            this.gridColumnDescription,
            this.gridColumnIsActive,
            this.gridColumnCodIntern,
            this.gridColumnEffectiveDate});
            this.gridViewNomenclator.GridControl = this.gridControlNomenclator;
            this.gridViewNomenclator.Name = "gridViewNomenclator";
            this.gridViewNomenclator.OptionsView.ShowAutoFilterRow = true;
            this.gridViewNomenclator.OptionsView.ShowGroupPanel = false;
            this.gridViewNomenclator.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewNomenclator_InitNewRow);
            this.gridViewNomenclator.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewNomenclator_FocusedRowChanged);
            this.gridViewNomenclator.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridViewNomenclator_InvalidRowException);
            this.gridViewNomenclator.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridViewNomenclator_ValidateRow);
            this.gridViewNomenclator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewNomenclator_KeyDown);
            this.gridViewNomenclator.DoubleClick += new System.EventHandler(this.gridViewNomenclator_DoubleClick);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // gridColumnAbbreviation
            // 
            this.gridColumnAbbreviation.Caption = "Cod";
            this.gridColumnAbbreviation.ColumnEdit = this.repositoryItemTextEditAbbreviation;
            this.gridColumnAbbreviation.FieldName = "Abbreviation";
            this.gridColumnAbbreviation.Name = "gridColumnAbbreviation";
            this.gridColumnAbbreviation.Visible = true;
            this.gridColumnAbbreviation.VisibleIndex = 0;
            // 
            // repositoryItemTextEditAbbreviation
            // 
            this.repositoryItemTextEditAbbreviation.AutoHeight = false;
            this.repositoryItemTextEditAbbreviation.Name = "repositoryItemTextEditAbbreviation";
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Denumire";
            this.gridColumnDescription.ColumnEdit = this.repositoryItemTextEditDescription;
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 1;
            // 
            // repositoryItemTextEditDescription
            // 
            this.repositoryItemTextEditDescription.AutoHeight = false;
            this.repositoryItemTextEditDescription.Name = "repositoryItemTextEditDescription";
            // 
            // gridColumnIsActive
            // 
            this.gridColumnIsActive.Caption = "Valabil";
            this.gridColumnIsActive.ColumnEdit = this.repositoryItemCheckEditIsActive;
            this.gridColumnIsActive.FieldName = "IsActive";
            this.gridColumnIsActive.Name = "gridColumnIsActive";
            this.gridColumnIsActive.Visible = true;
            this.gridColumnIsActive.VisibleIndex = 2;
            // 
            // repositoryItemCheckEditIsActive
            // 
            this.repositoryItemCheckEditIsActive.AutoHeight = false;
            this.repositoryItemCheckEditIsActive.Name = "repositoryItemCheckEditIsActive";
            // 
            // gridColumnCodIntern
            // 
            this.gridColumnCodIntern.Caption = "gridColumn5";
            this.gridColumnCodIntern.FieldName = "CodIntern";
            this.gridColumnCodIntern.Name = "gridColumnCodIntern";
            // 
            // gridColumnEffectiveDate
            // 
            this.gridColumnEffectiveDate.Caption = "EffectiveDate";
            this.gridColumnEffectiveDate.FieldName = "EffectiveDate";
            this.gridColumnEffectiveDate.Name = "gridColumnEffectiveDate";
            // 
            // NomenclatoareHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "NomenclatoareHome";
            this.SetWindowTitle = "NomenclatoareHome";
            this.Text = "NomenclatoareHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NomenclatoareHome_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNomenclator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNomenclator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditAbbreviation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditIsActive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlNomenclator;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNomenclator;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAbbreviation;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAbbreviation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIsActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCodIntern;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEffectiveDate;
    }
}