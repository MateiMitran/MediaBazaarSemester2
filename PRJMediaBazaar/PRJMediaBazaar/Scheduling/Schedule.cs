using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class Schedule
    {
      
        List<Day> _days;

        public Schedule(List<Day> days, int id, DateTime startDate, DateTime endDate)
        {
            _days = days;
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            IsOutdated = false;
        }

        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsOutdated { get; private set; }

        public List<Day> Days { get { return _days; } }

    }
}
