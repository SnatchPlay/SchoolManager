using ClassLibrary.DAL.ADO;
using ClassLibrary.DAL;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary.Factory
{
    public class ADOFactory:IFactory
    {
        public IRepository<Class> GetClassRepository()
        {
            return new ClassRepository();
        }

        public IRepository<Journal> GetJournalRepository()
        {
            return new JournalRepository();
        }

        public IRepository<Lesson> GetLessonRepository()
        {
            return new LessonRepository();
        }

        public IRepository<Parent> GetParentRepository()
        {
            return new ParentRepository();
        }

        public IRepository<ParentStudent> GetParentStudentRepository()
        {
            return new ParentStudentRepository();
        }

        public IRepository<Person> GetPersonRepository()
        {
            return new PersonRepository();
        }

        public IRepository<Shedule> GetSheduleRepository()
        {
            return new SheduleRepository();
        }

        public IRepository<Specialization> GetSpecializationRepository()
        {
            return new SpecializationRepository();
        }

        public IRepository<Student> GetStudentRepository()
        {
            return new StudentRepository();
        }

        public IRepository<TaskClass> GetTaskClassRepository()
        {
            return new TaskClassRepository();
        }

        public IRepository<Teacher> GetTeacherRepository()
        {
            return new TeacherRepository();
        }

        public IRepository<UserInfo> GetUserInfoRepository()
        {
            return new UserInfoRepository();
        }

        public IRepository<UserRole> GetUserRoleRepository()
        {
            return new UserRoleRepository();
        }
    }
}
