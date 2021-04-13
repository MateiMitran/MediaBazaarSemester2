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

        public EmployeeWorkday[] GetEmployeesShifts(int dayId, string jobPosition)
        {

            return scheduleDAL.SelectEmployeesShifts(dayId, jobPosition).ToArray();

        }

        public void RemoveShift(string shift, Day day, Employee employee)
        {
            EmployeeWorkday result = scheduleDAL.SelectEmployeeWorkday(day.Id, employee.Id);
            if (result != null)
            {
                int emptyShiftIndex = Helper.GetEmptyShiftIndex(result.FirstShift.ToString(), result.SecondShift.ToString());
                if (emptyShiftIndex != -1 && !result.Absence) //if there is an empty shift, remove the row
                {
                    scheduleDAL.DeleteShift(day.Id, employee.Id);
                }
                else if (emptyShiftIndex == -1 && !result.Absence)//if there is a double shift,insert None on the chosen one
                {
                    if (result.FirstShift.ToString() == shift.ToString())
                    {
                        scheduleDAL.UpdateShift(2, "None", day.Id, employee.Id);
                    }
                    else if (result.SecondShift.ToString() == shift.ToString())
                    {
                        scheduleDAL.UpdateShift(3, "None", day.Id, employee.Id);
                    }

                }
                double workedHours = GetWorkedHours(day.WeekId, employee.Id);
                scheduleDAL.UpdateHours(workedHours - 4.5, day.ScheduleId, employee.Id);
                DecreaseAssignedPosition(day, employee.JobPosition, shift);

            }
        }

        public void AssignShift(string shift, Employee employee, Day day, int emptyShiftIndex, double hours)
        {
            EmployeeWorkday wd = scheduleDAL.SelectEmployeeWorkday(day.Id, employee.Id);
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
            EmployeeWorkday wd = scheduleDAL.SelectEmployeeWorkday(day.Id, employee.Id);
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
            }
            else
            {
                scheduleDAL.InsertAbsence(day.Id, employee.Id);
            }
        }


        public double GetWorkedHours(int weekId, int employeeId)
        {
            return scheduleDAL.SelectWorkedHours(weekId, employeeId);
        }



        public void LoadDaysOff() // add the DayOff requests to the list 
        {
            dayoff_req = scheduleDAL.SelectDayOffRequests();
        }



        public string DayStatus(Day d)
        {

            foreach (Duty np in d.AllPositions)
            {

                if ((np.MorningAssigned < np.MorningNeeded || np.MiddayAssigned < np.MiddayNeeded || np.EveningAssigned < np.EveningNeeded) &&
                    (np.MorningAssigned != 0 || np.MiddayAssigned != 0 || np.EveningAssigned != 0))
                {
                    return "started";
                }
                else if (np.MorningAssigned == 0 && np.MiddayAssigned == 0 && np.EveningAssigned == 0)
                {
                    return "empty";
                }
            }
            return "complete";
        }
        public string ScheduleStatus(Schedule s)
        {
            return ScheduleStatus(s.Days);

        }

        private bool DaysAreComplete(Day[] days)
        {

            foreach (Day d in days)
            {
                string status = DayStatus(d);
                if (status != "complete")
                {
                    return false;
                }
            }
            return true;
        }

        private string ScheduleStatus(Day[] days)
        {
            int complete = 0;
            int started = 0;
            int empty = 0;
            foreach(Day d in days)
            {
                if(DayStatus(d) == "complete")
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

           if(empty == 14)
            {
                return "empty";
            }
           if(complete == 14)
            {
                return "complete";
            }
            return "started";

        }

        public bool ConfirmDayOffRequest(int dayId, int empId)
        {
            return scheduleDAL.ConfirmDayOffRequest(dayId, empId);
        }

        public void GenerateSchedule(Day day)
        {

            Duty[] positions = new Duty[] { day.CashiersNeeded, day.SalesAssistantsNeeded,
                day.SecurityNeeded, day.StockersNeeded, day.WarehouseManagersNeeded };

            foreach (Duty p in positions)
            {

                for (int i = 0; i < p.MaxValue(); i++)
                {
                    if (p.MorningNeeded > p.MorningAssigned)
                    {
                        EmployeePlanner available = GetFirstAvailableEmployeePlanner(day, Shift.Morning, p.Position);
                        double workedHours = GetWorkedHours(day.WeekId, available.Employee.Id);

                        AssignShift(Shift.Morning.ToString(), available.Employee, day, available.EmptyShiftIndex, workedHours + 4.5);
                    }

                    if (p.MiddayNeeded > p.MiddayAssigned)
                    {
                        EmployeePlanner available = GetFirstAvailableEmployeePlanner(day, Shift.Midday, p.Position);
                        double workedHours = GetWorkedHours(day.WeekId, available.Employee.Id);

                        AssignShift(Shift.Midday.ToString(), available.Employee, day, available.EmptyShiftIndex, workedHours + 4.5);
                    }

                    if (p.EveningNeeded > p.EveningAssigned)
                    {
                        EmployeePlanner available = GetFirstAvailableEmployeePlanner(day, Shift.Evening, p.Position);
                        double workedHours = GetWorkedHours(day.WeekId, available.Employee.Id);

                        AssignShift(Shift.Evening.ToString(), available.Employee, day, available.EmptyShiftIndex, workedHours + 4.5);
                    }
                }
            }
        }

        public void RemoveSchedule(Day d)
        {
            scheduleDAL.RemoveSchedule(d.Id, d.WeekId);
            d.EmptyDuties();
        }

        private EmployeePlanner GetFirstAvailableEmployeePlanner(Day day, Shift shift, string position)
        {
            List<int> ids = scheduleDAL.SelectAvailableEmployeesIds(position,day.Id);
            if(ids.Count > 0)
            {
                Employee employee = _empControl.GetEmployee(ids[0]);
                double hoursInfo = scheduleDAL.SelectWorkedHours(day.WeekId, employee.Id);
                return new EmployeePlanner(employee, "None", -1, hoursInfo);
            }


            List<EmployeeWorkday> workdays = scheduleDAL.SelectEmployeesShifts(day.Id, position);
            List<EmployeePlanner> available = new List<EmployeePlanner>();
            foreach (EmployeeWorkday wd in workdays) //employees in the workdays_table
            {
               
                    int index = Helper.GetEmptyShiftIndex(wd.FirstShift.ToString(), wd.SecondShift.ToString());
                    string busyShift = wd.GetBusyShift();

                    if (index != -1 && Helper.DoubleShiftIsValid(busyShift, shift.ToString())) //employee has only one shift, and the second one is valid
                    {
                        Employee employee = wd.Employee;
                        double hoursInfo = scheduleDAL.SelectWorkedHours(day.WeekId, employee.Id);

                        EmployeePlanner ea = new EmployeePlanner(employee, busyShift, index, hoursInfo);
                        available.Add(ea);
                    }
            }
            available.Sort();
            return available[0];
        }
    }
}
