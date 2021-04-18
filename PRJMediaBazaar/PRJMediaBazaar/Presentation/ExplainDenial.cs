using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Logic;
using System.Windows.Forms;

namespace PRJMediaBazaar
{
     partial class ExplainDenial : Form
    {
        private DayOff dayOff;
        private ScheduleControl sc;
        private HRHome hr;
        private Button x;
        public ExplainDenial(DayOff d, ScheduleControl sc, HRHome hr)
        {
            InitializeComponent();
            this.dayOff = d;
            this.sc = sc;
            this.hr = hr;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                sc.AddReason(dayOff.Employee_id, this.tbExplain.Text); // adds the reason to the db
                hr.AddReasonForDenial(dayOff, this.tbExplain.Text); // adds the reason to the property of the request
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

        private void ExplainDenial_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
