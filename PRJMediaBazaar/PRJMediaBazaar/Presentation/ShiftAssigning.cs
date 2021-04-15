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
        private List<EmployeePlanner> _available;
        private List<EmployeePlanner> _unavailable;
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

            Availabilities a = new Availabilities(_employees.ToArray(), _day, _shift);
            _available = a.Available.ToList();
            _unavailable = a.Unavailable.ToList();
            LoadAvailableTable();
            LoadUnavailableTable();

        }


        private void Assign_Click(object sender, EventArgs e, EmployeePlanner ep)
        {
            if (ep != null)
            {
                int employeeId = ep.Employee.Id;
                double workedHours = ep.HoursWorked;
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
                    _hr.UpdateDaysInfoListbox();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Please select an employee");
            }
        }

     

        private void ShiftAssigning_FormClosed(object sender, FormClosedEventArgs e)
        {
            _hr.ShiftsTable.Enabled = true;
        }

        private void LoadAvailableTable()
        {
            //Clear Table and suspend rendering is easier then editing each row
            AvailableTable.SuspendLayout();
            AvailableTable.Parent.SuspendLayout();
            AvailableTable.Visible = false;
            AvailableTable.Controls.Clear();
            AvailableTable.RowCount = 0;
            AvailableTable.ColumnCount = 6;

            //LoadInfoLabels(AvailableTable);
            foreach (EmployeePlanner ep in _available)
            {

                List<Label> labels = this.Labels(ep);

                Button Assign = new Button()
                {
                    BackColor = System.Drawing.Color.LightCyan,
                    Cursor = System.Windows.Forms.Cursors.Hand,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Dock = DockStyle.Fill,
                    Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    ForeColor = System.Drawing.Color.Black,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "Properties",
                    TabIndex = 0,
                    Text = "Assign",
                    UseVisualStyleBackColor = true
                };
               Assign.FlatAppearance.BorderSize = 0;
               Assign.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
               Assign.Click += delegate (object sender, EventArgs e) { Assign_Click(sender, e, ep); };


                AvailableTable.Controls.Add(labels[0], 0, AvailableTable.RowCount - 1);
                AvailableTable.Controls.Add(labels[1], 1, AvailableTable.RowCount - 1);
                AvailableTable.Controls.Add(labels[2], 2, AvailableTable.RowCount - 1);
                AvailableTable.Controls.Add(labels[3], 3, AvailableTable.RowCount - 1);
                AvailableTable.Controls.Add(labels[4], 4, AvailableTable.RowCount - 1);
                AvailableTable.Controls.Add(Assign, 5, AvailableTable.RowCount - 1);


            }

            //Enable rendering after inserting rows
            AvailableTable.Visible = true;
            AvailableTable.Parent.ResumeLayout();
            AvailableTable.ResumeLayout();
        }

        private void LoadUnavailableTable()
        {
            //Clear Table and suspend rendering is easier then editing each row
           UnavailableTable.SuspendLayout();
           UnavailableTable.Parent.SuspendLayout();
           UnavailableTable.Visible = false;
           UnavailableTable.Controls.Clear();
           UnavailableTable.RowCount = 0;
           UnavailableTable.ColumnCount = 5;

            //LoadInfoLabels(UnavailableTable);
            foreach (EmployeePlanner ep in _unavailable)
            {

                List<Label> labels = this.Labels(ep);

          
                UnavailableTable.Controls.Add(labels[0], 0, UnavailableTable.RowCount - 1);
                UnavailableTable.Controls.Add(labels[1], 1, UnavailableTable.RowCount - 1);
                UnavailableTable.Controls.Add(labels[2], 2, UnavailableTable.RowCount - 1);
                UnavailableTable.Controls.Add(labels[3], 3, UnavailableTable.RowCount - 1);
                UnavailableTable.Controls.Add(labels[4], 4, UnavailableTable.RowCount - 1);
               

            }

            //Enable rendering after inserting rows
            UnavailableTable.Visible = true;
            UnavailableTable.Parent.ResumeLayout();
            UnavailableTable.ResumeLayout();
        }

        private List<Label> Labels(EmployeePlanner ep)
        {
            List<Label> labels = new List<Label>();

            Label IdLabel = new Label()
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Rockwell Condensed", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Black,
                Location = new System.Drawing.Point(4, 1),
                Name = "IdLabel",
                Size = new System.Drawing.Size(365, 38),
                TabIndex = 0,
                Text = ep.Employee.Id.ToString(),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            //Name label
            Label NameLabel = new Label()
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Rockwell Condensed", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Black,
                Location = new System.Drawing.Point(4, 1),
                Name = "NameLabel",
                Size = new System.Drawing.Size(365, 38),
                TabIndex = 0,
                Text = ep.Employee.FullName,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            //Taskname label
            Label OccupationLabel = new Label()
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Rockwell Condensed", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Black,
                Location = new System.Drawing.Point(4, 1),
                Name = "OccupationLabel",
                Size = new System.Drawing.Size(365, 38),
                TabIndex = 0,
                Text = ep.Occupation,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            Label WorkedHoursLabel = new Label()
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Rockwell Condensed", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Black,
                Location = new System.Drawing.Point(4, 1),
                Name = "WorkedHoursLabel",
                Size = new System.Drawing.Size(365, 38),
                TabIndex = 0,
                Text = ep.HoursWorked.ToString() + " hrs",
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            Label ContractHoursLabel = new Label()
            {
                BackColor = System.Drawing.Color.Transparent,
                Font = new System.Drawing.Font("Rockwell Condensed", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.Black,
                Location = new System.Drawing.Point(4, 1),
                Name = "ContractHoursLabel",
                Size = new System.Drawing.Size(365, 38),
                TabIndex = 0,
                Text = ep.Employee.ContractHours.ToString() + " hrs",
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };
            labels.Add(IdLabel);
            labels.Add(NameLabel);
            labels.Add(OccupationLabel);
            labels.Add(WorkedHoursLabel);
            labels.Add(ContractHoursLabel);
            return labels;
        }




        //private void LoadInfoLabels(TableLayoutPanel table)
        //{


        //    Label IdLabel = new Label()
        //    {
        //        BackColor = System.Drawing.Color.Gray,
        //        Font = new System.Drawing.Font("Rockwell Condensed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
        //        ForeColor = System.Drawing.Color.Black,
        //        Location = new System.Drawing.Point(4, 1),
        //        Name = "IdLabel",
        //        Size = new System.Drawing.Size(365, 38),
        //        TabIndex = 0,
        //        Text = "Id",
        //        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        //    };
        //    //Name label
        //    Label NameLabel = new Label()
        //    {
        //        BackColor = System.Drawing.Color.Gray,
        //        Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
        //        ForeColor = System.Drawing.Color.Black,
        //        Location = new System.Drawing.Point(4, 1),
        //        Name = "NameLabel",
        //        Size = new System.Drawing.Size(365, 38),
        //        TabIndex = 0,
        //        Text = "Name",
        //        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        //    };
        //    //Taskname label
        //    Label OccupationLabel = new Label()
        //    {
        //        BackColor = System.Drawing.Color.Gray,
        //        Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
        //        ForeColor = System.Drawing.Color.Black,
        //        Location = new System.Drawing.Point(4, 1),
        //        Name = "OccupationLabel",
        //        Size = new System.Drawing.Size(365, 38),
        //        TabIndex = 0,
        //        Text = "Occupation",
        //        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        //    };
        //    Label WorkedHoursLabel = new Label()
        //    {
        //        BackColor = System.Drawing.Color.Gray,
        //        Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
        //        ForeColor = System.Drawing.Color.Black,
        //        Location = new System.Drawing.Point(4, 1),
        //        Name = "WorkedHoursLabel",
        //        Size = new System.Drawing.Size(365, 38),
        //        TabIndex = 0,
        //        Text = "Worked",
        //        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        //    };

        //    Label ContractHoursLabel = new Label()
        //    {
        //        BackColor = System.Drawing.Color.Gray,
        //        Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
        //        ForeColor = System.Drawing.Color.Black,
        //        Location = new System.Drawing.Point(4, 1),
        //        Name = "ContractHoursLabel",
        //        Size = new System.Drawing.Size(365, 38),
        //        TabIndex = 0,
        //        Text = "Contract",
        //        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        //    };

        //    Label Empty = new Label()
        //    {
        //        BackColor = System.Drawing.Color.Transparent,
        //        Font = new System.Drawing.Font("Rockwell Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
        //        ForeColor = System.Drawing.Color.Transparent,
        //        Location = new System.Drawing.Point(4, 1),
        //        Name = "ContractHoursLabel",
        //        Size = new System.Drawing.Size(365, 38),
        //        TabIndex = 0,
        //        Text = "",
        //        TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        //    };


        //    table.Controls.Add(IdLabel, 0, 0);
        //    table.Controls.Add(NameLabel, 1,0);
        //    table.Controls.Add(OccupationLabel, 2, 0);
        //    table.Controls.Add(WorkedHoursLabel, 3,0);
        //    table.Controls.Add(ContractHoursLabel, 4, 0);
        //    if(table == AvailableTable) { table.Controls.Add(Empty, 5, 0); }
        //}

    }
}
