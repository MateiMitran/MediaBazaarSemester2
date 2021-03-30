using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PRJMediaBazaar.Data
{
    class DayDAL : BaseDAL
    {
        protected Object UpdatePosition(string jobPosition, int amount, int dayId)
        {
            string sql = "";
            string[] parameters = new string[] { amount.ToString(), dayId.ToString() };
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
            return executeNonQuery(sql, parameters);
        }
    }
}
