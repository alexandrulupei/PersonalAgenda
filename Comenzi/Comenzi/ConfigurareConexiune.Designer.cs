namespace Comenzi
{
    partial class ConfigurareConexiune
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
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panelControlBase = new DevExpress.XtraEditors.PanelControl();
            this.textEditOptionalParameters = new DevExpress.XtraEditors.TextEdit();
            this.buttonEditDataBase = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControlParams = new DevExpress.XtraEditors.LabelControl();
            this.labelControlBaze = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.textEditPassword = new DevExpress.XtraEditors.TextEdit();
            this.textEditUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControlPassword = new DevExpress.XtraEditors.LabelControl();
            this.labelControlUser = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditAuthentication = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControlServer = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.buttonEditServerName = new DevExpress.XtraEditors.ButtonEdit();
            this.labelWindowHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlBase)).BeginInit();
            this.panelControlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOptionalParameters.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAuthentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditServerName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // panelControlBase
            // 
            this.panelControlBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlBase.Controls.Add(this.textEditOptionalParameters);
            this.panelControlBase.Controls.Add(this.buttonEditDataBase);
            this.panelControlBase.Controls.Add(this.labelControlParams);
            this.panelControlBase.Controls.Add(this.labelControlBaze);
            this.panelControlBase.Controls.Add(this.simpleButtonCancel);
            this.panelControlBase.Controls.Add(this.simpleButtonSave);
            this.panelControlBase.Controls.Add(this.textEditPassword);
            this.panelControlBase.Controls.Add(this.textEditUser);
            this.panelControlBase.Controls.Add(this.labelControlPassword);
            this.panelControlBase.Controls.Add(this.labelControlUser);
            this.panelControlBase.Controls.Add(this.lookUpEditAuthentication);
            this.panelControlBase.Controls.Add(this.labelControlServer);
            this.panelControlBase.Controls.Add(this.labelControl1);
            this.panelControlBase.Controls.Add(this.buttonEditServerName);
            this.panelControlBase.Location = new System.Drawing.Point(0, 58);
            this.panelControlBase.Name = "panelControlBase";
            this.panelControlBase.Size = new System.Drawing.Size(415, 221);
            this.panelControlBase.TabIndex = 1;
            // 
            // textEditOptionalParameters
            // 
            this.textEditOptionalParameters.EditValue = "Connection Timeout=600";
            this.textEditOptionalParameters.Location = new System.Drawing.Point(165, 158);
            this.textEditOptionalParameters.Name = "textEditOptionalParameters";
            this.textEditOptionalParameters.Size = new System.Drawing.Size(209, 20);
            this.textEditOptionalParameters.TabIndex = 19;
            // 
            // buttonEditDataBase
            // 
            this.buttonEditDataBase.Location = new System.Drawing.Point(165, 132);
            this.buttonEditDataBase.Name = "buttonEditDataBase";
            this.buttonEditDataBase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditDataBase.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditDataBase_Properties_ButtonClick);
            this.buttonEditDataBase.Size = new System.Drawing.Size(209, 20);
            this.buttonEditDataBase.TabIndex = 18;
            // 
            // labelControlParams
            // 
            this.labelControlParams.Location = new System.Drawing.Point(29, 165);
            this.labelControlParams.Name = "labelControlParams";
            this.labelControlParams.Size = new System.Drawing.Size(98, 13);
            this.labelControlParams.TabIndex = 17;
            this.labelControlParams.Text = "Parametri Optionali: ";
            // 
            // labelControlBaze
            // 
            this.labelControlBaze.Location = new System.Drawing.Point(29, 139);
            this.labelControlBaze.Name = "labelControlBaze";
            this.labelControlBaze.Size = new System.Drawing.Size(67, 13);
            this.labelControlBaze.TabIndex = 16;
            this.labelControlBaze.Text = "Baza de date:";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(299, 193);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 15;
            this.simpleButtonCancel.Text = "Renunta";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Location = new System.Drawing.Point(197, 193);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSave.TabIndex = 14;
            this.simpleButtonSave.Text = "Salveaza";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // textEditPassword
            // 
            this.textEditPassword.Location = new System.Drawing.Point(165, 102);
            this.textEditPassword.Name = "textEditPassword";
            this.textEditPassword.Properties.PasswordChar = '*';
            this.textEditPassword.Size = new System.Drawing.Size(209, 20);
            this.textEditPassword.TabIndex = 13;
            // 
            // textEditUser
            // 
            this.textEditUser.Location = new System.Drawing.Point(165, 69);
            this.textEditUser.Name = "textEditUser";
            this.textEditUser.Size = new System.Drawing.Size(209, 20);
            this.textEditUser.TabIndex = 12;
            // 
            // labelControlPassword
            // 
            this.labelControlPassword.Location = new System.Drawing.Point(95, 102);
            this.labelControlPassword.Name = "labelControlPassword";
            this.labelControlPassword.Size = new System.Drawing.Size(34, 13);
            this.labelControlPassword.TabIndex = 11;
            this.labelControlPassword.Text = "Parola:";
            // 
            // labelControlUser
            // 
            this.labelControlUser.Location = new System.Drawing.Point(95, 72);
            this.labelControlUser.Name = "labelControlUser";
            this.labelControlUser.Size = new System.Drawing.Size(46, 13);
            this.labelControlUser.TabIndex = 10;
            this.labelControlUser.Text = "Utilizator:";
            // 
            // lookUpEditAuthentication
            // 
            this.lookUpEditAuthentication.Location = new System.Drawing.Point(165, 36);
            this.lookUpEditAuthentication.Name = "lookUpEditAuthentication";
            this.lookUpEditAuthentication.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditAuthentication.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Descriere")});
            this.lookUpEditAuthentication.Properties.NullText = "";
            this.lookUpEditAuthentication.Size = new System.Drawing.Size(209, 20);
            this.lookUpEditAuthentication.TabIndex = 9;
            this.lookUpEditAuthentication.EditValueChanged += new System.EventHandler(this.lookUpEditAuthentication_EditValueChanged);
            // 
            // labelControlServer
            // 
            this.labelControlServer.Location = new System.Drawing.Point(29, 8);
            this.labelControlServer.Name = "labelControlServer";
            this.labelControlServer.Size = new System.Drawing.Size(66, 13);
            this.labelControlServer.TabIndex = 8;
            this.labelControlServer.Text = "Nume Server:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(29, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Autentificare:";
            // 
            // buttonEditServerName
            // 
            this.buttonEditServerName.Location = new System.Drawing.Point(165, 5);
            this.buttonEditServerName.Name = "buttonEditServerName";
            this.buttonEditServerName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditServerName.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditServer_Properties_ButtonClick);
            this.buttonEditServerName.Size = new System.Drawing.Size(209, 20);
            this.buttonEditServerName.TabIndex = 6;
            this.buttonEditServerName.EditValueChanged += new System.EventHandler(this.buttonEditServerName_EditValueChanged);
            // 
            // labelWindowHeader
            // 
            this.labelWindowHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWindowHeader.Image = global::Comenzi.Properties.Resources.connconfigheader_400x64;
            this.labelWindowHeader.Location = new System.Drawing.Point(0, 0);
            this.labelWindowHeader.Name = "labelWindowHeader";
            this.labelWindowHeader.Size = new System.Drawing.Size(415, 54);
            this.labelWindowHeader.TabIndex = 0;
            // 
            // ConfigurareConexiune
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 276);
            this.Controls.Add(this.panelControlBase);
            this.Controls.Add(this.labelWindowHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurareConexiune";
            this.Text = "Configurare Conexiune";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurareConexiune_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlBase)).EndInit();
            this.panelControlBase.ResumeLayout(false);
            this.panelControlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOptionalParameters.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAuthentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditServerName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWindowHeader;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.PanelControl panelControlBase;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditAuthentication;
        private DevExpress.XtraEditors.LabelControl labelControlServer;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit buttonEditServerName;
        private DevExpress.XtraEditors.TextEdit textEditOptionalParameters;
        private DevExpress.XtraEditors.ButtonEdit buttonEditDataBase;
        private DevExpress.XtraEditors.LabelControl labelControlParams;
        private DevExpress.XtraEditors.LabelControl labelControlBaze;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.TextEdit textEditPassword;
        private DevExpress.XtraEditors.TextEdit textEditUser;
        private DevExpress.XtraEditors.LabelControl labelControlPassword;
        private DevExpress.XtraEditors.LabelControl labelControlUser;
    }
}