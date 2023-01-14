using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Column ("person_id")]
        public int PersonId { get; set; }
        [Column ("class_id")]
        public int ClassId { get; set; }
        public Student(int studentId, int personId, int classId)
        {
            Id = studentId;
            PersonId = personId;
            ClassId = classId;
        }
        public Student() { }
    }
}
