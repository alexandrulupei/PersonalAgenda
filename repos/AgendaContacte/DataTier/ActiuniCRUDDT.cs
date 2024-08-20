﻿using System;
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
    }
}