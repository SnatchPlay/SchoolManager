using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }
        public Guid Salt { get; set; }
        public int RoleId { get; set; }
        public UserInfo(int userId, string login, byte[] password,Guid salt, int roleId)
        {
            this.UserId = userId;
            this.Login = login;
            this.Password = password;
            this.RoleId = roleId;
            this.Salt = salt;
        }
        public UserInfo() { }
    }
}
