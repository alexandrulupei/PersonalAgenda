using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            HomeAgendaAdapter.Fill(homeContacteDS.DatePersonale);
            return homeContacteDS;

        }

    }
}
    
