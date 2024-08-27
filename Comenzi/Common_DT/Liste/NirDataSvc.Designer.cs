namespace Common_DT.Liste
{
    partial class NirDataSvc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NirDataSvc));
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetNirByComanda = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblDateNir = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetPersoane = new System.Data.SqlClient.SqlDataAdapter();
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT        ID, NumarFactura, NumarNir, DataReceptie, ComandaBaseID, 0 as Lista" +
    "re \r\nFROM            tblReceptieComandaBase \r\nWHERE        (ComandaBaseID = @pCo" +
    "mandaBaseID)";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 16, "ComandaBaseID")});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=GS0010\\SQL2008R2;Initial Catalog=GS_Comenzi;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@NumarFactura", System.Data.SqlDbType.NVarChar, 0, "NumarFactura"),
            new System.Data.SqlClient.SqlParameter("@NumarNir", System.Data.SqlDbType.NVarChar, 0, "NumarNir"),
            new System.Data.SqlClient.SqlParameter("@DataReceptie", System.Data.SqlDbType.DateTime, 0, "DataReceptie"),
            new System.Data.SqlClient.SqlParameter("@ComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ComandaBaseID")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Connection = this.sqlConnection1;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@NumarFactura", System.Data.SqlDbType.NVarChar, 0, "NumarFactura"),
            new System.Data.SqlClient.SqlParameter("@NumarNir", System.Data.SqlDbType.NVarChar, 0, "NumarNir"),
            new System.Data.SqlClient.SqlParameter("@DataReceptie", System.Data.SqlDbType.DateTime, 0, "DataReceptie"),
            new System.Data.SqlClient.SqlParameter("@ComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ComandaBaseID"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NumarFactura", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumarFactura", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NumarNir", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumarNir", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DataReceptie", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataReceptie", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ComandaBaseID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = resources.GetString("sqlDeleteCommand1.CommandText");
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NumarFactura", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumarFactura", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NumarNir", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumarNir", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DataReceptie", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataReceptie", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ComandaBaseID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetNirByComanda
            // 
            this.sqlDataAdapter_GetNirByComanda.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter_GetNirByComanda.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter_GetNirByComanda.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter_GetNirByComanda.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblReceptieComandaBase", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("NumarFactura", "NumarFactura"),
                        new System.Data.Common.DataColumnMapping("NumarNir", "NumarNir"),
                        new System.Data.Common.DataColumnMapping("DataReceptie", "DataReceptie"),
                        new System.Data.Common.DataColumnMapping("ComandaBaseID", "ComandaBaseID"),
                        new System.Data.Common.DataColumnMapping("Listare", "Listare")})});
            this.sqlDataAdapter_GetNirByComanda.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = resources.GetString("sqlSelectCommand2.CommandText");
            this.sqlSelectCommand2.Connection = this.sqlConnection1;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pReceptieBaseID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID")});
            // 
            // sqlDataAdapter_tblDateNir
            // 
            this.sqlDataAdapter_tblDateNir.SelectCommand = this.sqlSelectCommand2;
            this.sqlDataAdapter_tblDateNir.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblProduse", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("NumarNir", "NumarNir"),
                        new System.Data.Common.DataColumnMapping("NumarFactura", "NumarFactura"),
                        new System.Data.Common.DataColumnMapping("DenumireCentru", "DenumireCentru"),
                        new System.Data.Common.DataColumnMapping("CodCentru", "CodCentru"),
                        new System.Data.Common.DataColumnMapping("DataReceptie", "DataReceptie"),
                        new System.Data.Common.DataColumnMapping("AnReceptie", "AnReceptie"),
                        new System.Data.Common.DataColumnMapping("LunaReceptie", "LunaReceptie"),
                        new System.Data.Common.DataColumnMapping("ZiReceptie", "ZiReceptie"),
                        new System.Data.Common.DataColumnMapping("CodPartener", "CodPartener"),
                        new System.Data.Common.DataColumnMapping("DenumirePartener", "DenumirePartener"),
                        new System.Data.Common.DataColumnMapping("CodProdus", "CodProdus"),
                        new System.Data.Common.DataColumnMapping("DenumireProdus", "DenumireProdus"),
                        new System.Data.Common.DataColumnMapping("UM", "UM"),
                        new System.Data.Common.DataColumnMapping("CantitateReceptionata", "CantitateReceptionata"),
                        new System.Data.Common.DataColumnMapping("Pret", "Pret"),
                        new System.Data.Common.DataColumnMapping("CantitateAdaos", "CantitateAdaos"),
                        new System.Data.Common.DataColumnMapping("TotalAdaos", "TotalAdaos"),
                        new System.Data.Common.DataColumnMapping("PretUnitar", "PretUnitar"),
                        new System.Data.Common.DataColumnMapping("TvaPret", "TvaPret"),
                        new System.Data.Common.DataColumnMapping("TvaTotal", "TvaTotal"),
                        new System.Data.Common.DataColumnMapping("PretCuTva", "PretCuTva"),
                        new System.Data.Common.DataColumnMapping("ValoareCuTva", "ValoareCuTva"),
                        new System.Data.Common.DataColumnMapping("Valoare", "Valoare")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = resources.GetString("sqlSelectCommand3.CommandText");
            this.sqlSelectCommand3.Connection = this.sqlConnection1;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pCentruID", System.Data.SqlDbType.UniqueIdentifier, 16, "CentruID")});
            // 
            // sqlDataAdapter_GetPersoane
            // 
            this.sqlDataAdapter_GetPersoane.SelectCommand = this.sqlSelectCommand3;
            this.sqlDataAdapter_GetPersoane.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tbxTipPersoana", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Persoana", "Persoana"),
                        new System.Data.Common.DataColumnMapping("CodIntern", "CodIntern"),
                        new System.Data.Common.DataColumnMapping("ID", "ID")})});

        }

        #endregion

        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetNirByComanda;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblDateNir;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetPersoane;
    }
}
