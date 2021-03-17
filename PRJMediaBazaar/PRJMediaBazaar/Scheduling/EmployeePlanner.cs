using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class EmployeePlanner
    {
        public EmployeePlanner(int employeeId, string employeeName, string occupation, int emptyShiftIndex)
        {
            EmployeeName = employeeName;
            EmployeeId = employeeId;
            Occupation = occupation;
            EmptyShiftIndex = emptyShiftIndex;
        }

       public string EmployeeName {get;set;}
      public string Occupation { get; set; }
      public int EmptyShiftIndex { get; set; }

        public int EmployeeId { get; set; }

        public override string ToString()
        {
            return ($"{EmployeeId} {EmployeeName} , Occupation:{Occupation}, esIndex: {EmptyShiftIndex}");
        }
    }
}
