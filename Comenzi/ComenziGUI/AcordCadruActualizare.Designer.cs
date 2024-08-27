namespace ComenziGUI
{
    partial class AcordCadruActualizare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcordCadruActualizare));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonRenunta = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSalvare = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlAcordCadru = new DevExpress.XtraGrid.GridControl();
            this.tblAcordCadruDetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewAcordCadru = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcordCadruID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditProdus = new ComenziGUI.RepositoryItemButtonEditAlege();
            this.colPret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditSuma = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colCantitate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareTVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValoareCuTva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCotaTVAID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditCotaTva = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.groupControlAcordBase = new DevExpress.XtraEditors.GroupControl();
            this.dateEditDataStop = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditTipCentru = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonEditAlegeCodPartener = new ComenziGUI.ButtonEditAlege();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEditDenumie = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ucDataLucru = new CommonGUIControllers.UC.UCData();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAcordCadru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAcordCadruDetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAcordCadru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditProdus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditCotaTva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAcordBase)).BeginInit();
            this.groupControlAcordBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStop.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTipCentru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditAlegeCodPartener.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDenumie.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonRenunta);
            this.panelControl1.Controls.Add(this.simpleButtonSalvare);
            this.panelControl1.Controls.Add(this.gridControlAcordCadru);
            this.panelControl1.Controls.Add(this.groupControlAcordBase);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(853, 470);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonRenunta
            // 
            this.simpleButtonRenunta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonRenunta.Location = new System.Drawing.Point(773, 442);
            this.simpleButtonRenunta.Name = "simpleButtonRenunta";
            this.simpleButtonRenunta.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonRenunta.TabIndex = 6;
            this.simpleButtonRenunta.Text = "Renunta";
            this.simpleButtonRenunta.Click += new System.EventHandler(this.simpleButtonRenunta_Click);
            // 
            // simpleButtonSalvare
            // 
            this.simpleButtonSalvare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSalvare.Location = new System.Drawing.Point(692, 442);
            this.simpleButtonSalvare.Name = "simpleButtonSalvare";
            this.simpleButtonSalvare.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSalvare.TabIndex = 5;
            this.simpleButtonSalvare.Text = "Salvare";
            this.simpleButtonSalvare.Click += new System.EventHandler(this.simpleButtonSalvare_Click);
            // 
            // gridControlAcordCadru
            // 
            this.gridControlAcordCadru.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlAcordCadru.DataSource = this.tblAcordCadruDetBindingSource;
            this.gridControlAcordCadru.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControlAcordCadru.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControlAcordCadru.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControlAcordCadru.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControlAcordCadru.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControlAcordCadru.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gridControlAcordCadru.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControlAcordCadru.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gridControlAcordCadru.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControlAcordCadru.Location = new System.Drawing.Point(0, 84);
            this.gridControlAcordCadru.MainView = this.gridViewAcordCadru;
            this.gridControlAcordCadru.Name = "gridControlAcordCadru";
            this.gridControlAcordCadru.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditSuma,
            this.repositoryItemButtonEditProdus,
            this.repositoryItemLookUpEditCotaTva});
            this.gridControlAcordCadru.Size = new System.Drawing.Size(853, 319);
            this.gridControlAcordCadru.TabIndex = 2;
            this.gridControlAcordCadru.UseEmbeddedNavigator = true;
            this.gridControlAcordCadru.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAcordCadru});
            // 
            // tblAcordCadruDetBindingSource
            // 
            this.tblAcordCadruDetBindingSource.DataMember = "tblAcordCadruDet";
            this.tblAcordCadruDetBindingSource.DataSource = typeof(CommonDataSets.GUI.AcordCadruDataSet);
            // 
            // gridViewAcordCadru
            // 
            this.gridViewAcordCadru.ColumnPanelRowHeight = 35;
            this.gridViewAcordCadru.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colAcordCadruID,
            this.colProduseID,
            this.colPret,
            this.colCantitate,
            this.colValoare,
            this.colValoareTVA,
            this.colValoareCuTva,
            this.colCotaTVAID});
            this.gridViewAcordCadru.GridControl = this.gridControlAcordCadru;
            this.gridViewAcordCadru.Name = "gridViewAcordCadru";
            this.gridViewAcordCadru.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewAcordCadru.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPret, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewAcordCadru.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewAcordCadru_InitNewRow);
            this.gridViewAcordCadru.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewAcordCadru_CellValueChanged);
            this.gridViewAcordCadru.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridViewAcordCadru_InvalidRowException);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.ReadOnly = true;
            // 
            // colAcordCadruID
            // 
            this.colAcordCadruID.FieldName = "AcordCadruID";
            this.colAcordCadruID.Name = "colAcordCadruID";
            // 
            // colProduseID
            // 
            this.colProduseID.AppearanceHeader.Options.UseTextOptions = true;
            this.colProduseID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProduseID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProduseID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProduseID.Caption = "Produs";
            this.colProduseID.ColumnEdit = this.repositoryItemButtonEditProdus;
            this.colProduseID.FieldName = "ProduseID";
            this.colProduseID.Name = "colProduseID";
            this.colProduseID.Visible = true;
            this.colProduseID.VisibleIndex = 0;
            // 
            // repositoryItemButtonEditProdus
            // 
            this.repositoryItemButtonEditProdus.AutoHeight = false;
            this.repositoryItemButtonEditProdus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEditProdus.CustomFieldsAlegeList = ((System.Collections.Generic.SortedList<string, object>)(resources.GetObject("repositoryItemButtonEditProdus.CustomFieldsAlegeList")));
            this.repositoryItemButtonEditProdus.DataSource = null;
            this.repositoryItemButtonEditProdus.Name = "repositoryItemButtonEditProdus";
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
            this.colPret.Name = "colPret";
            this.colPret.OptionsColumn.AllowEdit = false;
            this.colPret.OptionsColumn.ReadOnly = true;
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
            this.colCantitate.Caption = "Cantitate";
            this.colCantitate.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colCantitate.FieldName = "Cantitate";
            this.colCantitate.Name = "colCantitate";
            this.colCantitate.Visible = true;
            this.colCantitate.VisibleIndex = 3;
            // 
            // colValoare
            // 
            this.colValoare.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoare.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoare.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoare.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoare.Caption = "Valoare";
            this.colValoare.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoare.FieldName = "Valoare";
            this.colValoare.Name = "colValoare";
            this.colValoare.OptionsColumn.AllowEdit = false;
            this.colValoare.OptionsColumn.ReadOnly = true;
            this.colValoare.Visible = true;
            this.colValoare.VisibleIndex = 4;
            // 
            // colValoareTVA
            // 
            this.colValoareTVA.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareTVA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareTVA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareTVA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareTVA.Caption = "Valoare TVA";
            this.colValoareTVA.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareTVA.FieldName = "ValoareTVA";
            this.colValoareTVA.Name = "colValoareTVA";
            this.colValoareTVA.OptionsColumn.AllowEdit = false;
            this.colValoareTVA.OptionsColumn.ReadOnly = true;
            this.colValoareTVA.Visible = true;
            this.colValoareTVA.VisibleIndex = 5;
            // 
            // colValoareCuTva
            // 
            this.colValoareCuTva.AppearanceHeader.Options.UseTextOptions = true;
            this.colValoareCuTva.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValoareCuTva.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValoareCuTva.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValoareCuTva.Caption = "Valoare cu TVA";
            this.colValoareCuTva.ColumnEdit = this.repositoryItemTextEditSuma;
            this.colValoareCuTva.FieldName = "ValoareCuTva";
            this.colValoareCuTva.Name = "colValoareCuTva";
            this.colValoareCuTva.OptionsColumn.AllowEdit = false;
            this.colValoareCuTva.OptionsColumn.ReadOnly = true;
            this.colValoareCuTva.Visible = true;
            this.colValoareCuTva.VisibleIndex = 6;
            // 
            // colCotaTVAID
            // 
            this.colCotaTVAID.AppearanceHeader.Options.UseTextOptions = true;
            this.colCotaTVAID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCotaTVAID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCotaTVAID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCotaTVAID.Caption = "Cota TVA";
            this.colCotaTVAID.ColumnEdit = this.repositoryItemLookUpEditCotaTva;
            this.colCotaTVAID.FieldName = "CotaTVAID";
            this.colCotaTVAID.Name = "colCotaTVAID";
            this.colCotaTVAID.OptionsColumn.AllowEdit = false;
            this.colCotaTVAID.OptionsColumn.ReadOnly = true;
            this.colCotaTVAID.Visible = true;
            this.colCotaTVAID.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEditCotaTva
            // 
            this.repositoryItemLookUpEditCotaTva.AutoHeight = false;
            this.repositoryItemLookUpEditCotaTva.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditCotaTva.Name = "repositoryItemLookUpEditCotaTva";
            this.repositoryItemLookUpEditCotaTva.NullText = "";
            // 
            // groupControlAcordBase
            // 
            this.groupControlAcordBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlAcordBase.Controls.Add(this.dateEditDataStop);
            this.groupControlAcordBase.Controls.Add(this.labelControl5);
            this.groupControlAcordBase.Controls.Add(this.labelControl3);
            this.groupControlAcordBase.Controls.Add(this.lookUpEditTipCentru);
            this.groupControlAcordBase.Controls.Add(this.buttonEditAlegeCodPartener);
            this.groupControlAcordBase.Controls.Add(this.labelControl4);
            this.groupControlAcordBase.Controls.Add(this.textEditDenumie);
            this.groupControlAcordBase.Controls.Add(this.labelControl2);
            this.groupControlAcordBase.Controls.Add(this.ucDataLucru);
            this.groupControlAcordBase.Controls.Add(this.labelControl1);
            this.groupControlAcordBase.Location = new System.Drawing.Point(0, 0);
            this.groupControlAcordBase.Name = "groupControlAcordBase";
            this.groupControlAcordBase.Size = new System.Drawing.Size(853, 84);
            this.groupControlAcordBase.TabIndex = 1;
            this.groupControlAcordBase.Text = "Date Acord Cadru";
            // 
            // dateEditDataStop
            // 
            this.dateEditDataStop.EditValue = null;
            this.dateEditDataStop.Location = new System.Drawing.Point(343, 33);
            this.dateEditDataStop.Name = "dateEditDataStop";
            this.dateEditDataStop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDataStop.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditDataStop.Size = new System.Drawing.Size(165, 20);
            this.dateEditDataStop.TabIndex = 11;
            this.dateEditDataStop.Validated += new System.EventHandler(this.dateEditDataStop_Validated);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(289, 37);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 13);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Data Stop";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(665, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Tip Centru";
            // 
            // lookUpEditTipCentru
            // 
            this.lookUpEditTipCentru.Location = new System.Drawing.Point(721, 33);
            this.lookUpEditTipCentru.Name = "lookUpEditTipCentru";
            this.lookUpEditTipCentru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTipCentru.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Tip Centru")});
            this.lookUpEditTipCentru.Properties.DisplayMember = "Description";
            this.lookUpEditTipCentru.Properties.NullText = "";
            this.lookUpEditTipCentru.Properties.ValueMember = "ID";
            this.lookUpEditTipCentru.Size = new System.Drawing.Size(118, 20);
            this.lookUpEditTipCentru.TabIndex = 8;
            this.lookUpEditTipCentru.EditValueChanged += new System.EventHandler(this.lookUpEditTipCentru_EditValueChanged);
            // 
            // buttonEditAlegeCodPartener
            // 
            this.buttonEditAlegeCodPartener.CustomFieldsAlegeList = ((System.Collections.Generic.SortedList<string, object>)(resources.GetObject("buttonEditAlegeCodPartener.CustomFieldsAlegeList")));
            this.buttonEditAlegeCodPartener.DataSource = null;
            this.buttonEditAlegeCodPartener.Location = new System.Drawing.Point(559, 33);
            this.buttonEditAlegeCodPartener.Name = "buttonEditAlegeCodPartener";
            this.buttonEditAlegeCodPartener.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditAlegeCodPartener.Size = new System.Drawing.Size(100, 20);
            this.buttonEditAlegeCodPartener.TabIndex = 7;
            this.buttonEditAlegeCodPartener.EditValueChanged += new System.EventHandler(this.buttonEditAlegeCodPartener_EditValueChanged);
            this.buttonEditAlegeCodPartener.Validated += new System.EventHandler(this.buttonEditAlegeCodPartener_Validated);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(514, 37);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Furnizor";
            // 
            // textEditDenumie
            // 
            this.textEditDenumie.Location = new System.Drawing.Point(86, 58);
            this.textEditDenumie.Name = "textEditDenumie";
            this.textEditDenumie.Size = new System.Drawing.Size(753, 20);
            this.textEditDenumie.TabIndex = 3;
            this.textEditDenumie.EditValueChanged += new System.EventHandler(this.textEditDenumie_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Denumire acord";
            // 
            // ucDataLucru
            // 
            this.ucDataLucru.DisplayController = null;
            this.ucDataLucru.Location = new System.Drawing.Point(86, 31);
            this.ucDataLucru.Name = "ucDataLucru";
            this.ucDataLucru.ParameterList = null;
            this.ucDataLucru.Size = new System.Drawing.Size(197, 25);
            this.ucDataLucru.TabIndex = 1;
            this.ucDataLucru.UserDateTime = new System.DateTime(1, 1, 1, 15, 30, 59, 0);
            this.ucDataLucru.Validated += new System.EventHandler(this.ucDataLucru_Validated);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Data Start";
            // 
            // AcordCadruActualizare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 470);
            this.Controls.Add(this.panelControl1);
            this.Name = "AcordCadruActualizare";
            this.Text = "AcordCadruActualizare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AcordCadruActualizare_FormClosing);
            this.Load += new System.EventHandler(this.AcordCadruActualizare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAcordCadru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAcordCadruDetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAcordCadru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditProdus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditSuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditCotaTva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAcordBase)).EndInit();
            this.groupControlAcordBase.ResumeLayout(false);
            this.groupControlAcordBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStop.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTipCentru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditAlegeCodPartener.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDenumie.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControlAcordBase;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditTipCentru;
        private ButtonEditAlege buttonEditAlegeCodPartener;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEditDenumie;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private CommonGUIControllers.UC.UCData ucDataLucru;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControlAcordCadru;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAcordCadru;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRenunta;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSalvare;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit dateEditDataStop;
        private System.Windows.Forms.BindingSource tblAcordCadruDetBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colAcordCadruID;
        private DevExpress.XtraGrid.Columns.GridColumn colProduseID;
        private DevExpress.XtraGrid.Columns.GridColumn colCantitate;
        private DevExpress.XtraGrid.Columns.GridColumn colValoare;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareTVA;
        private DevExpress.XtraGrid.Columns.GridColumn colValoareCuTva;
        private DevExpress.XtraGrid.Columns.GridColumn colCotaTVAID;
        private DevExpress.XtraGrid.Columns.GridColumn colPret;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSuma;
        private ComenziGUI.RepositoryItemButtonEditAlege repositoryItemButtonEditProdus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditCotaTva;
    }
}