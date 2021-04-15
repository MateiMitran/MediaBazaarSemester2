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
    partial class LogIn : Form
    {
        Button x;
        public LogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (this.tbUsername.Text == "hrmanager" && this.tbPassword.Text == "hrmanager")
            {
                HRHome home = new HRHome(this);
                home.Show();
                this.Hide();
            }
            else
            {
                x = new Button();
                x.Location = new Point(-60, -5);
                x.Width = 556;
                x.Height = 28;
                x.Enabled = false;
                x.BackColor = Color.Red;
                x.Text = "Invalid username or password!";
                this.Controls.Add(x);
                x.BringToFront();
                timer1.Start();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void btnLogIn_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnLogIn_MouseEnter(object sender, EventArgs e)
        {
            this.btnLogIn.BackColor = Color.Bisque;
        }

        private void btnLogIn_MouseLeave(object sender, EventArgs e)
        {
            this.btnLogIn.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x.Visible = false;
        }
    }
}
