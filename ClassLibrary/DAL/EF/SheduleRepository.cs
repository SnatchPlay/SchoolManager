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
    public class SheduleRepository : IRepository<Shedule>
    {
        List<Shedule> SheduleList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public SheduleRepository(ApplicationContext context)
        {
            SheduleList = new List<Shedule>();
            Read();
            this._context = context;
        }
        public void Create(Shedule tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<Shedule, bool> filter)
        {
            Shedule cl = SheduleList.First(filter);
            SheduleList.Remove(cl);
            _context.Remove(cl);
        }

        public Shedule Get(Func<Shedule, bool> filter)
        {
            return _context.Shedule.Single(filter);
        }

        public List<Shedule> GetAll()
        {
            return SheduleList;
        }



        public void Read()
        {
            SheduleList = _context.Shedule.ToList();
        }

        public void Refresh()
        {
            SheduleList.Clear();
            Read();
        }

        public void Update(Shedule obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
