using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataSet;

namespace DataTier
{
    public partial class ListeazaDT : Component
    {
        private string conn;

        public SqlCommand cmd = new SqlCommand();

        public ListeazaDS listeazaDS = new ListeazaDS();
        public ListeazaDT()
        {
            InitializeComponent();
            conn = sqlConnection1.ConnectionString;

        }

        public ListeazaDT(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public ListeazaDS ExtrageDate()
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;
            listeazaAdapter.SelectCommand.Connection = con;
            listeazaAdapter.Fill(listeazaDS.AgendaListare);
            return listeazaDS;

        }

        public ListeazaDS ExtrageJudete()
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            judetAdapter.SelectCommand.Connection = con;
            judetAdapter.Fill(listeazaDS.Judet);

            return listeazaDS;

        }

        public ListeazaDS ExtrageTari()
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            taraAdapter.SelectCommand.Connection = con;
            taraAdapter.Fill(listeazaDS.Tara);

            return listeazaDS;

        }

        private void sqlDataAdapter1_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {

        }
    }
}
