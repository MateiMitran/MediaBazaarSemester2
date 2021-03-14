using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar
{

    abstract class User
    {
        protected User(int id, string firstName, string lastName, DateTime birthDate, 
            Gender gender, double salary, string email, string password, 
            JobPosition jobPosition, int phoneNumber, string address, string education)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            Salary = salary;
            Email = email;
            Password = password;
            JobPosition = jobPosition;
            PhoneNumber = phoneNumber;
            Address = address;
            Education = education;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public  Gender Gender { get; private set; }
        public double Salary { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public JobPosition JobPosition { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string Education { get; private set; }
    }
}
