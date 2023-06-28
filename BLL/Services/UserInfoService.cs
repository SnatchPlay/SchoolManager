using BLL.Interfaces;
using ClassLibrary.DAL;
using ClassLibrary.Factory;
using ClassLibrary.Models;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services
{
    internal class UserInfoService : IUserInfoService
    {
        private IRepository<UserInfo> userInfoRep;
        public UserInfoService()
        { 
            userInfoRep=  FactoryProvider.GetFactory().GetUserInfoRepository();
        }
        public void AddUserInfo(string login, string password, int role)
        {
            Guid salt= Guid.NewGuid();
            byte[] pass=HashGenerator(password,salt.ToString());
            UserInfo userInfo = new UserInfo() { Login=login, Password=pass,Salt=salt,Role=role};
            userInfoRep.Create(userInfo);
        }

        public void ChangeLogin(UserInfo _userInfo, string newLogin)
        {
            var userInfo=userInfoRep.Get(x=>x.Id==_userInfo.Id);
            userInfo.Login=newLogin;
            userInfoRep.Update(userInfo);
        }

        public void ChangePassword(UserInfo _userInfo, string newPassword)
        {
            _userInfo.Password=HashGenerator(newPassword,_userInfo.Salt.ToString());
            userInfoRep.Update(_userInfo);
        }

        public void ChangeRole(UserInfo _userInfo, int newRole)
        {
            _userInfo.Role=newRole;
            userInfoRep.Update(_userInfo);
        }

        public UserInfo GetUserInfoById(int id)
        {
            return userInfoRep.Get(x=>x.Id==id);
        }

        public UserInfo GetUserInfoByLogin(string login)
        {
            return userInfoRep.Get(x=>x.Login==login);
        }

        public List<UserInfo> GetUserInfos()
        {
            return userInfoRep.GetAll();
        }

        public byte[] HashGenerator(string password, string salt)
        {
            return SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }

        public void RemoveUserInfoById(int id)
        {
            userInfoRep.Delete(x=>x.Id==id);
        }

        public bool VerifyPassword(byte[] hash, byte[] password)
        {
            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
