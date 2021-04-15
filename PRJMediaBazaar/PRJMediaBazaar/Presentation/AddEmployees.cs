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
        private Button x;
        private Timer timer;
        public AddEmployees(HRHome hr, EmployeeControl ec, List<Employee> employees)
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
                {
                    x = new Button();
                    x.Location = new Point(-6, -1);
                    x.Width = 556;
                    x.Height = 28;
                    x.Enabled = false;
                    x.BackColor = Color.Red;
                    x.Text = "Enter a valid first name!";
                    this.Controls.Add(x);
                    x.BringToFront();
                    timer1.Start();
                    throw new InvalidStringException();
                }
                String lastName = this.tbName.Text;
                if (Regex.IsMatch(lastName, @"\d"))
                {
                    x = new Button();
                    x.Location = new Point(-6, -1);
                    x.Width = 556;
                    x.Height = 28;
                    x.Enabled = false;
                    x.BackColor = Color.Red;
                    x.Text = "Enter a valid last name!";
                    this.Controls.Add(x);
                    x.BringToFront();
                    timer1.Start();
                    throw new InvalidStringException();
                }
                DateTime birthDate = this.dtpBirthdate.Value.Date;
                String email = this.tbEmail.Text;
                if (CheckEmail(email) == false)
                {
                    x = new Button();
                    x.Location = new Point(-6, -1);
                    x.Width = 556;
                    x.Height = 28;
                    x.Enabled = false;
                    x.BackColor = Color.Red;
                    x.Text = "Enter a valid email!";
                    this.Controls.Add(x);
                    x.BringToFront();
                    timer1.Start();
                    throw new InvalidEmailException();
                }
                String password = this.tbPassword.Text;
                if (this.cbJobPosition.SelectedItem == null)
                {
                    x = new Button();
                    x.Location = new Point(-6, -1);
                    x.Width = 556;
                    x.Height = 28;
                    x.Enabled = false;
                    x.BackColor = Color.Red;
                    x.Text = "Select a job position!";
                    this.Controls.Add(x);
                    x.BringToFront();
                    timer1.Start();
                    throw new EmptyComboBoxException();
                }
                String jobPosition = this.cbJobPosition.Text;
                int phone = Convert.ToInt32(this.tbPhone.Text);
                if (phone < 0 || this.tbPhone.Text.Length != 10)
                {
                    x = new Button();
                    x.Location = new Point(-6, -1);
                    x.Width = 556;
                    x.Height = 28;
                    x.Enabled = false;
                    x.BackColor = Color.Red;
                    x.Text = "Enter a valid phone number!";
                    this.Controls.Add(x);
                    x.BringToFront();
                    timer1.Start();
                    throw new NegativeInputException();
                }
                String address = this.tbAddress.Text;
                if (!Regex.IsMatch(this.tbSalary.Text.ToString(), @"^\d+$"))
                {
                    x = new Button();
                    x.Location = new Point(-6, -1);
                    x.Width = 556;
                    x.Height = 28;
                    x.Enabled = false;
                    x.BackColor = Color.Red;
                    x.Text = "Enter a valid salary!";
                    this.Controls.Add(x);
                    x.BringToFront();
                    timer1.Start();
                    throw new InvalidIntException();
                }
                int salary = Convert.ToInt32(this.tbSalary.Text);
                if (salary < 0)
                {
                    x = new Button();
                    x.Location = new Point(-6, -1);
                    x.Width = 556;
                    x.Height = 28;
                    x.Enabled = false;
                    x.BackColor = Color.Red;
                    x.Text = "Enter a valid salary!";
                    this.Controls.Add(x);
                    x.BringToFront();
                    timer1.Start();
                    throw new NegativeInputException();
                }
                if (this.cbGender.SelectedItem == null)
                {
                    x = new Button();
                    x.Location = new Point(-6, -1);
                    x.Width = 556;
                    x.Height = 28;
                    x.Enabled = false;
                    x.BackColor = Color.Red;
                    x.Text = "Select a gender!";
                    this.Controls.Add(x);
                    x.BringToFront();
                    timer1.Start();
                    throw new EmptyComboBoxException();
                }
                String gender = this.cbGender.Text;
                String education = this.tbEducation.Text;
                if (Regex.IsMatch(education, @"\d"))
                {
                    x = new Button();
                    x.Location = new Point(-6, -1);
                    x.Width = 556;
                    x.Height = 28;
                    x.Enabled = false;
                    x.BackColor = Color.Red;
                    x.Text = "Enter a valid education!";
                    this.Controls.Add(x);
                    x.BringToFront();
                    timer1.Start();
                    throw new InvalidStringException();
                }
                int daysOff = 30;

                if (this.rbFulltime.Checked == true)
                {
                    String contract = this.rbFulltime.Text;
                    int contractHours = 40;
                    ec.AddAnEmployee(firstName, lastName, birthDate, email, password, jobPosition, phone, address,
                                    salary, gender, education, contract, daysOff, contractHours);
                    int id = ec.GetIDFromEmail(email);
                    hr.AddEmployee(new Employee(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition,
                                    phone, address, education, contract, daysOff, contractHours));
                    x = new Button();
                    x.Location = new Point(-6, -1);
                    x.Width = 556;
                    x.Height = 28;
                    x.Enabled = false;
                    x.BackColor = Color.Green;
                    x.Text = "Sucess!";
                    this.Controls.Add(x);
                    x.BringToFront();
                    timer1.Start();
                }
                else if (this.rbParttime.Checked == true)
                {
                    String contract = this.rbParttime.Text;
                    int contractHours = Convert.ToInt32(this.tbContractHours.Text);
                    if (!Regex.IsMatch(contractHours.ToString(), @"^\d+$"))
                    {
                        x = new Button();
                        x.Location = new Point(-6, -1);
                        x.Width = 556;
                        x.Height = 28;
                        x.Enabled = false;
                        x.BackColor = Color.Red;
                        x.Text = "Enter a valid number for contract hours!!";
                        this.Controls.Add(x);
                        x.BringToFront();
                        timer1.Start();
                        throw new InvalidIntException();
                    }
                    ec.AddAnEmployee(firstName, lastName, birthDate, email, password, jobPosition, phone, address,
                                    salary, gender, education, contract, daysOff, contractHours);
                    int id = ec.GetIDFromEmail(email);
                    hr.AddEmployee(new Employee(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition,
                                   phone, address, education, contract, daysOff, contractHours));
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
            }
            catch (InvalidIntException ex)
            {
                x = new Button();
                x.Location = new Point(-6, -1);
                x.Width = 556;
                x.Height = 28;
                x.Enabled = false;
                x.BackColor = Color.Red;
                x.Text = "Enter valid numbers for phone and salary and/or contract hours!";
                this.Controls.Add(x);
                x.BringToFront();
                timer1.Start();
            }
            catch (EmptyComboBoxException ex)
            {
                x = new Button();
                x.Location = new Point(-6, -1);
                x.Width = 556;
                x.Height = 28;
                x.Enabled = false;
                x.BackColor = Color.Red;
                x.Text = "Select a gender and job position!";
                this.Controls.Add(x);
                x.BringToFront();
                timer1.Start();
            }
            catch (InvalidEmailException ex)
            {
                x = new Button();
                x.Location = new Point(-6, -1);
                x.Width = 556;
                x.Height = 28;
                x.Enabled = false;
                x.BackColor = Color.Red;
                x.Text = "Enter a valid email!";
                this.Controls.Add(x);
                x.BringToFront();
                timer1.Start();
            }
            catch (InvalidStringException ex)
            {
                x = new Button();
                x.Location = new Point(-6, -1);
                x.Width = 556;
                x.Height = 28;
                x.Enabled = false;
                x.BackColor = Color.Red;
                x.Text = "Enter a valid name, address and education";
                this.Controls.Add(x);
                x.BringToFront();
                timer1.Start();
            }
            catch (NegativeInputException ex)
            {
                x = new Button();
                x.Location = new Point(-6, -1);
                x.Width = 556;
                x.Height = 28;
                x.Enabled = false;
                x.BackColor = Color.Red;
                x.Text = "Input cannot be negative!";
                this.Controls.Add(x);
                x.BringToFront();
                timer1.Start();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            x.Visible = false;
        }
    }
}
