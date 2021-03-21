using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
     class NamesRow
    {
        public RegularEmployee Morning { get; set; }
        public RegularEmployee Midday{ get; set; }
        public RegularEmployee Evening{ get; set; }

        public NamesRow(RegularEmployee morningEmployee, RegularEmployee middayEmployee,RegularEmployee eveningEmployee)
        {
            Morning = morningEmployee;
            Midday = middayEmployee;
            Evening = eveningEmployee;
        }

      
    }
}
