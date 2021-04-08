﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Logic
{
     class ScheduleControl : ScheduleDAL
    {
        private List<Schedule> _schedules;
        private List<Employee> _employees;
        public ScheduleControl(List<Employee> employees)
        {
            _schedules = new List<Schedule>();
            _employees = employees;
            LoadSchedules();
        }

        public Schedule[] Schedules { get { return _schedules.ToArray(); } }

        private void LoadSchedules()
        {
            MySqlDataReader dr = SelectSchedules();
            List<Schedule> schedules = new List<Schedule>();
           
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr[0]);
                    DateTime startDate = dr.GetDateTime(1);
                    DateTime endDate = dr.GetDateTime(2);
                    bool isOutdated = Convert.ToBoolean(dr[3]);
                    schedules.Add(new Schedule(id, startDate, endDate, isOutdated));
                }
            CloseConnection();
            _schedules = schedules;
        }

        public Day[] GetDays(int scheduleId)
        {
            List<Day> days = new List<Day>();
            MySqlDataReader dr = SelectDays(scheduleId);

            while (dr.Read())
            {
                int dayId = Convert.ToInt32(dr[0]);
                DateTime date = dr.GetDateTime(1);
                string securityNeeded = Convert.ToString(dr[3]);
                string cashiersNeeded = Convert.ToString(dr[4]);
                string stockersNeeded = Convert.ToString(dr[5]);
                string salesAssistantsNeeded = Convert.ToString(dr[6]);
                string warehouseManagersNeeded = Convert.ToString(dr[7]);

                days.Add(new Day(dayId, date, securityNeeded, cashiersNeeded, stockersNeeded, salesAssistantsNeeded, warehouseManagersNeeded));

            }
            dr.Close();
            return days.ToArray();
        }

        public EmployeeWorkday[] GetEmployeesShifts(int dayId, string jobPosition)
        {
            List<EmployeeWorkday> workdays = new List<EmployeeWorkday>();

            MySqlDataReader dr = SelectEmployeesShifts(dayId, jobPosition);
            while (dr.Read()) //add EmployeeWorkday objects to the list
            {
                Employee employee =Helper.GetEmployeeById( Convert.ToInt32(dr[1]),_employees.ToArray());
                Shift firstShift = (Shift)Enum.Parse(typeof(Shift), dr[2].ToString());
                Shift secondShift = (Shift)Enum.Parse(typeof(Shift), dr[3].ToString());
                bool absence = Convert.ToBoolean(dr[4]);
                AbsenceReason absenceReason = (AbsenceReason)Enum.Parse(typeof(AbsenceReason), dr[5].ToString());

                workdays.Add(new EmployeeWorkday(employee,firstShift,secondShift,absence,absenceReason));
            }
            CloseConnection();
            return workdays.ToArray();

        }

       public void RemoveShift(string shift,int dayId,int employeeId)
        {
            MySqlDataReader result = SelectEmployeeWorkday(dayId, employeeId);
            if (result.Read()) 
            {
                int emptyShiftIndex = Helper.GetEmptyShiftIndex(result[2].ToString(), result[3].ToString());
                if (emptyShiftIndex != -1 && !Convert.ToBoolean(result[4])) //if there is an empty shift, remove the row
                {
                      DeleteShift(dayId, employeeId);
                }
                else if (emptyShiftIndex == -1 && !Convert.ToBoolean(result[4]))//if there is a double shift,insert None on the chosen one
                {
                    if (result[2].ToString() == shift.ToString()) 
                    {
                      UpdateShift(2,"None",dayId,employeeId);
                    }
                    else if (result[3].ToString() == shift.ToString())
                    {
                       UpdateShift(3,"None", dayId, employeeId);
                    }
                }
            }
            CloseConnection();
        }
        
        public void AssignShift(string shift, int employeeId, int dayId, int emptyShiftIndex)
        {
            MySqlDataReader dr = SelectEmployeeWorkday(dayId, employeeId);
            if (dr.Read())
            {
                UpdateShift(emptyShiftIndex, shift, dayId, employeeId);
            }
            else
            {
                InsertShift(dayId, employeeId, shift);
            }
            CloseConnection();
        }

    }
}
