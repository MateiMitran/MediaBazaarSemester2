using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class EmployeeWorkday
    {
        //public EmployeeWorkday(Employee emp, Shift firstShift, Shift secondShift, bool absence, AbsenceReason absenceReason)
        //{
        //    Employee = emp;
        //    FirstShift = firstShift;
        //    SecondShift = secondShift;
        //    Absence = absence;
        //    AbsenceReason = AbsenceReason;
        //}

        public EmployeeWorkday(Employee emp, Shift firstShift, Shift secondShift, bool absence, AbsenceReason absenceReason, double hours)
        {
            Employee = emp;
            FirstShift = firstShift;
            SecondShift = secondShift;
            Absence = absence;
            AbsenceReason = AbsenceReason;
            Hours = hours;
        }


        public Employee Employee { get; private set; }
        public Shift FirstShift { get; set; }
        public Shift SecondShift { get; set; }
        public string JobPosition { get; set; }
        public bool Absence { get; set; }
        public AbsenceReason AbsenceReason { get; set; }

        public double Hours { get; private set; }

        public string GetEmptyShift()
        {
            if (FirstShift.ToString() == "None" && SecondShift.ToString() != "None")
            {
                return FirstShift.ToString();
            }
            else if (SecondShift.ToString() == "None" && FirstShift.ToString() != "None")
            {
                return SecondShift.ToString();
            }
            return "-1";
        }

        public string GetBusyShift()
        {
            if (FirstShift.ToString() == "None" && SecondShift.ToString() != "None")
            {
                return SecondShift.ToString();
            }
            else if (SecondShift.ToString() == "None" && FirstShift.ToString() != "None")
            {
                return FirstShift.ToString();
            }
            return "-1";
        }
    }
}
