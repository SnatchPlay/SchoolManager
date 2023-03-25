using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        [Column ("user_id")]
        public int UserId { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public Person(int personId, string name, string surname, string lastname, DateTime birthDate, int userId, DateTime rowInsertTime, DateTime rowUpdateTime)
        {
            this.Id = personId;
            this.Name = name;
            this.Surname = surname;
            this.Lastname = lastname;
            this.BirthDate = birthDate;
            this.UserId = userId;
            this.RowInsertTime = rowInsertTime;
            this.RowUpdateTime = rowUpdateTime;
        }
        public Person() { }
    }
}
