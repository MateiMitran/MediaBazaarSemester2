using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;

namespace PRJMediaBazaar.Logic
{
    class AbsenceControl
    {
        private List<DayOff> dayoff_req;
        private List<SickReport> sick_req;
        private AbsenceDAL absenceDAL;
        private ScheduleControl _scheduleControl;
  

        public List<DayOff> DaysOffRequests { get { return dayoff_req; } }
        public List<SickReport> SickReports { get { return sick_req; } }

        public AbsenceControl(ScheduleControl scheduleControl)
        {
            _scheduleControl = scheduleControl;
            absenceDAL = new AbsenceDAL(scheduleControl.EmployeeControl.GetAllEmployees(), scheduleControl.Schedules.ToList());
            LoadDaysOff();
            LoadSickReports();
        }


        public void LoadDaysOff() // add the DayOff requests to the list 
        {
            dayoff_req = absenceDAL.SelectDayOffRequests();
        }

        public void LoadSickReports()
        {
            sick_req = absenceDAL.SelectSickReports();
        }



        public void DenyDayOffRequest(int empId, int dayId, String note)
        {
            absenceDAL.DenyDayOffRequest(empId,dayId, note);
        }

        public bool MarkAsSeen(int dayId, int empId)
        {
            return absenceDAL.ConfirmSickReport(dayId, empId);
        }

        /// <summary>
        /// returns the number of shifts removed,along with the day
        /// </summary>
        /// <param name="absenceReason"></param>
        /// <param name="employee"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public int ConfirmDayOffRequest(Employee employee, Day day)
        {
            absenceDAL.ConfirmDayOffRequest(day.Id, employee.Id);
            int count = 0;
            EmployeeWorkday wd = _scheduleControl.GetEmployeeShift(day.WeekId, day.Id, employee.Id);

            if (wd != null)
            {   
                double hours = wd.Hours;
                absenceDAL.UpdateAbsence(day.Id, employee.Id);
                if (wd.FirstShift != Shift.None)
                {
                     hours -= 4.5;
                    _scheduleControl.DecreaseAssignedPosition(day, employee.JobPosition, wd.FirstShift.ToString());
                    _scheduleControl.UpdateHours(hours, day.WeekId, wd.Employee.Id);
                    count++;
                   
                }
                if (wd.SecondShift != Shift.None)
                {
                     hours -= 4.5;
                    _scheduleControl.DecreaseAssignedPosition(day, employee.JobPosition, wd.SecondShift.ToString());
                    _scheduleControl.UpdateHours(hours, day.WeekId, wd.Employee.Id);
                    count++;
                }
            }
            else
            {
                absenceDAL.InsertAbsence(day.Id, employee.Id);
               
            }
            return count;
        }

    }
}
