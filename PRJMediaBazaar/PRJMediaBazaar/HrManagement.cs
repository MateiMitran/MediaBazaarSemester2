using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    
    class HrManagement
    {
        private List<RegularEmployee> _employees;
        private List<Schedule> _schedules;
        private HrManager _hr;

        public HrManagement(HrManager hr)
        {
            _employees = new List<RegularEmployee>();
            _schedules = new List<Schedule>();
            //SQL query to create the employees
            _hr = hr;
        }

        private RegularEmployee GetEmployee(int employeeID)
        {
            foreach(RegularEmployee e in _employees)
            {
                if (e.Id == employeeID)
                {
                    return e;
                }
            }
            return null;
        }

        private Day GetDay(DateTime date)
        {
            Schedule schedule = GetScheduleByADay(date);
            Day day = schedule.GetDay(date);
            return day;
        }

        private Schedule GetSchedule(DateTime startDate, DateTime endDate)
        {
            foreach(Schedule s in _schedules)
            {
                if (s.StartDate == startDate && s.EndDate == endDate)
                {
                    return s;
                }
            }
            return null;
        }

        private Schedule GetScheduleByADay (DateTime date)
        {
            foreach (Schedule s in _schedules)
            {
                if (date.Ticks > s.StartDate.Ticks && date.Ticks < s.EndDate.Ticks)
                {
                    return s;
                }
            }
            return null;
        }

        public void ChangeNeededJobPosition(Day day, JobPosition jobPosition, int amount)
        {
            day.ChangeNeededJobPosition(jobPosition, amount);
        }


        public bool AssignShift(Shift shift, RegularEmployee employee, Day day)
        {
            if (day.AssignShift(shift, employee.Id))
            { 
                return true; 
            }
            return false;
        }

        public void DeleteShift(Shift shift, RegularEmployee employee, Day day)
        {
            day.DeleteShift(shift, employee.Id);
        }

        public void AssignAbsence(AbsenceReason absenceReason, RegularEmployee employee, Day day)
        {
            day.AssignAbsence(absenceReason, employee.Id);
        }
    }
}
