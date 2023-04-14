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
    public class UserRoleRepository : IRepository<UserRole>
    {
        List<UserRole> UserRoleList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public UserRoleRepository(ApplicationContext context)
        {
            UserRoleList = new List<UserRole>();
            Read();
            this._context = context;
        }
        public void Create(UserRole tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<UserRole, bool> filter)
        {
            UserRole cl = UserRoleList.First(filter);
            UserRoleList.Remove(cl);
            _context.Remove(cl);
        }

        public UserRole Get(Func<UserRole, bool> filter)
        {
            return _context.UserRole.Single(filter);
        }

        public List<UserRole> GetAll()
        {
            return UserRoleList;
        }



        public void Read()
        {
            UserRoleList = _context.UserRole.ToList();
        }

        public void Refresh()
        {
            UserRoleList.Clear();
            Read();
        }

        public void Update(UserRole obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
