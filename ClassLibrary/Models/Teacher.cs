using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ClassId { get; set; }
        public int SpecializationId { get; set; }
        public Teacher(int id, int personId, int classId, int specializationId)
        {
            Id = id;
            this.PersonId = personId;
            this.ClassId = classId;
            this.SpecializationId = specializationId;
        }
        public Teacher() { }
    }
}
