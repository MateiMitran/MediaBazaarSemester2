using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class Day
    {

        private List<EmployeePreference> _employeesPreferences;
        private List<EmployeeShift> _employeesShifts;

        public int Id { get; private set; }
        public int SecurityNeeded { get; private set; }
        public int CashiersNeeded { get; private set; }
        public int StockersNeeded { get; private set; }
        public int SalesAssistantsNeeded { get; private set; }
        public int WarehouseManagersNeeded { get; private set; }
        public DateTime Date { get; private set; }


        public Day(List<EmployeePreference> employeesPreferences, List<EmployeeShift> employeesShifts, int id,
            int securityNeeded, int cashiersNeeded, int stockersNeeded, int salesAssistantsNeeded,
            int warehouseManagersNeeded, DateTime date)
        {
            _employeesPreferences = employeesPreferences;
            _employeesShifts = employeesShifts;
            Id = id;
            SecurityNeeded = securityNeeded;
            CashiersNeeded = cashiersNeeded;
            StockersNeeded = stockersNeeded;
            SalesAssistantsNeeded = salesAssistantsNeeded;
            WarehouseManagersNeeded = warehouseManagersNeeded;
            Date = date;
        }


    }
}
