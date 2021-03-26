using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class EmployeePlanner
    {
        public Employee Employee { get; set; }
        public string Occupation { get; set; }
        public int EmptyShiftIndex { get; set; }

        public EmployeePlanner(Employee emp, string occupation, int emptyShiftIndex)
        {
            Employee = emp;
            Occupation = occupation;
            EmptyShiftIndex = emptyShiftIndex;
        }

        public override string ToString()
        {
            return ($"{Employee.Id} {Employee.FullName}, Occupation:{Occupation}");
        }
    }
}
