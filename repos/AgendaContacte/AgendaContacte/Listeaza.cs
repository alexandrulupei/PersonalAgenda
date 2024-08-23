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
using DevExpress.XtraReports.UI;

namespace AgendaContacte
{
    public partial class Listeaza : Form
    {
        private ListeazaBUS listeazaBus = new ListeazaBUS();

        private ListeazaDS listeazaDS = new ListeazaDS();

        private ActiuniCRUDBUS actiuniCRUDBUS = new ActiuniCRUDBUS();

        private ActiuniCRUDDS actiuniCRUDDS = new ActiuniCRUDDS();

        
        public Listeaza()
        {
            InitializeComponent();
            PopuleazaJudete();
            PopuleazaTari();
            listeazaDS = listeazaBus.ExtrageDate();
            listeazaDS.AcceptChanges();
        }

        public void PopuleazaTari()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageTari();

            // Setăm DataSource-ul pentru comboBoxTara
            comboBoxTara.DataSource = actiuniCRUDDS.Tara;
            comboBoxTara.DisplayMember = "Tara";   // Coloana care va fi afișată
            comboBoxTara.ValueMember = "ID_Tara"; // Coloana care va fi utilizată ca valoare
            comboBoxTara.SelectedItem = null;
        }

        public void PopuleazaJudete()
        {
            actiuniCRUDDS = actiuniCRUDBUS.ExtrageJudete();

            // Setăm DataSource-ul pentru comboBoxJudet
            comboBoxJudet.DataSource = actiuniCRUDDS.Judet;
            comboBoxJudet.DisplayMember = "Judet";   // Coloana care va fi afișată
            comboBoxJudet.ValueMember = "ID_Judet"; // Coloana care va fi utilizată ca valoare
            comboBoxJudet.SelectedItem = null;

        }

        private void ListareButton_Click(object sender, EventArgs e)
        {
            string nume = textBoxNume.Text;
            string prenume = textBoxPrenume.Text;
            string tara = comboBoxTara.Text;
            string judet = comboBoxJudet.Text;

            List<string> filterConditions = new List<string>();

            if (!string.IsNullOrEmpty(nume))
            {
                filterConditions.Add($"Nume = '{nume}'");
            }

            if (!string.IsNullOrEmpty(prenume))
            {
                filterConditions.Add($"Prenume = '{prenume}'");
            }

            if (!string.IsNullOrEmpty(tara))
            {
                filterConditions.Add($"Tara = '{tara}'");
            }

            if (!string.IsNullOrEmpty(judet))
            {
                filterConditions.Add($"Judet = '{judet}'");
            }

            // Construiește expresia de filtrare finală
            string filterExpression = string.Join(" AND ", filterConditions);

            // Dacă nu sunt specificate filtre, nu aplica nimic
            DataRow[] contactRows;
            if (string.IsNullOrEmpty(filterExpression))
            {
                contactRows = listeazaDS.AgendaListare.Select();
            }
            else
            {
                contactRows = listeazaDS.AgendaListare.Select(filterExpression);
            }

            Report report = new Report(listeazaDS);
            report.CreateDocument();
            report.ShowPreviewDialog();
        }
    }
}
