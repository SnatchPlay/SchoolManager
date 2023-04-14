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
    public class TeacherRepository : IRepository<Teacher>
    {
        List<Teacher> TeacherList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public TeacherRepository(ApplicationContext context)
        {
            TeacherList = new List<Teacher>();
            Read();
            this._context = context;
        }
        public void Create(Teacher tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<Teacher, bool> filter)
        {
            Teacher cl = TeacherList.First(filter);
            TeacherList.Remove(cl);
            _context.Remove(cl);
        }

        public Teacher Get(Func<Teacher, bool> filter)
        {
            return _context.Teachers.Single(filter);
        }

        public List<Teacher> GetAll()
        {
            return TeacherList;
        }



        public void Read()
        {
            TeacherList = _context.Teachers.ToList();
        }

        public void Refresh()
        {
            TeacherList.Clear();
            Read();
        }

        public void Update(Teacher obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
