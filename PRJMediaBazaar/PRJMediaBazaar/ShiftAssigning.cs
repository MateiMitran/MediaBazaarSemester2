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
     partial class ShiftAssigning : Form
    {
        private int _dayId;
        private DateTime _date;
        private Shift _shift;
        private string _jobPosition;
        private HRHome _hr;
        private Day _day;

        public ShiftAssigning(int dayId, DateTime date, Shift shift, string jobPosition, HRHome hr, Day day)
        {
            InitializeComponent();
            _dayId = dayId;
            _date = date;
            _shift = shift;
            _jobPosition = jobPosition;
            _hr = hr;
            _day = day;

            lblDay.Text = $"{date.DayOfWeek} ({_date.Date})";
            lblPosition.Text = $"Position: {_jobPosition}";
            lblShift.Text = $"Shift: {shift}";

            UpdateAvailabilities();
           
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            EmployeePlanner ep = (EmployeePlanner)this.lbAvailableEmployees.SelectedItem;
           
            if (ep != null)
            {
                int employeeId = ep.EmployeeId;
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to assign {ep.EmployeeName} for a {_shift} shift?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Database.AssignShift(_shift, employeeId, _dayId, ep.EmptyShiftIndex);
                    _hr.LoadTableByPosition(_day,_jobPosition);
                    _hr.ShiftsTable.Enabled = true;
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.lbAvailableEmployees.SelectedIndex = -1;
                }

            }
            else
            {
                MessageBox.Show("Please select an employee");
            }
            
        }

        private void UpdateAvailabilities()
        {
            this.lbAvailableEmployees.Items.Clear();
            this.lbUnavailableEmployees.Items.Clear();
            Availabilities a = new Availabilities(_jobPosition, _dayId, _shift);

            foreach (EmployeePlanner ep in a.AvailableEmployees)
            {
                lbAvailableEmployees.Items.Add(ep);
            }

            foreach (EmployeePlanner ep in a.UnavailableEmployees)
            {
                lbUnavailableEmployees.Items.Add(ep);
            }
        }

        private void ShiftAssigning_FormClosed(object sender, FormClosedEventArgs e)
        {
            _hr.ShiftsTable.Enabled = true;
        }
    }
}
