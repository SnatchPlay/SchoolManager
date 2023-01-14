using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
            Shedule cl = _context.Shedule.Find(id);
            for (int i = 0; i < SheduleList.Count(); i++)
            {
                if (i == id)
                {
                    SheduleList.RemoveAt(i);
                }
            }
            _context.Remove(cl);
        }

        public List<Shedule> GetAll()
        {
            return SheduleList;
        }

        public Shedule Get(int id)
        {
            return _context.Shedule.Find(id);
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
        }
    }
}
