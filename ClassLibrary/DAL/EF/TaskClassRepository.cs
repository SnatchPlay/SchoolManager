using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
            TaskClass cl = _context.Tasks.Find(id);
            for (int i = 0; i < TaskList.Count(); i++)
            {
                if (i == id)
                {
                    TaskList.RemoveAt(i);
                }
            }
            _context.Remove(cl);
        }

        public List<TaskClass> GetAll()
        {
            return TaskList;
        }

        public TaskClass Get(int id)
        {
            return _context.Tasks.Find(id);
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
        }
    }
}
