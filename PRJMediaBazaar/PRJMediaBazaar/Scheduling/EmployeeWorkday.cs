using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class EmployeeWorkday
    {
        public EmployeeWorkday(int dayID, DateTime date, int employeeID, Shift firstShift, Shift secondShift, bool absence,AbsenceReason absenceReason, string jobPosition, string employeeName)
        {
            DayID = dayID;
            Date = date;
            EmployeeID = employeeID;
            FirstShift = firstShift;
            SecondShift = secondShift;
            JobPosition = jobPosition;
            EmployeeName = employeeName;
           
        }

        public EmployeeWorkday(string jobPosition)
        {
            DayID = -1;
            JobPosition = jobPosition;
        }

        public int DayID { get; private set; }
        public DateTime Date { get; private set; }
        public int EmployeeID { get; private set; }

        public string EmployeeName { get; private set; }
        public Shift FirstShift { get; set; }
        public Shift SecondShift { get; set; }
        public string JobPosition { get; set; }
        public bool Absence { get;  set; }
        public AbsenceReason AbsenceReason { get; set; }
    }
}
