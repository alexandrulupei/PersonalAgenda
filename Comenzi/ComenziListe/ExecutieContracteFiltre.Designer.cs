namespace ComenziListe
{
    partial class ExecutieContracteFiltre
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
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonListare = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditCentru = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditLot = new DevExpress.XtraEditors.LookUpEdit();
            this.radioGroupTipLista = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCentru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupTipLista.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Controls.Add(this.simpleButtonListare);
            this.panelControl1.Controls.Add(this.lookUpEditCentru);
            this.panelControl1.Controls.Add(this.lookUpEditLot);
            this.panelControl1.Controls.Add(this.radioGroupTipLista);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(292, 266);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Location = new System.Drawing.Point(185, 231);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "Renunta";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonListare
            // 
            this.simpleButtonListare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonListare.Location = new System.Drawing.Point(104, 231);
            this.simpleButtonListare.Name = "simpleButtonListare";
            this.simpleButtonListare.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonListare.TabIndex = 8;
            this.simpleButtonListare.Text = "Listeaza";
            this.simpleButtonListare.Click += new System.EventHandler(this.simpleButtonListare_Click);
            // 
            // lookUpEditCentru
            // 
            this.lookUpEditCentru.Location = new System.Drawing.Point(102, 51);
            this.lookUpEditCentru.Name = "lookUpEditCentru";
            this.lookUpEditCentru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCentru.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Centru")});
            this.lookUpEditCentru.Properties.NullText = "";
            this.lookUpEditCentru.Size = new System.Drawing.Size(158, 20);
            this.lookUpEditCentru.TabIndex = 4;
            // 
            // lookUpEditLot
            // 
            this.lookUpEditLot.Location = new System.Drawing.Point(102, 23);
            this.lookUpEditLot.Name = "lookUpEditLot";
            this.lookUpEditLot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditLot.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Lot")});
            this.lookUpEditLot.Properties.NullText = "";
            this.lookUpEditLot.Size = new System.Drawing.Size(158, 20);
            this.lookUpEditLot.TabIndex = 3;
            // 
            // radioGroupTipLista
            // 
            this.radioGroupTipLista.Location = new System.Drawing.Point(31, 102);
            this.radioGroupTipLista.Name = "radioGroupTipLista";
            this.radioGroupTipLista.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Executie Contracte"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Procent executie contracte")});
            this.radioGroupTipLista.Size = new System.Drawing.Size(229, 49);
            this.radioGroupTipLista.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Centru";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(15, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Lot";
            // 
            // ExecutieContracteFiltre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.panelControl1);
            this.Name = "ExecutieContracteFiltre";
            this.Text = "ExecutieContracteFiltre";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCentru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupTipLista.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCentru;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditLot;
        private DevExpress.XtraEditors.RadioGroup radioGroupTipLista;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonListare;
    }
}