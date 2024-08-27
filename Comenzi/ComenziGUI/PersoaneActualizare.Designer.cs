namespace ComenziGUI
{
    partial class PersoaneActualizare
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.textEditNume = new DevExpress.XtraEditors.TextEdit();
            this.textEditPrenume = new DevExpress.XtraEditors.TextEdit();
            this.checkedComboBoxEditTipPersoana = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.tbxTipPersoanaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControlTipPersoana = new DevExpress.XtraEditors.LabelControl();
            this.labelControlPrenume = new DevExpress.XtraEditors.LabelControl();
            this.labelControlNume = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNume.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrenume.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEditTipPersoana.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipPersoanaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Controls.Add(this.simpleButtonSave);
            this.panelControl1.Controls.Add(this.textEditNume);
            this.panelControl1.Controls.Add(this.textEditPrenume);
            this.panelControl1.Controls.Add(this.checkedComboBoxEditTipPersoana);
            this.panelControl1.Controls.Add(this.labelControlTipPersoana);
            this.panelControl1.Controls.Add(this.labelControlPrenume);
            this.panelControl1.Controls.Add(this.labelControlNume);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(292, 196);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.Location = new System.Drawing.Point(205, 154);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 6;
            this.simpleButtonCancel.Text = "Renunta";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.Location = new System.Drawing.Point(106, 154);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSave.TabIndex = 5;
            this.simpleButtonSave.Text = "Salveaza";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // textEditNume
            // 
            this.textEditNume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditNume.Location = new System.Drawing.Point(106, 13);
            this.textEditNume.Name = "textEditNume";
            this.textEditNume.Size = new System.Drawing.Size(174, 20);
            this.textEditNume.TabIndex = 4;
            // 
            // textEditPrenume
            // 
            this.textEditPrenume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditPrenume.Location = new System.Drawing.Point(106, 52);
            this.textEditPrenume.Name = "textEditPrenume";
            this.textEditPrenume.Size = new System.Drawing.Size(174, 20);
            this.textEditPrenume.TabIndex = 4;
            // 
            // checkedComboBoxEditTipPersoana
            // 
            this.checkedComboBoxEditTipPersoana.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedComboBoxEditTipPersoana.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tbxTipPersoanaBindingSource, "ID", true));
            this.checkedComboBoxEditTipPersoana.EditValue = "";
            this.checkedComboBoxEditTipPersoana.Location = new System.Drawing.Point(106, 96);
            this.checkedComboBoxEditTipPersoana.Name = "checkedComboBoxEditTipPersoana";
            this.checkedComboBoxEditTipPersoana.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEditTipPersoana.Size = new System.Drawing.Size(174, 20);
            this.checkedComboBoxEditTipPersoana.TabIndex = 3;
            // 
            // tbxTipPersoanaBindingSource
            // 
            this.tbxTipPersoanaBindingSource.DataMember = "tbxTipPersoana";
            this.tbxTipPersoanaBindingSource.DataSource = typeof(CommonDataSets.GUI.PersoaneDataSet);
            // 
            // labelControlTipPersoana
            // 
            this.labelControlTipPersoana.Location = new System.Drawing.Point(13, 96);
            this.labelControlTipPersoana.Name = "labelControlTipPersoana";
            this.labelControlTipPersoana.Size = new System.Drawing.Size(59, 13);
            this.labelControlTipPersoana.TabIndex = 2;
            this.labelControlTipPersoana.Text = "TipPersoana";
            // 
            // labelControlPrenume
            // 
            this.labelControlPrenume.Location = new System.Drawing.Point(13, 52);
            this.labelControlPrenume.Name = "labelControlPrenume";
            this.labelControlPrenume.Size = new System.Drawing.Size(42, 13);
            this.labelControlPrenume.TabIndex = 1;
            this.labelControlPrenume.Text = "Prenume";
            // 
            // labelControlNume
            // 
            this.labelControlNume.Location = new System.Drawing.Point(13, 13);
            this.labelControlNume.Name = "labelControlNume";
            this.labelControlNume.Size = new System.Drawing.Size(27, 13);
            this.labelControlNume.TabIndex = 0;
            this.labelControlNume.Text = "Nume";
            // 
            // PersoaneActualizare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 196);
            this.Controls.Add(this.panelControl1);
            this.Name = "PersoaneActualizare";
            this.Text = "PersoaneActualizare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersoaneActualizare_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNume.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrenume.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEditTipPersoana.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTipPersoanaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.TextEdit textEditNume;
        private DevExpress.XtraEditors.TextEdit textEditPrenume;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEditTipPersoana;
        private DevExpress.XtraEditors.LabelControl labelControlTipPersoana;
        private DevExpress.XtraEditors.LabelControl labelControlPrenume;
        private DevExpress.XtraEditors.LabelControl labelControlNume;
        private System.Windows.Forms.BindingSource tbxTipPersoanaBindingSource;
    }
}