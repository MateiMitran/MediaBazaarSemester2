using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class RegularEmployee : User
    {
        private int promotionPoints;
        private int latePoints;
        public RegularEmployee(int id, string firstName, string lastName, DateTime birthDate,
            string gender, double salary, string email, string password, string jobPosition,
            int phoneNumber, string address, string education)

            : base(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition, phoneNumber, address, education)
        {

        }
        public int PromotionPoints { get; set; }
        public int LatePoints { get; set; }
    }
}
