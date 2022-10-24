using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Specialization
    {
        public int SpecializationID { get; set; }
        public string SpecializationName { get; set; }
        public Specialization(int specializationID, string specializationName)
        {
            SpecializationID = specializationID;
            SpecializationName = specializationName;
        }
        public Specialization() { }
    }
}
