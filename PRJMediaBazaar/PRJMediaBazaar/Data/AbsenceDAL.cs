using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Logic;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Data
{
    class AbsenceDAL : BaseDAL
    {
        List<Employee> _employees;
        List<Schedule> _schedules;
        public AbsenceDAL(List<Employee> employees, List<Schedule> schedules)
        {
            _employees = employees;
            _schedules = schedules;
        }

        //public List<DayOff> SelectDayOffRequests()
        //{
        //    string sql = "SELECT * FROM dayoff_requests WHERE status = 'pending'; ";
        //    MySqlDataReader result = executeReader(sql, null);

        //    List<DayOff> pseudos = new List<DayOff>();
        //    while (result.Read())
        //    {
        //        int scheduleId = Convert.ToInt32(result[0]);

        //        int dayId = Convert.ToInt32(result[1]);
        //        Day day = GetSchedule(scheduleId).GetDay(dayId);

        //        int empId = Convert.ToInt32(result[2]);
        //        Employee employee = _employees.FirstOrDefault(emp => emp.Id == empId);

        //        bool urgent = Convert.ToBoolean(result[3]);
        //        string status = result[4].ToString();
        //        string reason = result[5].ToString();
        //        DayOff req = new DayOff(day, employee, urgent, status, reason);
        //        pseudos.Add(req);
        //    }
        //    CloseConnection();
        //    return pseudos;
        //}

        public List<DayOff> SelectDayOffRequests()
        {
            string sql = "SELECT * FROM dayoff_requests WHERE status = 'pending'; ";
            MySqlDataReader result = executeReader(sql, null);

            List<DayOff> pseudos = new List<DayOff>();
            while (result.Read())
            {
                int scheduleId = Convert.ToInt32(result[0]);

                int dayId = Convert.ToInt32(result[1]);
                Day day = GetSchedule(scheduleId).GetDay(dayId);

                int empId = Convert.ToInt32(result[2]);
                Employee employee = _employees.FirstOrDefault(emp => emp.Id == empId);

                bool urgent = Convert.ToBoolean(result[3]);
                string reason = result[4].ToString();
                string status = result[5].ToString();
                string objection = result[6].ToString();
                DayOff req = new DayOff( day,employee, urgent, status, reason, objection);
                pseudos.Add(req);
            }
            CloseConnection();
            return pseudos;
        }
        public bool ConfirmDayOffRequest(int dayId, int empId)
        {
            string[] parameters = new string[] { dayId.ToString(), empId.ToString() };
            string sql = "DELETE FROM dayoff_requests WHERE day_id = @dayId AND employee_id = @empId";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public bool DenyDayOffRequest(int empId, int dayId, string objection) //1. reason, 2. status, 3. employee_id
        {
            String sql = "UPDATE `dayoff_requests` SET `objection`= @reason, `status`= 'denied' " +
                "WHERE `employee_id`= @employee_id AND `day_id`= @dayId ; ";
            String[] parameters = new String[] { objection, empId.ToString(),dayId.ToString()};
            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }



        public List<SickReport> SelectSickReports()
        {
            string sql = "SELECT * FROM sick_reports WHERE seen = 'false'; ";
            MySqlDataReader result = executeReader(sql, null);

            List<SickReport> pseudos = new List<SickReport>();
            while (result.Read())
            {
                int scheduleId = Convert.ToInt32(result[0]);

                int dayId = Convert.ToInt32(result[1]);
                Day day = GetSchedule(scheduleId).GetDay(dayId);

                int empId = Convert.ToInt32(result[2]);
                Employee employee = _employees.FirstOrDefault(emp => emp.Id == empId);

                string description = result[3].ToString();
                bool seen = Convert.ToBoolean(result[4]);
                SickReport req = new SickReport(day, employee, description, seen);
                pseudos.Add(req);
            }
            CloseConnection();
            return pseudos;
        }

       

        public bool ConfirmSickReport(int dayId, int empId)
        {
            string[] parameters = new string[] { dayId.ToString(), empId.ToString() };
            string sql = "DELETE FROM sick_reports WHERE day_id = @dayId AND employee_id = @empId";

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
            string[] parameters = new string[] { "None", "None", 1.ToString(), "DayOff", dayId.ToString(), employeeId.ToString() };
            string sql = "UPDATE employees_workdays SET first_shift = @shift1, second_shift = @shift2, absence = @absence, absence_reason = @absenceReason" +
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
            string[] parameters = new string[] { dayId.ToString(), employeeId.ToString(), "None", "None", 1.ToString(), "DayOff" };
            string sql = "INSERT INTO employees_workdays (day_id, employee_id, first_shift, second_shift, absence, absence_reason)" +
                    " VALUES(@dayId, @employeeId, @shift1, @shift2, @absence, @absenceReason);";

            if (executeNonQuery(sql, parameters) != null)
            {
                CloseConnection();
                return true;
            }
            CloseConnection();
            return false;
        }

        public Schedule GetSchedule(int scheduleId)
        {
            foreach (Schedule s in _schedules)
            {
                if (s.Id == scheduleId)
                {
                    return s;
                }
            }
            return null;
        }


    }
}
