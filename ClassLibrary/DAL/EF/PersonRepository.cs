using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL.EF
{
    public class PersonRepository : IRepository<Person>
    {
        List<Person> PersonList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public PersonRepository(ApplicationContext context)
        {
            PersonList = new List<Person>();
            Read();
            this._context = context;
        }
        public void Create(Person tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(int id)
        {
            Person cl = _context.Person.Find(id);
            for (int i = 0; i < PersonList.Count(); i++)
            {
                if (i == id)
                {
                    PersonList.RemoveAt(i);
                }
            }
            _context.Remove(cl);
        }

        public List<Person> GetAll()
        {
            return PersonList;
        }

        public Person Get(int id)
        {
            return _context.Person.Find(id);
        }

        public void Read()
        {
            PersonList = _context.Person.ToList();
        }

        public void Refresh()
        {
            PersonList.Clear();
            Read();
        }

        public void Update(Person obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
