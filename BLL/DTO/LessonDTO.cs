using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public LessonDTO(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
