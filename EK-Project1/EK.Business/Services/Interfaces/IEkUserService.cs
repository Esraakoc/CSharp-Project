using EK.Entities.Models;

namespace EK.Business.Services.Interfaces
{
    public interface IEkUserService
    {
        Task<IEnumerable<EkUser>> GetUsersAsync();
        Task<EkUser> GetUserByIdAsync(string id);
    }
}
  