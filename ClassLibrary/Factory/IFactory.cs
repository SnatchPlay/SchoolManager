using ClassLibrary.DAL;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Factory
{
    public interface IFactory
    {
        IRepository<Person> GetPersonRepository();//Create Next in the same way
        IRepository<Class> GetClassRepository();
        IRepository<Journal> GetJournalRepository();
        IRepository<Lesson> GetLessonRepository();
        IRepository<Shedule> GetSheduleRepository();
        IRepository<Specialization> GetSpecializationRepository();
        IRepository<Student> GetStudentRepository();
        IRepository<TaskClass> GetTaskClassRepository();
        IRepository<Teacher> GetTeacherRepository();
        IRepository<UserInfo> GetUserInfoRepository();
        IRepository<UserRole> GetUserRoleRepository();
        
    }
}
