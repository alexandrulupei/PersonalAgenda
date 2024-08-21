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
           /* dataGridView1.Columns.Clear();
    dataGridView1.Rows.Clear();*/
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
            // Codul tău pentru a actualiza datele sau a reîncărca conținutul
            MessageBox.Show("Datele au fost reactualizate!"); // Exemplu de testare
        }
    }
}
