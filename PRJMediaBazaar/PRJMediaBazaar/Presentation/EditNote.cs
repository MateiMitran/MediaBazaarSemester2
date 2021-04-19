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
        private List<Button> buttons;
        private List<Timer> timers;
        public EditNote(Employee thisEmployee, EmployeeControl ec, HRHome hr)
        {
            InitializeComponent();
            buttons = new List<Button>();
            timers = new List<Timer>();
            this.thisEmployee = thisEmployee;
            this.ec = ec;
            this.hr = hr;
        }
        public void StatusFunction(String text, int x, int y, int width, int height, Color color)
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
                StatusFunction("Success!", -60, -5, 818, 28, Color.Green);
            }
            catch (Exception ex)
            {
                StatusFunction("An error occured!", -60, -5, 818, 28, Color.Red);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void godTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < timers.Count; i++)
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
