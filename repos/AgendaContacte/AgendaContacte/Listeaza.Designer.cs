
namespace AgendaContacte
{
    partial class Listeaza
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
            this.ListareButton = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlJudet = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxJudet = new System.Windows.Forms.ComboBox();
            this.comboBoxTara = new System.Windows.Forms.ComboBox();
            this.labelControlTara = new DevExpress.XtraEditors.LabelControl();
            this.labelControlPrenume = new DevExpress.XtraEditors.LabelControl();
            this.labelControlNume = new DevExpress.XtraEditors.LabelControl();
            this.textBoxPrenume = new System.Windows.Forms.TextBox();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.RenuntaButton = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ListareButton
            // 
            this.ListareButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ListareButton.Location = new System.Drawing.Point(92, 216);
            this.ListareButton.Name = "ListareButton";
            this.ListareButton.Size = new System.Drawing.Size(75, 23);
            this.ListareButton.TabIndex = 28;
            this.ListareButton.Text = "Listare";
            this.ListareButton.Click += new System.EventHandler(this.ListareButton_Click);
            // 
            // labelControlJudet
            // 
            this.labelControlJudet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControlJudet.Location = new System.Drawing.Point(313, 117);
            this.labelControlJudet.Name = "labelControlJudet";
            this.labelControlJudet.Size = new System.Drawing.Size(27, 13);
            this.labelControlJudet.TabIndex = 27;
            this.labelControlJudet.Text = "Judet";
            // 
            // comboBoxJudet
            // 
            this.comboBoxJudet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxJudet.FormattingEnabled = true;
            this.comboBoxJudet.Location = new System.Drawing.Point(377, 114);
            this.comboBoxJudet.Name = "comboBoxJudet";
            this.comboBoxJudet.Size = new System.Drawing.Size(121, 21);
            this.comboBoxJudet.TabIndex = 26;
            // 
            // comboBoxTara
            // 
            this.comboBoxTara.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxTara.FormattingEnabled = true;
            this.comboBoxTara.Location = new System.Drawing.Point(109, 111);
            this.comboBoxTara.Name = "comboBoxTara";
            this.comboBoxTara.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTara.TabIndex = 25;
            // 
            // labelControlTara
            // 
            this.labelControlTara.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControlTara.Location = new System.Drawing.Point(61, 114);
            this.labelControlTara.Name = "labelControlTara";
            this.labelControlTara.Size = new System.Drawing.Size(22, 13);
            this.labelControlTara.TabIndex = 24;
            this.labelControlTara.Text = "Tara";
            // 
            // labelControlPrenume
            // 
            this.labelControlPrenume.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControlPrenume.Location = new System.Drawing.Point(313, 76);
            this.labelControlPrenume.Name = "labelControlPrenume";
            this.labelControlPrenume.Size = new System.Drawing.Size(42, 13);
            this.labelControlPrenume.TabIndex = 23;
            this.labelControlPrenume.Text = "Prenume";
            // 
            // labelControlNume
            // 
            this.labelControlNume.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControlNume.Location = new System.Drawing.Point(61, 75);
            this.labelControlNume.Name = "labelControlNume";
            this.labelControlNume.Size = new System.Drawing.Size(27, 13);
            this.labelControlNume.TabIndex = 22;
            this.labelControlNume.Text = "Nume";
            // 
            // textBoxPrenume
            // 
            this.textBoxPrenume.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxPrenume.Location = new System.Drawing.Point(377, 75);
            this.textBoxPrenume.Name = "textBoxPrenume";
            this.textBoxPrenume.Size = new System.Drawing.Size(121, 20);
            this.textBoxPrenume.TabIndex = 21;
            // 
            // textBoxNume
            // 
            this.textBoxNume.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxNume.Location = new System.Drawing.Point(109, 73);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(121, 20);
            this.textBoxNume.TabIndex = 20;
            // 
            // RenuntaButton
            // 
            this.RenuntaButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RenuntaButton.Location = new System.Drawing.Point(408, 216);
            this.RenuntaButton.Name = "RenuntaButton";
            this.RenuntaButton.Size = new System.Drawing.Size(75, 23);
            this.RenuntaButton.TabIndex = 29;
            this.RenuntaButton.Text = "Renunta";
            // 
            // Listeaza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 341);
            this.Controls.Add(this.RenuntaButton);
            this.Controls.Add(this.ListareButton);
            this.Controls.Add(this.labelControlJudet);
            this.Controls.Add(this.comboBoxJudet);
            this.Controls.Add(this.comboBoxTara);
            this.Controls.Add(this.labelControlTara);
            this.Controls.Add(this.labelControlPrenume);
            this.Controls.Add(this.labelControlNume);
            this.Controls.Add(this.textBoxPrenume);
            this.Controls.Add(this.textBoxNume);
            this.Name = "Listeaza";
            this.Text = "Listeaza";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton ListareButton;
        private DevExpress.XtraEditors.LabelControl labelControlJudet;
        private System.Windows.Forms.ComboBox comboBoxJudet;
        private System.Windows.Forms.ComboBox comboBoxTara;
        private DevExpress.XtraEditors.LabelControl labelControlTara;
        private DevExpress.XtraEditors.LabelControl labelControlPrenume;
        private DevExpress.XtraEditors.LabelControl labelControlNume;
        private System.Windows.Forms.TextBox textBoxPrenume;
        private System.Windows.Forms.TextBox textBoxNume;
        private DevExpress.XtraEditors.SimpleButton RenuntaButton;
    }
}