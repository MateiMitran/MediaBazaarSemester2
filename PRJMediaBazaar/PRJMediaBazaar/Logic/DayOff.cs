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
        public String Reason { get; set; }
        public String Objection { get; private set; }

        public DayOff (Day day, Employee employee, bool urgent, String status, String reason, String objection)
        {
            Day = day;
            Employee = employee;
            Urgent = urgent;
            Status = status;
            Reason = reason;
            Objection = objection;
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


        public override string ToString()
        {
            string urgent;

            if (Urgent == false)
            {
                urgent = "Not urgent";
            }
            else
            {
                urgent = "Urgent";
            }
            if(Reason != "")
            {
                return $"{Day.Date.ToString("dd/MM/yyyy")} --> {Employee.FullName} --> {urgent} --> Reason:{Reason}";
            }

            return $"{Day.Date.ToString("dd/MM/yyyy")} --> {Employee.FullName} --> {urgent}";
        }
    }
}
