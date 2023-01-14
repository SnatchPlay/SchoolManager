using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
            Specialization cl = _context.Specialization.Find(id);
            for (int i = 0; i < SpecializationList.Count(); i++)
            {
                if (i == id)
                {
                    SpecializationList.RemoveAt(i);
                }
            }
            _context.Remove(cl);
        }

        public List<Specialization> GetAll()
        {
            return SpecializationList;
        }

        public Specialization Get(int id)
        {
            return _context.Specialization.Find(id);
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
        }
    }
}
