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
    internal class TeacherService : ITeacherService
    {
        IRepository<Teacher> teacherRep;
        TeacherService()
        {
            teacherRep=FactoryProvider.GetFactory().GetTeacherRepository();
        }
        public void ChangeTeacherClass(Teacher teacher, int newClassId)
        {
            teacher.ClassId = newClassId;
            teacherRep.Update(teacher);
        }

        public void ChangeTeacherPersonId(Teacher teacher, int newPersonId)
        {
            teacher.PersonId = newPersonId;
            teacherRep.Update(teacher);
        }

        public void ChangeTeacherSpecialization(Teacher teacher, int newSpecializationId)
        {
            teacher.SpecializationId = newSpecializationId;
            teacherRep.Update(teacher);
        }

        public List<Teacher> GetAllTeachers()
        {
            return teacherRep.GetAll();
        }

        public Teacher GetTeacherByClassId(int classId)
        {
            return teacherRep.Get(x=>x.ClassId == classId);
        }

        public Teacher GetTeacherById(int id)
        {
            return teacherRep.Get(x=>x.Id == id);
        }

        public Teacher GetTeacherByPersonId(int personId)
        {
            return teacherRep.Get(x=> x.PersonId == personId);
        }

        public List<Teacher> GetTeachersBySpecialization(int specializationId)
        {
            return teacherRep.GetAll().FindAll(x=>x.SpecializationId == specializationId);
        }
    }
}
