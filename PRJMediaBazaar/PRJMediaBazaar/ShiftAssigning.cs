using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRJMediaBazaar
{
     partial class ShiftAssigning : Form
    {
        private HrManagement _hrm;
        public ShiftAssigning(HrManagement hrm)
        {
            InitializeComponent();
            _hrm = hrm;
        }
    }
}
