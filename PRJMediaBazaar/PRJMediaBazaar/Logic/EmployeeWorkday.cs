using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class EmployeeWorkday
    {
        public EmployeeWorkday(Employee emp, Shift firstShift, Shift secondShift, bool absence, AbsenceReason absenceReason)
        {
            Employee = emp;
            FirstShift = firstShift;
            SecondShift = secondShift;
            Absence = absence;
            AbsenceReason = AbsenceReason;
        }


        public Employee Employee { get; private set; }
        public Shift FirstShift { get; set; }
        public Shift SecondShift { get; set; }
        public string JobPosition { get; set; }
        public bool Absence { get; set; }
        public AbsenceReason AbsenceReason { get; set; }
    }
}
