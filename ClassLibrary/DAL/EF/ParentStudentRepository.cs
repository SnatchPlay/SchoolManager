using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClassLibrary.DAL.EF
{
    public class ParentStudentRepository : IRepository<ParentStudent>
    {
        private ApplicationContext _context;
        List<ParentStudent> ParentStudentList;

        public ParentStudentRepository(ApplicationContext context)
        {
            ParentStudentList = new List<ParentStudent>();
            Read();
            this._context = context;
        }

        public void Create(ParentStudent tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<ParentStudent, bool> filter)
        {
            ParentStudent cl = ParentStudentList.First(filter);
            ParentStudentList.Remove(cl);
            _context.ParentStudents.Remove(cl);

        }

        public ParentStudent Get(Func<ParentStudent, bool> filter)
        {
            //var parentStudent = parentStudentRepository.Get(ps => ps.ParentId == 1 && ps.StudentId == 2);
            return _context.ParentStudents.Single(filter);
        }
    

        public List<ParentStudent> GetAll()
        {
            return _context.ParentStudents.ToList();
        }



        public void Read()
        {
            _context.ParentStudents.ToList();
        }

        public void Refresh()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        public void Update(ParentStudent obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
