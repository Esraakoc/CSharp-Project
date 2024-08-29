using EK.Entities.Models;

namespace EK.DataAccess.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<EkUser> GetUserByIdAsync(string userId);
    } 
}
 