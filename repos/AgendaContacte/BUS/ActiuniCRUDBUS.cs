using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSet;
using DataTier;

namespace BUS
{
    public class ActiuniCRUDBUS
    {
        private ActiuniCRUDDT actiuniCRUDDT = new ActiuniCRUDDT();

        public void AdaugaDatePersonale(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.AdaugaDatePersonale(actiuniCRUDDS);
        }

        public void ModificaDatePersonale(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.ModificaDatePersonale(actiuniCRUDDS);
        }

        public int GetIdTaraByNume(string tara)
        {
            int id_Tara = -1;

            ActiuniCRUDDS dataSet = actiuniCRUDDT.GetIdTaraByNume(tara);

            if (dataSet.Tara.Rows.Count > 0)
            {
                // Extragem ID_Judet din primul rând
                id_Tara = Convert.ToInt32(dataSet.Tara.Rows[0]["ID_Tara"]);
            }

            return id_Tara;
        }

        public int GetIdJudetByNume(string tara)
        {
            int id_Judet = -1;

            ActiuniCRUDDS dataSet = actiuniCRUDDT.GetIdJudetByNume(tara);

            if (dataSet.Judet.Rows.Count > 0)
            {
                // Extragem ID_Judet din primul rând
                id_Judet = Convert.ToInt32(dataSet.Judet.Rows[0]["ID_Judet"]);
            }

            return id_Judet;
        }

        public void AdaugaAdresa(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.AdaugaAdresa(actiuniCRUDDS);
        }

        public void ModificaAdresa(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.ModificaAdresa(actiuniCRUDDS);
        }

        public void AdaugaTara(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.AdaugaTara(actiuniCRUDDS);
        }

        public void AdaugaJudet(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.AdaugaJudet(actiuniCRUDDS);
        }

        public void AdaugaContact(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.AdaugaContact(actiuniCRUDDS);
        }

        public void ModificaContacte(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.ModificaContacte(actiuniCRUDDS);
        }

        public void AdaugaTipContact(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.AdaugaTipContact(actiuniCRUDDS);
        }

        public void StergeContact(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.StergeContact(actiuniCRUDDS);
        }
        public void StergeAdresa(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.StergeAdresa(actiuniCRUDDS);
        }
        public void StergeDatePersonale(ActiuniCRUDDS actiuniCRUDDS)
        {
            actiuniCRUDDT.StergeDatePersonale(actiuniCRUDDS);
        }

        public ActiuniCRUDDS ExtrageContactById(int id)
        {
            return actiuniCRUDDT.ExtrageContactById(id);
        }

        public ActiuniCRUDDS ExtragePersonaleById(int id)
        {
            return actiuniCRUDDT.ExtragePersonaleById(id);
        }

        public ActiuniCRUDDS ExtrageJudete()
        {
            return actiuniCRUDDT.ExtrageJudete();
        }

        public ActiuniCRUDDS ExtrageTari()
        {
            return actiuniCRUDDT.ExtrageTari();
        }

        public ActiuniCRUDDS ExtrageDatePersonale()
        {
            return actiuniCRUDDT.ExtrageDatePersonale();
        }

        public ActiuniCRUDDS ExtrageAdresa()
        {
            return actiuniCRUDDT.ExtrageAdresa();
        }
        public ActiuniCRUDDS ExtrageContacte()
        {
            return actiuniCRUDDT.ExtrageContacte();
        }
    }
}
