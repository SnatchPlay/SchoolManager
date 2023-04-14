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
    public class UserInfoRepository : IRepository<UserInfo>
    {
        List<UserInfo> UserInfoList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public UserInfoRepository(ApplicationContext context)
        {
            UserInfoList = new List<UserInfo>();
            Read();
            this._context = context;
        }
        public void Create(UserInfo tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<UserInfo, bool> filter)
        {
            UserInfo cl = UserInfoList.First(filter);
            UserInfoList.Remove(cl);
            _context.Remove(cl);
        }

        public UserInfo Get(Func<UserInfo, bool> filter)
        {
            return _context.UserInfo.Single(filter);
        }

        public List<UserInfo> GetAll()
        {
            return UserInfoList;
        }



        public void Read()
        {
            UserInfoList = _context.UserInfo.ToList();
        }

        public void Refresh()
        {
            UserInfoList.Clear();
            Read();
        }

        public void Update(UserInfo obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
