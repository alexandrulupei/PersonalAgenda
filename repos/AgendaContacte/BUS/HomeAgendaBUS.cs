using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSet;
using DataTier;

namespace BUS
{
    public class HomeAgendaBUS
    {
        private HomeAgendaDT homeAgendaDT = new HomeAgendaDT();

        public HomeAgendaDS ExtrageDate()
        {
            return homeAgendaDT.ExtrageDate();
        }
    }
}
