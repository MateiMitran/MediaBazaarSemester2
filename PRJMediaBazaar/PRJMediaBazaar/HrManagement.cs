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

        public HrManagement()
        {
            _employees = new List<RegularEmployee>();
            //SQL query to create the employees
        }

        private RegularEmployee GetEmployee(int employeeID)
        {
            
        }

        private Day GetDay(DateTime day)
        {

        }

        private Schedule GetSchedule(DateTime startDate, DateTime endDate)
        {

        }

        private Schedule GetScheduleByADay (DateTime day)
        {

        }

        public void IncrementNeededJobPosition(Day day, JobPosition jobPosition)
        {

        }

        public bool ChangeNeededJobPosition(Day day, JobPosition jobPosition)
        {

        }

        public bool AssignShift(Shift first_shift, Shift second_shift, RegularEmployee employee, Day day)
        {

        }

        public bool ChangeShift(Shift shift, RegularEmployee employee, Day day)
        {

        }

        public void AssignAbsence(AbsenceReason absenceReason, Day day)
        {

        }
    }
}
