using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserRoleDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public UserRoleDTO(int id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }
    }
}
