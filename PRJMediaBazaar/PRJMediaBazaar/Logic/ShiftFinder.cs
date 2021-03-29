using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    public static class ShiftFinder
    {
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
    }
}
