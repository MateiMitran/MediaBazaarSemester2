using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    class NeededPositions
    {

        public int Morning { get; private set; }
        public int Midday { get; private set; }
        public int Evening { get; private set; }

          public NeededPositions(int morning, int midday, int evening)
        {
            Morning = morning;
            Midday = midday;
            Evening = evening;
        }

        public int MaxValue()
        {
            if(Morning >= Evening && Morning >= Midday)
            {
                return Morning;
            }

            else if (Midday >= Morning && Midday >= Evening)
            {
                return Midday;
            }

            return Evening;
        }
    }
}
