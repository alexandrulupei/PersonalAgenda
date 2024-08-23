using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using DataSet;
namespace BUS
{
    public class ListeazaBUS
    {
        ListeazaDT listeazaDT = new ListeazaDT();

        public ListeazaDS ExtrageDate()
        {
            return listeazaDT.ExtrageDate();
        }

        public ListeazaDS ExtrageJudete()
        {
            return listeazaDT.ExtrageJudete();
        }

        public ListeazaDS ExtrageTari()
        {
            return listeazaDT.ExtrageTari();
        }
    }
}
