using System.ComponentModel;
using System.Data.SqlClient;

using DataSet;

namespace DataTier
{
    public partial class HomeAgendaDT : Component
    {
        private string conn;

        public SqlCommand cmd = new SqlCommand();

        public HomeAgendaDS homeContacteDS = new HomeAgendaDS();

        public HomeAgendaDT()
        {
            InitializeComponent();
            conn = System.Configuration.ConfigurationManager.ConnectionStrings["Agenda_PersonalaConnectionString"].ConnectionString;
        }

        public HomeAgendaDT(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void sqlDataAdapter1_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
        {

        }

        public HomeAgendaDS ExtrageDate()
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;
            HomeAgendaAdapter.SelectCommand.Connection = con;
            HomeAgendaAdapter.Fill(homeContacteDS.HomeAgenda);
            return homeContacteDS;

        }

        private void sqlConnection1_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {

        }
    }
}
    
