using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class DatabaseHelper
    {


        public static bool AssignShift(Shift shift, int employeeID , int DayId)
        {
           
            if (/*query retrieves a row where the employee has ONLY one shift assigned for that dayId */)
            {
                //SQL quey to add the second shift to the employees_workdays table
                return true;
            }

            else if (/*query doesn't retrieve a row for that dayId*/)
            {

                //SQL quey to add a new row with the parameters to the employees_workdays table
                return true;

            }
            return false;
        }

        public static void DeleteShift(Shift shift, int employeeID, int DayId)
        {
         
            if (/*if the employee doesn't have a double shift*/) 
            {
                //SQL query to remove the shift from employees_workdays table
            
            }
            else //check which shift is selected and replace it with Shift.None
            {
               //SQL query to replace the shift with "None"
            }

        }

        public static void AssignAbsence(AbsenceReason absenceReason, int employeeID , int dayId)
        {
         
            if (/*if query retrieves a row for this dayID*/)
            {
                //SQL - UPDATE the row in employees_workdays with the new values. (Shift- "None" + Absence & AbsenceReason)
            }
            else
            {
               
                //SQL - INSERT a new row in employees_workdays with Absence and AbsenceReason
            }

        }

        public static void ChangeNeededJobPosition(JobPosition jobPosition, int amount , int dayId)
        {
            //SQL query to UPDATE the value in the days table
        }

       
        public static bool CreateEmptySchedule(DateTime startDate, DateTime endDate)
        {

            if (GetScheduleId(startDate,endDate) > 0)
            {
                return false;
            }
            //SQL insert schedule startDate and endDate in table schedules.
            //SQL insert 14 values in the days table with predefined parameters.
            return true;
        }

        public static Schedule GetSchedule(DateTime startDate, DateTime endDate)
        {
            int scheduleId = GetScheduleId(startDate, endDate);
            if (scheduleId > 0 && ScheduleIsEmpty(scheduleId))
            { 
              //SQL query the days table for that scheduleId and add them to a List<Days>
              //create the Schedule object and return it
            }

            else if(scheduleId > 0  && !ScheduleIsEmpty(scheduleId))
            {

                //create the Schedule object
                //make the List<Days> ---> SQL query the days table for that scheduleId and add them to a List<Days>
                //make the List<EmployeeShifts>  ---> SQL query employee_workdays with dayID in (get the dayId's with this scheduleId)
                //foreach Day d
                //(
                //   //foreach EmployeeShift es
                //   //if(es.dayID == d.dayId)
                //{
                //    // day.AddEmployeeShift(es);
                //}

                //)
            }
            return null;
        }

       private static int  GetScheduleId(DateTime startDate, DateTime endDate)
        {
            //SELECT id FROM schedule WHERE start_date = startDate AND end_Date = endDate
            //if(/*retrieves an id > 0*/)
            //{
            //    return id
            //}
            return 0;
        }


        private static bool ScheduleIsEmpty(int scheduleId)
        {

            if (/*SQL query retrieves an existing schedule ,
                 * where scheduleId is NOT in employees_workdays table*/)
            {
                return true;
            }
            return false;
        }

    }
}
