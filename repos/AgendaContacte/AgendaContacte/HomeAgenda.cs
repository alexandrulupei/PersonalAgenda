using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTier;
using DataSet;
using BUS;

namespace AgendaContacte
{
    public partial class HomeAgenda : Form
    {
        private HomeAgendaBUS homeAgendaBUS = new HomeAgendaBUS();

        private HomeAgendaDS homeAgendaDS = new HomeAgendaDS();

        private ActiuniCRUDBUS actiuniCRUDBUS = new ActiuniCRUDBUS();

        private ActiuniCRUDDS actiuniCRUDDS = new ActiuniCRUDDS();

        public HomeAgenda()
        {
            InitializeComponent();
        }

        private void AgendaContacte_Load(object sender, EventArgs e)
        {
            ExtrageDate();
        }

        private void ExtrageDate()
        {
            homeAgendaDS.Tables["HomeAgenda"].Clear();
            homeAgendaDS = homeAgendaBUS.ExtrageDate();
            dataGridView1.DataSource = homeAgendaDS.Tables["HomeAgenda"];
        }

        private void Editeaza(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obținem ID-ul contactului selectat
                int selectedContactId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_DP"].Value);

                // Creăm instanța noului formular și trimitem ID-ul contactului
                ActiuniCRUD actiuniCRUD = new ActiuniCRUD(selectedContactId);

                actiuniCRUD.FormClosed += (s, args) => RefreshData();


                actiuniCRUD.ShowDialog();
            }
            else
            {
                MessageBox.Show("Te rog să selectezi un contact înainte de a edita.");
            }
        }

        private void Adauga(object sender, EventArgs e)
        {
            ActiuniCRUD actiuniCRUD = new ActiuniCRUD();
            actiuniCRUD.FormClosed += (s, args) => RefreshData();


            actiuniCRUD.ShowDialog();
        }

        public void RefreshData()
        {
            ExtrageDate();
            /*MessageBox.Show("Datele au fost reactualizate!");*/
        }

        private void stergeButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int selectedContactId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_DP"].Value);
                string selectedContactNume = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Nume"].Value);
                string selectedContactPrenume = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Prenume"].Value);

                

                if (selectedContactId != -1)
                {
                    DialogResult result = MessageBox.Show($"Sunteti sigur ca doriti sa stergeti randul: \n ID: {selectedContactId} \n Nume: {selectedContactNume} \n Prenume: {selectedContactPrenume}", "Stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {


                        try
                        {
                            // Salvează modificările în baza de date
                            StergeContacte(selectedContactId);
                            StergeAdresa(selectedContactId);
                            StergeDatePersonale(selectedContactId);

                            MessageBox.Show($"Contactul cu ID: {selectedContactId} fost șters cu succes.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Eroare la ștergere: {ex.Message}");
                        }
                    }
                }
            }
            else
            {

            
                MessageBox.Show("Te rog să selectezi un contact înainte de a sterge.");

            }



            RefreshData();
        }
        private void StergeContacte(int selectedContactId)
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageContacte();

            DataRow[] contactRows = actiuniCRUDDS.Contact.Select($"ID_DP = {selectedContactId}");

            if (contactRows.Length > 0)
            {
                // Parcurge toate rândurile selectate și marchează-le pentru ștergere
                foreach (DataRow row in contactRows)
                {
                    row.Delete();
                }
                actiuniCRUDBUS.StergeContact(actiuniCRUDDS);
               
            }
        }

        private void StergeDatePersonale(int selectedContactId)
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageDatePersonale();
            DataRow findRow = actiuniCRUDDS.DatePersonale1.Rows.Find(selectedContactId);
            findRow.Delete();

            actiuniCRUDBUS.StergeDatePersonale(actiuniCRUDDS);
            //DataRowState dataRowState = findRow.RowState;
        }
        private void StergeAdresa(int selectedContactId)
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageAdresa();
            DataRow findRow = actiuniCRUDDS.Adresa.Rows.Find(selectedContactId);
            findRow.Delete();

            actiuniCRUDBUS.StergeAdresa(actiuniCRUDDS);
            //DataRowState dataRowState = findRow.RowState;
        }
    }
}
