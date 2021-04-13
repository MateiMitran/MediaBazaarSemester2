using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using EmployeeControl = PRJMediaBazaar.Logic.EmployeeControl;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar
{
    partial class AddEmployees : Form
    {
        private EmployeeControl ec;
        private HRHome hr;
        private List<Employee> employees;
        public AddEmployees(HRHome hr,EmployeeControl ec,List<Employee>employees)
        {
            InitializeComponent();
            this.ec = ec;
            this.hr = hr;
            this.employees = employees;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                String firstName = this.tbSurname.Text;
                if (Regex.IsMatch(firstName, @"\d"))
                    throw new InvalidStringException("Enter a valid first name!");
                String lastName = this.tbName.Text;
                if (Regex.IsMatch(lastName, @"\d"))
                    throw new InvalidStringException("Enter a valid last name!");
                DateTime birthDate = this.dtpBirthdate.Value.Date;
                String email = this.tbEmail.Text;
                if (CheckEmail(email) == false)
                    throw new InvalidEmailException("Enter a valid email!");
                String password = this.tbPassword.Text;
                if (this.cbJobPosition.SelectedItem == null)
                    throw new EmptyComboBoxException("Select a job position!");
                String jobPosition = this.cbJobPosition.Text;
                int phone = Convert.ToInt32(this.tbPhone.Text);
                if (phone < 0 || this.tbPhone.Text.Length!=10)
                    throw new NegativeInputException("Enter a valid phone number!");
                String address = this.tbAddress.Text;
                int salary = Convert.ToInt32(this.tbSalary.Text);
                if (salary < 0)
                    throw new NegativeInputException("Enter a valid salary!");
                else if (!Regex.IsMatch(salary.ToString(), @"^\d+$"))
                    throw new InvalidIntException("Enter a valid salary!");
                if (this.cbGender.SelectedItem == null)
                    throw new EmptyComboBoxException("Select a gender!");
                String gender = this.cbGender.Text;
                String education = this.tbEducation.Text;
                if (Regex.IsMatch(education, @"\d"))
                    throw new InvalidStringException("Enter a valid education!");
                int daysOff = 30;
               
                if (this.rbFulltime.Checked == true)
                {
                    String contract = this.rbFulltime.Text;
                    int contractHours = 40;
                    ec.AddAnEmployee(firstName, lastName, birthDate, email, password, jobPosition, phone, address,
                                    salary, gender, education, contract, daysOff, contractHours);
                    int id = ec.GetIDFromEmail(email);
                    hr.AddEmployee(new Employee(id,firstName, lastName, birthDate, gender, salary, email, password, jobPosition,
                                    phone, address, education, contract, daysOff, contractHours));
                    MessageBox.Show("Success!");
                }
                else if (this.rbParttime.Checked == true)
                {
                    String contract = this.rbParttime.Text;
                    int contractHours = Convert.ToInt32(this.tbContractHours.Text);
                    if (!Regex.IsMatch(contractHours.ToString(), @"^\d+$"))
                        throw new InvalidIntException("Enter a valid number for contract hours!!");
                    ec.AddAnEmployee(firstName, lastName, birthDate, email, password, jobPosition, phone, address,
                                    salary, gender, education, contract, daysOff, contractHours);
                    int id = ec.GetIDFromEmail(email);
                    hr.AddEmployee(new Employee(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition,
                                   phone, address, education, contract, daysOff, contractHours));
                    MessageBox.Show("Success!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured!" + ex.ToString());
            }
        }

        private void rbFulltime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbFulltime.Checked == true)
            {
                this.tbContractHours.Visible = false;
                this.label12.Visible = false;
            }
        }

        private void rbParttime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbParttime.Checked == true)
            {
                this.tbContractHours.Visible = true;
                this.label12.Visible = true;
            }
        }
        private bool CheckEmail(String email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
