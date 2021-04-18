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
    partial class EditNote : Form
    {
        private Employee thisEmployee;
        private EmployeeControl ec;
        private HRHome hr;
        private Button x;
        public EditNote(Employee thisEmployee, EmployeeControl ec, HRHome hr)
        {
            InitializeComponent();
            this.thisEmployee = thisEmployee;
            this.ec = ec;
            this.hr = hr;
        }

        private void EditNote_Load(object sender, EventArgs e)
        {
            this.tbNote.Text = thisEmployee.Note;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                this.tbNote.Text += " " + DateTime.Now.ToString();
                ec.UpdateNote(this.tbNote.Text, thisEmployee.Email);
                hr.AddNoteToEmployee(thisEmployee, this.tbNote.Text);
                x = new Button();
                x.Location = new Point(-6, -1);
                x.Width = 556;
                x.Height = 28;
                x.Enabled = false;
                x.BackColor = Color.Green;
                x.Text = "Success!";
                this.Controls.Add(x);
                x.BringToFront();
                timer1.Start();
            }
            catch (Exception ex)
            {
                x = new Button();
                x.Location = new Point(-6, -1);
                x.Width = 556;
                x.Height = 28;
                x.Enabled = false;
                x.BackColor = Color.Red;
                x.Text = "An error occured!";
                this.Controls.Add(x);
                x.BringToFront();
                timer1.Start();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x.Visible = false;
            timer1.Stop();
        }
    }
}
