﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DataSet;
using DataTier;

namespace AgendaContacte
{
    public partial class ActiuniCRUD : Form
    {
        private int contactId = -1;
        private ActiuniCRUDBUS actiuniCRUDBUS = new ActiuniCRUDBUS();

        private ActiuniCRUDDS actiuniCRUDDS = new ActiuniCRUDDS();

        public ActiuniCRUD()
        {
            InitializeComponent();
        }

        public ActiuniCRUD(int id)
        {
            InitializeComponent();
            this.contactId = id;
        }

        private void ActiuniCRUD_Load(object sender, EventArgs e)
        {
            ExtrageContactById();
            ExtragePersonaleById();
            PopuleazaJudete();
            PopuleazaTari();
        }

        private void ExtrageContactById()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageContactById(this.contactId);
            dataGridContacte.DataSource = actiuniCRUDDS.Tables["Contacte"];
        }

        private void ExtragePersonaleById()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtragePersonaleById(this.contactId);
            if (actiuniCRUDDS.DatePersonale.Rows.Count > 0)
            {
                var row = actiuniCRUDDS.DatePersonale.Rows[0];

                // Setăm valorile în controalele TextBox
                Nume.Text = row["Nume"].ToString();
                Prenume.Text = row["Prenume"].ToString();
                CNP.Text = row["CNP"].ToString();

                // Setăm textul butonului drop-down pentru Țară
                comboBoxTara.Text = row["Tara"].ToString();  // Exemplu de coloană pentru țară
                comboBoxJudet.Text = row["Judet"].ToString();  // Exemplu de coloană pentru țară

            }
        }

        public void PopuleazaTari()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageTari();

            // Setăm DataSource-ul pentru comboBoxTara
            comboBoxTara.DataSource = actiuniCRUDDS.Tara;
            comboBoxTara.DisplayMember = "Tara";   // Coloana care va fi afișată
            comboBoxTara.ValueMember = "ID_Tara"; // Coloana care va fi utilizată ca valoare

        }

        public void PopuleazaJudete()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageJudete();

            // Setăm DataSource-ul pentru comboBoxJudet
            comboBoxJudet.DataSource = actiuniCRUDDS.Judet;
            comboBoxJudet.DisplayMember = "Judet";   // Coloana care va fi afișată
            comboBoxJudet.ValueMember = "ID_Judet"; // Coloana care va fi utilizată ca valoare
        }

        private void Renunta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Salveaza_Click(object sender, EventArgs e)
        {

            if (comboBoxTara.SelectedValue == null)
            {
                MessageBox.Show("Trebuie să selectați o țară.");
                return;
            }

            if (comboBoxJudet.SelectedValue == null)
            {
                MessageBox.Show("Trebuie să selectați un județ.");
                return;
            }
            // Validare campuri obligatorii
            if (string.IsNullOrEmpty(Nume.Text))
            {
                MessageBox.Show("Numele este obligatoriu.");
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(CNP.Text, "[^0-9]") || CNP.Text.Length != 13)
            {
                MessageBox.Show("CNP-ul trebuie să conțină exact 13 cifre.");
                return;
            }

            if (this.contactId == -1)
            {
                Adaugare();
            }
            else
            {
                Editare();
            }

        }

        private void Editare()
        {

            string nume = Nume.Text;
            string prenume = Prenume.Text;
            string cnp = CNP.Text;
            string tara = (string)comboBoxTara.DisplayMember;
            string judet = (string)comboBoxTara.DisplayMember;
            int idTara = actiuniCRUDBUS.GetIdTaraByNume(tara);
            int idJudet = actiuniCRUDBUS.GetIdJudetByNume(judet);

            DataRow rowToUpdate = actiuniCRUDDS.DatePersonale1.Rows.Find(contactId);

            if (rowToUpdate != null)
            {
                // Dacă rândul există, actualizează-l
                rowToUpdate["Nume"] = nume;
                rowToUpdate["Prenume"] = prenume;
                rowToUpdate["CNP"] = cnp;
            }

            try
            {
                actiuniCRUDBUS.ModificaDatePersonale(actiuniCRUDDS);
                actiuniCRUDDS.DatePersonale1.AcceptChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvare: {ex.Message}");
            }
        }

        private void Adaugare()
        {
            // Obținere valori din form
            string nume = Nume.Text;
            string prenume = Prenume.Text;
            string cnp = CNP.Text;
            string tara = (string)comboBoxTara.DisplayMember;
            string judet = (string)comboBoxTara.DisplayMember;
            int idTara = actiuniCRUDBUS.GetIdTaraByNume(tara);
            int idJudet = actiuniCRUDBUS.GetIdJudetByNume(judet);

            actiuniCRUDDS.DatePersonale1.Columns["ID_DP"].AutoIncrement = true;
            actiuniCRUDDS.DatePersonale1.Columns["ID_DP"].AutoIncrementSeed = -1;
            actiuniCRUDDS.DatePersonale1.Columns["ID_DP"].AutoIncrementStep = -1;

            actiuniCRUDDS.Adresa.Columns["ID_Adresa"].AutoIncrement = true;
            actiuniCRUDDS.Adresa.Columns["ID_Adresa"].AutoIncrementSeed = -1;
            actiuniCRUDDS.Adresa.Columns["ID_Adresa"].AutoIncrementStep = -1;

            actiuniCRUDDS.Contact.Columns["Contact_ID"].AutoIncrement = true;
            actiuniCRUDDS.Contact.Columns["Contact_ID"].AutoIncrementSeed = -1;
            actiuniCRUDDS.Contact.Columns["Contact_ID"].AutoIncrementStep = -1;

            // Pregătirea rândurilor în DataSet pentru DatePersonale
            DataRow newRow = actiuniCRUDDS.DatePersonale1.NewRow();
            newRow["Nume"] = nume;
            newRow["Prenume"] = prenume;
            newRow["CNP"] = cnp;

            newRow["ID_DP"] = this.contactId;

            actiuniCRUDDS.DatePersonale1.Rows.Add(newRow);

            try
            {
                actiuniCRUDBUS.AdaugaDatePersonale(actiuniCRUDDS);
                actiuniCRUDDS.DatePersonale1.AcceptChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvare: {ex.Message}");
            }

            DataRow newRowAdresa = actiuniCRUDDS.Adresa.NewRow();
            newRowAdresa["ID_DP"] = newRow["ID_DP"];
            newRowAdresa["ID_Tara"] = idTara;
            newRowAdresa["ID_Judet"] = idJudet;

            actiuniCRUDDS.Adresa.Rows.Add(newRowAdresa);


            // Pregătirea rândurilor în DataSet pentru Contact
            foreach (DataGridViewRow row in dataGridContacte.Rows)
            {
                if (row.IsNewRow) continue;


                DataRow contactRow = actiuniCRUDDS.Contact.NewRow();
                contactRow["ID_DP"] = newRow["ID_DP"]; // Asocierea cu ID-ul din DatePersonale
                contactRow["Contact"] = row.Cells["Contact"].Value.ToString();

                actiuniCRUDDS.Contact.Rows.Add(contactRow);

                try
                {
                    actiuniCRUDBUS.AdaugaContact(actiuniCRUDDS);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la salvare: {ex.Message}");
                }


                DataRow contactTipRow = actiuniCRUDDS.Contact_Tip.NewRow();
                contactTipRow["Contact_Tip"] = row.Cells["TipContact"].Value.ToString();

                contactTipRow["Contact_ID"] = contactRow["Contact_ID"];

                actiuniCRUDDS.Contact_Tip.Rows.Add(contactTipRow);
            }

            // Salvarea în baza de date prin intermediul Business Layer
            try
            {
                actiuniCRUDBUS.AdaugaAdresa(actiuniCRUDDS);
                actiuniCRUDBUS.AdaugaContact(actiuniCRUDDS);
                actiuniCRUDBUS.AdaugaTipContact(actiuniCRUDDS);

                MessageBox.Show("Datele au fost salvate cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvare: {ex.Message}");
            }

        }
    }

}

