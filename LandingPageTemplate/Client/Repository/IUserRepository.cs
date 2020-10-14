using LandingPageTemplate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public interface IUserRepository
    {
        Task AssignRole(EditRoleDTO editRole);
        Task<List<UserDTO>> Get();
        Task<List<RoleDTO>> GetRoles();
        Task RemoveRole(EditRoleDTO editRole);
    }
}
