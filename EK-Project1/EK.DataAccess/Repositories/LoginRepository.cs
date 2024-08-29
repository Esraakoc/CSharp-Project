using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace EK.DataAccess.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context) 
        { 
            _context = context;
        }
        public async Task<EkUser> GetUserByIdAsync(string userId)
        { 
            var user = await _context.EkUsers.FirstOrDefaultAsync(u => u.UserId == userId)
                        ?? throw new Exception($"User with ID {userId} not found");
            return user;
        }
    }
}
 