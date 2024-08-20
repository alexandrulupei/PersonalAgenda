using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public partial class ActiuniCRUD : Component
    {
        public ActiuniCRUD()
        {
            InitializeComponent();
        }

        public ActiuniCRUD(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
