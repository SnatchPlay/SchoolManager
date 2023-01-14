using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Journal
    {
        public int Id { get; set; }
        [Column("student_id")]
        public int StudentId { get; set; }
        [Column("day_num")]
        public int DayNum { get; set; }
        [Column ("lesson_id")]
        public int LessonId { get; set; }
        public Journal(int studentId, int dayNum, int lessonId, int id)
        {
            StudentId = studentId;
            DayNum = dayNum;
            LessonId = lessonId;
            Id = id;
        }
        public Journal() { }
    }
}
