using ClassLibrary.DAL;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL.EF
{
    public class ParentRepository : IRepository<Parent>
    {
        List<Parent> ParentList;
        private ApplicationContext _context;

        public ParentRepository(ApplicationContext context)
        {
            ParentList = new List<Parent>();
            Read();
            this._context = context;
        }
        public void Create(Parent tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<Parent, bool> filter)
        {
            Parent cl = ParentList.First(filter);
            ParentList.Remove(cl);
            _context.Remove(cl);
        }

        public Parent Get(Func<Parent, bool> filter)
        {
            //Expression<Func<Parent, bool>> filter = p => p.FirstName == "John";
            return _context.Parents.Single(filter);
        }

        public List<Parent> GetAll()
        {
            return ParentList;
        }



        public void Read()
        {
            ParentList = _context.Parents.ToList();
        }

        public void Refresh()
        {
            ParentList.Clear();
            Read();
        }

        public void Update(Parent obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
