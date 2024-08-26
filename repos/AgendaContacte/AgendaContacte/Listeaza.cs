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

        
        public Listeaza()
        {
            InitializeComponent();
            PopuleazaJudete();
            PopuleazaTari();
            listeazaDS = listeazaBus.ExtrageDate();
            listeazaDS.AcceptChanges();
            comboBoxTara.SelectedIndex = -1;
            comboBoxJudet.SelectedValue = -1;

        }

        public void PopuleazaTari()
        {
            listeazaDS = listeazaBus.ExtrageTari();

            // Setăm DataSource-ul pentru comboBoxTara
            comboBoxTara.DataSource = listeazaDS.Tara;
            comboBoxTara.DisplayMember = "Tara";   // Coloana care va fi afișată
            comboBoxTara.ValueMember = "ID_Tara"; // Coloana care va fi utilizată ca valoare
        }

        public void PopuleazaJudete()
        {
            listeazaDS = listeazaBus.ExtrageJudete();

            // Setăm DataSource-ul pentru comboBoxJudet
            comboBoxJudet.DataSource = listeazaDS.Judet;
            comboBoxJudet.DisplayMember = "Judet";   // Coloana care va fi afișată
            comboBoxJudet.ValueMember = "ID_Judet"; // Coloana care va fi utilizată ca valoare
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
                filterConditions.Add($"Nume LIKE '{nume}%'");
            }

            if (!string.IsNullOrEmpty(prenume))
            {
                filterConditions.Add($"Prenume LIKE '{prenume}%'");
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
            DataRow[] contactRows= null;
            try
            {
                if (string.IsNullOrEmpty(filterExpression))
                {
                    contactRows = listeazaDS.AgendaListare.Select();
                }
                else
                {
                    contactRows = listeazaDS.AgendaListare.Select(filterExpression);
                }
            

                if (!contactRows.Any())
                {
                    MessageBox.Show("Nu au fost gasite date pentru acest filtru", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    DataTable filteredTable = listeazaDS.AgendaListare.Clone();

                    foreach (DataRow row in contactRows)
                    {
                        filteredTable.ImportRow(row);
                    }

                    //filteredTable.Tables.Remove("AgendaListare");
                    listeazaDS.Tables.Add(filteredTable);

                    Report report = new Report(filteredTable, nume, prenume, tara, judet);
                    report.CreateDocument();
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                MessageBox.Show("Nu au fost gasite date pentru acest filtru", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            //listeazaDS = listeazaBus.ExtrageDate();
            comboBoxTara.SelectedIndex = -1;
            comboBoxJudet.SelectedValue = -1;
        }

        private void RenuntaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
