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
    public class TaskClassRepository : IRepository<TaskClass>
    {
        List<TaskClass> TaskList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public TaskClassRepository(ApplicationContext context)
        {
            TaskList = new List<TaskClass>();
            Read();
            this._context = context;
        }
        public void Create(TaskClass tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<TaskClass, bool> filter)
        {
            TaskClass cl = TaskList.First(filter);
            TaskList.Remove(cl);
            _context.Remove(cl);
        }

        public TaskClass Get(Func<TaskClass, bool> filter)
        {
            return _context.Tasks.Single(filter);
        }

        public List<TaskClass> GetAll()
        {
            return TaskList;
        }



        public void Read()
        {
            TaskList = _context.Tasks.ToList();
        }

        public void Refresh()
        {
            TaskList.Clear();
            Read();
        }

        public void Update(TaskClass obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
