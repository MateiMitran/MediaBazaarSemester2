﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar.Data
{
     class ScheduleDAL : BaseDAL
    { 
     protected MySqlDataReader SelectSchedules()
        {
            return executeReader("SELECT * FROM schedules;", null);
        }

        protected MySqlDataReader SelectDays(int scheduleId)
        {
            string[] parameters = new string[] { scheduleId.ToString() };

            return executeReader("SELECT * FROM days WHERE schedule_id = @scheduleId", parameters);
        }


        protected Object UpdatePosition(string jobPosition, int amount, int dayId)
        {
            string sql = "";
            string[] parameters = new string[] { amount.ToString(), dayId.ToString() };
            switch (jobPosition)
            {
                case "Security":
                    sql = "UPDATE days SET security_needed = @amount WHERE id = @dayId";
                    break;
                case "Cashier":
                    sql = "UPDATE days SET cashiers_needed = @amount WHERE id = @dayId";
                    break;
                case "Stocker":
                    sql = "UPDATE days SET stockers_needed = @amount WHERE id = @dayId";

                    break;
                case "SalesAssistant":
                    sql = "UPDATE days SET sales_assistants_needed = @amount WHERE id = @dayId";

                    break;
                case "WarehouseManager":
                    sql = "UPDATE days SET warehouse_managers_needed = @amount WHERE id = @dayId";
                    break;

            }
            return executeNonQuery(sql, parameters);
        }

        /// <summary>
        /// takes the employees who are not absent, by the given job position
        /// </summary>
        /// <param name="dayId"></param>
        /// <param name="jobPosition"></param>
        /// <returns></returns>
        protected MySqlDataReader SelectEmployeesWorkdays(int dayId, string jobPosition)
        {
            string[] parameters = new string[] { dayId.ToString(), jobPosition };
            return executeReader("SELECT ew.*, d.date, e.first_name, e.last_name FROM employees_workdays ew INNER JOIN days d ON ew.day_id = d.id" +
                    " INNER JOIN employees e ON ew.employee_id = e.id WHERE ew.day_id = @dayId AND job_position = @jobPosition AND ew.absence = false;", parameters);
        }


        /// <summary>
        /// takes the employee workday for that day and employee
        /// </summary>
        /// <returns></returns>
        protected MySqlDataReader SelectEmployeeWorkday(int dayId, int employeeId)
        {
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString() };
            string sql = "SELECT * FROM employees_workdays WHERE day_id = @dayId AND employee_id = @employeeId";

            return executeReader(sql, parameters);
        }


        protected Object UpdateShift(int emptyIndex, string shift, int dayId, int employeeId)
        {
            string[] parameters = new string[] { shift, dayId.ToString(), employeeId.ToString() };
            string sql = "";

            switch (emptyIndex)
            {
                case 2:
                    sql = "UPDATE employees_workdays SET first_shift = @shift WHERE day_id = @dayId AND employee_id = @employeeId;";
                    break;
                case 3:
                    sql = "UPDATE employees_workdays SET second_shift = @shift WHERE day_id = @dayId AND employee_id = @employeeId;";
                    break;
            }
            return executeNonQuery(sql, parameters);
        }


        protected Object InsertShift(int dayId, int employeeId, string shift)
        {
            string sql = "INSERT INTO employees_workdays (day_id, employee_id, first_shift)" +
                " VALUES(@dayId, @employeeId, @shift);";
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString(), shift };

            return executeNonQuery(sql, parameters);
        }


        protected Object DeleteShift(string shift, int dayId, int employeeId)
        {
            string sql = "DELETE FROM employees_workdays WHERE day_id = @dayId AND employee_id = @employeeId";
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString() };


            return executeNonQuery(sql, parameters);
        }

        protected Object UpdateAbsence(AbsenceReason absenceReason, int dayId, int employeeId)
        {
            string[] parameters = new string[] { "None", "None", true.ToString(), absenceReason.ToString(), dayId.ToString(), employeeId.ToString() };
            string sql = "UPDATE employees_workdays SET first_shift = @shift, second_shift = @shift, absence = @absence, absence_reason = @absenceReason" +
                             " WHERE day_id = @dayId AND employee_id = @employeeId";

            return executeNonQuery(sql, parameters);
        }

        protected Object InsertAbsence(int dayId, int employeeId)
        {
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString(), "None", "None", true.ToString(), "DayOff" };
            string sql = "INSERT INTO employees_workdays (day_id, employee_id, first_shift, second_shift, absence, absence_reason)" +
                    " VALUES(@dayId, @employeeId, @shift, @shift, @absence, @absenceReason);";

            return executeNonQuery(sql, parameters);
        }
    }
}
