
namespace DataTier
{
    partial class ActiuniCRUDDT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiuniCRUDDT));
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
            this.taraAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand4 = new System.Data.SqlClient.SqlCommand();
            this.judetAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.editeazaPersonaleAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
            this.contactAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.tip_ContactAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.datePersonaleAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand8 = new System.Data.SqlClient.SqlCommand();
            this.adresaAdpter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand10 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand11 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand12 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand5 = new System.Data.SqlClient.SqlCommand();
            this.taraByNumeAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.judetByNumeAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand13 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand14 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand6 = new System.Data.SqlClient.SqlCommand();
            this.editeazaAdapter = new System.Data.SqlClient.SqlDataAdapter();
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "SELECT Tara, ID_Tara FROM Tara";
            this.sqlSelectCommand2.Connection = this.sqlConnection1;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=GS0022\\SQL2019;Initial Catalog=Agenda_Personala;User ID=sa;Password=1" +
    "234";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand2
            // 
            this.sqlInsertCommand2.CommandText = "INSERT INTO [Tara] ([Tara], [ID_Tara]) VALUES (@Tara, @ID_Tara);\r\nSELECT Tara, ID" +
    "_Tara FROM Tara WHERE (ID_Tara = @ID_Tara)";
            this.sqlInsertCommand2.Connection = this.sqlConnection1;
            this.sqlInsertCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Tara", System.Data.SqlDbType.VarChar, 0, "Tara"),
            new System.Data.SqlClient.SqlParameter("@ID_Tara", System.Data.SqlDbType.Int, 0, "ID_Tara")});
            // 
            // sqlUpdateCommand2
            // 
            this.sqlUpdateCommand2.CommandText = resources.GetString("sqlUpdateCommand2.CommandText");
            this.sqlUpdateCommand2.Connection = this.sqlConnection1;
            this.sqlUpdateCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Tara", System.Data.SqlDbType.VarChar, 0, "Tara"),
            new System.Data.SqlClient.SqlParameter("@ID_Tara", System.Data.SqlDbType.Int, 0, "ID_Tara"),
            new System.Data.SqlClient.SqlParameter("@IsNull_Tara", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Tara", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Tara", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Tara", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Tara", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Tara", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand2
            // 
            this.sqlDeleteCommand2.CommandText = "DELETE FROM [Tara] WHERE (((@IsNull_Tara = 1 AND [Tara] IS NULL) OR ([Tara] = @Or" +
    "iginal_Tara)) AND ([ID_Tara] = @Original_ID_Tara))";
            this.sqlDeleteCommand2.Connection = this.sqlConnection1;
            this.sqlDeleteCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@IsNull_Tara", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Tara", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Tara", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Tara", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Tara", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Tara", System.Data.DataRowVersion.Original, null)});
            // 
            // taraAdapter
            // 
            this.taraAdapter.DeleteCommand = this.sqlDeleteCommand2;
            this.taraAdapter.InsertCommand = this.sqlInsertCommand2;
            this.taraAdapter.SelectCommand = this.sqlSelectCommand2;
            this.taraAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Tara", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Tara", "Tara"),
                        new System.Data.Common.DataColumnMapping("ID_Tara", "ID_Tara")})});
            this.taraAdapter.UpdateCommand = this.sqlUpdateCommand2;
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT     ID_Judet, Judet\r\nFROM         Judet";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = "INSERT INTO [Judet] ([ID_Judet], [Judet]) VALUES (@ID_Judet, @Judet);\r\nSELECT ID_" +
    "Judet, Judet FROM Judet WHERE (ID_Judet = @ID_Judet)";
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_Judet", System.Data.SqlDbType.Int, 0, "ID_Judet"),
            new System.Data.SqlClient.SqlParameter("@Judet", System.Data.SqlDbType.VarChar, 0, "Judet")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Connection = this.sqlConnection1;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_Judet", System.Data.SqlDbType.Int, 0, "ID_Judet"),
            new System.Data.SqlClient.SqlParameter("@Judet", System.Data.SqlDbType.VarChar, 0, "Judet"),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Judet", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Judet", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Judet", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Judet", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM [Judet] WHERE (([ID_Judet] = @Original_ID_Judet) AND ((@IsNull_Judet " +
    "= 1 AND [Judet] IS NULL) OR ([Judet] = @Original_Judet)))";
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Judet", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Judet", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Judet", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Judet", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "SELECT     Judet, ID_Judet\r\nFROM         Judet";
            this.sqlSelectCommand4.Connection = this.sqlConnection1;
            // 
            // sqlInsertCommand4
            // 
            this.sqlInsertCommand4.CommandText = "INSERT INTO [Judet] ([Judet], [ID_Judet]) VALUES (@Judet, @ID_Judet);\r\nSELECT Jud" +
    "et, ID_Judet FROM Judet WHERE (ID_Judet = @ID_Judet)";
            this.sqlInsertCommand4.Connection = this.sqlConnection1;
            this.sqlInsertCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Judet", System.Data.SqlDbType.VarChar, 0, "Judet"),
            new System.Data.SqlClient.SqlParameter("@ID_Judet", System.Data.SqlDbType.Int, 0, "ID_Judet")});
            // 
            // sqlUpdateCommand4
            // 
            this.sqlUpdateCommand4.CommandText = resources.GetString("sqlUpdateCommand4.CommandText");
            this.sqlUpdateCommand4.Connection = this.sqlConnection1;
            this.sqlUpdateCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Judet", System.Data.SqlDbType.VarChar, 0, "Judet"),
            new System.Data.SqlClient.SqlParameter("@ID_Judet", System.Data.SqlDbType.Int, 0, "ID_Judet"),
            new System.Data.SqlClient.SqlParameter("@IsNull_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Judet", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Judet", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Judet", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Judet", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand4
            // 
            this.sqlDeleteCommand4.CommandText = "DELETE FROM [Judet] WHERE (((@IsNull_Judet = 1 AND [Judet] IS NULL) OR ([Judet] =" +
    " @Original_Judet)) AND ([ID_Judet] = @Original_ID_Judet))";
            this.sqlDeleteCommand4.Connection = this.sqlConnection1;
            this.sqlDeleteCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@IsNull_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Judet", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Judet", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Judet", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Judet", System.Data.DataRowVersion.Original, null)});
            // 
            // judetAdapter
            // 
            this.judetAdapter.DeleteCommand = this.sqlDeleteCommand4;
            this.judetAdapter.InsertCommand = this.sqlInsertCommand4;
            this.judetAdapter.SelectCommand = this.sqlSelectCommand4;
            this.judetAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Judet", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Judet", "Judet"),
                        new System.Data.Common.DataColumnMapping("ID_Judet", "ID_Judet")})});
            this.judetAdapter.UpdateCommand = this.sqlUpdateCommand4;
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = resources.GetString("sqlSelectCommand5.CommandText");
            this.sqlSelectCommand5.Connection = this.sqlConnection1;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_DP", System.Data.SqlDbType.Int, 4, "ID_DP")});
            // 
            // editeazaPersonaleAdapter
            // 
            this.editeazaPersonaleAdapter.SelectCommand = this.sqlSelectCommand5;
            this.editeazaPersonaleAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "DatePersonale", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Nume", "Nume"),
                        new System.Data.Common.DataColumnMapping("Prenume", "Prenume"),
                        new System.Data.Common.DataColumnMapping("CNP", "CNP"),
                        new System.Data.Common.DataColumnMapping("Judet", "Judet"),
                        new System.Data.Common.DataColumnMapping("Tara", "Tara"),
                        new System.Data.Common.DataColumnMapping("ID_DP", "ID_DP")})});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "SELECT     Contact, ID_DP, Contact_ID, Contact_Tip_Id\r\nFROM         Contact";
            this.sqlSelectCommand6.Connection = this.sqlConnection1;
            // 
            // sqlInsertCommand3
            // 
            this.sqlInsertCommand3.CommandText = resources.GetString("sqlInsertCommand3.CommandText");
            this.sqlInsertCommand3.Connection = this.sqlConnection1;
            this.sqlInsertCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Contact", System.Data.SqlDbType.VarChar, 0, "Contact"),
            new System.Data.SqlClient.SqlParameter("@ID_DP", System.Data.SqlDbType.Int, 0, "ID_DP"),
            new System.Data.SqlClient.SqlParameter("@Contact_Tip_Id", System.Data.SqlDbType.Int, 0, "Contact_Tip_Id")});
            // 
            // sqlUpdateCommand3
            // 
            this.sqlUpdateCommand3.CommandText = resources.GetString("sqlUpdateCommand3.CommandText");
            this.sqlUpdateCommand3.Connection = this.sqlConnection1;
            this.sqlUpdateCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Contact", System.Data.SqlDbType.VarChar, 0, "Contact"),
            new System.Data.SqlClient.SqlParameter("@ID_DP", System.Data.SqlDbType.Int, 0, "ID_DP"),
            new System.Data.SqlClient.SqlParameter("@Contact_Tip_Id", System.Data.SqlDbType.Int, 0, "Contact_Tip_Id"),
            new System.Data.SqlClient.SqlParameter("@Original_Contact", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_DP", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_DP", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Contact_Tip_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Contact_Tip_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_Tip_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_Tip_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Contact_ID", System.Data.SqlDbType.Int, 4, "Contact_ID")});
            // 
            // sqlDeleteCommand3
            // 
            this.sqlDeleteCommand3.CommandText = resources.GetString("sqlDeleteCommand3.CommandText");
            this.sqlDeleteCommand3.Connection = this.sqlConnection1;
            this.sqlDeleteCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Contact", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_DP", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_DP", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Contact_Tip_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Contact_Tip_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_Tip_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_Tip_Id", System.Data.DataRowVersion.Original, null)});
            // 
            // contactAdapter
            // 
            this.contactAdapter.DeleteCommand = this.sqlDeleteCommand3;
            this.contactAdapter.InsertCommand = this.sqlInsertCommand3;
            this.contactAdapter.SelectCommand = this.sqlSelectCommand6;
            this.contactAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Contact", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Contact", "Contact"),
                        new System.Data.Common.DataColumnMapping("ID_DP", "ID_DP"),
                        new System.Data.Common.DataColumnMapping("Contact_ID", "Contact_ID"),
                        new System.Data.Common.DataColumnMapping("Contact_Tip_Id", "Contact_Tip_Id")})});
            this.contactAdapter.UpdateCommand = this.sqlUpdateCommand3;
            // 
            // tip_ContactAdapter
            // 
            this.tip_ContactAdapter.DeleteCommand = this.sqlDeleteCommand;
            this.tip_ContactAdapter.InsertCommand = this.sqlCommand2;
            this.tip_ContactAdapter.SelectCommand = this.sqlCommand3;
            this.tip_ContactAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Contact_Tip", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Contact_Tip_Id", "Contact_Tip_Id"),
                        new System.Data.Common.DataColumnMapping("Contact_Tip", "Contact_Tip")})});
            this.tip_ContactAdapter.UpdateCommand = this.sqlUpdateCommand;
            // 
            // sqlDeleteCommand
            // 
            this.sqlDeleteCommand.CommandText = "DELETE FROM [Contact_Tip] WHERE (([Contact_Tip_Id] = @Original_Contact_Tip_Id) AN" +
    "D ((@IsNull_Contact_Tip = 1 AND [Contact_Tip] IS NULL) OR ([Contact_Tip] = @Orig" +
    "inal_Contact_Tip)))";
            this.sqlDeleteCommand.Connection = this.sqlConnection1;
            this.sqlDeleteCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Contact_Tip_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_Tip_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Contact_Tip", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Contact_Tip", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_Tip", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_Tip", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = "INSERT INTO [Contact_Tip] ([Contact_Tip_Id], [Contact_Tip]) VALUES (@Contact_Tip_" +
    "Id, @Contact_Tip);\r\nSELECT Contact_Tip_Id, Contact_Tip FROM Contact_Tip WHERE (C" +
    "ontact_Tip_Id = @Contact_Tip_Id)";
            this.sqlCommand2.Connection = this.sqlConnection1;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Contact_Tip_Id", System.Data.SqlDbType.Int, 0, "Contact_Tip_Id"),
            new System.Data.SqlClient.SqlParameter("@Contact_Tip", System.Data.SqlDbType.VarChar, 0, "Contact_Tip")});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = "SELECT     Contact_Tip_Id, Contact_Tip\r\nFROM         Contact_Tip";
            this.sqlCommand3.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand
            // 
            this.sqlUpdateCommand.CommandText = resources.GetString("sqlUpdateCommand.CommandText");
            this.sqlUpdateCommand.Connection = this.sqlConnection1;
            this.sqlUpdateCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Contact_Tip_Id", System.Data.SqlDbType.Int, 0, "Contact_Tip_Id"),
            new System.Data.SqlClient.SqlParameter("@Contact_Tip", System.Data.SqlDbType.VarChar, 0, "Contact_Tip"),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_Tip_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_Tip_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Contact_Tip", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Contact_Tip", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_Tip", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_Tip", System.Data.DataRowVersion.Original, null)});
            // 
            // datePersonaleAdapter
            // 
            this.datePersonaleAdapter.DeleteCommand = this.sqlCommand5;
            this.datePersonaleAdapter.InsertCommand = this.sqlCommand6;
            this.datePersonaleAdapter.SelectCommand = this.sqlCommand7;
            this.datePersonaleAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "DatePersonale", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID_DP", "ID_DP"),
                        new System.Data.Common.DataColumnMapping("Nume", "Nume"),
                        new System.Data.Common.DataColumnMapping("Prenume", "Prenume"),
                        new System.Data.Common.DataColumnMapping("CNP", "CNP")})});
            this.datePersonaleAdapter.UpdateCommand = this.sqlCommand8;
            // 
            // sqlCommand5
            // 
            this.sqlCommand5.CommandText = resources.GetString("sqlCommand5.CommandText");
            this.sqlCommand5.Connection = this.sqlConnection1;
            this.sqlCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID_DP", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_DP", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Nume", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Nume", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Nume", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Nume", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Prenume", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Prenume", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Prenume", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Prenume", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_CNP", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CNP", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_CNP", System.Data.SqlDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CNP", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand6
            // 
            this.sqlCommand6.CommandText = "INSERT INTO [DatePersonale] ([Nume], [Prenume], [CNP]) VALUES (@Nume, @Prenume, @" +
    "CNP);\r\nSELECT ID_DP, Nume, Prenume, CNP FROM DatePersonale WHERE (ID_DP = SCOPE_" +
    "IDENTITY())";
            this.sqlCommand6.Connection = this.sqlConnection1;
            this.sqlCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Nume", System.Data.SqlDbType.VarChar, 0, "Nume"),
            new System.Data.SqlClient.SqlParameter("@Prenume", System.Data.SqlDbType.VarChar, 0, "Prenume"),
            new System.Data.SqlClient.SqlParameter("@CNP", System.Data.SqlDbType.Char, 0, "CNP")});
            // 
            // sqlCommand7
            // 
            this.sqlCommand7.CommandText = "SELECT     ID_DP, Nume, Prenume, CNP\r\nFROM         DatePersonale";
            this.sqlCommand7.Connection = this.sqlConnection1;
            // 
            // sqlCommand8
            // 
            this.sqlCommand8.CommandText = resources.GetString("sqlCommand8.CommandText");
            this.sqlCommand8.Connection = this.sqlConnection1;
            this.sqlCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Nume", System.Data.SqlDbType.VarChar, 0, "Nume"),
            new System.Data.SqlClient.SqlParameter("@Prenume", System.Data.SqlDbType.VarChar, 0, "Prenume"),
            new System.Data.SqlClient.SqlParameter("@CNP", System.Data.SqlDbType.Char, 0, "CNP"),
            new System.Data.SqlClient.SqlParameter("@Original_ID_DP", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_DP", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Nume", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Nume", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Nume", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Nume", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Prenume", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Prenume", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Prenume", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Prenume", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_CNP", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CNP", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_CNP", System.Data.SqlDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CNP", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@ID_DP", System.Data.SqlDbType.Int, 4, "ID_DP")});
            // 
            // adresaAdpter
            // 
            this.adresaAdpter.DeleteCommand = this.sqlCommand9;
            this.adresaAdpter.InsertCommand = this.sqlCommand10;
            this.adresaAdpter.SelectCommand = this.sqlCommand11;
            this.adresaAdpter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Adresa", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID_Adresa", "ID_Adresa"),
                        new System.Data.Common.DataColumnMapping("ID_Tara", "ID_Tara"),
                        new System.Data.Common.DataColumnMapping("ID_Judet", "ID_Judet"),
                        new System.Data.Common.DataColumnMapping("Strada", "Strada"),
                        new System.Data.Common.DataColumnMapping("Numar_Strada", "Numar_Strada"),
                        new System.Data.Common.DataColumnMapping("Cod_Postal", "Cod_Postal"),
                        new System.Data.Common.DataColumnMapping("ID_DP", "ID_DP")})});
            this.adresaAdpter.UpdateCommand = this.sqlCommand12;
            // 
            // sqlCommand9
            // 
            this.sqlCommand9.CommandText = resources.GetString("sqlCommand9.CommandText");
            this.sqlCommand9.Connection = this.sqlConnection1;
            this.sqlCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID_Adresa", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Adresa", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Tara", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Tara", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Judet", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Strada", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Strada", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Strada", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Strada", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Numar_Strada", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Numar_Strada", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Numar_Strada", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Numar_Strada", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Cod_Postal", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Cod_Postal", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Cod_Postal", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Cod_Postal", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_DP", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_DP", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand10
            // 
            this.sqlCommand10.CommandText = resources.GetString("sqlCommand10.CommandText");
            this.sqlCommand10.Connection = this.sqlConnection1;
            this.sqlCommand10.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_Tara", System.Data.SqlDbType.Int, 0, "ID_Tara"),
            new System.Data.SqlClient.SqlParameter("@ID_Judet", System.Data.SqlDbType.Int, 0, "ID_Judet"),
            new System.Data.SqlClient.SqlParameter("@Strada", System.Data.SqlDbType.VarChar, 0, "Strada"),
            new System.Data.SqlClient.SqlParameter("@Numar_Strada", System.Data.SqlDbType.Int, 0, "Numar_Strada"),
            new System.Data.SqlClient.SqlParameter("@Cod_Postal", System.Data.SqlDbType.Int, 0, "Cod_Postal"),
            new System.Data.SqlClient.SqlParameter("@ID_DP", System.Data.SqlDbType.Int, 0, "ID_DP")});
            // 
            // sqlCommand11
            // 
            this.sqlCommand11.CommandText = "SELECT     ID_Adresa, ID_Tara, ID_Judet, Strada, Numar_Strada, Cod_Postal, ID_DP\r" +
    "\nFROM         Adresa";
            this.sqlCommand11.Connection = this.sqlConnection1;
            // 
            // sqlCommand12
            // 
            this.sqlCommand12.CommandText = resources.GetString("sqlCommand12.CommandText");
            this.sqlCommand12.Connection = this.sqlConnection1;
            this.sqlCommand12.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_Tara", System.Data.SqlDbType.Int, 0, "ID_Tara"),
            new System.Data.SqlClient.SqlParameter("@ID_Judet", System.Data.SqlDbType.Int, 0, "ID_Judet"),
            new System.Data.SqlClient.SqlParameter("@Strada", System.Data.SqlDbType.VarChar, 0, "Strada"),
            new System.Data.SqlClient.SqlParameter("@Numar_Strada", System.Data.SqlDbType.Int, 0, "Numar_Strada"),
            new System.Data.SqlClient.SqlParameter("@Cod_Postal", System.Data.SqlDbType.Int, 0, "Cod_Postal"),
            new System.Data.SqlClient.SqlParameter("@ID_DP", System.Data.SqlDbType.Int, 0, "ID_DP"),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Adresa", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Adresa", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Tara", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Tara", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Judet", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Strada", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Strada", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Strada", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Strada", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Numar_Strada", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Numar_Strada", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Numar_Strada", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Numar_Strada", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Cod_Postal", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Cod_Postal", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Cod_Postal", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Cod_Postal", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_DP", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_DP", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@ID_Adresa", System.Data.SqlDbType.Int, 4, "ID_Adresa")});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = "SELECT     ID_Tara\r\nFROM         Tara\r\nWHERE     (Tara = @Tara)";
            this.sqlSelectCommand7.Connection = this.sqlConnection1;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Tara", System.Data.SqlDbType.VarChar, 50, "Tara")});
            // 
            // sqlInsertCommand5
            // 
            this.sqlInsertCommand5.CommandText = "INSERT INTO [Tara] ([ID_Tara]) VALUES (@ID_Tara);\r\nSELECT ID_Tara FROM Tara WHERE" +
    " (ID_Tara = @ID_Tara)";
            this.sqlInsertCommand5.Connection = this.sqlConnection1;
            this.sqlInsertCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_Tara", System.Data.SqlDbType.Int, 0, "ID_Tara")});
            // 
            // sqlUpdateCommand5
            // 
            this.sqlUpdateCommand5.CommandText = "UPDATE [Tara] SET [ID_Tara] = @ID_Tara WHERE (([ID_Tara] = @Original_ID_Tara));\r\n" +
    "SELECT ID_Tara FROM Tara WHERE (ID_Tara = @ID_Tara)";
            this.sqlUpdateCommand5.Connection = this.sqlConnection1;
            this.sqlUpdateCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_Tara", System.Data.SqlDbType.Int, 0, "ID_Tara"),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Tara", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Tara", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand5
            // 
            this.sqlDeleteCommand5.CommandText = "DELETE FROM [Tara] WHERE (([ID_Tara] = @Original_ID_Tara))";
            this.sqlDeleteCommand5.Connection = this.sqlConnection1;
            this.sqlDeleteCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID_Tara", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Tara", System.Data.DataRowVersion.Original, null)});
            // 
            // taraByNumeAdapter
            // 
            this.taraByNumeAdapter.DeleteCommand = this.sqlDeleteCommand5;
            this.taraByNumeAdapter.InsertCommand = this.sqlInsertCommand5;
            this.taraByNumeAdapter.SelectCommand = this.sqlSelectCommand7;
            this.taraByNumeAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Tara", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID_Tara", "ID_Tara")})});
            this.taraByNumeAdapter.UpdateCommand = this.sqlUpdateCommand5;
            // 
            // judetByNumeAdapter
            // 
            this.judetByNumeAdapter.DeleteCommand = this.sqlCommand1;
            this.judetByNumeAdapter.InsertCommand = this.sqlCommand4;
            this.judetByNumeAdapter.SelectCommand = this.sqlCommand13;
            this.judetByNumeAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Judet", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID_Judet", "ID_Judet")})});
            this.judetByNumeAdapter.UpdateCommand = this.sqlCommand14;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "DELETE FROM [Judet] WHERE (([ID_Judet] = @Original_ID_Judet))";
            this.sqlCommand1.Connection = this.sqlConnection1;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Judet", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand4
            // 
            this.sqlCommand4.CommandText = "INSERT INTO [Judet] ([ID_Judet]) VALUES (@ID_Judet);\r\nSELECT TOP (1) ID_Judet FRO" +
    "M Judet WHERE (ID_Judet = @ID_Judet)";
            this.sqlCommand4.Connection = this.sqlConnection1;
            this.sqlCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_Judet", System.Data.SqlDbType.Int, 0, "ID_Judet")});
            // 
            // sqlCommand13
            // 
            this.sqlCommand13.CommandText = "SELECT     TOP (1) ID_Judet\r\nFROM         Judet\r\nWHERE     (Judet = @Judet)";
            this.sqlCommand13.Connection = this.sqlConnection1;
            this.sqlCommand13.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Judet", System.Data.SqlDbType.VarChar, 50, "Judet")});
            // 
            // sqlCommand14
            // 
            this.sqlCommand14.CommandText = "UPDATE [Judet] SET [ID_Judet] = @ID_Judet WHERE (([ID_Judet] = @Original_ID_Judet" +
    "));\r\nSELECT TOP (1) ID_Judet FROM Judet WHERE (ID_Judet = @ID_Judet)";
            this.sqlCommand14.Connection = this.sqlConnection1;
            this.sqlCommand14.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_Judet", System.Data.SqlDbType.Int, 0, "ID_Judet"),
            new System.Data.SqlClient.SqlParameter("@Original_ID_Judet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_Judet", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "SELECT     Contact, ID_DP, Contact_ID, Contact_Tip_Id\r\nFROM         Contact\r\nWHER" +
    "E     (ID_DP = @ID_DP)";
            this.sqlSelectCommand3.Connection = this.sqlConnection1;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID_DP", System.Data.SqlDbType.Int, 4, "ID_DP")});
            // 
            // sqlInsertCommand6
            // 
            this.sqlInsertCommand6.CommandText = resources.GetString("sqlInsertCommand6.CommandText");
            this.sqlInsertCommand6.Connection = this.sqlConnection1;
            this.sqlInsertCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Contact", System.Data.SqlDbType.VarChar, 0, "Contact"),
            new System.Data.SqlClient.SqlParameter("@ID_DP", System.Data.SqlDbType.Int, 0, "ID_DP"),
            new System.Data.SqlClient.SqlParameter("@Contact_Tip_Id", System.Data.SqlDbType.Int, 0, "Contact_Tip_Id")});
            // 
            // sqlUpdateCommand6
            // 
            this.sqlUpdateCommand6.CommandText = resources.GetString("sqlUpdateCommand6.CommandText");
            this.sqlUpdateCommand6.Connection = this.sqlConnection1;
            this.sqlUpdateCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Contact", System.Data.SqlDbType.VarChar, 0, "Contact"),
            new System.Data.SqlClient.SqlParameter("@ID_DP", System.Data.SqlDbType.Int, 0, "ID_DP"),
            new System.Data.SqlClient.SqlParameter("@Contact_Tip_Id", System.Data.SqlDbType.Int, 0, "Contact_Tip_Id"),
            new System.Data.SqlClient.SqlParameter("@Original_Contact", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_DP", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_DP", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Contact_Tip_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Contact_Tip_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_Tip_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_Tip_Id", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Contact_ID", System.Data.SqlDbType.Int, 4, "Contact_ID")});
            // 
            // sqlDeleteCommand6
            // 
            this.sqlDeleteCommand6.CommandText = resources.GetString("sqlDeleteCommand6.CommandText");
            this.sqlDeleteCommand6.Connection = this.sqlConnection1;
            this.sqlDeleteCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_Contact", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID_DP", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID_DP", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Contact_Tip_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Contact_Tip_Id", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Contact_Tip_Id", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Contact_Tip_Id", System.Data.DataRowVersion.Original, null)});
            // 
            // editeazaAdapter
            // 
            this.editeazaAdapter.DeleteCommand = this.sqlDeleteCommand6;
            this.editeazaAdapter.InsertCommand = this.sqlInsertCommand6;
            this.editeazaAdapter.SelectCommand = this.sqlSelectCommand3;
            this.editeazaAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Contact", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Contact", "Contact"),
                        new System.Data.Common.DataColumnMapping("ID_DP", "ID_DP"),
                        new System.Data.Common.DataColumnMapping("Contact_ID", "Contact_ID"),
                        new System.Data.Common.DataColumnMapping("Contact_Tip_Id", "Contact_Tip_Id")})});
            this.editeazaAdapter.UpdateCommand = this.sqlUpdateCommand6;

        }
            // 
            // sqlDataAdapter1
            // 
            

        #endregion
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
        private System.Data.SqlClient.SqlDataAdapter taraAdapter;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand4;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand4;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand4;
        private System.Data.SqlClient.SqlDataAdapter judetAdapter;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
        private System.Data.SqlClient.SqlDataAdapter editeazaPersonaleAdapter;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand3;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand3;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand3;
        private System.Data.SqlClient.SqlDataAdapter contactAdapter;
        private System.Data.SqlClient.SqlDataAdapter tip_ContactAdapter;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        private System.Data.SqlClient.SqlCommand sqlCommand3;
        private System.Data.SqlClient.SqlDataAdapter datePersonaleAdapter;
        private System.Data.SqlClient.SqlCommand sqlCommand5;
        private System.Data.SqlClient.SqlCommand sqlCommand6;
        private System.Data.SqlClient.SqlCommand sqlCommand7;
        private System.Data.SqlClient.SqlCommand sqlCommand8;
        private System.Data.SqlClient.SqlDataAdapter adresaAdpter;
        private System.Data.SqlClient.SqlCommand sqlCommand9;
        private System.Data.SqlClient.SqlCommand sqlCommand10;
        private System.Data.SqlClient.SqlCommand sqlCommand11;
        private System.Data.SqlClient.SqlCommand sqlCommand12;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand5;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand5;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand5;
        private System.Data.SqlClient.SqlDataAdapter taraByNumeAdapter;
        private System.Data.SqlClient.SqlDataAdapter judetByNumeAdapter;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlCommand sqlCommand4;
        private System.Data.SqlClient.SqlCommand sqlCommand13;
        private System.Data.SqlClient.SqlCommand sqlCommand14;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand6;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand6;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand6;
        private System.Data.SqlClient.SqlDataAdapter editeazaAdapter;
    }
}
