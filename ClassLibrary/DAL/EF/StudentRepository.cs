using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
            Student cl = _context.Students.Find(id);
            for (int i = 0; i < StudentList.Count(); i++)
            {
                if (i == id)
                {
                    StudentList.RemoveAt(i);
                }
            }
            _context.Remove(cl);
        }

        public List<Student> GetAll()
        {
            return StudentList;
        }

        public Student Get(int id)
        {
            return _context.Students.Find(id);
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
        }
    }
}
