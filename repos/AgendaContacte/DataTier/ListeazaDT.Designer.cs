﻿
namespace DataTier
{
    partial class ListeazaDT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListeazaDT));
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.listeazaAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.taraAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
            this.judetAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand4 = new System.Data.SqlClient.SqlCommand();
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // listeazaAdapter
            // 
            this.listeazaAdapter.SelectCommand = this.sqlSelectCommand1;
            this.listeazaAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "DatePersonale", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Nume", "Nume"),
                        new System.Data.Common.DataColumnMapping("Prenume", "Prenume"),
                        new System.Data.Common.DataColumnMapping("CNP", "CNP"),
                        new System.Data.Common.DataColumnMapping("ID_DP", "ID_DP"),
                        new System.Data.Common.DataColumnMapping("Judet", "Judet"),
                        new System.Data.Common.DataColumnMapping("Tara", "Tara")})});
            this.listeazaAdapter.RowUpdated += new System.Data.SqlClient.SqlRowUpdatedEventHandler(this.sqlDataAdapter1_RowUpdated);
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=GS0022\\SQL2019;Initial Catalog=Agenda_Personala;Persist Security Info" +
    "=True;User ID=sa;Password=1234";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
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
            // sqlInsertCommand2
            // 
            this.sqlInsertCommand2.CommandText = "INSERT INTO [Tara] ([Tara], [ID_Tara]) VALUES (@Tara, @ID_Tara);\r\nSELECT Tara, ID" +
    "_Tara FROM Tara WHERE (ID_Tara = @ID_Tara)";
            this.sqlInsertCommand2.Connection = this.sqlConnection1;
            this.sqlInsertCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Tara", System.Data.SqlDbType.VarChar, 0, "Tara"),
            new System.Data.SqlClient.SqlParameter("@ID_Tara", System.Data.SqlDbType.Int, 0, "ID_Tara")});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "SELECT Tara, ID_Tara FROM Tara";
            this.sqlSelectCommand2.Connection = this.sqlConnection1;
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
            // sqlInsertCommand4
            // 
            this.sqlInsertCommand4.CommandText = "INSERT INTO [Judet] ([Judet], [ID_Judet]) VALUES (@Judet, @ID_Judet);\r\nSELECT Jud" +
    "et, ID_Judet FROM Judet WHERE (ID_Judet = @ID_Judet)";
            this.sqlInsertCommand4.Connection = this.sqlConnection1;
            this.sqlInsertCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Judet", System.Data.SqlDbType.VarChar, 0, "Judet"),
            new System.Data.SqlClient.SqlParameter("@ID_Judet", System.Data.SqlDbType.Int, 0, "ID_Judet")});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "SELECT     Judet, ID_Judet\r\nFROM         Judet";
            this.sqlSelectCommand4.Connection = this.sqlConnection1;
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

        }

        #endregion

        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlDataAdapter listeazaAdapter;
        private System.Data.SqlClient.SqlDataAdapter taraAdapter;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
        private System.Data.SqlClient.SqlDataAdapter judetAdapter;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand4;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand4;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand4;
    }
}
