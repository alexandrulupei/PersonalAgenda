using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComenziBase;
using CommonDataSets.Base;
using CommonGUIControllers.Base;
using DevExpress.XtraEditors;
using GSFramework;
using Utilities;

namespace ComenziGUI
{
    public partial class UsersRolesHome : BaseWindow
    {

        #region Constructor
        public UsersRolesHome()
        {
            InitializeComponent();
        }
        #endregion

        #region Class Fields
        private SecurityController mController;
        private SecurityDataSet mDataSet;
        private Utility mUtility = new Utility();
        private Guid mAplicatiiID = ContextUtilityClass.OnlyInstance.AplicatiiID;
        private Guid mRolesIDDefault = Guid.Empty;
        private bool mEventCanceled = false;
        private bool mEventNo = false;
        private SecurityDataClass mSecurityDataClass = SecurityDataClass.OnlyInstance;
        DateTime mNow = DateTime.Now;


        #endregion

        #region Events

    
        #endregion

        #region Private Methods
        #region Private Methods
        private void LoadInstitutie()
        {

            foreach (DataRow dr in mDataSet.tblDeschidereDet.Rows)
            {
                //dr["ServerName"] = "10.9.0.1\\EcoFocsani";
                DataRow drTipDeschidere = mDataSet.tbxTipDataBase.FindByID((Guid)dr["TipDataBaseID"]);
                if (!drTipDeschidere["Abbreviation"].ToString().Equals("01"))
                    continue;
                mController.LoadInstitutie = true;
                mController.DeschidereBaseID = (Guid)dr["DeschidereBaseID"];
                //this.Context.SetCurrentConnection(mUtility.GetConnectionString(dr));
                this.Context.SetCurrentConnection(mSecurityDataClass.GetConnectionString(dr, 100));
                mController.Load();
                if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
            }
        }
        private void FillUserRightsTables()
        {
            // pentru a clona coloanele tabelului, datele sunt sterse ulterior
            DataTable dtUserRightsXmlClone = mDataSet.tblUserRightsXml.Clone();
            DataTable dtUserRightsSpecificXmlClone = mDataSet.tblUserRightsSpecificXml.Clone();
            foreach (DataRow dr in mDataSet.tblUserRights.Rows)
            {   
                //
           
                {
                    dtUserRightsXmlClone.Clear();
                    TextReader reader = new StringReader(dr["UserRights"].ToString());
                    dtUserRightsXmlClone.ReadXml(reader);
                    mDataSet.tblUserRightsXml.Merge(dtUserRightsXmlClone);
                }
                if (!dr.IsNull("UserRightsSpecific"))
                {
                    dtUserRightsSpecificXmlClone.Clear();
                    TextReader reader = new StringReader(dr["UserRightsSpecific"].ToString());
                    dtUserRightsSpecificXmlClone.ReadXml(reader);
                    mDataSet.tblUserRightsSpecificXml.Merge(dtUserRightsSpecificXmlClone);
                }
            }

            #region Fill tblUserRightsUsr
            foreach (DataRow dr in mDataSet.tblUserRightsXml.Rows)
            {
                DataRow drNew = mDataSet.tblUserRightsUsr.NewRow();
                drNew["ID"] = dr["ID"];
                drNew["UserRightsID"] = dr["UserRightsID"];
                DataRow drUR = dr.GetParentRow("tblUserRights_tblUserRightsXml");
                if (drUR != null)
                {
                    drNew["UsersID"] = drUR["UsersID"];
                    drNew["AplicatiiID"] = drUR["AplicatiiID"];
                }
                drNew["DeschidereBaseID"] = dr["DeschidereBaseID"];
                drNew["ModulID"] = dr["ModulID"];
                drNew["CentruID"] = dr["CentruID"];
                drNew["RolesID"] = dr["RolesID"];
                mDataSet.tblUserRightsUsr.Rows.Add(drNew);
            }

            foreach (DataRow dr in mDataSet.tblUsers.Rows)
            {
                Guid UserID = (Guid)dr["ID"];
                //daca este admin sau user inactiv bucla trece la urmatorul dr
                if (dr["UserName"].ToString().Equals("Admin", StringComparison.InvariantCultureIgnoreCase)
                    || !(Convert.ToBoolean(dr["IsActive"])))
                    continue;

                // Selectarea deschiderilor asociate utilizatorului curent:
                foreach (DataRow drDesch in mDataSet.lnkUsersDeschidere.Select("UsersID = '" + dr["ID"] + "'"))
                {
                    Guid DeschidereID = (Guid)drDesch["DeschidereID"];

                    //if (DeschidereID.Equals(Guid.Empty)) continue;
                    //Verificarea drepturilor de utilizator pentru o anumită deschidere
                    DataRow[] rows = mDataSet.tblUserRightsUsr.Select("UsersID = '" + UserID + "' and DeschidereBaseID = '" + DeschidereID + "'");
                    if (rows.Length > 0)
                    {
                        ;
                        //cauta de institutii noi in fiecare modul
                        foreach (DataRow drModul in mDataSet.tblModul.Rows)
                        {
                            if (drModul["CodIntern"].ToString() == "100" || drModul["CodIntern"].ToString() == "0")
                            {
                                //DataRow drNew = mDataSet.tblUserRightsUsr.NewRow();
                                //drNew["ID"] = Guid.NewGuid();
                                //drNew["UsersID"] = dr["ID"];
                                //drNew["FullName"] = dr["FullName"];
                                //drNew["AplicatiiID"] = mAplicatiiID;
                                //drNew["ModulID"] = drModul["ID"];
                                //drNew["CodModul"] = drModul["CodIntern"];
                                //drNew["DeschidereBaseID"] = DeschidereID;
                                //drNew["NumeDeschidere"] = "deschiderea noua";//drDesch["NumeDeschidere"];
                                //drNew["RolesID"] = mRolesIDDefault;
                                //mDataSet.tblUserRightsUsr.Rows.Add(drNew);
                                ;
                            }
                            else
                            {
                                foreach (DataRow drInstit in mDataSet.tblCentru.Select("DeschidereBaseID = '" + DeschidereID + "' and ModulID = '" + (Guid)drModul["ID"] + "'"))
                                {
                                    Guid InstitutieID = (Guid)drInstit["ID"];
                                    DataRow[] rowsInst
                                        = mDataSet.tblUserRightsUsr.Select("UsersID = '" + UserID +
                                                        "' and CentruID = '" + InstitutieID + "'");

                                    Guid UserRightsSpecificID = Guid.Empty;
                                    if (rowsInst.Length == 0)
                                    {
                                        //mirela new user
                                        //institutie noua (user nou ?)
                                        DataRow drNew = mDataSet.tblUserRightsUsr.NewRow();
                                        drNew["ID"] = Guid.NewGuid();
                                        drNew["UsersID"] = dr["ID"];
                                        drNew["FullName"] = dr["FullName"];
                                        drNew["AplicatiiID"] = mAplicatiiID;
                                        drNew["ModulID"] = drModul["ID"];
                                        drNew["CodModul"] = drModul["CodIntern"];
                                        drNew["DeschidereBaseID"] = DeschidereID;
                                        drNew["NumeDeschidere"] = "deschiderea noua";//drDesch["NumeDeschidere"];
                                        drNew["CentruID"] = InstitutieID;
                                        drNew["RolesID"] = mRolesIDDefault;
                                        mDataSet.tblUserRightsUsr.Rows.Add(drNew);
                                     
                                    }
                                    //-----------------------------------------------------------------------
                                    else if (rowsInst.Length == 1)//>=0?
                                    {
                                        UserRightsSpecificID = (Guid)rowsInst[0]["ID"];
        
                                    }
                                    else
                                    {
                                        ;//naspa
                                    }
                                    //-----------------------------------------------------------------------

                                }
                            }
                        }

                        //--

                    }
                    else
                    {
                        //nu am gasit deschiderea de loc => este noua
                        //adaug toate modulele si toate institutiile 
                        foreach (DataRow drModul in mDataSet.tblModul.Rows)
                        {
                            if (drModul["CodIntern"].ToString() == "100" || drModul["CodIntern"].ToString() == "0")
                            {
                                DataRow drNew = mDataSet.tblUserRightsUsr.NewRow();
                                drNew["ID"] = Guid.NewGuid();
                                drNew["UsersID"] = dr["ID"];
                                drNew["FullName"] = dr["FullName"];
                                drNew["AplicatiiID"] = mAplicatiiID;
                                drNew["ModulID"] = drModul["ID"];
                                drNew["CodModul"] = drModul["CodIntern"];
                                drNew["DeschidereBaseID"] = DeschidereID;
                                drNew["NumeDeschidere"] = "deschiderea noua";//drDesch["NumeDeschidere"];
                                drNew["RolesID"] = mRolesIDDefault;
                                mDataSet.tblUserRightsUsr.Rows.Add(drNew);
                            }
                            else
                            {
                                foreach (DataRow drInstit in mDataSet.tblCentru.Select("ModulID='" + drModul["ID"].ToString()
                                                + "' and DeschidereBaseID='" + DeschidereID + "'"))
                                {
                                    DataRow drNew = mDataSet.tblUserRightsUsr.NewRow();
                                    drNew["ID"] = Guid.NewGuid();
                                    drNew["UsersID"] = dr["ID"];
                                    drNew["FullName"] = dr["FullName"];
                                    drNew["AplicatiiID"] = mAplicatiiID;
                                    drNew["ModulID"] = drModul["ID"];
                                    drNew["CodModul"] = drModul["CodIntern"];
                                    drNew["DeschidereBaseID"] = DeschidereID;
                                    drNew["NumeDeschidere"] = "deschiderea noua";//drDesch["NumeDeschidere"];
                                    drNew["CentruID"] = drInstit["ID"];
                                    drNew["RolesID"] = mRolesIDDefault;
                                    mDataSet.tblUserRightsUsr.Rows.Add(drNew);
                                  
                                }
                            }
                        }
                    }

                }
            }


           
            #endregion

            #region Fill Names

            try
            {
                foreach (DataRow dr in mDataSet.tblUserRightsUsr.Select("UsersID IS NOT NULL"))
                {
                    try
                    {
                    DataRow drUsers = mDataSet.tblUsers.FindByID((Guid) dr["UsersID"]);

                        if (drUsers != null)
                        {
                            dr["FullName"] = drUsers["FullName"];
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    try
                    {
                    DataRow drModul = mDataSet.tblModul.FindByID((Guid) dr["ModulID"]);
                  

                        if (drModul != null)
                        {
                            dr["CodModul"] = drModul["CodIntern"];
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    try
                    {
                    DataRow drDeschidere = mDataSet.tblDeschidereBase.FindByID((Guid) dr["DeschidereBaseID"]);
                  

                    if (drDeschidere != null)
                    {
                        dr["NumeDeschidere"] = drDeschidere["NumeDeschidere"];
                    }
                    }
                    catch (Exception e)
                    {
                        
                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        
            #endregion

            #region Sync Deschidere
            mDataSet.tblUserRightsUsr.AcceptChanges();


            foreach (DataRow dr in mDataSet.tblUserRightsUsr.Select("UsersID IS NOT NULL"))
            {
                //era odata un bug si s-au salvat cu guid empty
                if (dr["DeschidereBaseID"].Equals(Guid.Empty))
                {
                    dr.Delete();
                    continue;
                }
                //--
                if (dr.RowState == DataRowState.Deleted) continue;
                //DataRow drDeschidere = mDataSet.tblDeschidereBase.FindByID((Guid)dr["DeschidereBaseID"]);
                DataRow drDeschidere = null;
                DataRow[] rows = mDataSet.lnkUsersDeschidere.Select("DeschidereID = '" + (Guid)dr["DeschidereBaseID"] + "' and UsersID = '" + (Guid)dr["UsersID"] + "'");
                if (rows.Length > 0)
                    drDeschidere = rows[0];
                else
                {
                    ;
                }
                //if (drDeschidere == null)
                //{
                //    DataRow[] drsUserRightsSpecificXml = mDataSet.tblUserRightsSpecificXml.Select("UserRightsXmlID='" + dr["ID"].ToString() + "'");
                //    foreach (DataRow drUserRightsSpecificXml in drsUserRightsSpecificXml)
                //    {
                //        drUserRightsSpecificXml.Delete();
                //    }
                //    dr.Delete();
                //}
            }
            #endregion

            #region Sync Institutie
            //mDataSet.tblUserRightsUsr.AcceptChanges();
            foreach (DataRow dr in mDataSet.tblUserRightsUsr.Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;
                if (dr.IsNull("CentruID")) continue;
             
            }

            #endregion
            
         
        }
        private void SetRoleDefault()
        {
            DataRow[] drs = mDataSet.tblRoles.Select("CodIntern = 01");
            if (drs.Length > 0)
                mRolesIDDefault = (Guid)drs[0]["ID"];
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
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.Context.SetCurrentConnection(ContextUtilityClass.OnlyInstance.DataBaseCurrentConnectionString);
            }
        }
        private bool HasChanges()
        {
            bool bChanges = false;
        
            this.tblUserRightsUsrBindingSource.EndEdit();
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
            DataTable dtUserRightsXmlClone = mDataSet.tblUserRightsXml.Clone();
            DataTable dtUserRightsSpecificXmlClone = mDataSet.tblUserRightsSpecificXml.Clone();

           
            this.tblUserRightsUsrBindingSource.EndEdit();


            foreach (DataRow dr in mDataSet.tblUsers.Rows)
            {
                if (dr["UserName"].ToString().Equals("Admin", StringComparison.InvariantCultureIgnoreCase)
                    || !(Convert.ToBoolean(dr["IsActive"])))
                    continue;

                DataRow[] drsUserRights = mDataSet.tblUserRights.Select("UsersID='" + dr["ID"].ToString() +
                            "' and AplicatiiID='" + mAplicatiiID.ToString() + "'");
                DataRow drUserRights;
                if (drsUserRights.Length == 0)
                {
                    drUserRights = mDataSet.tblUserRights.NewRow();
                    drUserRights["ID"] = Guid.NewGuid();
                    drUserRights["UsersID"] = dr["ID"];
                    drUserRights["AplicatiiID"] = mAplicatiiID.ToString();
                    mDataSet.tblUserRights.Rows.Add(drUserRights);
                }
                else
                    drUserRights = drsUserRights[0];

                DataRow[] drsUserRightsUsr = mDataSet.tblUserRightsUsr.Select("UsersID='" + dr["ID"].ToString()
                                        + "' and AplicatiiID='" + mAplicatiiID.ToString() + "'");
                foreach (DataRow drUserRightsUsr in drsUserRightsUsr)
                {
                    DataRow drUserRightsXml = dtUserRightsXmlClone.NewRow();
                    drUserRightsXml["ID"] = drUserRightsUsr["ID"];
                    drUserRightsXml["UserRightsID"] = drUserRights["ID"];
                    drUserRightsXml["DeschidereBaseID"] = drUserRightsUsr["DeschidereBaseID"];
                    drUserRightsXml["ModulID"] = drUserRightsUsr["ModulID"];
                    drUserRightsXml["CentruID"] = drUserRightsUsr["CentruID"];
                    drUserRightsXml["RolesID"] = drUserRightsUsr["RolesID"];
                    dtUserRightsXmlClone.Rows.Add(drUserRightsXml);

                    DataRow[] drsUserRightsSpecificXml = mDataSet.tblUserRightsSpecificXml.Select("UserRightsXmlID ='" + drUserRightsUsr["ID"].ToString() + "'");
                    foreach (DataRow drUserRightsSpecificXml in drsUserRightsSpecificXml)
                    {
                        dtUserRightsSpecificXmlClone.ImportRow(drUserRightsSpecificXml);
                    }
                }
                //UserRightsXml
                TextWriter stringWriterUserRightsXml = new StringWriter();
                dtUserRightsXmlClone.WriteXml(stringWriterUserRightsXml);
                drUserRights["UserRights"] = stringWriterUserRightsXml;

                //UserRightsSpecificXml
                TextWriter stringWriterUserRightsSpecificXml = new StringWriter();
                dtUserRightsSpecificXmlClone.WriteXml(stringWriterUserRightsSpecificXml);
                drUserRights["UserRightsSpecific"] = stringWriterUserRightsSpecificXml;

                dtUserRightsSpecificXmlClone.Clear();
                dtUserRightsXmlClone.Clear();
            }



            mySaveData = true;
        }
        #endregion

        #endregion

        #region Public Methods
        public override void Initialize()
        {
            try
            {
                mNow = DateTime.Now;
                mEventCanceled = mEventNo;
                base.Initialize(this.gridControl1);
               mController = (SecurityController)Context.GetSharedController("CommonGUIControllers.Base.SecurityController, CommonGUIControllers");
                mController.AplicatiiID = ContextUtilityClass.OnlyInstance.AplicatiiID;
                mController.LoadInstitutie = false;
                mController.Load();
                if (System.Convert.ToInt16(mController.ResultCode.ToString()) != 0)
                {
                    Context.HandleException(mController.ServerException.ToString());
                    return;
                }
                // cand se incarca dataSetu ul tblUserRightsUsr este gol
                mDataSet = (SecurityDataSet)mController.DataSet;
                //XtraMessageBox.Show("Load() " + (DateTime.Now - mNow).Milliseconds.ToString());
                mNow = DateTime.Now;
                LoadInstitutie();
                //XtraMessageBox.Show("LoadInstitutie() " + (DateTime.Now - mNow).Milliseconds.ToString());
                SetRoleDefault();
                mNow = DateTime.Now;
                
                FillUserRightsTables();
                //XtraMessageBox.Show("FillUserRightsTables() " + (DateTime.Now - mNow).Milliseconds.ToString());

                this.Bind();
                mDataSet.AcceptChanges();

                foreach (DataRow drDesch in mDataSet.lnkUsersDeschidere.Rows)
                {
                    if (drDesch.RowState == DataRowState.Deleted) continue;
                    Guid DeschidereID = (Guid)drDesch["DeschidereID"];
                    Guid UsersID = (Guid)drDesch["UsersID"];

                    DataRow r = mDataSet.tblDeschidereBase.FindByID(DeschidereID);
                    if (r == null)
                    {
                        drDesch.Delete();
                        continue;
                    }
                    r = mDataSet.tblUsers.FindByID(UsersID);
                    if (r == null)
                    {
                        drDesch.Delete();
                        continue;
                    }
                }


                navBarGroupActualizare.Visible = false;
                //navBarItemAlege.Visible = false;
                navBarItemAlege.Caption = "Actualizare Grup Valori (Alt + G)";
                this.gridView1.ExpandAllGroups();
            }
            catch (Exception e)
            {
                Context.HandleException(this, e);
            }
            finally
            {
                this.Context.SetCurrentConnection(ContextUtilityClass.OnlyInstance.DataBaseCurrentConnectionString);
            }
        }
        public override void Bind()
        {
            base.Bind();
            this.tblDeschidereBaseBindingSource.DataSource = mDataSet.tblDeschidereBase;
            this.tblCentruBindingSource.DataSource = mDataSet.tblCentru;
            this.tblModulBindingSource.DataSource = mDataSet.tblModul;
            this.tblRolesBindingSource.DataSource = mDataSet.tblRoles;
            this.tblUsersBindingSource.DataSource = mDataSet.tblUsers;

            this.tblUserRightsUsrBindingSource.DataSource = mDataSet.tblUserRightsUsr;
            this.tblUserRightsUsrBindingSource.Sort = "FullName, NumeDeschidere, CodModul";
           

            DataView vv = new DataView(mDataSet.tblUserRightsSpecificXml);
            vv.RowFilter = "";

           
        }
        public override void Salvare()
        {
            mySaveData = true;
            this.Close();
        }
        public override void Iesire()
        {
            this.Close();
        }
        public override void Alege()
        {
            Context.AddUserContextParameterList("EconetAdmin.Users.UserRolesActualizareGrupValori.tblRolesBindingSource", tblRolesBindingSource);
            using (UserRolesActualizareGrupValori wnd = (UserRolesActualizareGrupValori)this.Context.CreateDialogWindow("ComenziGUI.UserRolesActualizareGrupValori, ComenziGUI"))
            {
                if (wnd.DialogResult == DialogResult.OK)
                {
                    Guid roleID = wnd.RoleID;
                    gridControl1.BeginUpdate();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        DataRow dr = gridView1.GetDataRow(gridView1.GetVisibleRowHandle(i));
                        if (dr != null)
                            dr["RolesID"] = roleID;
                    }
                    gridControl1.EndUpdate();
                }
                Context.CreatedWindow = null;
            }
            Context.DeleteEntryFromUserContextParameterList("EconetAdmin.Users.UserRolesActualizareGrupValori.tblRolesBindingSource");
        }
        #endregion

        private void UsersRolesHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Context.ReleaseSharedController("CommonGUIControllers.Admin.SecurityController, CommonGUIControllers");
            mDataSet.tblUserRightsUsr.Clear();
        }


        private void UsersRolesHome_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
