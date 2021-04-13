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
        private EmployeeControl empControl;

        public ScheduleDAL()
        {
            empControl = new EmployeeControl();
        }

        public List<Schedule> SelectSchedules()
        {
            MySqlDataReader dr = executeReader("SELECT * FROM schedules;", null);

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
             foreach(Schedule s in schedules)
            {
                s.AddDays(SelectDays(s.Id));
            }
            return schedules;
        }

        private List<Day> SelectDays(int scheduleId)
        {
            List<Day> days = new List<Day>();
            string[] parameters = new string[] { scheduleId.ToString() };
            MySqlDataReader dr = executeReader("SELECT * FROM days WHERE schedule_id = @scheduleId", parameters);

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
                string securityAssigned = Convert.ToString(dr[9]);
                string cashiersAssigned = Convert.ToString(dr[10]);
                string stockersAssigned = Convert.ToString(dr[11]);
                string salesAsstantsAssigned = Convert.ToString(dr[12]);
                string warehouseManagersAssigned = Convert.ToString(dr[13]);

                days.Add(new Day(dayId, date, scheduleId, securityNeeded, cashiersNeeded, stockersNeeded, salesAssistantsNeeded, warehouseManagersNeeded, weekId, securityAssigned,cashiersAssigned,stockersAssigned,salesAsstantsAssigned,warehouseManagersAssigned));

            }
            CloseConnection();
            return days;
        }

        /// <summary>
        /// takes all employees workdays, by the given job position
        /// </summary>
        /// <returns></returns>
        public List<EmployeeWorkday> SelectEmployeesWorkdays(int dayId, string jobPosition)
        {
            string[] parameters = new string[] { dayId.ToString(), jobPosition };
            string sql = "SELECT ew.* FROM employees_workdays ew INNER JOIN employees e ON ew.employee_id =e.id WHERE day_id = @dayId AND e.job_position = @jobPosition";
            List<EmployeeWorkday> workdays = new List<EmployeeWorkday>();
            MySqlDataReader dr = executeReader(sql, parameters);
            while (dr.Read()) //add EmployeeWorkday objects to the list
            {
                Employee employee = empControl.GetEmployee(Convert.ToInt32(dr[1]));
                Shift firstShift = (Shift)Enum.Parse(typeof(Shift), dr[2].ToString());
                Shift secondShift = (Shift)Enum.Parse(typeof(Shift), dr[3].ToString());
                bool absence = Convert.ToBoolean(dr[4]);
                AbsenceReason absenceReason = (AbsenceReason)Enum.Parse(typeof(AbsenceReason), dr[5].ToString());

                workdays.Add(new EmployeeWorkday(employee, firstShift, secondShift, absence, absenceReason));
            }
            CloseConnection();
            return workdays;
        }

        /// <summary>
        /// takes the employees who are not absent, by the given job position
        /// </summary>
        /// <param name="dayId"></param>
        /// <param name="jobPosition"></param>
        /// <returns></returns>
        public List<EmployeeWorkday> SelectEmployeesShifts(int dayId, string jobPosition)
        {
            string[] parameters = new string[] { dayId.ToString(), jobPosition };
            MySqlDataReader dr = executeReader("SELECT ew.* FROM employees_workdays ew INNER JOIN employees e ON ew.employee_id =e.id" +
                    "  WHERE day_id = @dayId AND e.job_position = @jobPosition AND absence = false;", parameters);
            List<EmployeeWorkday> workdays = new List<EmployeeWorkday>();
            while (dr.Read()) //add EmployeeWorkday objects to the list
            {
                Employee employee = empControl.GetEmployee(Convert.ToInt32(dr[1]));
                Shift firstShift = (Shift)Enum.Parse(typeof(Shift), dr[2].ToString());
                Shift secondShift = (Shift)Enum.Parse(typeof(Shift), dr[3].ToString());
                bool absence = Convert.ToBoolean(dr[4]);
                AbsenceReason absenceReason = (AbsenceReason)Enum.Parse(typeof(AbsenceReason), dr[5].ToString());

                workdays.Add(new EmployeeWorkday(employee, firstShift, secondShift, absence, absenceReason));
            }
            CloseConnection();
            return workdays;
        }


        /// <summary>
        /// takes the employee's workday
        /// </summary>
        /// <param name="dayId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public EmployeeWorkday SelectEmployeeWorkday(int dayId, int employeeId)
        {
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString() };
            string sql = "SELECT * FROM employees_workdays WHERE day_id = @dayId AND employee_id = @employeeId";
            EmployeeWorkday workday = null;
    
            MySqlDataReader dr = executeReader(sql, parameters);
            if (dr.Read())
            {
                Employee employee = empControl.GetEmployee(Convert.ToInt32(dr[1]));
                Shift firstShift = (Shift)Enum.Parse(typeof(Shift), dr[2].ToString());
                Shift secondShift = (Shift)Enum.Parse(typeof(Shift), dr[3].ToString());
                bool absence = Convert.ToBoolean(dr[4]);
                AbsenceReason absenceReason = (AbsenceReason)Enum.Parse(typeof(AbsenceReason), dr[5].ToString());

               workday = new EmployeeWorkday(employee, firstShift, secondShift, absence, absenceReason);
            }
            CloseConnection();
            return workday;
        }


        public bool UpdateShift(int emptyIndex, string shift, int dayId, int employeeId)
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
             if(executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
             return false;
        }


        public bool InsertShift(int dayId, int employeeId, string shift)
        {
            string sql = "INSERT INTO employees_workdays (day_id, employee_id, first_shift)" +
                " VALUES(@dayId, @employeeId, @shift);";
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString(), shift };

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public bool DeleteShift(int dayId, int employeeId)
        {
            string sql = "DELETE FROM employees_workdays WHERE day_id = @dayId AND employee_id = @employeeId";
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString() };

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public bool UpdateAbsence(int dayId, int employeeId) // !
        {
            string[] parameters = new string[] { "None", "None", true.ToString(), "DayOff", dayId.ToString(), employeeId.ToString() };
            string sql = "UPDATE employees_workdays SET first_shift = @shift, second_shift = @shift, absence = @absence, absence_reason = @absenceReason" +
                             " WHERE day_id = @dayId AND employee_id = @employeeId";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public bool InsertAbsence(int dayId, int employeeId) // !
        {
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString(), "None", "None", true.ToString(), "DayOff" };
            string sql = "INSERT INTO employees_workdays (day_id, employee_id, first_shift, second_shift, absence, absence_reason)" +
                    " VALUES(@dayId, @employeeId, @shift, @shift, @absence, @absenceReason);";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public bool UpdateHours(double hours, int weekId,int employeeId)
        {
            string[] parameters;
            string sql;
            if(hours <= 0)
            {
                parameters = new string[] {weekId.ToString(), employeeId.ToString() };
                sql = "DELETE FROM worked_hours WHERE week_id = @weekId AND employee_id = @employeeId";
            }
            else
            {
                parameters = new string[] { hours.ToString(), weekId.ToString(), employeeId.ToString() };
                sql = "UPDATE worked_hours SET hours = @hours WHERE week_id = @weekId AND employee_id = @employeeId";

            }
            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public bool InsertHours(double hours, int weekId, int employeeId)
        {
            string[] parameters = new string[] { weekId.ToString(), employeeId.ToString(), hours.ToString() };
            string sql = "INSERT INTO worked_hours (week_id, employee_id, hours)" +
                "VALUES(@weekId, @employeeId, @hours)";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public double SelectWorkedHours(int weekId, int employeeId)
        {
            string[] parameters = new string[] { weekId.ToString(), employeeId.ToString() };
            string sql = "SELECT hours FROM worked_hours WHERE week_id = @weekId AND employee_id = @employeeId";
           double result = Convert.ToDouble( executeScalar(sql, parameters));
            CloseConnection();
            return result;
            
        }

        public List<DayOff> SelectDayOffRequests()
        {
            string sql = "SELECT * FROM dayoff_requests WHERE status = 'pending'; ";
            MySqlDataReader result = executeReader(sql, null);

            List<DayOff> pseudos = new List<DayOff>();
            while (result.Read())
            {
                int scheduleId = Convert.ToInt32(result[0]);
                int dayId = Convert.ToInt32(result[1]);
                int employee_id = Convert.ToInt32(result[2]);
                bool urgent = Convert.ToBoolean(result[3]);
                string status = result[4].ToString();
                string reason = result[5].ToString();
                DayOff req = new DayOff(scheduleId, dayId, employee_id, urgent, status, reason);
                pseudos.Add(req);
            }
            CloseConnection();
            return pseudos;
        }

        public bool ConfirmDayOffRequest(int dayId, int empId)
        {
            string[] parameters = new string[] { dayId.ToString(), empId.ToString()};
            string sql = "DELETE FROM dayoff_requests WHERE day_id = @dayId AND employee_id = @empId";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public void RemoveSchedule(int dayId, int weekId)
        {
            string[] parameters = new string[] { dayId.ToString()};
            string sql = "DELETE FROM employees_workdays WHERE day_id = @dayId";
            executeNonQuery(sql, parameters);  
                CloseConnection();
           
            sql = "UPDATE days SET security_assigned = '0 0 0',cashiers_assigned = '0 0 0',stockers_assigned = '0 0 0'," +
                "stockers_assigned = '0 0 0',sales_assistants_assigned = '0 0 0', warehouse_managers_assigned = '0 0 0'" +
                "   WHERE id = @dayId";
            executeNonQuery(sql, parameters);
            CloseConnection();

            parameters = new string[] {weekId.ToString() };
            sql = "DELETE FROM worked_hours WHERE week_id = @weekId";
            executeNonQuery(sql, parameters);
            CloseConnection();

        }
        public List<int> SelectAvailableEmployeesIds(string position, int dayId)
        {
            List<int> ids = new List<int>();
            string[] parameters = new string[] { position, dayId.ToString() };
            string sql = "SELECT id FROM employees WHERE job_position = @position AND id NOT IN (SELECT employee_id FROM employees_workdays WHERE day_id = @dayId)";
            MySqlDataReader dr = executeReader(sql, parameters);
            while (dr.Read())
            {
                ids.Add(Convert.ToInt32(dr[0]));
            }
            CloseConnection();
            return ids;

        }
    }
}
