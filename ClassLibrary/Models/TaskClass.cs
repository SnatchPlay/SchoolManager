using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class TaskClass
    {
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime CloseTime {get; set; }
        public bool Status { get; set; }
        public TaskClass(int studentId, int lessonId, string description, DateTime deadLine, DateTime closeTime, bool status)
        {
            StudentId = studentId;
            LessonId = lessonId;
            Description = description;
            DeadLine = deadLine;
            CloseTime = closeTime;
            Status = status;
        }
        public TaskClass() { }
    }
}
