using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Journal
    {
        public int StudentId { get; set; }
        public int DayNum { get; set; }
        public int LessonId { get; set; }
        public Journal(int studentId, int dayNum, int lessonId)
        {
            StudentId = studentId;
            DayNum = dayNum;
            LessonId = lessonId;
        }
        public Journal() { }
    }
}
