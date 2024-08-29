using EK.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.Business.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<bool> RegisterUserAsync(RegisterDto registerDto);
    }
}
 