using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
            Teacher cl = _context.Teachers.Find(id);
            for (int i = 0; i < TeacherList.Count(); i++)
            {
                if (i == id)
                {
                    TeacherList.RemoveAt(i);
                }
            }
            _context.Remove(cl);
        }

        public List<Teacher> GetAll()
        {
            return TeacherList;
        }

        public Teacher Get(int id)
        {
            return _context.Teachers.Find(id);
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
        }
    }
}
