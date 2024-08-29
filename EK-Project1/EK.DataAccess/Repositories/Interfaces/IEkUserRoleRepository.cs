using EK.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.DataAccess.Repositories.Interfaces
{
    public interface IEkUserRoleRepository
    {
        Task AddUserRoleAsync(EkUserRole userRole);
        Task<IEnumerable<UserRoleWithRoleName>> GetUserRolesWithRoleNamesAsync();
    }
}
 