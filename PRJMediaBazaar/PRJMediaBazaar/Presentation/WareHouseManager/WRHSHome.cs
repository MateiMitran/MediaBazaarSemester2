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
     partial class WRHSHome : Form
    {
        private LogIn login;
        public WRHSHome(LogIn login)
        {
            InitializeComponent();
            this.lblItems.ForeColor = Color.Gray;
            this.login = login;
        }

        private void lblItems_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = true;
            this.pnlStatistics.Visible = false;
            this.pnlRestock.Visible = false;
            this.pnlAccount.Visible = false;
            this.lblItems.ForeColor = Color.Gray;
            this.lblStatistics.ForeColor = Color.White;
            this.lblRestock.ForeColor = Color.White;
            this.lblAccount.ForeColor = Color.White;
        }

        private void lblStatistics_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = false;
            this.pnlStatistics.Visible = true;
            this.pnlRestock.Visible = false;
            this.pnlAccount.Visible = false;
            this.lblItems.ForeColor = Color.White;
            this.lblStatistics.ForeColor = Color.Gray;
            this.lblRestock.ForeColor = Color.White;
            this.lblAccount.ForeColor = Color.White;
        }

        private void lblRestock_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = false;
            this.pnlStatistics.Visible = false;
            this.pnlRestock.Visible = true;
            this.pnlAccount.Visible = false;
            this.lblItems.ForeColor = Color.White;
            this.lblStatistics.ForeColor = Color.White;
            this.lblRestock.ForeColor = Color.Gray;
            this.lblAccount.ForeColor = Color.White;
        }

        private void lblAccount_Click(object sender, EventArgs e)
        {
            this.pnlItems.Visible = false;
            this.pnlStatistics.Visible = false;
            this.pnlRestock.Visible = false;
            this.pnlAccount.Visible = true;
            this.lblItems.ForeColor = Color.White;
            this.lblStatistics.ForeColor = Color.White;
            this.lblRestock.ForeColor = Color.White;
            this.lblAccount.ForeColor = Color.Gray;
        }
        private void WRHSHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }

        private void WRHSHome_Load(object sender, EventArgs e)
        {

        }
    }
}
