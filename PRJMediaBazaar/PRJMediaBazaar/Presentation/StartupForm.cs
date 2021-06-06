using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRJMediaBazaar.Presentation
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void btnSingleLogin_Click(object sender, EventArgs e)
        {
            LogIn first = new LogIn();
            first.Show();
            this.Hide();
        }

        private void btnMultipleLogin_Click(object sender, EventArgs e)
        {
            LogIn first = new LogIn();
            LogIn second = new LogIn();
            LogIn third = new LogIn();
            first.Show();
            second.Show();
            third.Show();
            this.Hide();
        }
    }
}
