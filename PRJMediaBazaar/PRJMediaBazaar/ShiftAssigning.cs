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

        public ShiftAssigning(int dayId, DateTime date, Shift shift, string jobPosition)
        {
            InitializeComponent();
            _dayId = dayId;
            _date = date;
            _shift = shift;
            _jobPosition = jobPosition;

            lblDay.Text = $"{date.DayOfWeek} ({_date.Date})";
            lblPosition.Text = $"Position: {_jobPosition}";
            lblShift.Text = $"Shift: {shift}";

            UpdateAvailabilities();
           
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            EmployeePlanner ep = (EmployeePlanner)this.lbAvailableEmployees.SelectedItem;
            int employeeId = ep.EmployeeId;
            Database.AssignShift(_shift, employeeId, _dayId, ep.EmptyShiftIndex);
            UpdateAvailabilities();
            
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
    }
}
