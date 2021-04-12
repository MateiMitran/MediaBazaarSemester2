using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Data
{
    class AvailabilitiesDAL : BaseDAL
    {
        /// <summary>
        /// takes all employees workdays, by the given job position
        /// </summary>
        /// <returns></returns>
        public MySqlDataReader SelectEmployeesWorkdays(int dayId, string jobPosition)
        {
            string[] parameters = new string[] { dayId.ToString(), jobPosition };
            string sql = "SELECT ew.* FROM employees_workdays ew INNER JOIN employees e ON ew.employee_id =e.id WHERE day_id = @dayId AND e.job_position = @jobPosition";

            return executeReader(sql, parameters);
        }
    }
}
