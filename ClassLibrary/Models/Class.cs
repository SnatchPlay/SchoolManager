using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Class(int classId, string name)
        {
            Id = classId;
            Name = name;
        }
        public Class() { }
    }
}
