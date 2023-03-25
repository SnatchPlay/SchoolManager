using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TaskClassDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime ClosedTime { get; set; }
        public bool Status { get; set; }
        public TaskClassDTO(int id, int studentId, int lessonId, string description, DateTime deadLine, DateTime closedTime, bool status)
        {
            Id = id;
            StudentId = studentId;
            LessonId = lessonId;
            Description = description;
            DeadLine = deadLine;
            ClosedTime = closedTime;
            Status = status;
        }
    }
}
