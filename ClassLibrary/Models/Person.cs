using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public int UserId { get; set; }
        public Person(int personId, string name, string surname, string lastname, DateTime birthDate, int userId)
        {
            this.PersonId = personId;
            this.Name = name;
            this.Surname = surname;
            this.Lastname = lastname;
            this.BirthDate = birthDate;
            this.UserId = userId;
        }
        public Person() { }
    }
}
