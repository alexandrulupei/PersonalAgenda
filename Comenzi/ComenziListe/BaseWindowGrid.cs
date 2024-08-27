using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GSFramework;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using System.Xml.Serialization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Drawing.Printing;
using ComenziBase;
using CommonDataSets.Base;
using CommonGUIControllers.Base;
using DevExpress.XtraEditors;

namespace ComenziListe
{
    public partial class BaseWindowGrid : FrameworkWindow
    {

        #region Constructor

        public BaseWindowGrid()
        {
            InitializeComponent();
        }

        #endregion

        #region Class Fields

        private DevExpress.XtraGrid.GridControl mGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView mGridView;
        private System.Diagnostics.Process mProcessToStart;
        private BaseWindowGridDataSet mDataSet;
        private BaseWindowFiltreDataSet mFiltreDataSet;
        private BaseWindowFiltreController mController;
        protected BaseWindowGridDataSet.tblOptiuniRow mOptiuniRow;
        protected string mListName = string.Empty;
        protected string mFilterText = string.Empty;
        protected bool mCuDataListare = false;
        private bool mAfisareGestionar = false;
        private string mGestionariCustomString;
        private string mComisieCustomString;

        private OptiuniFiltre mOptiuniHeaderLeft;
        private OptiuniFiltre mOptiuniHeaderCenter;
        private OptiuniFiltre mOptiuniHeaderRight;
        private OptiuniFiltre mOptiuniFooterLeft;
        private OptiuniFiltre mOptiuniFooterCenter;
        private OptiuniFiltre mOptiuniFooterRight;

        private FontStyle mHeaderLeftStyle = FontStyle.Regular;
        private FontStyle mHeaderCenterStyle = FontStyle.Regular;
        private FontStyle mHeaderRightStyle = FontStyle.Regular;
        private FontStyle mFooterLeftStyle = FontStyle.Regular;
        private FontStyle mFooterCenterStyle = FontStyle.Regular;
        private FontStyle mFooterRightStyle = FontStyle.Regular;

        private Font mHeaderLeftFont;
        private Font mHeaderCenterFont;
        private Font mHeaderRightFont;
        private Font mFooterLeftFont;
        private Font mFooterCenterFont;
        private Font mFooterRightFont;

        private Color mHeaderLeftColor;
        private Color mHeaderCenterColor;
        private Color mHeaderRightColor;
        private Color mFooterLeftColor;
        private Color mFooterCenterColor;
        private Color mFooterRightColor;

        private float mFontSize = 8.25F;
        private string mFontName = "Arial";
        private string mFontColor = "Black";

        protected bool SalveazaLayoutGrid = true;
        protected int mNrZecimale = 0;
        protected bool mSeparatorMii = false;
        protected string mNrFormatString = "{0:#}";

        private string mFileName;
        private string mUserName;
        private bool mIsLandscape = false;
        private string mDimensiune = "A4";
        private bool mAfisareSubsolPerPagina = false;
        private bool mAfiseazaAntetPrimaPagina = false;
        // private System.Drawing.Printing.PaperKind mPaper = System.Drawing.Printing.PaperKind.A4;
        private string mAssemblyName;

        private Dictionary<int, string> mColumnNameList = new Dictionary<int, string>();
        private Dictionary<int, string> mBandNameList = new Dictionary<int, string>();
        private bool mIsBandedGrid = false;
        private string mExportFileName = String.Empty;
        private string mExportFileExtension = ".pdf";
        private string mExportFileSignExtension = ".p7s";
        private string mTitluName = String.Empty;
        // daca este true atunci sant intr-o fereastra 
        // care poate avea mai multe forme
        // de ex: listele la DDS sau monitorizare cheltuieli
        // primeste valoare in clasa derivata, este folosita in clasa de baza
        protected bool mIsMultiList = false;
        // numele listei care diferenatiaza fisierele intre ele
        // si titlul listei
        // primeste valoare in clasa derivata, este folosita in clasa de baza
        protected string mAdditionalNameList = string.Empty;
        private Dictionary<string, object> mExportData = new Dictionary<string, object>();

        #endregion

        #region Properties

        public string AssemblyName
        {
            set { this.mAssemblyName = value; }
        }

        public string ListName
        {
            set { this.mListName = value; }
        }

        protected Dictionary<int, string> ColumnNameList
        {
            get { return mColumnNameList; }
            set { this.mColumnNameList = value; }
        }

        public bool AfisareGestionar
        {

            set { this.mAfisareGestionar = value; }
        }

        public string GestionarCustomString
        {
            set { this.mGestionariCustomString = value; }
        }

        public string ComisieCustomString
        {
            set { this.mComisieCustomString = value; }
        }

        public bool AfiseazaSubsolPerPagina
        {
            get { return mAfisareSubsolPerPagina; }
            set { this.mAfisareSubsolPerPagina = value; }
        }

        public bool AfiseazaAntetPrimaPagina
        {
            get { return mAfiseazaAntetPrimaPagina; }
            set { this.mAfiseazaAntetPrimaPagina = value; }
        }

        #endregion

        #region Events

        private void BaseWindowGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || (e.Alt && e.KeyCode == Keys.E))
                Iesire();
            else if (e.Alt && e.KeyCode == Keys.Q)
                ResetareColoane();
            else if (e.Alt && e.KeyCode == Keys.L)
                Listare();
            else if (e.Alt && e.KeyCode == Keys.C)
                ExportExcel();
            else if (e.Alt && e.KeyCode == Keys.H)
                ExportHTML();
            else if (e.Alt && e.KeyCode == Keys.T)
                ExportTxt();

        }

        private void navBarItemExportExcel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ExportExcel();
        }

        private void navBarItemExportHTML_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ExportHTML();
        }

        private void navBarItemExportText_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ExportTxt();
        }

        private void navBarItemListare_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Imprimare();
        }

        private void navBarItemPrevizualizare_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Listare();
        }

        private void navBarItemSalvare_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Salvare();
        }

        private void navBarItemConfigurare_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ConfigListare();
        }

        private void navBarItemSemnareDigitala_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SemnareDigitala();
        }

        private void navBarItemReset_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ResetareColoane();
        }

        private void navBarItemIesire_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Iesire();
        }

        private void Export_Progress(object sender, DevExpress.XtraGrid.Export.ProgressEventArgs e)
        {
            if (e.Phase == DevExpress.XtraGrid.Export.ExportPhase.Link)
            {
                progressBarControlBaseWindowGrid.Position = e.Position;
                this.Update();
            }
        }

        private void BaseWindowGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SalveazaLayoutGrid)
                Utilities.Utility.SaveGridLayoutToXml(mGridControl, this, Context.UserName);

            if (mDataSet.tblSetariPaginaRaport.Rows.Count > 0)
            {
                DataRow dr = mDataSet.tblSetariPaginaRaport.Rows[0];
                dr["Dimensiune"] = comboBoxEditDimensiune.SelectedIndex;
                if (comboBoxEditOrientare.SelectedIndex == 1)
                    dr["Landscape"] = true;
                else
                    dr["Landscape"] = false;
            }
            else
            {
                DataRow dr = mDataSet.tblSetariPaginaRaport.NewtblSetariPaginaRaportRow();
                dr["Dimensiune"] = comboBoxEditDimensiune.SelectedIndex;
                if (comboBoxEditOrientare.SelectedIndex == 1)
                    dr["Landscape"] = true;
                else
                    dr["Landscape"] = false;
                mDataSet.tblSetariPaginaRaport.Rows.Add(dr);
            }

            Utilities.Utility.SaveDataSetToXmlFile(mDataSet, mFileName, mUserName);
        }

        private void checkedListBoxControlConfigurareCol_ItemCheck(object sender,
            DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            string sCaption = checkedListBoxControlConfigurareCol.GetItemText(e.Index);
            if (mIsBandedGrid)
            {
                foreach (BandedGridColumn bcoll in mGridView.Columns)
                {
                    if (bcoll.Name == mColumnNameList[e.Index])
                    {
                        if (e.State == CheckState.Checked)
                        {
                            bcoll.Visible = true;
                            GridBand bandV = bcoll.OwnerBand;
                            if (bandV.Columns.VisibleColumnCount > 0)
                            {
                                bandV.Visible = true;
                                for (int i = 0; i < mBandNameList.Count; i++)
                                    if (bandV.Name == mBandNameList[i])
                                    {
                                        checkedListBoxControlBands.Items[i].CheckState = CheckState.Checked;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            bcoll.Visible = false;
                            GridBand bandI = bcoll.OwnerBand;
                            if (bandI.Columns.VisibleColumnCount == 0)
                            {
                                bandI.Visible = false;
                                for (int i = 0; i < mBandNameList.Count; i++)
                                    if (bandI.Name == mBandNameList[i])
                                    {
                                        checkedListBoxControlBands.Items[i].CheckState = CheckState.Unchecked;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                }
            }
            else
            {
                foreach (GridColumn coll in mGridView.Columns)
                {
                    if (coll.Name == mColumnNameList[e.Index])
                    {
                        if (e.State == CheckState.Checked)
                            coll.Visible = true;
                        else
                            coll.Visible = false;
                        break;
                    }
                }
            }
        }

        private void checkedListBoxControlBands_ItemCheck(object sender,
            DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            string sCaption = checkedListBoxControlBands.GetItemText(e.Index);
            BandedGridView bandedView = mGridControl.MainView as BandedGridView;
            if (bandedView != null)
            {
                foreach (GridBand band in bandedView.Bands)
                {
                    if (band.Name == mBandNameList[e.Index])
                    {
                        if (e.State == CheckState.Checked)
                        {
                            band.Visible = true;
                            foreach (GridColumn col in band.Columns)
                            {
                                for (int i = 0; i < mColumnNameList.Count; i++)
                                    if (col.Name == mColumnNameList[i])
                                    {
                                        col.Visible = true;
                                        checkedListBoxControlConfigurareCol.Items[i].CheckState = CheckState.Checked;
                                        break;
                                    }

                            }
                        }
                        else
                        {
                            band.Visible = false;
                            foreach (GridColumn col in band.Columns)
                            {
                                for (int i = 0; i < mColumnNameList.Count; i++)
                                    if (col.Name == mColumnNameList[i])
                                    {
                                        col.Visible = false;
                                        checkedListBoxControlConfigurareCol.Items[i].CheckState = CheckState.Unchecked;
                                        break;
                                    }

                            }
                        }
                        break;
                    }
                }
            }
        }

        private void comboBoxEditDimensiune_SelectedIndexChanged(object sender, EventArgs e)
        {
            mDimensiune = comboBoxEditDimensiune.SelectedItem.ToString();

        }

        private void comboBoxEditOrientare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditOrientare.SelectedIndex == 0)
                mIsLandscape = false;
            else
                mIsLandscape = true;
        }

        private void ReportLink_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            if (!mAfisareSubsolPerPagina)
            {
                if (mCuDataListare)
                {
                    Font mFont = new Font("Arial", 8, FontStyle.Italic);
                    string sFormat = ContextUtilityClass.OnlyInstance.DateWithHourFormat;
                    TextBrick ReportLogo = new TextBrick();
                    ReportLogo.Text = "Comenzi v1.0";
                    ReportLogo.Font = mFont;
                    ReportLogo.StringFormat = new BrickStringFormat(StringAlignment.Near);
                    ReportLogo.Sides = BorderSide.None;
                    float ReportLogoTextHeight =
                        Graphics.FromHwnd(this.Handle).MeasureString(ReportLogo.Text, ReportLogo.Font).Height;
                    e.Graph.DrawBrick(ReportLogo, new RectangleF(0, 10, GetWidthByPercent(35, e), ReportLogoTextHeight));


                    mFont = new Font("Arial", 8, FontStyle.Regular);
                    TextBrick ReportDataListare = new TextBrick();
                    ReportDataListare.Text = "Data listarii: " + DateTime.Now.ToString(sFormat);
                    ReportDataListare.Font = mFont;
                    ReportDataListare.StringFormat = new BrickStringFormat(StringAlignment.Center);
                    ReportDataListare.Sides = BorderSide.None;
                    float ReportDataListareTextHeight =
                        Graphics.FromHwnd(this.Handle)
                            .MeasureString(ReportDataListare.Text, ReportDataListare.Font)
                            .Height;
                    e.Graph.DrawBrick(ReportDataListare,
                        new RectangleF(GetWidthByPercent(35, e), 10, GetWidthByPercent(35, e),
                            ReportDataListareTextHeight));

                    string format = "{0}/{1}";
                    RectangleF r = new RectangleF(GetWidthByPercent(65, e), 10, GetWidthByPercent(35, e),
                        e.Graph.Font.Height);
                    PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black, r,
                        BorderSide.None);
                    brick.Alignment = BrickAlignment.Far;
                    StringFormat sFormatBr = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                    sFormatBr.Alignment = StringAlignment.Near;
                    sFormatBr.LineAlignment = StringAlignment.Center;
                    BrickStringFormat brickSFormat = new BrickStringFormat(sFormatBr);
                    brick.StringFormat = brickSFormat;
                }
                else
                {
                    Font mFont = new Font("Arial", 8, FontStyle.Italic);
                    string sFormat = ContextUtilityClass.OnlyInstance.DateFormat;
                    TextBrick ReportLogo = new TextBrick();
                    ReportLogo.Text = "Comenzi v1.0";
                    ReportLogo.Font = mFont;
                    ReportLogo.StringFormat = new BrickStringFormat(StringAlignment.Near);
                    ReportLogo.Sides = BorderSide.None;
                    float ReportLogoTextHeight =
                        Graphics.FromHwnd(this.Handle).MeasureString(ReportLogo.Text, ReportLogo.Font).Height;
                    e.Graph.DrawBrick(ReportLogo, new RectangleF(0, 10, GetWidthByPercent(35, e), ReportLogoTextHeight));

                    string format = "{0}/{1}";
                    RectangleF r = new RectangleF(GetWidthByPercent(65, e), 10, GetWidthByPercent(35, e),
                        e.Graph.Font.Height);
                    PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black, r,
                        BorderSide.None);
                    brick.Alignment = BrickAlignment.Far;
                    StringFormat sFormatBr = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                    sFormatBr.Alignment = StringAlignment.Near;
                    sFormatBr.LineAlignment = StringAlignment.Center;
                    BrickStringFormat brickSFormat = new BrickStringFormat(sFormatBr);
                    brick.StringFormat = brickSFormat;

                }
            }
            else
            {
                e.Graph.PageUnit = GraphicsUnit.Pixel;
                float ReportStangaTextHeight = 0;
                float ReportFooterLeftBrickWidth = GetWidthByPercent(32, e);
                if (mOptiuniRow != null)
                {
                    //Report footer left
                    TextBrick ReportFooterLeftBrick = new TextBrick();
                    if (!mAfisareGestionar)
                    {
                        ReportFooterLeftBrick.Text = mOptiuniRow.FooterLeftText;
                        // ReportFooterLeftBrickTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(mOptiuniRow.FooterLeftText, mFooterLeftFont, Convert.ToInt32(Math.Floor(ReportFooterLeftBrickWidth))).Height;

                    }
                    else
                    {
                        ReportFooterLeftBrick.Text = mGestionariCustomString;
                        // ReportFooterLeftBrickTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(mGestionariCustomString, mFooterLeftFont, Convert.ToInt32(Math.Floor(ReportFooterLeftBrickWidth))).Height;

                    }
                    //  ReportFooterLeftBrick.Text = mOptiuniRow.FooterLeftText;
                    ReportFooterLeftBrick.Font = mFooterLeftFont;
                    ReportFooterLeftBrick.ForeColor = mFooterLeftColor;
                    ReportFooterLeftBrick.StringFormat = new BrickStringFormat(StringAlignment.Near);
                    ReportFooterLeftBrick.Sides = BorderSide.None;
                    ReportFooterLeftBrick.BackColor = Color.Transparent;

                    ReportStangaTextHeight =
                        Graphics.FromHwnd(this.Handle)
                            .MeasureString(ReportFooterLeftBrick.Text, ReportFooterLeftBrick.Font)
                            .Height + 15;
                    float ReportLogoTextHeight =
                        Graphics.FromHwnd(this.Handle)
                            .MeasureString(ReportFooterLeftBrick.Text, ReportFooterLeftBrick.Font)
                            .Height + 15;

                    e.Graph.DrawBrick(ReportFooterLeftBrick,
                        new RectangleF(0, 10, GetWidthByPercent(35, e), ReportLogoTextHeight));

                    //Report footer center
                    TextBrick ReportFooterCenterBrick = new TextBrick();
                    float ReportFooterCenterBrickTextHeight;
                    float ReportFooterRightBrickWidth = GetWidthByPercent(32, e);
                    float ReportFooterCenterBrickWidth = GetWidthByPercent(32, e);

                    if (!mAfisareGestionar)
                    {
                        ReportFooterCenterBrick.Text = mOptiuniRow.FooterCenterText;
                        //ReportFooterCenterBrickTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(mOptiuniRow.FooterCenterText, mFooterCenterFont, Convert.ToInt32(Math.Floor(ReportFooterCenterBrickWidth))).Height;
                        ReportFooterCenterBrickTextHeight =
                            Graphics.FromHwnd(this.Handle)
                                .MeasureString(mOptiuniRow.FooterCenterText, mFooterCenterFont,
                                    Convert.ToInt32(Math.Floor(ReportFooterCenterBrickWidth)))
                                .Height;
                    }
                    else
                    {
                        ReportFooterCenterBrick.Text = mComisieCustomString;
                        ReportFooterCenterBrickTextHeight =
                            Graphics.FromHwnd(this.Handle)
                                .MeasureString(mComisieCustomString, mFooterCenterFont,
                                    Convert.ToInt32(Math.Floor(ReportFooterCenterBrickWidth)))
                                .Height;
                    }
                    //ReportFooterCenterBrick.Text = mOptiuniRow.FooterCenterText;
                    ReportFooterCenterBrick.Font = mFooterCenterFont;
                    ReportFooterCenterBrick.ForeColor = mFooterCenterColor;
                    ReportFooterCenterBrick.StringFormat = new BrickStringFormat(StringAlignment.Center);
                    ReportFooterCenterBrick.Sides = BorderSide.None;
                    ReportFooterCenterBrick.BackColor = Color.Transparent;

                    e.Graph.DrawBrick(ReportFooterCenterBrick,
                        new RectangleF(GetWidthByPercent(34, e), 10, ReportFooterCenterBrickWidth,
                            ReportFooterCenterBrickTextHeight + 10));

                    TextBrick ReportFooterRightBrick = new TextBrick();
                    ReportFooterRightBrick.Text = mOptiuniRow.FooterRightText;
                    ReportFooterRightBrick.Font = mFooterRightFont;
                    ReportFooterRightBrick.ForeColor = mFooterRightColor;
                    ReportFooterRightBrick.StringFormat = new BrickStringFormat(StringAlignment.Far);
                    ReportFooterRightBrick.Sides = BorderSide.None;
                    ReportFooterRightBrick.BackColor = Color.Transparent;

                    float ReportFooterRightBrickTextHeight =
                        Graphics.FromHwnd(this.Handle)
                            .MeasureString(mOptiuniRow.FooterRightText, mFooterRightFont,
                                Convert.ToInt32(Math.Floor(ReportFooterRightBrickWidth)))
                            .Height;
                    e.Graph.DrawBrick(ReportFooterRightBrick,
                        new RectangleF(GetWidthByPercent(68, e), 10, ReportFooterRightBrickWidth,
                            ReportFooterRightBrickTextHeight + 10));
                }

                if (mCuDataListare)
                {
                    Font mFont = new Font("Arial", 8, FontStyle.Italic);
                    string sFormat = ContextUtilityClass.OnlyInstance.DateFormat;
                    TextBrick ReportLogo = new TextBrick();
                    ReportLogo.Text = "Comenzi v1.0";
                    ReportLogo.Font = mFont;
                    ReportLogo.StringFormat = new BrickStringFormat(StringAlignment.Near);
                    ReportLogo.Sides = BorderSide.None;
                    float ReportLogoTextHeight =
                        Graphics.FromHwnd(this.Handle).MeasureString(ReportLogo.Text, ReportLogo.Font).Height;
                    e.Graph.DrawBrick(ReportLogo,
                        new RectangleF(0, ReportStangaTextHeight, GetWidthByPercent(35, e), ReportLogoTextHeight));


                    mFont = new Font("Arial", 8, FontStyle.Regular);
                    TextBrick ReportDataListare = new TextBrick();
                    ReportDataListare.Text = "Data listarii: " + DateTime.Now.ToString(sFormat);
                    ReportDataListare.Font = mFont;
                    ReportDataListare.StringFormat = new BrickStringFormat(StringAlignment.Center);
                    ReportDataListare.Sides = BorderSide.None;
                    float ReportDataListareTextHeight =
                        Graphics.FromHwnd(this.Handle)
                            .MeasureString(ReportDataListare.Text, ReportDataListare.Font)
                            .Height;
                    e.Graph.DrawBrick(ReportDataListare,
                        new RectangleF(GetWidthByPercent(35, e), ReportStangaTextHeight, GetWidthByPercent(35, e),
                            ReportDataListareTextHeight));

                    string format = "{0}/{1}";
                    RectangleF r = new RectangleF(GetWidthByPercent(65, e), ReportStangaTextHeight,
                        GetWidthByPercent(35, e), e.Graph.Font.Height);
                    PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black, r,
                        BorderSide.None);
                    brick.Alignment = BrickAlignment.Far;
                    StringFormat sFormatBr = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                    sFormatBr.Alignment = StringAlignment.Near;
                    sFormatBr.LineAlignment = StringAlignment.Center;
                    BrickStringFormat brickSFormat = new BrickStringFormat(sFormatBr);
                    brick.StringFormat = brickSFormat;
                }
                else
                {
                    Font mFont = new Font("Arial", 8, FontStyle.Italic);
                    string sFormat = ContextUtilityClass.OnlyInstance.DateFormat;
                    TextBrick ReportLogo = new TextBrick();
                    ReportLogo.Text = "Comenzi v1.0";
                    ReportLogo.Font = mFont;
                    ReportLogo.StringFormat = new BrickStringFormat(StringAlignment.Near);
                    ReportLogo.Sides = BorderSide.None;
                    float ReportLogoTextHeight =
                        Graphics.FromHwnd(this.Handle).MeasureString(ReportLogo.Text, ReportLogo.Font).Height;
                    e.Graph.DrawBrick(ReportLogo,
                        new RectangleF(0, ReportStangaTextHeight, GetWidthByPercent(35, e), ReportLogoTextHeight));

                    string format = "{0}/{1}";
                    RectangleF r = new RectangleF(GetWidthByPercent(65, e), ReportStangaTextHeight,
                        GetWidthByPercent(35, e), e.Graph.Font.Height);
                    PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black, r,
                        BorderSide.None);
                    brick.Alignment = BrickAlignment.Far;
                    StringFormat sFormatBr = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                    sFormatBr.Alignment = StringAlignment.Near;
                    sFormatBr.LineAlignment = StringAlignment.Center;
                    BrickStringFormat brickSFormat = new BrickStringFormat(sFormatBr);
                    brick.StringFormat = brickSFormat;

                }
            }
        }

        private void ReportLink_CreateReportFooterArea(object sender, CreateAreaEventArgs e)
        {
            e.Graph.PageUnit = GraphicsUnit.Pixel;

            if (mOptiuniRow != null)
            {
                //Report footer left
                TextBrick ReportFooterLeftBrick = new TextBrick();
                float ReportFooterLeftBrickWidth = GetWidthByPercent(32, e);
                float ReportFooterLeftBrickTextHeight;
                if (!mAfisareGestionar)
                {
                    ReportFooterLeftBrick.Text = mOptiuniRow.FooterLeftText;
                    ReportFooterLeftBrickTextHeight =
                        Graphics.FromHwnd(this.Handle)
                            .MeasureString(mOptiuniRow.FooterLeftText, mFooterLeftFont,
                                Convert.ToInt32(Math.Floor(ReportFooterLeftBrickWidth)))
                            .Height;

                }
                else
                {
                    ReportFooterLeftBrick.Text = mGestionariCustomString;
                    ReportFooterLeftBrickTextHeight =
                        Graphics.FromHwnd(this.Handle)
                            .MeasureString(mGestionariCustomString, mFooterLeftFont,
                                Convert.ToInt32(Math.Floor(ReportFooterLeftBrickWidth)))
                            .Height;

                }
                ReportFooterLeftBrick.Font = mFooterLeftFont;
                ReportFooterLeftBrick.ForeColor = mFooterLeftColor;
                ReportFooterLeftBrick.StringFormat = new BrickStringFormat(StringAlignment.Near);
                ReportFooterLeftBrick.Sides = BorderSide.None;
                ReportFooterLeftBrick.BackColor = Color.Transparent;

                e.Graph.DrawBrick(ReportFooterLeftBrick,
                    new RectangleF(0, 10, ReportFooterLeftBrickWidth, ReportFooterLeftBrickTextHeight + 10));

                //Report footer center
                float ReportFooterCenterBrickWidth = GetWidthByPercent(32, e);
                float ReportFooterCenterBrickTextHeight;
                TextBrick ReportFooterCenterBrick = new TextBrick();
                if (!mAfisareGestionar)
                {
                    ReportFooterCenterBrick.Text = mOptiuniRow.FooterCenterText;
                    ReportFooterCenterBrickTextHeight =
                        Graphics.FromHwnd(this.Handle)
                            .MeasureString(mOptiuniRow.FooterCenterText, mFooterCenterFont,
                                Convert.ToInt32(Math.Floor(ReportFooterCenterBrickWidth)))
                            .Height;
                }
                else
                {
                    ReportFooterCenterBrick.Text = mComisieCustomString;
                    ReportFooterCenterBrickTextHeight =
                        Graphics.FromHwnd(this.Handle)
                            .MeasureString(mComisieCustomString, mFooterCenterFont,
                                Convert.ToInt32(Math.Floor(ReportFooterCenterBrickWidth)))
                            .Height;
                }
                ReportFooterCenterBrick.Font = mFooterCenterFont;
                ReportFooterCenterBrick.ForeColor = mFooterCenterColor;
                ReportFooterCenterBrick.StringFormat = new BrickStringFormat(StringAlignment.Center);
                ReportFooterCenterBrick.Sides = BorderSide.None;
                ReportFooterCenterBrick.BackColor = Color.Transparent;


                e.Graph.DrawBrick(ReportFooterCenterBrick,
                    new RectangleF(GetWidthByPercent(34, e), 10, ReportFooterCenterBrickWidth,
                        ReportFooterCenterBrickTextHeight + 10));

                //Report footer right
                TextBrick ReportFooterRightBrick = new TextBrick();
                ReportFooterRightBrick.Text = mOptiuniRow.FooterRightText;
                ReportFooterRightBrick.Font = mFooterRightFont;
                ReportFooterRightBrick.ForeColor = mFooterRightColor;
                ReportFooterRightBrick.StringFormat = new BrickStringFormat(StringAlignment.Far);
                ReportFooterRightBrick.Sides = BorderSide.None;
                ReportFooterRightBrick.BackColor = Color.Transparent;
                float ReportFooterRightBrickWidth = GetWidthByPercent(32, e);
                float ReportFooterRightBrickTextHeight =
                    Graphics.FromHwnd(this.Handle)
                        .MeasureString(mOptiuniRow.FooterRightText, mFooterRightFont,
                            Convert.ToInt32(Math.Floor(ReportFooterRightBrickWidth)))
                        .Height;
                e.Graph.DrawBrick(ReportFooterRightBrick,
                    new RectangleF(GetWidthByPercent(68, e), 10, ReportFooterRightBrickWidth,
                        ReportFooterRightBrickTextHeight + 10));
            }

        }

        private void ReportLink_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            e.Graph.PageUnit = GraphicsUnit.Pixel;
            if (mOptiuniRow != null)
            {
                // Report header left
                TextBrick ReportHeaderLeftBrick = new TextBrick();
                ReportHeaderLeftBrick.Text = mOptiuniRow.HeaderLeftText;
                ReportHeaderLeftBrick.Font = mHeaderLeftFont;
                ReportHeaderLeftBrick.ForeColor = mHeaderLeftColor;
                ReportHeaderLeftBrick.StringFormat = new BrickStringFormat(StringAlignment.Near);
                ReportHeaderLeftBrick.Sides = BorderSide.None;
                float ReportHeaderLeftWidth = GetWidthByPercent(32, e);
                float ReportHeaderLeftTextHeight =
                    Graphics.FromHwnd(this.Handle)
                        .MeasureString(mOptiuniRow.HeaderLeftText, mHeaderLeftFont,
                            Convert.ToInt32(Math.Floor(ReportHeaderLeftWidth)))
                        .Height;
                e.Graph.DrawBrick(ReportHeaderLeftBrick,
                    new RectangleF(0, 10, ReportHeaderLeftWidth, ReportHeaderLeftTextHeight));

                // Report header center
                TextBrick ReportHeaderCenterBrick = new TextBrick();
                ReportHeaderCenterBrick.Text = mOptiuniRow.HeaderCenterText;
                ReportHeaderCenterBrick.Font = mHeaderCenterFont;
                ReportHeaderCenterBrick.ForeColor = mHeaderCenterColor;
                ReportHeaderCenterBrick.Sides = BorderSide.None;
                ReportHeaderCenterBrick.StringFormat = new BrickStringFormat(StringAlignment.Center);
                float ReportHeaderCenterWidth = GetWidthByPercent(32, e);
                float ReportHeaderCenterTextHeight =
                    Graphics.FromHwnd(this.Handle)
                        .MeasureString(mOptiuniRow.HeaderCenterText, mHeaderCenterFont,
                            Convert.ToInt32(Math.Floor(ReportHeaderCenterWidth)))
                        .Height;
                e.Graph.DrawBrick(ReportHeaderCenterBrick,
                    new RectangleF(GetWidthByPercent(34, e), 10, ReportHeaderCenterWidth, ReportHeaderCenterTextHeight));

                // Report header right
                TextBrick ReportHeaderRightBrick = new TextBrick();
                ReportHeaderRightBrick.Text = mOptiuniRow.HeaderRightText;
                ReportHeaderRightBrick.Font = mHeaderRightFont;
                ReportHeaderRightBrick.ForeColor = mHeaderRightColor;
                ReportHeaderRightBrick.Sides = BorderSide.None;
                ReportHeaderRightBrick.StringFormat = new BrickStringFormat(StringAlignment.Far);
                float ReportHeaderRightWidth = GetWidthByPercent(32, e);
                float ReportHeaderRightTextHeight =
                    Graphics.FromHwnd(this.Handle)
                        .MeasureString(mOptiuniRow.HeaderRightText, mHeaderRightFont,
                            Convert.ToInt32(Math.Floor(ReportHeaderRightWidth)))
                        .Height;
                e.Graph.DrawBrick(ReportHeaderRightBrick,
                    new RectangleF(GetWidthByPercent(68, e), 10, ReportHeaderRightWidth, ReportHeaderRightTextHeight));

                // Report title
                TextBrick ReportTitleBrick = new TextBrick();
                ReportTitleBrick.Text = mListName;
                ReportTitleBrick.Font = this.labelTitle.Font;
                ReportTitleBrick.Sides = BorderSide.None;
                ReportTitleBrick.StringFormat = new BrickStringFormat(StringAlignment.Center);
                float ReportTitleTextHeight =
                    Graphics.FromHwnd(this.Handle).MeasureString(mListName, this.labelTitle.Font).Height;
                e.Graph.DrawBrick(ReportTitleBrick,
                    new RectangleF(0,
                        20F +
                        GetMaxValue(ReportHeaderLeftTextHeight, ReportHeaderCenterTextHeight,
                            ReportHeaderRightTextHeight), e.Graph.ClientPageSize.Width, ReportTitleTextHeight * 3));

            }
            else
            {
                // Report title
                TextBrick ReportTitleBrick = new TextBrick();
                ReportTitleBrick.Text = mListName;
                ReportTitleBrick.Font = this.labelTitle.Font;
                ReportTitleBrick.Sides = BorderSide.None;
                ReportTitleBrick.StringFormat = new BrickStringFormat(StringAlignment.Center);
                float ReportTitleTextHeight =
                    Graphics.FromHwnd(this.Handle).MeasureString(mListName, this.labelTitle.Font).Height;
                e.Graph.DrawBrick(ReportTitleBrick,
                    new RectangleF(0, 20F, e.Graph.ClientPageSize.Width, ReportTitleTextHeight));
            }
        }

        private void ReportLink_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            //Report filter
            if (mFilterText != string.Empty)
            {
                TextBrick ReportFilterBrick = new TextBrick();
                ReportFilterBrick.Text = mFilterText;
                ReportFilterBrick.Font = new Font("Courier New", mFontSize);
                ReportFilterBrick.Sides = BorderSide.None;
                ReportFilterBrick.StringFormat = new BrickStringFormat(StringAlignment.Near);
                float ReportFilterTextHeight =
                    Graphics.FromHwnd(this.Handle).MeasureString(ReportFilterBrick.Text, ReportFilterBrick.Font).Height;
                e.Graph.DrawBrick(ReportFilterBrick,
                    new RectangleF(0, 0F, e.Graph.ClientPageSize.Width, ReportFilterTextHeight + 10F));
            }
        }

        private void ReportLink_CreateReportHeaderAreaNew(object sender, CreateAreaEventArgs e)
        {
            e.Graph.PageUnit = GraphicsUnit.Pixel;
            if (mOptiuniRow != null)
            {
                // Report header left
                TextBrick ReportHeaderLeftBrick = new TextBrick();
                ReportHeaderLeftBrick.Text = mOptiuniRow.HeaderLeftText;
                ReportHeaderLeftBrick.Font = mHeaderLeftFont;
                ReportHeaderLeftBrick.ForeColor = mHeaderLeftColor;
                ReportHeaderLeftBrick.StringFormat = new BrickStringFormat(StringAlignment.Near);
                ReportHeaderLeftBrick.Sides = BorderSide.None;
                float ReportHeaderLeftWidth = GetWidthByPercent(32, e);
                float ReportHeaderLeftTextHeight =
                    Graphics.FromHwnd(this.Handle)
                        .MeasureString(mOptiuniRow.HeaderLeftText, mHeaderLeftFont,
                            Convert.ToInt32(Math.Floor(ReportHeaderLeftWidth)))
                        .Height;
                e.Graph.DrawBrick(ReportHeaderLeftBrick,
                    new RectangleF(0, 0F, ReportHeaderLeftWidth, ReportHeaderLeftTextHeight));

                // Report header center
                TextBrick ReportHeaderCenterBrick = new TextBrick();
                ReportHeaderCenterBrick.Text = mOptiuniRow.HeaderCenterText;
                ReportHeaderCenterBrick.Font = mHeaderCenterFont;
                ReportHeaderCenterBrick.ForeColor = mHeaderCenterColor;
                ReportHeaderCenterBrick.Sides = BorderSide.None;
                ReportHeaderCenterBrick.StringFormat = new BrickStringFormat(StringAlignment.Center);
                float ReportHeaderCenterWidth = GetWidthByPercent(32, e);
                float ReportHeaderCenterTextHeight =
                    Graphics.FromHwnd(this.Handle)
                        .MeasureString(mOptiuniRow.HeaderCenterText, mHeaderCenterFont,
                            Convert.ToInt32(Math.Floor(ReportHeaderCenterWidth)))
                        .Height;
                e.Graph.DrawBrick(ReportHeaderCenterBrick,
                    new RectangleF(GetWidthByPercent(34, e), 0F, ReportHeaderCenterWidth, ReportHeaderCenterTextHeight));

                // Report header right
                TextBrick ReportHeaderRightBrick = new TextBrick();
                ReportHeaderRightBrick.Text = mOptiuniRow.HeaderRightText;
                ReportHeaderRightBrick.Font = mHeaderRightFont;
                ReportHeaderRightBrick.ForeColor = mHeaderRightColor;
                ReportHeaderRightBrick.Sides = BorderSide.None;
                ReportHeaderRightBrick.StringFormat = new BrickStringFormat(StringAlignment.Far);
                float ReportHeaderRightWidth = GetWidthByPercent(32, e);
                float ReportHeaderRightTextHeight =
                    Graphics.FromHwnd(this.Handle)
                        .MeasureString(mOptiuniRow.HeaderRightText, mHeaderRightFont,
                            Convert.ToInt32(Math.Floor(ReportHeaderRightWidth)))
                        .Height;
                e.Graph.DrawBrick(ReportHeaderRightBrick,
                    new RectangleF(GetWidthByPercent(68, e), 0F, ReportHeaderRightWidth, ReportHeaderRightTextHeight));

                // Report title
                TextBrick ReportTitleBrick = new TextBrick();
                ReportTitleBrick.Text = mListName;
                ReportTitleBrick.Font = this.labelTitle.Font;
                ReportTitleBrick.Sides = BorderSide.None;
                ReportTitleBrick.StringFormat = new BrickStringFormat(StringAlignment.Center);
                float ReportTitleTextHeight =
                    Graphics.FromHwnd(this.Handle).MeasureString(mListName, this.labelTitle.Font).Height;
                e.Graph.DrawBrick(ReportTitleBrick,
                    new RectangleF(0,
                        20F +
                        GetMaxValue(ReportHeaderLeftTextHeight, ReportHeaderCenterTextHeight,
                            ReportHeaderRightTextHeight), e.Graph.ClientPageSize.Width, ReportTitleTextHeight * 3));

            }
            else
            {
                // Report title
                TextBrick ReportTitleBrick = new TextBrick();
                ReportTitleBrick.Text = mListName;
                ReportTitleBrick.Font = this.labelTitle.Font;
                ReportTitleBrick.Sides = BorderSide.None;
                ReportTitleBrick.StringFormat = new BrickStringFormat(StringAlignment.Center);
                float ReportTitleTextHeight =
                    Graphics.FromHwnd(this.Handle).MeasureString(mListName, this.labelTitle.Font).Height;
                e.Graph.DrawBrick(ReportTitleBrick,
                    new RectangleF(0, 20F, e.Graph.ClientPageSize.Width, ReportTitleTextHeight));
            }
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
            if (
                XtraMessageBox.Show("Doriti sa deschideti acest fisier?", "Export", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
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
                    XtraMessageBox.Show(this,
                        "Nu exista instalata o aplicatie potrivita pentru deschiderea fisierului ce contine datele exportate",
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    mProcessToStart.Close();
                }
            }
            progressBarControlBaseWindowGrid.Position = 0;
        }

        private void ExportTo(IExportProvider provider)
        {
            progressBarControlBaseWindowGrid.BringToFront();
            progressBarControlBaseWindowGrid.Visible = true;
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            BaseExportLink link = mGridControl.FocusedView.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = true;
            link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
            link.ExportTo(true);
            provider.Dispose();
            link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
            Cursor.Current = currentCursor;
            progressBarControlBaseWindowGrid.Visible = false;
        }

        private void ExportToPDF(string fileName)
        {
            GetOptiuniFont();
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            PrintableComponentLink ReportLink = new PrintableComponentLink(new PrintingSystem());
            ReportLink.Component = mGridControl;
            if (comboBoxEditDimensiune.SelectedItem == null)
                ReportLink.PaperKind = PaperKind.A4;
            else
                ReportLink.PaperKind = (PaperKind) comboBoxEditDimensiune.SelectedItem;
            ReportLink.Landscape = Convert.ToBoolean(mIsLandscape);
            ReportLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(ReportLink_CreateMarginalHeaderArea);
            ReportLink.CreateMarginalFooterArea += new CreateAreaEventHandler(ReportLink_CreateMarginalFooterArea);

            ReportLink.CreateReportFooterArea += new CreateAreaEventHandler(ReportLink_CreateReportFooterArea);
            ReportLink.CreateDocument();
            ReportLink.PrintingSystem.ExportToPdf(@fileName);
            //ReportLink.ShowPreview();
            Cursor.Current = currentCursor;
        }



        private void GetOptiuniFont()
        {
            if (mOptiuniRow != null)
            {
                string fFontName;
                float fFontSize;

                #region Header Left

                fFontName = "Arial";
                fFontSize = 8.25F;
                if (!mOptiuniRow.IsHeaderLeftFontNameNull())
                {
                    fFontName = mOptiuniRow.HeaderLeftFontName;
                }
                if (!mOptiuniRow.IsHeaderLeftFontSizeNull())
                {
                    fFontSize = (float) mOptiuniRow.HeaderLeftFontSize;
                }
                if (!mOptiuniRow.IsHeaderLeftColorNameNull())
                {
                    mHeaderLeftColor = Color.FromName(mOptiuniRow.HeaderLeftColorName);
                }
                else
                {
                    mHeaderLeftColor = Color.FromName(mFontColor);
                }
                if (!mOptiuniRow.IsHeaderLeftFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniHeaderLeft =
                        (OptiuniFiltre) serializer.Deserialize(new StringReader(mOptiuniRow.HeaderLeftFontStyle));
                    if (mOptiuniHeaderLeft != null)
                    {
                        mHeaderLeftStyle = mOptiuniHeaderLeft.FontStyle;
                    }
                }
                try
                {
                    mHeaderLeftFont = new Font(fFontName, fFontSize, mHeaderLeftStyle);
                }
                catch
                {
                    mHeaderLeftFont = new Font(mFontName, mFontSize, FontStyle.Regular);
                }

                #endregion

                #region Header Center

                fFontName = "Arial";
                fFontSize = 8.25F;
                if (!mOptiuniRow.IsHeaderCenterFontNameNull())
                {
                    fFontName = mOptiuniRow.HeaderCenterFontName;
                }
                if (!mOptiuniRow.IsHeaderCenterFontSizeNull())
                {
                    fFontSize = (float) mOptiuniRow.HeaderCenterFontSize;
                }
                if (!mOptiuniRow.IsHeaderCenterColorNameNull())
                {
                    mHeaderCenterColor = Color.FromName(mOptiuniRow.HeaderCenterColorName);
                }
                else
                {
                    mHeaderCenterColor = Color.FromName(mFontColor);
                }
                if (!mOptiuniRow.IsHeaderCenterFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniHeaderCenter =
                        (OptiuniFiltre) serializer.Deserialize(new StringReader(mOptiuniRow.HeaderCenterFontStyle));
                    if (mOptiuniHeaderCenter != null)
                    {
                        mHeaderCenterStyle = mOptiuniHeaderCenter.FontStyle;
                    }
                }
                try
                {
                    mHeaderCenterFont = new Font(fFontName, fFontSize, mHeaderCenterStyle);
                }
                catch
                {
                    mHeaderCenterFont = new Font(mFontName, mFontSize, FontStyle.Regular);
                }

                #endregion

                #region Header Right

                fFontName = "Arial";
                fFontSize = 8.25F;
                if (!mOptiuniRow.IsHeaderRightFontNameNull())
                {
                    fFontName = mOptiuniRow.HeaderRightFontName;
                }
                if (!mOptiuniRow.IsHeaderRightFontSizeNull())
                {
                    fFontSize = (float) mOptiuniRow.HeaderRightFontSize;
                }
                if (!mOptiuniRow.IsHeaderRightColorNameNull())
                {
                    mHeaderRightColor = Color.FromName(mOptiuniRow.HeaderRightColorName);
                }
                else
                {
                    mHeaderRightColor = Color.FromName(mFontColor);
                }
                if (!mOptiuniRow.IsHeaderRightFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniHeaderRight =
                        (OptiuniFiltre) serializer.Deserialize(new StringReader(mOptiuniRow.HeaderRightFontStyle));
                    if (mOptiuniHeaderRight != null)
                    {
                        mHeaderRightStyle = mOptiuniHeaderRight.FontStyle;
                    }
                }
                try
                {
                    mHeaderRightFont = new Font(fFontName, fFontSize, mHeaderRightStyle);
                }
                catch
                {
                    mHeaderRightFont = new Font(mFontName, mFontSize, FontStyle.Regular);
                }

                #endregion

                #region Footer Left

                fFontName = "Arial";
                fFontSize = 8.25F;
                if (!mOptiuniRow.IsFooterLeftFontNameNull())
                {
                    fFontName = mOptiuniRow.FooterLeftFontName;
                }
                if (!mOptiuniRow.IsFooterLeftFontSizeNull())
                {
                    fFontSize = (float) mOptiuniRow.FooterLeftFontSize;
                }
                if (!mOptiuniRow.IsFooterLeftColorNameNull())
                {
                    mFooterLeftColor = Color.FromName(mOptiuniRow.FooterLeftColorName);
                }
                else
                {
                    mFooterLeftColor = Color.FromName(mFontColor);
                }
                if (!mOptiuniRow.IsFooterLeftFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniFooterLeft =
                        (OptiuniFiltre) serializer.Deserialize(new StringReader(mOptiuniRow.FooterLeftFontStyle));
                    if (mOptiuniFooterLeft != null)
                    {
                        mFooterLeftStyle = mOptiuniFooterLeft.FontStyle;
                    }
                }
                try
                {
                    mFooterLeftFont = new Font(fFontName, fFontSize, mFooterLeftStyle);
                }
                catch
                {
                    mFooterLeftFont = new Font(mFontName, mFontSize, FontStyle.Regular);
                }

                #endregion

                #region Footer Center

                fFontName = "Arial";
                fFontSize = 8.25F;
                if (!mOptiuniRow.IsFooterCenterFontNameNull())
                {
                    fFontName = mOptiuniRow.FooterCenterFontName;
                }
                if (!mOptiuniRow.IsFooterCenterFontSizeNull())
                {
                    fFontSize = (float) mOptiuniRow.FooterCenterFontSize;
                }
                if (!mOptiuniRow.IsFooterCenterColorNameNull())
                {
                    mFooterCenterColor = Color.FromName(mOptiuniRow.FooterCenterColorName);
                }
                else
                {
                    mFooterCenterColor = Color.FromName(mFontColor);
                }
                if (!mOptiuniRow.IsFooterCenterFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniFooterCenter =
                        (OptiuniFiltre) serializer.Deserialize(new StringReader(mOptiuniRow.FooterCenterFontStyle));
                    if (mOptiuniFooterCenter != null)
                    {
                        mFooterCenterStyle = mOptiuniFooterCenter.FontStyle;
                    }
                }
                try
                {
                    mFooterCenterFont = new Font(fFontName, fFontSize, mFooterCenterStyle);
                }
                catch
                {
                    mFooterCenterFont = new Font(mFontName, mFontSize, FontStyle.Regular);
                }

                #endregion

                #region Footer Right

                fFontName = "Arial";
                fFontSize = 8.25F;
                if (!mOptiuniRow.IsFooterRightFontNameNull())
                {
                    fFontName = mOptiuniRow.FooterRightFontName;
                }
                if (!mOptiuniRow.IsFooterRightFontSizeNull())
                {
                    fFontSize = (float) mOptiuniRow.FooterRightFontSize;
                }
                if (!mOptiuniRow.IsFooterRightColorNameNull())
                {
                    mFooterRightColor = Color.FromName(mOptiuniRow.FooterRightColorName);
                }
                else
                {
                    mFooterRightColor = Color.FromName(mFontColor);
                }
                if (!mOptiuniRow.IsFooterRightFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniFooterRight =
                        (OptiuniFiltre) serializer.Deserialize(new StringReader(mOptiuniRow.FooterRightFontStyle));
                    if (mOptiuniFooterRight != null)
                    {
                        mFooterRightStyle = mOptiuniFooterRight.FontStyle;
                    }
                }
                try
                {
                    mFooterRightFont = new Font(fFontName, fFontSize, mFooterRightStyle);
                }
                catch
                {
                    mFooterRightFont = new Font(mFontName, mFontSize, FontStyle.Regular);
                }

                #endregion
            }
        }

        private int GetReportTopMargin()
        {
            float ReportHeaderLeftTextHeight =
                Graphics.FromHwnd(this.Handle)
                    .MeasureString(mOptiuniRow["HeaderLeftText"].ToString(),
                        new Font(mFontName, mFontSize, mHeaderLeftStyle))
                    .Height;
            float ReportHeaderCenterTextHeight =
                Graphics.FromHwnd(this.Handle)
                    .MeasureString(mOptiuniRow["HeaderCenterText"].ToString(),
                        new Font(mFontName, mFontSize, mHeaderCenterStyle))
                    .Height;
            float ReportHeaderRightTextHeight =
                Graphics.FromHwnd(this.Handle)
                    .MeasureString(mOptiuniRow["HeaderRightText"].ToString(),
                        new Font(mFontName, mFontSize, mHeaderRightStyle))
                    .Height;
            return 70 +
                   Convert.ToInt32(GetMaxValue(ReportHeaderLeftTextHeight, ReportHeaderCenterTextHeight,
                                       ReportHeaderRightTextHeight)
                                   +
                                   Graphics.FromHwnd(this.Handle).MeasureString(mListName, this.labelTitle.Font).Height);
        }

        private float GetMaxValue(params float[] list)
        {
            float TempValue = 0.0F;

            for (int i = 0; i < list.Length; i++)
            {
                if (TempValue < list[i])
                {
                    TempValue = list[i];
                }
            }
            return TempValue;
        }

        private float GetWidthByPercent(int Percent, CreateAreaEventArgs e)
        {
            return e.Graph.ClientPageSize.Width * Percent / 100;
        }


        #endregion

        #region Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize();
                this.ShowInTaskbar = false;

                this.Bind();
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }

        public override void Bind()
        {
            base.Bind();
            comboBoxEditDimensiune.Properties.Items.Clear();

            comboBoxEditDimensiune.Properties.Items.Add(PaperKind.A4);
            comboBoxEditDimensiune.Properties.Items.Add(PaperKind.A4Rotated);
            comboBoxEditDimensiune.Properties.Items.Add(PaperKind.A5);
            comboBoxEditDimensiune.Properties.Items.Add(PaperKind.A5Rotated);
            comboBoxEditDimensiune.Properties.Items.Add(PaperKind.A3);
            comboBoxEditDimensiune.Properties.Items.Add(PaperKind.A3Rotated);
            comboBoxEditDimensiune.Properties.Items.Add(PaperKind.Letter);

            if (mDataSet.tblSetariPaginaRaport.Rows.Count > 0)
            {
                DataRow dr = mDataSet.tblSetariPaginaRaport.Rows[0];
                if (dr != null)
                {
                    try
                    {
                        comboBoxEditDimensiune.SelectedIndex = Convert.ToInt16(dr["Dimensiune"]);
                    }
                    catch
                    {
                        comboBoxEditDimensiune.SelectedItem = PaperKind.A4;
                    }
                    if (Convert.ToBoolean(dr["Landscape"].ToString()))
                        comboBoxEditOrientare.SelectedIndex = 1;
                    else
                        comboBoxEditOrientare.SelectedIndex = 0;
                }
            }
        }

        #endregion

        #region Public Virtual Methods

        public virtual void Initialize(DevExpress.XtraGrid.GridControl pGridControl)
        {
            base.Initialize();
            this.mGridControl = pGridControl;
            mListName = this.labelTitle.Text;
          
            mController =
                (BaseWindowFiltreController)
                Context.CreateController(
                    "CommonGUIControllers.Base.BaseWindowFiltreController, CommonGUIControllers");
            mController.AssemblyName = mAssemblyName;
            mController.Load();
            mFiltreDataSet = (BaseWindowFiltreDataSet) mController.DataSet;

            mDataSet = new BaseWindowGridDataSet();
            mDataSet.Merge(mFiltreDataSet);
            mDataSet.AcceptChanges();
            if (mDataSet.Tables["tblOptiuni"].Rows.Count > 0)
            {
                mOptiuniRow = (BaseWindowGridDataSet.tblOptiuniRow) mDataSet.Tables["tblOptiuni"].Rows[0];
            }
            this.mGridControl = pGridControl;

            if (SalveazaLayoutGrid)
                Utilities.Utility.RestoreGridLayoutFromXml(this.mGridControl, this, Context.UserName);

            //pun in lista de configurari coloanele din grid
            if (mGridControl.Views.Count > 0)
            {
                mGridView = (GridView) mGridControl.MainView;
                for (int i = 0; i < mGridView.Columns.Count; i++)
                {
                    if (mGridView.Columns[i].OptionsColumn.ShowInCustomizationForm)
                    {
                        string str = mGridView.Columns[i].CustomizationCaption;
                        if (str == string.Empty)
                            str = mGridView.Columns[i].Caption;
                        checkedListBoxControlConfigurareCol.Items.Add(str, mGridView.Columns[i].Visible);
                        int j = checkedListBoxControlConfigurareCol.Items.Count - 1;
                        mColumnNameList[j] = mGridView.Columns[i].Name;
                    }
                }
                //daca e bandedgrid, pun bandurile in lista de configurare

                BandedGridView bandedView = mGridControl.MainView as BandedGridView;
                if (bandedView != null)
                {
                    mIsBandedGrid = true;
                    for (int i = 0; i < bandedView.Bands.Count; i++)
                    {
                        if (bandedView.Bands[i].OptionsBand.ShowInCustomizationForm)
                        {
                            string str = bandedView.Bands[i].CustomizationCaption;
                            if (str == string.Empty)
                                str = bandedView.Bands[i].Caption;
                            checkedListBoxControlBands.Items.Add(str, bandedView.Bands[i].Visible);
                            int k = checkedListBoxControlBands.Items.Count - 1;
                            mBandNameList[i] = bandedView.Bands[i].Name;
                        }
                    }
                }
            }


            mFileName = "SetariListe.xml";
            mUserName = Context.UserName;

            Utilities.Utility.LoadDataSetFromXmlFile(mDataSet, mFileName, mUserName);

            foreach (DataRow dr in mFiltreDataSet.tblListeBase.Rows)
            {
                if (Convert.ToBoolean(dr["ExportEnabled"]))
                {
                    navBarItemSemnareDigitala.Visible = true;
                }
            }
        }

        public virtual void Imprimare()
        {
            if (mGridControl != null)
            {
                GetOptiuniFont();
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                PrintableComponentLink ReportLink = new PrintableComponentLink(new PrintingSystem());
                ReportLink.Component = mGridControl;
                ReportLink.PaperKind = (PaperKind) comboBoxEditDimensiune.SelectedItem;
                ReportLink.Landscape = Convert.ToBoolean(mIsLandscape);
                ReportLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(ReportLink_CreateMarginalHeaderArea);
                ReportLink.CreateMarginalFooterArea += new CreateAreaEventHandler(ReportLink_CreateMarginalFooterArea);
                if (!mAfisareSubsolPerPagina)
                    ReportLink.CreateReportFooterArea += new CreateAreaEventHandler(ReportLink_CreateReportFooterArea);
                ReportLink.CreateDocument();
                System.Drawing.Printing.PrinterSettings sp = new System.Drawing.Printing.PrinterSettings();
                ReportLink.Print(sp.PrinterName);
                Cursor.Current = currentCursor;
                this.BringToFront();
            }
        }

        public virtual void Listare()
        {
            if (mGridControl != null)
            {
                GetOptiuniFont();
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                PrintableComponentLink ReportLink = new PrintableComponentLink(new PrintingSystem());
                ReportLink.Component = mGridControl;
                if (comboBoxEditDimensiune.SelectedItem == null)
                    ReportLink.PaperKind = PaperKind.A4;
                else
                    ReportLink.PaperKind = (PaperKind) comboBoxEditDimensiune.SelectedItem;
                ReportLink.Landscape = Convert.ToBoolean(mIsLandscape);

                ReportLink.CreateMarginalFooterArea += new CreateAreaEventHandler(ReportLink_CreateMarginalFooterArea);
                if (!mAfisareSubsolPerPagina)
                    ReportLink.CreateReportFooterArea += new CreateAreaEventHandler(ReportLink_CreateReportFooterArea);
                if (mAfiseazaAntetPrimaPagina)
                {
                    ReportLink.CreateReportHeaderArea += new CreateAreaEventHandler(ReportLink_CreateReportHeaderAreaNew);
                }
                else
                {
                    ReportLink.CreateMarginalHeaderArea +=
                        new CreateAreaEventHandler(ReportLink_CreateMarginalHeaderArea);
                    ReportLink.CreateReportHeaderArea += new CreateAreaEventHandler(ReportLink_CreateReportHeaderArea);
                }
                ReportLink.CreateDocument();
                ReportLink.ShowPreview();
                Cursor.Current = currentCursor;
                this.BringToFront();
            }
        }


        public virtual void ExportExcel()
        {
            if (mGridControl != null)
            {
                string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
                if (!String.IsNullOrEmpty(fileName.Trim()))
                {
                    mGridControl.FocusedView.ExportToXls(fileName, new XlsExportOptions(TextExportMode.Value, true));
                    OpenFile(fileName);
                }
            }
        }

        public virtual void ExportHTML()
        {
            if (mGridControl != null)
            {
                string fileName = ShowSaveFileDialog("HTML Document", "HTML Documents|*.html");
                if (!String.IsNullOrEmpty(fileName.Trim()))
                {
                    ExportTo(new ExportHtmlProvider(fileName));
                    OpenFile(fileName);
                }
            }
        }

        public virtual void ExportTxt()
        {
            if (mGridControl != null)
            {
                string fileName = ShowSaveFileDialog("Text Document", "Text Files|*.txt");
                if (!String.IsNullOrEmpty(fileName.Trim()))
                {
                    ExportTo(new ExportTxtProvider(fileName));
                    OpenFile(fileName);
                }
            }
        }

        public virtual void ExportPDF()
        {
            if (mGridControl != null)
            {
                string fileName = ShowSaveFileDialog("PDF Document", "PDF|*.pdf");
                if (!String.IsNullOrEmpty(fileName.Trim()))
                {
                    ExportToPDF(fileName);
                    OpenFile(fileName);
                }
            }
        }

        public virtual void SemnareDigitala()
        {
            try
            {
                foreach (DataRow dr in mFiltreDataSet.tblListeBase.Rows)
                {
                    mExportFileName = mTitluName = dr["ExportFileName"].ToString();
                }

                if (mGridControl != null)
                {
                    if (!String.IsNullOrEmpty(mExportFileName.Trim()))
                    {
                        string fileName = Path.Combine(Application.StartupPath,
                            (mIsMultiList ? mExportFileName + mAdditionalNameList : mExportFileName));
                        fileName += mExportFileExtension;
                        ExportToPDF(fileName);
                        //OpenFile(fileName);

                        Utilities.GSSign gsSign = new Utilities.GSSign();
                        if (gsSign.Semneaza(fileName) == 0)
                        {
                            mExportData["DocumentID"] = Guid.Empty;
                            mExportData["TitluDocument"] = (mIsMultiList ? mTitluName + mAdditionalNameList : mTitluName);
                            mExportData["ExportFileName"] = (mIsMultiList
                                                                ? mExportFileName + mAdditionalNameList
                                                                : mExportFileName) + mExportFileExtension;
                            mExportData["ExportFileExtension"] = mExportFileSignExtension;
                            mExportData["StatusAbbreviation"] = "1";

                            Context.AddUserContextParameterList("ComenziListe.BaseWindowGrid.mExportData", mExportData);
                            using (Context.CreateDialogWindow("ComenziListe.ExportDocumente,ComenziListe"))
                            {
                                Context.CreatedWindow = null;
                            }
                            Context.DeleteEntryFromUserContextParameterList("ComenziListe.BaseWindowGrid.mExportData");
                        }

                        File.Delete(fileName);
                        File.Delete(fileName + mExportFileSignExtension);
                    }
                }

            }
            catch (Exception e)
            {
                XtraMessageBox.Show(this, "Operatiunea de semnare digitala a esuat!", "Eroare", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Context.HandleException(this, e);
            }
            finally
            {

            }
        }

        public virtual void Iesire()
        {
            this.Close();
        }

        public virtual void ResetareColoane()
        {
            if (
                XtraMessageBox.Show("Sunteti siguri ca doriti resetarea coloanelor la forma initiala?", "Confirmare",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.Yes)
            {
                if (SalveazaLayoutGrid)
                {
                    Utilities.Utility.DeleteGridLayoutXml(this.mGridControl, this, Context.UserName);
                }
                SalveazaLayoutGrid = false;
                Iesire();
            }
        }

        public virtual void Salvare()
        {
            mySaveData = true;
            this.Close();
        }

        public virtual void ConfigListare()
        {

        }

        #endregion
    }
}



