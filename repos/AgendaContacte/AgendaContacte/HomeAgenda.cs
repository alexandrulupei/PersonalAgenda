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
            homeAgendaDS = homeAgendaBUS.ExtrageDate();
            dataGridView1.DataSource = homeAgendaDS.Tables["HomeAgenda"];
        }

        private void Editeaza(object sender, EventArgs e)
        {
            ActiuniCRUD actiuniCRUD = new ActiuniCRUD();
            actiuniCRUD.ShowDialog();
        }

        private void Adauga(object sender, EventArgs e)
        {
            ActiuniCRUD actiuniCRUD = new ActiuniCRUD();
            actiuniCRUD.ShowDialog();
        }
    }
}
