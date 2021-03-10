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
        private int _cashiersNeeded;
        private int _securityNeeded;
        private int _salesAssistantsNeeded;
        private int _managersNeeded;
        private int _stockersNeeded;

        public Day(DateTime date)
        {
            _id = _idCounter;
            _idCounter++;
            _date = date;
            _employeesPreferences = new List<EmployeePreference>();
            _employeesShifts = new List<EmployeeShift>();

        }
        
        public void PopulateShiftPreferences() //used in GetEmployeePreferedShift()
        {
            //SQL query to get the preferences for that day
            //create the EmployeePreference objects and add them to the list _employeePreferences 
        }

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

        public bool EmployeeHasDoubleShift(EmployeeShift es)
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
                employeeShift.SecondShift = shift;
                return true;
            }

            else if (employeeShift == null)
            {
                //create an object with inital second shift as None.
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

        public void AssignAbsence(AbsenceReason absenceReason)
        {

        }

        public EmployeePreference GetEmployeePreferedShift(int employeeID)
        {
            this.PopulateShiftPreferences();
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


    }
}
