using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    internal interface IStudentService
    {
        public Student GetStudentById(int id);
        public Student GetStudentByPersonId(int personId);
        public List<Student> GetAllStudents();
        public List<Student> GetAllStudentsByClassId(int classId);
        public List<Student> GetAllStudentsByParents(Parent parent);

    }
}
