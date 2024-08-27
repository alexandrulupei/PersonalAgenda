using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraPrinting;
using GSFramework;

namespace ComenziBase
{
    public partial class BaseWindow : FrameworkWindow
    {
        #region Constructor
        public BaseWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Members
        private DevExpress.XtraGrid.GridControl mGridControl;
        //private DevExpress.XtraTreeList.TreeList mTreeListControl;
        private System.Diagnostics.Process mProcessToStart;
        private SecurityDataClass mSecurityDataClass = SecurityDataClass.OnlyInstance;
        protected Guid mAlegeIDBase = Guid.Empty;
        #endregion

        #region Properties
        [
        Category("User Defined"),
        Description("Sets the window title."),
        DisplayName("WindowTitle")
        ]
        public string SetWindowTitle
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        [
        Category("User Defined"),
        Description("Sets the window header text."),
        DisplayName("WindowHeader")
        ]
        public string SetWindowHeader
        {
            get { return this.labelBaseWindowHeader.Text; }
            set { this.labelBaseWindowHeader.Text = value; }
        }
        [Browsable(true)]
        [Category("User Defined")]
        [Description("Define which borders of the control are bound to the container")]
        [DisplayName("NavBarDockStyle")]
        public DockStyle NavBarDockStyle
        {
            set { this.navBarControlBaseWindow.Dock = value; }
            get { return this.navBarControlBaseWindow.Dock; }
        }

        [Browsable(true)]
        [Category("User Defined")]
        [Description("Define the anchor")]
        [DisplayName("NavBarAnchorStyle")]
        public AnchorStyles NavBarAnchorStyle
        {
            set { this.navBarControlBaseWindow.Anchor = value; }
            get { return this.navBarControlBaseWindow.Anchor; }
        }
        public DevExpress.XtraEditors.Mask.DateEditMaskProperties DateEditMask
        {
            get
            {
                DevExpress.XtraEditors.Mask.DateEditMaskProperties dateEditMask = new DevExpress.XtraEditors.Mask.DateEditMaskProperties();
                dateEditMask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                dateEditMask.EditMask = ContextUtilityClass.OnlyInstance.DateFormat;
                return dateEditMask;
            }
        }
        public DevExpress.Utils.FormatInfo FormatInfo
        {
            get
            {
                DevExpress.Utils.FormatInfo formatInfo = new DevExpress.Utils.FormatInfo();
                formatInfo.FormatType = DevExpress.Utils.FormatType.DateTime;
                formatInfo.FormatString = ContextUtilityClass.OnlyInstance.DateFormat;
                return formatInfo;
            }
        }
        public Guid AlegeIDBase
        {
            get { return mAlegeIDBase; }
            set { mAlegeIDBase = value; }
        }
        #endregion

        #region Events Handlers
        private void Export_Progress(object sender, DevExpress.XtraGrid.Export.ProgressEventArgs e)
        {
            if (e.Phase == DevExpress.XtraGrid.Export.ExportPhase.Link)
            {
                progressBarControlBaseWindow.Position = e.Position;
                this.Update();
            }
        }
        private void BaseWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || (e.Alt && e.KeyCode == Keys.E))
                Iesire();
            else if (e.Alt && e.KeyCode == Keys.A && navBarItemAdauga.Enabled)
            {
                if (mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.READING)
                    return;
                Adauga();
            }
            else if (e.Alt && e.KeyCode == Keys.M && navBarItemModifica.Enabled)
            {
                if (mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.READING)
                    return;
                Modifica();
            }
            else if (e.Alt && e.KeyCode == Keys.X && navBarItemSterge.Enabled)
            {
                if (mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.READING)
                    return;
                Sterge();
            }
            else if (e.Alt && e.KeyCode == Keys.L)
                Listare();
            else if (e.Alt && e.KeyCode == Keys.C)
                ExportExcel();
            else if (e.Alt && e.KeyCode == Keys.H)
                ExportHTML();
            else if (e.Alt && e.KeyCode == Keys.T)
                ExportTxt();
            else if (e.Alt && e.KeyCode == Keys.G)
                Alege();
            else if (e.Alt && e.KeyCode == Keys.S)
            {
                if (mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.READING)
                    return;
                Salvare();
            }
            else if (e.Alt && e.KeyCode == Keys.D)
                ActualizareItem1();
            else if (e.Alt && e.KeyCode == Keys.R)
                ActualizareItem2();
            else if (e.Alt && e.KeyCode == Keys.I)
                ActualizareItem3();
        }
        private void navBarItemAdauga_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Adauga();
        }

        private void navBarItemModifica_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Modifica();
        }

        private void navBarItemSterge_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Sterge();
        }

        private void navBarItemActualizare_Custom3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ActualizareItem3();
        }

        private void navBarItemActualizare_Custom2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ActualizareItem2();
        }

        private void navBarItemActualizare_Custom1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ActualizareItem1();
        }
        private void navBarItemListare_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Listare();
        }

        private void navBarItemExportExcel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ExportExcel();
        }

        private void navBarItemExportHTML_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ExportHTML();
        }

        private void navBarItemExportTxt_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ExportTxt();
        }

        private void navBarItemAlege_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Alege();
        }

        private void navBarItemSalvare_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Salvare();
        }

        private void navBarItemIesire_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Iesire();
        }

        #endregion

        #region Private Methods
        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Export To " + title;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        private void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show("Doriti sa deschideti acest fisier?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    mProcessToStart = new System.Diagnostics.Process();
                    mProcessToStart.StartInfo.FileName = fileName;
                    mProcessToStart.StartInfo.Verb = "Open";
                    mProcessToStart.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    mProcessToStart.Start();
                }
                catch
                {
                    XtraMessageBox.Show(this, "Nu exista instalata o aplicatie potrivita pentru deschiderea fisierului ce contine datele exportate", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    mProcessToStart.Close();
                }
            }
            progressBarControlBaseWindow.Position = 0;
        }
        private void ExportTo(IExportProvider provider)
        {
            progressBarControlBaseWindow.BringToFront();
            progressBarControlBaseWindow.Visible = true;
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            BaseExportLink link = mGridControl.FocusedView.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = true;
            link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
            link.ExportTo(true);
            provider.Dispose();
            link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
            Cursor.Current = currentCursor;
            progressBarControlBaseWindow.Visible = false;
        }
        private void ApplySecurity()
        {
            if (mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.NO_RIGHTS)
            {
                navBarGroupActualizare.Visible = navBarItemSalvare.Visible = false;
                if (this.mGridControl != null && mGridControl.UseEmbeddedNavigator)
                {
                    foreach (GridView gv in mGridControl.Views)
                    {
                        gv.OptionsBehavior.Editable = false;
                    }
                    mGridControl.EmbeddedNavigator.Buttons.Append.Visible =
                    mGridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
                }
            }
            else if (mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.READING)
            {
                navBarGroupActualizare.Visible = navBarItemSalvare.Visible = false;
                if (this.mGridControl != null && mGridControl.UseEmbeddedNavigator)
                {
                    foreach (GridView gv in mGridControl.Views)
                    {
                        gv.OptionsBehavior.Editable = false;

                    }
                    mGridControl.EmbeddedNavigator.Buttons.Append.Visible =
                    mGridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
                }
            }
            else if (mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.FULL_RIGHTS)
            {
                return;
            }
            else if (mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.ADD)
            {
                navBarItemModifica.Visible = navBarItemSterge.Visible = false;
                navBarItemAdauga.Visible = true;
            }
            else if (mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.ADD_MODIFY)
            {
                navBarItemAdauga.Visible = navBarItemModifica.Visible = true;
                navBarItemSterge.Visible = false;
            }
        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            base.Initialize();
            this.ShowInTaskbar = false;
            ApplySecurity();
        }
        public override void Bind()
        {
            base.Bind();
        }
        #endregion

        #region Public Virtual Methods
        //public virtual void Initialize(DevExpress.XtraTreeList.TreeList pTreeList)
        //{
        //    base.Initialize();
        //    this.mTreeListControl = pTreeList;
        //    ApplySecurity();
        //}
        public virtual void Initialize(DevExpress.XtraGrid.GridControl pGridControl)
        {
            base.Initialize();
            this.mGridControl = pGridControl;
            this.mGridControl.ProcessGridKey += new KeyEventHandler(mGridControl_ProcessGridKey);
            ApplySecurity();
        }

        void mGridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.READING ||
                mSecurityDataClass.UserAccessRights == SecurityDataClass.AccessRights.NO_RIGHTS)
            {
                if (e.KeyCode == Keys.Insert || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Enter)
                    e.Handled = true;
            }
        }
        public virtual void Adauga()
        {
        }
        public virtual void Modifica()
        {
        }
        public virtual void Sterge()
        {
        }
        public virtual void Listare()
        {
            if (mGridControl != null)
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                (mGridControl.FocusedView as GridView).OptionsPrint.PrintDetails = true;
                this.mGridControl.ShowPrintPreview();
                Cursor.Current = currentCursor;
            }
            //else if (mTreeListControl != null)
            //{
            //    Cursor currentCursor = Cursor.Current;
            //    Cursor.Current = Cursors.WaitCursor;
            //    this.mTreeListControl.ShowPrintPreview();
            //    Cursor.Current = currentCursor;
            //}
        }
        public virtual void ExportExcel()
        {
            try
            {
                string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
                if (!String.IsNullOrEmpty(fileName.Trim()))
                {
                    if (mGridControl != null)
                    {
                        mGridControl.FocusedView.ExportToXls(fileName, new XlsExportOptions(TextExportMode.Value, true));
                    }
                    OpenFile(fileName);
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Nu s-a reusit salvarea exportului. Mesajul de eroare este: \n" + e.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public virtual void ExportHTML()
        {
            try
            {
                string fileName = ShowSaveFileDialog("HTML Document", "HTML Documents|*.html");
                if (!String.IsNullOrEmpty(fileName.Trim()))
                {
                    if (mGridControl != null)
                        ExportTo(new ExportHtmlProvider(fileName));
                    //else if (mTreeListControl != null)
                    //    mTreeListControl.ExportToHtml(fileName);
                    OpenFile(fileName);
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Nu s-a reusit salvarea exportului. Mesajul de eroare este: \n" + e.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public virtual void ExportTxt()
        {
            try
            {
                string fileName = ShowSaveFileDialog("Text Document", "Text Files|*.txt");
                if (!String.IsNullOrEmpty(fileName.Trim()))
                {
                    if (mGridControl != null)
                        ExportTo(new ExportTxtProvider(fileName));
                    //else if (mTreeListControl != null)
                    //    mTreeListControl.ExportToText(fileName);
                    OpenFile(fileName);
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Nu s-a reusit salvarea exportului. Mesajul de eroare este: \n" + e.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public virtual void Alege()
        {
        }
        public virtual void Salvare()
        {
        }
        public virtual void Iesire()
        {
        }
        public virtual void ActualizareItem1()
        {
        }
        public virtual void ActualizareItem2()
        {
        }
        public virtual void ActualizareItem3()
        {
        }
        #endregion


    }
}
