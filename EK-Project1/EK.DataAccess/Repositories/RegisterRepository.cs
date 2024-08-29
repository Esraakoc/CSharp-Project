using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EK.DataAccess.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly AppDbContext _context;

        public RegisterRepository(AppDbContext context)
        { 
            _context = context; 
        }

        public async Task<bool> RegisterUserAsync(EkUser user)
         { 
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            try
            { 
                _context.EkUsers.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                return false;
            } 
        }
        public async Task<EkUser?> GetUserByUserIdOrEmailAsync(string userId, string email)
        {
            return await _context.EkUsers
                .FirstOrDefaultAsync(u => u.UserId == userId || u.Email == email);
        }

    }
}
