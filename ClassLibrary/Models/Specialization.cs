using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public Specialization(int specializationID, string specializationName, DateTime rowInsertTime, DateTime rowUpdateTime)
        {
            this.Id = specializationID;
            this.Name = specializationName;
            this.RowInsertTime = rowInsertTime;
            this.RowUpdateTime = rowUpdateTime;
        }
        public Specialization() { }
    }
}
