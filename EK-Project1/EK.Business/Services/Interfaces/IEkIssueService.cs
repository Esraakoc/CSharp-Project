using EK.Business.Dto;
using EK.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
 
namespace EK.Business.Services.Interfaces
{
    public interface IEkIssueService   
    { 
        Task<IEnumerable<EkIssue>> GetIssues();  
        Task<EkIssue> GetIssueById(int id);
        Task<int> CreateIssue(EkIssueDto ıssueDto);
        Task<bool> UpdateIssueStatus(EkTaskLogDto updateStatusDto);
        Task<bool> UpdateIssue(int taskId, string description, string taskName, double timestamp);
        Task<bool> UpdateIssueIsDeleted(int taskId);
        Task<IEnumerable<IssueWithStatus>> GetIssuesWithStatus();
    } 
}
 