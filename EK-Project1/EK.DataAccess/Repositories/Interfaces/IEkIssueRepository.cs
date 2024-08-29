using EK.Entities.Models;


namespace EK.DataAccess.Repositories.Interfaces
{
    public interface IEkIssueRepository 
    {
        Task<IEnumerable<EkIssue>> GetIssues();
        Task<EkIssue> GetIssue(int id);
        Task<bool> CreateIssue(EkIssue ekIssue); 
        Task<bool> UpdateIssue(EkIssue ekIssue);
        Task<bool> SaveAsync();
        Task<bool> UpdateIssueIsDeleted(EkIssue ekIssue);
        Task<IEnumerable<IssueWithStatus>> GetIssuesWithStatusAsync();
    }
}
   