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
using Day = PRJMediaBazaar.Logic.Day;

namespace PRJMediaBazaar
{
     partial class ShiftAssigning : Form
    {
        private Shift _shift;
        private HRHome _hr;
        private Day _day;
        private string _jobPosition;
        private ScheduleControl _scheduleControl;
        private List<Employee> _employees;
        public ShiftAssigning(ScheduleControl scheduleControl, List<Employee> empsOnPositon, Shift shift, string jobPosition, HRHome hr, Day day)
        {
            InitializeComponent();
            _shift = shift;
            _jobPosition = jobPosition;
            _hr = hr;
            _day = day;
            _employees = empsOnPositon;
            _scheduleControl = scheduleControl;

            lblDay.Text = $"{_day.Date.ToString("ddd-MM-yyyy")}";
            lblPosition.Text = $"Position: {_jobPosition}";
            lblShift.Text = $"Shift: {shift}";

            UpdateAvailabilities();
           
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            EmployeePlanner ep = (EmployeePlanner)this.lbAvailableEmployees.SelectedItem;
            
            if (ep != null)
            {
                int employeeId = ep.Employee.Id;
                double workedHours = _scheduleControl.GetWorkedHours(_day.WeekId, employeeId);
                DialogResult dialogResult;
                if (ep.Employee.ContractHours < workedHours + 4.5)
                {
                    dialogResult = MessageBox.Show($" {ep.Employee.FullName} exceeds his contract hours. Do you still want to assign him/her for a {_shift} shift?", "Confirmation", MessageBoxButtons.YesNo);
                }
                else
                {
                    dialogResult = MessageBox.Show($"Are you sure you want to assign {ep.Employee.FullName} for a {_shift} shift?", "Confirmation", MessageBoxButtons.YesNo);
                }    
                    
                    if (dialogResult == DialogResult.Yes)
                    {
                        _scheduleControl.AssignShift(_shift.ToString(), ep.Employee, _day, ep.EmptyShiftIndex, workedHours + 4.5);
                        _hr.LoadTableByPosition(_day, _jobPosition);
                        _hr.ShiftsTable.Enabled = true;
                        _hr.UpdateSchedulesStatus();
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
            Availabilities a = new Availabilities(_employees.ToArray(), _day, _shift);

            foreach (EmployeePlanner ep in a.Available)
            {
                lbAvailableEmployees.Items.Add(ep);
            }

            foreach (EmployeePlanner ep in a.Unavailable)
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
