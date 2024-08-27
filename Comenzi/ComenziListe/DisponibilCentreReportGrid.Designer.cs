namespace ComenziListe
{
    partial class DisponibilCentreReportGrid
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
            this.gridControlDisponibil = new DevExpress.XtraGrid.GridControl();
            this.tblListaDisponibilBindingSource = new System.Windows.Forms.BindingSource();
            this.gridViewDisponibil = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDenumireLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDenumireProdus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCantitate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareFaraTvaLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareTvaLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareCuTvaLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateReceptionata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareReceptionataFaraTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareReceptionataTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareReceptionata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantitateDisponibila = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareDisponitbilaFaraTva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareDisponibilaTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareDisponibila = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcordCadru = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHeader)).BeginInit();
            this.panelControlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindowGrid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditOrientare.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDimensiune.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlConfigurareCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDisponibil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblListaDisponibilBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDisponibil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
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
            this.panelControl3.Controls.Add(this.gridControlDisponibil);
            this.panelControl3.LookAndFeel.SkinName = "Money Twins";
            this.panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl3.Size = new System.Drawing.Size(588, 477);
            this.panelControl3.Controls.SetChildIndex(this.progressBarControlBaseWindowGrid, 0);
            this.panelControl3.Controls.SetChildIndex(this.gridControlDisponibil, 0);
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
            // gridControlDisponibil
            // 
            this.gridControlDisponibil.DataSource = this.tblListaDisponibilBindingSource;
            this.gridControlDisponibil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDisponibil.Location = new System.Drawing.Point(0, 0);
            this.gridControlDisponibil.MainView = this.gridViewDisponibil;
            this.gridControlDisponibil.Name = "gridControlDisponibil";
            this.gridControlDisponibil.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma});
            this.gridControlDisponibil.Size = new System.Drawing.Size(588, 477);
            this.gridControlDisponibil.TabIndex = 1;
            this.gridControlDisponibil.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDisponibil});
            // 
            // tblListaDisponibilBindingSource
            // 
            this.tblListaDisponibilBindingSource.DataMember = "tblListaDisponibil";
            this.tblListaDisponibilBindingSource.DataSource = typeof(CommonDataSets.GUI.ListaComenziDataSet);
            // 
            // gridViewDisponibil
            // 
            this.gridViewDisponibil.ColumnPanelRowHeight = 35;
            this.gridViewDisponibil.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDenumireLot,
            this.colDenumireProdus,
            this.colUM,
            this.colPret,
            this.colCantitate,
            this.colValoareFaraTvaLot,
            this.colValoareTvaLot,
            this.colValoareCuTvaLot,
            this.colCantitateReceptionata,
            this.colValoareReceptionataFaraTVA,
            this.colValoareReceptionataTVA,
            this.colValoareReceptionata,
            this.colCantitateDisponibila,
            this.colValoareDisponitbilaFaraTva,
            this.colValoareDisponibilaTVA,
            this.colValoareDisponibila,
            this.colAcordCadru});
            this.gridViewDisponibil.GridControl = this.gridControlDisponibil;
            this.gridViewDisponibil.GroupCount = 2;
            this.gridViewDisponibil.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareFaraTvaLot", this.colValoareFaraTvaLot, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareTvaLot", this.colValoareTvaLot, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareDisponibila", this.colValoareDisponibila, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareDisponibilaTVA", this.colValoareDisponibilaTVA, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareDisponitbilaFaraTva", this.colValoareDisponitbilaFaraTva, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareCuTvaLot", this.colValoareCuTvaLot, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareReceptionata", this.colValoareReceptionata, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareReceptionataFaraTVA", this.colValoareReceptionataFaraTVA, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValoareReceptionataTVA", this.colValoareReceptionataTVA, "")});
            this.gridViewDisponibil.Name = "gridViewDisponibil";
            this.gridViewDisponibil.OptionsBehavior.Editable = false;
            this.gridViewDisponibil.OptionsView.AllowCellMerge = true;
            this.gridViewDisponibil.OptionsView.ShowAutoFilterRow = true;
            this.gridViewDisponibil.OptionsView.ShowFooter = true;
            this.gridViewDisponibil.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDenumireLot, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAcordCadru, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colDenumireLot
            // 
            this.colDenumireLot.AppearanceHeader.Options.UseTextOptions = true;
            this.colDenumireLot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDenumireLot.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDenumireLot.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDenumireLot.Caption = "LOT";
            this.colDenumireLot.CustomizationCaption = "LOT";
            this.colDenumireLot.FieldName = "DenumireLot";
            this.colDenumireLot.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDenumireLot.Name = "colDenumireLot";
            this.colDenumireLot.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colDenumireLot.Visible = true;
            this.colDenumireLot.VisibleIndex = 0;
            // 
            // colDenumireProdus
            // 
            this.colDenumireProdus.AppearanceHeader.Options.UseTextOptions = true;
            this.colDenumireProdus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDenumireProdus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDenumireProdus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDenumireProdus.Caption = "DENUMIRE PRODUS";
            this.colDenumireProdus.CustomizationCaption = "DENUMIRE PRODUS";
            this.colDenumireProdus.FieldName = "DenumireProdus";
            this.colDenumireProdus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDenumireProdus.Name = "colDenumireProdus";
            this.colDenumireProdus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDenumireProdus.Visible = true;
            this.colDenumireProdus.VisibleIndex = 0;
            // 
            // colUM
            // 
            this.colUM.AppearanceHeader.Options.UseTextOptions = true;
            this.colUM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUM.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUM.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUM.Caption = "U.M.";
            this.colUM.CustomizationCaption = "U.M.";
            this.colUM.FieldName = "UM";
            this.colUM.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colUM.Name = "colUM";
            this.colUM.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colUM.Visible = true;
            this.colUM.VisibleIndex = 1;
            // 
            // colPret
            // 
            this.colPret.AppearanceHeader.Options.UseTextOptions = true;
            this.colPret.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPret.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPret.Caption = "PRET";
            this.colPret.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colPret.CustomizationCaption = "PRET";
            this.colPret.FieldName = "Pret";
            this.colPret.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPret.Name = "colPret";
            this.colPret.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPret.Visible = true;
            this.colPret.VisibleIndex = 2;
            // 
            // repositoryItemTextEditSuma
            // 
            this.repositoryItemTextEditSuma.AutoHeight = false;
            this.repositoryItemTextEditSuma.Name = "repositoryItemTextEditSuma";
            // 
            // colCantitate
            // 
            this.colCantitate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitate.Caption = "CANTITATE LICITATA";
            this.colCantitate.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitate.CustomizationCaption = "CANTITATE LICITATA";
            this.colCantitate.FieldName = "Cantitate";
            this.colCantitate.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitate.Name = "colCantitate";
            this.colCantitate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCantitate.Visible = true;
            this.colCantitate.VisibleIndex = 3;
            // 
            // colValoareFaraTvaLot
            // 
            this.colValoareFaraTvaLot.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareFaraTvaLot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareFaraTvaLot.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareFaraTvaLot.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareFaraTvaLot.Caption = "VALOARE FARA TVA";
            this.colValoareFaraTvaLot.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareFaraTvaLot.CustomizationCaption = "VALOARE FARA TVA";
            this.colValoareFaraTvaLot.FieldName = "ValoareFaraTvaLot";
            this.colValoareFaraTvaLot.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareFaraTvaLot.Name = "colValoareFaraTvaLot";
            this.colValoareFaraTvaLot.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValoareFaraTvaLot.OptionsColumn.ReadOnly = true;
            this.colValoareFaraTvaLot.Visible = true;
            this.colValoareFaraTvaLot.VisibleIndex = 4;
            // 
            // colValoareTvaLot
            // 
            this.colValoareTvaLot.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareTvaLot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareTvaLot.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareTvaLot.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareTvaLot.Caption = "VALOARE TVA";
            this.colValoareTvaLot.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareTvaLot.CustomizationCaption = "VALOARE TVA";
            this.colValoareTvaLot.FieldName = "ValoareTvaLot";
            this.colValoareTvaLot.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareTvaLot.Name = "colValoareTvaLot";
            this.colValoareTvaLot.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValoareTvaLot.OptionsColumn.ReadOnly = true;
            this.colValoareTvaLot.Visible = true;
            this.colValoareTvaLot.VisibleIndex = 5;
            // 
            // colValoareCuTvaLot
            // 
            this.colValoareCuTvaLot.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareCuTvaLot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareCuTvaLot.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareCuTvaLot.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareCuTvaLot.Caption = "VALOARE CU TVA";
            this.colValoareCuTvaLot.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareCuTvaLot.CustomizationCaption = "VALOARE CU TVA";
            this.colValoareCuTvaLot.FieldName = "ValoareCuTvaLot";
            this.colValoareCuTvaLot.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareCuTvaLot.Name = "colValoareCuTvaLot";
            this.colValoareCuTvaLot.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValoareCuTvaLot.OptionsColumn.ReadOnly = true;
            this.colValoareCuTvaLot.Visible = true;
            this.colValoareCuTvaLot.VisibleIndex = 6;
            // 
            // colCantitateReceptionata
            // 
            this.colCantitateReceptionata.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateReceptionata.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateReceptionata.Caption = "CANTITATE CONSUMATA";
            this.colCantitateReceptionata.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateReceptionata.CustomizationCaption = "CANTITATE CONSUMATA";
            this.colCantitateReceptionata.FieldName = "CantitateReceptionata";
            this.colCantitateReceptionata.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateReceptionata.Name = "colCantitateReceptionata";
            this.colCantitateReceptionata.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCantitateReceptionata.OptionsColumn.ReadOnly = true;
            this.colCantitateReceptionata.Visible = true;
            this.colCantitateReceptionata.VisibleIndex = 7;
            // 
            // colValoareReceptionataFaraTVA
            // 
            this.colValoareReceptionataFaraTVA.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareReceptionataFaraTVA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareReceptionataFaraTVA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareReceptionataFaraTVA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareReceptionataFaraTVA.Caption = "VALOARE FARA TVA";
            this.colValoareReceptionataFaraTVA.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareReceptionataFaraTVA.CustomizationCaption = "VALOARE FARA TVA";
            this.colValoareReceptionataFaraTVA.FieldName = "ValoareReceptionataFaraTVA";
            this.colValoareReceptionataFaraTVA.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareReceptionataFaraTVA.Name = "colValoareReceptionataFaraTVA";
            this.colValoareReceptionataFaraTVA.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValoareReceptionataFaraTVA.OptionsColumn.ReadOnly = true;
            this.colValoareReceptionataFaraTVA.Visible = true;
            this.colValoareReceptionataFaraTVA.VisibleIndex = 8;
            // 
            // colValoareReceptionataTVA
            // 
            this.colValoareReceptionataTVA.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareReceptionataTVA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareReceptionataTVA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareReceptionataTVA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareReceptionataTVA.Caption = "VALOARE TVA";
            this.colValoareReceptionataTVA.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareReceptionataTVA.CustomizationCaption = "VALOARE TVA";
            this.colValoareReceptionataTVA.FieldName = "ValoareReceptionataTVA";
            this.colValoareReceptionataTVA.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareReceptionataTVA.Name = "colValoareReceptionataTVA";
            this.colValoareReceptionataTVA.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValoareReceptionataTVA.OptionsColumn.ReadOnly = true;
            this.colValoareReceptionataTVA.Visible = true;
            this.colValoareReceptionataTVA.VisibleIndex = 9;
            // 
            // colValoareReceptionata
            // 
            this.colValoareReceptionata.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareReceptionata.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareReceptionata.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareReceptionata.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareReceptionata.Caption = "VALOARE CU TVA";
            this.colValoareReceptionata.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareReceptionata.CustomizationCaption = "VALOARE CU TVA";
            this.colValoareReceptionata.FieldName = "ValoareReceptionata";
            this.colValoareReceptionata.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareReceptionata.Name = "colValoareReceptionata";
            this.colValoareReceptionata.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValoareReceptionata.OptionsColumn.ReadOnly = true;
            this.colValoareReceptionata.Visible = true;
            this.colValoareReceptionata.VisibleIndex = 10;
            // 
            // colCantitateDisponibila
            // 
            this.colCantitateDisponibila.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCantitateDisponibila.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCantitateDisponibila.Caption = "CANTITATE RAMASA";
            this.colCantitateDisponibila.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitateDisponibila.CustomizationCaption = "CANTITATE RAMASA";
            this.colCantitateDisponibila.FieldName = "CantitateDisponibila";
            this.colCantitateDisponibila.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCantitateDisponibila.Name = "colCantitateDisponibila";
            this.colCantitateDisponibila.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCantitateDisponibila.OptionsColumn.ReadOnly = true;
            this.colCantitateDisponibila.Visible = true;
            this.colCantitateDisponibila.VisibleIndex = 11;
            // 
            // colValoareDisponitbilaFaraTva
            // 
            this.colValoareDisponitbilaFaraTva.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareDisponitbilaFaraTva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareDisponitbilaFaraTva.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareDisponitbilaFaraTva.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareDisponitbilaFaraTva.Caption = "VALOARE FARA TVA";
            this.colValoareDisponitbilaFaraTva.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareDisponitbilaFaraTva.CustomizationCaption = "VALOARE FARA TVA";
            this.colValoareDisponitbilaFaraTva.FieldName = "ValoareDisponitbilaFaraTva";
            this.colValoareDisponitbilaFaraTva.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareDisponitbilaFaraTva.Name = "colValoareDisponitbilaFaraTva";
            this.colValoareDisponitbilaFaraTva.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValoareDisponitbilaFaraTva.OptionsColumn.ReadOnly = true;
            this.colValoareDisponitbilaFaraTva.Visible = true;
            this.colValoareDisponitbilaFaraTva.VisibleIndex = 12;
            // 
            // colValoareDisponibilaTVA
            // 
            this.colValoareDisponibilaTVA.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareDisponibilaTVA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareDisponibilaTVA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareDisponibilaTVA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareDisponibilaTVA.Caption = "VALOARE TVA";
            this.colValoareDisponibilaTVA.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareDisponibilaTVA.CustomizationCaption = "VALOARE TVA";
            this.colValoareDisponibilaTVA.FieldName = "ValoareDisponibilaTVA";
            this.colValoareDisponibilaTVA.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareDisponibilaTVA.Name = "colValoareDisponibilaTVA";
            this.colValoareDisponibilaTVA.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValoareDisponibilaTVA.OptionsColumn.ReadOnly = true;
            this.colValoareDisponibilaTVA.Visible = true;
            this.colValoareDisponibilaTVA.VisibleIndex = 13;
            // 
            // colValoareDisponibila
            // 
            this.colValoareDisponibila.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareDisponibila.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareDisponibila.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareDisponibila.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareDisponibila.Caption = "VALOARE CU TVA";
            this.colValoareDisponibila.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareDisponibila.CustomizationCaption = "VALOARE CU TVA";
            this.colValoareDisponibila.FieldName = "ValoareDisponibila";
            this.colValoareDisponibila.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colValoareDisponibila.Name = "colValoareDisponibila";
            this.colValoareDisponibila.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValoareDisponibila.OptionsColumn.ReadOnly = true;
            this.colValoareDisponibila.Visible = true;
            this.colValoareDisponibila.VisibleIndex = 14;
            // 
            // colAcordCadru
            // 
            this.colAcordCadru.Caption = "Acord Cadru";
            this.colAcordCadru.FieldName = "AcordCadru";
            this.colAcordCadru.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colAcordCadru.Name = "colAcordCadru";
            this.colAcordCadru.Visible = true;
            this.colAcordCadru.VisibleIndex = 15;
            // 
            // DisponibilCentreReportGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 511);
            this.Name = "DisponibilCentreReportGrid";
            this.Text = "DisponibilCentreReportGrid";
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHeader)).EndInit();
            this.panelControlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindowGrid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditOrientare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDimensiune.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlConfigurareCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDisponibil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblListaDisponibilBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDisponibil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDisponibil;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDisponibil;
        private System.Windows.Forms.BindingSource tblListaDisponibilBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumireLot;
        private DevExpress.XtraGrid.Columns.GridColumn colDenumireProdus;
        private DevExpress.XtraGrid.Columns.GridColumn colUM;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitate;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareFaraTvaLot;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareTvaLot;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareCuTvaLot;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateReceptionata;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareReceptionataFaraTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareReceptionataTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareReceptionata;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitateDisponibila;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareDisponitbilaFaraTva;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareDisponibilaTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareDisponibila;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
        private DevExpress.XtraGrid.Columns.GridColumn colAcordCadru;

    }
}