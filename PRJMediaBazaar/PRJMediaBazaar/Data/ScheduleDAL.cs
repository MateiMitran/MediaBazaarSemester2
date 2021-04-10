using System;
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
        protected List<Object> dayoff_req;

        protected MySqlDataReader SelectSchedules()
        {
            return executeReader("SELECT * FROM schedules;", null);
        }

        protected MySqlDataReader SelectDays(int scheduleId)
        {
            string[] parameters = new string[] { scheduleId.ToString() };

            return executeReader("SELECT * FROM days WHERE schedule_id = @scheduleId", parameters);
        }

        /// <summary>
        /// takes the employees who are not absent, by the given job position
        /// </summary>
        /// <param name="dayId"></param>
        /// <param name="jobPosition"></param>
        /// <returns></returns>
        protected MySqlDataReader SelectEmployeesShifts(int dayId, string jobPosition)
        {
            string[] parameters = new string[] { dayId.ToString(), jobPosition };
            return executeReader("SELECT ew.* FROM employees_workdays ew INNER JOIN employees e ON ew.employee_id =e.id" +
                    "  WHERE day_id = @dayId AND e.job_position = @jobPosition AND absence = false;", parameters);
        }


        /// <summary>
        /// takes the employee's workday
        /// </summary>
        /// <param name="dayId"></param>
        /// <param name="employeeId"></param>
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


        protected Object DeleteShift(int dayId, int employeeId)
        {
            string sql = "DELETE FROM employees_workdays WHERE day_id = @dayId AND employee_id = @employeeId";
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString() };


            return executeNonQuery(sql, parameters);
        }

        protected Object UpdateAbsence(int dayId, int employeeId) // !
        {
            string[] parameters = new string[] { "None", "None", true.ToString(), "DayOff", dayId.ToString(), employeeId.ToString() };
            string sql = "UPDATE employees_workdays SET first_shift = @shift, second_shift = @shift, absence = @absence, absence_reason = @absenceReason" +
                             " WHERE day_id = @dayId AND employee_id = @employeeId";

            return executeNonQuery(sql, parameters);
        }

        protected Object InsertAbsence(int dayId, int employeeId) // !
        {
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString(), "None", "None", true.ToString(), "DayOff" };
            string sql = "INSERT INTO employees_workdays (day_id, employee_id, first_shift, second_shift, absence, absence_reason)" +
                    " VALUES(@dayId, @employeeId, @shift, @shift, @absence, @absenceReason);";

            return executeNonQuery(sql, parameters);
        }

        protected Object UpdateHours(double hours, int weekId,int employeeId)
        {
            string[] parameters;
            string sql;
            if(hours <= 0)
            {
                parameters = new string[] {weekId.ToString(), employeeId.ToString() };
                sql = "DELETE FROM worked_hours WHERE schedule_id = @scheduleId AND employee_id = @employeeId";
            }
            else
            {
                parameters = new string[] { hours.ToString(), weekId.ToString(), employeeId.ToString() };
                sql = "UPDATE worked_hours SET hours = @hours WHERE week_id = @scheduleId AND employee_id = @employeeId";

            }
            Object result = executeNonQuery(sql, parameters);
            CloseConnection();
            return result;
        }

        protected Object InsertHours(double hours, int weekId, int employeeId)
        {
            string[] parameters = new string[] { weekId.ToString(), employeeId.ToString(), hours.ToString() };
            string sql = "INSERT INTO worked_hours (week_id, employee_id, hours)" +
                "VALUES(@weekId, @employeeId, @hours)";
            Object result = executeNonQuery(sql, parameters);
            CloseConnection();
            return result;
        }


        protected Object SelectWorkedHours(int weekId, int employeeId)
        {
            string[] parameters = new string[] { weekId.ToString(), employeeId.ToString() };
            string sql = "SELECT hours FROM worked_hours WHERE week_id = @weekId AND employee_id = @employeeId";
           Object result = executeScalar(sql, parameters);
            CloseConnection();
            return result;
        }

        protected MySqlDataReader SelectDayOffRequests()
        {
            string sql = "SELECT * FROM dayoff_requests WHERE status = 'Pending'; ";
            return executeReader(sql, null);
        }

    }
}
