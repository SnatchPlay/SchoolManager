using ClassLibrary.Models;

namespace BLL.Interfaces
{
    internal interface IUserRoleService
    {
        public void AddUserRole(string rolename);
        public void RemoveUserRoleById(int id);
        public void RenameUserRole(UserRole userRole,string newName);
        public List<UserRole> GetUserRoles();
        public UserRole GetUserRolesById(int id);
        public UserRole GetUserRoleByName(string name);

    }
}
