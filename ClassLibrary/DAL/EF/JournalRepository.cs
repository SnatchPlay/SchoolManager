using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
            Journal cl = _context.Journal.Find(id);
            for (int i = 0; i < JournalList.Count(); i++)
            {
                if (i == id)
                {
                    JournalList.RemoveAt(i);
                }
            }
            _context.Remove(cl);
        }

        public List<Journal> GetAll()
        {
            return JournalList;
        }

        public Journal Get(int id)
        {
            return _context.Journal.Find(id);
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
        }
    }
}
