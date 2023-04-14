using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class ParentStudent
    {
        [Column("parent_id")]
        [ForeignKey("Parent")]
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        [Column("student_id")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }

}
