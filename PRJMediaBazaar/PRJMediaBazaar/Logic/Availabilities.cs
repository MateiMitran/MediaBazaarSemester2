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

            foreach (Employee employee in _employees)
            {
                MySqlDataReader result = SelectEmployeeWorkday(dayId, employee.Id);
                if (result.Read()) //the employee is in the workdays_table
                {
                    if (!Convert.ToBoolean(result[4])) //the employee isn't absent
                    {
                        int index = GetEmptyShiftIndex(result[2].ToString(), result[3].ToString());
                        int busyIndex = GetBusyShiftIndex(result[2].ToString(), result[3].ToString());

                        if (index == -1)  //employee has a double shift
                        {
                            EmployeePlanner ea = new EmployeePlanner(employee, "Double shift", -1);
                            _unavailable.Add(ea);
                        }

                        else if (index != -1 && DoubleShiftIsValid(result[busyIndex].ToString(), shift.ToString())) //employee has only one shift, and the second one is valid
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


                }

                else //if the employee is not in the employees_workdays table, add availability
                {
                    EmployeePlanner ea = new EmployeePlanner(employee, "None", -1);
                    _available.Add(ea);
                }
                CloseConnection();
            }
        }

        private static int GetEmptyShiftIndex(string firstShift, string secondShift)
        {
            if (firstShift == "None" && secondShift != "None")
            {
                return 2;
            }
            else if (secondShift == "None" && firstShift != "None")
            {
                return 3;
            }
            return -1;
        }

        private static int GetBusyShiftIndex(string firstShift, string secondShift)
        {
            if (firstShift == "None" && secondShift != "None")
            {
                return 3;
            }
            else if (secondShift == "None" && firstShift != "None")
            {
                return 2;
            }
            return -1;
        }

        private static bool DoubleShiftIsValid(string assignedShift, string shiftToAssign)
        {
            if (assignedShift == "Morning" && shiftToAssign == "Evening")
            {
                return false;
            }

            if (assignedShift == "Evening" && shiftToAssign == "Morning")
            {
                return false;
            }

            if (assignedShift == shiftToAssign)
            {
                return false;
            }

            return true;

        }
    }
}
