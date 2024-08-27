namespace ComenziGUI
{
    partial class UserRolesActualizareGrupValori
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
            this.labelControlAlege = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditRoles = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButtonAccepta = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRenunta = new DevExpress.XtraEditors.SimpleButton();
            this.tblRolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditRoles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRolesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonRenunta);
            this.panelControl1.Controls.Add(this.simpleButtonAccepta);
            this.panelControl1.Controls.Add(this.lookUpEditRoles);
            this.panelControl1.Controls.Add(this.labelControlAlege);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(399, 121);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControlAlege
            // 
            this.labelControlAlege.Location = new System.Drawing.Point(12, 44);
            this.labelControlAlege.Name = "labelControlAlege";
            this.labelControlAlege.Size = new System.Drawing.Size(59, 13);
            this.labelControlAlege.TabIndex = 0;
            this.labelControlAlege.Text = "Alegeti Rolul";
            // 
            // lookUpEditRoles
            // 
            this.lookUpEditRoles.Location = new System.Drawing.Point(86, 41);
            this.lookUpEditRoles.Name = "lookUpEditRoles";
            this.lookUpEditRoles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditRoles.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RolName", "Cod"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RolDescription", "Descriere")});
            this.lookUpEditRoles.Properties.DataSource = this.tblRolesBindingSource;
            this.lookUpEditRoles.Properties.DisplayMember = "RolName";
            this.lookUpEditRoles.Properties.NullText = "";
            this.lookUpEditRoles.Properties.ValueMember = "ID";
            this.lookUpEditRoles.Size = new System.Drawing.Size(275, 20);
            this.lookUpEditRoles.TabIndex = 1;
            // 
            // simpleButtonAccepta
            // 
            this.simpleButtonAccepta.Location = new System.Drawing.Point(184, 86);
            this.simpleButtonAccepta.Name = "simpleButtonAccepta";
            this.simpleButtonAccepta.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonAccepta.TabIndex = 2;
            this.simpleButtonAccepta.Text = "Accepta";
            this.simpleButtonAccepta.Click += new System.EventHandler(this.simpleButtonAccepta_Click);
            // 
            // simpleButtonRenunta
            // 
            this.simpleButtonRenunta.Location = new System.Drawing.Point(286, 85);
            this.simpleButtonRenunta.Name = "simpleButtonRenunta";
            this.simpleButtonRenunta.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonRenunta.TabIndex = 3;
            this.simpleButtonRenunta.Text = "Renunta";
            this.simpleButtonRenunta.Click += new System.EventHandler(this.simpleButtonRenunta_Click);
            // 
            // tblRolesBindingSource
            // 
            this.tblRolesBindingSource.DataMember = "tblRoles";
            this.tblRolesBindingSource.DataSource = typeof(CommonDataSets.GUI.RolesDataSet);
            // 
            // UserRolesActualizareGrupValori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 121);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserRolesActualizareGrupValori";
            this.Text = "UserRolesActualizareGrupValori";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditRoles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRolesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditRoles;
        private DevExpress.XtraEditors.LabelControl labelControlAlege;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRenunta;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAccepta;
        private System.Windows.Forms.BindingSource tblRolesBindingSource;
    }
}