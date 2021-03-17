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
    class Availabilities
    {
        private static readonly string connStr = "server=studmysql01.fhict.local;database=dbi460221;uid=dbi460221;password=lol;";

        private RegularEmployee[] employees;
        private List<EmployeePlanner> availableEmployees;
        private List<EmployeePlanner> unavailableEmployees;

        public Availabilities(string jobPosition, int dayId, Shift shift)
        {
            this.employees = Database.GetEmployees(jobPosition);
            this.availableEmployees = new List<EmployeePlanner>();
            this.unavailableEmployees = new List<EmployeePlanner>();
            PopulateList(dayId, shift);
        }


        public List<EmployeePlanner> AvailableEmployees { get { return this.availableEmployees; } }
        public List<EmployeePlanner> UnavailableEmployees { get { return this.unavailableEmployees; } }

        private void PopulateList(int dayId, Shift shift)
        {
            foreach (RegularEmployee e in this.employees)
            {
                MySqlConnection conn = null;
                try
                {

                    conn = new MySqlConnection(connStr);
                    int employeeId = e.Id;
                    string sql = "SELECT * FROM employees_workdays WHERE day_id = @dayId AND employee_id = @employeeId";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@dayId", dayId);
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);

                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    if (result.Read()) //the employee is in the workdays_table
                    {
                        if (!Convert.ToBoolean(result[4])) //the employee isn't absent
                        {
                            int index = Database.GetEmptyShiftIndex(result[2].ToString(), result[3].ToString());
                            int busyIndex = Database.GetBusyShiftIndex(result[2].ToString(), result[3].ToString());

                            if (index == -1)  //employee has a double shift
                            {
                                string name = $"{e.FirstName} {e.LastName}";
                                EmployeePlanner ea = new EmployeePlanner(e.Id,name, "Double shift", -1);
                                unavailableEmployees.Add(ea);
                            }

                            else if (index != -1 && Database.DoubleShiftIsValid(result[busyIndex].ToString(), shift.ToString())) //employee has only one shift, and the second one is valid
                            {
                                string name = $"{e.FirstName} {e.LastName}";
                                EmployeePlanner ea = new EmployeePlanner(e.Id,name, result[busyIndex].ToString(), index);
                                availableEmployees.Add(ea);
                            }
                            else // the double shift is invalid
                            {
                                string name = $"{e.FirstName} {e.LastName}";
                                EmployeePlanner ea = new EmployeePlanner(e.Id,name, result[busyIndex].ToString(), -1);
                                unavailableEmployees.Add(ea);
                            }
                        }

                        else if (Convert.ToBoolean(result[4])) //is absent
                        {
                            string name = $"{e.FirstName} {e.LastName}";
                            EmployeePlanner ea = new EmployeePlanner(e.Id,name, result[5].ToString(), -1);
                            unavailableEmployees.Add(ea);
                        }


                    }

                    else //if the employee is not in the employees_workdays table, add availability
                    {
                        string name = $"{e.FirstName} {e.LastName}";
                        EmployeePlanner ea = new EmployeePlanner(e.Id,name, "None", -1);
                        availableEmployees.Add(ea);
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
           
        }

    }
}
