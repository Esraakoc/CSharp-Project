using EK.Entities.Models;

namespace EK.DataAccess.Repositories.Interfaces
{
    public interface IEkUserRepository
    {

        Task<IEnumerable<EkUser>> GetUsersAsync();
        Task<EkUser> GetUserAsync(string id);
        Task<bool> SaveAsync();
    }
}
  