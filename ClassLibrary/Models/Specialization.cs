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
        public Specialization(int specializationID, string specializationName)
        {
            Id = specializationID;
            Name = specializationName;
        }
        public Specialization() { }
    }
}
