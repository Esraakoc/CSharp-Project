using EK.Business.Services.Interfaces;
using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;

namespace EK.Business.Services
{
    public class EkUserService : IEkUserService
    { 
        private readonly IEkUserRepository _ekUserRepository;

        public EkUserService(IEkUserRepository ekUserRepository)
        {
            _ekUserRepository = ekUserRepository;
        }

        public async Task<IEnumerable<EkUser>> GetUsersAsync()
        { 
            return await _ekUserRepository.GetUsersAsync();
        } 

        public async Task<EkUser> GetUserByIdAsync(string id)
        {
            return await _ekUserRepository.GetUserAsync(id);
        }
    }
}
