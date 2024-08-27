using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using CommonDataSets;
using CommonDataSets.Base;
using CommonGUIControllers.Base;
using DevExpress.XtraEditors;
using GSFramework;
using Utilities;

namespace ComenziListe
{
    public partial class ConfigurareAntetSubsol :Window
    {
        #region Constructor
        public ConfigurareAntetSubsol()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields
        private BaseWindowFiltreController mController;
        private BaseWindowFiltreDataSet mDataSet;
        private BaseWindowFiltreDataSet.tblOptiuniRow mDataRowOptiuni;
        private Utility mUtil = new Utility();
        private bool mIsNew = false;
        private bool mEventCanceled = false;
        private bool mEventNo = false;
        private OptiuniFiltre mOptiuniFiltreHeaderLeft;
        private OptiuniFiltre mOptiuniFiltreHeaderCenter;
        private OptiuniFiltre mOptiuniFiltreHeaderRight;
        private OptiuniFiltre mOptiuniFiltreFooterLeft;
        private OptiuniFiltre mOptiuniFiltreFooterCenter;
        private OptiuniFiltre mOptiuniFiltreFooterRight;
        private FontStyle mHeaderLeftFontStyle = FontStyle.Regular;
        private FontStyle mHeaderCenterFontStyle = FontStyle.Regular;
        private FontStyle mHeaderRightFontStyle = FontStyle.Regular;
        private FontStyle mFooterLeftFontStyle = FontStyle.Regular;
        private FontStyle mFooterCenterFontStyle = FontStyle.Regular;
        private FontStyle mFooterRightFontStyle = FontStyle.Regular;
        private Guid mCentruID = Guid.Empty;
        private bool mAfisareDoarAntretDreapta = false;
        #endregion

        #region Events
        private void simpleButtonFontAntetStanga_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = memoEditAntetStanga.Font;
            fontDialog1.Color = memoEditAntetStanga.ForeColor;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                mDataRowOptiuni.HeaderLeftColorName = fontDialog1.Color.Name;
                mDataRowOptiuni.HeaderLeftFontName = fontDialog1.Font.Name;
                mDataRowOptiuni.HeaderLeftFontSize = fontDialog1.Font.Size;
                mHeaderLeftFontStyle = fontDialog1.Font.Style;

                memoEditAntetStanga.ForeColor = fontDialog1.Color;
                memoEditAntetStanga.Font = fontDialog1.Font;
            }
        }
        private void simpleButtonFontAntetCentru_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = memoEditAntetCentru.Font;
            fontDialog1.Color = memoEditAntetCentru.ForeColor;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                mDataRowOptiuni.HeaderCenterColorName = fontDialog1.Color.Name;
                mDataRowOptiuni.HeaderCenterFontName = fontDialog1.Font.Name;
                mDataRowOptiuni.HeaderCenterFontSize = fontDialog1.Font.Size;
                mHeaderCenterFontStyle = fontDialog1.Font.Style;

                memoEditAntetCentru.ForeColor = fontDialog1.Color;
                memoEditAntetCentru.Font = fontDialog1.Font;
            }
        }
        private void simpleButtonFontAntetDreapta_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = memoEditAntetDreapta.Font;
            fontDialog1.Color = memoEditAntetDreapta.ForeColor;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                mDataRowOptiuni.HeaderRightColorName = fontDialog1.Color.Name;
                mDataRowOptiuni.HeaderRightFontName = fontDialog1.Font.Name;
                mDataRowOptiuni.HeaderRightFontSize = fontDialog1.Font.Size;
                mHeaderRightFontStyle = fontDialog1.Font.Style;

                memoEditAntetDreapta.ForeColor = fontDialog1.Color;
                memoEditAntetDreapta.Font = fontDialog1.Font;
            }
        }
        private void simpleButtonFontSubsolStanga_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = memoEditSubsolStanga.Font;
            fontDialog1.Color = memoEditSubsolStanga.ForeColor;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                mDataRowOptiuni.FooterLeftColorName = fontDialog1.Color.Name;
                mDataRowOptiuni.FooterLeftFontName = fontDialog1.Font.Name;
                mDataRowOptiuni.FooterLeftFontSize = fontDialog1.Font.Size;
                mFooterLeftFontStyle = fontDialog1.Font.Style;

                memoEditSubsolStanga.ForeColor = fontDialog1.Color;
                memoEditSubsolStanga.Font = fontDialog1.Font;
            }
        }
        private void simpleButtonFontSubsolCentru_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = memoEditSubsolCentru.Font;
            fontDialog1.Color = memoEditSubsolCentru.ForeColor;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                mDataRowOptiuni.FooterCenterColorName = fontDialog1.Color.Name;
                mDataRowOptiuni.FooterCenterFontName = fontDialog1.Font.Name;
                mDataRowOptiuni.FooterCenterFontSize = fontDialog1.Font.Size;
                mFooterCenterFontStyle = fontDialog1.Font.Style;

                memoEditSubsolCentru.ForeColor = fontDialog1.Color;
                memoEditSubsolCentru.Font = fontDialog1.Font;
            }
        }
        private void simpleButtonFontSubsolDreapta_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = memoEditSubsolDreapta.Font;
            fontDialog1.Color = memoEditSubsolDreapta.ForeColor;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                mDataRowOptiuni.FooterRightColorName = fontDialog1.Color.Name;
                mDataRowOptiuni.FooterRightFontName = fontDialog1.Font.Name;
                mDataRowOptiuni.FooterRightFontSize = fontDialog1.Font.Size;
                mFooterRightFontStyle = fontDialog1.Font.Style;

                memoEditSubsolDreapta.ForeColor = fontDialog1.Color;
                memoEditSubsolDreapta.Font = fontDialog1.Font;
            }
        }
        private void simpleButtonRenunta_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void simpleButtonSalveaza_Click(object sender, EventArgs e)
        {
            mySaveData = true;
            this.Close();
        }
        private void ConfigurareAntetSubsol_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool bValidate = true;
                mEventCanceled = false;
                mEventNo = false;
                DialogResult drChange = DialogResult.Yes;
                if (mySaveData == true)
                {
                    if (!Validate())
                    {
                        mySaveData = false;
                        mEventCanceled = e.Cancel = true;
                    }
                    else
                    {
                        Save();
                        if (!mySaveData)
                        {
                            mySaveData = false;
                            mEventCanceled = e.Cancel = true;
                        }
                    }
                }
                else
                {
                    if (HasChanges() == true)
                    {
                        if ((drChange = XtraMessageBox.Show("Doriti sa salvati modificarile?", "ECONET",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) == DialogResult.Yes)
                        {
                            if ((bValidate = Validate()))
                            {
                                Save();
                                if (!mySaveData)
                                {
                                    mySaveData = false;
                                    mEventCanceled = e.Cancel = true;
                                }
                            }
                            else
                            {
                                mySaveData = false;
                                mEventCanceled = e.Cancel = true;
                            }
                        }
                        else if (drChange == DialogResult.Cancel)
                        {
                            mySaveData = false;
                            mEventCanceled = e.Cancel = true;
                            mDataSet.RejectChanges();
                        }
                        else
                        {
                            mEventNo = true;
                            mEventCanceled = true;
                        }
                    }
                }
                this.Cursor = Cursors.Default;
            }
            catch (System.Exception excep)
            {
                Context.HandleException(this, excep);
            }
        }
        private void ConfigurareAntetSubsol_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mEventNo)
                mDataRowOptiuni.RejectChanges();
       //    Context.ReleaseSharedController("CommonGUIControllers.BaseClasses.BaseWindowFiltreController, CommonGUIControllers");
        }
        #endregion

        #region Private Methods
        private void SetFont()
        {
            string sFontName;
            float fFontSize;
            string sColorName;
            FontStyle fStyle;
            string sMessage = String.Empty;

            #region Header Left
            sFontName = "Arial";
            fFontSize = 8.25F;
            sColorName = "WindowText";
            fStyle = FontStyle.Regular;
            if (!mIsNew)
            {
                if (!mDataRowOptiuni.IsHeaderLeftFontNameNull())
                {
                    sFontName = mDataRowOptiuni.HeaderLeftFontName;
                }
                else
                {
                    mDataRowOptiuni.HeaderLeftFontName = sFontName;
                }
                if (!mDataRowOptiuni.IsHeaderLeftFontSizeNull())
                {
                    fFontSize = (float)mDataRowOptiuni.HeaderLeftFontSize;
                }
                else
                {
                    mDataRowOptiuni.HeaderLeftFontSize = fFontSize;
                }
                if (!mDataRowOptiuni.IsHeaderLeftColorNameNull())
                {
                    sColorName = mDataRowOptiuni.HeaderLeftColorName;
                }
                else
                {
                    mDataRowOptiuni.HeaderLeftColorName = sColorName;
                }
                if (!mDataRowOptiuni.IsHeaderLeftFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniFiltreHeaderLeft = (OptiuniFiltre)serializer.Deserialize(new StringReader(mDataRowOptiuni.HeaderLeftFontStyle));
                    if (mOptiuniFiltreHeaderLeft != null)
                    {
                        fStyle = mHeaderLeftFontStyle = mOptiuniFiltreHeaderLeft.FontStyle;
                    }
                }
                else
                {
                    mHeaderLeftFontStyle = fStyle;
                }
            }
            else
            {
                mDataRowOptiuni.HeaderLeftFontName = sFontName;
                mDataRowOptiuni.HeaderLeftFontSize = fFontSize;
                mDataRowOptiuni.HeaderLeftColorName = sColorName;
                mHeaderLeftFontStyle = fStyle;
            }
            try
            {
                this.memoEditAntetStanga.Font = new Font(sFontName, fFontSize, fStyle);
                if (this.memoEditAntetStanga.Font.Name != sFontName) throw new Exception("Font not found.");
                this.memoEditAntetStanga.ForeColor = Color.FromName(sColorName);
            }
            catch
            {
                this.memoEditAntetStanga.Font = new Font("Arial", 8.25F, FontStyle.Regular);
                this.memoEditAntetStanga.ForeColor = Color.FromName("WindowText");
                mDataRowOptiuni.HeaderLeftFontName = "Arial";
                mDataRowOptiuni.HeaderLeftFontSize = 8.25F;
                mDataRowOptiuni.HeaderLeftColorName = "WindowText";
                mHeaderLeftFontStyle = FontStyle.Regular;
                if (!sMessage.Equals(String.Empty)) sMessage += Environment.NewLine;
                sMessage += "Fontul pentru Antet Stanga a fost readus la forma initiala.";
            }
            #endregion

            #region Header Center
            sFontName = "Arial";
            fFontSize = 8.25F;
            sColorName = "WindowText";
            fStyle = FontStyle.Regular;
            if (!mIsNew)
            {
                if (!mDataRowOptiuni.IsHeaderCenterFontNameNull())
                {
                    sFontName = mDataRowOptiuni.HeaderCenterFontName;
                }
                else
                {
                    mDataRowOptiuni.HeaderCenterFontName = sFontName;
                }
                if (!mDataRowOptiuni.IsHeaderCenterFontSizeNull())
                {
                    fFontSize = (float)mDataRowOptiuni.HeaderCenterFontSize;
                }
                else
                {
                    mDataRowOptiuni.HeaderCenterFontSize = fFontSize;
                }
                if (!mDataRowOptiuni.IsHeaderCenterColorNameNull())
                {
                    sColorName = mDataRowOptiuni.HeaderCenterColorName;
                }
                else
                {
                    mDataRowOptiuni.HeaderCenterColorName = sColorName;
                }
                if (!mDataRowOptiuni.IsHeaderCenterFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniFiltreHeaderCenter = (OptiuniFiltre)serializer.Deserialize(new StringReader(mDataRowOptiuni.HeaderCenterFontStyle));
                    if (mOptiuniFiltreHeaderCenter != null)
                    {
                        fStyle = mHeaderCenterFontStyle = mOptiuniFiltreHeaderCenter.FontStyle;
                    }
                }
                else
                {
                    mHeaderCenterFontStyle = fStyle;
                }
            }
            else
            {
                mDataRowOptiuni.HeaderCenterFontName = sFontName;
                mDataRowOptiuni.HeaderCenterFontSize = fFontSize;
                mDataRowOptiuni.HeaderCenterColorName = sColorName;
                mHeaderCenterFontStyle = fStyle;
            }
            try
            {
                this.memoEditAntetCentru.Font = new Font(sFontName, fFontSize, fStyle);
                if (this.memoEditAntetCentru.Font.Name != sFontName) throw new Exception("Font not found.");
                this.memoEditAntetCentru.ForeColor = Color.FromName(sColorName);
            }
            catch
            {
                this.memoEditAntetCentru.Font = new Font("Arial", 8.25F, FontStyle.Regular);
                this.memoEditAntetCentru.ForeColor = Color.FromName("WindowText");
                mDataRowOptiuni.HeaderCenterFontName = "Arial";
                mDataRowOptiuni.HeaderCenterFontSize = 8.25F;
                mDataRowOptiuni.HeaderCenterColorName = "WindowText";
                mHeaderCenterFontStyle = FontStyle.Regular;
                if (!sMessage.Equals(String.Empty)) sMessage += Environment.NewLine;
                sMessage += "Fontul pentru Antet Centru a fost readus la forma initiala.";
            }
            #endregion

            #region Header Right
            sFontName = "Arial";
            fFontSize = 8.25F;
            sColorName = "WindowText";
            fStyle = FontStyle.Regular;
            if (!mIsNew)
            {
                if (!mDataRowOptiuni.IsHeaderRightFontNameNull())
                {
                    sFontName = mDataRowOptiuni.HeaderRightFontName;
                }
                else
                {
                    mDataRowOptiuni.HeaderRightFontName = sFontName;
                }
                if (!mDataRowOptiuni.IsHeaderRightFontSizeNull())
                {
                    fFontSize = (float)mDataRowOptiuni.HeaderRightFontSize;
                }
                else
                {
                    mDataRowOptiuni.HeaderRightFontSize = fFontSize;
                }
                if (!mDataRowOptiuni.IsHeaderRightColorNameNull())
                {
                    sColorName = mDataRowOptiuni.HeaderRightColorName;
                }
                else
                {
                    mDataRowOptiuni.HeaderRightColorName = sColorName;
                }
                if (!mDataRowOptiuni.IsHeaderRightFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniFiltreHeaderRight = (OptiuniFiltre)serializer.Deserialize(new StringReader(mDataRowOptiuni.HeaderRightFontStyle));
                    if (mOptiuniFiltreHeaderRight != null)
                    {
                        fStyle = mHeaderRightFontStyle = mOptiuniFiltreHeaderRight.FontStyle;
                    }
                }
                else
                {
                    mHeaderRightFontStyle = fStyle;
                }
            }
            else
            {
                mDataRowOptiuni.HeaderRightFontName = sFontName;
                mDataRowOptiuni.HeaderRightFontSize = fFontSize;
                mDataRowOptiuni.HeaderRightColorName = sColorName;
                mHeaderRightFontStyle = fStyle;
            }
            try
            {
                this.memoEditAntetDreapta.Font = new Font(sFontName, fFontSize, fStyle);
                if (this.memoEditAntetDreapta.Font.Name != sFontName) throw new Exception("Font not found.");
                this.memoEditAntetDreapta.ForeColor = Color.FromName(sColorName);
            }
            catch
            {
                this.memoEditAntetDreapta.Font = new Font("Arial", 8.25F, FontStyle.Regular);
                this.memoEditAntetDreapta.ForeColor = Color.FromName("WindowText");
                mDataRowOptiuni.HeaderRightFontName = "Arial";
                mDataRowOptiuni.HeaderRightFontSize = 8.25F;
                mDataRowOptiuni.HeaderRightColorName = "WindowText";
                mHeaderRightFontStyle = FontStyle.Regular;
                if (!sMessage.Equals(String.Empty)) sMessage += Environment.NewLine;
                sMessage += "Fontul pentru Antet Dreapta a fost readus la forma initiala.";
            }
            #endregion

            #region Footer Left
            sFontName = "Arial";
            fFontSize = 8.25F;
            sColorName = "WindowText";
            fStyle = FontStyle.Regular;
            if (!mIsNew)
            {
                if (!mDataRowOptiuni.IsFooterLeftFontNameNull())
                {
                    sFontName = mDataRowOptiuni.FooterLeftFontName;
                }
                else
                {
                    mDataRowOptiuni.FooterLeftFontName = sFontName;
                }
                if (!mDataRowOptiuni.IsFooterLeftFontSizeNull())
                {
                    fFontSize = (float)mDataRowOptiuni.FooterLeftFontSize;
                }
                else
                {
                    mDataRowOptiuni.FooterLeftFontSize = fFontSize;
                }
                if (!mDataRowOptiuni.IsFooterLeftColorNameNull())
                {
                    sColorName = mDataRowOptiuni.FooterLeftColorName;
                }
                else
                {
                    mDataRowOptiuni.FooterLeftColorName = sColorName;
                }
                if (!mDataRowOptiuni.IsFooterLeftFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniFiltreFooterLeft = (OptiuniFiltre)serializer.Deserialize(new StringReader(mDataRowOptiuni.FooterLeftFontStyle));
                    if (mOptiuniFiltreFooterLeft != null)
                    {
                        fStyle = mFooterLeftFontStyle = mOptiuniFiltreFooterLeft.FontStyle;
                    }
                }
                else
                {
                    mFooterLeftFontStyle = fStyle;
                }
            }
            else
            {
                mDataRowOptiuni.FooterLeftFontName = sFontName;
                mDataRowOptiuni.FooterLeftFontSize = fFontSize;
                mDataRowOptiuni.FooterLeftColorName = sColorName;
                mFooterLeftFontStyle = fStyle;
            }
            try
            {
                this.memoEditSubsolStanga.Font = new Font(sFontName, fFontSize, fStyle);
                if (this.memoEditSubsolStanga.Font.Name != sFontName) throw new Exception("Font not found.");
                this.memoEditSubsolStanga.ForeColor = Color.FromName(sColorName);
            }
            catch
            {
                this.memoEditSubsolStanga.Font = new Font("Arial", 8.25F, FontStyle.Regular);
                this.memoEditSubsolStanga.ForeColor = Color.FromName("WindowText");
                mDataRowOptiuni.FooterLeftFontName = "Arial";
                mDataRowOptiuni.FooterLeftFontSize = 8.25F;
                mDataRowOptiuni.FooterLeftColorName = "WindowText";
                mFooterLeftFontStyle = FontStyle.Regular;
                if (!sMessage.Equals(String.Empty)) sMessage += Environment.NewLine;
                sMessage += "Fontul pentru Subsol Stanga a fost readus la forma initiala.";
            }
            #endregion

            #region Footer Center
            sFontName = "Arial";
            fFontSize = 8.25F;
            sColorName = "WindowText";
            fStyle = FontStyle.Regular;
            if (!mIsNew)
            {
                if (!mDataRowOptiuni.IsFooterCenterFontNameNull())
                {
                    sFontName = mDataRowOptiuni.FooterCenterFontName;
                }
                else
                {
                    mDataRowOptiuni.FooterCenterFontName = sFontName;
                }
                if (!mDataRowOptiuni.IsFooterCenterFontSizeNull())
                {
                    fFontSize = (float)mDataRowOptiuni.FooterCenterFontSize;
                }
                else
                {
                    mDataRowOptiuni.FooterCenterFontSize = fFontSize;
                }
                if (!mDataRowOptiuni.IsFooterCenterColorNameNull())
                {
                    sColorName = mDataRowOptiuni.FooterCenterColorName;
                }
                else
                {
                    mDataRowOptiuni.FooterCenterColorName = sColorName;
                }
                if (!mDataRowOptiuni.IsFooterCenterFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniFiltreFooterCenter = (OptiuniFiltre)serializer.Deserialize(new StringReader(mDataRowOptiuni.FooterCenterFontStyle));
                    if (mOptiuniFiltreFooterCenter != null)
                    {
                        fStyle = mFooterCenterFontStyle = mOptiuniFiltreFooterCenter.FontStyle;
                    }
                }
                else
                {
                    mFooterCenterFontStyle = fStyle;
                }
            }
            else
            {
                mDataRowOptiuni.FooterCenterFontName = sFontName;
                mDataRowOptiuni.FooterCenterFontSize = fFontSize;
                mDataRowOptiuni.FooterCenterColorName = sColorName;
                mFooterCenterFontStyle = fStyle;
            }
            try
            {
                this.memoEditSubsolCentru.Font = new Font(sFontName, fFontSize, fStyle);
                if (this.memoEditSubsolCentru.Font.Name != sFontName) throw new Exception("Font not found.");
                this.memoEditSubsolCentru.ForeColor = Color.FromName(sColorName);
            }
            catch
            {
                this.memoEditSubsolCentru.Font = new Font("Arial", 8.25F, FontStyle.Regular);
                this.memoEditSubsolCentru.ForeColor = Color.FromName("WindowText");
                mDataRowOptiuni.FooterCenterFontName = "Arial";
                mDataRowOptiuni.FooterCenterFontSize = 8.25F;
                mDataRowOptiuni.FooterCenterColorName = "WindowText";
                mFooterCenterFontStyle = FontStyle.Regular;
                if (!sMessage.Equals(String.Empty)) sMessage += Environment.NewLine;
                sMessage += "Fontul pentru Subsol Centru a fost readus la forma initiala.";
            }
            #endregion

            #region Footer Right
            sFontName = "Arial";
            fFontSize = 8.25F;
            sColorName = "WindowText";
            fStyle = FontStyle.Regular;
            if (!mIsNew)
            {
                if (!mDataRowOptiuni.IsFooterRightFontNameNull())
                {
                    sFontName = mDataRowOptiuni.FooterRightFontName;
                }
                else
                {
                    mDataRowOptiuni.FooterRightFontName = sFontName;
                }
                if (!mDataRowOptiuni.IsFooterRightFontSizeNull())
                {
                    fFontSize = (float)mDataRowOptiuni.FooterRightFontSize;
                }
                else
                {
                    mDataRowOptiuni.FooterRightFontSize = fFontSize;
                }
                if (!mDataRowOptiuni.IsFooterRightColorNameNull())
                {
                    sColorName = mDataRowOptiuni.FooterRightColorName;
                }
                else
                {
                    mDataRowOptiuni.FooterRightColorName = sColorName;
                }
                if (!mDataRowOptiuni.IsFooterRightFontStyleNull())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
                    mOptiuniFiltreFooterRight = (OptiuniFiltre)serializer.Deserialize(new StringReader(mDataRowOptiuni.FooterRightFontStyle));
                    if (mOptiuniFiltreFooterRight != null)
                    {
                        fStyle = mFooterRightFontStyle = mOptiuniFiltreFooterRight.FontStyle;
                    }
                }
                else
                {
                    mFooterRightFontStyle = fStyle;
                }
            }
            else
            {
                mDataRowOptiuni.FooterRightFontName = sFontName;
                mDataRowOptiuni.FooterRightFontSize = fFontSize;
                mDataRowOptiuni.FooterRightColorName = sColorName;
                mFooterRightFontStyle = fStyle;
            }
            try
            {
                this.memoEditSubsolDreapta.Font = new Font(sFontName, fFontSize, fStyle);
                if (this.memoEditSubsolDreapta.Font.Name != sFontName) throw new Exception("Font not found.");
                this.memoEditSubsolDreapta.ForeColor = Color.FromName(sColorName);
            }
            catch
            {
                this.memoEditSubsolDreapta.Font = new Font("Arial", 8.25F, FontStyle.Regular);
                this.memoEditSubsolDreapta.ForeColor = Color.FromName("WindowText");
                mDataRowOptiuni.FooterRightFontName = "Arial";
                mDataRowOptiuni.FooterRightFontSize = 8.25F;
                mDataRowOptiuni.FooterRightColorName = "WindowText";
                mFooterRightFontStyle = FontStyle.Regular;
                if (!sMessage.Equals(String.Empty)) sMessage += Environment.NewLine;
                sMessage += "Fontul pentru Subsol Dreapta a fost readus la forma initiala.";
            }
            #endregion

            if (!sMessage.Equals(String.Empty))
            {
                XtraMessageBox.Show(sMessage, "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Save()
        {
            try
            {
                if (!mySaveData)
                    return;

                SaveToDataSet();
                this.Cursor = Cursors.WaitCursor;
                if (mController.DataSet.HasChanges())
                {
                    mController.Perform();
                    if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        mySaveData = false;
                        return;
                    }
                    DialogResult = DialogResult.OK;
                }
                mDataSet.AcceptChanges();
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private bool HasChanges()
        {
            bool bChanges = false;
            BindingContext[mDataSet.tblOptiuni].EndCurrentEdit();
            bChanges = mController.DataSet.HasChanges();
            return bChanges;
        }
        private new bool Validate()
        {
            mySaveData = false;

            return mySaveData = true;
        }
        private void SaveToDataSet()
        {
            BindingContext[mDataSet.tblOptiuni].EndCurrentEdit();
            if (mIsNew)
            {
                AddNewRow();
            }

            #region Header Left
            mOptiuniFiltreHeaderLeft = new OptiuniFiltre();
            mOptiuniFiltreHeaderLeft.FontStyle = mHeaderLeftFontStyle;
            XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
            StringBuilder output = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(output);
            serializer.Serialize(writer, mOptiuniFiltreHeaderLeft);
            mDataRowOptiuni.HeaderLeftFontStyle = output.ToString();
            #endregion

            #region Header Center
            mOptiuniFiltreHeaderCenter = new OptiuniFiltre();
            mOptiuniFiltreHeaderCenter.FontStyle = mHeaderCenterFontStyle;
            //XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
            output = new StringBuilder();
            writer = XmlWriter.Create(output);
            serializer.Serialize(writer, mOptiuniFiltreHeaderCenter);
            mDataRowOptiuni.HeaderCenterFontStyle = output.ToString();
            #endregion

            #region Header Right
            mOptiuniFiltreHeaderRight = new OptiuniFiltre();
            mOptiuniFiltreHeaderRight.FontStyle = mHeaderRightFontStyle;
            //XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
            output = new StringBuilder();
            writer = XmlWriter.Create(output);
            serializer.Serialize(writer, mOptiuniFiltreHeaderRight);
            mDataRowOptiuni.HeaderRightFontStyle = output.ToString();
            #endregion

            #region Footer Left
            mOptiuniFiltreFooterLeft = new OptiuniFiltre();
            mOptiuniFiltreFooterLeft.FontStyle = mFooterLeftFontStyle;
            //XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
            output = new StringBuilder();
            writer = XmlWriter.Create(output);
            serializer.Serialize(writer, mOptiuniFiltreFooterLeft);
            mDataRowOptiuni.FooterLeftFontStyle = output.ToString();
            #endregion

            #region Footer Center
            mOptiuniFiltreFooterCenter = new OptiuniFiltre();
            mOptiuniFiltreFooterCenter.FontStyle = mFooterCenterFontStyle;
            //XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
            output = new StringBuilder();
            writer = XmlWriter.Create(output);
            serializer.Serialize(writer, mOptiuniFiltreFooterCenter);
            mDataRowOptiuni.FooterCenterFontStyle = output.ToString();
            #endregion

            #region Footer Right
            mOptiuniFiltreFooterRight = new OptiuniFiltre();
            mOptiuniFiltreFooterRight.FontStyle = mFooterRightFontStyle;
            //XmlSerializer serializer = new XmlSerializer(typeof(OptiuniFiltre));
            output = new StringBuilder();
            writer = XmlWriter.Create(output);
            serializer.Serialize(writer, mOptiuniFiltreFooterRight);
            mDataRowOptiuni.FooterRightFontStyle = output.ToString();
            #endregion

            TextWriter stringWriter = new StringWriter();
            mDataSet.tblOptiuni.WriteXml(stringWriter);

            DataRow baseListeRow = mDataSet.tblListeBase.Rows[0];
            DataRow[] detListeRow;
            if (mCentruID != Guid.Empty)
            {
                detListeRow = mDataSet.tblListeDet.Select("ListeBaseID='" + baseListeRow["ID"] + "' AND CentruID='" + mCentruID + "'" +
                (Convert.ToBoolean(baseListeRow["IsUserSpecific"]) ? " AND UserName='" + Context.UserName + "'" : ""));
            }
            else
            {
                detListeRow = mDataSet.tblListeDet.Select("ListeBaseID='" + baseListeRow["ID"] + "'" +
               (Convert.ToBoolean(baseListeRow["IsUserSpecific"]) ? " AND UserName='" + Context.UserName + "'" : ""));
            }
            if (detListeRow.Length == 0)
            {
                BaseWindowFiltreDataSet.tblListeDetRow drNew = mDataSet.tblListeDet.NewtblListeDetRow();
                drNew.ID = Guid.NewGuid();
                drNew.ListeBaseID = (Guid)baseListeRow["ID"];
                if (mCentruID != Guid.Empty)
                    drNew.CentruID = mCentruID;
                drNew.Optiuni = stringWriter.ToString();
                if ((bool)baseListeRow["IsUserSpecific"])
                    drNew.Optiuni = Context.UserName;
                mDataSet.tblListeDet.AddtblListeDetRow(drNew);
            }
            else
            {
                detListeRow[0]["Optiuni"] = stringWriter.ToString();
            }
            mySaveData = true;
        }
        private void AddNewRow()
        {
            mDataSet.tblOptiuni.AddtblOptiuniRow(mDataRowOptiuni);
        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                base.Initialize();
                mEventCanceled = mEventNo;
                string sParam = this.GetParameter("pCentruID");
                if (!string.IsNullOrEmpty(sParam))
                    mCentruID = new Guid(sParam);
                object objParam = Context.GetParameterValueUserContextParameterList("EconetListe.ConfigurareAntetSubsol.DoarAntetDreapta");
                if (mUtil.IsNotObjectEmpty(objParam))
                    mAfisareDoarAntretDreapta = (bool)objParam;
              
                mController = (BaseWindowFiltreController)Context.GetSharedController("CommonGUIControllers.Base.BaseWindowFiltreController, CommonGUIControllers");
                mDataSet = (BaseWindowFiltreDataSet)mController.DataSet;
                if (mDataSet.tblOptiuni.Rows.Count > 0)
                {
                    mDataRowOptiuni = (BaseWindowFiltreDataSet.tblOptiuniRow)mDataSet.tblOptiuni.Rows[0];
                }
                else
                {
                    mDataRowOptiuni = mDataSet.tblOptiuni.NewtblOptiuniRow();
                    mIsNew = true;
                }
                mDataSet.AcceptChanges();
                this.Bind();
                SetFont();
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
        }
        public override void Bind()
        {
            base.Bind();
            this.memoEditAntetStanga.DataBindings.Add("Text", mDataRowOptiuni, "HeaderLeftText", true, DataSourceUpdateMode.OnValidation, string.Empty);
            this.memoEditAntetCentru.DataBindings.Add("Text", mDataRowOptiuni, "HeaderCenterText", true, DataSourceUpdateMode.OnValidation, string.Empty);
            this.memoEditAntetDreapta.DataBindings.Add("Text", mDataRowOptiuni, "HeaderRightText", true, DataSourceUpdateMode.OnValidation, string.Empty);
            this.memoEditSubsolStanga.DataBindings.Add("Text", mDataRowOptiuni, "FooterLeftText", true, DataSourceUpdateMode.OnValidation, string.Empty);
            this.memoEditSubsolCentru.DataBindings.Add("Text", mDataRowOptiuni, "FooterCenterText", true, DataSourceUpdateMode.OnValidation, string.Empty);
            this.memoEditSubsolDreapta.DataBindings.Add("Text", mDataRowOptiuni, "FooterRightText", true, DataSourceUpdateMode.OnValidation, string.Empty);

         //stanga
            memoEditAntetStanga.Visible = simpleButtonFontAntetStanga.Visible = label1.Visible = !mAfisareDoarAntretDreapta;
            memoEditAntetCentru.Visible = simpleButtonFontAntetCentru.Visible = label2.Visible = !mAfisareDoarAntretDreapta;
            groupBox2.Visible = !mAfisareDoarAntretDreapta;
            if (mAfisareDoarAntretDreapta)
            {
                label3.Location = new Point(5, 16);
                memoEditAntetDreapta.Location = new Point(5, 32);
                memoEditAntetDreapta.Size = new Size(687, 81);
                simpleButtonFontAntetDreapta.Location = new Point(5, 115);
            }
        }
        #endregion
    
    }
}