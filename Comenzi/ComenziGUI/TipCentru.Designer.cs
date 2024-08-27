using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace ComenziGUI
{
    partial class TipCentru
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.gridControlTipCentru = new DevExpress.XtraGrid.GridControl();
            this.tbxTipCentruBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewTipCentru = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbbreviation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpirationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditActiv = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTipCentru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipCentruBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTipCentru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditActiv)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControlBaseWindow
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.gridControlTipCentru);
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
            // gridControlTipCentru
            // 
            this.gridControlTipCentru.DataSource = this.tbxTipCentruBindingSource;
            this.gridControlTipCentru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTipCentru.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControlTipCentru.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControlTipCentru.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControlTipCentru.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gridControlTipCentru.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControlTipCentru.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gridControlTipCentru.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControlTipCentru.Location = new System.Drawing.Point(0, 0);
            this.gridControlTipCentru.MainView = this.gridViewTipCentru;
            this.gridControlTipCentru.Name = "gridControlTipCentru";
            this.gridControlTipCentru.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditActiv});
            this.gridControlTipCentru.Size = new System.Drawing.Size(739, 456);
            this.gridControlTipCentru.TabIndex = 1;
            this.gridControlTipCentru.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTipCentru});
            // 
            // tbxTipCentruBindingSource
            // 
            this.tbxTipCentruBindingSource.DataMember = "tbxTipCentru";
            this.tbxTipCentruBindingSource.DataSource = typeof(CommonDataSets.GUI.Nomenclatoare);
            // 
            // gridViewTipCentru
            // 
            this.gridViewTipCentru.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colAbbreviation,
            this.colDescription,
            this.colIsActive,
            this.colEffectiveDate,
            this.colExpirationDate});
            this.gridViewTipCentru.GridControl = this.gridControlTipCentru;
            this.gridViewTipCentru.Name = "gridViewTipCentru";
            this.gridViewTipCentru.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewTipCentru.OptionsView.ShowAutoFilterRow = true;
            this.gridViewTipCentru.OptionsView.ShowFooter = true;
            this.gridViewTipCentru.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewTipCentru_InitNewRow);
            this.gridViewTipCentru.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridViewTipCentru_ValidateRow);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colAbbreviation
            // 
            this.colAbbreviation.Caption = "Cod";
            this.colAbbreviation.CustomizationCaption = "Cod";
            this.colAbbreviation.FieldName = "Abbreviation";
            this.colAbbreviation.Name = "colAbbreviation";
            this.colAbbreviation.Visible = true;
            this.colAbbreviation.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Denumie";
            this.colDescription.CustomizationCaption = "Denumire";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Activ";
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 2;
            // 
            // colEffectiveDate
            // 
            this.colEffectiveDate.FieldName = "EffectiveDate";
            this.colEffectiveDate.Name = "colEffectiveDate";
            // 
            // colExpirationDate
            // 
            this.colExpirationDate.FieldName = "ExpirationDate";
            this.colExpirationDate.Name = "colExpirationDate";
            // 
            // repositoryItemCheckEditActiv
            // 
            this.repositoryItemCheckEditActiv.AutoHeight = false;
            this.repositoryItemCheckEditActiv.Name = "repositoryItemCheckEditActiv";
            // 
            // TipCentru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Name = "TipCentru";
            this.SetWindowTitle = "TipCentru";
            this.Text = "TipCentru";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TipCentru_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTipCentru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipCentruBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTipCentru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditActiv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GridControl gridControlTipCentru;
        private GridView gridViewTipCentru;
        private BindingSource tbxTipCentruBindingSource;
        private GridColumn colID;
        private GridColumn colAbbreviation;
        private GridColumn colDescription;
        private GridColumn colIsActive;
        private GridColumn colEffectiveDate;
        private GridColumn colExpirationDate;
        private RepositoryItemCheckEdit repositoryItemCheckEditActiv;
    }
}