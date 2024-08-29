using EK.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.Business.Services.Interfaces
{
    public interface ITokenService
    {
        string GeneratePasswordResetToken(EkUser user);
        Task<EkUser> GetUserByResetTokenAsync(string token);
    }
}
