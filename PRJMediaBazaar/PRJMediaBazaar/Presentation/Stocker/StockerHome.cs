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
            this.lblDashboard.BackColor = Color.Gray;
            this.pnlDashboard.Visible = true;
            this.pnlRestocks.Visible = false;
            this.pnlDashboard.BringToFront();
        }

        private void StockerHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            this.lblDashboard.BackColor = Color.Gray;
            this.pnlDashboard.BringToFront();
            this.lblRestocks.BackColor = Color.White;
            this.pnlRestocks.Visible = false;
            this.pnlDashboard.Visible = true;
        }

        private void lblRestocks_Click(object sender, EventArgs e)
        {
            this.lblRestocks.BackColor = Color.Gray;
            this.pnlRestocks.BringToFront();
            this.lblDashboard.BackColor = Color.White;
            this.pnlRestocks.Visible = true;
            this.pnlDashboard.Visible = false;
        }
    }
}
