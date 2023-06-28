using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    internal interface ITeacherService
    {
        public Teacher GetTeacherById(int id);
        public Teacher GetTeacherByPersonId(int personId);
        public Teacher GetTeacherByClassId(int classId);
        public List<Teacher> GetAllTeachers();
        public List<Teacher> GetTeachersBySpecialization(int specializationId);
        public void ChangeTeacherClass(Teacher teacher,int newClassId);
        public void ChangeTeacherSpecialization(Teacher teacher, int newSpecializationId);
        public void ChangeTeacherPersonId(Teacher teacher, int newPersonId);
    }
}
