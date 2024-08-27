namespace Common_DT.Base
{
    partial class SecurityDataSvc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityDataSvc));
            this.sqlDataAdapter_lnkUsersDeschidere = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand10 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetRolesByUsersID = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand11 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblUserRights = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblUsers = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetModule = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetDeschidereDet = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblCentru = new System.Data.SqlClient.SqlDataAdapter();
            this.SelectCommandInstitutie = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblRoles = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetRolesDeschidereBase = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetNavigationByApplicationID = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetRolesNavigationByApplicationID = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblDeschidereBase = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand5 = new System.Data.SqlClient.SqlCommand();
            // 
            // sqlDataAdapter_lnkUsersDeschidere
            // 
            this.sqlDataAdapter_lnkUsersDeschidere.DeleteCommand = this.sqlDeleteCommand6;
            this.sqlDataAdapter_lnkUsersDeschidere.InsertCommand = this.sqlInsertCommand6;
            this.sqlDataAdapter_lnkUsersDeschidere.SelectCommand = this.sqlSelectCommand10;
            this.sqlDataAdapter_lnkUsersDeschidere.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "lnkUsersDeschidere", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("UsersID", "UsersID"),
                        new System.Data.Common.DataColumnMapping("DeschidereID", "DeschidereID"),
                        new System.Data.Common.DataColumnMapping("DataLucru", "DataLucru")})});
            this.sqlDataAdapter_lnkUsersDeschidere.UpdateCommand = this.sqlUpdateCommand6;
            // 
            // sqlDeleteCommand6
            // 
            this.sqlDeleteCommand6.CommandText = resources.GetString("sqlDeleteCommand6.CommandText");
            this.sqlDeleteCommand6.Connection = this.sqlConnection1;
            this.sqlDeleteCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UsersID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UsersID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DeschidereID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DeschidereID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DataLucru", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DataLucru", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DataLucru", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataLucru", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=GS0010\\SQL2008R2;Initial Catalog=GS_Comenzi;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand6
            // 
            this.sqlInsertCommand6.CommandText = resources.GetString("sqlInsertCommand6.CommandText");
            this.sqlInsertCommand6.Connection = this.sqlConnection1;
            this.sqlInsertCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@UsersID", System.Data.SqlDbType.UniqueIdentifier, 0, "UsersID"),
            new System.Data.SqlClient.SqlParameter("@DeschidereID", System.Data.SqlDbType.UniqueIdentifier, 0, "DeschidereID"),
            new System.Data.SqlClient.SqlParameter("@DataLucru", System.Data.SqlDbType.DateTime, 0, "DataLucru")});
            // 
            // sqlSelectCommand10
            // 
            this.sqlSelectCommand10.CommandText = "SELECT     ID, UsersID, DeschidereID, DataLucru\r\nFROM         lnkUsersDeschidere";
            this.sqlSelectCommand10.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand6
            // 
            this.sqlUpdateCommand6.CommandText = resources.GetString("sqlUpdateCommand6.CommandText");
            this.sqlUpdateCommand6.Connection = this.sqlConnection1;
            this.sqlUpdateCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@UsersID", System.Data.SqlDbType.UniqueIdentifier, 0, "UsersID"),
            new System.Data.SqlClient.SqlParameter("@DeschidereID", System.Data.SqlDbType.UniqueIdentifier, 0, "DeschidereID"),
            new System.Data.SqlClient.SqlParameter("@DataLucru", System.Data.SqlDbType.DateTime, 0, "DataLucru"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UsersID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UsersID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DeschidereID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DeschidereID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DataLucru", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DataLucru", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DataLucru", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataLucru", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetRolesByUsersID
            // 
            this.sqlDataAdapter_GetRolesByUsersID.SelectCommand = this.sqlSelectCommand11;
            this.sqlDataAdapter_GetRolesByUsersID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("RolesID", "RolesID")})});
            // 
            // sqlSelectCommand11
            // 
            this.sqlSelectCommand11.CommandText = resources.GetString("sqlSelectCommand11.CommandText");
            this.sqlSelectCommand11.Connection = this.sqlConnection1;
            this.sqlSelectCommand11.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pUsersID", System.Data.SqlDbType.UniqueIdentifier, 16, "UsersID")});
            // 
            // sqlDataAdapter_tblUserRights
            // 
            this.sqlDataAdapter_tblUserRights.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter_tblUserRights.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter_tblUserRights.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter_tblUserRights.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblUserRights", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("UsersID", "UsersID"),
                        new System.Data.Common.DataColumnMapping("AplicatiiID", "AplicatiiID"),
                        new System.Data.Common.DataColumnMapping("UserRights", "UserRights"),
                        new System.Data.Common.DataColumnMapping("UserRightsSpecific", "UserRightsSpecific")})});
            this.sqlDataAdapter_tblUserRights.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM [tblUserRights] WHERE (([ID] = @Original_ID) AND ([UsersID] = @Origin" +
    "al_UsersID) AND ([AplicatiiID] = @Original_AplicatiiID))";
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UsersID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UsersID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AplicatiiID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@UsersID", System.Data.SqlDbType.UniqueIdentifier, 0, "UsersID"),
            new System.Data.SqlClient.SqlParameter("@AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, "AplicatiiID"),
            new System.Data.SqlClient.SqlParameter("@UserRights", System.Data.SqlDbType.Xml, 0, "UserRights"),
            new System.Data.SqlClient.SqlParameter("@UserRightsSpecific", System.Data.SqlDbType.Xml, 0, "UserRightsSpecific")});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID"),
            new System.Data.SqlClient.SqlParameter("@pUsersID", System.Data.SqlDbType.UniqueIdentifier, 16, "UsersID")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Connection = this.sqlConnection1;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@UsersID", System.Data.SqlDbType.UniqueIdentifier, 0, "UsersID"),
            new System.Data.SqlClient.SqlParameter("@AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, "AplicatiiID"),
            new System.Data.SqlClient.SqlParameter("@UserRights", System.Data.SqlDbType.Xml, 0, "UserRights"),
            new System.Data.SqlClient.SqlParameter("@UserRightsSpecific", System.Data.SqlDbType.Xml, 0, "UserRightsSpecific"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UsersID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UsersID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AplicatiiID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_tblUsers
            // 
            this.sqlDataAdapter_tblUsers.DeleteCommand = this.sqlDeleteCommand2;
            this.sqlDataAdapter_tblUsers.InsertCommand = this.sqlInsertCommand2;
            this.sqlDataAdapter_tblUsers.SelectCommand = this.sqlSelectCommand2;
            this.sqlDataAdapter_tblUsers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblUsers", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Nume", "Nume"),
                        new System.Data.Common.DataColumnMapping("Prenume", "Prenume"),
                        new System.Data.Common.DataColumnMapping("UserName", "UserName"),
                        new System.Data.Common.DataColumnMapping("Password", "Password"),
                        new System.Data.Common.DataColumnMapping("IsActive", "IsActive"),
                        new System.Data.Common.DataColumnMapping("IsUtilizatorCentru", "IsUtilizatorCentru"),
                        new System.Data.Common.DataColumnMapping("TipConection", "TipConection"),
                        new System.Data.Common.DataColumnMapping("FullName", "FullName")})});
            this.sqlDataAdapter_tblUsers.UpdateCommand = this.sqlUpdateCommand2;
            // 
            // sqlDeleteCommand2
            // 
            this.sqlDeleteCommand2.CommandText = resources.GetString("sqlDeleteCommand2.CommandText");
            this.sqlDeleteCommand2.Connection = this.sqlConnection1;
            this.sqlDeleteCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Nume", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Nume", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Prenume", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Prenume", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UserName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Password", System.Data.SqlDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Password", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsUtilizatorCentru", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsUtilizatorCentru", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_TipConection", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TipConection", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand2
            // 
            this.sqlInsertCommand2.CommandText = resources.GetString("sqlInsertCommand2.CommandText");
            this.sqlInsertCommand2.Connection = this.sqlConnection1;
            this.sqlInsertCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Nume", System.Data.SqlDbType.NVarChar, 0, "Nume"),
            new System.Data.SqlClient.SqlParameter("@Prenume", System.Data.SqlDbType.NVarChar, 0, "Prenume"),
            new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.NVarChar, 0, "UserName"),
            new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.VarBinary, 0, "Password"),
            new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 0, "IsActive"),
            new System.Data.SqlClient.SqlParameter("@IsUtilizatorCentru", System.Data.SqlDbType.Bit, 0, "IsUtilizatorCentru"),
            new System.Data.SqlClient.SqlParameter("@TipConection", System.Data.SqlDbType.Bit, 0, "TipConection")});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "SELECT     *, Nume + \' \' + Prenume AS FullName\r\nFROM         tblUsers";
            this.sqlSelectCommand2.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand2
            // 
            this.sqlUpdateCommand2.CommandText = resources.GetString("sqlUpdateCommand2.CommandText");
            this.sqlUpdateCommand2.Connection = this.sqlConnection1;
            this.sqlUpdateCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Nume", System.Data.SqlDbType.NVarChar, 0, "Nume"),
            new System.Data.SqlClient.SqlParameter("@Prenume", System.Data.SqlDbType.NVarChar, 0, "Prenume"),
            new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.NVarChar, 0, "UserName"),
            new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.VarBinary, 0, "Password"),
            new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 0, "IsActive"),
            new System.Data.SqlClient.SqlParameter("@IsUtilizatorCentru", System.Data.SqlDbType.Bit, 0, "IsUtilizatorCentru"),
            new System.Data.SqlClient.SqlParameter("@TipConection", System.Data.SqlDbType.Bit, 0, "TipConection"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Nume", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Nume", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Prenume", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Prenume", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UserName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Password", System.Data.SqlDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Password", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsUtilizatorCentru", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsUtilizatorCentru", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_TipConection", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TipConection", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetModule
            // 
            this.sqlDataAdapter_GetModule.SelectCommand = this.sqlSelectCommand3;
            this.sqlDataAdapter_GetModule.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblModul", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("AplicatiiID", "AplicatiiID"),
                        new System.Data.Common.DataColumnMapping("TipModulID", "TipModulID"),
                        new System.Data.Common.DataColumnMapping("CodIntern", "CodIntern"),
                        new System.Data.Common.DataColumnMapping("ModulName", "ModulName")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = resources.GetString("sqlSelectCommand3.CommandText");
            this.sqlSelectCommand3.Connection = this.sqlConnection1;
            // 
            // sqlDataAdapter_GetDeschidereDet
            // 
            this.sqlDataAdapter_GetDeschidereDet.SelectCommand = this.sqlCommand1;
            this.sqlDataAdapter_GetDeschidereDet.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblDeschidereDet", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("DeschidereBaseID", "DeschidereBaseID"),
                        new System.Data.Common.DataColumnMapping("ServerName", "ServerName"),
                        new System.Data.Common.DataColumnMapping("TipAutentificare", "TipAutentificare"),
                        new System.Data.Common.DataColumnMapping("UserNameServer", "UserNameServer"),
                        new System.Data.Common.DataColumnMapping("PaswordServer", "PaswordServer"),
                        new System.Data.Common.DataColumnMapping("DataBaseName", "DataBaseName"),
                        new System.Data.Common.DataColumnMapping("TipDataBaseID", "TipDataBaseID"),
                        new System.Data.Common.DataColumnMapping("DataStart", "DataStart"),
                        new System.Data.Common.DataColumnMapping("DataStop", "DataStop"),
                        new System.Data.Common.DataColumnMapping("IsActive", "IsActive"),
                        new System.Data.Common.DataColumnMapping("IsRemote", "IsRemote"),
                        new System.Data.Common.DataColumnMapping("ServerNameLocal", "ServerNameLocal"),
                        new System.Data.Common.DataColumnMapping("ExcludeFromCumul", "ExcludeFromCumul")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "SELECT     tblDeschidereDet.*\r\nFROM         tblDeschidereDet\r\nWHERE     (IsActive" +
    " = 1)";
            this.sqlCommand1.Connection = this.sqlConnection1;
            // 
            // sqlDataAdapter_tblCentru
            // 
            this.sqlDataAdapter_tblCentru.SelectCommand = this.SelectCommandInstitutie;
            this.sqlDataAdapter_tblCentru.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblCentru", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Cod", "Cod"),
                        new System.Data.Common.DataColumnMapping("Denumire", "Denumire"),
                        new System.Data.Common.DataColumnMapping("IsActive", "IsActive"),
                        new System.Data.Common.DataColumnMapping("TipCentruID", "TipCentruID"),
                        new System.Data.Common.DataColumnMapping("DeschidereBaseID", "DeschidereBaseID"),
                        new System.Data.Common.DataColumnMapping("ModulID", "ModulID")})});
            // 
            // SelectCommandInstitutie
            // 
            this.SelectCommandInstitutie.CommandText = "\r\nSELECT  tblCentru.ID ,\r\n        Cod ,\r\n        Denumire ,\r\n        IsActive ,\r\n" +
    "        TipCentruID ,\r\n        @pDeschidereBaseID AS DeschidereBaseID ,\r\n ModulI" +
    "D\r\nFROM    tblCentru\r\n";
            this.SelectCommandInstitutie.Connection = this.sqlConnection1;
            this.SelectCommandInstitutie.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pDeschidereBaseID", System.Data.SqlDbType.UniqueIdentifier, 1024)});
            // 
            // sqlDataAdapter_tblRoles
            // 
            this.sqlDataAdapter_tblRoles.DeleteCommand = this.sqlDeleteCommand3;
            this.sqlDataAdapter_tblRoles.InsertCommand = this.sqlInsertCommand3;
            this.sqlDataAdapter_tblRoles.SelectCommand = this.sqlSelectCommand4;
            this.sqlDataAdapter_tblRoles.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblRoles", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("AplicatiiID", "AplicatiiID"),
                        new System.Data.Common.DataColumnMapping("RolName", "RolName"),
                        new System.Data.Common.DataColumnMapping("RolDescription", "RolDescription"),
                        new System.Data.Common.DataColumnMapping("CodIntern", "CodIntern")})});
            this.sqlDataAdapter_tblRoles.UpdateCommand = this.sqlUpdateCommand3;
            // 
            // sqlDeleteCommand3
            // 
            this.sqlDeleteCommand3.CommandText = resources.GetString("sqlDeleteCommand3.CommandText");
            this.sqlDeleteCommand3.Connection = this.sqlConnection1;
            this.sqlDeleteCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AplicatiiID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_RolName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RolName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_RolDescription", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "RolDescription", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_RolDescription", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RolDescription", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_CodIntern", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CodIntern", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_CodIntern", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CodIntern", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand3
            // 
            this.sqlInsertCommand3.CommandText = resources.GetString("sqlInsertCommand3.CommandText");
            this.sqlInsertCommand3.Connection = this.sqlConnection1;
            this.sqlInsertCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, "AplicatiiID"),
            new System.Data.SqlClient.SqlParameter("@RolName", System.Data.SqlDbType.NVarChar, 0, "RolName"),
            new System.Data.SqlClient.SqlParameter("@RolDescription", System.Data.SqlDbType.NVarChar, 0, "RolDescription"),
            new System.Data.SqlClient.SqlParameter("@CodIntern", System.Data.SqlDbType.VarChar, 0, "CodIntern")});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "SELECT     ID, AplicatiiID, RolName, RolDescription, CodIntern\r\nFROM         tblR" +
    "oles";
            this.sqlSelectCommand4.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand3
            // 
            this.sqlUpdateCommand3.CommandText = resources.GetString("sqlUpdateCommand3.CommandText");
            this.sqlUpdateCommand3.Connection = this.sqlConnection1;
            this.sqlUpdateCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
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
            // sqlDataAdapter_GetRolesDeschidereBase
            // 
            this.sqlDataAdapter_GetRolesDeschidereBase.SelectCommand = this.sqlSelectCommand9;
            this.sqlDataAdapter_GetRolesDeschidereBase.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "lnkRolesDeschidereBase", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("RolesID", "RolesID"),
                        new System.Data.Common.DataColumnMapping("DeschidereBaseID", "DeschidereBaseID")})});
            // 
            // sqlSelectCommand9
            // 
            this.sqlSelectCommand9.CommandText = resources.GetString("sqlSelectCommand9.CommandText");
            this.sqlSelectCommand9.Connection = this.sqlConnection1;
            this.sqlSelectCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID")});
            // 
            // sqlDataAdapter_GetNavigationByApplicationID
            // 
            this.sqlDataAdapter_GetNavigationByApplicationID.DeleteCommand = this.sqlDeleteCommand;
            this.sqlDataAdapter_GetNavigationByApplicationID.InsertCommand = this.sqlInsertCommand;
            this.sqlDataAdapter_GetNavigationByApplicationID.SelectCommand = this.sqlSelectCommand6;
            this.sqlDataAdapter_GetNavigationByApplicationID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblNavigation", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Node", "Node"),
                        new System.Data.Common.DataColumnMapping("NAME", "NAME"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("NavigateUrl", "NavigateUrl"),
                        new System.Data.Common.DataColumnMapping("Permission", "Permission"),
                        new System.Data.Common.DataColumnMapping("ParentGroupID", "ParentGroupID"),
                        new System.Data.Common.DataColumnMapping("PreCondition", "PreCondition"),
                        new System.Data.Common.DataColumnMapping("QueryString", "QueryString"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("WindowString", "WindowString"),
                        new System.Data.Common.DataColumnMapping("IsDialogWindow", "IsDialogWindow"),
                        new System.Data.Common.DataColumnMapping("IsWeb", "IsWeb"),
                        new System.Data.Common.DataColumnMapping("IsWindow", "IsWindow"),
                        new System.Data.Common.DataColumnMapping("ModulID", "ModulID"),
                        new System.Data.Common.DataColumnMapping("AplicatiiID", "AplicatiiID"),
                        new System.Data.Common.DataColumnMapping("ShortcutValue", "ShortcutValue"),
                        new System.Data.Common.DataColumnMapping("modifiedTimeStamp", "modifiedTimeStamp")})});
            this.sqlDataAdapter_GetNavigationByApplicationID.UpdateCommand = this.sqlUpdateCommand;
            // 
            // sqlDeleteCommand
            // 
            this.sqlDeleteCommand.CommandText = resources.GetString("sqlDeleteCommand.CommandText");
            this.sqlDeleteCommand.Connection = this.sqlConnection1;
            this.sqlDeleteCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Node", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Node", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NAME", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NAME", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Description", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_NavigateUrl", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NavigateUrl", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_NavigateUrl", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NavigateUrl", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Permission", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Permission", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ParentGroupID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ParentGroupID", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ParentGroupID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ParentGroupID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PreCondition", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PreCondition", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PreCondition", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PreCondition", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_QueryString", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QueryString", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_QueryString", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QueryString", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Title", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_WindowString", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "WindowString", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_WindowString", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "WindowString", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_IsDialogWindow", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IsDialogWindow", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_IsDialogWindow", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsDialogWindow", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsWeb", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsWeb", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsWindow", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsWindow", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ModulID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ModulID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AplicatiiID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ShortcutValue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShortcutValue", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ShortcutValue", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShortcutValue", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_modifiedTimeStamp", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "modifiedTimeStamp", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_modifiedTimeStamp", System.Data.SqlDbType.Binary, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "modifiedTimeStamp", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand
            // 
            this.sqlInsertCommand.CommandText = resources.GetString("sqlInsertCommand.CommandText");
            this.sqlInsertCommand.Connection = this.sqlConnection1;
            this.sqlInsertCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Node", System.Data.SqlDbType.Int, 0, "Node"),
            new System.Data.SqlClient.SqlParameter("@NAME", System.Data.SqlDbType.VarChar, 0, "NAME"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 0, "Description"),
            new System.Data.SqlClient.SqlParameter("@NavigateUrl", System.Data.SqlDbType.VarChar, 0, "NavigateUrl"),
            new System.Data.SqlClient.SqlParameter("@Permission", System.Data.SqlDbType.VarChar, 0, "Permission"),
            new System.Data.SqlClient.SqlParameter("@ParentGroupID", System.Data.SqlDbType.UniqueIdentifier, 0, "ParentGroupID"),
            new System.Data.SqlClient.SqlParameter("@PreCondition", System.Data.SqlDbType.VarChar, 0, "PreCondition"),
            new System.Data.SqlClient.SqlParameter("@QueryString", System.Data.SqlDbType.VarChar, 0, "QueryString"),
            new System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.VarChar, 0, "Title"),
            new System.Data.SqlClient.SqlParameter("@WindowString", System.Data.SqlDbType.VarChar, 0, "WindowString"),
            new System.Data.SqlClient.SqlParameter("@IsDialogWindow", System.Data.SqlDbType.Bit, 0, "IsDialogWindow"),
            new System.Data.SqlClient.SqlParameter("@IsWeb", System.Data.SqlDbType.Bit, 0, "IsWeb"),
            new System.Data.SqlClient.SqlParameter("@IsWindow", System.Data.SqlDbType.Bit, 0, "IsWindow"),
            new System.Data.SqlClient.SqlParameter("@ModulID", System.Data.SqlDbType.UniqueIdentifier, 0, "ModulID"),
            new System.Data.SqlClient.SqlParameter("@AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, "AplicatiiID"),
            new System.Data.SqlClient.SqlParameter("@ShortcutValue", System.Data.SqlDbType.VarChar, 0, "ShortcutValue"),
            new System.Data.SqlClient.SqlParameter("@modifiedTimeStamp", System.Data.SqlDbType.Binary, 0, "modifiedTimeStamp")});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = resources.GetString("sqlSelectCommand6.CommandText");
            this.sqlSelectCommand6.Connection = this.sqlConnection1;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID")});
            // 
            // sqlUpdateCommand
            // 
            this.sqlUpdateCommand.CommandText = resources.GetString("sqlUpdateCommand.CommandText");
            this.sqlUpdateCommand.Connection = this.sqlConnection1;
            this.sqlUpdateCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Node", System.Data.SqlDbType.Int, 0, "Node"),
            new System.Data.SqlClient.SqlParameter("@NAME", System.Data.SqlDbType.VarChar, 0, "NAME"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 0, "Description"),
            new System.Data.SqlClient.SqlParameter("@NavigateUrl", System.Data.SqlDbType.VarChar, 0, "NavigateUrl"),
            new System.Data.SqlClient.SqlParameter("@Permission", System.Data.SqlDbType.VarChar, 0, "Permission"),
            new System.Data.SqlClient.SqlParameter("@ParentGroupID", System.Data.SqlDbType.UniqueIdentifier, 0, "ParentGroupID"),
            new System.Data.SqlClient.SqlParameter("@PreCondition", System.Data.SqlDbType.VarChar, 0, "PreCondition"),
            new System.Data.SqlClient.SqlParameter("@QueryString", System.Data.SqlDbType.VarChar, 0, "QueryString"),
            new System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.VarChar, 0, "Title"),
            new System.Data.SqlClient.SqlParameter("@WindowString", System.Data.SqlDbType.VarChar, 0, "WindowString"),
            new System.Data.SqlClient.SqlParameter("@IsDialogWindow", System.Data.SqlDbType.Bit, 0, "IsDialogWindow"),
            new System.Data.SqlClient.SqlParameter("@IsWeb", System.Data.SqlDbType.Bit, 0, "IsWeb"),
            new System.Data.SqlClient.SqlParameter("@IsWindow", System.Data.SqlDbType.Bit, 0, "IsWindow"),
            new System.Data.SqlClient.SqlParameter("@ModulID", System.Data.SqlDbType.UniqueIdentifier, 0, "ModulID"),
            new System.Data.SqlClient.SqlParameter("@AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, "AplicatiiID"),
            new System.Data.SqlClient.SqlParameter("@ShortcutValue", System.Data.SqlDbType.VarChar, 0, "ShortcutValue"),
            new System.Data.SqlClient.SqlParameter("@modifiedTimeStamp", System.Data.SqlDbType.Binary, 0, "modifiedTimeStamp"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Node", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Node", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NAME", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NAME", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Description", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_NavigateUrl", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NavigateUrl", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_NavigateUrl", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NavigateUrl", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Permission", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Permission", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ParentGroupID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ParentGroupID", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ParentGroupID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ParentGroupID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PreCondition", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PreCondition", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PreCondition", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PreCondition", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_QueryString", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "QueryString", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_QueryString", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "QueryString", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Title", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Title", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_WindowString", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "WindowString", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_WindowString", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "WindowString", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_IsDialogWindow", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IsDialogWindow", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_IsDialogWindow", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsDialogWindow", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsWeb", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsWeb", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsWindow", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsWindow", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ModulID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ModulID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AplicatiiID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ShortcutValue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShortcutValue", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ShortcutValue", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShortcutValue", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_modifiedTimeStamp", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "modifiedTimeStamp", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_modifiedTimeStamp", System.Data.SqlDbType.Binary, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "modifiedTimeStamp", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetRolesNavigationByApplicationID
            // 
            this.sqlDataAdapter_GetRolesNavigationByApplicationID.SelectCommand = this.sqlSelectCommand7;
            this.sqlDataAdapter_GetRolesNavigationByApplicationID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "lnkRolesNavigation", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("RolesID", "RolesID"),
                        new System.Data.Common.DataColumnMapping("NavigationID", "NavigationID"),
                        new System.Data.Common.DataColumnMapping("TipAccesID", "TipAccesID"),
                        new System.Data.Common.DataColumnMapping("CodIntern", "CodIntern"),
                        new System.Data.Common.DataColumnMapping("ModulID", "ModulID")})});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = resources.GetString("sqlSelectCommand7.CommandText");
            this.sqlSelectCommand7.Connection = this.sqlConnection1;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID")});
            // 
            // sqlDataAdapter_tblDeschidereBase
            // 
            this.sqlDataAdapter_tblDeschidereBase.DeleteCommand = this.sqlDeleteCommand5;
            this.sqlDataAdapter_tblDeschidereBase.InsertCommand = this.sqlInsertCommand5;
            this.sqlDataAdapter_tblDeschidereBase.SelectCommand = this.sqlSelectCommand8;
            this.sqlDataAdapter_tblDeschidereBase.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblDeschidereBase", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("AplicatiiID", "AplicatiiID"),
                        new System.Data.Common.DataColumnMapping("NumeDeschidere", "NumeDeschidere"),
                        new System.Data.Common.DataColumnMapping("DataInitializare", "DataInitializare"),
                        new System.Data.Common.DataColumnMapping("DataDeschisa", "DataDeschisa"),
                        new System.Data.Common.DataColumnMapping("DataInchisa", "DataInchisa"),
                        new System.Data.Common.DataColumnMapping("IsBugetar", "IsBugetar")})});
            this.sqlDataAdapter_tblDeschidereBase.UpdateCommand = this.sqlUpdateCommand5;
            // 
            // sqlDeleteCommand5
            // 
            this.sqlDeleteCommand5.CommandText = resources.GetString("sqlDeleteCommand5.CommandText");
            this.sqlDeleteCommand5.Connection = this.sqlConnection1;
            this.sqlDeleteCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AplicatiiID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NumeDeschidere", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumeDeschidere", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DataInitializare", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataInitializare", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DataDeschisa", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DataDeschisa", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DataDeschisa", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataDeschisa", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DataInchisa", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DataInchisa", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DataInchisa", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataInchisa", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsBugetar", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsBugetar", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand5
            // 
            this.sqlInsertCommand5.CommandText = resources.GetString("sqlInsertCommand5.CommandText");
            this.sqlInsertCommand5.Connection = this.sqlConnection1;
            this.sqlInsertCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, "AplicatiiID"),
            new System.Data.SqlClient.SqlParameter("@NumeDeschidere", System.Data.SqlDbType.NVarChar, 0, "NumeDeschidere"),
            new System.Data.SqlClient.SqlParameter("@DataInitializare", System.Data.SqlDbType.DateTime, 0, "DataInitializare"),
            new System.Data.SqlClient.SqlParameter("@DataDeschisa", System.Data.SqlDbType.DateTime, 0, "DataDeschisa"),
            new System.Data.SqlClient.SqlParameter("@DataInchisa", System.Data.SqlDbType.DateTime, 0, "DataInchisa"),
            new System.Data.SqlClient.SqlParameter("@IsBugetar", System.Data.SqlDbType.Bit, 0, "IsBugetar")});
            // 
            // sqlSelectCommand8
            // 
            this.sqlSelectCommand8.CommandText = "SELECT     ID, AplicatiiID, NumeDeschidere, DataInitializare, DataDeschisa, DataI" +
    "nchisa, IsBugetar\r\nFROM         tblDeschidereBase\r\nWHERE     (AplicatiiID = @pAp" +
    "licatiiID)";
            this.sqlSelectCommand8.Connection = this.sqlConnection1;
            this.sqlSelectCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pAplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 16, "AplicatiiID")});
            // 
            // sqlUpdateCommand5
            // 
            this.sqlUpdateCommand5.CommandText = resources.GetString("sqlUpdateCommand5.CommandText");
            this.sqlUpdateCommand5.Connection = this.sqlConnection1;
            this.sqlUpdateCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, "AplicatiiID"),
            new System.Data.SqlClient.SqlParameter("@NumeDeschidere", System.Data.SqlDbType.NVarChar, 0, "NumeDeschidere"),
            new System.Data.SqlClient.SqlParameter("@DataInitializare", System.Data.SqlDbType.DateTime, 0, "DataInitializare"),
            new System.Data.SqlClient.SqlParameter("@DataDeschisa", System.Data.SqlDbType.DateTime, 0, "DataDeschisa"),
            new System.Data.SqlClient.SqlParameter("@DataInchisa", System.Data.SqlDbType.DateTime, 0, "DataInchisa"),
            new System.Data.SqlClient.SqlParameter("@IsBugetar", System.Data.SqlDbType.Bit, 0, "IsBugetar"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AplicatiiID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AplicatiiID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NumeDeschidere", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumeDeschidere", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DataInitializare", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataInitializare", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DataDeschisa", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DataDeschisa", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DataDeschisa", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataDeschisa", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DataInchisa", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DataInchisa", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DataInchisa", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataInchisa", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsBugetar", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsBugetar", System.Data.DataRowVersion.Original, null)});

        }

        #endregion

        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_lnkUsersDeschidere;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand6;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand6;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand10;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand6;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetRolesByUsersID;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand11;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblUserRights;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblUsers;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetModule;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetDeschidereDet;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblCentru;
        private System.Data.SqlClient.SqlCommand SelectCommandInstitutie;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblRoles;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand3;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand3;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand3;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetRolesDeschidereBase;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand9;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetNavigationByApplicationID;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetRolesNavigationByApplicationID;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblDeschidereBase;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand5;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand5;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand5;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
    }
}
