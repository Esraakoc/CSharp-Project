using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EK.DataAccess.Repositories
{
    public class EkUserRepository : IEkUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public EkUserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<EkUser> StatusAll(bool trackChanges)
        {
            return trackChanges ? _appDbContext.EkUsers : _appDbContext.EkUsers.AsNoTracking(); 
        }

        public async Task<IEnumerable<EkUser>> GetUsersAsync()
        {
            return await StatusAll(trackChanges: false).ToListAsync();
        }

        public async Task<EkUser> GetUserAsync(string id)
        {
            var user = await StatusAll(trackChanges: false).FirstOrDefaultAsync(e => e.UserId == id);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            return user;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                var saved = await _appDbContext.SaveChangesAsync();
                return saved > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes.", ex);
            }
        }
    }
}
