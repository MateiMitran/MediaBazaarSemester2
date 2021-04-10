using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Data;

namespace PRJMediaBazaar.Logic
{
    class DayOff : ScheduleDAL
    {
        
        public int Day_id { get; private set; }
        public int Employee_id { get; private set; }
        public bool Denied { get; private set; }
        public String Reason { get; private set; }


        public DayOff ( int dayId, int employee_id, String status, String reason)
        {
            Day_id = dayId;
            Employee_id = employee_id;
            Denied = denied;// 
            Reason = reason;
            
        }

       
    }
}
