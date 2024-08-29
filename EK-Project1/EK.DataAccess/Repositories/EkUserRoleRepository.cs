using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.DataAccess.Repositories
{
    public class EkUserRoleRepository : IEkUserRoleRepository
    {
        private readonly AppDbContext _context;

        public EkUserRoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserRoleAsync(EkUserRole userRole)
        {
            _context.EkUserRoles.Add(userRole);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<UserRoleWithRoleName>> GetUserRolesWithRoleNamesAsync()
        {
            return await _context.GetUserRolesWithRoleNamesAsync();
        }
    }
}
