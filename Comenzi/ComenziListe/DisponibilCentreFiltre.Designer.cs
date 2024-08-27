namespace ComenziListe
{
    partial class DisponibilCentreFiltre
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
            this.lookUpEditLot = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditFurnizor = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFurnizor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Controls.Add(this.simpleButtonListare);
            this.panelControl1.Controls.Add(this.lookUpEditLot);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.lookUpEditFurnizor);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(295, 117);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Location = new System.Drawing.Point(192, 79);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(78, 26);
            this.simpleButtonCancel.TabIndex = 31;
            this.simpleButtonCancel.Text = "Renunta";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonListare
            // 
            this.simpleButtonListare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonListare.Location = new System.Drawing.Point(111, 79);
            this.simpleButtonListare.Name = "simpleButtonListare";
            this.simpleButtonListare.Size = new System.Drawing.Size(78, 26);
            this.simpleButtonListare.TabIndex = 30;
            this.simpleButtonListare.Text = "Listeaza";
            this.simpleButtonListare.Click += new System.EventHandler(this.simpleButtonListare_Click);
            // 
            // lookUpEditLot
            // 
            this.lookUpEditLot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEditLot.Location = new System.Drawing.Point(116, 38);
            this.lookUpEditLot.Name = "lookUpEditLot";
            this.lookUpEditLot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditLot.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Lot")});
            this.lookUpEditLot.Properties.DisplayMember = "Denumire";
            this.lookUpEditLot.Properties.NullText = "";
            this.lookUpEditLot.Properties.ValueMember = "ID";
            this.lookUpEditLot.Size = new System.Drawing.Size(154, 20);
            this.lookUpEditLot.TabIndex = 29;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(20, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(15, 13);
            this.labelControl5.TabIndex = 28;
            this.labelControl5.Text = "Lot";
            // 
            // lookUpEditFurnizor
            // 
            this.lookUpEditFurnizor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEditFurnizor.Location = new System.Drawing.Point(116, 12);
            this.lookUpEditFurnizor.Name = "lookUpEditFurnizor";
            this.lookUpEditFurnizor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditFurnizor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Cod"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Denumire", "Denumire")});
            this.lookUpEditFurnizor.Properties.DisplayMember = "Denumire";
            this.lookUpEditFurnizor.Properties.NullText = "";
            this.lookUpEditFurnizor.Properties.ValueMember = "ID";
            this.lookUpEditFurnizor.Size = new System.Drawing.Size(154, 20);
            this.lookUpEditFurnizor.TabIndex = 27;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(20, 14);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Furnizor";
            // 
            // DisponibilCentreFiltre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 117);
            this.Controls.Add(this.panelControl1);
            this.Name = "DisponibilCentreFiltre";
            this.Text = "DisponibilCentreFiltre";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFurnizor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonListare;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditLot;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditFurnizor;
        private DevExpress.XtraEditors.LabelControl labelControl4;

    }
}