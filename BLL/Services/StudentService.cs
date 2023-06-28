using BLL.Interfaces;
using ClassLibrary.DAL;
using ClassLibrary.Factory;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class StudentService : IStudentService
    {
        IRepository<Student> studentRep;
        public StudentService() 
        {
            studentRep=FactoryProvider.GetFactory().GetStudentRepository();
        }
        public List<Student> GetAllStudents()
        {
            return studentRep.GetAll();
        }

        public List<Student> GetAllStudentsByClassId(int classId)
        {
            return studentRep.GetAll().FindAll(x=>x.ClassId == classId);
        }

        public List<Student> GetAllStudentsByParents(Parent parent)
        {
            return studentRep.GetAll().FindAll(x=>x.Parents.Contains(parent));
        }

        public Student GetStudentById(int id)
        {
            return studentRep.Get(x=>x.Id == id);
        }

        public Student GetStudentByPersonId(int personId)
        {
            return studentRep.Get(x=> x.PersonId == personId);
        }
    }
}
