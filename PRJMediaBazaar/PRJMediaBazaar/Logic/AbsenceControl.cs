using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;

namespace PRJMediaBazaar.Logic
{
    class AbsenceControl : ScheduleControl
    {
        private List<DayOff> dayoff_req;
        private List<SickReport> sick_req;
        private AbsenceDAL absenceDAL;
  

        public List<DayOff> DaysOffRequests { get { return dayoff_req; } }
        public List<SickReport> SickReports { get { return sick_req; } }

        public AbsenceControl(EmployeeControl employeeControl) : base(employeeControl)
        {
            absenceDAL = new AbsenceDAL(employeeControl.GetAllEmployees(), this.Schedules.ToList());
            LoadDaysOff();
            LoadSickReports();
        }

        public ScheduleControl GetScheduleControl()
        {
            return (ScheduleControl)this;
        }

        public void LoadDaysOff() // add the DayOff requests to the list 
        {
            dayoff_req = absenceDAL.SelectDayOffRequests();
        }

        public void LoadSickReports()
        {
            sick_req = absenceDAL.SelectSickReports();
        }


        public bool ConfirmDayOffRequest(int dayId, int empId)
        {
            return absenceDAL.ConfirmDayOffRequest(dayId, empId);
        }

        public bool MarkAsSeen(int dayId, int empId)
        {
            return absenceDAL.ConfirmSickReport(dayId, empId);
        }


        public void AssignAbsence(AbsenceReason absenceReason, Employee employee, Day day)
        {
            EmployeeWorkday wd = GetEmployeeShift(day.WeekId, day.Id, employee.Id);
            if (wd != null)
            {
                absenceDAL.UpdateAbsence(day.Id, employee.Id);
                if (wd.FirstShift != Shift.None)
                {
                    DecreaseAssignedPosition(day, employee.JobPosition, wd.FirstShift.ToString());
                }
                if (wd.SecondShift != Shift.None)
                {
                    DecreaseAssignedPosition(day, employee.JobPosition, wd.SecondShift.ToString());
                }
                scheduleDAL.UpdateHours(wd.Hours, day.WeekId, employee.Id);
            }
            else
            {
                absenceDAL.InsertAbsence(day.Id, employee.Id);
            }
        }

    }
}
