using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Data;

namespace PRJMediaBazaar.Logic
{
    class DayOff
    {
        
        public Day Day { get; private set; }
        public Employee Employee { get; private set; }
        public bool Urgent { get; private set; }
        public String Status { get; private set; }
        public String Reason { get; private set; }


        public DayOff (Day day, Employee employee, bool urgent, String status, String reason)
        {
           
            Day = day;
            Employee = employee;
            Urgent = urgent;
            Status = status;
            Reason = reason;
        }


        public void SetStatus(string status)
        {
            this.Status = status;
        }
    }
}
