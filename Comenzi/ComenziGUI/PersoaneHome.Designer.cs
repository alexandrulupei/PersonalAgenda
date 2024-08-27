namespace ComenziGUI
{
    partial class PersoaneHome
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
            this.gridControlPersoane = new DevExpress.XtraGrid.GridControl();
            this.tblPersoaneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewPersoane = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrenume = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPersoane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPersoaneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPersoane)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlPersoane);
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
            // gridControlPersoane
            // 
            this.gridControlPersoane.DataSource = this.tblPersoaneBindingSource;
            this.gridControlPersoane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPersoane.Location = new System.Drawing.Point(0, 0);
            this.gridControlPersoane.MainView = this.gridViewPersoane;
            this.gridControlPersoane.Name = "gridControlPersoane";
            this.gridControlPersoane.Size = new System.Drawing.Size(739, 456);
            this.gridControlPersoane.TabIndex = 1;
            this.gridControlPersoane.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPersoane});
            // 
            // tblPersoaneBindingSource
            // 
            this.tblPersoaneBindingSource.DataMember = "tblPersoane";
            this.tblPersoaneBindingSource.DataSource = typeof(CommonDataSets.GUI.PersoaneDataSet);
            // 
            // gridViewPersoane
            // 
            this.gridViewPersoane.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colNume,
            this.colPrenume});
            this.gridViewPersoane.GridControl = this.gridControlPersoane;
            this.gridViewPersoane.Name = "gridViewPersoane";
            this.gridViewPersoane.OptionsBehavior.Editable = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colNume
            // 
            this.colNume.FieldName = "Nume";
            this.colNume.Name = "colNume";
            this.colNume.Visible = true;
            this.colNume.VisibleIndex = 0;
            // 
            // colPrenume
            // 
            this.colPrenume.FieldName = "Prenume";
            this.colPrenume.Name = "colPrenume";
            this.colPrenume.Visible = true;
            this.colPrenume.VisibleIndex = 1;
            // 
            // PersoaneHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "PersoaneHome";
            this.SetWindowTitle = "PersoaneHome";
            this.Text = "PersoaneHome";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPersoane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPersoaneBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPersoane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPersoane;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPersoane;
        private System.Windows.Forms.BindingSource tblPersoaneBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNume;
        private DevExpress.XtraGrid.Columns.GridColumn colPrenume;
    }
}