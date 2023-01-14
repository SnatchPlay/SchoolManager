using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
            Lesson cl = _context.Lessons.Find(id);
            for (int i = 0; i < LessonList.Count(); i++)
            {
                if (i == id)
                {
                    LessonList.RemoveAt(i);
                }
            }
            _context.Remove(cl);
        }

        public List<Lesson> GetAll()
        {
            return LessonList;
        }

        public Lesson Get(int id)
        {
            return _context.Lessons.Find(id);
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
        }
    }
}
