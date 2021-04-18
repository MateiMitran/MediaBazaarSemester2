using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class Schedule
    {
      
        
        public Schedule(int scheduleId, DateTime startDate, DateTime endDate, bool isOutdated)
        {
            Id = scheduleId;
            StartDate = startDate;
            EndDate = endDate;
     
        }

        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsOutdated { get; private set; }


        public override string ToString()
        {
            return $"{StartDate.ToString("dd-MM-yyyy")} - {EndDate.ToString("dd-MM-yyyy")}";
        }

    }
}
