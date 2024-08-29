using EK.Entities.Models;


namespace EK.DataAccess.Repositories.Interfaces
{ 
    public interface IRegisterRepository
    {
        Task<bool> RegisterUserAsync(EkUser user);
        Task<EkUser?> GetUserByUserIdOrEmailAsync(string userId, string email);
    } 
}
