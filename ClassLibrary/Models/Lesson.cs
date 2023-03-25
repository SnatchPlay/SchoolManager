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
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public Lesson(int lessonId, string lessonTitle, DateTime rowInsertTime, DateTime rowUpdateTime)
        {
            this.Id = lessonId;
            this.Title = lessonTitle;
            this.RowInsertTime = rowInsertTime;
            this.RowUpdateTime = rowUpdateTime;
        }
        public Lesson() { }
    }
}
