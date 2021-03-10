using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class Schedule
    {
        private static int _idCounter = 1;
        
        List<Day> days;
        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsOutdated { get; private set; }

        public Schedule(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Id = _idCounter;
            _idCounter++;

            days = new List<Day>();
            //create the Day objects between StartDate and EndDate
            for (DateTime date = StartDate; date.Date <= EndDate.Date; date = date.AddDays(1))
            {
             
                days.Add(new Day(date));
            }
        }

    }
}
