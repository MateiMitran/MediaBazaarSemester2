using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PRJMediaBazaar
{
    class DatabaseHelper
    {
       private static readonly string connStr = "server=studmysql01.fhict.local;database=dbi460221;uid=dbi460221;password=lol;";

        public static RegularEmployee[] GetEmployees()
        {

            MySqlConnection conn = null;
            List<RegularEmployee> employees = new List<RegularEmployee>();
            try
            {
                conn = new MySqlConnection(connStr);
            
                    String sql = "SELECT* FROM employees;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr[0]);
                        String firstName = dr[1].ToString();
                        String lastName = dr[2].ToString();
                        DateTime birthDate = Convert.ToDateTime(dr[3]);
                        String email = dr[4].ToString();
                        String password = dr[5].ToString();
                        String jobPosition = dr[6].ToString();
                        int phoneNumber = Convert.ToInt32(dr[7]);
                        String address = dr[8].ToString();
                        double salary = Convert.ToDouble(dr[9]);
                        String gender = dr[10].ToString();
                        String education = dr[11].ToString();
                        employees.Add(new RegularEmployee(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition, phoneNumber, address, education));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occured!");
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return employees.ToArray();
          
        }


        public static bool CreateEmptySchedule(DateTime startDate)
        {
            DateTime endDate = startDate.AddDays(13);
            if (GetScheduleId(startDate, endDate) > 0)
            {
                MessageBox.Show("Schedule already exists");
                return false;
            }

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                String sql = "INSERT INTO schedules(start_date,end_date) VALUES(@startDate,@endDate) ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                {
                    int scheduleId = GetScheduleId(startDate, endDate);
                    for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
                    {
                        String sql2 = "INSERT INTO days(date,schedule_id) VALUES(@date,@scheduleId)";
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                        cmd2.Parameters.AddWithValue("@date", date);
                        cmd2.Parameters.AddWithValue("@scheduleId", scheduleId );
                        cmd2.ExecuteNonQuery();
                    }
                    return true;
                }
                
            }
            catch (MySqlException ex)
            {
               MessageBox.Show("An error occured!");
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return false;
        }

        //public static Schedule GetSchedule(DateTime startDate, DateTime endDate)
        //{
        //    int scheduleId = GetScheduleId(startDate, endDate);
        //    if (scheduleId > 0 && ScheduleIsEmpty(scheduleId))
        //    {
        //        //SQL query the days table for that scheduleId and add them to a List<Days>
        //        //create the Schedule object and return it
        //    }

        //    else if (scheduleId > 0 && !ScheduleIsEmpty(scheduleId))
        //    {

        //        //create the Schedule object
        //        //make the List<Days> ---> SQL query the days table for that scheduleId and add them to a List<Days>
        //        //make the List<EmployeeShifts>  ---> SQL query employee_workdays with dayID in (get the dayId's with this scheduleId)
        //        //foreach Day d
        //        //(
        //        //   //foreach EmployeeShift es
        //        //   //if(es.dayID == d.dayId)
        //        //{
        //        //    // day.AddEmployeeShift(es);
        //        //}

        //        //)
        //    }
        //    return null;
        //}

        private static int GetScheduleId(DateTime startDate, DateTime endDate)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            int id = 0;

            try
            {
                using (conn)
                {
                    String sql = "SELECT id FROM schedules WHERE start_date = @startDate AND end_date = @endDate;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                   Object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        id = Convert.ToInt32(result);
                    }
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occured!");
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return id;

        }


        //private static bool ScheduleIsEmpty(int scheduleId)
        //{

        //    if (/*SQL query retrieves an existing schedule ,
        //          * where scheduleId is NOT in employees_workdays table*/)
        //    {
        //        return true;
        //    }
        //    return false;
        //}


        // public static bool AssignShift(Shift shift, int employeeID , int DayId)
        // {

        //     if (/*query retrieves a row where the employee has ONLY one shift assigned for that dayId */)
        //     {
        //         //SQL quey to add the second shift to the employees_workdays table
        //         return true;
        //     }

        //     else if (/*query doesn't retrieve a row for that dayId*/)
        //     {

        //         //SQL quey to add a new row with the parameters to the employees_workdays table
        //         return true;

        //     }
        //     return false;
        // }

        // public static void DeleteShift(Shift shift, int employeeID, int DayId)
        // {

        //     if (/*if the employee doesn't have a double shift*/) 
        //     {
        //         //SQL query to remove the shift from employees_workdays table

        //     }
        //     else //check which shift is selected and replace it with Shift.None
        //     {
        //        //SQL query to replace the shift with "None"
        //     }

        // }

        // public static void AssignAbsence(AbsenceReason absenceReason, int employeeID , int dayId)
        // {

        //     if (/*if query retrieves a row for this dayID*/)
        //     {
        //         //SQL - UPDATE the row in employees_workdays with the new values. (Shift- "None" + Absence & AbsenceReason)
        //     }
        //     else
        //     {

        //         //SQL - INSERT a new row in employees_workdays with Absence and AbsenceReason
        //     }

        // }

        // public static void ChangeNeededJobPosition(JobPosition jobPosition, int amount , int dayId)
        // {
        //     //SQL query to UPDATE the value in the days table
        // }

    }
}
