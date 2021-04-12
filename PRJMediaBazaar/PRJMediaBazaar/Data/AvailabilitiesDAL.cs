using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar.Data
{
    class AvailabilitiesDAL : BaseDAL
    {
        private EmployeeControl empControl;

        public AvailabilitiesDAL()
        {
            empControl = new EmployeeControl();
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
    }
}
