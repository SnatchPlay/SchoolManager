using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using ClassLibrary.DAL;
using ClassLibrary.Factory;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class UserRoleService : IUserRoleService
    {
        private IRepository<UserRole> userroleRep;
        public UserRoleService()
        {
            userroleRep = FactoryProvider.GetFactory().GetUserRoleRepository();
        }
        public void AddUserRole(string rolename)
        {
            UserRole userRole = new UserRole() { RoleName=rolename};

            userroleRep.Create(userRole);
        }

        public UserRoleDTO GetUserRoleByName(string name)
        {
            var userRole=userroleRep.GetAll().Where(x => x.RoleName == name).First();
            return new UserRoleDTO ( userRole.Id,userRole.RoleName );
        }

        public List<UserRoleDTO> GetUserRoles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserRole, UserRoleDTO>()).CreateMapper();
            return mapper.Map<List<UserRole>, List<UserRoleDTO>>(userroleRep.GetAll());
        }

        public UserRoleDTO GetUserRolesById(int id)
        {
            var userRole=userroleRep.Get(id);
            return new UserRoleDTO( userRole.Id,userRole.RoleName );
        }

        public void RemoveUserRoleById(int id)
        {
            userroleRep.Delete(id);
        }

        public void RenameUserRole(UserRoleDTO userRoleDTO,string newName)
        {
            var userRole = userroleRep.Get(userRoleDTO.Id);
            userRole.RoleName = newName;
            userroleRep.Update(userRole);
        }
    }
}
