using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using ComenziBase;
using ComenziListe;
using CommonDataSets;
using CommonDataSets.Base;
using CommonDataSets.GUI;
using CommonGUIControllers.Base;
using CommonGUIControllers.GUI;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting;
using GSFramework;
using Utilities;

namespace ComenziGUI
{
    public partial class ListaComenzi : BaseWindowGrid
    {
        public ListaComenzi()
        {
            InitializeComponent();
        }

     

        #region Class Fields

        private ListaComenziDataSet mDataSet;
        private ListaComenziController mController;
        private DataView mDataViewNomenclator = new DataView();
        private string mDataTableName = string.Empty;
        private string mWindowName = string.Empty;
        private Guid mFocusedID;
        private bool mIsAlege;
        private Guid mID;
        private String mDenumire;
        private string mCod;
        private bool mAbbreviationAlowNull = true;
        private bool mEventCanceled;
        private bool mUseCodAsReturnValue = true;
        private SortedList<string, object> mTagList = new SortedList<string, object>();
        private bool mIsNewRow;
        Utility mUtil = new Utility();
        BaseWindowGridDataSet.tblOptiuniRow mOptiuniRow;
        Guid mInstitutieID = Guid.Empty;
        private BaseWindowFiltreDataSet mFiltreDataSet;
        private BaseWindowFiltreController mFiltreController;
        private OptiuniListeDataSet mDataSetOptiuniListe = new OptiuniListeDataSet();
        private string mOptiuniListeTableName;
        private DataSet mDataSetOptiuniListeCustom = null;
        private string mAssemblyName;

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
        protected string mFilterText = string.Empty;

        private Guid mTipCentruID = Guid.Empty;
        private DateTime mDataStart;
        private DateTime mDataStop;
        private  Guid mFurnizorID = Guid.Empty;
        private  Guid mLotID= Guid.Empty;
        private string furnizor = string.Empty;
        private string lot = string.Empty;
        #endregion

        #region Private Methods
        private bool LoadData()
        {
            mFiltreController = (BaseWindowFiltreController)Context.GetSharedController("CommonGUIControllers.Base.BaseWindowFiltreController, CommonGUIControllers");
            mFiltreController.AssemblyName = mAssemblyName;
            mFiltreController.InstitutieID = mInstitutieID;
            if (mFiltreController.DataSet != null)
            {
                mFiltreController.DataSet.Clear();
                mFiltreController.DataSet.AcceptChanges();
            }
            mFiltreController.Load();
            if (System.Convert.ToInt16(mFiltreController.ResultCode.ToString()) != 0)
            {
                Context.HandleException(mFiltreController.ServerException.ToString());
                return false;
            }
            mFiltreDataSet = (BaseWindowFiltreDataSet)mFiltreController.DataSet;
            if (mFiltreDataSet.tblListeDet.Rows.Count > 0)
            {
                DataRow dr = mFiltreDataSet.tblListeDet.Rows[0];
                if (dr["Optiuni"] != DBNull.Value)
                {
                    TextReader reader = new StringReader(dr["Optiuni"].ToString());
                    mFiltreDataSet.tblOptiuni.ReadXml(reader);
                }
                if (!dr.IsNull("OptiuniConfig"))
                {
                    if (!String.IsNullOrEmpty(mOptiuniListeTableName))
                    {
                        TextReader reader = new StringReader(dr["OptiuniConfig"].ToString());
                        mDataSetOptiuniListe.Tables[mOptiuniListeTableName].ReadXml(reader);
                    }
                    else if (mDataSetOptiuniListeCustom != null)
                    {
                        TextReader reader = new StringReader(dr["OptiuniConfig"].ToString());
                        mDataSetOptiuniListeCustom.ReadXml(reader, XmlReadMode.ReadSchema);
                    }
                }
            }
            if (mFiltreDataSet.tblOptiuni.Rows.Count == 0)
            {
                mFiltreDataSet.tblOptiuni.Rows.Add(mFiltreDataSet.tblOptiuni.NewRow());
            }
            else
            {
                DataRow[] drsOpt = mFiltreDataSet.tblOptiuni.Select("");
                //mOptiuniRow = (BaseWindowGridDataSet.tblOptiuniRow)drsOpt[0];
            }
            BaseWindowGridDataSet mBaseWindowGridDataSet = new BaseWindowGridDataSet();
            mBaseWindowGridDataSet.Merge(mFiltreDataSet);
            if (mBaseWindowGridDataSet.tblOptiuni.Rows.Count > 0)
            {
                mOptiuniRow = (BaseWindowGridDataSet.tblOptiuniRow)mBaseWindowGridDataSet.tblOptiuni.Rows[0];
            }
            mDataSetOptiuniListe.AcceptChanges();

            return true;
        }  
        private void navBarItemConfigAntetSubsol_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (Context.CreateDialogWindow("ComenziListe.ConfigurareAntetSubsol, ComenziListe",
                                              "pCentruID=" + mInstitutieID.ToString()))
            {
                Context.CreatedWindow = null;
            }
            BaseWindowGridDataSet mBaseWindowGridDataSet = new BaseWindowGridDataSet();
            mBaseWindowGridDataSet.Merge(mFiltreDataSet);
            if (mBaseWindowGridDataSet.tblOptiuni.Rows.Count > 0)
            {
                mOptiuniRow = (BaseWindowGridDataSet.tblOptiuniRow)mBaseWindowGridDataSet.tblOptiuni.Rows[0];
            }
        }

        private void ReportLink_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
             e.Graph.PageUnit = GraphicsUnit.Pixel;
                float ReportStangaTextHeight = 0;
                float ReportFooterLeftBrickWidth = GetWidthByPercent(32, e);
                if (mOptiuniRow != null)
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
                        float ReportLogoTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(ReportLogo.Text, ReportLogo.Font).Height;
                        e.Graph.DrawBrick(ReportLogo, new RectangleF(0, 10, GetWidthByPercent(35, e), ReportLogoTextHeight));

                        string format = "{0}/{1}";
                        RectangleF r = new RectangleF(GetWidthByPercent(65, e), 10, GetWidthByPercent(35, e), e.Graph.Font.Height);
                        PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black, r, BorderSide.None);
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
                ReportFooterLeftBrick.Text = mOptiuniRow.FooterLeftText;
                ReportFooterLeftBrick.Font = mFooterLeftFont;
                ReportFooterLeftBrick.ForeColor = mFooterLeftColor;
                ReportFooterLeftBrick.StringFormat = new BrickStringFormat(StringAlignment.Near);
                ReportFooterLeftBrick.Sides = BorderSide.None;
                ReportFooterLeftBrick.BackColor = Color.Transparent;
                float ReportFooterLeftBrickTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(mOptiuniRow.FooterLeftText, mFooterLeftFont).Height;
                e.Graph.DrawBrick(ReportFooterLeftBrick, new RectangleF(0, 10, GetWidthByPercent(35, e), ReportFooterLeftBrickTextHeight + 10));

                //Report footer center
                TextBrick ReportFooterCenterBrick = new TextBrick();
                ReportFooterCenterBrick.Text = mOptiuniRow.FooterCenterText;
                ReportFooterCenterBrick.Font = mFooterCenterFont;
                ReportFooterCenterBrick.ForeColor = mFooterCenterColor;
                ReportFooterCenterBrick.StringFormat = new BrickStringFormat(StringAlignment.Center);
                ReportFooterCenterBrick.Sides = BorderSide.None;
                ReportFooterCenterBrick.BackColor = Color.Transparent;
                float ReportFooterCenterBrickTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(mOptiuniRow.FooterCenterText, mFooterCenterFont).Height;
                e.Graph.DrawBrick(ReportFooterCenterBrick, new RectangleF(GetWidthByPercent(35, e), 10, GetWidthByPercent(35, e), ReportFooterCenterBrickTextHeight + 10));

                //Report footer right
                TextBrick ReportFooterRightBrick = new TextBrick();
                ReportFooterRightBrick.Text = mOptiuniRow.FooterRightText;
                ReportFooterRightBrick.Font = mFooterRightFont;
                ReportFooterRightBrick.ForeColor = mFooterRightColor;
                ReportFooterRightBrick.StringFormat = new BrickStringFormat(StringAlignment.Far);
                ReportFooterRightBrick.Sides = BorderSide.None;
                ReportFooterRightBrick.BackColor = Color.Transparent;
                float ReportFooterRightBrickTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(mOptiuniRow.FooterRightText, mFooterRightFont).Height;
                e.Graph.DrawBrick(ReportFooterRightBrick, new RectangleF(GetWidthByPercent(65, e), 10, GetWidthByPercent(35, e), ReportFooterRightBrickTextHeight + 10));

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
                float ReportHeaderLeftTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(mOptiuniRow.HeaderLeftText, mFooterLeftFont).Height;
                e.Graph.DrawBrick(ReportHeaderLeftBrick, new RectangleF(0, 10F, GetWidthByPercent(35, e), ReportHeaderLeftTextHeight));

                // Report header center
                TextBrick ReportHeaderCenterBrick = new TextBrick();
                ReportHeaderCenterBrick.Text = mOptiuniRow.HeaderCenterText;
                ReportHeaderCenterBrick.Font = mHeaderCenterFont;
                ReportHeaderCenterBrick.ForeColor = mHeaderCenterColor;
                ReportHeaderCenterBrick.Sides = BorderSide.None;
                ReportHeaderCenterBrick.StringFormat = new BrickStringFormat(StringAlignment.Center);
                float ReportHeaderCenterTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(mOptiuniRow.HeaderCenterText, mHeaderCenterFont).Height;
                e.Graph.DrawBrick(ReportHeaderCenterBrick, new RectangleF(GetWidthByPercent(35, e), 10F, GetWidthByPercent(30, e), ReportHeaderCenterTextHeight));

                // Report header right
                TextBrick ReportHeaderRightBrick = new TextBrick();
                ReportHeaderRightBrick.Text = mOptiuniRow.HeaderRightText;
                ReportHeaderRightBrick.Font = mHeaderRightFont;
                ReportHeaderRightBrick.ForeColor = mHeaderRightColor;
                ReportHeaderRightBrick.Sides = BorderSide.None;
                ReportHeaderRightBrick.StringFormat = new BrickStringFormat(StringAlignment.Far);
                float ReportHeaderRightTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(mOptiuniRow.HeaderRightText, mHeaderRightFont).Height;
                e.Graph.DrawBrick(ReportHeaderRightBrick, new RectangleF(GetWidthByPercent(65, e), 10F, GetWidthByPercent(35, e), ReportHeaderRightTextHeight));

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
                float ReportFilterTextHeight = Graphics.FromHwnd(this.Handle).MeasureString(ReportFilterBrick.Text, ReportFilterBrick.Font).Height;
                e.Graph.DrawBrick(ReportFilterBrick, new RectangleF(0, 0F, e.Graph.ClientPageSize.Width, ReportFilterTextHeight + 10F));
            }
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
                    fFontSize = (float)mOptiuniRow.HeaderLeftFontSize;
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
                    mOptiuniHeaderLeft = (OptiuniFiltre)serializer.Deserialize(new StringReader(mOptiuniRow.HeaderLeftFontStyle));
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
                    fFontSize = (float)mOptiuniRow.HeaderCenterFontSize;
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
                    mOptiuniHeaderCenter = (OptiuniFiltre)serializer.Deserialize(new StringReader(mOptiuniRow.HeaderCenterFontStyle));
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
                    fFontSize = (float)mOptiuniRow.HeaderRightFontSize;
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
                    mOptiuniHeaderRight = (OptiuniFiltre)serializer.Deserialize(new StringReader(mOptiuniRow.HeaderRightFontStyle));
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
                    fFontSize = (float)mOptiuniRow.FooterLeftFontSize;
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
                    mOptiuniFooterLeft = (OptiuniFiltre)serializer.Deserialize(new StringReader(mOptiuniRow.FooterLeftFontStyle));
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
                    fFontSize = (float)mOptiuniRow.FooterCenterFontSize;
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
                    mOptiuniFooterCenter = (OptiuniFiltre)serializer.Deserialize(new StringReader(mOptiuniRow.FooterCenterFontStyle));
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
                    fFontSize = (float)mOptiuniRow.FooterRightFontSize;
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
                    mOptiuniFooterRight = (OptiuniFiltre)serializer.Deserialize(new StringReader(mOptiuniRow.FooterRightFontStyle));
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
        private float GetWidthByPercent(int Percent, CreateAreaEventArgs e)
        {
            return e.Graph.ClientPageSize.Width * Percent / 100;
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
        private void PrelucareDate()
        {

            mDataSet.tblDate.Columns.Add("Lot", typeof(string));
            mDataSet.tblDate.Columns.Add("AcordCadru", typeof(string));
            mDataSet.tblDate.Columns.Add("NrCrt",typeof(Int64));
            mDataSet.tblDate.Columns.Add("DenumireProdus", typeof(string));
            mDataSet.tblDate.Columns.Add("UM", typeof(string));
            mDataSet.tblDate.Columns.Add("Pret", typeof(decimal));
            foreach (DataRow dr in mDataSet.tblCentru.Select())
            {
                mDataSet.tblDate.Columns.Add(dr["Denumire"].ToString(), typeof(decimal));
            }
            mDataSet.tblDate.Columns.Add("CantitateTotala", typeof(decimal));
            mDataSet.tblDate.Columns.Add("ValoareTotala", typeof(decimal));
            mDataSet.tblDate.Columns.Add("TVA", typeof(decimal));
            mDataSet.tblDate.Columns.Add("ValoareCuTVA", typeof(decimal));

            DataTable mDataTable = mDataSet.tblLista.DefaultView.ToTable(true, "DenumireProdus", "Pret", "UM", "Lot","AcordCadru") ;
            mDataTable.DefaultView.Sort = "DenumireProdus";
            ListaComenziDataSet.tblDateRow drDate = mDataSet.tblDate.NewtblDateRow();
            DataRow[] drLista;
            int i = 1;
            decimal mCantitate = 0,  mValoareTVA = 0, mValoarecuTVA = 0,mValoare = 0;
            foreach (DataRow drProdus in mDataTable.Rows)
            {
                mCantitate = 0;
                mValoareTVA = 0;
                mValoarecuTVA = 0;
                mValoare = 0;
                drDate = mDataSet.tblDate.NewtblDateRow();
                drDate["Lot"] = drProdus["Lot"];
                drDate["AcordCadru"] = drProdus["AcordCadru"];
                drDate["Nrcrt"] = i;
                drDate["DenumireProdus"] = drProdus["DenumireProdus"];
                drDate["UM"] = drProdus["UM"];
                drDate["Pret"] = drProdus["Pret"];
                foreach (DataRow dr in mDataSet.tblCentru.Select())
                {
                    
                    drLista =
                        mDataSet.tblLista.Select("DenumireProdus='" + drProdus["DenumireProdus"] + "' AND CentruID='" +
                                                 dr["ID"] + "' AND Lot='" + drProdus["Lot"] + "'");
                    if (drLista.Length > 0)
                    {
                        drDate[dr["Denumire"].ToString()] = drLista[0]["Cantitate"];
                        if (mUtil.IsNotObjectEmpty(drLista[0]["Cantitate"]))
                            mCantitate = mCantitate + Convert.ToDecimal(drLista[0]["Cantitate"]);

                        if (mUtil.IsNotObjectEmpty(drLista[0]["ValoareCuTVA"]))
                            mValoarecuTVA = mValoarecuTVA+ Convert.ToDecimal(drLista[0]["ValoareCuTVA"]);

                        if (mUtil.IsNotObjectEmpty(drLista[0]["ValoareTVA"]))
                            mValoareTVA = mValoareTVA + Convert.ToDecimal(drLista[0]["ValoareTVA"]);

                        if (mUtil.IsNotObjectEmpty(drLista[0]["Valoare"]))
                            mValoare= mValoare+ Convert.ToDecimal(drLista[0]["Valoare"]);
                    }
                    else
                    {
                        drDate[dr["Denumire"].ToString()] = 0;
                    }

                }

                drDate["CantitateTotala"] = mCantitate;
                drDate["ValoareTotala"] = mValoare;
                drDate["TVA"] = mValoareTVA;
                drDate["ValoareCuTVA"] = mValoarecuTVA;
                mDataSet.tblDate.AddtblDateRow(drDate);
                i++;
            }
           
            AdaugareColoaneGrid();

        }

        private void AdaugareColoaneGrid()
        {
            
            
            GridColumn mColumn = new GridColumn();
            int coloana = 0;
            if (mLotID == Guid.Empty)
            {
                mColumn.Name = "Lot";
                mColumn.Caption = "Lot";
                mColumn.FieldName = "Lot";
                mColumn.SortMode = ColumnSortMode.DisplayText;
                mColumn.VisibleIndex = coloana;
                mColumn.GroupIndex = 0;
                mColumn.AppearanceHeader.Options.UseTextOptions = true;
                mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridViewComenzi.Columns.Add(mColumn);
                coloana++;
                mColumn = new GridColumn();
                mColumn.Name = "AcordCadru";
                mColumn.Caption = " ACORD CADRU";
                mColumn.FieldName = "AcordCadru";
                mColumn.SortMode = ColumnSortMode.DisplayText;
                mColumn.VisibleIndex = coloana;
                mColumn.GroupIndex = 1;
                mColumn.AppearanceHeader.Options.UseTextOptions = true;
                mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridViewComenzi.Columns.Add(mColumn);
                coloana++;
            }
            else
            {
                mColumn = new GridColumn();
                mColumn.Name = "NrCrt";
                mColumn.Caption = "NR. CRT.";
                mColumn.FieldName = "NrCrt";
                mColumn.SortMode = ColumnSortMode.DisplayText;
                mColumn.VisibleIndex = coloana;
                mColumn.AppearanceHeader.Options.UseTextOptions = true;
                mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridViewComenzi.Columns.Add(mColumn);
                coloana++;
            }
        
            mColumn= new GridColumn();
            mColumn.Name = "DenumireProdus";
            mColumn.Caption = "DENUMIRE PRODUS";
            mColumn.FieldName = "DenumireProdus";
            mColumn.SortMode = ColumnSortMode.DisplayText;
            mColumn.VisibleIndex = coloana;
            mColumn.AppearanceHeader.Options.UseTextOptions = true;
            mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gridViewComenzi.Columns.Add(mColumn);
            coloana++;
            mColumn = new GridColumn();
            mColumn.Name = "UM";
            mColumn.Caption = "U.M.";
            mColumn.FieldName = "UM";
            mColumn.SortMode = ColumnSortMode.DisplayText;
            mColumn.VisibleIndex = coloana;
            mColumn.AppearanceHeader.Options.UseTextOptions = true;
            mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gridViewComenzi.Columns.Add(mColumn);

            coloana++;
            mColumn = new GridColumn();
            mColumn.Name = "Pret";
            mColumn.Caption = "PRET FARA T.V.A";
            mColumn.FieldName = "Pret";
            mColumn.SortMode = ColumnSortMode.DisplayText;
            mColumn.VisibleIndex = coloana;
            mColumn.AppearanceHeader.Options.UseTextOptions = true;
            mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            mColumn.ColumnEdit = repositoryItemTextEditSuma;
            gridViewComenzi.Columns.Add(mColumn);

            foreach (DataRow dr in mDataSet.tblCentru.Select())
            {
                coloana++;
                mColumn = new GridColumn();
                mColumn.Name = dr["Denumire"].ToString();
                mColumn.Caption = dr["Denumire"].ToString();
                mColumn.FieldName = dr["Denumire"].ToString();
                mColumn.SortMode = ColumnSortMode.DisplayText;
                mColumn.VisibleIndex = coloana;
                mColumn.AppearanceHeader.Options.UseTextOptions = true;
                mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                mColumn.ColumnEdit = repositoryItemTextEditSuma;
                gridViewComenzi.Columns.Add(mColumn);
            }

            coloana++;
            mColumn = new GridColumn();
            mColumn.Name = "Cantitate";
            mColumn.Caption = "CANTITATE TOTALA";
            mColumn.FieldName = "CantitateTotala";
            mColumn.SortMode = ColumnSortMode.DisplayText;
            mColumn.VisibleIndex = coloana;
            mColumn.AppearanceHeader.Options.UseTextOptions = true;
            mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            mColumn.ColumnEdit = repositoryItemTextEditSuma;
            gridViewComenzi.Columns.Add(mColumn);
            coloana++;
            mColumn = new GridColumn();
            mColumn.Name = "Valoare";
            mColumn.Caption = "VALOARE TOTALA";
            mColumn.FieldName = "ValoareTotala";
            mColumn.SortMode = ColumnSortMode.DisplayText;
            mColumn.VisibleIndex = coloana;
            mColumn.SummaryItem.SummaryType = SummaryItemType.Sum; 
            mColumn.AppearanceHeader.Options.UseTextOptions = true;
            mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            mColumn.ColumnEdit = repositoryItemTextEditSuma;
            gridViewComenzi.Columns.Add(mColumn);

            coloana++;
            mColumn = new GridColumn();
            mColumn.Name = "ValoareTVA";
            mColumn.Caption = "T.V.A";
            mColumn.FieldName = "TVA";
            mColumn.SortMode = ColumnSortMode.DisplayText;
            mColumn.VisibleIndex = coloana;
            mColumn.SummaryItem.SummaryType = SummaryItemType.Sum; 
            mColumn.AppearanceHeader.Options.UseTextOptions = true;
            mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            mColumn.ColumnEdit = repositoryItemTextEditSuma;
            gridViewComenzi.Columns.Add(mColumn);

            coloana++;
            mColumn = new GridColumn();
            mColumn.Name = "ValoareCUTVA";
            mColumn.Caption = "VALOARE CU T.V.A";
            mColumn.FieldName = "ValoareCuTVA";
            mColumn.SortMode = ColumnSortMode.DisplayText;
            mColumn.VisibleIndex = coloana;
            mColumn.SummaryItem.SummaryType= SummaryItemType.Sum; 
            mColumn.AppearanceHeader.Options.UseTextOptions = true;
            mColumn.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            mColumn.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            mColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            mColumn.ColumnEdit = repositoryItemTextEditSuma;
            gridViewComenzi.Columns.Add(mColumn);

            string mNrFormatString = string.Empty;
            string mGeneralFormat = string.Empty;
            mUtil.FormatString(2, 12, mSeparatorMii, ref mNrFormatString, ref mGeneralFormat);
            GridGroupSummaryItemCollection collection = gridViewComenzi.GroupSummary;
            foreach (GridGroupSummaryItem item in collection)
            {
                if (item.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                    item.DisplayFormat = mGeneralFormat;
            }
            GridColumnCollection cols = gridViewComenzi.Columns;
            foreach (GridColumn col in cols)
            {
                if (col.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                {
                    col.SummaryItem.DisplayFormat = mGeneralFormat;
                }
            }
            gridViewComenzi.ExpandAllGroups();
        }

        private void StabilireTitlu()
        {
            mDataSet.tblDate.CaseSensitive = true;
            foreach (DataRow dr in mDataSet.tblPartener.Select("ID='" + mFurnizorID + "'"))
            {
                furnizor = dr["Denumire"].ToString();
            }

            if (mLotID != Guid.Empty)
            {
                foreach (DataRow dr in mDataSet.tblLotBase.Select("ID='" + mLotID + "'"))
                {
                    lot = lot + dr["Denumire"].ToString() + ", ";
                }
            }
            else
            {
                foreach (DataRow dr in mDataSet.tblLotBase.Select("PartenerID='"+mFurnizorID+"'"))
                {
                    DataRow[] drdate = mDataSet.tblDate.Select("Lot='" + dr["Denumire"] + "'");
                    if (drdate.Length>0)
                    lot = lot + dr["Denumire"].ToString() + ", ";
                }
            }
            
        
        if

        (lot!= string.Empty)
            lot=lot.Remove(lot.Length - 2, 2);
        }

        #endregion

        #region Public Methods

        public override void Initialize()
        {
            try
            {
                mAssemblyName = "Comenzi.ListaComenzi, ComenziListe";
                base.AssemblyName = mAssemblyName;
                base.mCuDataListare = true;
                Utilities.Utility.DeleteGridLayoutXml(gridControlComenzi, this, Context.UserName);
                base.Initialize(gridControlComenzi);

                if (!LoadData())
                    return;
             
                object obj = Context.GetParameterValueUserContextParameterList("ComenziListe.Lista.TipCentruID");
                if (obj != null && obj.ToString()!= string.Empty) mTipCentruID = (Guid)obj;
                obj = Context.GetParameterValueUserContextParameterList("ComenziListe.Lista.DataStart");
                if (obj != null && obj.ToString() != string.Empty)
                    mDataStart = Convert.ToDateTime(obj);
                obj = Context.GetParameterValueUserContextParameterList("ComenziListe.Lista.DataStop");
                if (obj != null && obj.ToString() != string.Empty)
                    mDataStop = Convert.ToDateTime(obj);
                obj = Context.GetParameterValueUserContextParameterList("ComenziListe.Lista.FurnizorID");
                if (obj != null && obj.ToString() != string.Empty)
                    mFurnizorID =(Guid)obj;
                obj = Context.GetParameterValueUserContextParameterList("ComenziListe.Lista.LotID");
                if (obj != null && obj.ToString() != string.Empty)
                    mLotID = (Guid)obj;     
            
                navBarItemSalvare.Visible = false;
                

                mController =
                    (ListaComenziController)
                    Context.CreateController("CommonGUIControllers.GUI.ListaComenziController,CommonGUIControllers");
              
                mController.LoadLista = true;
                mController.DataStart = mDataStart;
                mController.DataStop = mDataStop;
                mController.TipCentruID = mTipCentruID;
                mController.FurnizorID = mFurnizorID;
                mController.LotID = mLotID;
                mController.Load();
                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }

                mDataSet = (ListaComenziDataSet) mController.DataSet;
                mDataSet.AcceptChanges();

                DevExpress.XtraNavBar.NavBarItemLink navBarConfigAntetSubsol = base.navBarGroupAlteActiuni.AddItem();
                navBarConfigAntetSubsol.Item.Caption = "Configurare Antet/Subsol";
                navBarConfigAntetSubsol.Item.Hint = "Configurare Antet/Subsol";
                navBarConfigAntetSubsol.Item.SmallImageIndex = 3;
                navBarConfigAntetSubsol.Item.LinkClicked += new NavBarLinkEventHandler(navBarItemConfigAntetSubsol_LinkClicked);

                PrelucareDate();
                StabilireTitlu();
                if (furnizor != string.Empty)
                {
                    if (lot != string.Empty)
                    {
                        labelTitle.Text = "Lista Comenzi in perioada :" + mDataStart.ToString("dd.MM.yyyy") + " - " +
                                         mDataStop.ToString("dd.MM.yyyy") + " pentru furnizorul " + furnizor + " lot  "+lot;
                        mListName = "Lista Comenzi in perioada :" + mDataStart.ToString("dd.MM.yyyy") + " - " +
                                    mDataStop.ToString("dd.MM.yyyy") + " pentru furnizorul " + furnizor+ "lot  "+lot ;
                    }
                    else
                    {
                        labelTitle.Text = "Lista Comenzi in perioada :" + mDataStart.ToString("dd.MM.yyyy") + " - " +
                                          mDataStop.ToString("dd.MM.yyyy") + " pentru furnizorul " + furnizor;
                        mListName = "Lista Comenzi in perioada :" + mDataStart.ToString("dd.MM.yyyy") + " - " +
                                    mDataStop.ToString("dd.MM.yyyy") + " pentru furnizorul " + furnizor;
                    }
                }
                else
                {
                    labelTitle.Text = "Lista Comenzi in perioada :" + mDataStart.ToString("dd.MM.yyyy") + " - " + mDataStop.ToString("dd.MM.yyyy");
                    mListName = "Lista Comenzi in perioada :" + mDataStart.ToString("dd.MM.yyyy") + " - " + mDataStop.ToString("dd.MM.yyyy");
                }

                Bind();

            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }

        public override void Bind()
        {
            base.Bind();
            gridControlComenzi.DataSource = mDataSet.tblDate;
            mUtil.SetNumericMask(repositoryItemTextEditSuma,2,true);
            gridViewComenzi.ExpandAllGroups();

        }

        public override void Iesire()
        {
            
                Close();
        }

        public override void Listare()
        {
            GetOptiuniFont();
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            PrintableComponentLink ReportLink = new PrintableComponentLink(new PrintingSystem());
            ReportLink.Component = gridControlComenzi;
            ReportLink.PaperKind = PaperKind.A4;
            ReportLink.Landscape = true;
            ReportLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(ReportLink_CreateMarginalHeaderArea);
            ReportLink.CreateMarginalFooterArea += new CreateAreaEventHandler(ReportLink_CreateMarginalFooterArea);
            ReportLink.CreateReportFooterArea += new CreateAreaEventHandler(ReportLink_CreateReportFooterArea);
            ReportLink.CreateReportHeaderArea += new CreateAreaEventHandler(ReportLink_CreateReportHeaderArea);
            ReportLink.CreateDocument();
            ReportLink.ShowPreview();
            Cursor.Current = currentCursor;
            this.BringToFront();
        }

        //public override void Listare()
        //{
           
        //    AfiseazaSubsolPerPagina = true;       
        //    mCuDataListare = false;
        //    base.Listare();


        //}

        #endregion

    }
}
