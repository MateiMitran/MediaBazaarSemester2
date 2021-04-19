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


        public bool ConfirmDayOffRequest(int dayId, int empId)
        {
            return absenceDAL.ConfirmDayOffRequest(dayId, empId);
        }

        public void AddReason(int id, String note)
        {
            absenceDAL.AddReasonForDenial(id, note, "denied");
        }

        public bool MarkAsSeen(int dayId, int empId)
        {
            return absenceDAL.ConfirmSickReport(dayId, empId);
        }


        public void AssignAbsence(AbsenceReason absenceReason, Employee employee, Day day)
        {
            EmployeeWorkday wd = _scheduleControl.GetEmployeeShift(day.WeekId, day.Id, employee.Id);
            if (wd != null)
            {
                absenceDAL.UpdateAbsence(day.Id, employee.Id);
                if (wd.FirstShift != Shift.None)
                {
                    _scheduleControl.DecreaseAssignedPosition(day, employee.JobPosition, wd.FirstShift.ToString());
                }
                if (wd.SecondShift != Shift.None)
                {
                    _scheduleControl.DecreaseAssignedPosition(day, employee.JobPosition, wd.SecondShift.ToString());
                }
                _scheduleControl.UpdateHours(wd.Hours, day.WeekId, employee.Id);
            }
            else
            {
                absenceDAL.InsertAbsence(day.Id, employee.Id);
            }
        }

    }
}
