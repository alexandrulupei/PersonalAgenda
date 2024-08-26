
namespace AgendaContacte
{
    partial class ActiuniCRUD
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
            this.Nume = new System.Windows.Forms.TextBox();
            this.CNP = new System.Windows.Forms.TextBox();
            this.Prenume = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.salveazaButton = new DevExpress.XtraEditors.SimpleButton();
            this.renuntaButton = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridContacte = new System.Windows.Forms.DataGridView();
            this.Contact_Tip_Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ID_DP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxTara = new System.Windows.Forms.ComboBox();
            this.comboBoxJudet = new System.Windows.Forms.ComboBox();
            this.stergeContactButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContacte)).BeginInit();
            this.SuspendLayout();
            // 
            // Nume
            // 
            this.Nume.Location = new System.Drawing.Point(159, 62);
            this.Nume.Name = "Nume";
            this.Nume.Size = new System.Drawing.Size(100, 20);
            this.Nume.TabIndex = 2;
            // 
            // CNP
            // 
            this.CNP.Location = new System.Drawing.Point(159, 198);
            this.CNP.Name = "CNP";
            this.CNP.Size = new System.Drawing.Size(100, 20);
            this.CNP.TabIndex = 3;
            // 
            // Prenume
            // 
            this.Prenume.Location = new System.Drawing.Point(159, 130);
            this.Prenume.Name = "Prenume";
            this.Prenume.Size = new System.Drawing.Size(100, 20);
            this.Prenume.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(87, 304);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Tara";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(458, 309);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Judet";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(90, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Nume";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(90, 133);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Prenume";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(90, 198);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(20, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "CNP";
            // 
            // salveazaButton
            // 
            this.salveazaButton.Location = new System.Drawing.Point(233, 373);
            this.salveazaButton.Name = "salveazaButton";
            this.salveazaButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.salveazaButton.Size = new System.Drawing.Size(75, 23);
            this.salveazaButton.TabIndex = 11;
            this.salveazaButton.Text = "Salveaza";
            this.salveazaButton.Click += new System.EventHandler(this.Salveaza_Click);
            // 
            // renuntaButton
            // 
            this.renuntaButton.Location = new System.Drawing.Point(460, 373);
            this.renuntaButton.Name = "renuntaButton";
            this.renuntaButton.Size = new System.Drawing.Size(75, 23);
            this.renuntaButton.TabIndex = 12;
            this.renuntaButton.Text = "Renunta";
            this.renuntaButton.Click += new System.EventHandler(this.Renunta_Click);
            // 
            // dataGridContacte
            // 
            this.dataGridContacte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridContacte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Contact_Tip_Column,
            this.ID_DP,
            this.Contact_Id,
            this.Contact});
            this.dataGridContacte.Location = new System.Drawing.Point(330, 62);
            this.dataGridContacte.Name = "dataGridContacte";
            this.dataGridContacte.Size = new System.Drawing.Size(437, 189);
            this.dataGridContacte.TabIndex = 13;
            // 
            // Contact_Tip_Column
            // 
            this.Contact_Tip_Column.DataPropertyName = "Contact_Tip_Id";
            this.Contact_Tip_Column.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Contact_Tip_Column.HeaderText = "Contact_Tip";
            this.Contact_Tip_Column.Name = "Contact_Tip_Column";
            // 
            // ID_DP
            // 
            this.ID_DP.DataPropertyName = "ID_DP";
            this.ID_DP.HeaderText = "ID_DP";
            this.ID_DP.Name = "ID_DP";
            this.ID_DP.Visible = false;
            // 
            // Contact_Id
            // 
            this.Contact_Id.DataPropertyName = "Contact_Id";
            this.Contact_Id.HeaderText = "Contact_Id";
            this.Contact_Id.Name = "Contact_Id";
            this.Contact_Id.Visible = false;
            // 
            // Contact
            // 
            this.Contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Contact.DataPropertyName = "Contact";
            this.Contact.HeaderText = "Contact";
            this.Contact.Name = "Contact";
            // 
            // comboBoxTara
            // 
            this.comboBoxTara.FormattingEnabled = true;
            this.comboBoxTara.Location = new System.Drawing.Point(156, 301);
            this.comboBoxTara.Name = "comboBoxTara";
            this.comboBoxTara.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTara.TabIndex = 14;
            // 
            // comboBoxJudet
            // 
            this.comboBoxJudet.FormattingEnabled = true;
            this.comboBoxJudet.Location = new System.Drawing.Point(531, 304);
            this.comboBoxJudet.Name = "comboBoxJudet";
            this.comboBoxJudet.Size = new System.Drawing.Size(121, 21);
            this.comboBoxJudet.TabIndex = 15;
            // 
            // stergeContactButton
            // 
            this.stergeContactButton.Location = new System.Drawing.Point(641, 257);
            this.stergeContactButton.Name = "stergeContactButton";
            this.stergeContactButton.Size = new System.Drawing.Size(126, 23);
            this.stergeContactButton.TabIndex = 16;
            this.stergeContactButton.Text = "Sterge contact";
            this.stergeContactButton.Click += new System.EventHandler(this.stergeContactButton_Click);
            // 
            // ActiuniCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 450);
            this.Controls.Add(this.stergeContactButton);
            this.Controls.Add(this.comboBoxJudet);
            this.Controls.Add(this.comboBoxTara);
            this.Controls.Add(this.dataGridContacte);
            this.Controls.Add(this.renuntaButton);
            this.Controls.Add(this.salveazaButton);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Prenume);
            this.Controls.Add(this.CNP);
            this.Controls.Add(this.Nume);
            this.Name = "ActiuniCRUD";
            this.Text = "ActiuniCRUD";
            this.Load += new System.EventHandler(this.ActiuniCRUD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContacte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Nume;
        private System.Windows.Forms.TextBox CNP;
        private System.Windows.Forms.TextBox Prenume;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton salveazaButton;
        private DevExpress.XtraEditors.SimpleButton renuntaButton;
        private System.Windows.Forms.DataGridView dataGridContacte;
        private System.Windows.Forms.ComboBox comboBoxTara;
        private System.Windows.Forms.ComboBox comboBoxJudet;
        private DevExpress.XtraEditors.SimpleButton stergeContactButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn Contact_Tip_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_DP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
    }
}