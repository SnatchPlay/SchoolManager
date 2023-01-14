using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
            UserInfo cl = _context.UserInfo.Find(id);
            for (int i = 0; i < UserInfoList.Count(); i++)
            {
                if (i == id)
                {
                    UserInfoList.RemoveAt(i);
                }
            }
            _context.Remove(cl);
        }

        public List<UserInfo> GetAll()
        {
            return UserInfoList;
        }

        public UserInfo Get(int id)
        {
            return _context.UserInfo.Find(id);
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
        }
    }
}
