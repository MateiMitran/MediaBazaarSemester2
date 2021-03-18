using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
     class NamesRow
    {
        public string Morning { get; set; }
        public string Midday{ get; set; }
        public string Evening{ get; set; }

        public NamesRow(string morningEmployee, string middayEmployee, string eveningEmployee)
        {
            Morning = morningEmployee;
            Midday = middayEmployee;
            Evening = eveningEmployee;
        }

      
    }
}
