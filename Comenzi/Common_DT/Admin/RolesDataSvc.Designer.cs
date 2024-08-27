namespace Common_DT.Admin
{
    partial class RolesDataSvc
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolesDataSvc));
            this.sqlDataAdapter_tblDeschidereBase = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlDataAdapter_GetNavigationByAppID = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetRolesDeschidereBase = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblAplicatii = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_lnkRolesNavigation = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_lnkRolesDeschidereBase = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblRoles = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetModul = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetDeschideriActive = new System.Data.SqlClient.SqlDataAdapter();
            // 
            // sqlDataAdapter_tblDeschidereBase
            // 
            this.sqlDataAdapter_tblDeschidereBase.SelectCommand = this.sqlSelectCommand5;
            this.sqlDataAdapter_tblDeschidereBase.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblDeschidereBase", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("AplicatiiID", "AplicatiiID"),
                        new System.Data.Common.DataColumnMapping("NumeDeschidere", "NumeDeschidere"),
                        new System.Data.Common.DataColumnMapping("DataInitializare", "DataInitializare"),
                        new System.Data.Common.DataColumnMapping("DataDeschisa", "DataDeschisa"),
                        new System.Data.Common.DataColumnMapping("DataInchisa", "DataInchisa"),
                        new System.Data.Common.DataColumnMapping("IsBugetar", "IsBugetar")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = resources.GetString("sqlSelectCommand5.CommandText");
            this.sqlSelectCommand5.Connection = this.sqlConnection1;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID")});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=GS0010\\SQL2008R2;Initial Catalog=GS_Comenzi;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlDataAdapter_GetNavigationByAppID
            // 
            this.sqlDataAdapter_GetNavigationByAppID.SelectCommand = this.sqlSelectCommand7;
            this.sqlDataAdapter_GetNavigationByAppID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblNavigation", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("NAME", "NAME"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("ParentGroupID", "ParentGroupID"),
                        new System.Data.Common.DataColumnMapping("ModulID", "ModulID"),
                        new System.Data.Common.DataColumnMapping("ModulOrder", "ModulOrder"),
                        new System.Data.Common.DataColumnMapping("ModulName", "ModulName")})});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = resources.GetString("sqlSelectCommand7.CommandText");
            this.sqlSelectCommand7.Connection = this.sqlConnection1;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID")});
            // 
            // sqlDataAdapter_GetRolesDeschidereBase
            // 
            this.sqlDataAdapter_GetRolesDeschidereBase.SelectCommand = this.sqlSelectCommand3;
            this.sqlDataAdapter_GetRolesDeschidereBase.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "lnkRolesDeschidereBase", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("RolesID", "RolesID"),
                        new System.Data.Common.DataColumnMapping("DeschidereBaseID", "DeschidereBaseID"),
                        new System.Data.Common.DataColumnMapping("RolDescription", "RolDescription")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = resources.GetString("sqlSelectCommand3.CommandText");
            this.sqlSelectCommand3.Connection = this.sqlConnection1;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID")});
            // 
            // sqlDataAdapter_tblAplicatii
            // 
            this.sqlDataAdapter_tblAplicatii.DeleteCommand = this.sqlDeleteCommand5;
            this.sqlDataAdapter_tblAplicatii.InsertCommand = this.sqlInsertCommand5;
            this.sqlDataAdapter_tblAplicatii.SelectCommand = this.sqlSelectCommand6;
            this.sqlDataAdapter_tblAplicatii.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblAplicatii", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("NumeAplicatie", "NumeAplicatie"),
                        new System.Data.Common.DataColumnMapping("Descriere", "Descriere"),
                        new System.Data.Common.DataColumnMapping("App", "App"),
                        new System.Data.Common.DataColumnMapping("IsActive", "IsActive"),
                        new System.Data.Common.DataColumnMapping("IsInstalled", "IsInstalled")})});
            this.sqlDataAdapter_tblAplicatii.UpdateCommand = this.sqlUpdateCommand5;
            // 
            // sqlDeleteCommand5
            // 
            this.sqlDeleteCommand5.CommandText = resources.GetString("sqlDeleteCommand5.CommandText");
            this.sqlDeleteCommand5.Connection = this.sqlConnection1;
            this.sqlDeleteCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NumeAplicatie", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumeAplicatie", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Descriere", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Descriere", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Descriere", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Descriere", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_App", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "App", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsInstalled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsInstalled", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand5
            // 
            this.sqlInsertCommand5.CommandText = resources.GetString("sqlInsertCommand5.CommandText");
            this.sqlInsertCommand5.Connection = this.sqlConnection1;
            this.sqlInsertCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@NumeAplicatie", System.Data.SqlDbType.NVarChar, 0, "NumeAplicatie"),
            new System.Data.SqlClient.SqlParameter("@Descriere", System.Data.SqlDbType.NVarChar, 0, "Descriere"),
            new System.Data.SqlClient.SqlParameter("@App", System.Data.SqlDbType.NVarChar, 0, "App"),
            new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 0, "IsActive"),
            new System.Data.SqlClient.SqlParameter("@IsInstalled", System.Data.SqlDbType.Bit, 0, "IsInstalled")});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "SELECT        ID, NumeAplicatie, Descriere, App, IsActive, IsInstalled\r\nFROM     " +
    "       tblAplicatii\r\nWHERE        (ID = @pAplicatiiID)";
            this.sqlSelectCommand6.Connection = this.sqlConnection1;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID")});
            // 
            // sqlUpdateCommand5
            // 
            this.sqlUpdateCommand5.CommandText = resources.GetString("sqlUpdateCommand5.CommandText");
            this.sqlUpdateCommand5.Connection = this.sqlConnection1;
            this.sqlUpdateCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@NumeAplicatie", System.Data.SqlDbType.NVarChar, 0, "NumeAplicatie"),
            new System.Data.SqlClient.SqlParameter("@Descriere", System.Data.SqlDbType.NVarChar, 0, "Descriere"),
            new System.Data.SqlClient.SqlParameter("@App", System.Data.SqlDbType.NVarChar, 0, "App"),
            new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 0, "IsActive"),
            new System.Data.SqlClient.SqlParameter("@IsInstalled", System.Data.SqlDbType.Bit, 0, "IsInstalled"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NumeAplicatie", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumeAplicatie", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Descriere", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Descriere", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Descriere", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Descriere", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_App", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "App", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsInstalled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsInstalled", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_lnkRolesNavigation
            // 
            this.sqlDataAdapter_lnkRolesNavigation.DeleteCommand = this.sqlDeleteCommand3;
            this.sqlDataAdapter_lnkRolesNavigation.InsertCommand = this.sqlInsertCommand3;
            this.sqlDataAdapter_lnkRolesNavigation.SelectCommand = this.sqlSelectCommand4;
            this.sqlDataAdapter_lnkRolesNavigation.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "lnkRolesNavigation", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("RolesID", "RolesID"),
                        new System.Data.Common.DataColumnMapping("NavigationID", "NavigationID"),
                        new System.Data.Common.DataColumnMapping("TipAccesID", "TipAccesID")})});
            this.sqlDataAdapter_lnkRolesNavigation.UpdateCommand = this.sqlUpdateCommand3;
            // 
            // sqlDeleteCommand3
            // 
            this.sqlDeleteCommand3.CommandText = "DELETE FROM [lnkRolesNavigation] WHERE (([ID] = @Original_ID) AND ([RolesID] = @O" +
    "riginal_RolesID) AND ([NavigationID] = @Original_NavigationID) AND ([TipAccesID]" +
    " = @Original_TipAccesID))";
            this.sqlDeleteCommand3.Connection = this.sqlConnection1;
            this.sqlDeleteCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_RolesID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RolesID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NavigationID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NavigationID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_TipAccesID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TipAccesID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand3
            // 
            this.sqlInsertCommand3.CommandText = resources.GetString("sqlInsertCommand3.CommandText");
            this.sqlInsertCommand3.Connection = this.sqlConnection1;
            this.sqlInsertCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@RolesID", System.Data.SqlDbType.UniqueIdentifier, 0, "RolesID"),
            new System.Data.SqlClient.SqlParameter("@NavigationID", System.Data.SqlDbType.UniqueIdentifier, 0, "NavigationID"),
            new System.Data.SqlClient.SqlParameter("@TipAccesID", System.Data.SqlDbType.UniqueIdentifier, 0, "TipAccesID")});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "SELECT     ID, RolesID, NavigationID, TipAccesID\r\nFROM         lnkRolesNavigation" +
    "";
            this.sqlSelectCommand4.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand3
            // 
            this.sqlUpdateCommand3.CommandText = resources.GetString("sqlUpdateCommand3.CommandText");
            this.sqlUpdateCommand3.Connection = this.sqlConnection1;
            this.sqlUpdateCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@RolesID", System.Data.SqlDbType.UniqueIdentifier, 0, "RolesID"),
            new System.Data.SqlClient.SqlParameter("@NavigationID", System.Data.SqlDbType.UniqueIdentifier, 0, "NavigationID"),
            new System.Data.SqlClient.SqlParameter("@TipAccesID", System.Data.SqlDbType.UniqueIdentifier, 0, "TipAccesID"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_RolesID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RolesID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NavigationID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NavigationID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_TipAccesID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TipAccesID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_lnkRolesDeschidereBase
            // 
            this.sqlDataAdapter_lnkRolesDeschidereBase.DeleteCommand = this.sqlDeleteCommand2;
            this.sqlDataAdapter_lnkRolesDeschidereBase.InsertCommand = this.sqlInsertCommand2;
            this.sqlDataAdapter_lnkRolesDeschidereBase.SelectCommand = this.sqlSelectCommand2;
            this.sqlDataAdapter_lnkRolesDeschidereBase.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "lnkRolesDeschidereBase", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("RolesID", "RolesID"),
                        new System.Data.Common.DataColumnMapping("DeschidereBaseID", "DeschidereBaseID")})});
            this.sqlDataAdapter_lnkRolesDeschidereBase.UpdateCommand = this.sqlUpdateCommand2;
            // 
            // sqlDeleteCommand2
            // 
            this.sqlDeleteCommand2.CommandText = "DELETE FROM [lnkRolesDeschidereBase] WHERE (([ID] = @Original_ID) AND ([RolesID] " +
    "= @Original_RolesID) AND ([DeschidereBaseID] = @Original_DeschidereBaseID))";
            this.sqlDeleteCommand2.Connection = this.sqlConnection1;
            this.sqlDeleteCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_RolesID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RolesID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DeschidereBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DeschidereBaseID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand2
            // 
            this.sqlInsertCommand2.CommandText = "INSERT INTO [lnkRolesDeschidereBase] ([ID], [RolesID], [DeschidereBaseID]) VALUES" +
    " (@ID, @RolesID, @DeschidereBaseID);\r\nSELECT ID, RolesID, DeschidereBaseID FROM " +
    "lnkRolesDeschidereBase WHERE (ID = @ID)";
            this.sqlInsertCommand2.Connection = this.sqlConnection1;
            this.sqlInsertCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@RolesID", System.Data.SqlDbType.UniqueIdentifier, 0, "RolesID"),
            new System.Data.SqlClient.SqlParameter("@DeschidereBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, "DeschidereBaseID")});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "SELECT     ID, RolesID, DeschidereBaseID\r\nFROM         lnkRolesDeschidereBase";
            this.sqlSelectCommand2.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand2
            // 
            this.sqlUpdateCommand2.CommandText = resources.GetString("sqlUpdateCommand2.CommandText");
            this.sqlUpdateCommand2.Connection = this.sqlConnection1;
            this.sqlUpdateCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@RolesID", System.Data.SqlDbType.UniqueIdentifier, 0, "RolesID"),
            new System.Data.SqlClient.SqlParameter("@DeschidereBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, "DeschidereBaseID"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_RolesID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RolesID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DeschidereBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DeschidereBaseID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_tblRoles
            // 
            this.sqlDataAdapter_tblRoles.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter_tblRoles.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter_tblRoles.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter_tblRoles.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblRoles", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("AplicatiiID", "AplicatiiID"),
                        new System.Data.Common.DataColumnMapping("RolName", "RolName"),
                        new System.Data.Common.DataColumnMapping("RolDescription", "RolDescription"),
                        new System.Data.Common.DataColumnMapping("CodIntern", "CodIntern")})});
            this.sqlDataAdapter_tblRoles.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = resources.GetString("sqlDeleteCommand1.CommandText");
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AplicatiiID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_RolName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RolName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_RolDescription", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "RolDescription", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_RolDescription", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RolDescription", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_CodIntern", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CodIntern", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_CodIntern", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CodIntern", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, "AplicatiiID"),
            new System.Data.SqlClient.SqlParameter("@RolName", System.Data.SqlDbType.NVarChar, 0, "RolName"),
            new System.Data.SqlClient.SqlParameter("@RolDescription", System.Data.SqlDbType.NVarChar, 0, "RolDescription"),
            new System.Data.SqlClient.SqlParameter("@CodIntern", System.Data.SqlDbType.VarChar, 0, "CodIntern")});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT     ID, AplicatiiID, RolName, RolDescription, CodIntern\r\nFROM         tblR" +
    "oles\r\nWHERE     (AplicatiiID = @pAplicatiiID)";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Connection = this.sqlConnection1;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, "AplicatiiID"),
            new System.Data.SqlClient.SqlParameter("@RolName", System.Data.SqlDbType.NVarChar, 0, "RolName"),
            new System.Data.SqlClient.SqlParameter("@RolDescription", System.Data.SqlDbType.NVarChar, 0, "RolDescription"),
            new System.Data.SqlClient.SqlParameter("@CodIntern", System.Data.SqlDbType.VarChar, 0, "CodIntern"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AplicatiiID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_RolName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RolName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_RolDescription", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "RolDescription", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_RolDescription", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RolDescription", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_CodIntern", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CodIntern", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_CodIntern", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CodIntern", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetModul
            // 
            this.sqlDataAdapter_GetModul.SelectCommand = this.sqlSelectCommand8;
            this.sqlDataAdapter_GetModul.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblModul", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("AplicatiiID", "AplicatiiID"),
                        new System.Data.Common.DataColumnMapping("TipModulID", "TipModulID"),
                        new System.Data.Common.DataColumnMapping("Abbreviation", "Abbreviation"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("IsBugetar", "IsBugetar")})});
            // 
            // sqlSelectCommand8
            // 
            this.sqlSelectCommand8.CommandText = resources.GetString("sqlSelectCommand8.CommandText");
            this.sqlSelectCommand8.Connection = this.sqlConnection1;
            this.sqlSelectCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID")});
            // 
            // sqlSelectCommand9
            // 
            this.sqlSelectCommand9.CommandText = resources.GetString("sqlSelectCommand9.CommandText");
            this.sqlSelectCommand9.Connection = this.sqlConnection1;
            this.sqlSelectCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID")});
            // 
            // sqlDataAdapter_GetDeschideriActive
            // 
            this.sqlDataAdapter_GetDeschideriActive.SelectCommand = this.sqlSelectCommand9;
            this.sqlDataAdapter_GetDeschideriActive.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblDeschidereBase", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("AplicatiiID", "AplicatiiID"),
                        new System.Data.Common.DataColumnMapping("NumeDeschidere", "NumeDeschidere"),
                        new System.Data.Common.DataColumnMapping("DataInitializare", "DataInitializare"),
                        new System.Data.Common.DataColumnMapping("DataDeschisa", "DataDeschisa"),
                        new System.Data.Common.DataColumnMapping("DataInchisa", "DataInchisa"),
                        new System.Data.Common.DataColumnMapping("IsBugetar", "IsBugetar")})});

        }

        #endregion

        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblDeschidereBase;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetNavigationByAppID;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetRolesDeschidereBase;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblAplicatii;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand5;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand5;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand5;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_lnkRolesNavigation;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand3;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand3;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand3;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_lnkRolesDeschidereBase;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblRoles;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetModul;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand9;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetDeschideriActive;
    }
}
