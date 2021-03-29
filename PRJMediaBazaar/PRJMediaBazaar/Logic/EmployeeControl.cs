using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;
namespace PRJMediaBazaar.Logic
{
    class EmployeeControl : EmployeeDAL
    {
        private List<Employee> _employees;

        public EmployeeControl()
        {
            _employees = new List<Employee>();
            LoadEmployees();
          
        }

        private void LoadEmployees()
        {
            List<Employee> employees = new List<Employee>();
            MySqlDataReader dr = SelectAll();
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr[0]);
                String firstName = dr[1].ToString();
                String lastName = dr[2].ToString();
                DateTime birthDate = Convert.ToDateTime(dr[3]);
                String email = dr[4].ToString();
                String password = dr[5].ToString();
                String jobPosition = dr[6].ToString();
                int phoneNumber = Convert.ToInt32(dr[7]);
                String address = dr[8].ToString();
                double salary = Convert.ToDouble(dr[9]);
                String gender = dr[10].ToString();
                String education = dr[11].ToString();
                
                employees.Add(new Employee(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition, phoneNumber, address, education));
            }
            CloseConnection();
            _employees = employees;
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

        public Employee[] Employees { get { return _employees.ToArray(); } }
    }
}
