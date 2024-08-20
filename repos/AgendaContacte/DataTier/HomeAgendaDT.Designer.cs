
namespace DataTier
{
    partial class HomeAgendaDT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeAgendaDT));
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.HomeAgendaAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // HomeAgendaAdapter
            // 
            this.HomeAgendaAdapter.SelectCommand = this.sqlSelectCommand1;
            this.HomeAgendaAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Adresa", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Nume", "Nume"),
                        new System.Data.Common.DataColumnMapping("Prenume", "Prenume"),
                        new System.Data.Common.DataColumnMapping("CNP", "CNP"),
                        new System.Data.Common.DataColumnMapping("Strada", "Strada"),
                        new System.Data.Common.DataColumnMapping("Numar_Strada", "Numar_Strada"),
                        new System.Data.Common.DataColumnMapping("Cod_Postal", "Cod_Postal"),
                        new System.Data.Common.DataColumnMapping("Contact_Tip", "Contact_Tip"),
                        new System.Data.Common.DataColumnMapping("Contact", "Contact"),
                        new System.Data.Common.DataColumnMapping("Judet", "Judet"),
                        new System.Data.Common.DataColumnMapping("Tara", "Tara")})});
            this.HomeAgendaAdapter.RowUpdated += new System.Data.SqlClient.SqlRowUpdatedEventHandler(this.sqlDataAdapter1_RowUpdated);
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=GS0022\\SQL2019;Initial Catalog=Agenda_Personala;User ID=sa;Password=1" +
    "234";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;

        }

        #endregion

        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlDataAdapter HomeAgendaAdapter;
    }
}
