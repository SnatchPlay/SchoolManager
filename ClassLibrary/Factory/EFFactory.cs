using ClassLibrary.DAL;
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
        public IRepository<Class> GetClassRepository()
        {
            throw new NotImplementedException();
        }

        public IRepository<Journal> GetJournalRepository()
        {
            throw new NotImplementedException();
        }

        public IRepository<Lesson> GetLessonRepository()
        {
            throw new NotImplementedException();
        }

        public IRepository<Person> GetPersonRepository()
        {
            //return new EFPersonRepository;
            return null;
        }

        public IRepository<Shedule> GetSheduleRepository()
        {
            throw new NotImplementedException();
        }

        public IRepository<Specialization> GetSpecializationRepository()
        {
            throw new NotImplementedException();
        }

        public IRepository<Student> GetStudentRepository()
        {
            throw new NotImplementedException();
        }

        public IRepository<TaskClass> GetTaskClassRepository()
        {
            throw new NotImplementedException();
        }

        public IRepository<Teacher> GetTeacherRepository()
        {
            throw new NotImplementedException();
        }

        public IRepository<UserInfo> GetUserInfoRepository()
        {
            throw new NotImplementedException();
        }

        public IRepository<UserRole> GetUserRoleRepository()
        {
            throw new NotImplementedException();
        }
    }
}
