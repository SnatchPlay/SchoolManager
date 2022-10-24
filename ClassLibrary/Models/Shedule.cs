using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Shedule
    {
        public int DayNum { get; set; }
        public int LessonNum { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public int LessonId { get; set; }
        public Shedule(int dayNum, int lessonNum, int classId, int teacherId, int lessonId)
        {
            DayNum = dayNum;
            LessonNum = lessonNum;
            ClassId = classId;
            TeacherId = teacherId;
            LessonId = lessonId;
        }
        public Shedule() { }
    }
}
