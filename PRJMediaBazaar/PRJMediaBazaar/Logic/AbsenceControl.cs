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
            absenceDAL = new AbsenceDAL(scheduleControl.EmployeeControl.GetAllEmployees(), scheduleControl);
            LoadPendingDaysOff();
            LoadSickReports();
        }


        public void LoadPendingDaysOff() // add the DayOff requests to the list 
        {
            dayoff_req = absenceDAL.SelectDayOffRequests("pending");
        }
        public DayOff[] GetConfirmedDaysOff() // add the DayOff requests to the list 
        {
            return absenceDAL.SelectDayOffRequests("confirmed").ToArray();
        }

        public DayOff[] GetDeniedDaysOff() // add the DayOff requests to the list 
        {
            return absenceDAL.SelectDayOffRequests("denied").ToArray();
        }


        public void LoadSickReports()
        {
            sick_req = absenceDAL.SelectSickReports();
        }



        public void DenyDayOffRequest(int requestId, String note)
        {
            absenceDAL.DenyDayOffRequest(requestId, note);
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
        public void ConfirmDayOffRequest(DayOff request)
        {
            bool set = false;
            double hours = 0;
            foreach (KeyValuePair<Day, EmployeeWorkday> kv in request.Shifts)
            {
                Day day = kv.Key;
                Employee employee = request.Employee;
                absenceDAL.ConfirmDayOffRequest(request.RequestId);
                EmployeeWorkday wd = kv.Value;

                if (wd != null)
                {
                    if (!set)
                    {
                        hours = wd.Hours;
                        set = true;
                    }
                    
                    absenceDAL.UpdateAbsence(day.Id, employee.Id);
                    if (wd.FirstShift != Shift.None)
                    {
                        hours -= 4.5;
                        _scheduleControl.DecreaseAssignedPosition(day, employee.JobPosition, wd.FirstShift.ToString());
                        _scheduleControl.UpdateHours(hours, day.WeekId, wd.Employee.Id);

                    }
                    if (wd.SecondShift != Shift.None)
                    {
                        hours -= 4.5;
                        _scheduleControl.DecreaseAssignedPosition(day, employee.JobPosition, wd.SecondShift.ToString());
                        _scheduleControl.UpdateHours(hours, day.WeekId, wd.Employee.Id);
                    }
                }
                else
                {
                    absenceDAL.InsertAbsence(day.Id, employee.Id);
                }
            }

        }

    }
}
