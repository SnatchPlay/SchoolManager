using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public int UserId { get; set; }
        public PersonDTO(int id, string name, string surname, string lastname, DateTime birthDate, int userId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Lastname = lastname;
            BirthDate = birthDate;
            UserId = userId;
        }
    }
}
