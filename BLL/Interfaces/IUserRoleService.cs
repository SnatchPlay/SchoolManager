using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    internal interface IUserRoleService
    {
        public void AddUserRole(string rolename);
        public void RemoveUserRoleById(int id);
        public void RenameUserRole(UserRoleDTO userRoleDTO,string newName);
        public List<UserRoleDTO> GetUserRoles();
        public UserRoleDTO GetUserRolesById(int id);
        public UserRoleDTO GetUserRoleByName(string name);

    }
}
