using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL.EF
{
    public class LessonRepository : IRepository<Lesson>
    {
        List<Lesson> LessonList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public LessonRepository(ApplicationContext context)
        {
            LessonList = new List<Lesson>();
            Read();
            this._context = context;
        }
        public void Create(Lesson tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<Lesson, bool> filter)
        {
            Lesson cl = LessonList.First(filter);
            LessonList.Remove(cl);
            _context.Remove(cl);
        }

        public List<Lesson> GetAll()
        {
            return LessonList;
        }


        public void Read()
        {
            LessonList = _context.Lessons.ToList();
        }

        public void Refresh()
        {
            LessonList.Clear();
            Read();
        }

        public void Update(Lesson obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Lesson Get(Func<Lesson, bool> filter)
        {
            return _context.Lessons.Single(filter);
        }
    }
}
