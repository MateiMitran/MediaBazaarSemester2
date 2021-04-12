using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace PRJMediaBazaar.Logic
{
     class ScheduleControl
    {
        private List<DayOff> dayoff_req;
        private List<Schedule> _schedules;
        private List<Employee> _employees;
        private ScheduleDAL scheduleDAL;
        public ScheduleControl(List<Employee> employees)
        {
            _schedules = new List<Schedule>();
            _employees = employees;
            scheduleDAL = new ScheduleDAL();
            LoadSchedules();
            LoadDaysOff();
            
        }

        public DayOff[] DaysOffRequests { get { return dayoff_req.ToArray(); } }
        public Schedule[] Schedules { get { return _schedules.ToArray(); } }

        private void LoadSchedules()
        {
            _schedules = scheduleDAL.SelectSchedules();
        }

        public Day[] GetDays(int scheduleId)
        {
            return scheduleDAL.SelectDays(scheduleId).ToArray();
        }

        public EmployeeWorkday[] GetEmployeesShifts(int dayId, string jobPosition)
        {
          
           return scheduleDAL.SelectEmployeesShifts(dayId, jobPosition).ToArray();
           
        }

       public void RemoveShift(string shift,Day day,int employeeId)
        {
            EmployeeWorkday result = scheduleDAL.SelectEmployeeWorkday(day.Id, employeeId);
            if (result != null) 
            {
                int emptyShiftIndex = Helper.GetEmptyShiftIndex(result.FirstShift.ToString(), result.SecondShift.ToString());
                if (emptyShiftIndex != -1 && !result.Absence) //if there is an empty shift, remove the row
                {
                    scheduleDAL.DeleteShift(day.Id, employeeId);
                }
                else if (emptyShiftIndex == -1 && !result.Absence)//if there is a double shift,insert None on the chosen one
                {
                    if (result.FirstShift.ToString() == shift.ToString()) 
                    {
                        scheduleDAL.UpdateShift(2,"None",day.Id,employeeId);
                    }
                    else if (result.SecondShift.ToString() == shift.ToString())
                    {
                        scheduleDAL.UpdateShift(3,"None", day.Id, employeeId);
                    }
                    
                }
                double workedHours = GetWorkedHours(day.WeekId, employeeId);
                scheduleDAL.UpdateHours(workedHours - 4.5, day.ScheduleId, employeeId);
            }
        }
        
        public void AssignShift(string shift, int employeeId, Day day, int emptyShiftIndex, double hours)
        {
           EmployeeWorkday wd = scheduleDAL.SelectEmployeeWorkday(day.Id, employeeId);
            if (wd != null)
            {
                scheduleDAL.UpdateShift(emptyShiftIndex, shift, day.Id, employeeId);  
            }
            else
            {
                scheduleDAL.InsertShift(day.Id, employeeId, shift);  
            }

            if (hours == 4.5)
            {
                scheduleDAL.InsertHours(hours, day.WeekId, employeeId);
            }
            else
            {
                scheduleDAL.UpdateHours(hours, day.WeekId, employeeId);
            }
        }


        public void AssignAbsence(AbsenceReason absenceReason, int employeeId, int dayId)
        {
           EmployeeWorkday wd = scheduleDAL.SelectEmployeeWorkday(dayId, employeeId);
            if (wd != null)
            {
                scheduleDAL.UpdateAbsence(dayId, employeeId);
            }
            else
            {
                scheduleDAL.InsertAbsence(dayId, employeeId);
            }
        }


        public double GetWorkedHours(int weekId, int employeeId)
        {
            return scheduleDAL.SelectWorkedHours(weekId, employeeId);
        }



        public void LoadDaysOff() // add the DayOff requests to the list 
        {
           dayoff_req = scheduleDAL.SelectDayOffRequests();
        }

    }
}
