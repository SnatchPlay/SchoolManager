using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int PersonId { get; set; }
        public int ClassId { get; set; }
        public Student(int studentId, int personId, int classId)
        {
            StudentId = studentId;
            PersonId = personId;
            ClassId = classId;
        }
        public Student() { }
    }
}
