using EK.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.Business.Services.Interfaces
{
    public interface IEkUserRoleService
    {
        Task AddUserRoleAsync(UserRoleDto userRoleDto);
    }
}
