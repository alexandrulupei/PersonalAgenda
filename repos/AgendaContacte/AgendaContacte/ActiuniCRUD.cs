using System;
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
        private int contactId;
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
            foreach (var taraRow in actiuniCRUDDS.Tara)
            {
                // Adăugăm fiecare țară în drop-down
                comboBoxTara.Items.Add(taraRow["Tara"].ToString());

            }
        }

        public void PopuleazaJudete()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageJudete();
            foreach (var judetRow in actiuniCRUDDS.Judet)
            {
                // Adăugăm fiecare județ în drop-down
                comboBoxJudet.Items.Add(judetRow["Judet"].ToString());
                
            }
        }

        private void Renunta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Salveaza_Click(object sender, EventArgs e)
        {
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

            if (comboBoxJudet.SelectedValue == null)
            {
                MessageBox.Show("Trebuie să selectați o țară.");
                return;
            }

            if (comboBoxJudet.SelectedValue == null)
            {
                MessageBox.Show("Trebuie să selectați un județ.");
                return;
            }

            // Obținere valori din form
            string nume = Nume.Text;
            string prenume = Prenume.Text;
            string cnp = CNP.Text;
            string Tara = (string)comboBoxJudet.SelectedValue;
            string Judet = (string)comboBoxJudet.SelectedValue;
            int idTara = 0;
            int idJudet = 0;

            // Pregătirea rândurilor în DataSet pentru DatePersonale
            DataRow newRow = actiuniCRUDDS.DatePersonale.NewRow();
            newRow["Nume"] = nume;
            newRow["Prenume"] = prenume;
            newRow["CNP"] = cnp;
            newRow["TaraID"] = idTara;
            newRow["JudetID"] = idJudet;
            actiuniCRUDDS.DatePersonale.Rows.Add(newRow);

            // Pregătirea rândurilor în DataSet pentru Contact
            foreach (DataGridViewRow row in dataGridContacte.Rows)
            {
                if (row.IsNewRow) continue;

                DataRow contactRow = actiuniCRUDDS.Contacte.NewRow();
                contactRow["ID_DP"] = newRow["ID_DP"]; // Asocierea cu ID-ul din DatePersonale
                contactRow["Tip_Contact"] = row.Cells["Tip Contact"].Value.ToString();
                contactRow["Contact"] = row.Cells["Contact"].Value.ToString();
                actiuniCRUDDS.Contacte.Rows.Add(contactRow);
            }

            // Salvarea în baza de date prin intermediul Business Layer
            try
            {
                actiuniCRUDBUS.SalveazaDatePersonale(actiuniCRUDDS);
                MessageBox.Show("Datele au fost salvate cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvare: {ex.Message}");
            }
        }



    }
}
