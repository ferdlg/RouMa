using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Role>> GetRoles();
        Task<Role> GetRol(int id);
        Task PostRol(Role Rol);
        Task<Role> PutRol(int id);

        Task<Role> DeleteRol(int id);
    }
}
