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
                String contract = dr[12].ToString();
                int daysOff = Convert.ToInt32(dr[13]);
                int contractHours = Convert.ToInt32(dr[14]);
                String note = dr[15].ToString();
                Employee temp = new Employee(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition, phoneNumber, address, education, contract, daysOff, contractHours);
                temp.Note = note;
                employees.Add(temp);
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
        public void AddAnEmployee(String firstName, String lastName, DateTime birthDate, String email, String password, String jobPosition, int phoneNumber, String address, int salary, String gender, String education, String contract, int daysOff, int contractHours)
        {
            AddEmployee(firstName, lastName, birthDate, email, password, jobPosition, phoneNumber, address, salary, gender, education, contract, daysOff, contractHours);
            int id = Convert.ToInt32(GetIDByEmail(email));
            _employees.Add(new Employee(id, firstName, lastName, birthDate,gender,salary,email,password,jobPosition,phoneNumber,address,education,contract,daysOff,contractHours));
            CloseConnection();
        }
        public void UpdateNote(String note,String email)
        {
            AddNoteToEmployee(note, email);
            CloseConnection();
        }
        public Employee[] Employees { get { return _employees.ToArray(); } }

        public int GetIDFromEmail(String email)
        {
            int id = Convert.ToInt32(GetIDByEmail(email));
            return id;
        }
    }
}
