﻿using System;
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
                MessageBox.Show("Invalid username or password!");
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
    }
}