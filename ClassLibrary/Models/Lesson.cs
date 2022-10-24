using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonTitle { get; set; }
        public Lesson(int lessonId, string lessonTitle)
        {
            LessonId = lessonId;
            LessonTitle = lessonTitle;
        }
        public Lesson() { }
    }
}
