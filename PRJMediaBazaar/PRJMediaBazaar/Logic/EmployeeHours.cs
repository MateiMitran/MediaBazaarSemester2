using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class EmployeeHours
    {
        public Employee Employee { get; private set; }
        public double Hours { get; private set; }

        public EmployeeHours(Employee employee, double hours)
        {
            Employee = employee;
            Hours = hours;
        }

       
    }
}
