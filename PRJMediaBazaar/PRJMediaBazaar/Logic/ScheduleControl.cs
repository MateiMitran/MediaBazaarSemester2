using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJMediaBazaar.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace PRJMediaBazaar.Logic
{
    class ScheduleControl
    {
        private List<DayOff> dayoff_req;
        private List<SickReport> sick_req;
        private List<Schedule> _schedules;
        private EmployeeControl _empControl;
        private ScheduleDAL scheduleDAL;

        public ScheduleControl(EmployeeControl employeeControl)
        {
            _schedules = new List<Schedule>();
            _empControl = employeeControl;
            scheduleDAL = new ScheduleDAL();
            LoadSchedules();
            LoadDaysOff();
        }

        public List<DayOff> DaysOffRequests { get { return dayoff_req; } }
        public List<SickReport> SickReports { get { return sick_req; } }
        public Schedule[] Schedules { get { return _schedules.ToArray(); } }

        private void LoadSchedules()
        {
            _schedules = scheduleDAL.SelectSchedules();
        }


        public Day[] GetDays(int scheduleId)
        {
            foreach (Schedule s in _schedules)
            {
                if (s.Id == scheduleId)
                {
                    return s.Days;
                }
            }
            return null;
        }



        private void DecreaseAssignedPosition(Day day, string jobPosition, string shift)
        {
            Duty duty = day.GetDuty(jobPosition);
            int morning = duty.MorningAssigned;
            int midday = duty.MiddayAssigned;
            int evening = duty.EveningAssigned;
            switch (shift)
            {
                case "Morning":
                    morning -= 1;
                    break;
                case "Midday":
                    midday -= 1;
                    break;
                case "Evening":
                    evening -= 1;
                    break;
            }
            day.ChangeAssignedDuties(jobPosition, morning, midday, evening);
        }

        private void IncreaseAssignedPosition(Day day, string jobPosition, string shift)
        {
            Duty duty = day.GetDuty(jobPosition);
            int morning = duty.MorningAssigned;
            int midday = duty.MiddayAssigned;
            int evening = duty.EveningAssigned;
            switch (shift)
            {
                case "Morning":
                    morning += 1;
                    break;
                case "Midday":
                    midday += 1;
                    break;
                case "Evening":
                    evening += 1;
                    break;
            }
            day.ChangeAssignedDuties(jobPosition, morning, midday, evening);
        }

        public EmployeeWorkday[] GetEmployeesShifts(int weekId, int dayId, string jobPosition)
        {

            return scheduleDAL.SelectEmployeesShifts(weekId, dayId, jobPosition).ToArray();

        }

        public void RemoveShift(string shift, Day day, Employee employee)
        {
            EmployeeWorkday result = scheduleDAL.SelectEmployeeShift(day.WeekId,day.Id, employee.Id);
            if (result != null)
            {
                int emptyShiftIndex = Helper.GetEmptyShiftIndex(result.FirstShift.ToString(), result.SecondShift.ToString());
                if (emptyShiftIndex != -1 && !result.Absence) //if there is an empty shift, remove the row
                {
                    scheduleDAL.DeleteShift(day.Id, employee.Id);
                   
                }
                else if (emptyShiftIndex == -1 && !result.Absence)//if there is a double shift,insert None on the chosen one
                {
                    if (result.FirstShift.ToString() == shift)
                    {
                        scheduleDAL.UpdateShift(2, "None", day.Id, employee.Id);
                      
                    }
                    else if (result.SecondShift.ToString() == shift)
                    {

                        scheduleDAL.UpdateShift(3, "None", day.Id, employee.Id);
                        
                    }

                }


                DecreaseAssignedPosition(day, employee.JobPosition, shift);
                scheduleDAL.UpdateHours(result.Hours - 4.5, day.ScheduleId, employee.Id);

            }
        }
        //public void RemoveShift(string shift, Day day,EmployeeWorkday result)
        //{
           
        //    if (result != null)
        //    {
        //        int emptyShiftIndex = Helper.GetEmptyShiftIndex(result.FirstShift.ToString(), result.SecondShift.ToString());
        //        if (emptyShiftIndex != -1 && !result.Absence) //if there is an empty shift, remove the row
        //        {
        //            scheduleDAL.DeleteShift(result.DayId, result.Employee.Id);
                   
        //        }
        //        else if (emptyShiftIndex == -1 && !result.Absence)//if there is a double shift,insert None on the chosen one
        //        {
        //            if (result.FirstShift.ToString() == shift)
        //            {
        //                scheduleDAL.UpdateShift(2, "None", result.DayId, result.Employee.Id);
                       
        //            }
        //            else if (result.SecondShift.ToString() == shift)
        //            {
        //                scheduleDAL.UpdateShift(3, "None", result.DayId, result.Employee.Id);
                       
        //            }

        //        }

        //        DecreaseAssignedPosition(day, result.Employee.JobPosition, shift);
        //        scheduleDAL.UpdateHours(result.Hours - 4.5, day.ScheduleId, result.Employee.Id);
        //    }
        //}

        public void AssignShift(string shift, Employee employee, Day day, int emptyShiftIndex, double hours)
        {
            EmployeeWorkday wd = scheduleDAL.SelectEmployeeShift(day.WeekId,day.Id, employee.Id);
            if (wd != null)
            {
                scheduleDAL.UpdateShift(emptyShiftIndex, shift, day.Id, employee.Id);
            }
            else
            {
                scheduleDAL.InsertShift(day.Id, employee.Id, shift);
            }

            if (hours == 4.5)
            {
                scheduleDAL.InsertHours(hours, day.WeekId, employee.Id);
            }
            else
            {
                scheduleDAL.UpdateHours(hours, day.WeekId, employee.Id);
            }

            IncreaseAssignedPosition(day, employee.JobPosition, shift);

        }


        public void AssignAbsence(AbsenceReason absenceReason, Employee employee, Day day)
        {
            EmployeeWorkday wd = scheduleDAL.SelectEmployeeShift(day.WeekId, day.Id, employee.Id);
            if (wd != null)
            {
                scheduleDAL.UpdateAbsence(day.Id, employee.Id);
                if (wd.FirstShift != Shift.None)
                {
                    DecreaseAssignedPosition(day, employee.JobPosition, wd.FirstShift.ToString());
                }
                if (wd.SecondShift != Shift.None)
                {
                    DecreaseAssignedPosition(day, employee.JobPosition, wd.SecondShift.ToString());
                }
                scheduleDAL.UpdateHours(wd.Hours, day.WeekId, employee.Id);
            }
            else
            {
                scheduleDAL.InsertAbsence(day.Id, employee.Id);
            }
        }



        public void LoadDaysOff() // add the DayOff requests to the list 
        {
            dayoff_req = scheduleDAL.SelectDayOffRequests();
        }

        public void LoadSickReports()  
        {
            sick_req = scheduleDAL.SelectSickReports();
        }



        public string DayStatus(Day d)
        {
            int count = d.AllPositions.Count();
            int complete = 0;
            int empty = 0;

            foreach (Duty np in d.AllPositions)
            {
               
                if (np.MorningAssigned == np.MorningNeeded && np.MiddayAssigned == np.MiddayNeeded  && np.EveningAssigned == np.EveningNeeded)
                {
                    complete++;
                    if(complete == count)
                    {
                        return "complete";
                    }
                }
                else if (np.MorningAssigned == 0 && np.MiddayAssigned == 0 && np.EveningAssigned == 0)
                {
                    empty++;
                    if(empty == count)
                    {
                        return "empty";
                    }
                   
                }
            }
            return "started";
        }
        public string ScheduleStatus(Schedule s)
        {
            return ScheduleStatus(s.Days);

        }


        private string ScheduleStatus(Day[] days)
        {
            int complete = 0;
            int started = 0;
            int empty = 0;
            foreach (Day d in days)
            {
                if (DayStatus(d) == "complete")
                {
                    complete++;
                }
                else if (DayStatus(d) == "started")
                {
                    started++;
                }
                else
                {
                    empty++;
                }
            }

            if (empty == 14)
            {
                return "empty";
            }
            if (complete == 14)
            {
                return "complete";
            }
            return "started";

        }

        public bool ConfirmDayOffRequest(int dayId, int empId)
        {
            return scheduleDAL.ConfirmDayOffRequest(dayId, empId);
        }

        public void AddReason(int id, String note)
        {
           scheduleDAL.AddReasonForDenial(id, note);
        }

        public bool MarkAsSeen(int dayId, int empId)
        {
            return scheduleDAL.ConfirmSickReport(dayId, empId);
        }

        public void GenerateSchedule(Day day)
        {

            Duty[] positions = new Duty[] { day.CashiersNeeded, day.SalesAssistantsNeeded,
                day.SecurityNeeded, day.StockersNeeded, day.WarehouseManagersNeeded };

            foreach (Duty p in positions)
            {

                while (p.MaxValue() > p.MaxAssigned())
                {
                    if (p.MorningNeeded > p.MorningAssigned)
                    {
                        EmployeePlanner available = GetFirstAvailableEmployeePlanner(day, Shift.Morning, p.Position);
                        if(available != null)
                        {
                            double workedHours = available.HoursWorked;
                            AssignShift(Shift.Morning.ToString(), available.Employee, day, available.EmptyShiftIndex, workedHours + 4.5);
                        }
                      
                    }

                    if (p.MiddayNeeded > p.MiddayAssigned)
                    {
                        EmployeePlanner available = GetFirstAvailableEmployeePlanner(day, Shift.Midday, p.Position);
                        if(available != null)
                        {
                            double workedHours = available.HoursWorked;
                            AssignShift(Shift.Midday.ToString(), available.Employee, day, available.EmptyShiftIndex, workedHours + 4.5);
                        }
                        
                    }

                    if (p.EveningNeeded > p.EveningAssigned)
                    {
                        EmployeePlanner available = GetFirstAvailableEmployeePlanner(day, Shift.Evening, p.Position);

                        if(available != null)
                        {
                            double workedHours = available.HoursWorked;
                            AssignShift(Shift.Evening.ToString(), available.Employee, day, available.EmptyShiftIndex, workedHours + 4.5);
                        }
                       
                    }
                }
            }
        }

        public void RemoveSchedule(Day day)
        {
            
            //day.EmptyDuties();
            foreach (string position in Day.positions)
            {
                foreach (EmployeeWorkday wd in scheduleDAL.SelectEmployeesShifts(day.WeekId,day.Id, position))
                {
                    
                    RemoveShift(wd.GetShift(),day,wd.Employee);
                }
            }
        }

        private EmployeePlanner GetFirstAvailableEmployeePlanner(Day day, Shift shift, string position)
        {
            
            EmployeePlanner ep = scheduleDAL.SelectFirstAvailableEmployeePlanner(position, day.WeekId, day.Id);
            if (ep != null)
            {
                return ep;
            }
            return scheduleDAL.SelectAvailableEmployeePlanner(day.Id, position, day.WeekId, shift);
        }
    }
}
