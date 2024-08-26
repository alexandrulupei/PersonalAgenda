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
        private int contactId = -1;
        private ActiuniCRUDBUS actiuniCRUDBUS = new ActiuniCRUDBUS();

        private ActiuniCRUDDS actiuniCRUDDS = new ActiuniCRUDDS();

        public ActiuniCRUD()
        {
            InitializeComponent();
            dataGridContacte.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridContacte_DefaultValuesNeeded);

        }

        public ActiuniCRUD(int id)
        {
            InitializeComponent();
            dataGridContacte.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridContacte_DefaultValuesNeeded);

            this.contactId = id;
        }
        private void dataGridContacte_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["ID_DP"].Value = -1;
        }
        private void ActiuniCRUD_Load(object sender, EventArgs e)
        {

            PopuleazaJudete();
            PopuleazaTari();
            PopuleazaContacte();
            if(this.contactId > 0)
            {
                PopuleazaPersonaleById();
                PopuleazaContactById();

            }

            //Doar dupa load Accept Changes, restul modificarilor le faci cu functiile din bussines si logic
            actiuniCRUDDS.Contact.AcceptChanges();
        }

        public void PopuleazaContacte()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageContactTip();
            DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)dataGridContacte.Columns["Contact_Tip_Column"];
            comboBoxColumn.DisplayMember = "Contact_Tip";   // Coloana care va fi afișată
            comboBoxColumn.ValueMember = "Contact_Tip_Id";
            comboBoxColumn.DataSource = actiuniCRUDDS.Contact_Tip;

            /* TipContact.DataPropertyName = "Contact_Tip_Id";*/
        }
        private void PopuleazaContactById()
        {
            actiuniCRUDDS.Tables["Contact"].Clear();
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageContactById(this.contactId);
            dataGridContacte.DataSource = actiuniCRUDDS.Tables["Contact"];

        }

        private void PopuleazaPersonaleById()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageDatePersonale();
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageAdresa();
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
            if (CheckAllContactFieldsCompleted() == false)
            {
                MessageBox.Show("Trebuie să completati campurile de contacte");
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

            this.Close();

        }


        private void Editare()
        {

            string nume = Nume.Text;
            string prenume = Prenume.Text;
            string cnp = CNP.Text;
/*            string tara = (string)comboBoxTara.Text;
            string judet = (string)comboBoxTara.Text;*/
            int idTara = (int)comboBoxTara.SelectedValue;
            int idJudet = (int)comboBoxTara.SelectedValue;

            try
            {
                EditareDatePersonale(nume, prenume, cnp);
                EditareAdresa(idTara, idJudet);
                EditareContacte();
                DialogResult result = MessageBox.Show("Datele au fost salvate cu succes!", "Modificare", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(result == DialogResult.OK)
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvare: {ex.Message}");
            }

        }

        private void EditareContacte()
        {

            // Pregătirea rândurilor în DataSet pentru Contact
            foreach (DataRow row in actiuniCRUDDS.Contact.Select())
            {

                /*DataRow rowToUpdate = actiuniCRUDDS.Contact.Rows.Find((int)row["Contact_Tip_Id"]);
                if (rowToUpdate != null)
                {
                    rowToUpdate["Contact"] = row["Contact"].ToString();
                    row["Contact_Tip_Id"] = (int)row["Contact_Tip_Id"];
                }
                else
                {*/
                    row["ID_DP"] = this.contactId; // Asocierea cu ID-ul din DatePersonale
                    row["Contact"] = row["Contact"].ToString();
                    row["Contact_Tip_Id"] = (int)row["Contact_Tip_Id"];
                /*}*/

            }
            actiuniCRUDBUS.ModificaContacte(actiuniCRUDDS);
        }

        private void EditareAdresa(int idTara, int idJudet)
        {
            DataRow[] rowToUpdate = actiuniCRUDDS.Adresa.Select($"ID_DP = {contactId}");

            rowToUpdate[0]["ID_Tara"] = idTara;
            rowToUpdate[0]["ID_Judet"] = idJudet;

            actiuniCRUDBUS.ModificaAdresa(actiuniCRUDDS);
        }

        private void EditareDatePersonale(string nume, string prenume, string cnp)
        {
            DataRow[] rowToUpdate = actiuniCRUDDS.DatePersonale1.Select($"ID_DP = {contactId}");

            rowToUpdate[0]["Nume"] = nume;
            rowToUpdate[0]["Prenume"] = prenume;
            rowToUpdate[0]["CNP"] = cnp;
            
            actiuniCRUDBUS.ModificaDatePersonale(actiuniCRUDDS);
        }

        private void Adaugare()
            {
                // Obținere valori din form
                string nume = Nume.Text;
                string prenume = Prenume.Text;
                string cnp = CNP.Text;
                /*string tara = (string)comboBoxTara.DisplayMember;
                string judet = (string)comboBoxTara.DisplayMember;*/
                int idTara = (int)comboBoxTara.SelectedValue;
                int idJudet = (int)comboBoxTara.SelectedValue;

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
                    this.contactId = (int)newRow["ID_DP"];


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
            foreach (DataRow row in actiuniCRUDDS.Contact.Select())
                {
                row["ID_DP"] = newRow["ID_DP"]; // Asocierea cu ID-ul din DatePersonale

                row["Contact"] = row["Contact"].ToString();
                row["Contact_Tip_Id"] = (int)row["Contact_Tip_Id"];

                actiuniCRUDBUS.AdaugaContact(actiuniCRUDDS);
                
            }

            // Salvarea în baza de date prin intermediul Business Layer
            try
            {
                actiuniCRUDBUS.AdaugaAdresa(actiuniCRUDDS);
                MessageBox.Show("Datele au fost salvate cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvare: {ex.Message}");
            }


        }

        private void stergeContactButton_Click(object sender, EventArgs e)
        {
            int selectedContactId = 0;

            if (dataGridContacte.SelectedRows.Count > 0)
            {
                selectedContactId = Convert.ToInt32(dataGridContacte.SelectedRows[0].Cells["Contact_ID"].Value);
            }

            if (selectedContactId != 0)
            {
                DataRow findRow = actiuniCRUDDS.Contact.Rows.Find(selectedContactId);
                findRow.Delete();
                //actiuniCRUDDS.Contact.Rows.Remove(findRow);
                DataRowState dataRowState = findRow.RowState;

                try
                {
                    actiuniCRUDBUS.StergeContact(actiuniCRUDDS);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la stergere: {ex.Message}");
                }

                RefreshContactGirdViewData();
            }
            else
            {
                MessageBox.Show("Te rog să selectezi un contact înainte de a sterge.");
            }
        }
        public void RefreshContactGirdViewData()
        {
            PopuleazaContactById();
            /*MessageBox.Show("Datele au fost reactualizate!");*/
        }
        private bool CheckAllContactFieldsCompleted()
        {
            foreach (DataGridViewRow row in this.dataGridContacte.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var contactCellValue = row.Cells["Contact"].Value;
                if (contactCellValue == null || string.IsNullOrWhiteSpace(contactCellValue.ToString()))
                {
                    return false;
                }

                if (row.Cells["Contact_Tip_Column"] is DataGridViewComboBoxCell comboBoxCell)
                {
                    var selectedValue = comboBoxCell.Value;

                    // Verifică dacă un element este selectat (nu este null sau gol)
                    if (selectedValue == null || string.IsNullOrWhiteSpace(selectedValue.ToString()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

