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
     partial class HRHome : Form
    {

        private EmployeeControl _empControl;
        private ScheduleControl _scheduleControl;
        private Employee[] _employees;

        private NamesRow[] _tableRows;
        private LogIn _loginForm;

        public HRHome(LogIn loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;

            _empControl = new EmployeeControl();
            _employees = _empControl.Employees;
            _scheduleControl = new ScheduleControl(_employees.ToList());
            foreach(Employee e in _empControl.Employees)
            {
                cbAllEmployees.Items.Add(e.FirstName + " " + e.LastName);
            }
            
            foreach(Schedule s in _scheduleControl.Schedules)
            {
                cbSchedule.Items.Add(s);
            }
            cbPosition.Text = "All";
            this.btnChangeNeededPosition.Enabled = false;
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

        private void LoadEmployeeListboxes(Employee currentEmployee)
        {
            this.lbEmployeeInfo.Items.Clear();
            this.lbGeneralInfo.Items.Clear();

            this.lbEmployeeInfo.Items.Add("ID : " + currentEmployee.Id);
            this.lbEmployeeInfo.Items.Add("First Name : " + currentEmployee.FirstName);
            this.lbEmployeeInfo.Items.Add("Last Name : " + currentEmployee.LastName);
            this.lbEmployeeInfo.Items.Add("Email : " + currentEmployee.Email);
            this.lbEmployeeInfo.Items.Add("Password : " + currentEmployee.Password);
            this.lbEmployeeInfo.Items.Add("Job Position : " + currentEmployee.JobPosition);
            this.lbEmployeeInfo.Items.Add("Salary : " + currentEmployee.Salary);
            this.lbGeneralInfo.Items.Add("Birth Date : " + currentEmployee.BirthDate);
            this.lbGeneralInfo.Items.Add("Phone Number : " + currentEmployee.PhoneNumber);
            this.lbGeneralInfo.Items.Add("Address : " + currentEmployee.Address);
            this.lbGeneralInfo.Items.Add("Gender : " + currentEmployee.Gender);
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
            UpdateDaysCheckbox(scheduleId);

        }


        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePositionNeededLabel();
            //reload the table layout panel, based on the day and position
            //if All is selected, disable the change position button.
            //enable the button if All is not selected.
            Day day = (Day)this.cbDay.SelectedItem;
            if (day != null)
            {
                if (cbPosition.Text != "All")
                {
                    LoadTableByPosition(day, cbPosition.Text);
                    this.btnChangeNeededPosition.Enabled = true;
                }
                else
                {
                    this.btnChangeNeededPosition.Enabled = false;
                }
            }

        }

        private void cbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePositionNeededLabel();
            //if a position is selected, reload the table layout panel, based on the day and position
            Day day = (Day)this.cbDay.SelectedItem;
            if (cbPosition.Text != "All")
            {
                LoadTableByPosition(day, cbPosition.Text);
            }
        }


        private void btnChangeNeededPosition_Click(object sender, EventArgs e)
        {
   
            //based on the selected position and day, open a new form to change the needed amount of that the position
            ChangeNeededPosition form = new ChangeNeededPosition(this.cbPosition.Text, (Day)cbDay.SelectedItem, _tableRows,this, ((Schedule)cbSchedule.SelectedItem).Id, cbDay.SelectedIndex);
            form.Show();

        }


        public void LoadTableByPosition(Day day, string jobPosition)
        {
            try
            {
                int neededJobPositionAmount = day.GetNeededPositionAmount(jobPosition);
                EmployeeWorkday[] workdays = _scheduleControl.GetEmployeesShifts(day.Id, jobPosition);
                ShiftSeparator ssp = new ShiftSeparator(workdays, neededJobPositionAmount);
                NamesRow[] namesRows = ssp.GetNamesRows();
                _tableRows = namesRows;

                //Clear Table and suspend rendering is easier then editing each row
                ShiftsTable.SuspendLayout();
                ShiftsTable.Parent.SuspendLayout();
                ShiftsTable.Visible = false;
                ShiftsTable.Controls.Clear();
                ShiftsTable.RowCount = 0;
                ShiftsTable.ColumnCount = 4;
                for (int i = 0; i < namesRows.Count(); i++)
                {
                    Button MorningShiftButton = null;
                    Button MiddayShiftButton = null;
                    Button EveningShiftButton = null;
                    //label with the position
                    Label JobPositionLabel = new Label()
                    {
                        BackColor = System.Drawing.Color.Transparent,
                        Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                        ForeColor = System.Drawing.Color.White,
                        Location = new System.Drawing.Point(4, 1),
                        Name = "JobPositionLabel",
                        Size = new System.Drawing.Size(365, 38),
                        TabIndex = 0,
                        Text = jobPosition,
                        TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                    };

                    if (namesRows[i].Morning == null && namesRows[i].Midday == null && namesRows[i].Evening == null) // row with unassigned shifts
                    {
                        MorningShiftButton = GetUnassignedShiftButton(day, Shift.Morning, jobPosition);
                        MiddayShiftButton = GetUnassignedShiftButton(day, Shift.Midday, jobPosition);
                        EveningShiftButton = GetUnassignedShiftButton(day, Shift.Evening, jobPosition);

                    }

                    else //row with assigned shifts
                    {
                        int emptyEmployeeIndex = GetEmptyShiftIndex(namesRows[i].Morning, namesRows[i].Midday, namesRows[i].Evening);
                        int busyEmployeeIndex = GetBusyShiftIndex(namesRows[i].Morning, namesRows[i].Midday, namesRows[i].Evening);

                        if (emptyEmployeeIndex != -1) //2 assigned buttons, 1 unassigned button
                        {
                            //separate the buttons
                            switch (emptyEmployeeIndex)
                            {
                                case 1:
                                    MorningShiftButton = GetUnassignedShiftButton(day, Shift.Morning, jobPosition);
                                    MiddayShiftButton = GetAssignedShiftButton(day, Shift.Midday, jobPosition, namesRows[i].Midday);
                                    EveningShiftButton = GetAssignedShiftButton(day, Shift.Evening, jobPosition, namesRows[i].Evening);
                                    break;
                                case 2:
                                    MorningShiftButton = GetAssignedShiftButton(day, Shift.Morning, jobPosition, namesRows[i].Morning);
                                    MiddayShiftButton = GetUnassignedShiftButton(day, Shift.Midday, jobPosition);
                                    EveningShiftButton = GetAssignedShiftButton(day, Shift.Evening, jobPosition, namesRows[i].Evening);
                                    break;
                                case 3:
                                    MorningShiftButton = GetAssignedShiftButton(day, Shift.Morning, jobPosition, namesRows[i].Morning);
                                    MiddayShiftButton = GetAssignedShiftButton(day, Shift.Midday, jobPosition, namesRows[i].Midday);
                                    EveningShiftButton = GetUnassignedShiftButton(day, Shift.Evening, jobPosition);
                                    break;
                            }
                        }
                        else if (busyEmployeeIndex != -1) //2 unassigned buttons, 1 assigned button
                        {
                            //separate the buttons
                            switch (busyEmployeeIndex)
                            {
                                case 1:
                                    MorningShiftButton = GetAssignedShiftButton(day, Shift.Morning, jobPosition, namesRows[i].Morning);
                                    MiddayShiftButton = GetUnassignedShiftButton(day, Shift.Midday, jobPosition);
                                    EveningShiftButton = GetUnassignedShiftButton(day, Shift.Evening, jobPosition);
                                    break;
                                case 2:
                                    MorningShiftButton = GetUnassignedShiftButton(day, Shift.Morning, jobPosition);
                                    MiddayShiftButton = GetAssignedShiftButton(day, Shift.Midday, jobPosition, namesRows[i].Midday);
                                    EveningShiftButton = GetUnassignedShiftButton(day, Shift.Evening, jobPosition);
                                    break;
                                case 3:
                                    MorningShiftButton = GetUnassignedShiftButton(day, Shift.Morning, jobPosition);
                                    MiddayShiftButton = GetUnassignedShiftButton(day, Shift.Midday, jobPosition);
                                    EveningShiftButton = GetAssignedShiftButton(day, Shift.Evening, jobPosition, namesRows[i].Evening);
                                    break;
                            }
                        }
                        else //row is full
                        {
                            MorningShiftButton = GetAssignedShiftButton(day, Shift.Morning, jobPosition, namesRows[i].Morning);
                            MiddayShiftButton = GetAssignedShiftButton(day, Shift.Midday, jobPosition, namesRows[i].Midday);
                            EveningShiftButton = GetAssignedShiftButton(day, Shift.Evening, jobPosition, namesRows[i].Evening);
                        }
                    }

                    ShiftsTable.Controls.Add(JobPositionLabel, 0, ShiftsTable.RowCount - 1);
                    ShiftsTable.Controls.Add(MorningShiftButton, 1, ShiftsTable.RowCount - 1);
                    ShiftsTable.Controls.Add(MiddayShiftButton, 2, ShiftsTable.RowCount - 1);
                    ShiftsTable.Controls.Add(EveningShiftButton, 3, ShiftsTable.RowCount - 1);



                }

                //Enable rendering after inserting rows
                ShiftsTable.Visible = true;
                ShiftsTable.Parent.ResumeLayout();
                ShiftsTable.ResumeLayout();
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private Button GetUnassignedShiftButton(Day day, Shift shift, string jobPosition)
        {
            Button UnassignedShiftButton = new Button()
            {
                Cursor = System.Windows.Forms.Cursors.Hand,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Microsoft YaHei", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.White,
                BackColor = System.Drawing.Color.Red,
                Location = new System.Drawing.Point(0, 0),
                Name = "UnassignedShiftButton",
                TabIndex = 0,
                Text = "Unassigned",
                UseVisualStyleBackColor = true,
                Size = new System.Drawing.Size(365, 38)
            };
            UnassignedShiftButton.FlatAppearance.BorderSize = 0;
            UnassignedShiftButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            UnassignedShiftButton.Click += delegate (object sender, EventArgs e) { UnassignedShiftButton_Click(sender, e, new ShiftAssigning(_scheduleControl,_empControl.GetEmployeesByPosition(jobPosition).ToList(), shift, jobPosition,this,day)); };
            return UnassignedShiftButton;


        }

        private Button GetAssignedShiftButton(Day day, Shift shift, string jobPosition, Employee employee)
        {
            Button AssignedShiftButton = new Button()
            {
                Cursor = System.Windows.Forms.Cursors.Hand,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Microsoft YaHei", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Black,
                BackColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(0, 0),
                Name = "AssignedShiftButton",
                TabIndex = 0,
                Text = employee.FirstName + " "+ employee.LastName,
                UseVisualStyleBackColor = true,
                Size = new System.Drawing.Size(365, 38)
            };
            AssignedShiftButton.FlatAppearance.BorderSize = 0;
            AssignedShiftButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            AssignedShiftButton.Click += delegate (object sender, EventArgs e) { AssignedShiftButton_Click(sender, e, employee, shift); };
            return AssignedShiftButton;
        }


        private void UnassignedShiftButton_Click(object sender, EventArgs e, ShiftAssigning assigningForm)
        {
            ShiftsTable.Enabled = false;
            assigningForm.Show();
        }

        private void AssignedShiftButton_Click(object sender, EventArgs e, Employee employee, Shift shift)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Remove Employee", null, delegate (object sender2, EventArgs e2) { RemoveShift(shift,employee); });     
            contextMenuStrip.Show(Cursor.Position);
        }

        private void RemoveShift(Shift shift, Employee employee)
        {
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove " +
                $"{employee.FirstName} {employee.LastName}'s {shift.ToString()} shift?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _scheduleControl.RemoveShift(shift.ToString(),((Day)cbDay.SelectedItem).Id, employee.Id);
            }
            LoadTableByPosition((Day)cbDay.SelectedItem, employee.JobPosition);
        }

        public void UpdateDaysCheckbox(int scheduleId)
        {
            Day[] days =_scheduleControl.GetDays(scheduleId);
            this.cbDay.Items.Clear();
            foreach (Day d in days)
            {
                this.cbDay.Items.Add(d);
            }
        }

        public void UpdatePositionNeededLabel()
        {
            Day day = (Day)cbDay.SelectedItem;
            if (this.cbPosition.Text != "All" && day != null)
            {
              
                this.lblPositionNeeded.Text = day.GetNeededPositionInfo(cbPosition.Text);
            }
            else if (this.cbPosition.Text == "All" && day != null)
            {
                this.lblPositionNeeded.Text = day.GetAllNeededPositionsInfo();
            }
        }

        private int GetEmptyShiftIndex(Employee morning, Employee mid, Employee evening)
        {
            if (morning != null && mid != null && evening == null)
            {
                return 3;
            }
           else  if (morning != null && mid == null && evening != null)
            {
                return 2;
            }
            else if (morning == null && mid != null && evening != null)
            {
                return 1;
            }
            return -1;
        }

        private int GetBusyShiftIndex(Employee morning, Employee mid, Employee evening)
        {
          
            if (morning != null && mid == null && evening == null)
            {
                return 1;
            }
            else if (morning == null && mid == null && evening != null)
            {
                return 3;
            }
            else if (morning == null && mid != null && evening == null)
            {
                return 2;
            }
            return -1;
        }

        private void btnAddPromotionPoints_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAddLatePoints_Click(object sender, EventArgs e)
        {
            
        }

        private void HRHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginForm.Close();
        }

        private void cbAllEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (this.cbAllEmployees.SelectedItem == null)
                {
                    throw new EmptyComboBoxException("Please select an employee!");
                }
                String name = this.cbAllEmployees.SelectedItem.ToString();
                Employee currentEmployee = null;
                for (int i = 0; i < _employees.Length; i++)
                {
                    if (_employees[i].FirstName + " " + _employees[i].LastName == name)
                    {
                        currentEmployee = _employees[i];
                        break;
                    }
                }
                if (currentEmployee == null)
                    MessageBox.Show("No employee found!");
                else
                {
                    LoadEmployeeListboxes(currentEmployee);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocurred!" + ex.ToString());
            }
        }
    }
}
