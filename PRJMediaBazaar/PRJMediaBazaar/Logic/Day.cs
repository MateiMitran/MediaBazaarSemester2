using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Logic
{
    class Day : DayDAL
    {

        public int Id { get; private set; }
        public NeededPositions SecurityNeeded { get; set; }
        public NeededPositions CashiersNeeded { get; set; }
        public NeededPositions StockersNeeded { get; set; }
        public NeededPositions SalesAssistantsNeeded { get; set; }
        public NeededPositions WarehouseManagersNeeded { get; set; }
        public DateTime Date { get; private set; }


        public Day(int id, DateTime date, string securityNeeded, string cashiersNeeded,
            string stockersNeeded, string salesAssistantsNeeded,
           string warehouseManagersNeeded)
        {
            string[] security = securityNeeded.Split(' ');
            string[] cashiers = cashiersNeeded.Split(' ');
            string[] stockers = stockersNeeded.Split(' ');
            string[] assistants = salesAssistantsNeeded.Split(' ');
            string[] managers = warehouseManagersNeeded.Split(' ');

            Id = id;
            SecurityNeeded = new NeededPositions(Convert.ToInt32(security[0]), Convert.ToInt32(security[1]), Convert.ToInt32(security[2]));
            CashiersNeeded = new NeededPositions(Convert.ToInt32(cashiers[0]), Convert.ToInt32(cashiers[1]), Convert.ToInt32(cashiers[2]));
            StockersNeeded = new NeededPositions(Convert.ToInt32(stockers[0]), Convert.ToInt32(stockers[1]), Convert.ToInt32(stockers[2]));
            SalesAssistantsNeeded = new NeededPositions(Convert.ToInt32(assistants[0]), Convert.ToInt32(assistants[1]), Convert.ToInt32(assistants[2]));
            WarehouseManagersNeeded = new NeededPositions(Convert.ToInt32(managers[0]), Convert.ToInt32(managers[1]), Convert.ToInt32(managers[2]));
            Date = date;
        }

     

        public override string ToString()
        {
            return $"{Date.DayOfWeek} {Date.ToString("dd-MM-yyyy")}";
        }

        public NeededPositions GetNeededPositionAmount(string jobPosition)
        {
            NeededPositions neededPosition = null;
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
            NeededPositions amount = GetNeededPositionAmount(jobPosition);
            return $"Needed {jobPosition}: {amount}";
        }

        public string GetAllNeededPositionsInfo()
        {
            return $"Needed: {SecurityNeeded} Security| {CashiersNeeded} Cashiers| {StockersNeeded} Stockers|" +
                $" {SalesAssistantsNeeded} SalesAssistants| {WarehouseManagersNeeded} Managers";
        }

      
        public Object ChangeNeededJobPosition(string jobPosition, int morning, int midday, int evening)
        {
            string amounts = $"{morning} {midday} {evening}";
           Object result = UpdatePosition(jobPosition, amounts, Id);
            CloseConnection();
            return result;
        }

    }
}
