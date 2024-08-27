namespace ComenziListe
{
    partial class ListaComenziFiltru
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lookUpEditLot = new DevExpress.XtraEditors.LookUpEdit();
            this.tblLotBaseBindingSource = new System.Windows.Forms.BindingSource();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditFurnizor = new DevExpress.XtraEditors.LookUpEdit();
            this.tblPartenerDataTableBindingSource = new System.Windows.Forms.BindingSource();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonListare = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditTipCentru = new DevExpress.XtraEditors.LookUpEdit();
            this.tbxTipCentruBindingSource = new System.Windows.Forms.BindingSource();
            this.dateEditDataStop = new DevExpress.XtraEditors.DateEdit();
            this.dateEditDataStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLotBaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFurnizor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPartenerDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTipCentru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipCentruBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStop.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStart.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lookUpEditLot);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.lookUpEditFurnizor);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Controls.Add(this.simpleButtonListare);
            this.panelControl1.Controls.Add(this.lookUpEditTipCentru);
            this.panelControl1.Controls.Add(this.dateEditDataStop);
            this.panelControl1.Controls.Add(this.dateEditDataStart);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(288, 233);
            this.panelControl1.TabIndex = 0;
            // 
            // lookUpEditLot
            // 
            this.lookUpEditLot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEditLot.Location = new System.Drawing.Point(113, 139);
            this.lookUpEditLot.Name = "lookUpEditLot";
            this.lookUpEditLot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditLot.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Lot")});
            this.lookUpEditLot.Properties.DataSource = this.tblLotBaseBindingSource;
            this.lookUpEditLot.Properties.DisplayMember = "Denumire";
            this.lookUpEditLot.Properties.NullText = "";
            this.lookUpEditLot.Properties.ValueMember = "ID";
            this.lookUpEditLot.Size = new System.Drawing.Size(147, 20);
            this.lookUpEditLot.TabIndex = 11;
            // 
            // tblLotBaseBindingSource
            // 
            this.tblLotBaseBindingSource.DataMember = "tblLotBase";
            this.tblLotBaseBindingSource.DataSource = typeof(CommonDataSets.GUI.ListaComenziDataSet);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 142);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(15, 13);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Lot";
            // 
            // lookUpEditFurnizor
            // 
            this.lookUpEditFurnizor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEditFurnizor.Location = new System.Drawing.Point(113, 113);
            this.lookUpEditFurnizor.Name = "lookUpEditFurnizor";
            this.lookUpEditFurnizor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditFurnizor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Cod"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Denumire")});
            this.lookUpEditFurnizor.Properties.DataSource = this.tblPartenerDataTableBindingSource;
            this.lookUpEditFurnizor.Properties.DisplayMember = "Denumire";
            this.lookUpEditFurnizor.Properties.NullText = "";
            this.lookUpEditFurnizor.Properties.ValueMember = "ID";
            this.lookUpEditFurnizor.Size = new System.Drawing.Size(147, 20);
            this.lookUpEditFurnizor.TabIndex = 9;
            // 
            // tblPartenerDataTableBindingSource
            // 
            this.tblPartenerDataTableBindingSource.DataSource = typeof(CommonDataSets.GUI.ListaComenziDataSet.tblPartenerDataTable);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 116);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Furnizor";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Location = new System.Drawing.Point(195, 188);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 7;
            this.simpleButtonCancel.Text = "Renunta";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonListare
            // 
            this.simpleButtonListare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonListare.Location = new System.Drawing.Point(114, 188);
            this.simpleButtonListare.Name = "simpleButtonListare";
            this.simpleButtonListare.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonListare.TabIndex = 6;
            this.simpleButtonListare.Text = "Listeaza";
            this.simpleButtonListare.Click += new System.EventHandler(this.simpleButtonListare_Click);
            // 
            // lookUpEditTipCentru
            // 
            this.lookUpEditTipCentru.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEditTipCentru.Location = new System.Drawing.Point(113, 84);
            this.lookUpEditTipCentru.Name = "lookUpEditTipCentru";
            this.lookUpEditTipCentru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTipCentru.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbreviation", "Cod"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Denumire")});
            this.lookUpEditTipCentru.Properties.DataSource = this.tbxTipCentruBindingSource;
            this.lookUpEditTipCentru.Properties.DisplayMember = "Description";
            this.lookUpEditTipCentru.Properties.NullText = "";
            this.lookUpEditTipCentru.Size = new System.Drawing.Size(148, 20);
            this.lookUpEditTipCentru.TabIndex = 5;
            // 
            // tbxTipCentruBindingSource
            // 
            this.tbxTipCentruBindingSource.DataMember = "tbxTipCentru";
            this.tbxTipCentruBindingSource.DataSource = typeof(CommonDataSets.GUI.ListaComenziDataSet);
            // 
            // dateEditDataStop
            // 
            this.dateEditDataStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEditDataStop.EditValue = null;
            this.dateEditDataStop.Location = new System.Drawing.Point(113, 58);
            this.dateEditDataStop.Name = "dateEditDataStop";
            this.dateEditDataStop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDataStop.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditDataStop.Size = new System.Drawing.Size(148, 20);
            this.dateEditDataStop.TabIndex = 4;
            // 
            // dateEditDataStart
            // 
            this.dateEditDataStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEditDataStart.EditValue = null;
            this.dateEditDataStart.Location = new System.Drawing.Point(113, 30);
            this.dateEditDataStart.Name = "dateEditDataStart";
            this.dateEditDataStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDataStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditDataStart.Size = new System.Drawing.Size(148, 20);
            this.dateEditDataStart.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 87);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Tip centru";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Pana la data";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "De la data";
            // 
            // ListaComenziFiltru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 233);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaComenziFiltru";
            this.Text = "ListaComenziFiltru";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLotBaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFurnizor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPartenerDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTipCentru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipCentruBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStop.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDataStart.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonListare;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditTipCentru;
        private DevExpress.XtraEditors.DateEdit dateEditDataStop;
        private DevExpress.XtraEditors.DateEdit dateEditDataStart;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.BindingSource tbxTipCentruBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditLot;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditFurnizor;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.BindingSource tblLotBaseBindingSource;
        private System.Windows.Forms.BindingSource tblPartenerDataTableBindingSource;
    }
}