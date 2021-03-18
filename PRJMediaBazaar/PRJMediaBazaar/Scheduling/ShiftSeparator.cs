using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class ShiftSeparator
    {
        private int neededShiftAmount;
        private EmployeeWorkday[] workdays;
        private List<string> morning;
        private List<string> mid;
        private List<string> evening;

        public ShiftSeparator(EmployeeWorkday[] workdays, int neededShiftAmount)
        {
            morning = new List<string>();
            mid = new List<string>();
            evening = new List<string>();
            this.workdays = workdays;
            this.neededShiftAmount = neededShiftAmount;
            SeparateShifts();
        }

        private void SeparateShifts()
        {

            if (workdays != null)
            {
                foreach (EmployeeWorkday ew in workdays)
                {

                    if (ew.SecondShift == Shift.None || ew.FirstShift == Shift.None) //1  assigned shift
                    {
                        Shift busyShift = GetBusyShift(ew.FirstShift, ew.SecondShift);
                        string employeeName = ew.EmployeeName;

                        switch (busyShift)
                        {
                            case Shift.Morning:
                                morning.Add(employeeName);
                                break;
                            case Shift.Midday:
                                mid.Add(employeeName);
                                break;
                            case Shift.Evening:
                                evening.Add(employeeName);
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
                                mid.Add(employeeName);
                                evening.Add(employeeName);
                                break;

                            case Shift.Evening:
                                morning.Add(employeeName);
                                mid.Add(employeeName);
                                break;
                        }
                    }
                }
               
            }
            while (morning.Count < neededShiftAmount)
            {
                morning.Add("-");
            }
            while (mid.Count < neededShiftAmount)
            {
                mid.Add("-");
            }
            while (evening.Count < neededShiftAmount)
            {
                evening.Add("-");
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


    }
}
