using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class JournalDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DayNum { get; set; }
        public int LessonId { get; set; }
        public int Mark { get; set; }
        public JournalDTO(int id, int studentId, int dayNum, int lessonId, int mark)
        {
            Id = id;
            StudentId = studentId;
            DayNum = dayNum;
            LessonId = lessonId;
            Mark = mark;
        }
    }
}
