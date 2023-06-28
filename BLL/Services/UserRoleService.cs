using BLL.Interfaces;
using ClassLibrary.DAL;
using ClassLibrary.Factory;
using ClassLibrary.Models;

namespace BLL.Services
{
    internal class UserRoleService : IUserRoleService
    {
        private IRepository<UserRole> userRoleRep;
        public UserRoleService()
        {
            userRoleRep = FactoryProvider.GetFactory().GetUserRoleRepository();
        }
        public void AddUserRole(string rolename)
        {
            UserRole userRole = new UserRole() { RoleName=rolename};

            userRoleRep.Create(userRole);
        }

        public UserRole GetUserRoleByName(string name)
        {
            return userRoleRep.GetAll().Where(x => x.RoleName == name).First();
             
        }

        public List<UserRole> GetUserRoles()
        {
            return userRoleRep.GetAll();
        }

        public UserRole GetUserRolesById(int id)
        {
            return userRoleRep.Get(x => x.Id == id);
        }

        public void RemoveUserRoleById(int id)
        {
            userRoleRep.Delete(x=>x.Id==id);
        }

        public void RenameUserRole(UserRole _userRole,string newName)
        {
            _userRole.RoleName = newName;
            userRoleRep.Update(_userRole);
        }
    }
}
