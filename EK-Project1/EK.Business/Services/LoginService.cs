using EK.DataAccess.Repositories.Interfaces;
using EK.Business.Services.Interfaces;
using EK.Business.Dto;
using EK.Entities.Models;

namespace EK.Business.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;  

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository; 
        }

        public async Task<EkUser?> LoginAsync(LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.UserId) || string.IsNullOrEmpty(loginDto.Password))
            {
                return null;
            }
              
            var user = await _loginRepository.GetUserByIdAsync(loginDto.UserId);
            if (user != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return user;
            } 
            return null;
        }
    }
}
