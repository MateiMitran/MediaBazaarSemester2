using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{
    class HrManager : User
    {
        public HrManager(int id, string firstName, string lastName, DateTime birthDate,
           string gender, double salary, string email, string password, string jobPosition,
            int phoneNumber, string address, string education)
            
            : base(id, firstName, lastName, birthDate, gender, salary, email, password, jobPosition, phoneNumber, address, education)
        {
        }
    }
}
