using EK.Business.Services.Interfaces;
using EK.DataAccess;
using EK.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EK.Business.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly AppDbContext _context;

        public PasswordService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EkUser?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            return await _context.EkUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ValidateNewPasswordAsync(string newPassword, string confirmPassword)
        { 
            return await Task.FromResult(newPassword == confirmPassword);
        }

        public async Task<bool> UpdatePasswordAsync(string userId, string hashedPassword)
        {
            var user = await _context.EkUsers.FindAsync(userId);
            if (user == null)
                return false;

            user.Password = hashedPassword;
            _context.EkUsers.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
