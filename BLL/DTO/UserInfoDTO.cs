using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }
        public Guid Salt { get; set; }
        public int Role { get; set; }
        public UserInfoDTO(int id, string login, byte[] password, Guid salt, int role)
        {
            Id = id;
            Login = login;
            Password = password;
            Salt = salt;
            Role = role;
        }
    }
}
