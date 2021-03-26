using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Logic
{
    class Day : ScheduleDAL
    {
        public int Id { get; private set; }
        public int SecurityNeeded { get; set; }
        public int CashiersNeeded { get; set; }
        public int StockersNeeded { get; set; }
        public int SalesAssistantsNeeded { get; set; }
        public int WarehouseManagersNeeded { get; set; }
        public DateTime Date { get; private set; }

        public Availabilities Availabilities { get; private set; }


        public Day(int id, DateTime date,
            int securityNeeded, int cashiersNeeded, int stockersNeeded, int salesAssistantsNeeded,
            int warehouseManagersNeeded)
        {

            Id = id;
            SecurityNeeded = securityNeeded;
            CashiersNeeded = cashiersNeeded;
            StockersNeeded = stockersNeeded;
            SalesAssistantsNeeded = salesAssistantsNeeded;
            WarehouseManagersNeeded = warehouseManagersNeeded;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Date.DayOfWeek} {Date.ToString("dd-MM-yyyy")}";
        }

        public int GetNeededPositionAmount(string jobPosition)
        {
            int neededPosition = -1;
            switch (jobPosition)
            {
                case "Security":
                    neededPosition = SecurityNeeded;
                    break;
                case "Cashier":
                    neededPosition = CashiersNeeded;
                    break;
                case "Stocker":
                    neededPosition = StockersNeeded;
                    break;
                case "SalesAssistant":
                    neededPosition = SalesAssistantsNeeded;
                    break;
                case "WarehouseManager":
                    neededPosition = WarehouseManagersNeeded;
                    break;

            }
            return neededPosition;
        }

        public string GetNeededPositionInfo(string jobPosition)
        {
            int amount = GetNeededPositionAmount(jobPosition);
            return $"Needed {jobPosition}: {amount}";
        }

        public string GetAllNeededPositionsInfo()
        {
            return $"Needed: {SecurityNeeded} Security| {CashiersNeeded} Cashiers| {StockersNeeded} Stockers|" +
                $" {SalesAssistantsNeeded} SalesAssistants| {WarehouseManagersNeeded} Managers";
        }

        public Object ChangeNeededJobPosition(string jobPosition, int amount)
        {
           return UpdatePosition(jobPosition, amount, Id);
        }

    }
}
