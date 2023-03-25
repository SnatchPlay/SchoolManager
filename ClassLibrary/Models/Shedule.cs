using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    [Keyless]
    public class Shedule
    {
        [Column ("day_num")]
        public int DayNum { get; set; }
        [Column ("lesson_num")]
        public int LessonNum { get; set; }
        [Column ("class_id")]
        public int ClassId { get; set; }
        [Column ("teacher_id")]
        public int TeacherId { get; set; }
        [Column ("lesson_id")]
        public int LessonId { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public Shedule(int dayNum, int lessonNum, int classId, int teacherId, int lessonId, DateTime rowInsertTime, DateTime rowUpdateTime)
        {
            this.DayNum = dayNum;
            this.LessonNum = lessonNum;
            this.ClassId = classId;
            this.TeacherId = teacherId;
            this.LessonId = lessonId;
            this.RowInsertTime = rowInsertTime;
            this.RowUpdateTime = rowUpdateTime;
        }
        public Shedule() { }
    }
}
