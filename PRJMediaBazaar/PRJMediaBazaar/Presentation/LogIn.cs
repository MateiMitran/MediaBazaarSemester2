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
        private List<Button> buttons;
        private List<Timer> timers;
        public LogIn()
        {
            timers = new List<Timer>();
            buttons = new List<Button>();
            InitializeComponent();
        }
        public void StatusFunction(String text,int x,int y,int width,int height,Color color)
        {
            Button newButton = new Button();
            newButton.Location = new Point(x, y);
            newButton.Width = width;
            newButton.Height = height;
            newButton.Enabled = false;
            newButton.BackColor = color;
            newButton.Text = text;
            this.Controls.Add(newButton);
            newButton.BringToFront();
            buttons.Add(newButton);
            Timer temp = new Timer();
            timers.Add(temp);
            temp.Start();
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
                StatusFunction("Invalid Credentials", -60, -5, 508, 28,Color.Red);
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
           
        }

        private void godTimer_Tick(object sender, EventArgs e)
        {
            for (int i=0;i<timers.Count;i++)
            {
                if (timers[i].Enabled == true)
                {
                    timers[i].Enabled = false;
                    buttons[i].Visible = false;
                }
            }
        }
    }
}
