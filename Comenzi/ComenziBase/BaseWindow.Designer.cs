namespace ComenziBase
{
    partial class BaseWindow
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
            this.panelControlHeader = new DevExpress.XtraEditors.PanelControl();
            this.labelBaseWindowHeader = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlBaseWindow = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControlBaseWindow = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupListareExport = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemListare = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemExportExcel = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemExportHTML = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemExportTxt = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupActualizare = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemAdauga = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemModifica = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemSterge = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemActualizare_Custom1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemActualizare_Custom2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemActualizare_Custom3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupAlteActiuni = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemAlege = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemSalvare = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemIesire = new DevExpress.XtraNavBar.NavBarItem();
            this.progressBarControlBaseWindow = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHeader)).BeginInit();
            this.panelControlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel1)).BeginInit();
            this.splitContainerControlBaseWindow.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel2)).BeginInit();
            this.splitContainerControlBaseWindow.Panel2.SuspendLayout();
            this.splitContainerControlBaseWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlBaseWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlHeader
            // 
            this.panelControlHeader.Controls.Add(this.labelBaseWindowHeader);
            this.panelControlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlHeader.Location = new System.Drawing.Point(0, 0);
            this.panelControlHeader.Name = "panelControlHeader";
            this.panelControlHeader.Size = new System.Drawing.Size(931, 38);
            this.panelControlHeader.TabIndex = 1;
            // 
            // labelBaseWindowHeader
            // 
            this.labelBaseWindowHeader.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBaseWindowHeader.Appearance.Options.UseFont = true;
            this.labelBaseWindowHeader.Appearance.Options.UseTextOptions = true;
            this.labelBaseWindowHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelBaseWindowHeader.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelBaseWindowHeader.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelBaseWindowHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelBaseWindowHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBaseWindowHeader.Location = new System.Drawing.Point(2, 2);
            this.labelBaseWindowHeader.Name = "labelBaseWindowHeader";
            this.labelBaseWindowHeader.Size = new System.Drawing.Size(927, 34);
            this.labelBaseWindowHeader.TabIndex = 0;
            this.labelBaseWindowHeader.Text = "Base Window";
            // 
            // splitContainerControlBaseWindow
            // 
            this.splitContainerControlBaseWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlBaseWindow.Location = new System.Drawing.Point(0, 38);
            this.splitContainerControlBaseWindow.Name = "splitContainerControlBaseWindow";
            // 
            // splitContainerControlBaseWindow.Panel1
            // 
            this.splitContainerControlBaseWindow.Panel1.Controls.Add(this.navBarControlBaseWindow);
            this.splitContainerControlBaseWindow.Panel1.Text = "Panel1";
            // 
            // splitContainerControlBaseWindow.Panel2
            // 
            this.splitContainerControlBaseWindow.Panel2.Controls.Add(this.progressBarControlBaseWindow);
            this.splitContainerControlBaseWindow.Panel2.Text = "Panel2";
            this.splitContainerControlBaseWindow.Size = new System.Drawing.Size(931, 456);
            this.splitContainerControlBaseWindow.SplitterPosition = 187;
            this.splitContainerControlBaseWindow.TabIndex = 2;
            this.splitContainerControlBaseWindow.Text = "splitContainerControl1";
            // 
            // navBarControlBaseWindow
            // 
            this.navBarControlBaseWindow.ActiveGroup = this.navBarGroupListareExport;
            this.navBarControlBaseWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControlBaseWindow.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupActualizare,
            this.navBarGroupListareExport,
            this.navBarGroupAlteActiuni});
            this.navBarControlBaseWindow.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItemAdauga,
            this.navBarItemModifica,
            this.navBarItemSterge,
            this.navBarItemListare,
            this.navBarItemExportExcel,
            this.navBarItemExportHTML,
            this.navBarItemExportTxt,
            this.navBarItemAlege,
            this.navBarItemSalvare,
            this.navBarItemIesire,
            this.navBarItemActualizare_Custom1,
            this.navBarItemActualizare_Custom2,
            this.navBarItemActualizare_Custom3});
            this.navBarControlBaseWindow.Location = new System.Drawing.Point(0, 0);
            this.navBarControlBaseWindow.Name = "navBarControlBaseWindow";
            this.navBarControlBaseWindow.OptionsNavPane.ExpandedWidth = 187;
            this.navBarControlBaseWindow.Size = new System.Drawing.Size(187, 456);
            this.navBarControlBaseWindow.TabIndex = 0;
            this.navBarControlBaseWindow.Text = "navBarControl1";
            // 
            // navBarGroupListareExport
            // 
            this.navBarGroupListareExport.Appearance.Options.UseTextOptions = true;
            this.navBarGroupListareExport.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBarGroupListareExport.Caption = "Listare/Export";
            this.navBarGroupListareExport.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemListare),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemExportExcel),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemExportHTML),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemExportTxt)});
            this.navBarGroupListareExport.Name = "navBarGroupListareExport";
            // 
            // navBarItemListare
            // 
            this.navBarItemListare.Caption = "Listare (Alt+L)";
            this.navBarItemListare.Name = "navBarItemListare";
            this.navBarItemListare.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemListare_LinkClicked);
            // 
            // navBarItemExportExcel
            // 
            this.navBarItemExportExcel.Caption = "Export Excel (Alt+C)";
            this.navBarItemExportExcel.Name = "navBarItemExportExcel";
            this.navBarItemExportExcel.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemExportExcel_LinkClicked);
            // 
            // navBarItemExportHTML
            // 
            this.navBarItemExportHTML.Caption = "Export HTML (Alt+H)";
            this.navBarItemExportHTML.Name = "navBarItemExportHTML";
            this.navBarItemExportHTML.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemExportHTML_LinkClicked);
            // 
            // navBarItemExportTxt
            // 
            this.navBarItemExportTxt.Caption = "Export Text (Alt+T)";
            this.navBarItemExportTxt.Name = "navBarItemExportTxt";
            this.navBarItemExportTxt.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemExportTxt_LinkClicked);
            // 
            // navBarGroupActualizare
            // 
            this.navBarGroupActualizare.Appearance.Options.UseTextOptions = true;
            this.navBarGroupActualizare.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBarGroupActualizare.Caption = "Actualizare";
            this.navBarGroupActualizare.Expanded = true;
            this.navBarGroupActualizare.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemAdauga),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemModifica),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemSterge),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemActualizare_Custom1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemActualizare_Custom2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemActualizare_Custom3)});
            this.navBarGroupActualizare.Name = "navBarGroupActualizare";
            // 
            // navBarItemAdauga
            // 
            this.navBarItemAdauga.Caption = "Adauga (Alt+A)";
            this.navBarItemAdauga.Name = "navBarItemAdauga";
            this.navBarItemAdauga.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemAdauga_LinkClicked);
            // 
            // navBarItemModifica
            // 
            this.navBarItemModifica.Caption = "Modifica (Alt+M)";
            this.navBarItemModifica.Name = "navBarItemModifica";
            this.navBarItemModifica.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemModifica_LinkClicked);
            // 
            // navBarItemSterge
            // 
            this.navBarItemSterge.Caption = "Sterge (Alt+X)";
            this.navBarItemSterge.Name = "navBarItemSterge";
            this.navBarItemSterge.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemSterge_LinkClicked);
            // 
            // navBarItemActualizare_Custom1
            // 
            this.navBarItemActualizare_Custom1.Caption = "navBarItem1";
            this.navBarItemActualizare_Custom1.Name = "navBarItemActualizare_Custom1";
            this.navBarItemActualizare_Custom1.Visible = false;
            this.navBarItemActualizare_Custom1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemActualizare_Custom1_LinkClicked);
            // 
            // navBarItemActualizare_Custom2
            // 
            this.navBarItemActualizare_Custom2.Caption = "navBarItem2";
            this.navBarItemActualizare_Custom2.Name = "navBarItemActualizare_Custom2";
            this.navBarItemActualizare_Custom2.Visible = false;
            this.navBarItemActualizare_Custom2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemActualizare_Custom2_LinkClicked);
            // 
            // navBarItemActualizare_Custom3
            // 
            this.navBarItemActualizare_Custom3.Caption = "navBarItem3";
            this.navBarItemActualizare_Custom3.Name = "navBarItemActualizare_Custom3";
            this.navBarItemActualizare_Custom3.Visible = false;
            this.navBarItemActualizare_Custom3.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemActualizare_Custom3_LinkClicked);
            // 
            // navBarGroupAlteActiuni
            // 
            this.navBarGroupAlteActiuni.Appearance.Options.UseTextOptions = true;
            this.navBarGroupAlteActiuni.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBarGroupAlteActiuni.Caption = "Alte Actiuni";
            this.navBarGroupAlteActiuni.Expanded = true;
            this.navBarGroupAlteActiuni.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemAlege),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemSalvare),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemIesire)});
            this.navBarGroupAlteActiuni.Name = "navBarGroupAlteActiuni";
            // 
            // navBarItemAlege
            // 
            this.navBarItemAlege.Caption = "Alege (Alt+G)";
            this.navBarItemAlege.Name = "navBarItemAlege";
            this.navBarItemAlege.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemAlege_LinkClicked);
            // 
            // navBarItemSalvare
            // 
            this.navBarItemSalvare.Caption = "Salvare (Alt+S)";
            this.navBarItemSalvare.Name = "navBarItemSalvare";
            this.navBarItemSalvare.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemSalvare_LinkClicked);
            // 
            // navBarItemIesire
            // 
            this.navBarItemIesire.Caption = "Iesire (Alt+E)";
            this.navBarItemIesire.Name = "navBarItemIesire";
            this.navBarItemIesire.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemIesire_LinkClicked);
            // 
            // progressBarControlBaseWindow
            // 
            this.progressBarControlBaseWindow.Location = new System.Drawing.Point(5, 435);
            this.progressBarControlBaseWindow.Name = "progressBarControlBaseWindow";
            this.progressBarControlBaseWindow.Size = new System.Drawing.Size(736, 18);
            this.progressBarControlBaseWindow.TabIndex = 0;
            // 
            // BaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Controls.Add(this.splitContainerControlBaseWindow);
            this.Controls.Add(this.panelControlHeader);
            this.Name = "BaseWindow";
            this.ShowInTaskbar = false;
            this.Text = "BaseWindow";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHeader)).EndInit();
            this.panelControlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel1)).EndInit();
            this.splitContainerControlBaseWindow.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow.Panel2)).EndInit();
            this.splitContainerControlBaseWindow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlBaseWindow)).EndInit();
            this.splitContainerControlBaseWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlBaseWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlBaseWindow.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlHeader;
        private DevExpress.XtraNavBar.NavBarControl navBarControlBaseWindow;
        protected DevExpress.XtraEditors.SplitContainerControl splitContainerControlBaseWindow;
        public DevExpress.XtraNavBar.NavBarItem navBarItemAdauga;
        public DevExpress.XtraNavBar.NavBarItem navBarItemModifica;
        public DevExpress.XtraNavBar.NavBarItem navBarItemSterge;
        public DevExpress.XtraNavBar.NavBarItem navBarItemListare;
        public DevExpress.XtraNavBar.NavBarItem navBarItemExportExcel;
        public DevExpress.XtraNavBar.NavBarItem navBarItemExportHTML;
        public DevExpress.XtraNavBar.NavBarItem navBarItemExportTxt;
        public DevExpress.XtraNavBar.NavBarItem navBarItemAlege;
        public DevExpress.XtraNavBar.NavBarItem navBarItemSalvare;
        public DevExpress.XtraNavBar.NavBarItem navBarItemIesire;
        public DevExpress.XtraNavBar.NavBarGroup navBarGroupActualizare;
        public DevExpress.XtraNavBar.NavBarGroup navBarGroupListareExport;
        public DevExpress.XtraNavBar.NavBarGroup navBarGroupAlteActiuni;
        public DevExpress.XtraEditors.ProgressBarControl progressBarControlBaseWindow;
        public DevExpress.XtraEditors.LabelControl labelBaseWindowHeader;
        public DevExpress.XtraNavBar.NavBarItem navBarItemActualizare_Custom1;
        public DevExpress.XtraNavBar.NavBarItem navBarItemActualizare_Custom2;
        public DevExpress.XtraNavBar.NavBarItem navBarItemActualizare_Custom3;

    }
}