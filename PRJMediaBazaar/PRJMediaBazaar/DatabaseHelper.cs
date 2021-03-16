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

                                                                   //SCHEDULING

        //Helping methods for GetSchedule()

        /// <summary>
        /// Creating the Schedule with a List of 14 Days, each day has empty List<EmployeeShift> and List<EmployeePreference>
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Schedule</returns>
        private static Schedule GetEmptySchedule(DateTime startDate, DateTime endDate)
        {
            int scheduleId = GetScheduleId(startDate, endDate);
            Schedule schedule = null;
            List<Day> days = new List<Day>();

                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connStr);

                    String sql = "SELECT * FROM days WHERE schedule_id = @scheduleId;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr[0]);
                        DateTime date = DateTime.Parse(dr[1].ToString());
                        int securityNeeded = Convert.ToInt32(dr[3]);
                        int cashiersNeeded = Convert.ToInt32(dr[4]);
                        int stockersNeeded = Convert.ToInt32(dr[5]);
                        int salesAssistantsNeeded = Convert.ToInt32(dr[6]);
                        int warehouseManagersNeeded = Convert.ToInt32(dr[7]);
                        days.Add(new Day(id, date, securityNeeded, cashiersNeeded, stockersNeeded, salesAssistantsNeeded, warehouseManagersNeeded));
                    }

                    schedule = new Schedule(days, scheduleId, startDate, endDate);
                 
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
                return schedule;
        }

   
        private static int GetScheduleId(DateTime startDate, DateTime endDate)
        {
            MySqlConnection conn = null;
            int id = 0;

            try
            {
                conn = new MySqlConnection(connStr);
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

        /// <summary>
        /// Checks if the scheduleId is related to the employees_workdays table in the database
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns>bool</returns>
        private static bool ScheduleIsEmpty(int scheduleId)
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                String sql = "SELECT d.schedule_id FROM days d INNER JOIN employees_workdays ew ON d.id = ew.day_id WHERE d.schedule_id = @scheduleId;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                conn.Open();
                Object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    return true;
                }
                conn.Close();

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

        //Helping methods for AssignShift()
        private static int GetEmptyShiftIndex(string firstShift, string secondShift)
        {
            if (firstShift == "None" && secondShift != "None")
            {
                return 2;
            }
            else if (secondShift == "None" && firstShift != "None")
            {
                return 3;
            }
            return -1;
        }

        private static int GetBusyShiftIndex(string firstShift, string secondShift)
        {
            if (firstShift == "None" && secondShift != "None")
            {
                return 3;
            }
            else if (secondShift == "None" && firstShift != "None")
            {
                return 2;
            }
            return -1;
        }

        private static bool DoubleShiftIsValid(string assignedShift, string shiftToAssign)
        {
            if (assignedShift == "Morning" && shiftToAssign == "Evening")
            {
                return false;
            }

            if (assignedShift == "Evening" && shiftToAssign == "Morning")
            {
                return false;
            }

            if (assignedShift == shiftToAssign)
            {
                return false;
            }

            return true;

        }

        //The main methods for AssignShift()
        private static bool AssignSecondShift(Shift shift, int employeeId, int dayId, int indexOfShift)
        {

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                String sql = "";

                switch (indexOfShift)
                {
                    case 2:
                        sql = "UPDATE employees_workdays SET first_shift = @shift WHERE day_id = @dayId AND employee_id = @employeeId;";
                        break;
                    case 3:
                        sql = "UPDATE employees_workdays SET second_shift = @shift WHERE day_id = @dayId AND employee_id = @employeeId;";
                        break;
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@shift", shift.ToString());
                cmd.Parameters.AddWithValue("@dayId", dayId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Successfully added a second shift!");
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

        private static bool InsertEmployeeWorkday(Shift shift, int employeeId, int dayId)
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                String sql = "INSERT INTO employees_workdays (day_id, employee_id, first_shift) VALUES(@dayId, @employeeId, @shift);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@shift", shift.ToString());
                cmd.Parameters.AddWithValue("@dayId", dayId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Successfully added a shift");
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


        //Public methods
        /// <summary>
        /// Make sure you've parsed the dates with: DateTime.ParseExact("the date", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static Schedule GetSchedule(DateTime startDate, DateTime endDate)
        {
            int scheduleId = GetScheduleId(startDate, endDate);
            Schedule schedule = null;

            if (scheduleId > 0 && ScheduleIsEmpty(scheduleId))
            {
                schedule = GetEmptySchedule(startDate, endDate); // Get the schedule with empty EmployeeShift list in the days
            }

            else if (scheduleId > 0 && !ScheduleIsEmpty(scheduleId))
            {

                schedule = GetEmptySchedule(startDate,endDate);
                List<EmployeeShift> employeeShifts = new List<EmployeeShift>();

                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connStr);

                    String sql = "SELECT ew.*, d.date FROM employees_workdays ew INNER JOIN days d ON ew.day_id = d.id WHERE ew.day_id IN (SELECT id FROM days WHERE schedule_id = @scheduleId);";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) //add EmployeeShift objects to the list of employeeShifts
                    {
                        int dayId = Convert.ToInt32(dr[0]);
                        int employeeId = Convert.ToInt32(dr[1]);
                       Shift firstShift = (Shift)Enum.Parse(typeof(Shift), dr[2].ToString());
                       Shift secondShift = (Shift)Enum.Parse(typeof(Shift), dr[3].ToString());
                        bool absence = Convert.ToBoolean(dr[4]);
                       AbsenceReason absenceReason = (AbsenceReason)Enum.Parse(typeof(AbsenceReason), dr[5].ToString());
                       DateTime date = DateTime.Parse(dr[6].ToString());
                        employeeShifts.Add(new EmployeeShift(dayId, date, employeeId, firstShift, secondShift, absence,absenceReason));
                    }
                    foreach (Day d in schedule.Days) // separate the EmployeeShift objects in the days they belong to
                    {
                        foreach (EmployeeShift es in employeeShifts)
                        {
                            if (es.DayID == d.Id)
                            {
                                d.AddEmployeeShiftFromDatabase(es);
                            }
                        }
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

            }
            return schedule;
        }


        public static bool AssignShift(Shift shift, int employeeId, int dayId)
        {

            MySqlConnection conn = null;

            try
            {
               
                conn = new MySqlConnection(connStr);

                //returns a row if the employee is in the employees_workdays table
                String sql = "SELECT * FROM employees_workdays WHERE day_id = @dayId AND employee_id = @employeeId";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dayId", dayId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);

                conn.Open();
               MySqlDataReader result = cmd.ExecuteReader();
                if (result.Read()) //if the employee is in the workdays_table
                {
                    int index = GetEmptyShiftIndex(result[2].ToString(),result[3].ToString());
                    int busyIndex = GetBusyShiftIndex(result[2].ToString(), result[3].ToString());

                   if (index == -1)  //employee has a double shift
                    {
                        MessageBox.Show("Employee already has a double shift");
                        return false;
                    }

                   else if (index != -1 && DoubleShiftIsValid(result[busyIndex].ToString(), shift.ToString())) //employee has only one shift, and the second one is valid
                    {
                       return AssignSecondShift(shift, employeeId, dayId, index);
                    }
                   else
                    {
                        MessageBox.Show("Double shift is invalid! Shifts should be consecutive.");
                        return false;
                    }
                }

                else if (!result.Read()) //if the employee has no shifts assigned, insert a row in the table
                {
                   return InsertEmployeeWorkday(shift, employeeId, dayId);
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

                                                                      //ACCOUNTING

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

    }
}
