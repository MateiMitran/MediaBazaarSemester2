using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;

namespace PRJMediaBazaar.Logic
{
    class Day
    {
        private DayDAL dayDAL;
        private static string[] positions = new string[] { "Security", "Cashier", "Stocker","SalesAssistant","WarehouseManager"};
        public int Id { get; private set; }
        public int ScheduleId { get; private set; }
        public Duty SecurityNeeded { get; set; }
        public Duty CashiersNeeded { get; set; }
        public Duty StockersNeeded { get; set; }
        public Duty SalesAssistantsNeeded { get; set; }
        public Duty WarehouseManagersNeeded { get; set; }
        public DateTime Date { get; private set; }
        public int WeekId { get; private set; }

        public Duty[] AllPositions 
        {
            get
            {
                return new Duty[] { SecurityNeeded, CashiersNeeded, StockersNeeded, SalesAssistantsNeeded, WarehouseManagersNeeded };
            }
        }


        public Day()
        {
            /* EMPTY DAY OBJECT CONSTRUCTOR */
        }

        public Day(int id, DateTime date,int scheduleId, string securityNeeded, string cashiersNeeded,
            string stockersNeeded, string salesAssistantsNeeded,
           string warehouseManagersNeeded, int weekId, string securityAssigned, string cashiersAssigned,
            string stockersAssigned, string salesAssistantsAssigned,
           string warehouseManagersAssigned)
        {
            string[] security = securityNeeded.Split(' ');
            string[] cashiers = cashiersNeeded.Split(' ');
            string[] stockers = stockersNeeded.Split(' ');
            string[] assistants = salesAssistantsNeeded.Split(' ');
            string[] managers = warehouseManagersNeeded.Split(' ');

            string[] security_assigned = securityAssigned.Split(' ');
            string[] cashiers_assigned = cashiersAssigned.Split(' ');
            string[] stockers_assigned = stockersAssigned.Split(' ');
            string[] assistants_assigned = salesAssistantsAssigned.Split(' ');
            string[] managers_assigned = warehouseManagersAssigned.Split(' ');

            Id = id;
            ScheduleId = scheduleId;
            SecurityNeeded = new Duty(Convert.ToInt32(security[0]), Convert.ToInt32(security[1]), Convert.ToInt32(security[2]), "Security", Convert.ToInt32(security_assigned[0]), Convert.ToInt32(security_assigned[1]), Convert.ToInt32(security_assigned[2]));
            CashiersNeeded = new Duty(Convert.ToInt32(cashiers[0]), Convert.ToInt32(cashiers[1]), Convert.ToInt32(cashiers[2]), "Cashier", Convert.ToInt32(cashiers_assigned[0]), Convert.ToInt32(cashiers_assigned[1]), Convert.ToInt32(cashiers_assigned[2]));
            StockersNeeded = new Duty(Convert.ToInt32(stockers[0]), Convert.ToInt32(stockers[1]), Convert.ToInt32(stockers[2]), "Stocker", Convert.ToInt32(stockers_assigned[0]), Convert.ToInt32(stockers_assigned[1]), Convert.ToInt32(stockers_assigned[2]));
            SalesAssistantsNeeded = new Duty(Convert.ToInt32(assistants[0]), Convert.ToInt32(assistants[1]), Convert.ToInt32(assistants[2]), "SalesAssistant", Convert.ToInt32(assistants_assigned[0]), Convert.ToInt32(assistants_assigned[1]), Convert.ToInt32(assistants_assigned[2]));
            WarehouseManagersNeeded = new Duty(Convert.ToInt32(managers[0]), Convert.ToInt32(managers[1]), Convert.ToInt32(managers[2]), "WarehouseManager", Convert.ToInt32(managers_assigned[0]), Convert.ToInt32(managers_assigned[1]), Convert.ToInt32(managers_assigned[2]));
            Date = date;
            WeekId = weekId;
            dayDAL = new DayDAL();
            
        }

     

        public override string ToString()
        {
            return $"{Date.DayOfWeek} {Date.ToString("dd-MM-yyyy")}";
        }

        public Duty GetDuty(string jobPosition)
        {
            Duty duty = null;
            switch (jobPosition)
            {
                case "Security":
                    duty = SecurityNeeded;
                    break;
                case "Cashier":
                    duty = CashiersNeeded;
                    break;
                case "Stocker":
                    duty = StockersNeeded;
                    break;
                case "SalesAssistant":
                    duty = SalesAssistantsNeeded;
                    break;
                case "WarehouseManager":
                    duty = WarehouseManagersNeeded;
                    break;

            }
            return duty;
        }

        public string GetNeededPositionInfo(string jobPosition)
        {
            Duty amount = GetDuty(jobPosition);
            return $"Needed {jobPosition}: {amount}";
        }

        public string GetAllNeededPositionsInfo()
        {
            return $"Needed: {SecurityNeeded} Security| {CashiersNeeded} Cashiers| {StockersNeeded} Stockers|" +
                $" {SalesAssistantsNeeded} SalesAssistants| {WarehouseManagersNeeded} Managers";
        }

      
        public bool ChangeNeededDuties(string jobPosition, int morning, int midday, int evening)
        {
          
            string amounts = $"{morning} {midday} {evening}";
            bool result = dayDAL.UpdateNeededPosition(jobPosition, amounts, Id);
           if(result)
            {
                Duty duty = GetDuty(jobPosition);
                duty.MorningNeeded = morning;
                duty.MiddayNeeded = midday;
                duty.EveningNeeded = evening;
                return true;
            }
            return false;
        }

        public bool ChangeAssignedDuties(string jobPosition, int morning, int midday, int evening)
        {
            string amounts = $"{morning} {midday} {evening}";
            bool result = dayDAL.UpdateAssignedPosition(jobPosition, amounts, Id);
           if(result)
            {
                Duty duty = GetDuty(jobPosition);
                duty.MorningAssigned = morning;
                duty.MiddayAssigned = midday;
                duty.EveningAssigned = evening;
                return true;
            }
            return false;
        }

        public void EmptyDuties()
        {
           foreach(string jobPosition in positions)
            {
                Duty duty = GetDuty(jobPosition);
                duty.MorningAssigned =0;
                duty.MiddayAssigned = 0;
                duty.EveningAssigned = 0;
            }
        }

    }
}
