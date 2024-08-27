namespace Common_DT.GUI
{
    partial class ComenziDataSvc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComenziDataSvc));
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlDataAdapter_GetHome = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetComandaBase = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetComandaDet = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_DetaliiComanda = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetLot = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_getReceptii = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblReceptieComandaDet = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_getProduseComandate = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetNirComanda = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand10 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblReceptieComenziBase = new System.Data.SqlClient.SqlDataAdapter();
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "dbo.usp_GetComenziHome";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@pCentruID", System.Data.SqlDbType.UniqueIdentifier, 16),
            new System.Data.SqlClient.SqlParameter("@pDataLucru", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=GS0010\\SQL2008R2;Initial Catalog=GS_Comenzi;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlDataAdapter_GetHome
            // 
            this.sqlDataAdapter_GetHome.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter_GetHome.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblProduse", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("LotID", "LotID"),
                        new System.Data.Common.DataColumnMapping("Data", "Data"),
                        new System.Data.Common.DataColumnMapping("Denumire", "Denumire"),
                        new System.Data.Common.DataColumnMapping("CodProdus", "CodProdus"),
                        new System.Data.Common.DataColumnMapping("DenumireProdus", "DenumireProdus"),
                        new System.Data.Common.DataColumnMapping("CantitateDistribuita", "CantitateDistribuita"),
                        new System.Data.Common.DataColumnMapping("CantitateComandata", "CantitateComandata"),
                        new System.Data.Common.DataColumnMapping("CantitateDisponibilaLot", "CantitateDisponibilaLot"),
                        new System.Data.Common.DataColumnMapping("CantitateReceptionata", "CantitateReceptionata"),
                        new System.Data.Common.DataColumnMapping("CantitateDispComanda", "CantitateDispComanda"),
                        new System.Data.Common.DataColumnMapping("Pret", "Pret"),
                        new System.Data.Common.DataColumnMapping("Valoare", "Valoare"),
                        new System.Data.Common.DataColumnMapping("ValoareTVA", "ValoareTVA"),
                        new System.Data.Common.DataColumnMapping("ValoareCuTVA", "ValoareCuTVA")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "SELECT        ID, LotID, Data, CentruID\r\nFROM            tblComandaBase\r\nwhere ID" +
    " = @pComandaBaseID";
            this.sqlSelectCommand2.Connection = this.sqlConnection1;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID")});
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = "INSERT INTO [tblComandaBase] ([ID], [LotID], [Data], [CentruID]) VALUES (@ID, @Lo" +
    "tID, @Data, @CentruID);\r\nSELECT ID, LotID, Data, CentruID FROM tblComandaBase WH" +
    "ERE (ID = @ID)";
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@LotID", System.Data.SqlDbType.UniqueIdentifier, 0, "LotID"),
            new System.Data.SqlClient.SqlParameter("@Data", System.Data.SqlDbType.DateTime, 0, "Data"),
            new System.Data.SqlClient.SqlParameter("@CentruID", System.Data.SqlDbType.UniqueIdentifier, 0, "CentruID")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Connection = this.sqlConnection1;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@LotID", System.Data.SqlDbType.UniqueIdentifier, 0, "LotID"),
            new System.Data.SqlClient.SqlParameter("@Data", System.Data.SqlDbType.DateTime, 0, "Data"),
            new System.Data.SqlClient.SqlParameter("@CentruID", System.Data.SqlDbType.UniqueIdentifier, 0, "CentruID"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_LotID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LotID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Data", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Data", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_CentruID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CentruID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM [tblComandaBase] WHERE (([ID] = @Original_ID) AND ([LotID] = @Origina" +
    "l_LotID) AND ([Data] = @Original_Data) AND ([CentruID] = @Original_CentruID))";
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_LotID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LotID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Data", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Data", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_CentruID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CentruID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetComandaBase
            // 
            this.sqlDataAdapter_GetComandaBase.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter_GetComandaBase.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter_GetComandaBase.SelectCommand = this.sqlSelectCommand2;
            this.sqlDataAdapter_GetComandaBase.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblComandaBase", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("LotID", "LotID"),
                        new System.Data.Common.DataColumnMapping("Data", "Data"),
                        new System.Data.Common.DataColumnMapping("CentruID", "CentruID")})});
            this.sqlDataAdapter_GetComandaBase.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "SELECT        ID, ComandaBaseID, ProduseID, Cantitate, Valoare, ValoareTVA\r\nFROM " +
    "           tblComandaDet\r\nwhere comandabaseid= @pComandaBaseID";
            this.sqlSelectCommand3.Connection = this.sqlConnection1;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 16, "ComandaBaseID")});
            // 
            // sqlUpdateCommand2
            // 
            this.sqlUpdateCommand2.CommandText = resources.GetString("sqlUpdateCommand2.CommandText");
            this.sqlUpdateCommand2.Connection = this.sqlConnection1;
            this.sqlUpdateCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@ComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ComandaBaseID"),
            new System.Data.SqlClient.SqlParameter("@ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ProduseID"),
            new System.Data.SqlClient.SqlParameter("@Cantitate", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Cantitate", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Valoare", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Valoare", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@ValoareTVA", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "ValoareTVA", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ComandaBaseID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProduseID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Cantitate", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Cantitate", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Valoare", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Valoare", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ValoareTVA", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "ValoareTVA", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand2
            // 
            this.sqlDeleteCommand2.CommandText = resources.GetString("sqlDeleteCommand2.CommandText");
            this.sqlDeleteCommand2.Connection = this.sqlConnection1;
            this.sqlDeleteCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ComandaBaseID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProduseID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Cantitate", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Cantitate", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Valoare", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Valoare", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ValoareTVA", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "ValoareTVA", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetComandaDet
            // 
            this.sqlDataAdapter_GetComandaDet.DeleteCommand = this.sqlDeleteCommand2;
            this.sqlDataAdapter_GetComandaDet.InsertCommand = this.sqlInsertCommand;
            this.sqlDataAdapter_GetComandaDet.SelectCommand = this.sqlSelectCommand3;
            this.sqlDataAdapter_GetComandaDet.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblComandaDet", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("ComandaBaseID", "ComandaBaseID"),
                        new System.Data.Common.DataColumnMapping("ProduseID", "ProduseID"),
                        new System.Data.Common.DataColumnMapping("Cantitate", "Cantitate"),
                        new System.Data.Common.DataColumnMapping("Valoare", "Valoare"),
                        new System.Data.Common.DataColumnMapping("ValoareTVA", "ValoareTVA")})});
            this.sqlDataAdapter_GetComandaDet.UpdateCommand = this.sqlUpdateCommand2;
            // 
            // sqlInsertCommand
            // 
            this.sqlInsertCommand.CommandText = resources.GetString("sqlInsertCommand.CommandText");
            this.sqlInsertCommand.Connection = this.sqlConnection1;
            this.sqlInsertCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@ComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ComandaBaseID"),
            new System.Data.SqlClient.SqlParameter("@ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ProduseID"),
            new System.Data.SqlClient.SqlParameter("@Cantitate", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Cantitate", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Valoare", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Valoare", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@ValoareTVA", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "ValoareTVA", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = resources.GetString("sqlSelectCommand4.CommandText");
            this.sqlSelectCommand4.Connection = this.sqlConnection1;
            this.sqlSelectCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pLotBaseID", System.Data.SqlDbType.UniqueIdentifier, 16, "LotBaseID"),
            new System.Data.SqlClient.SqlParameter("@pCentruID", System.Data.SqlDbType.UniqueIdentifier, 16),
            new System.Data.SqlClient.SqlParameter("@pComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID")});
            // 
            // sqlDataAdapter_DetaliiComanda
            // 
            this.sqlDataAdapter_DetaliiComanda.SelectCommand = this.sqlSelectCommand4;
            this.sqlDataAdapter_DetaliiComanda.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblDistribuireLotDet", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("LotBaseID", "LotBaseID"),
                        new System.Data.Common.DataColumnMapping("CodProdus", "CodProdus"),
                        new System.Data.Common.DataColumnMapping("Denumire", "Denumire"),
                        new System.Data.Common.DataColumnMapping("ProduseID", "ProduseID"),
                        new System.Data.Common.DataColumnMapping("CotaTVAID", "CotaTVAID"),
                        new System.Data.Common.DataColumnMapping("Cantitate", "Cantitate"),
                        new System.Data.Common.DataColumnMapping("Pret", "Pret"),
                        new System.Data.Common.DataColumnMapping("CantitateComandata", "CantitateComandata"),
                        new System.Data.Common.DataColumnMapping("CantitateDistribuita", "CantitateDistribuita")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = resources.GetString("sqlSelectCommand5.CommandText");
            this.sqlSelectCommand5.Connection = this.sqlConnection1;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pDataLucru", System.Data.SqlDbType.DateTime, 8, "DataStop"),
            new System.Data.SqlClient.SqlParameter("@pCentruID", System.Data.SqlDbType.UniqueIdentifier, 16)});
            // 
            // sqlInsertCommand2
            // 
            this.sqlInsertCommand2.CommandText = resources.GetString("sqlInsertCommand2.CommandText");
            this.sqlInsertCommand2.Connection = this.sqlConnection1;
            this.sqlInsertCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Denumire", System.Data.SqlDbType.NVarChar, 0, "Denumire"),
            new System.Data.SqlClient.SqlParameter("@CodCPVID", System.Data.SqlDbType.UniqueIdentifier, 0, "CodCPVID"),
            new System.Data.SqlClient.SqlParameter("@PartenerID", System.Data.SqlDbType.UniqueIdentifier, 0, "PartenerID"),
            new System.Data.SqlClient.SqlParameter("@Data", System.Data.SqlDbType.DateTime, 0, "Data")});
            // 
            // sqlUpdateCommand3
            // 
            this.sqlUpdateCommand3.CommandText = resources.GetString("sqlUpdateCommand3.CommandText");
            this.sqlUpdateCommand3.Connection = this.sqlConnection1;
            this.sqlUpdateCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Denumire", System.Data.SqlDbType.NVarChar, 0, "Denumire"),
            new System.Data.SqlClient.SqlParameter("@CodCPVID", System.Data.SqlDbType.UniqueIdentifier, 0, "CodCPVID"),
            new System.Data.SqlClient.SqlParameter("@PartenerID", System.Data.SqlDbType.UniqueIdentifier, 0, "PartenerID"),
            new System.Data.SqlClient.SqlParameter("@Data", System.Data.SqlDbType.DateTime, 0, "Data"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Denumire", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Denumire", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_CodCPVID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CodCPVID", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_CodCPVID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CodCPVID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_PartenerID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PartenerID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Data", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Data", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand3
            // 
            this.sqlDeleteCommand3.CommandText = resources.GetString("sqlDeleteCommand3.CommandText");
            this.sqlDeleteCommand3.Connection = this.sqlConnection1;
            this.sqlDeleteCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Denumire", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Denumire", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_CodCPVID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CodCPVID", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_CodCPVID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CodCPVID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_PartenerID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PartenerID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Data", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Data", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetLot
            // 
            this.sqlDataAdapter_GetLot.DeleteCommand = this.sqlDeleteCommand3;
            this.sqlDataAdapter_GetLot.InsertCommand = this.sqlInsertCommand2;
            this.sqlDataAdapter_GetLot.SelectCommand = this.sqlSelectCommand5;
            this.sqlDataAdapter_GetLot.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblLotBase", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Denumire", "Denumire"),
                        new System.Data.Common.DataColumnMapping("CodCPVID", "CodCPVID"),
                        new System.Data.Common.DataColumnMapping("PartenerID", "PartenerID"),
                        new System.Data.Common.DataColumnMapping("Data", "Data")})});
            this.sqlDataAdapter_GetLot.UpdateCommand = this.sqlUpdateCommand3;
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = resources.GetString("sqlSelectCommand6.CommandText");
            this.sqlSelectCommand6.Connection = this.sqlConnection1;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 16, "ComandaBaseID")});
            // 
            // sqlDataAdapter_getReceptii
            // 
            this.sqlDataAdapter_getReceptii.SelectCommand = this.sqlSelectCommand6;
            this.sqlDataAdapter_getReceptii.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblComandaDet", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ComandaBaseID", "ComandaBaseID"),
                        new System.Data.Common.DataColumnMapping("Cod", "Cod"),
                        new System.Data.Common.DataColumnMapping("Denumire", "Denumire"),
                        new System.Data.Common.DataColumnMapping("ProduseID", "ProduseID"),
                        new System.Data.Common.DataColumnMapping("CotaTVAID", "CotaTVAID"),
                        new System.Data.Common.DataColumnMapping("Cantitate", "Cantitate"),
                        new System.Data.Common.DataColumnMapping("CantitateReceptionata", "CantitateReceptionata"),
                        new System.Data.Common.DataColumnMapping("CantitateRec", "CantitateRec"),
                        new System.Data.Common.DataColumnMapping("CantitateDisponibila", "CantitateDisponibila"),
                        new System.Data.Common.DataColumnMapping("Pret", "Pret"),
                        new System.Data.Common.DataColumnMapping("Valoare", "Valoare"),
                        new System.Data.Common.DataColumnMapping("ValoareTVA", "ValoareTVA"),
                        new System.Data.Common.DataColumnMapping("ValoareCuTVA", "ValoareCuTVA")})});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = "SELECT        ID, ReceptieComandaBaseID, ProduseID, CantitateReceptionata\r\nFROM  " +
    "          tblReceptieComandaDet";
            this.sqlSelectCommand7.Connection = this.sqlConnection1;
            // 
            // sqlInsertCommand3
            // 
            this.sqlInsertCommand3.CommandText = resources.GetString("sqlInsertCommand3.CommandText");
            this.sqlInsertCommand3.Connection = this.sqlConnection1;
            this.sqlInsertCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@ReceptieComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ReceptieComandaBaseID"),
            new System.Data.SqlClient.SqlParameter("@ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ProduseID"),
            new System.Data.SqlClient.SqlParameter("@CantitateReceptionata", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "CantitateReceptionata", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlUpdateCommand4
            // 
            this.sqlUpdateCommand4.CommandText = resources.GetString("sqlUpdateCommand4.CommandText");
            this.sqlUpdateCommand4.Connection = this.sqlConnection1;
            this.sqlUpdateCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@ReceptieComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ReceptieComandaBaseID"),
            new System.Data.SqlClient.SqlParameter("@ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ProduseID"),
            new System.Data.SqlClient.SqlParameter("@CantitateReceptionata", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "CantitateReceptionata", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ReceptieComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ReceptieComandaBaseID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProduseID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_CantitateReceptionata", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "CantitateReceptionata", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand4
            // 
            this.sqlDeleteCommand4.CommandText = resources.GetString("sqlDeleteCommand4.CommandText");
            this.sqlDeleteCommand4.Connection = this.sqlConnection1;
            this.sqlDeleteCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ReceptieComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ReceptieComandaBaseID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProduseID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_CantitateReceptionata", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "CantitateReceptionata", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_tblReceptieComandaDet
            // 
            this.sqlDataAdapter_tblReceptieComandaDet.DeleteCommand = this.sqlDeleteCommand4;
            this.sqlDataAdapter_tblReceptieComandaDet.InsertCommand = this.sqlInsertCommand3;
            this.sqlDataAdapter_tblReceptieComandaDet.SelectCommand = this.sqlSelectCommand7;
            this.sqlDataAdapter_tblReceptieComandaDet.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblReceptieComandaDet", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("ReceptieComandaBaseID", "ReceptieComandaBaseID"),
                        new System.Data.Common.DataColumnMapping("ProduseID", "ProduseID"),
                        new System.Data.Common.DataColumnMapping("CantitateReceptionata", "CantitateReceptionata")})});
            this.sqlDataAdapter_tblReceptieComandaDet.UpdateCommand = this.sqlUpdateCommand4;
            // 
            // sqlSelectCommand8
            // 
            this.sqlSelectCommand8.CommandText = resources.GetString("sqlSelectCommand8.CommandText");
            this.sqlSelectCommand8.Connection = this.sqlConnection1;
            this.sqlSelectCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pCentruID", System.Data.SqlDbType.UniqueIdentifier, 16)});
            // 
            // sqlDataAdapter_getProduseComandate
            // 
            this.sqlDataAdapter_getProduseComandate.SelectCommand = this.sqlSelectCommand8;
            this.sqlDataAdapter_getProduseComandate.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblComandaDet", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ProduseID", "ProduseID")})});
            // 
            // sqlSelectCommand9
            // 
            this.sqlSelectCommand9.CommandText = "SELECT DISTINCT\r\n        NumarNir ,\r\n        DataReceptie\r\nFROM    dbo.tblRecepti" +
    "eComanda\r\nWHERE   ComandaBaseID = @pComandaBaseID";
            this.sqlSelectCommand9.Connection = this.sqlConnection1;
            this.sqlSelectCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 16, "ComandaBaseID")});
            // 
            // sqlDataAdapter_GetNirComanda
            // 
            this.sqlDataAdapter_GetNirComanda.SelectCommand = this.sqlSelectCommand9;
            this.sqlDataAdapter_GetNirComanda.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblReceptieComanda", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("NumarNir", "NumarNir"),
                        new System.Data.Common.DataColumnMapping("DataReceptie", "DataReceptie")})});
            // 
            // sqlSelectCommand10
            // 
            this.sqlSelectCommand10.CommandText = "SELECT        ID, NumarFactura, NumarNir, DataReceptie, ComandaBaseID\r\nFROM      " +
    "      tblReceptieComandaBase";
            this.sqlSelectCommand10.Connection = this.sqlConnection1;
            // 
            // sqlInsertCommand4
            // 
            this.sqlInsertCommand4.CommandText = resources.GetString("sqlInsertCommand4.CommandText");
            this.sqlInsertCommand4.Connection = this.sqlConnection1;
            this.sqlInsertCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@NumarFactura", System.Data.SqlDbType.NVarChar, 0, "NumarFactura"),
            new System.Data.SqlClient.SqlParameter("@NumarNir", System.Data.SqlDbType.NVarChar, 0, "NumarNir"),
            new System.Data.SqlClient.SqlParameter("@DataReceptie", System.Data.SqlDbType.DateTime, 0, "DataReceptie"),
            new System.Data.SqlClient.SqlParameter("@ComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ComandaBaseID")});
            // 
            // sqlUpdateCommand5
            // 
            this.sqlUpdateCommand5.CommandText = resources.GetString("sqlUpdateCommand5.CommandText");
            this.sqlUpdateCommand5.Connection = this.sqlConnection1;
            this.sqlUpdateCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
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
            // sqlDeleteCommand5
            // 
            this.sqlDeleteCommand5.CommandText = resources.GetString("sqlDeleteCommand5.CommandText");
            this.sqlDeleteCommand5.Connection = this.sqlConnection1;
            this.sqlDeleteCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NumarFactura", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumarFactura", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_NumarNir", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NumarNir", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DataReceptie", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataReceptie", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ComandaBaseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ComandaBaseID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_tblReceptieComenziBase
            // 
            this.sqlDataAdapter_tblReceptieComenziBase.DeleteCommand = this.sqlDeleteCommand5;
            this.sqlDataAdapter_tblReceptieComenziBase.InsertCommand = this.sqlInsertCommand4;
            this.sqlDataAdapter_tblReceptieComenziBase.SelectCommand = this.sqlSelectCommand10;
            this.sqlDataAdapter_tblReceptieComenziBase.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblReceptieComandaBase", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("NumarFactura", "NumarFactura"),
                        new System.Data.Common.DataColumnMapping("NumarNir", "NumarNir"),
                        new System.Data.Common.DataColumnMapping("DataReceptie", "DataReceptie"),
                        new System.Data.Common.DataColumnMapping("ComandaBaseID", "ComandaBaseID")})});
            this.sqlDataAdapter_tblReceptieComenziBase.UpdateCommand = this.sqlUpdateCommand5;

        }

        #endregion

        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetHome;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetComandaBase;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetComandaDet;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_DetaliiComanda;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand3;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand3;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetLot;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_getReceptii;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand3;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand4;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand4;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblReceptieComandaDet;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_getProduseComandate;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand9;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetNirComanda;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand10;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand4;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand5;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand5;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblReceptieComenziBase;
    }
}
