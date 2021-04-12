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
            
        }

        public DayOff[] DaysOffRequests { get { return dayoff_req.ToArray(); } }
        public Schedule[] Schedules { get { return _schedules.ToArray(); } }

        private void LoadSchedules()
        {
            MySqlDataReader dr = scheduleDAL.SelectSchedules();
            List<Schedule> schedules = new List<Schedule>();
           
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr[0]);
                    DateTime startDate = dr.GetDateTime(1);
                    DateTime endDate = dr.GetDateTime(2);
                    bool isOutdated = Convert.ToBoolean(dr[3]);
                    schedules.Add(new Schedule(id, startDate, endDate, isOutdated));
                }
            scheduleDAL.CloseConnection();
            _schedules = schedules;
        }

        public Day[] GetDays(int scheduleId)
        {
            List<Day> days = new List<Day>();
            MySqlDataReader dr = scheduleDAL.SelectDays(scheduleId);

            while (dr.Read())
            {
                int dayId = Convert.ToInt32(dr[0]);
                DateTime date = dr.GetDateTime(1);
                string securityNeeded = Convert.ToString(dr[3]);
                string cashiersNeeded = Convert.ToString(dr[4]);
                string stockersNeeded = Convert.ToString(dr[5]);
                string salesAssistantsNeeded = Convert.ToString(dr[6]);
                string warehouseManagersNeeded = Convert.ToString(dr[7]);
                int weekId = Convert.ToInt32(dr[8]);

                days.Add(new Day(dayId, date,scheduleId, securityNeeded, cashiersNeeded, stockersNeeded, salesAssistantsNeeded, warehouseManagersNeeded, weekId));

            }
            dr.Close();
            return days.ToArray();
        }

        public EmployeeWorkday[] GetEmployeesShifts(int dayId, string jobPosition)
        {
            List<EmployeeWorkday> workdays = new List<EmployeeWorkday>();

            MySqlDataReader dr = scheduleDAL.SelectEmployeesShifts(dayId, jobPosition);
            while (dr.Read()) //add EmployeeWorkday objects to the list
            {
                Employee employee =Helper.GetEmployeeById( Convert.ToInt32(dr[1]),_employees.ToArray());
                Shift firstShift = (Shift)Enum.Parse(typeof(Shift), dr[2].ToString());
                Shift secondShift = (Shift)Enum.Parse(typeof(Shift), dr[3].ToString());
                bool absence = Convert.ToBoolean(dr[4]);
                AbsenceReason absenceReason = (AbsenceReason)Enum.Parse(typeof(AbsenceReason), dr[5].ToString());

                workdays.Add(new EmployeeWorkday(employee,firstShift,secondShift,absence,absenceReason));
            }
            scheduleDAL.CloseConnection();
            return workdays.ToArray();

        }

       public void RemoveShift(string shift,Day day,int employeeId)
        {
            MySqlDataReader result = scheduleDAL.SelectEmployeeWorkday(day.Id, employeeId);
            if (result.Read()) 
            {
                int emptyShiftIndex = Helper.GetEmptyShiftIndex(result[2].ToString(), result[3].ToString());
                if (emptyShiftIndex != -1 && !Convert.ToBoolean(result[4])) //if there is an empty shift, remove the row
                {
                    scheduleDAL.DeleteShift(day.Id, employeeId);
                }
                else if (emptyShiftIndex == -1 && !Convert.ToBoolean(result[4]))//if there is a double shift,insert None on the chosen one
                {
                    if (result[2].ToString() == shift.ToString()) 
                    {
                        scheduleDAL.UpdateShift(2,"None",day.Id,employeeId);
                    }
                    else if (result[3].ToString() == shift.ToString())
                    {
                        scheduleDAL.UpdateShift(3,"None", day.Id, employeeId);
                    }
                    
                }
                int workedHours = GetWorkedHours(day.WeekId, employeeId);
                scheduleDAL.UpdateHours(workedHours - 4.5, day.ScheduleId, employeeId);
            }
            scheduleDAL.CloseConnection();
        }
        
        public void AssignShift(string shift, int employeeId, Day day, int emptyShiftIndex, double hours)
        {
            MySqlDataReader dr = scheduleDAL.SelectEmployeeWorkday(day.Id, employeeId);
            if (dr.Read())
            {
                scheduleDAL.UpdateShift(emptyShiftIndex, shift, day.Id, employeeId);  
            }
            else
            {
                scheduleDAL.InsertShift(day.Id, employeeId, shift);  
            }
            scheduleDAL.CloseConnection();

            if (hours == 4.5)
            {
                scheduleDAL.InsertHours(hours, day.WeekId, employeeId);
            }
            else
            {
                scheduleDAL.UpdateHours(hours, day.WeekId, employeeId);
            }
            scheduleDAL.CloseConnection();
        }


        public void AssignAbsence(AbsenceReason absenceReason, int employeeId, int dayId)
        {
            MySqlDataReader dr = scheduleDAL.SelectEmployeeWorkday(dayId, employeeId);
            if (dr.Read())
            {
                scheduleDAL.UpdateAbsence(dayId, employeeId);
            }
            else
            {
                scheduleDAL.InsertAbsence(dayId, employeeId);
            }
            scheduleDAL.CloseConnection();

        }


        public int GetWorkedHours(int weekId, int employeeId)
        {
            int hours =Convert.ToInt32(scheduleDAL.SelectWorkedHours(weekId, employeeId));
            scheduleDAL.CloseConnection();
            return hours;
        }



        public List<DayOff> PopulateList_DayOff() // add the DayOff requests to the list 
        {
            List<DayOff> pseudos = new List<DayOff>();
            MySqlDataReader result = scheduleDAL.SelectDayOffRequests();
            while (result.Read())
            {
                int dayId = Convert.ToInt32(result[0]);
                int employee_id = Convert.ToInt32(result[1]);
                bool denied = Convert.ToBoolean(result[2]);
                string objection = result[3].ToString();
                DayOff req = new DayOff(dayId, employee_id, denied, objection);
                pseudos.Add(req);
            }
            scheduleDAL.CloseConnection();
            dayoff_req = pseudos;
            return dayoff_req;
        }

    }
}
