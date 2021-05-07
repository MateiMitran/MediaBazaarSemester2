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
     partial class StockerHome : Form
    {
        LogIn login;
        public StockerHome(LogIn login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void StockerHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }
    }
}
