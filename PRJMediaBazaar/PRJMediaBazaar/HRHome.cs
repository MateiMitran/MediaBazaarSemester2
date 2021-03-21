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

        public HRHome()
        {
            InitializeComponent();

            _employees = Database.GetEmployees();
            foreach (RegularEmployee e in _employees)
            {
                cbAllEmployees.Items.Add(e.FirstName + " " + e.LastName);
            }
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
            try
            {
                if (this.cbAllEmployees.SelectedItem == null)
                {
                    throw new EmptyComboBoxException("Please select an employee!");
                }
                String name = this.cbAllEmployees.SelectedItem.ToString();
                RegularEmployee currentEmployee = null;
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
                    if (currentEmployee.LatePoints>5)
                    {
                        MessageBox.Show("Cannot add more late points!");
                    }
                    else
                    {
                        currentEmployee.LatePoints++;
                        int id = currentEmployee.Id;
                        Database.AddLatePoints(id, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured!" + ex.ToString());
            }
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
            try
            {
                this.lbEmployeeInfo.Items.Clear();
                this.lbGeneralInfo.Items.Clear();
                if (this.cbAllEmployees.SelectedItem == null)
                {
                    throw new EmptyComboBoxException("Please select an employee!");
                }
                String name = this.cbAllEmployees.SelectedItem.ToString();
                RegularEmployee currentEmployee = null;
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
                    this.lbEmployeeInfo.Items.Add("ID : " + currentEmployee.Id);
                    this.lbEmployeeInfo.Items.Add("First Name : " + currentEmployee.FirstName);
                    this.lbEmployeeInfo.Items.Add("Last Name : " + currentEmployee.LastName);
                    this.lbEmployeeInfo.Items.Add("Email : " + currentEmployee.Email);
                    this.lbEmployeeInfo.Items.Add("Password : " + currentEmployee.Password);
                    this.lbEmployeeInfo.Items.Add("Job Position : " + currentEmployee.JobPosition);
                    this.lbEmployeeInfo.Items.Add("Salary : " + currentEmployee.Salary);
                    this.lbEmployeeInfo.Items.Add("Promotion Points : " + currentEmployee.PromotionPoints);
                    this.lbEmployeeInfo.Items.Add("Late Points : " + currentEmployee.LatePoints);
                    this.lbGeneralInfo.Items.Add("Birth Date : " + currentEmployee.BirthDate);
                    this.lbGeneralInfo.Items.Add("Phone Number : " + currentEmployee.PhoneNumber);
                    this.lbGeneralInfo.Items.Add("Address : " + currentEmployee.Address);
                    this.lbGeneralInfo.Items.Add("Gender : " + currentEmployee.Gender);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error ocurred!" + ex.ToString());
            }

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

        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmDayOff_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPromotionPoints_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbAllEmployees.SelectedItem == null)
                {
                    throw new EmptyComboBoxException("Please select an employee!");
                }
                String name = this.cbAllEmployees.SelectedItem.ToString();
                RegularEmployee currentEmployee = null;
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
                    if (currentEmployee.PromotionPoints > 5)
                        MessageBox.Show("Cannot add more promotion points!");
                    else
                    {
                        currentEmployee.PromotionPoints++;
                        int id = currentEmployee.Id;
                        Database.AddPromotionPoints(id, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured!" + ex.ToString());
            }
        }
    }
}
