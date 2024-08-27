using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using ComenziBase;
using CommonDataSets;
using CommonDataSets.Base;
using CommonDataSets.GUI;
using CommonGUIControllers.Base;
using CommonGUIControllers.GUI;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting;
using GSFramework;
using Utilities;

namespace ComenziGUI
{
    public partial class Comenzi : BaseWindow
    {
        #region Constructor
        public Comenzi()
        {
            InitializeComponent();
        }
        #endregion
        
        #region  Class Fields

        private ComenziDataSet mDataSet;
        private ComenziController mController;
        Utility mUtil = new Utility();
        private int mNrZecimale = 2;
        private NavBarItem navItemModificaReceptie;
        private NavBarItem navItemStergeReceptie;
        private bool mEventCanceled;
        #endregion

        #region Private Events

        private void navItemModificaReceptie_LinkClicked(object sender, NavBarLinkEventArgs e)
        {

           
            DataRow dr = mUtil.GetSelectedRow(gridControlComenzi);
            if (dr != null)
            {
                Context.AddUserContextParameterList("ComenziGUI.Comenzi.CallerHandler", this);
                Context.AddUserContextParameterList("ComenziGUI.Comenzi.ComandaBaseID", dr["ID"]);
                Context.AddUserContextParameterList("ComenziGUI.Comenzi.IsModifica", true);
                using (Context.CreateDialogWindow("ComenziGUI.ActualizareReceptie, ComenziGUI"))
                {
                    Context.CreatedWindow = null;
                }
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Comenzi.CallerHandler");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Comenzi.ComandaBaseID");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Comenzi.IsModifica");
            }
            gridViewComenzi.ExpandAllGroups();
        }

        private void navItemStergeReceptie_LinkClicked(object sender, NavBarLinkEventArgs e)
        {

         
            DataRow dr = mUtil.GetSelectedRow(gridControlComenzi);
            if (dr != null)
            {
                Context.AddUserContextParameterList("ComenziGUI.Comenzi.CallerHandler", this);
                Context.AddUserContextParameterList("ComenziGUI.Comenzi.ComandaBaseID", dr["ID"]);
                Context.AddUserContextParameterList("ComenziGUI.Comenzi.IsModifica", false);
                using (Context.CreateDialogWindow("ComenziGUI.ActualizareReceptie, ComenziGUI"))
                {
                    Context.CreatedWindow = null;
                }
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Comenzi.CallerHandler");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Comenzi.ComandaBaseID");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Comenzi.IsModifica");
            }
            gridViewComenzi.ExpandAllGroups();
        }
        #endregion

        #region Private Methods

        public void RemoveRow(DataRow dr)
        {
            if (dr != null)
            {


                if (mUtil.IsNotObjectEmpty(dr["ID"]))
                {
                    mController.Modifica = true;
                    mController.ComadaBaseID = (Guid) dr["ID"];
                    mController.Load();

                    if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        return;
                    }
                }
                DataRow[] drsBase = mDataSet.tblComandaBase.Select("ID='" + dr["ID"] + "'");
                foreach (DataRow drBase in drsBase)
                {
                    DataRow[] drsDet = mDataSet.tblComandaDet.Select("ComandaBaseID='" + drBase["ID"] + "'");
                    foreach (DataRow drdet in drsDet )
                    {
                        drdet.Delete();
                    }
                    drBase.Delete();
                }
            }


        }
        private void Comenzi_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool bValidate = true;
                DialogResult drChange = DialogResult.Yes;
                if (mySaveData)
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
                    if (HasChanges())
                    {
                        if ((drChange = XtraMessageBox.Show("Doriti sa salvati modificarile?", "Comenzi",
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
                        }
                        else
                        {
                            mEventCanceled = true;
                        }
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception excep)
            {
                Context.HandleException(this, excep);
            }
        }
         private void Save()
        {
            try
            {
                if (!mySaveData)
                    return;

                SaveToDataSet();
                Cursor = Cursors.WaitCursor;
                if (mController.DataSet.HasChanges())
                {
                    mController.Perform();
                    if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                    {
                        Context.HandleException(mController.ServerException.ToString());
                        mySaveData = false;
                    }
                }
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool HasChanges()
        {
            bool bChanges = false;
            bChanges = mController.DataSet.HasChanges();
            mySaveData = true;
            return bChanges;
        }

        private void SaveToDataSet()
        {
        }

        #endregion

        #region  Public Methods

        public override void Initialize()
        {
            try
            {
                base.Initialize(gridControlComenzi);
             
                navBarItemAlege.Visible = false;
                labelBaseWindowHeader.Text = "Comenzi";
                string mUserName = Context.UserName;
                //if (mUserName == "Admin" || mUserName == "admin")
                //{
                    navBarItemSterge.Visible = true;
                    navBarItemModifica.Visible = true;
                    navBarItemSterge.Caption = "Stergere comanda";
                    navBarItemModifica.Caption = "Modificare comanda";

                   // modifica si sterge receptie
                    navItemModificaReceptie = new NavBarItem("Modificare Receptie");
                    navItemModificaReceptie.LinkClicked += new NavBarLinkEventHandler(navItemModificaReceptie_LinkClicked);
                    navItemModificaReceptie.Enabled = true;
                    navBarGroupActualizare.ItemLinks.Add(navItemModificaReceptie);

                    navItemStergeReceptie = new NavBarItem("Stergere receptie");
                    navItemStergeReceptie.LinkClicked += new NavBarLinkEventHandler(navItemStergeReceptie_LinkClicked);
                    navItemStergeReceptie.Enabled = true;
                    navBarGroupActualizare.ItemLinks.Add(navItemStergeReceptie);
                //}
                //else
                //{

                //    navBarItemSterge.Visible = false;
                //    navBarItemModifica.Visible = false;
                //    navBarItemSalvare.Visible = false;
                //}

              
                navBarItemActualizare_Custom1.Visible = true;
                navBarItemActualizare_Custom1.Caption = "Adauga receptie";

                navBarItemActualizare_Custom2.Visible = true;
                navBarItemActualizare_Custom2.Caption = "Persoane NIR";

                navBarItemActualizare_Custom3.Visible = true;
                navBarItemActualizare_Custom3.Caption = "Listare NIR";

                mController =
                    (ComenziController)
                    Context.CreateController("CommonGUIControllers.GUI.ComenziController,CommonGUIControllers");
                mController.LoadDate = false;
                mController.CentruID = ContextUtilityClass.OnlyInstance.CentruID;
                mController.Data = ContextUtilityClass.OnlyInstance.DataLucru;
                mController.Load();

                if (Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
           
                mDataSet = (ComenziDataSet)mController.DataSet;
                mDataSet.AcceptChanges();
                string sNrFormatString = string.Empty, sGeneralFormat = string.Empty;
                mUtil.FormatString(mNrZecimale, true, ref sNrFormatString, ref sGeneralFormat);
                mUtil.SetDateTimeFormatFromConfig(repositoryItemDateEditData);

                GridGroupSummaryItemCollection collection = gridViewComenzi.GroupSummary;
                foreach (GridGroupSummaryItem item in collection)
                {
                    if (item.Index >= 0)
                        item.DisplayFormat = sGeneralFormat;
                }

                GridColumnCollection cols = gridViewComenzi.Columns;
                foreach (GridColumn col in cols)
                {
                    if (col.SummaryItem.SummaryType == DevExpress.Data.SummaryItemType.Sum)
                    {
                        col.SummaryItem.DisplayFormat = sGeneralFormat;
                    }
                }
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
            tblHomeBindingSource.DataSource = mDataSet.tblHome.DefaultView;
            mUtil.SetNumericMask(repositoryItemTextEditSuma, 2, true);
            mUtil.SetDateTimeFormatFromConfig(repositoryItemDateEditData);
            gridViewComenzi.ExpandAllGroups();
        }
        
        public override void Iesire()
        {

            this.Close();
        }
        
        public override void Adauga()
        {
            base.Adauga();
            Context.AddUserContextParameterList("ComenziGUI.Lot.CallerHandler", this);
            Context.AddUserContextParameterList("ComenziGUI.Lot.IsNew", true);
            using (Context.CreateDialogWindow("ComenziGUI.ComenziActualizare, ComenziGUI"))
            {
                Context.CreatedWindow = null;
            }
            Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.CallerHandler");
            Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.IsNew");
        }

        public override void Modifica()
        {
            base.Modifica();
            DataRow dr = mUtil.GetSelectedRow(gridControlComenzi);
            
            if (dr != null)
            {
                DataRow[] drsComenzi = mDataSet.tblHome.Select("ID='" + dr["ID"] + "' AND CantitateReceptionata<>0");
                if (drsComenzi.Length > 0)
                {
                    XtraMessageBox.Show("Nu puteti modifica pentru ca aveti receptii");
                }
                else
                {
                    Context.AddUserContextParameterList("ComenziGUI.Lot.CallerHandler", this);
                    Context.AddUserContextParameterList("ComenziGUI.Lot.IsNew", false);
                    Context.AddUserContextParameterList("ComenziGUI.Lot.ID", dr["ID"]);
                    Context.AddUserContextParameterList("ComenziGUI.Lot.LotBaseID", dr["LotID"]);
                    using (Context.CreateDialogWindow("ComenziGUI.ComenziActualizare, ComenziGUI"))
                    {
                        Context.CreatedWindow = null;
                    }
                    Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.CallerHandler");
                    Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.IsNew");
                    Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.LotBaseID");
                    Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Lot.ID");
                }
                
            }
        }

        public override void Sterge()
        {
            base.Sterge();
            DataRow dr = mUtil.GetSelectedRow(gridControlComenzi);

            if (dr != null)
            {
                DataRow[] drsComenzi = mDataSet.tblHome.Select("ID='" + dr["ID"] + "' AND CantitateReceptionata<>0");
                if (drsComenzi.Length > 0)
                {
                    XtraMessageBox.Show("Nu puteti sterge pentru ca aveti receptii");
                }
                else
                {
                    if (new Utility().DeleteConfirmation())
                    {
                        RemoveRow(dr);
                        mySaveData = true;
                        Save();
                        ReloadOnClose();
                    }

                }
            }
        }
        public void ReloadOnClose()
        {
            mDataSet.Clear();
            mController.LoadDate = false;
            mController.CentruID = ContextUtilityClass.OnlyInstance.CentruID;
            mController.Data = ContextUtilityClass.OnlyInstance.DataLucru;
            mController.Load();
            
            if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
            {
                Context.HandleException(mController.ServerException.ToString());
                return;
            }
            gridViewComenzi.ExpandAllGroups();
        }

        public override void ActualizareItem1()
        {
            base.ActualizareItem1();
            DataRow dr = mUtil.GetSelectedRow(gridControlComenzi);
            if (dr != null)
            {
                Context.AddUserContextParameterList("ComenziGUI.Comenzi.CallerHandler", this);
                Context.AddUserContextParameterList("ComenziGUI.Comenzi.ComandaBaseID", dr["ID"]);
                using (Context.CreateDialogWindow("ComenziGUI.AdaugareReceptie, ComenziGUI"))
                {
                    Context.CreatedWindow = null;
                }
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Comenzi.CallerHandler");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Comenzi.ComandaBaseID");
            }
            gridViewComenzi.ExpandAllGroups();
        }

        public override void ActualizareItem2()
        {
            base.ActualizareItem2();
            using (Context.CreateDialogWindow("ComenziGUI.PersoaneHome, ComenziGUI"))
            {
                Context.CreatedWindow = null;
            }
            gridViewComenzi.ExpandAllGroups();
        }

        public override void ActualizareItem3()
        {
            base.ActualizareItem3();
            DataRow dr = mUtil.GetSelectedRow(gridControlComenzi);
            if (dr != null)
            {
                Context.AddUserContextParameterList("ComenziGUI.Comenzi.CallerHandler", this);
                Context.AddUserContextParameterList("ComenziGUI.Comenzi.ComandaBaseID", dr["ID"]);
                using (Context.CreateDialogWindow("ComenziGUI.NirFiltre, ComenziGUI"))
                {
                    Context.CreatedWindow = null;
                }
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Comenzi.CallerHandler");
                Context.DeleteEntryFromUserContextParameterList("ComenziGUI.Comenzi.ComandaBaseID");
            }
            gridViewComenzi.ExpandAllGroups();

        }

        public override void Salvare()
        {
            base.Salvare();
            mySaveData = true;
            this.Close();

        }

        #endregion

      
    }
}
