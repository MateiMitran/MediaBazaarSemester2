using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class EmployeePreference
    {
     
        public int DayID { get; private set; }
        public DateTime Date { get; private set; }
        public int EmployeeID { get; private set; }
        public Shift PreferedShift { get; private set; }


        public EmployeePreference(int dayID, DateTime date, int employeeID, Shift preferedShift)
        {
            DayID = dayID;
            Date = date;
            EmployeeID = employeeID;
            PreferedShift = preferedShift;
        }

    }
}
