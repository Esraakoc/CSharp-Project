using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EK.DataAccess.Repositories
{
    public class EkIssueRepository : IEkIssueRepository
    {
        private readonly AppDbContext _appDbContext;

        public EkIssueRepository(AppDbContext appDbContext) 
        { 
            _appDbContext = appDbContext;
        }
        public IQueryable<EkIssue> StatusAll(bool trackChanges) 
        {
            return trackChanges ? _appDbContext.EkIssues : _appDbContext.EkIssues.AsNoTracking();
        }
        public async Task<IEnumerable<IssueWithStatus>> GetIssuesWithStatusAsync()
        {
            return await _appDbContext.GetIssuesWithStatusAsync();
        }

        public async Task<IEnumerable<EkIssue>> GetIssues()  
        { 
            return await StatusAll(trackChanges: false).ToListAsync();
        }

        public async Task<EkIssue> GetIssue(int id)
        {
            var issue = await StatusAll(trackChanges: false).FirstOrDefaultAsync(e=>e.TaskId ==id );
            if (issue == null)
            {
                throw new Exception($"Issue with ID {id} not found.");
            }
            return issue;
        } 

        public async Task<bool> CreateIssue(EkIssue ekIssue)
        {
            await _appDbContext.EkIssues.AddAsync(ekIssue);
            return await SaveAsync();
        }
        public async Task<bool> UpdateIssue(EkIssue ekIssue)
        {
            _appDbContext.EkIssues.Update(ekIssue); 
            return await SaveAsync();
        }
        public async Task<bool> SaveAsync()
        {
            var saved = await _appDbContext.SaveChangesAsync();
            return saved > 0;
        }
        public async Task<bool> UpdateIssueIsDeleted(EkIssue ekIssue)
        { 
            var existingIssue = await _appDbContext.EkIssues.FindAsync(ekIssue.TaskId);
            if (existingIssue == null)
            {
                return false;
            }

            existingIssue.IsDeleted = ekIssue.IsDeleted; 
            return await SaveAsync();
        }

    }
}
