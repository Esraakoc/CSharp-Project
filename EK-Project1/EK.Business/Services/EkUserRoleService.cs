using EK.Business.Dto;
using EK.Business.Services.Interfaces;
using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.Business.Services
{
    public class EkUserRoleService : IEkUserRoleService
    {
        private readonly IEkUserRoleRepository _userRoleRepository;

        public EkUserRoleService(IEkUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task AddUserRoleAsync(UserRoleDto userRoleDto)
        {
            var userRole = new EkUserRole
            {
                UserId = userRoleDto.UserId,
                RoleId = userRoleDto.RoleId
            };

            await _userRoleRepository.AddUserRoleAsync(userRole);
        }
    }
}
