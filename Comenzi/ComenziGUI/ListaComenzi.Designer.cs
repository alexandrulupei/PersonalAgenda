namespace ComenziGUI
{
    partial class ListaComenzi
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
            this.gridControlComenzi = new DevExpress.XtraGrid.GridControl();
            this.gridViewComenzi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tblListaBindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHeader)).BeginInit();
            this.panelControlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindowGrid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditOrientare.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDimensiune.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlConfigurareCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlComenzi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewComenzi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblListaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlHeader
            // 
            this.panelControlHeader.Appearance.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelControlHeader.Appearance.Options.UseBackColor = true;
            this.panelControlHeader.Size = new System.Drawing.Size(912, 30);
            // 
            // labelTitle
            // 
            this.labelTitle.Size = new System.Drawing.Size(908, 30);
            // 
            // progressBarControlBaseWindowGrid
            // 
            this.progressBarControlBaseWindowGrid.Location = new System.Drawing.Point(0, 442);
            this.progressBarControlBaseWindowGrid.Size = new System.Drawing.Size(611, 20);
            this.progressBarControlBaseWindowGrid.Visible = false;
            // 
            // comboBoxEditOrientare
            // 
            // 
            // comboBoxEditDimensiune
            // 
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.Appearance.Options.UseForeColor = true;
            this.panelControl3.Controls.Add(this.gridControlComenzi);
            this.panelControl3.LookAndFeel.SkinName = "Money Twins";
            this.panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl3.Size = new System.Drawing.Size(712, 460);
            this.panelControl3.Controls.SetChildIndex(this.gridControlComenzi, 0);
            this.panelControl3.Controls.SetChildIndex(this.progressBarControlBaseWindowGrid, 0);
            // 
            // checkedListBoxControlConfigurareCol
            // 
            this.checkedListBoxControlConfigurareCol.LookAndFeel.SkinName = "Money Twins";
            this.checkedListBoxControlConfigurareCol.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseForeColor = true;
            this.panelControl2.LookAndFeel.SkinName = "Money Twins";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Size = new System.Drawing.Size(191, 460);
            // 
            // gridControlComenzi
            // 
            this.gridControlComenzi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlComenzi.Location = new System.Drawing.Point(0, 0);
            this.gridControlComenzi.MainView = this.gridViewComenzi;
            this.gridControlComenzi.Name = "gridControlComenzi";
            this.gridControlComenzi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma});
            this.gridControlComenzi.Size = new System.Drawing.Size(712, 460);
            this.gridControlComenzi.TabIndex = 1;
            this.gridControlComenzi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewComenzi});
            // 
            // gridViewComenzi
            // 
            this.gridViewComenzi.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewComenzi.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewComenzi.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewComenzi.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridViewComenzi.ColumnPanelRowHeight = 50;
            this.gridViewComenzi.GridControl = this.gridControlComenzi;
            this.gridViewComenzi.Name = "gridViewComenzi";
            this.gridViewComenzi.OptionsBehavior.Editable = false;
            this.gridViewComenzi.OptionsView.ShowAutoFilterRow = true;
            this.gridViewComenzi.OptionsView.ShowFooter = true;
            // 
            // repositoryItemTextEditSuma
            // 
            this.repositoryItemTextEditSuma.AutoHeight = false;
            this.repositoryItemTextEditSuma.Name = "repositoryItemTextEditSuma";
            // 
            // tblListaBindingSource
            // 
            this.tblListaBindingSource.DataMember = "tblLista";
            this.tblListaBindingSource.DataSource = typeof(CommonDataSets.GUI.ListaComenziDataSet);
            // 
            // ListaComenzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "ListaComenzi";
            this.Text = "ListaComenzi";
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHeader)).EndInit();
            this.panelControlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindowGrid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditOrientare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDimensiune.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlConfigurareCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlComenzi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewComenzi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblListaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlComenzi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewComenzi;
        private System.Windows.Forms.BindingSource tblListaBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
    }
}