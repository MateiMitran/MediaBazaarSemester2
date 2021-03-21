﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PRJMediaBazaar
{
    static class Database
    {
        private static readonly string connStr = "server=studmysql01.fhict.local;database=dbi460221;uid=dbi460221;password=lol;";

        //============================================================SCHEDULING=================================================================================


        public static EmployeeWorkday[] GetEmployeesWorkdays(int dayId, string jobPosition)
        {
            MySqlConnection conn = null;
            List<EmployeeWorkday> workdays = new List<EmployeeWorkday>();
            try
            {
                conn = new MySqlConnection(connStr);

                String sql = "SELECT ew.*, d.date, e.first_name, e.last_name FROM employees_workdays ew INNER JOIN days d ON ew.day_id = d.id" +
                    " INNER JOIN employees e ON ew.employee_id = e.id WHERE ew.day_id = @dayId AND job_position = @jobPosition AND ew.absence = false;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dayId", dayId);
                cmd.Parameters.AddWithValue("@jobPosition", jobPosition);

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read()) //add EmployeeWorkday objects to the list
                    {
                        int employeeId = Convert.ToInt32(dr[1]);
                        Shift firstShift = (Shift)Enum.Parse(typeof(Shift), dr[2].ToString());
                        Shift secondShift = (Shift)Enum.Parse(typeof(Shift), dr[3].ToString());
                        bool absence = Convert.ToBoolean(dr[4]);
                        AbsenceReason absenceReason = (AbsenceReason)Enum.Parse(typeof(AbsenceReason), dr[5].ToString());
                        DateTime date = DateTime.Parse(dr[6].ToString());
                         string fullName = dr[7].ToString() + " " + dr[8].ToString();
                        workdays.Add(new EmployeeWorkday(dayId, date, employeeId, firstShift, secondShift, absence, absenceReason, jobPosition, fullName));
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
            return workdays.ToArray();
        }

        public static Schedule[] GetAllSchedules()
        {
            List<Schedule> schedules = new List<Schedule>();

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connStr);

                String sql = "SELECT * FROM schedules;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr[0]);
                    DateTime startDate = dr.GetDateTime(1);
                    DateTime endDate = dr.GetDateTime(2);
                    bool isOutdated = Convert.ToBoolean(dr[3]);
                    schedules.Add(new Schedule(id, startDate, endDate, isOutdated));
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
            return schedules.ToArray();
        }

        public static Day[] GetDays(int scheduleId)
        {
            MySqlConnection conn = null;
            List<Day> days = new List<Day>();

            try
            {
                conn = new MySqlConnection(connStr);

                String sql = "SELECT * FROM days WHERE schedule_id = @scheduleId";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                conn.Open();
               MySqlDataReader dr = cmd.ExecuteReader();
              while(dr.Read())
                {
                    int dayId = Convert.ToInt32(dr[0]);
                    DateTime date = dr.GetDateTime(1);
                    int securityNeeded = Convert.ToInt32(dr[3]);
                    int cashiersNeeded = Convert.ToInt32(dr[4]);
                    int stockersNeeded = Convert.ToInt32(dr[5]);
                    int salesAssistantsNeeded = Convert.ToInt32(dr[6]);
                    int warehouseManagersNeeded = Convert.ToInt32(dr[7]);

                    days.Add(new Day(dayId,date,securityNeeded,cashiersNeeded,stockersNeeded,salesAssistantsNeeded,warehouseManagersNeeded));

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
            return days.ToArray();
        }


        //to be implemented
        public static bool DayIsFull(int dayId)
        {
            //get the positions_needed for that day
            //get the count of each shift in employees_workdays and compare it to the coresponding the positionNeeded
            return false;
        }
        

        //Helping methods for GetSchedule()


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

        //ASSIGNING SHIFTS

        //Helping methods for AssignShift()
        public static int GetEmptyShiftIndex(string firstShift, string secondShift)
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

        public static int GetBusyShiftIndex(string firstShift, string secondShift)
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

        public static bool DoubleShiftIsValid(string assignedShift, string shiftToAssign)
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
        private static bool UpdateSecondShift(Shift shift, int employeeId, int dayId, int shiftIndex)
        {

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                String sql = "";

                switch (shiftIndex)
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

        } //also used for DeleteShift() for double shifts

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

        public static bool AssignShift(Shift shift, int employeeId, int dayId, int emptyShiftIndex)
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
                if (result.Read()) //the employee is in the workdays_table
                {
                    return UpdateSecondShift(shift, employeeId, dayId, emptyShiftIndex);                
                }

                else //if the employee is not in the employees_workdays table, insert a row
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

        //REMOVING SHIFTS

        public static bool RemoveShift(Shift shift, int employeeId, int dayId)
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
                if (result.Read())
                {
                    int emptyShiftIndex = GetEmptyShiftIndex(result[2].ToString(), result[3].ToString());


                    if (emptyShiftIndex != -1 && !Convert.ToBoolean(result[4])) //if there is an empty shift, remove the row
                    {
                        return RemoveEmployeeWorkday(dayId, employeeId);
                    }
                    else if (emptyShiftIndex == -1 && !Convert.ToBoolean(result[4]))//if there is a double shift,insert None on the chosen one
                    {
                        int indexToReplace = GetShiftIndex(shift, dayId, employeeId);
                        return UpdateSecondShift(Shift.None, employeeId, dayId, indexToReplace);
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
            return false;

        }

        private static bool RemoveEmployeeWorkday(int dayId, int employeeId)
        {
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                String sql = "DELETE FROM employees_workdays WHERE day_id = @dayId AND employee_id = @employeeId";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dayId", dayId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Successfully removed an employee workday");
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

        private static int GetShiftIndex(Shift shift, int dayId, int employeeId)
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
                if (result.Read())
                {
                    if (result[2].ToString() == shift.ToString()) { return 2; }
                    else if (result[3].ToString() == shift.ToString()) { return 3; }
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
            return -1;

        }

        //ASSIGNING ABSENCE
        public static bool AssignDayOff(int employeeId, int dayId)
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
                    MessageBox.Show("Successfully updated an employee workday with absence");
                    return UpdateAbsence(employeeId, dayId,true,AbsenceReason.None);
                }

                else
                {
                    return InsertEmployeeWorkdayWithDayOff(employeeId, dayId);
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

        /// <summary>
        /// For assigning absence: absence = true, absenceReason = DayOff ||
        /// For removing absence: absence = false, absenceReason = None
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="dayId"></param>
        /// <param name="absence"></param>
        /// <param name="absenceReason"></param>
        /// <returns></returns>
        private static bool UpdateAbsence(int employeeId, int dayId, bool absence, AbsenceReason absenceReason)
        {

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                String sql = "UPDATE employees_workdays SET first_shift = @shift, second_shift = @shift, absence = @absence, absence_reason = @absenceReason" +
                             " WHERE day_id = @dayId AND employee_id = @employeeId";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dayId", dayId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@shift", Shift.None.ToString());
                cmd.Parameters.AddWithValue("@absence", absence);
                cmd.Parameters.AddWithValue("@absenceReason", absenceReason.ToString());
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
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

        private static bool InsertEmployeeWorkdayWithDayOff(int employeeId,int dayId)
        {

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                String sql = "INSERT INTO employees_workdays (day_id, employee_id, first_shift, second_shift, absence, absence_reason)" +
                    " VALUES(@dayId, @employeeId, @shift, @shift, @absence, @absenceReason);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dayId", dayId);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@shift", Shift.None.ToString());
                cmd.Parameters.AddWithValue("@absence", true );
                cmd.Parameters.AddWithValue("@absenceReason", AbsenceReason.DayOff.ToString());

                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Successfully added a workday with absence");
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

        //Daily job positions

        public static List<int> GetAllNeededJobPositionsAmounts(int dayId)
        {
            MySqlConnection conn = null;
            List<int> neededPositions = new List<int>();
            try
            {
                conn = new MySqlConnection(connStr);

                String sql = "SELECT * FROM days WHERE id = @dayId";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dayId", dayId);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    neededPositions.Add(Convert.ToInt32(dr[3]));
                    neededPositions.Add(Convert.ToInt32(dr[4]));
                    neededPositions.Add(Convert.ToInt32(dr[5]));
                    neededPositions.Add(Convert.ToInt32(dr[6]));
                    neededPositions.Add(Convert.ToInt32(dr[7]));
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
            return neededPositions;
        }

        public static int GetNeededJobPositionAmount(string jobPosition, int dayId)
        {
            List<int> list = GetAllNeededJobPositionsAmounts(dayId);
            int neededPosition = -1;
            switch(jobPosition)
            {
                case "Security":
                    neededPosition = list[0];
                    break;
                case "Cashier":
                    neededPosition = list[1];
                    break;
                case "Stocker":
                    neededPosition = list[2];
                    break;
                case "SalesAssistant":
                    neededPosition = list[3];
                    break;
                case "WarehouseManager":
                    neededPosition = list[4];
                    break;

            }
            return neededPosition;
        }


        public static bool ChangeNeededJobPosition(string jobPosition, int amount, int dayId)
        {
            MySqlConnection conn = null;

            try
            {
              
                conn = new MySqlConnection(connStr);
                String sql = GetNeededPositionUPDATEQuery(jobPosition);
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dayId", dayId);
                cmd.Parameters.AddWithValue("@amount", amount);



                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
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

        private static string GetNeededPositionUPDATEQuery(string jobPosition)
        {
            string sql = "";

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
            return sql;
        }

        //===========================================================ACCOUNTING================================================================================

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

        public static RegularEmployee[] GetEmployees(string jobPosition)
        {
            List<RegularEmployee> employees = new List<RegularEmployee>();
           foreach (RegularEmployee e in GetEmployees())
            {
                if (e.JobPosition == jobPosition)
                {
                    employees.Add(e);
                }
            }
            return employees.ToArray();
        }

        
    }

}
