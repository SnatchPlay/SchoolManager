using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ClassId { get; set; }
        public StudentDTO(int id, int personId, int classId)
        {
            Id = id;
            PersonId = personId;
            ClassId = classId;
        }
    }
}
