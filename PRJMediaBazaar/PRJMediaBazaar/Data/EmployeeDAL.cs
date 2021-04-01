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
        protected Object AddEmployee(String firstName, String lastName,DateTime birthDate,String email,String password,String jobPosition,int phoneNumber,String address,int salary,String gender,String education,String contract,int daysOff,int contractHours)
        {
            String format = "yyyy-MM-dd";
            String sql = "INSERT INTO `employees` (`id`,`first_name`,`last_name`,`birthDate`,`email`,`password`,`job_position`,`phoneNumber`,`address`,`salary`,`gender`,`education`,`Contract`,`DaysOff`,`ContractHours`) "
                        + "VALUES(NULL,@firstName,@lastName,@birthDate,@email,@password,@jobPosition,@phoneNumber,@address,@salary,@gender,@education,@contract,@daysOff,@contractHours);";
            String[] parameters = new String[] {firstName, lastName, birthDate.ToString(format), email, password, jobPosition, phoneNumber.ToString(), address, salary.ToString(), gender, education, contract, daysOff.ToString(), contractHours.ToString() };
            return executeNonQuery(sql, parameters);
        }
        protected Object GetIDByEmail(String Email)
        {
            String sql = "SELECT id FROM employees WHERE email=@email;";
            String[] parameters = new String[] { Email };
            return executeScalar(sql, parameters);
        }
        protected Object AddNoteToEmployee(String email,String note)
        {
            String sql = "UPDATE `employees` SET `Notes`= @note WHERE `email`= @email;";
            String[] parameters = new String[] { email, note };
            return executeNonQuery(sql, parameters);
        }

    }
}
