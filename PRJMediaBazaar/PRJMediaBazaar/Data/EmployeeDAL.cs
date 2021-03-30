using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Data
{
      class EmployeeDAL : BaseDAL
    {
        protected MySqlDataReader SelectAll()
        {
            return executeReader("SELECT * FROM employees;", null);
        }

    }
}
