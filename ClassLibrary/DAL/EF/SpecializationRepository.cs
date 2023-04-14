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
    public class SpecializationRepository : IRepository<Specialization>
    {
        List<Specialization> SpecializationList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public SpecializationRepository(ApplicationContext context)
        {
            SpecializationList = new List<Specialization>();
            Read();
            this._context = context;
        }
        public void Create(Specialization tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<Specialization, bool> filter)
        {
            Specialization cl = SpecializationList.First(filter);
            SpecializationList.Remove(cl);
            _context.Remove(cl);
        }

        public Specialization Get(Func<Specialization, bool> filter)
        {
            return _context.Specialization.Single(filter);
        }

        public List<Specialization> GetAll()
        {
            return SpecializationList;
        }



        public void Read()
        {
            SpecializationList = _context.Specialization.ToList();
        }

        public void Refresh()
        {
            SpecializationList.Clear();
            Read();
        }

        public void Update(Specialization obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
