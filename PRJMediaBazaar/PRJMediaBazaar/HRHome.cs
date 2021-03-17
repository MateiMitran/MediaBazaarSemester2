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
     partial class HRHome : Form
    {
        RegularEmployee[] _employees;
        Schedule[] _schedules;

        public HRHome()
        {
            InitializeComponent();
   
            _employees = Database.GetEmployees();
            foreach(RegularEmployee e in _employees)
            {
                cbAllEmployees.Items.Add(e.FirstName + " " + e.LastName);
            }
            _schedules = Database.GetAllSchedules();
            foreach(Schedule s in _schedules)
            {
                cbSchedule.Items.Add(s);
            }
            cbPosition.Text = "All";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.panelEmployees.Visible = true;
            this.panelSchedule.Visible = false;
            this.panelSickReports.Visible = false;
            this.pnlDayOff.Visible = false;
            this.lblSchedule.ForeColor = Color.White;
            this.lblEmployees.ForeColor = Color.Gray;
            this.lblSickReports.ForeColor = Color.White;
            this.lblDayOffReports.ForeColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.panelEmployees.Visible = false;
            this.panelSchedule.Visible = false;
            this.pnlDayOff.Visible = false;
            this.panelSickReports.Visible = true;
            this.lblSchedule.ForeColor = Color.White;
            this.lblEmployees.ForeColor = Color.White;
            this.lblSickReports.ForeColor = Color.Gray;
            this.lblDayOffReports.ForeColor = Color.White;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.pnlDayOff.Visible = true;
            this.panelEmployees.Visible = false;
            this.panelSchedule.Visible = false;
            this.panelSickReports.Visible = false;
            
            this.lblSchedule.ForeColor = Color.White;
            this.lblEmployees.ForeColor = Color.White;
            this.lblSickReports.ForeColor = Color.White;
            this.lblDayOffReports.ForeColor = Color.Gray;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.panelEmployees.Visible = false;
            this.panelSchedule.Visible = true;
            this.panelSickReports.Visible = false;
            this.pnlDayOff.Visible = false;
            this.lblSchedule.ForeColor = Color.Gray;
            this.lblEmployees.ForeColor = Color.White;
            this.lblSickReports.ForeColor = Color.White;
            this.lblDayOffReports.ForeColor = Color.White;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void HRHome_Load(object sender, EventArgs e)
        {
            this.lblEmployees.ForeColor = Color.Gray;
            this.panelEmployees.Visible = true;
            this.panelSchedule.Visible = false;
            this.panelSickReports.Visible = false;
            this.pnlDayOff.Visible = false;
        }

        private void lblAllEmployees_Click(object sender, EventArgs e)
        {

        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {

        }

        private void lbEmployeeInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelEmployees_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSickReports_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSchedule_Paint(object sender, PaintEventArgs e)
        {

        }


        private void cbSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            Schedule schedule = (Schedule)cbSchedule.SelectedItem;
            int scheduleId = schedule.Id;
            UpdateDaysCheckbox(schedule);

        }

        private void UpdateDaysCheckbox(Schedule schedule)
        {
            this.cbDay.Items.Clear();
            for (DateTime date = schedule.StartDate; date <= schedule.EndDate; date = date.AddDays(1))
            {
                cbDay.Items.Add($"{date.DayOfWeek} {date.ToString("dd-MM-yyyy")}");
            }
        }

        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reload the table layout panel, based on the day and position
            //if All is selected, disable the change position button.
            //enable the button if All is not selected.
        }

        private void cbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if a position is selected, reload the table layout panel, based on the day and position
        }

        private void btnChangeNeededPosition_Click(object sender, EventArgs e)
        {
            //based on the selected position and day, open a new form to change the needed amount of that the position
        }
    }
}
