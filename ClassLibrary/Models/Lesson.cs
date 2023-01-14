using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Lesson(int lessonId, string lessonTitle)
        {
            Id = lessonId;
            Title = lessonTitle;
        }
        public Lesson() { }
    }
}
