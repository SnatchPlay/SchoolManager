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
    public class JournalRepository : IRepository<Journal>
    {
        List<Journal> JournalList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public JournalRepository(ApplicationContext context)
        {
            JournalList = new List<Journal>();
            Read();
            this._context = context;
        }
        public void Create(Journal tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<Journal, bool> filter)
        {
            Journal cl = JournalList.First(filter);
            JournalList.Remove(cl);
            _context.Remove(cl);
        }

        public Journal Get(Func<Journal, bool> filter)
        {
            return _context.Journal.Single(filter);
        }

        public List<Journal> GetAll()
        {
            return JournalList;
        }


        public void Read()
        {
            JournalList = _context.Journal.ToList();
        }

        public void Refresh()
        {
            JournalList.Clear();
            Read();
        }

        public void Update(Journal obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
