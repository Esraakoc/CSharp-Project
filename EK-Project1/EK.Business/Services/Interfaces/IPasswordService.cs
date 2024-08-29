using EK.Entities.Models;
using System.Threading.Tasks;

namespace EK.Business.Services.Interfaces
{
    public interface IPasswordService
    {
        Task<EkUser?> GetUserByEmailAsync(string email);
        Task<bool> ValidateNewPasswordAsync(string newPassword, string confirmPassword);
        Task<bool> UpdatePasswordAsync(string userId, string newPassword);
    }
}
 