using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Data;

namespace PRJMediaBazaar.Logic
{
    class SickReport
    {

     
        public Day Day { get; private set; }
        public Employee Employee { get; private set; }
        public string Description { get; private set; }
        public bool Seen { get; private set; }


        public SickReport(Day day , Employee employee, string description, bool seen)
        {
           
            Day = day;
            Employee = employee;
            Description = description;
            Seen = seen;
        }

     

        public void MarkAsSeen(bool seen)
        {
            this.Seen = seen;
        }
    }
}