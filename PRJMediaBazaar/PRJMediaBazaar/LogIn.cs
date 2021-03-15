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
        public LogIn()
        {
            InitializeComponent();

            DateTime startDate = DateTime.ParseExact("2021-01-04", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            while(startDate.Year != 2022)
            {
                Console.Write(startDate);
                Console.Write(" - ");

                DateTime endDate = startDate.AddDays(13);

                DatabaseHelper.CreateEmptySchedule(startDate, endDate);
                Console.Write(endDate);

                startDate = endDate.AddDays(1);

                Console.WriteLine(" ");
            }
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
            
            HRHome home = new HRHome();
            home.Show();
            this.Hide();
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
    }
}
