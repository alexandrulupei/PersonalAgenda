﻿namespace Common_DT.GUI
{
    partial class AcordCadruDataSvc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcordCadruDataSvc));
            this.sqlDataAdapter_tblAcordCadru = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tblAcordCadruDet = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetCodCPV = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetProduse = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetPartener = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_tbxTipCentru = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter_GetHome = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand11 = new System.Data.SqlClient.SqlCommand();
            // 
            // sqlDataAdapter_tblAcordCadru
            // 
            this.sqlDataAdapter_tblAcordCadru.DeleteCommand = this.sqlDeleteCommand2;
            this.sqlDataAdapter_tblAcordCadru.InsertCommand = this.sqlInsertCommand2;
            this.sqlDataAdapter_tblAcordCadru.SelectCommand = this.sqlSelectCommand2;
            this.sqlDataAdapter_tblAcordCadru.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblAcordCadru", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Denumire", "Denumire"),
                        new System.Data.Common.DataColumnMapping("PartenerID", "PartenerID"),
                        new System.Data.Common.DataColumnMapping("DataStart", "DataStart"),
                        new System.Data.Common.DataColumnMapping("DataStop", "DataStop"),
                        new System.Data.Common.DataColumnMapping("TipCentruID", "TipCentruID")})});
            this.sqlDataAdapter_tblAcordCadru.UpdateCommand = this.sqlUpdateCommand2;
            // 
            // sqlDeleteCommand2
            // 
            this.sqlDeleteCommand2.CommandText = resources.GetString("sqlDeleteCommand2.CommandText");
            this.sqlDeleteCommand2.Connection = this.sqlConnection1;
            this.sqlDeleteCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Denumire", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Denumire", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_PartenerID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PartenerID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DataStart", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataStart", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DataStop", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataStop", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_TipCentruID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TipCentruID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=GS0010\\SQL2008R2;Initial Catalog=GS_Comenzi;Integrated Security=True";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand2
            // 
            this.sqlInsertCommand2.CommandText = resources.GetString("sqlInsertCommand2.CommandText");
            this.sqlInsertCommand2.Connection = this.sqlConnection1;
            this.sqlInsertCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Denumire", System.Data.SqlDbType.NVarChar, 0, "Denumire"),
            new System.Data.SqlClient.SqlParameter("@PartenerID", System.Data.SqlDbType.UniqueIdentifier, 0, "PartenerID"),
            new System.Data.SqlClient.SqlParameter("@DataStart", System.Data.SqlDbType.DateTime, 0, "DataStart"),
            new System.Data.SqlClient.SqlParameter("@DataStop", System.Data.SqlDbType.DateTime, 0, "DataStop"),
            new System.Data.SqlClient.SqlParameter("@TipCentruID", System.Data.SqlDbType.UniqueIdentifier, 0, "TipCentruID")});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "SELECT        ID, Denumire, PartenerID, DataStart, DataStop, TipCentruID\r\nFROM   " +
    "         tblAcordCadru\r\nwhere id=@pID";
            this.sqlSelectCommand2.Connection = this.sqlConnection1;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID")});
            // 
            // sqlUpdateCommand2
            // 
            this.sqlUpdateCommand2.CommandText = resources.GetString("sqlUpdateCommand2.CommandText");
            this.sqlUpdateCommand2.Connection = this.sqlConnection1;
            this.sqlUpdateCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Denumire", System.Data.SqlDbType.NVarChar, 0, "Denumire"),
            new System.Data.SqlClient.SqlParameter("@PartenerID", System.Data.SqlDbType.UniqueIdentifier, 0, "PartenerID"),
            new System.Data.SqlClient.SqlParameter("@DataStart", System.Data.SqlDbType.DateTime, 0, "DataStart"),
            new System.Data.SqlClient.SqlParameter("@DataStop", System.Data.SqlDbType.DateTime, 0, "DataStop"),
            new System.Data.SqlClient.SqlParameter("@TipCentruID", System.Data.SqlDbType.UniqueIdentifier, 0, "TipCentruID"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Denumire", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Denumire", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_PartenerID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PartenerID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DataStart", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataStart", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DataStop", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DataStop", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_TipCentruID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TipCentruID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_tblAcordCadruDet
            // 
            this.sqlDataAdapter_tblAcordCadruDet.DeleteCommand = this.sqlCommand1;
            this.sqlDataAdapter_tblAcordCadruDet.InsertCommand = this.sqlCommand2;
            this.sqlDataAdapter_tblAcordCadruDet.SelectCommand = this.sqlCommand3;
            this.sqlDataAdapter_tblAcordCadruDet.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblAcordCadruDet", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("AcordCadruID", "AcordCadruID"),
                        new System.Data.Common.DataColumnMapping("ProduseID", "ProduseID"),
                        new System.Data.Common.DataColumnMapping("Cantitate", "Cantitate"),
                        new System.Data.Common.DataColumnMapping("Valoare", "Valoare"),
                        new System.Data.Common.DataColumnMapping("ValoareTVA", "ValoareTVA"),
                        new System.Data.Common.DataColumnMapping("ValoareCuTva", "ValoareCuTva"),
                        new System.Data.Common.DataColumnMapping("Pret", "Pret"),
                        new System.Data.Common.DataColumnMapping("CotaTVAID", "CotaTVAID")})});
            this.sqlDataAdapter_tblAcordCadruDet.UpdateCommand = this.sqlCommand4;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = resources.GetString("sqlCommand1.CommandText");
            this.sqlCommand1.Connection = this.sqlConnection1;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AcordCadruID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AcordCadruID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProduseID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Cantitate", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Cantitate", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Valoare", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Valoare", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ValoareTVA", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "ValoareTVA", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = resources.GetString("sqlCommand2.CommandText");
            this.sqlCommand2.Connection = this.sqlConnection1;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@AcordCadruID", System.Data.SqlDbType.UniqueIdentifier, 0, "AcordCadruID"),
            new System.Data.SqlClient.SqlParameter("@ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ProduseID"),
            new System.Data.SqlClient.SqlParameter("@Cantitate", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Cantitate", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Valoare", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Valoare", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@ValoareTVA", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "ValoareTVA", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = resources.GetString("sqlCommand3.CommandText");
            this.sqlCommand3.Connection = this.sqlConnection1;
            this.sqlCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pID", System.Data.SqlDbType.UniqueIdentifier, 16, "AcordCadruID")});
            // 
            // sqlCommand4
            // 
            this.sqlCommand4.CommandText = resources.GetString("sqlCommand4.CommandText");
            this.sqlCommand4.Connection = this.sqlConnection1;
            this.sqlCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@AcordCadruID", System.Data.SqlDbType.UniqueIdentifier, 0, "AcordCadruID"),
            new System.Data.SqlClient.SqlParameter("@ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, "ProduseID"),
            new System.Data.SqlClient.SqlParameter("@Cantitate", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Cantitate", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Valoare", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Valoare", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@ValoareTVA", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "ValoareTVA", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_AcordCadruID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AcordCadruID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ProduseID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProduseID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Cantitate", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Cantitate", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Valoare", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Valoare", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_ValoareTVA", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "ValoareTVA", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetCodCPV
            // 
            this.sqlDataAdapter_GetCodCPV.DeleteCommand = this.sqlDeleteCommand5;
            this.sqlDataAdapter_GetCodCPV.InsertCommand = this.sqlInsertCommand4;
            this.sqlDataAdapter_GetCodCPV.SelectCommand = this.sqlSelectCommand6;
            this.sqlDataAdapter_GetCodCPV.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblCPVCodes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Cod", "Cod"),
                        new System.Data.Common.DataColumnMapping("DescriereRO", "DescriereRO"),
                        new System.Data.Common.DataColumnMapping("DescriereEN", "DescriereEN"),
                        new System.Data.Common.DataColumnMapping("EffectiveDate", "EffectiveDate"),
                        new System.Data.Common.DataColumnMapping("IsActive", "IsActive"),
                        new System.Data.Common.DataColumnMapping("ExpirationDate", "ExpirationDate")})});
            this.sqlDataAdapter_GetCodCPV.UpdateCommand = this.sqlUpdateCommand5;
            // 
            // sqlDeleteCommand5
            // 
            this.sqlDeleteCommand5.CommandText = resources.GetString("sqlDeleteCommand5.CommandText");
            this.sqlDeleteCommand5.Connection = this.sqlConnection1;
            this.sqlDeleteCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Cod", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Cod", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DescriereRO", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DescriereRO", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DescriereRO", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DescriereRO", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DescriereEN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DescriereEN", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DescriereEN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DescriereEN", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_EffectiveDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EffectiveDate", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ExpirationDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExpirationDate", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ExpirationDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExpirationDate", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand4
            // 
            this.sqlInsertCommand4.CommandText = resources.GetString("sqlInsertCommand4.CommandText");
            this.sqlInsertCommand4.Connection = this.sqlConnection1;
            this.sqlInsertCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Cod", System.Data.SqlDbType.NChar, 0, "Cod"),
            new System.Data.SqlClient.SqlParameter("@DescriereRO", System.Data.SqlDbType.NVarChar, 0, "DescriereRO"),
            new System.Data.SqlClient.SqlParameter("@DescriereEN", System.Data.SqlDbType.NVarChar, 0, "DescriereEN"),
            new System.Data.SqlClient.SqlParameter("@EffectiveDate", System.Data.SqlDbType.DateTime, 0, "EffectiveDate"),
            new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 0, "IsActive"),
            new System.Data.SqlClient.SqlParameter("@ExpirationDate", System.Data.SqlDbType.DateTime, 0, "ExpirationDate")});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "SELECT        ID, Cod, DescriereRO, DescriereEN, EffectiveDate, IsActive, Expirat" +
    "ionDate\r\nFROM            tblCPVCodes\r\nWHERE        (IsActive = 1)";
            this.sqlSelectCommand6.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand5
            // 
            this.sqlUpdateCommand5.CommandText = resources.GetString("sqlUpdateCommand5.CommandText");
            this.sqlUpdateCommand5.Connection = this.sqlConnection1;
            this.sqlUpdateCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Cod", System.Data.SqlDbType.NChar, 0, "Cod"),
            new System.Data.SqlClient.SqlParameter("@DescriereRO", System.Data.SqlDbType.NVarChar, 0, "DescriereRO"),
            new System.Data.SqlClient.SqlParameter("@DescriereEN", System.Data.SqlDbType.NVarChar, 0, "DescriereEN"),
            new System.Data.SqlClient.SqlParameter("@EffectiveDate", System.Data.SqlDbType.DateTime, 0, "EffectiveDate"),
            new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 0, "IsActive"),
            new System.Data.SqlClient.SqlParameter("@ExpirationDate", System.Data.SqlDbType.DateTime, 0, "ExpirationDate"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Cod", System.Data.SqlDbType.NChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Cod", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DescriereRO", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DescriereRO", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DescriereRO", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DescriereRO", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_DescriereEN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DescriereEN", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_DescriereEN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DescriereEN", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_EffectiveDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EffectiveDate", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ExpirationDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExpirationDate", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ExpirationDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExpirationDate", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetProduse
            // 
            this.sqlDataAdapter_GetProduse.DeleteCommand = this.sqlDeleteCommand4;
            this.sqlDataAdapter_GetProduse.InsertCommand = this.sqlInsertCommand3;
            this.sqlDataAdapter_GetProduse.SelectCommand = this.sqlSelectCommand5;
            this.sqlDataAdapter_GetProduse.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblProduse", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Cod", "Cod"),
                        new System.Data.Common.DataColumnMapping("Denumire", "Denumire"),
                        new System.Data.Common.DataColumnMapping("CotaTVAID", "CotaTVAID"),
                        new System.Data.Common.DataColumnMapping("Pret", "Pret"),
                        new System.Data.Common.DataColumnMapping("UMID", "UMID")})});
            this.sqlDataAdapter_GetProduse.UpdateCommand = this.sqlUpdateCommand4;
            // 
            // sqlDeleteCommand4
            // 
            this.sqlDeleteCommand4.CommandText = resources.GetString("sqlDeleteCommand4.CommandText");
            this.sqlDeleteCommand4.Connection = this.sqlConnection1;
            this.sqlDeleteCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Cod", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Cod", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Denumire", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Denumire", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_CotaTVAID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CotaTVAID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Pret", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Pret", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UMID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UMID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand3
            // 
            this.sqlInsertCommand3.CommandText = resources.GetString("sqlInsertCommand3.CommandText");
            this.sqlInsertCommand3.Connection = this.sqlConnection1;
            this.sqlInsertCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Cod", System.Data.SqlDbType.NVarChar, 0, "Cod"),
            new System.Data.SqlClient.SqlParameter("@Denumire", System.Data.SqlDbType.NVarChar, 0, "Denumire"),
            new System.Data.SqlClient.SqlParameter("@CotaTVAID", System.Data.SqlDbType.UniqueIdentifier, 0, "CotaTVAID"),
            new System.Data.SqlClient.SqlParameter("@Pret", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Pret", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@UMID", System.Data.SqlDbType.UniqueIdentifier, 0, "UMID")});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "SELECT        ID, Cod, Denumire, CotaTVAID, Pret, UMID\r\nFROM            tblProdus" +
    "e";
            this.sqlSelectCommand5.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand4
            // 
            this.sqlUpdateCommand4.CommandText = resources.GetString("sqlUpdateCommand4.CommandText");
            this.sqlUpdateCommand4.Connection = this.sqlConnection1;
            this.sqlUpdateCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Cod", System.Data.SqlDbType.NVarChar, 0, "Cod"),
            new System.Data.SqlClient.SqlParameter("@Denumire", System.Data.SqlDbType.NVarChar, 0, "Denumire"),
            new System.Data.SqlClient.SqlParameter("@CotaTVAID", System.Data.SqlDbType.UniqueIdentifier, 0, "CotaTVAID"),
            new System.Data.SqlClient.SqlParameter("@Pret", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Pret", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@UMID", System.Data.SqlDbType.UniqueIdentifier, 0, "UMID"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Cod", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Cod", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Denumire", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Denumire", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_CotaTVAID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CotaTVAID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Pret", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(6)), "Pret", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UMID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UMID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetPartener
            // 
            this.sqlDataAdapter_GetPartener.DeleteCommand = this.sqlDeleteCommand3;
            this.sqlDataAdapter_GetPartener.InsertCommand = this.sqlInsertCommand;
            this.sqlDataAdapter_GetPartener.SelectCommand = this.sqlSelectCommand4;
            this.sqlDataAdapter_GetPartener.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblPartener", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Cod", "Cod"),
                        new System.Data.Common.DataColumnMapping("Denumire", "Denumire"),
                        new System.Data.Common.DataColumnMapping("Adresa", "Adresa"),
                        new System.Data.Common.DataColumnMapping("Detalii", "Detalii"),
                        new System.Data.Common.DataColumnMapping("CUI", "CUI"),
                        new System.Data.Common.DataColumnMapping("IsActive", "IsActive"),
                        new System.Data.Common.DataColumnMapping("UserName", "UserName")})});
            this.sqlDataAdapter_GetPartener.UpdateCommand = this.sqlUpdateCommand3;
            // 
            // sqlDeleteCommand3
            // 
            this.sqlDeleteCommand3.CommandText = resources.GetString("sqlDeleteCommand3.CommandText");
            this.sqlDeleteCommand3.Connection = this.sqlConnection1;
            this.sqlDeleteCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Cod", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Cod", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Denumire", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Denumire", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Adresa", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Adresa", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Adresa", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Adresa", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Detalii", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Detalii", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Detalii", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Detalii", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_CUI", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CUI", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_CUI", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CUI", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UserName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserName", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand
            // 
            this.sqlInsertCommand.CommandText = resources.GetString("sqlInsertCommand.CommandText");
            this.sqlInsertCommand.Connection = this.sqlConnection1;
            this.sqlInsertCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Cod", System.Data.SqlDbType.NVarChar, 0, "Cod"),
            new System.Data.SqlClient.SqlParameter("@Denumire", System.Data.SqlDbType.NVarChar, 0, "Denumire"),
            new System.Data.SqlClient.SqlParameter("@Adresa", System.Data.SqlDbType.NVarChar, 0, "Adresa"),
            new System.Data.SqlClient.SqlParameter("@Detalii", System.Data.SqlDbType.NVarChar, 0, "Detalii"),
            new System.Data.SqlClient.SqlParameter("@CUI", System.Data.SqlDbType.VarChar, 0, "CUI"),
            new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 0, "IsActive"),
            new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.NVarChar, 0, "UserName")});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "SELECT        ID, Cod, Denumire, Adresa, Detalii, CUI, IsActive,UserName\r\nFROM   " +
    "         tblPartener\r\nWHERE        (IsActive = 1)";
            this.sqlSelectCommand4.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand3
            // 
            this.sqlUpdateCommand3.CommandText = resources.GetString("sqlUpdateCommand3.CommandText");
            this.sqlUpdateCommand3.Connection = this.sqlConnection1;
            this.sqlUpdateCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Cod", System.Data.SqlDbType.NVarChar, 0, "Cod"),
            new System.Data.SqlClient.SqlParameter("@Denumire", System.Data.SqlDbType.NVarChar, 0, "Denumire"),
            new System.Data.SqlClient.SqlParameter("@Adresa", System.Data.SqlDbType.NVarChar, 0, "Adresa"),
            new System.Data.SqlClient.SqlParameter("@Detalii", System.Data.SqlDbType.NVarChar, 0, "Detalii"),
            new System.Data.SqlClient.SqlParameter("@CUI", System.Data.SqlDbType.VarChar, 0, "CUI"),
            new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 0, "IsActive"),
            new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.NVarChar, 0, "UserName"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Cod", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Cod", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Denumire", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Denumire", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Adresa", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Adresa", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Adresa", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Adresa", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Detalii", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Detalii", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Detalii", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Detalii", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_CUI", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CUI", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_CUI", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CUI", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_UserName", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UserName", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_tbxTipCentru
            // 
            this.sqlDataAdapter_tbxTipCentru.DeleteCommand = this.sqlCommand5;
            this.sqlDataAdapter_tbxTipCentru.InsertCommand = this.sqlCommand6;
            this.sqlDataAdapter_tbxTipCentru.SelectCommand = this.sqlCommand7;
            this.sqlDataAdapter_tbxTipCentru.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tbxTipCentru", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Abbreviation", "Abbreviation"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("IsActive", "IsActive"),
                        new System.Data.Common.DataColumnMapping("EffectiveDate", "EffectiveDate"),
                        new System.Data.Common.DataColumnMapping("ExpirationDate", "ExpirationDate")})});
            this.sqlDataAdapter_tbxTipCentru.UpdateCommand = this.sqlCommand8;
            // 
            // sqlCommand5
            // 
            this.sqlCommand5.CommandText = resources.GetString("sqlCommand5.CommandText");
            this.sqlCommand5.Connection = this.sqlConnection1;
            this.sqlCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Abbreviation", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Abbreviation", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_EffectiveDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EffectiveDate", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ExpirationDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExpirationDate", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ExpirationDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExpirationDate", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand6
            // 
            this.sqlCommand6.CommandText = resources.GetString("sqlCommand6.CommandText");
            this.sqlCommand6.Connection = this.sqlConnection1;
            this.sqlCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Abbreviation", System.Data.SqlDbType.NVarChar, 0, "Abbreviation"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"),
            new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 0, "IsActive"),
            new System.Data.SqlClient.SqlParameter("@EffectiveDate", System.Data.SqlDbType.DateTime, 0, "EffectiveDate"),
            new System.Data.SqlClient.SqlParameter("@ExpirationDate", System.Data.SqlDbType.DateTime, 0, "ExpirationDate")});
            // 
            // sqlCommand7
            // 
            this.sqlCommand7.CommandText = "SELECT  ID ,\r\n        Abbreviation ,\r\n        Description ,\r\n        IsActive ,\r\n" +
    "        EffectiveDate ,\r\n        ExpirationDate FROM dbo.tbxTipCentru\r\n        W" +
    "HERE Abbreviation IN (\'01\',\'03\')";
            this.sqlCommand7.Connection = this.sqlConnection1;
            // 
            // sqlCommand8
            // 
            this.sqlCommand8.CommandText = resources.GetString("sqlCommand8.CommandText");
            this.sqlCommand8.Connection = this.sqlConnection1;
            this.sqlCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Abbreviation", System.Data.SqlDbType.NVarChar, 0, "Abbreviation"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"),
            new System.Data.SqlClient.SqlParameter("@IsActive", System.Data.SqlDbType.Bit, 0, "IsActive"),
            new System.Data.SqlClient.SqlParameter("@EffectiveDate", System.Data.SqlDbType.DateTime, 0, "EffectiveDate"),
            new System.Data.SqlClient.SqlParameter("@ExpirationDate", System.Data.SqlDbType.DateTime, 0, "ExpirationDate"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Abbreviation", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Abbreviation", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IsActive", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IsActive", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_EffectiveDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EffectiveDate", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_ExpirationDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExpirationDate", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_ExpirationDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExpirationDate", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter_GetHome
            // 
            this.sqlDataAdapter_GetHome.SelectCommand = this.sqlCommand11;
            this.sqlDataAdapter_GetHome.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblAcordCadru", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("AcordCadru", "AcordCadru"),
                        new System.Data.Common.DataColumnMapping("DataStart", "DataStart"),
                        new System.Data.Common.DataColumnMapping("DataStop", "DataStop"),
                        new System.Data.Common.DataColumnMapping("TipCentruID", "TipCentruID"),
                        new System.Data.Common.DataColumnMapping("Furnizor", "Furnizor"),
                        new System.Data.Common.DataColumnMapping("Produs", "Produs"),
                        new System.Data.Common.DataColumnMapping("Pret", "Pret"),
                        new System.Data.Common.DataColumnMapping("CantitateTotala", "CantitateTotala"),
                        new System.Data.Common.DataColumnMapping("Valoare", "Valoare"),
                        new System.Data.Common.DataColumnMapping("CantitateDistributa", "CantitateDistributa"),
                        new System.Data.Common.DataColumnMapping("Disponibil", "Disponibil")})});
            // 
            // sqlCommand11
            // 
            this.sqlCommand11.CommandText = resources.GetString("sqlCommand11.CommandText");
            this.sqlCommand11.Connection = this.sqlConnection1;
            this.sqlCommand11.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@pDataLucru", System.Data.SqlDbType.DateTime, 8, "DataStop")});

        }

        #endregion

        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblAcordCadru;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tblAcordCadruDet;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        private System.Data.SqlClient.SqlCommand sqlCommand3;
        private System.Data.SqlClient.SqlCommand sqlCommand4;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetCodCPV;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand5;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand4;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand5;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetProduse;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand4;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand3;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand4;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetPartener;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand3;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand3;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_tbxTipCentru;
        private System.Data.SqlClient.SqlCommand sqlCommand5;
        private System.Data.SqlClient.SqlCommand sqlCommand6;
        private System.Data.SqlClient.SqlCommand sqlCommand7;
        private System.Data.SqlClient.SqlCommand sqlCommand8;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_GetHome;
        private System.Data.SqlClient.SqlCommand sqlCommand11;
    }
}