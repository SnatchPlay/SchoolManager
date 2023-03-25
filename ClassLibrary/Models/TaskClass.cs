using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class TaskClass
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime ClosedTime {get; set; }
        public bool Status { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public TaskClass(int studentId, int lessonId, string description, DateTime deadLine, DateTime closeTime, bool status, int id, DateTime rowInsertTime, DateTime rowUpdateTime)
        {
            this.StudentId = studentId;
            this.LessonId = lessonId;
            this.Description = description;
            this.DeadLine = deadLine;
            this.ClosedTime = closeTime;
            this.Status = status;
            this.Id = id;
            this.RowInsertTime = rowInsertTime;
            this.RowUpdateTime = rowUpdateTime;
        }
        public TaskClass() { }
    }
}
