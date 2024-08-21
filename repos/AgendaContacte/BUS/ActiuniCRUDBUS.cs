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
    }
}
