using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Parent
    {
        [Key]
        public int Id { get; set; }
        [Column("person_id")]
        public int PersonId { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public ICollection<Student> Students { get; set; }

        public Parent(int Id, int personId,  DateTime rowInsertTime, DateTime rowUpdateTime)
        {
            this.Id = Id;
            this.PersonId = personId;
            this.RowInsertTime = rowInsertTime;
            this.RowUpdateTime = rowUpdateTime;
        }
        public Parent() { }
    }
}
