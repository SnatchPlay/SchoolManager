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
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public Teacher(int id, int personId, int classId, int specializationId, DateTime rowInsertTime, DateTime rowUpdateTime)
        {
            this.Id = id;
            this.PersonId = personId;
            this.ClassId = classId;
            this.SpecializationId = specializationId;
            this.RowInsertTime = rowInsertTime;
            this.RowUpdateTime = rowUpdateTime;
        }
        public Teacher() { }
    }
}
