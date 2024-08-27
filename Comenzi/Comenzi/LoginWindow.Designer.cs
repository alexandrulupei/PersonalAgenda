namespace Comenzi
{
    partial class LoginWindow
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
            this.panelControlLogin = new DevExpress.XtraEditors.PanelControl();
            this.panelControlGrupare = new DevExpress.XtraEditors.PanelControl();
            this.textBoxPassword = new DevExpress.XtraEditors.TextEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItemConfigurare = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInfo = new DevExpress.XtraBars.BarButtonItem();
            this.hyperLinkEditSuportGS = new DevExpress.XtraEditors.HyperLinkEdit();
            this.lblVersiune = new DevExpress.XtraEditors.LabelControl();
            this.dropDownButtonOptiuni = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenuOptiuni = new DevExpress.XtraBars.PopupMenu(this.components);
            this.simpleButtonRenunta = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonLogin = new DevExpress.XtraEditors.SimpleButton();
            this.textEditUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControlPassword = new DevExpress.XtraEditors.LabelControl();
            this.labelControlUser = new DevExpress.XtraEditors.LabelControl();
            this.labelTitlu = new System.Windows.Forms.Label();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLogin)).BeginInit();
            this.panelControlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrupare)).BeginInit();
            this.panelControlGrupare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEditSuportGS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuOptiuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlLogin
            // 
            this.panelControlLogin.Controls.Add(this.panelControlGrupare);
            this.panelControlLogin.Controls.Add(this.labelTitlu);
            this.panelControlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlLogin.Location = new System.Drawing.Point(0, 0);
            this.panelControlLogin.Name = "panelControlLogin";
            this.panelControlLogin.Size = new System.Drawing.Size(401, 246);
            this.panelControlLogin.TabIndex = 0;
            // 
            // panelControlGrupare
            // 
            this.panelControlGrupare.Controls.Add(this.textBoxPassword);
            this.panelControlGrupare.Controls.Add(this.hyperLinkEditSuportGS);
            this.panelControlGrupare.Controls.Add(this.lblVersiune);
            this.panelControlGrupare.Controls.Add(this.dropDownButtonOptiuni);
            this.panelControlGrupare.Controls.Add(this.simpleButtonRenunta);
            this.panelControlGrupare.Controls.Add(this.simpleButtonLogin);
            this.panelControlGrupare.Controls.Add(this.textEditUser);
            this.panelControlGrupare.Controls.Add(this.labelControlPassword);
            this.panelControlGrupare.Controls.Add(this.labelControlUser);
            this.panelControlGrupare.Location = new System.Drawing.Point(0, 62);
            this.panelControlGrupare.Name = "panelControlGrupare";
            this.panelControlGrupare.Size = new System.Drawing.Size(401, 184);
            this.panelControlGrupare.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.EnterMoveNextControl = true;
            this.textBoxPassword.Location = new System.Drawing.Point(181, 59);
            this.textBoxPassword.MenuManager = this.barManager;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(186, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            // 
            // barManager
            // 
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemConfigurare,
            this.barButtonItemInfo});
            this.barManager.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(401, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 246);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(401, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 246);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(401, 0);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 246);
            // 
            // barButtonItemConfigurare
            // 
            this.barButtonItemConfigurare.Caption = "Configurare conexiuni";
            this.barButtonItemConfigurare.Id = 0;
            this.barButtonItemConfigurare.Name = "barButtonItemConfigurare";
            this.barButtonItemConfigurare.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemConfigurare_ItemClick);
            // 
            // barButtonItemInfo
            // 
            this.barButtonItemInfo.Caption = "Informatii server";
            this.barButtonItemInfo.Id = 1;
            this.barButtonItemInfo.Name = "barButtonItemInfo";
            this.barButtonItemInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInfo_ItemClick);
            // 
            // hyperLinkEditSuportGS
            // 
            this.hyperLinkEditSuportGS.EditValue = "Suport Online GS";
            this.hyperLinkEditSuportGS.Location = new System.Drawing.Point(261, 155);
            this.hyperLinkEditSuportGS.MenuManager = this.barManager;
            this.hyperLinkEditSuportGS.Name = "hyperLinkEditSuportGS";
            this.hyperLinkEditSuportGS.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hyperLinkEditSuportGS.Properties.Appearance.Options.UseBackColor = true;
            this.hyperLinkEditSuportGS.Size = new System.Drawing.Size(106, 20);
            this.hyperLinkEditSuportGS.TabIndex = 9;
            this.hyperLinkEditSuportGS.Click += new System.EventHandler(this.hyperLinkEdit1_Click);
            // 
            // lblVersiune
            // 
            this.lblVersiune.Location = new System.Drawing.Point(63, 158);
            this.lblVersiune.Name = "lblVersiune";
            this.lblVersiune.Size = new System.Drawing.Size(41, 13);
            this.lblVersiune.TabIndex = 8;
            this.lblVersiune.Text = "Versiune";
            // 
            // dropDownButtonOptiuni
            // 
            this.dropDownButtonOptiuni.DropDownControl = this.popupMenuOptiuni;
            this.dropDownButtonOptiuni.Location = new System.Drawing.Point(261, 117);
            this.dropDownButtonOptiuni.MenuManager = this.barManager;
            this.dropDownButtonOptiuni.Name = "dropDownButtonOptiuni";
            this.dropDownButtonOptiuni.Size = new System.Drawing.Size(106, 23);
            this.dropDownButtonOptiuni.TabIndex = 7;
            this.dropDownButtonOptiuni.Text = "Optiuni";
            this.dropDownButtonOptiuni.Click += new System.EventHandler(this.dropDownButtonOptiuni_Click);
            // 
            // popupMenuOptiuni
            // 
            this.popupMenuOptiuni.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemConfigurare),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemInfo)});
            this.popupMenuOptiuni.Manager = this.barManager;
            this.popupMenuOptiuni.Name = "popupMenuOptiuni";
            // 
            // simpleButtonRenunta
            // 
            this.simpleButtonRenunta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonRenunta.Location = new System.Drawing.Point(180, 117);
            this.simpleButtonRenunta.Name = "simpleButtonRenunta";
            this.simpleButtonRenunta.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonRenunta.TabIndex = 5;
            this.simpleButtonRenunta.Text = "Renunta";
            // 
            // simpleButtonLogin
            // 
            this.simpleButtonLogin.Location = new System.Drawing.Point(89, 117);
            this.simpleButtonLogin.Name = "simpleButtonLogin";
            this.simpleButtonLogin.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonLogin.TabIndex = 4;
            this.simpleButtonLogin.Text = "Autentificare";
            this.simpleButtonLogin.Click += new System.EventHandler(this.simpleButtonLogin_Click);
            // 
            // textEditUser
            // 
            this.textEditUser.EnterMoveNextControl = true;
            this.textEditUser.Location = new System.Drawing.Point(181, 21);
            this.textEditUser.Name = "textEditUser";
            this.textEditUser.Size = new System.Drawing.Size(186, 20);
            this.textEditUser.TabIndex = 2;
            // 
            // labelControlPassword
            // 
            this.labelControlPassword.Location = new System.Drawing.Point(34, 59);
            this.labelControlPassword.Name = "labelControlPassword";
            this.labelControlPassword.Size = new System.Drawing.Size(90, 13);
            this.labelControlPassword.TabIndex = 1;
            this.labelControlPassword.Text = "Introduceti parola:";
            // 
            // labelControlUser
            // 
            this.labelControlUser.Location = new System.Drawing.Point(34, 21);
            this.labelControlUser.Name = "labelControlUser";
            this.labelControlUser.Size = new System.Drawing.Size(130, 13);
            this.labelControlUser.TabIndex = 0;
            this.labelControlUser.Text = "Introduceti nume utilizator:";
            // 
            // labelTitlu
            // 
            this.labelTitlu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitlu.BackColor = System.Drawing.Color.White;
            this.labelTitlu.Image = global::Comenzi.Properties.Resources.GrupSoft;
            this.labelTitlu.Location = new System.Drawing.Point(-3, 2);
            this.labelTitlu.Name = "labelTitlu";
            this.labelTitlu.Size = new System.Drawing.Size(399, 57);
            this.labelTitlu.TabIndex = 0;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 246);
            this.Controls.Add(this.panelControlLogin);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autentificare utilizatori in sistem";
            this.Load += new System.EventHandler(this.LoginWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLogin)).EndInit();
            this.panelControlLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrupare)).EndInit();
            this.panelControlGrupare.ResumeLayout(false);
            this.panelControlGrupare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEditSuportGS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuOptiuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUser.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlLogin;
        private System.Windows.Forms.Label labelTitlu;
        private DevExpress.XtraEditors.PanelControl panelControlGrupare;
        private DevExpress.XtraEditors.LabelControl labelControlPassword;
        private DevExpress.XtraEditors.LabelControl labelControlUser;
        private DevExpress.XtraEditors.TextEdit textEditUser;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRenunta;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLogin;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu popupMenuOptiuni;
        private DevExpress.XtraEditors.DropDownButton dropDownButtonOptiuni;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemConfigurare;
        private DevExpress.XtraBars.BarButtonItem barButtonItemInfo;
        private DevExpress.XtraEditors.LabelControl lblVersiune;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEditSuportGS;
        private DevExpress.XtraEditors.TextEdit textBoxPassword;
    }
}

