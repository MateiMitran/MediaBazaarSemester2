using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Data;

namespace PRJMediaBazaar.Logic
{
    class SickReport : ScheduleDAL
    {

        public int Schedule_id { get; private set; }
        public int Day_id { get; private set; }
        public int Employee_id { get; private set; }
        public string Description { get; private set; }
        public bool Seen { get; private set; }


        public SickReport(int scheduleId, int dayId, int employee_id, string description, bool seen)
        {
            Schedule_id = scheduleId;
            Day_id = dayId;
            Employee_id = employee_id;
            Description = description;
            Seen = seen;
        }

        public Day GetDayById(int scheduleId, int dayId)
        {
            EmployeeControl employeeControl = new EmployeeControl();
            ScheduleControl scheduleControl = new ScheduleControl(employeeControl);

            Day[] days = scheduleControl.GetDays(scheduleId);
            Day day = new Day();

            for (int i = 0; i < days.Length; i++)
            {
                if (days[i].Id == dayId)
                {
                    day = days[i];
                    break;
                }
            }

            return day;
        }

        public void MarkAsSeen(bool seen)
        {
            this.Seen = seen;
        }
    }
}