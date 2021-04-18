﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;
namespace PRJMediaBazaar.Logic
{
    class EmployeeControl
    {
        private List<Employee> _employees;
        private EmployeeDAL employeeDAL;
        public EmployeeControl()
        {
            _employees = new List<Employee>();
            employeeDAL = new EmployeeDAL();
            LoadEmployees();
        }

        private void LoadEmployees()
        {       
            _employees = employeeDAL.SelectAll();
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }


        public Employee[] GetEmployeesByPosition(string jobPosition)
        {
            List<Employee> employees = new List<Employee>();
            foreach (Employee e in _employees)
            {
                if (e.JobPosition == jobPosition)
                {
                    employees.Add(e);
                }
            }
            return employees.ToArray();
        }
        public void AddAnEmployee(String firstName, String lastName, DateTime birthDate, String email, String password, String jobPosition, int phoneNumber, String address, int salary, String gender, String education, String contract, int daysOff, int contractHours)
        {
            employeeDAL.AddEmployee(firstName, lastName, birthDate, email, password, jobPosition, phoneNumber, address, salary, gender, education, contract, daysOff, contractHours);
            int id = employeeDAL.GetIDByEmail(email);
            _employees.Add(new Employee(id, firstName, lastName, birthDate,gender,salary,email,password,jobPosition,phoneNumber,address,education,contract,daysOff,contractHours));
        }
        public void UpdateNote(String note,String email)
        {
            employeeDAL.AddNoteToEmployee(email, note);
        }
        public Employee[] Employees { get { return _employees.ToArray(); } }

        public int GetIDFromEmail(String email)
        {
            int id = employeeDAL.GetIDByEmail(email);
            return id;
        }

        public Employee GetEmployee(int id)
        {
            foreach(Employee emp in _employees)
            {
                if(emp.Id == id)
                {
                    return emp;
                }
            }
            return null;
        }
    }
}
