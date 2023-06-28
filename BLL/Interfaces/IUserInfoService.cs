using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    internal interface IUserInfoService
    {
        public void AddUserInfo(string login,string password,int role);
        public void RemoveUserInfoById(int id);
        public void ChangeLogin(UserInfo _userInfo, string newLogin);
        public void ChangePassword(UserInfo _userInfo, string newPassword);
        public void ChangeRole(UserInfo _userInfo, int newRole);
        public bool VerifyPassword(byte[] hash, byte[] password);
        public byte[] HashGenerator(string password, string salt);
        public List<UserInfo> GetUserInfos();
        public UserInfo GetUserInfoById(int id);
        public UserInfo GetUserInfoByLogin(string login);
    }
}
