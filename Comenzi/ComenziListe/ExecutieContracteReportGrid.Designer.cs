namespace ComenziListe
{
    partial class ExecutieContracteReportGrid
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
            this.gridControlLista = new DevExpress.XtraGrid.GridControl();
            this.gridViewDate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCentru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProdus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCantitateDistribuita = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareCuTva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateReceptionata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareReceptionata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateDisponibila = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareDisponibila = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcordCadru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewProcent = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProcent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblListaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlHeader
            // 
            this.panelControlHeader.Appearance.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelControlHeader.Appearance.Options.UseBackColor = true;
            this.panelControlHeader.Size = new System.Drawing.Size(793, 30);
            // 
            // labelTitle
            // 
            this.labelTitle.Size = new System.Drawing.Size(789, 30);
            // 
            // progressBarControlBaseWindowGrid
            // 
            this.progressBarControlBaseWindowGrid.Size = new System.Drawing.Size(594, 20);
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
            this.panelControl3.Controls.Add(this.gridControlLista);
            this.panelControl3.LookAndFeel.SkinName = "Money Twins";
            this.panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl3.Size = new System.Drawing.Size(588, 477);
            this.panelControl3.Controls.SetChildIndex(this.progressBarControlBaseWindowGrid, 0);
            this.panelControl3.Controls.SetChildIndex(this.gridControlLista, 0);
            // 
            // checkedListBoxControlConfigurareCol
            // 
            this.checkedListBoxControlConfigurareCol.LookAndFeel.SkinName = "Money Twins";
            this.checkedListBoxControlConfigurareCol.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkedListBoxControlConfigurareCol.Size = new System.Drawing.Size(185, 453);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseForeColor = true;
            this.panelControl2.LookAndFeel.SkinName = "Money Twins";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // gridControlLista
            // 
            this.gridControlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLista.Location = new System.Drawing.Point(0, 0);
            this.gridControlLista.MainView = this.gridViewDate;
            this.gridControlLista.Name = "gridControlLista";
            this.gridControlLista.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma});
            this.gridControlLista.Size = new System.Drawing.Size(588, 477);
            this.gridControlLista.TabIndex = 1;
            this.gridControlLista.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDate,
            this.gridViewProcent});
            this.gridControlLista.Click += new System.EventHandler(this.gridControlLista_Click);
            // 
            // gridViewDate
            // 
            this.gridViewDate.ColumnPanelRowHeight = 35;
            this.gridViewDate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCentru,
            this.colLot,
            this.colProdus,
            this.colUM,
            this.colPret,
            this.colCantitateDistribuita,
            this.colValoareCuTva,
            this.colCantitateReceptionata,
            this.colValoareReceptionata,
            this.colCantitateDisponibila,
            this.colValoareDisponibila,
            this.colAcordCadru});
            this.gridViewDate.GridControl = this.gridControlLista;
            this.gridViewDate.GroupCount = 3;
            this.gridViewDate.GroupRowHeight = 35;
            this.gridViewDate.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CantitateDistribuita", this.colCantitateDistribuita, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareCuTva", this.colValoareCuTva, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CantitateReceptionata", this.colCantitateReceptionata, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareReceptionata", this.colValoareReceptionata, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CantitateDisponibila", this.colCantitateDisponibila, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareDisponibila", this.colValoareDisponibila, "")});
            this.gridViewDate.Name = "gridViewDate";
            this.gridViewDate.OptionsBehavior.Editable = false;
            this.gridViewDate.OptionsBehavior.ReadOnly = true;
            this.gridViewDate.OptionsView.ShowAutoFilterRow = true;
            this.gridViewDate.OptionsView.ShowFooter = true;
            this.gridViewDate.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLot, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAcordCadru, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCentru, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colCentru
            // 
            this.colCentru.AppearanceHeader.Options.UseTextOptions = true;
            this.colCentru.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCentru.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCentru.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCentru.Caption = "Centru";
            this.colCentru.FieldName = "Centru";
            this.colCentru.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCentru.Name = "colCentru";
            this.colCentru.Visible = true;
            this.colCentru.VisibleIndex = 0;
            // 
            // colLot
            // 
            this.colLot.AppearanceHeader.Options.UseTextOptions = true;
            this.colLot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLot.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLot.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLot.Caption = "Lot";
            this.colLot.FieldName = "Lot";
            this.colLot.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colLot.Name = "colLot";
            this.colLot.Visible = true;
            this.colLot.VisibleIndex = 1;
            // 
            // colProdus
            // 
            this.colProdus.AppearanceHeader.Options.UseTextOptions = true;
            this.colProdus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProdus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProdus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProdus.Caption = "Produs";
            this.colProdus.FieldName = "Produs";
            this.colProdus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colProdus.Name = "colProdus";
            this.colProdus.Visible = true;
            this.colProdus.VisibleIndex = 0;
            this.colProdus.Width = 83;
            // 
            // colUM
            // 
            this.colUM.AppearanceHeader.Options.UseTextOptions = true;
            this.colUM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUM.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUM.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUM.Caption = "U.M.";
            this.colUM.FieldName = "UM";
            this.colUM.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colUM.Name = "colUM";
            this.colUM.Visible = true;
            this.colUM.VisibleIndex = 1;
            // 
            // colPret
            // 
            this.colPret.AppearanceHeader.Options.UseTextOptions = true;
            this.colPret.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPret.Caption = "Pret";
            this.colPret.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colPret.FieldName = "Pret";
            this.colPret.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPret.Name = "colPret";
            this.colPret.Visible = true;
            this.colPret.VisibleIndex = 2;
            // 
            // repositoryItemTextEditSuma
            // 
            this.repositoryItemTextEditSuma.AutoHeight = false;
            this.repositoryItemTextEditSuma.Name = "repositoryItemTextEditSuma";
            // 
            // colCantitateDistribuita
            // 
            this.colCantitateDistribuita.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDistribuita.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDistribuita.Caption = "Cantitate Distribuita";
            this.colCantitateDistribuita.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateDistribuita.FieldName = "CantitateDistribuita";
            this.colCantitateDistribuita.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateDistribuita.Name = "colCantitateDistribuita";
            this.colCantitateDistribuita.Visible = true;
            this.colCantitateDistribuita.VisibleIndex = 3;
            // 
            // colValoareCuTva
            // 
            this.colValoareCuTva.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareCuTva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareCuTva.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareCuTva.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareCuTva.Caption = "Valoare Distribuita";
            this.colValoareCuTva.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareCuTva.FieldName = "ValoareCuTva";
            this.colValoareCuTva.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareCuTva.Name = "colValoareCuTva";
            this.colValoareCuTva.Visible = true;
            this.colValoareCuTva.VisibleIndex = 4;
            // 
            // colCantitateReceptionata
            // 
            this.colCantitateReceptionata.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateReceptionata.Caption = "Cantitate Receptionata";
            this.colCantitateReceptionata.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateReceptionata.FieldName = "CantitateReceptionata";
            this.colCantitateReceptionata.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateReceptionata.Name = "colCantitateReceptionata";
            this.colCantitateReceptionata.Visible = true;
            this.colCantitateReceptionata.VisibleIndex = 5;
            // 
            // colValoareReceptionata
            // 
            this.colValoareReceptionata.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareReceptionata.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareReceptionata.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareReceptionata.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareReceptionata.Caption = "Valoare receptionata";
            this.colValoareReceptionata.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareReceptionata.FieldName = "ValoareReceptionata";
            this.colValoareReceptionata.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareReceptionata.Name = "colValoareReceptionata";
            this.colValoareReceptionata.Visible = true;
            this.colValoareReceptionata.VisibleIndex = 6;
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
            this.colCantitateDisponibila.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateDisponibila.Name = "colCantitateDisponibila";
            this.colCantitateDisponibila.Visible = true;
            this.colCantitateDisponibila.VisibleIndex = 7;
            // 
            // colValoareDisponibila
            // 
            this.colValoareDisponibila.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareDisponibila.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareDisponibila.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareDisponibila.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareDisponibila.Caption = "Valoare disponibila";
            this.colValoareDisponibila.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareDisponibila.FieldName = "ValoareDisponibila";
            this.colValoareDisponibila.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareDisponibila.Name = "colValoareDisponibila";
            this.colValoareDisponibila.Visible = true;
            this.colValoareDisponibila.VisibleIndex = 8;
            // 
            // colAcordCadru
            // 
            this.colAcordCadru.Caption = "Acord Cadru";
            this.colAcordCadru.FieldName = "AcordCadru";
            this.colAcordCadru.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colAcordCadru.Name = "colAcordCadru";
            this.colAcordCadru.Visible = true;
            this.colAcordCadru.VisibleIndex = 0;
            // 
            // gridViewProcent
            // 
            this.gridViewProcent.ColumnPanelRowHeight = 35;
            this.gridViewProcent.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn11,
            this.gridColumn3});
            this.gridViewProcent.GridControl = this.gridControlLista;
            this.gridViewProcent.GroupRowHeight = 35;
            this.gridViewProcent.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareDisponibila", this.gridColumn11, "")});
            this.gridViewProcent.Name = "gridViewProcent";
            this.gridViewProcent.OptionsBehavior.Editable = false;
            this.gridViewProcent.OptionsBehavior.ReadOnly = true;
            this.gridViewProcent.OptionsView.ShowAutoFilterRow = true;
            this.gridViewProcent.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Centru";
            this.gridColumn1.FieldName = "Centru";
            this.gridColumn1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "Lot";
            this.gridColumn2.FieldName = "Lot";
            this.gridColumn2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn11.Caption = "Procent executie";
            this.gridColumn11.ColumnEdit = this.repositoryItemTextEditSuma;
            this.gridColumn11.FieldName = "Procent";
            this.gridColumn11.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Acord Cadru";
            this.gridColumn3.FieldName = "AcordCadru";
            this.gridColumn3.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // tblListaBindingSource
            // 
            this.tblListaBindingSource.DataMember = "tblLista";
            this.tblListaBindingSource.DataSource = typeof(CommonDataSets.Liste.ExecutieContracteDataSet);
            // 
            // ExecutieContracteReportGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 511);
            this.Name = "ExecutieContracteReportGrid";
            this.Text = "ExecutieContracteReportGrid";
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHeader)).EndInit();
            this.panelControlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindowGrid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditOrientare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDimensiune.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlConfigurareCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProcent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblListaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlLista;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDate;
        private System.Windows.Forms.BindingSource tblListaBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCentru;
        private DevExpress.XtraGrid.Columns.GridColumn colLot;
        private DevExpress.XtraGrid.Columns.GridColumn colProdus;
        private DevExpress.XtraGrid.Columns.GridColumn colUM;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDistribuita;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareCuTva;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateReceptionata;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareReceptionata;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDisponibila;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareDisponibila;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProcent;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn colAcordCadru;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}