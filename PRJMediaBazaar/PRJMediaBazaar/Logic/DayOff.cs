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
        public int Schedule_id { get; private set; }
        public int Day_id { get; private set; }
        public int Employee_id { get; private set; }
        public bool Urgent { get; private set; }
        public String Status { get; private set; }
        public String Reason { get; private set; }


        public DayOff (int scheduleId, int dayId, int employee_id, bool urgent, String status, String reason)
        {
            Schedule_id = scheduleId;
            Day_id = dayId;
            Employee_id = employee_id;
            Urgent = urgent;
            Status = status;
            Reason = reason;
        }

        public Day GetDayById(int scheduleId, int dayId)
        {
            EmployeeControl employeeControl = new EmployeeControl();
            ScheduleControl scheduleControl = new ScheduleControl(employeeControl.GetAllEmployees());

            Day[] days = scheduleControl.GetDays(scheduleId);
            Day day = new Day();

            for(int i = 0; i < days.Length; i++)
            {
                if(days[i].Id == dayId)
                {
                    day = days[i];
                    break;
                }
            }

            return day;
        }

        public void SetStatus(string status)
        {
            this.Status = status;
        }
    }
}
