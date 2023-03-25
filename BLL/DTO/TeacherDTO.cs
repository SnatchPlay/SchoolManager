using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ClassId { get; set; }
        public int SpecializationId { get; set; }
        public TeacherDTO(int id, int personId, int classId, int specializationId)
        {
            Id = id;
            PersonId = personId;
            ClassId = classId;
            SpecializationId = specializationId;
        }
    }
}
