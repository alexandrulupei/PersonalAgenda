
namespace AgendaContacte
{
    partial class HomeAgenda
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID_DP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prenume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Judet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.stergeButton = new DevExpress.XtraEditors.SimpleButton();
            this.listeazaButton = new DevExpress.XtraEditors.SimpleButton();
            this.homeAgendaBUSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeAgendaBUSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_DP,
            this.Nume,
            this.Prenume,
            this.CNP,
            this.Tara,
            this.Judet});
            this.dataGridView1.Location = new System.Drawing.Point(64, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(669, 337);
            this.dataGridView1.TabIndex = 0;
            // 
            // ID_DP
            // 
            this.ID_DP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID_DP.DataPropertyName = "ID_DP";
            this.ID_DP.HeaderText = "ID";
            this.ID_DP.Name = "ID_DP";
            this.ID_DP.ReadOnly = true;
            // 
            // Nume
            // 
            this.Nume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nume.DataPropertyName = "Nume";
            this.Nume.HeaderText = "Nume";
            this.Nume.Name = "Nume";
            this.Nume.ReadOnly = true;
            // 
            // Prenume
            // 
            this.Prenume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prenume.DataPropertyName = "Prenume";
            this.Prenume.HeaderText = "Prenume";
            this.Prenume.Name = "Prenume";
            this.Prenume.ReadOnly = true;
            // 
            // CNP
            // 
            this.CNP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CNP.DataPropertyName = "CNP";
            this.CNP.HeaderText = "CNP";
            this.CNP.Name = "CNP";
            this.CNP.ReadOnly = true;
            // 
            // Tara
            // 
            this.Tara.DataPropertyName = "Tara";
            this.Tara.HeaderText = "Tara";
            this.Tara.Name = "Tara";
            this.Tara.ReadOnly = true;
            // 
            // Judet
            // 
            this.Judet.DataPropertyName = "Judet";
            this.Judet.HeaderText = "Judet";
            this.Judet.Name = "Judet";
            this.Judet.ReadOnly = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.simpleButton1.Location = new System.Drawing.Point(257, 396);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Adauga";
            this.simpleButton1.Click += new System.EventHandler(this.Adauga);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.simpleButton2.Location = new System.Drawing.Point(456, 396);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Editeaza";
            this.simpleButton2.Click += new System.EventHandler(this.Editeaza);
            // 
            // stergeButton
            // 
            this.stergeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.stergeButton.Location = new System.Drawing.Point(655, 396);
            this.stergeButton.Name = "stergeButton";
            this.stergeButton.Size = new System.Drawing.Size(75, 23);
            this.stergeButton.TabIndex = 3;
            this.stergeButton.Text = "Sterge";
            this.stergeButton.Click += new System.EventHandler(this.stergeButton_Click);
            // 
            // listeazaButton
            // 
            this.listeazaButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.listeazaButton.Location = new System.Drawing.Point(66, 396);
            this.listeazaButton.Name = "listeazaButton";
            this.listeazaButton.Size = new System.Drawing.Size(75, 23);
            this.listeazaButton.TabIndex = 4;
            this.listeazaButton.Text = "Listeaza";
            this.listeazaButton.Click += new System.EventHandler(this.listeazaButton_Click);
            // 
            // homeAgendaBUSBindingSource
            // 
            this.homeAgendaBUSBindingSource.DataSource = typeof(BUS.HomeAgendaBUS);
            // 
            // HomeAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 471);
            this.Controls.Add(this.listeazaButton);
            this.Controls.Add(this.stergeButton);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "HomeAgenda";
            this.Text = "Contacte";
            this.Load += new System.EventHandler(this.AgendaContacte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeAgendaBUSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton stergeButton;
        private System.Windows.Forms.BindingSource homeAgendaBUSBindingSource;
        private DevExpress.XtraEditors.SimpleButton listeazaButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_DP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prenume;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tara;
        private System.Windows.Forms.DataGridViewTextBoxColumn Judet;
    }
}

