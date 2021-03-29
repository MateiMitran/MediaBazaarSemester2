using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace PRJMediaBazaar.Logic
{
    class Availabilities : ScheduleDAL
    {
        private Employee[] _employees;
        private List<EmployeePlanner> _available;
        private List<EmployeePlanner> _unavailable;

        public Availabilities(Employee[] employeesOnPosition, int dayId, Shift shift)
        {
            _available = new List<EmployeePlanner>();
            _unavailable = new List<EmployeePlanner>();
            _employees = employeesOnPosition;
            PopulateLists(dayId, shift);

        }

        public EmployeePlanner[] Available { get { return _available.ToArray(); } }
        public EmployeePlanner[] Unavailable { get { return _unavailable.ToArray(); } }


        private void PopulateLists(int dayId, Shift shift)
        {


            MySqlDataReader result = SelectEmployeesWorkdays(dayId, _employees[0].JobPosition);
            List<Employee> busyEmployees = new List<Employee>();

            while (result.Read()) //employees in the workdays_table
            {
                Employee employee = GetEmployeeById(Convert.ToInt32(result[1]));
                if (!Convert.ToBoolean(result[4])) //the employee isn't absent
                {
                    int index = ShiftFinder.GetEmptyShiftIndex(result[2].ToString(), result[3].ToString());
                    int busyIndex = ShiftFinder.GetBusyShiftIndex(result[2].ToString(), result[3].ToString());

                    if (index == -1)  //employee has a double shift
                    {
                        EmployeePlanner ea = new EmployeePlanner(employee, "Double shift", -1);
                        _unavailable.Add(ea);
                    }

                    else if (index != -1 && ShiftFinder.DoubleShiftIsValid(result[busyIndex].ToString(), shift.ToString())) //employee has only one shift, and the second one is valid
                    {

                        EmployeePlanner ea = new EmployeePlanner(employee, result[busyIndex].ToString(), index);
                        _available.Add(ea);
                    }
                    else // the double shift is invalid
                    {
                        EmployeePlanner ea = new EmployeePlanner(employee, result[busyIndex].ToString(), -1);
                        _unavailable.Add(ea);
                    }
                }

                else if (Convert.ToBoolean(result[4])) //is absent
                {
                    EmployeePlanner ea = new EmployeePlanner(employee, result[5].ToString(), -1);
                    _unavailable.Add(ea);
                }
                busyEmployees.Add(employee);

            }

            foreach (Employee employee in _employees) //if the employee is not in the busyEmployee list, add availability
            {
                if (!busyEmployees.Contains(employee))
                {
                    EmployeePlanner ea = new EmployeePlanner(employee, "None", -1);
                    _available.Add(ea);
                }
            }
            CloseConnection();
        }


        private Employee GetEmployeeById(int id)
        {
            foreach (Employee e in _employees)
            {
                if (e.Id == id)
                {
                    return e;
                }
            }
            return null;
        }
    }
}
