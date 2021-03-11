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

        public static bool ScheduleExists(DateTime startDate, DateTime endDate)
        {
            if (/*SQL query retrieves an existing schedule for the startDate and endDates in table schedules*/)
            {
                return true;
            }
            return false;
        }

        public static bool CreateEmptySchedule(DateTime startDate , DateTime endDate)
        {

            if (ScheduleExists(startDate, endDate))
            {
                return false;
            }
            //SQL insert schedule startDate and endDate in table schedules.
            //SQL insert 14 values in the days table with predefined parameters.
            return true;
        }

        public static bool ScheduleIsEmpty(DateTime startDate, DateTime endDate)
        {
            if (/*SQL query retrieves an existing schedule for the startDate and endDates,
                 * where schedule is NOT in employees_workdays table*/)
            {
                return true;
            }
            return false;
        }

        public static Schedule GetSchedule(DateTime startDate, DateTime endDate)
        {
            if (ScheduleExists(startDate, endDate) && ScheduleIsEmpty(startDate, endDate))
            { 
              //SQL query the days table for that schedule and add them to a List<Days>
              //create the Schedule object and return it
            }

            else if(ScheduleExists(startDate,endDate) && !ScheduleIsEmpty(startDate,endDate))
            {
                //SQL query the days table for that schedule and add them to a List<Days>
                //create the Schedule object
                //SQL query all days for this shift id in days table
                //result = SQL query employee_workdays for dayID in (select dayid where scheduleID = "")
                //make the List<EmployeeShifts>
                //make the List<Days>
                //foreach Day
                //(
                //   //foreach EmployeeShift
                //   //if(es.dayID == Day.dayId)
                //{
                //    // day.AddEmployeeShift(es);
                //}

                //)
            }
            return null;
        }

    }
}
