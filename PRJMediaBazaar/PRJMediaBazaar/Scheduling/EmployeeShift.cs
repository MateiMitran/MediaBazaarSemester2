using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class EmployeeShift
    {
        public EmployeeShift(int dayID, DateTime date, int employeeID, Shift firstShift, Shift secondShift)
        {
            DayID = dayID;
            Date = date;
            EmployeeID = employeeID;
            FirstShift = firstShift;
            SecondShift = secondShift;
            Absence = false;
            AbsenceReason = AbsenceReason.None;
        }

        public int DayID { get; private set; }
        public DateTime Date { get; private set; }
        public int EmployeeID { get; private set; }
        public Shift FirstShift { get; set; }
        public Shift SecondShift { get; set; }
        public bool Absence { get;  set; }
        public AbsenceReason AbsenceReason { get; set; }
    }
}
