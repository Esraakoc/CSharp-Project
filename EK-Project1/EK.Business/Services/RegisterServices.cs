using EK.Business.Dto;
using EK.Business.Services.Interfaces;
using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;
 
namespace EK.Business.Services
{ 
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public async Task<bool> RegisterUserAsync(RegisterDto registerDto)
        {
            if (string.IsNullOrWhiteSpace(registerDto.UserId) ||
                string.IsNullOrWhiteSpace(registerDto.Email) ||
                string.IsNullOrWhiteSpace(registerDto.Password)) 
            { 
                throw new ArgumentException("UserId, Email, and Password are required."); 
            }

            var existingUser = await _registerRepository.GetUserByUserIdOrEmailAsync(registerDto.UserId, registerDto.Email);
            if (existingUser != null)
            {
                throw new ArgumentException("A user with this UserId or Email already exists.");
            }

            var user = new EkUser
            {
                UserId = registerDto.UserId,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Password = registerDto.Password 
            };
             
            return await _registerRepository.RegisterUserAsync(user);
        }
    }
}
