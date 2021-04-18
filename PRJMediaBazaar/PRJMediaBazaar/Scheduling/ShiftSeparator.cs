using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class ShiftSeparator
    {
        private RegularEmployee[] allEmployees;

        private int neededShiftAmount;
        private EmployeeWorkday[] workdays;
        private List<RegularEmployee> morning;
        private List<RegularEmployee> mid;
        private List<RegularEmployee> evening;

        public ShiftSeparator(EmployeeWorkday[] workdays, int neededShiftAmount, RegularEmployee[] allEmployees)
        {
            morning = new List<RegularEmployee>();
            mid = new List<RegularEmployee>();
            evening = new List<RegularEmployee>();
            this.workdays = workdays;
            this.neededShiftAmount = neededShiftAmount;
            this.allEmployees = allEmployees;
            SeparateShifts();
        }

        private void SeparateShifts()
        {

            if (workdays != null)
            {
                foreach (EmployeeWorkday ew in workdays)
                {
                    RegularEmployee emp = GetEmployee(ew.EmployeeID);
                    if (ew.SecondShift == Shift.None || ew.FirstShift == Shift.None) //1  assigned shift
                    {
                        Shift busyShift = GetBusyShift(ew.FirstShift, ew.SecondShift);
                        

                        switch (busyShift)
                        {
                            case Shift.Morning:
                                morning.Add(emp);
                                break;
                            case Shift.Midday:
                                mid.Add(emp);
                                break;
                            case Shift.Evening:
                                evening.Add(emp);
                                break;
                        }
                    }
                    else  //2 assigned shifts
                    {
                        Shift emptyShift = GetEmptyShift(ew.FirstShift, ew.SecondShift);

                        string employeeName = ew.EmployeeName;

                        switch (emptyShift)
                        {
                            case Shift.Morning:
                                mid.Add(emp);
                                evening.Add(emp);
                                break;

                            case Shift.Evening:
                                morning.Add(emp);
                                mid.Add(emp);
                                break;
                        }
                    }
                }
               
            }
            while (morning.Count < neededShiftAmount)
            {
                morning.Add(null);
            }
            while (mid.Count < neededShiftAmount)
            {
                mid.Add(null);
            }
            while (evening.Count < neededShiftAmount)
            {
                evening.Add(null);
            }
        }

        public NamesRow[] GetNamesRows()
        {
           List<NamesRow> rows = new List<NamesRow>();
           for(int i = 0;i <neededShiftAmount;i++)
            {
                rows.Add(new NamesRow(morning[i], mid[i], evening[i]));
            }
            return rows.ToArray();
        }

        private Shift GetEmptyShift(Shift firstShift, Shift secondShift)
        {
            if (firstShift == Shift.None)
            {
                return firstShift;
            }
            else if (secondShift == Shift.None)
            {
                return secondShift;
            }
            else if ((firstShift == Shift.Morning && secondShift == Shift.Midday) || (secondShift == Shift.Morning && firstShift == Shift.Midday))
            {
                return Shift.Evening;
            }
            else if ((firstShift == Shift.Midday && secondShift == Shift.Evening) || (secondShift == Shift.Midday && firstShift == Shift.Evening))
            {
                return Shift.Morning;
            }
            return Shift.None;

        }

        private Shift GetBusyShift(Shift firstShift, Shift secondShift)
        {
            if (firstShift != Shift.None)
            {
                return firstShift;
            }
            return secondShift;

        }

        public RegularEmployee GetEmployee(int id)
        {
            foreach (RegularEmployee e in allEmployees)
            {
                if (e.Id == id)
                {
                    return e;
                }
            }
            return null;
        }

   
    }
}
