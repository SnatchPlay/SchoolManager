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
    public class StudentRepository : IRepository<Student>
    {
        List<Student> StudentList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public StudentRepository(ApplicationContext context)
        {
            StudentList = new List<Student>();
            Read();
            this._context = context;
        }
        public void Create(Student tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<Student, bool> filter)
        {
            Student cl = StudentList.First(filter);
            StudentList.Remove(cl);
            _context.Remove(cl);
        }

        public Student Get(Func<Student, bool> filter)
        {
            return _context.Students.Single(filter);
        }

        public List<Student> GetAll()
        {
            return StudentList;
        }



        public void Read()
        {
            StudentList = _context.Students.ToList();
        }

        public void Refresh()
        {
            StudentList.Clear();
            Read();
        }

        public void Update(Student obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
