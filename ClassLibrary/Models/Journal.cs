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
        public int Mark { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public Journal(int studentId, int dayNum, int lessonId, int id, int mark, DateTime rowInsertTime, DateTime rowUpdateTime)
        {
            this.StudentId = studentId;
            this.DayNum = dayNum;
            this.LessonId = lessonId;
            this.Id = id;
            this.Mark = mark;
            this.RowInsertTime = rowInsertTime;
            this.RowUpdateTime = rowUpdateTime;
        }
        public Journal() { }
    }
}
