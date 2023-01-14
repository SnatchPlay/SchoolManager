using ClassLibrary.DAL;
using ClassLibrary.DAL.EF;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Factory
{
    public class EFFactory : IFactory
    {
        ApplicationContext applicationContext= new ApplicationContext();
        public IRepository<Class> GetClassRepository()
        {
            return new ClassRepository(applicationContext) ;
        }

        public IRepository<Journal> GetJournalRepository()
        {
            return new JournalRepository(applicationContext);
        }

        public IRepository<Lesson> GetLessonRepository()
        {
            return new LessonRepository(applicationContext);
        }

        public IRepository<Person> GetPersonRepository()
        {
            return new PersonRepository(applicationContext);
        }

        public IRepository<Shedule> GetSheduleRepository()
        {
            return new SheduleRepository(applicationContext);
        }

        public IRepository<Specialization> GetSpecializationRepository()
        {
            return new SpecializationRepository(applicationContext);
        }

        public IRepository<Student> GetStudentRepository()
        {
            return new StudentRepository(applicationContext);
        }

        public IRepository<TaskClass> GetTaskClassRepository()
        {
            return new TaskClassRepository(applicationContext);
        }

        public IRepository<Teacher> GetTeacherRepository()
        {
            return new TeacherRepository(applicationContext);
        }

        public IRepository<UserInfo> GetUserInfoRepository()
        {
            return new UserInfoRepository(applicationContext);
        }

        public IRepository<UserRole> GetUserRoleRepository()
        {
            return new UserRoleRepository(applicationContext);
        }
    }
}
