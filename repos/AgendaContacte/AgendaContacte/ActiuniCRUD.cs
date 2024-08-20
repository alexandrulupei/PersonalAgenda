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
        }

        private void ExtrageContactById()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageContactById(this.contactId);
            dataGridView1.DataSource = actiuniCRUDDS.Tables["Contacte"];
        }

        private void ExtragePersonaleById()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageContactById(this.contactId);
            dataGridView1.DataSource = actiuniCRUDDS.Tables[""];
        }

    }
}
