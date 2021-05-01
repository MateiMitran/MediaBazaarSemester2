using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRJMediaBazaar.Logic;
namespace PRJMediaBazaar
{
     partial class RequestsOverview : Form
    {
        private DayOff[] _requests;
        public RequestsOverview(DayOff[] requests, string info)
        {
            InitializeComponent();
            _requests = requests;
            foreach(DayOff r in _requests)
            {
                listBox1.Items.Add(r);
            }
            lblInfo.Text = info;
        }
    }
}
