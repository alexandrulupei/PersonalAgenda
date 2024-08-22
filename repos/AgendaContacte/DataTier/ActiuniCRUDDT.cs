using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSet;
using System.Data.SqlClient;



namespace DataTier
{
    public partial class ActiuniCRUDDT : Component
    {
            
        private string conn;

        public SqlCommand cmd = new SqlCommand();

        public ActiuniCRUDDS actiuniCRUDDS = new ActiuniCRUDDS();

        public ActiuniCRUDDT()
        {
            InitializeComponent();
            conn = System.Configuration.ConfigurationManager.ConnectionStrings["Agenda_PersonalaConnectionString"].ConnectionString;

        }

        public ActiuniCRUDDT(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void AdaugaDatePersonale(ActiuniCRUDDS actiuniCRUDDS)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            datePersonaleAdapter.InsertCommand.Connection = con;
            datePersonaleAdapter.Update(actiuniCRUDDS.DatePersonale1);

        }

        public void ModificaDatePersonale(ActiuniCRUDDS actiuniCRUDDS)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            datePersonaleAdapter.UpdateCommand.Connection = con;
            datePersonaleAdapter.Update(actiuniCRUDDS.DatePersonale1);

        }

        public void ModificaAdresa(ActiuniCRUDDS actiuniCRUDDS)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            adresaAdpter.UpdateCommand.Connection = con;
            adresaAdpter.Update(actiuniCRUDDS.Adresa);

        }

        public void ModificaContacte(ActiuniCRUDDS actiuniCRUDDS)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            contactAdapter.UpdateCommand.Connection = con;
            contactAdapter.Update(actiuniCRUDDS.Contact);

        }

        public void AdaugaContact(ActiuniCRUDDS actiuniCRUDDS)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            contactAdapter.InsertCommand.Connection = con;
            contactAdapter.Update(actiuniCRUDDS.Contact);

        }

        public void AdaugaTipContact(ActiuniCRUDDS actiuniCRUDDS)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            tip_ContactAdapter.InsertCommand.Connection = con;
            tip_ContactAdapter.Update(actiuniCRUDDS.Contact_Tip);

        }

        public void AdaugaAdresa(ActiuniCRUDDS actiuniCRUDDS)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            adresaAdpter.InsertCommand.Connection = con;
            adresaAdpter.Update(actiuniCRUDDS.Adresa);

        }

        public void AdaugaTara(ActiuniCRUDDS actiuniCRUDDS)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            taraAdapter.InsertCommand.Connection = con;
            taraAdapter.Update(actiuniCRUDDS.Tara);

        }

        public void AdaugaJudet(ActiuniCRUDDS actiuniCRUDDS)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            judetAdapter.InsertCommand.Connection = con;
            judetAdapter.Update(actiuniCRUDDS.Judet);

        }

        public ActiuniCRUDDS ExtrageContactById(int id)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            // Setăm parametrul pentru TableAdapter
            editeazaAdapter.SelectCommand.Parameters.Clear(); // Curățăm parametrii existenți
            editeazaAdapter.SelectCommand.Parameters.AddWithValue("@ID_DP", id);

            // Umplem DataSet-ul folosind TableAdapter-ul
            editeazaAdapter.Fill(actiuniCRUDDS.Contacte);

            return actiuniCRUDDS;

        }

        public ActiuniCRUDDS ExtragePersonaleById(int id)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            // Setăm parametrul pentru TableAdapter
            editeazaPersonaleAdapter.SelectCommand.Parameters.Clear(); // Curățăm parametrii existenți
            editeazaPersonaleAdapter.SelectCommand.Parameters.AddWithValue("@ID_DP", id);

            // Umplem DataSet-ul folosind TableAdapter-ul
            editeazaPersonaleAdapter.Fill(actiuniCRUDDS.DatePersonale);

            return actiuniCRUDDS;

        }

        public ActiuniCRUDDS GetIdTaraByNume(string tara)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            // Setăm parametrul pentru TableAdapter
            taraByNumeAdapter.SelectCommand.Parameters.Clear(); // Curățăm parametrii existenți
            taraByNumeAdapter.SelectCommand.Parameters.AddWithValue("@Tara", tara);

            // Umplem DataSet-ul folosind TableAdapter-ul
            taraByNumeAdapter.Fill(actiuniCRUDDS.Tara);

            return actiuniCRUDDS;

        }

        public ActiuniCRUDDS GetIdJudetByNume(string judet)
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            // Setăm parametrul pentru TableAdapter
            judetByNumeAdapter.SelectCommand.Parameters.Clear(); // Curățăm parametrii existenți
            judetByNumeAdapter.SelectCommand.Parameters.AddWithValue("@Judet", judet);

            // Umplem DataSet-ul folosind TableAdapter-ul
            judetByNumeAdapter.Fill(actiuniCRUDDS.Judet);

            return actiuniCRUDDS;
        }

        public ActiuniCRUDDS ExtrageJudete()
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            judetAdapter.SelectCommand.Connection = con;
            judetAdapter.Fill(actiuniCRUDDS.Judet);

            return actiuniCRUDDS;

        }

        public ActiuniCRUDDS ExtrageTari()
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            taraAdapter.SelectCommand.Connection = con;
            taraAdapter.Fill(actiuniCRUDDS.Tara);

            return actiuniCRUDDS;

        }

        public ActiuniCRUDDS ExtrageDatePersonale()
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            datePersonaleAdapter.SelectCommand.Connection = con;
            datePersonaleAdapter.Fill(actiuniCRUDDS.DatePersonale1);

            return actiuniCRUDDS;
        }

        public ActiuniCRUDDS ExtrageAdresa()
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            adresaAdpter.SelectCommand.Connection = con;
            adresaAdpter.Fill(actiuniCRUDDS.Adresa);

            return actiuniCRUDDS;
        }

        public ActiuniCRUDDS ExtrageContacte()
        {
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            cmd.Connection = con;

            contactAdapter.SelectCommand.Connection = con;
            contactAdapter.Fill(actiuniCRUDDS.Contact);

            return actiuniCRUDDS;
        }
    }
}
