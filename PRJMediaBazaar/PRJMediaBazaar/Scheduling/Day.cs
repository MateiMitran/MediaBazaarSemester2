using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class Day
    {
        private static int _idCounter = 1;
        private int _id;

        private List<EmployeePreference> _employeesPreferences;
        private List<EmployeeShift> _employeesShifts;
        private DateTime _date;
       
        public int SecurityNeeded { get; private set; }
        public int CashiersNeeded { get; private set; }
        public int StockersNeeded { get; private set; }
        public int SalesAssistantsNeeded { get; private set; }
        public int WarehouseManagersNeeded { get; private set; }


        public Day(DateTime date)
        {
            _id = _idCounter;
            _idCounter++;
            _date = date;
            _employeesPreferences = new List<EmployeePreference>();
            _employeesShifts = new List<EmployeeShift>();

        }

        public DateTime Date { get; }
      
        private bool ShiftIsValid(Shift assignedShift, Shift secondShift)
        {
            if(assignedShift == Shift.Morning && secondShift == Shift.Evening)
            {
                return false;
            }

            if (assignedShift == Shift.Evening && secondShift == Shift.Morning)
            {
                return false;
            }

            return true;
        }

        private bool EmployeeHasDoubleShift(EmployeeShift es)
        {
            if (es.FirstShift != Shift.None && es.SecondShift != Shift.None)
            {
                return true;
            }
            return false;
        }

        public bool AssignShift(Shift shift, int employeeID)
        {
            EmployeeShift employeeShift = GetEmployeeShift(employeeID);

            if (employeeShift != null && employeeShift.SecondShift == Shift.None && ShiftIsValid(employeeShift.FirstShift, shift))
            {
                //SQL quey to add the shift to the employees_workdays table
                employeeShift.SecondShift = shift;
                return true;
            }

            else if (employeeShift == null)
            {
                //create an object with inital second shift as None.
                //SQL quey to add the shift to the employees_workdays table
                _employeesShifts.Add(new EmployeeShift(_id, _date, employeeID, shift, Shift.None));
                return true;
            }
            return false;
        }

        public void DeleteShift(Shift shift, int employeeID) // sets the shift to None.
        {
            EmployeeShift employeeShift = GetEmployeeShift(employeeID);
            if (!EmployeeHasDoubleShift(employeeShift)) //if the employee doesn't have a double shift, remove the object from the list
            {
                //SQL query to remove the shift from employees_workdays table
                _employeesShifts.Remove(employeeShift);
            }
            else //check which shift is selected and replace it with Shift.None
            {
                if (employeeShift.FirstShift == shift)
                {
                    employeeShift.FirstShift = Shift.None;
                }
                else if (employeeShift.SecondShift == shift)
                {
                    employeeShift.SecondShift = Shift.None;
                }
            }

        }

        public void AssignAbsence(AbsenceReason absenceReason , int employeeID)
        {
            EmployeeShift employee = GetEmployeeShift(employeeID);
            if (employee != null)
            {
                employee.FirstShift = Shift.None;
                employee.SecondShift = Shift.None;
                employee.AbsenceReason = absenceReason;
                employee.Absence = true;
                //SQL - UPDATE the row in employees_workdays with the new values.
            }
            else
            {
              EmployeeShift es = new EmployeeShift(_id, _date, employeeID, Shift.None, Shift.None);
                es.Absence = true;
                es.AbsenceReason = absenceReason;
                //SQL - INSERT a new row in employees_workdays
            }

        }

        public EmployeePreference GetEmployeePreferedShift(int employeeID)
        {
           
            foreach (EmployeePreference ep in _employeesPreferences)
            {
                if (ep.EmployeeID == employeeID)
                {
                    return ep;
                }
            }
            return null;
        }

        public EmployeeShift GetEmployeeShift(int employeeID)
        {
            foreach (EmployeeShift es in _employeesShifts)
            {
                if (es.EmployeeID == employeeID)
                {
                    return es;
                }
            }
            return null;
        }

        public void ChangeNeededJobPosition(JobPosition jobPosition , int amount)
        {
            switch(jobPosition)
            {
                case JobPosition.Cashier:
                    CashiersNeeded = amount;
                    break;
                case JobPosition.Security:
                    SecurityNeeded = amount;
                    break;
                case JobPosition.SalesAssistant:
                    SalesAssistantsNeeded = amount;
                    break;
                case JobPosition.Stocker:
                    StockersNeeded = amount;
                    break;
                case JobPosition.WarehouseManager:
                    WarehouseManagersNeeded = amount;
                    break;
            }
            //SQL query to UPDATE the value in the days table
        }

    }
}
