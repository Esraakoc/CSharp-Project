using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;
using EK.Business.Services.Interfaces;
using EK.Business.Dto;
using Microsoft.EntityFrameworkCore;
using EK.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EK.DataAccess.Repositories;

namespace EK.Business.Services
{
    public class EkIssueService : IEkIssueService 
    { 
        private readonly IEkIssueRepository _ekIssueRepository;
        private readonly IEkUserRoleRepository _ekUserRoleRepository;
        private readonly IEkTaskLogRepository _taskLogRepository;
        public EkIssueService(IEkIssueRepository ekIssueRepository, IEkTaskLogRepository taskLogRepository, IEkUserRoleRepository ekUserRoleRepository)
        {
            _ekIssueRepository = ekIssueRepository; 
            _taskLogRepository = taskLogRepository;
            _ekUserRoleRepository = ekUserRoleRepository;
        } 
         
        public async Task<IEnumerable<EkIssue>> GetIssues()
        {
            return await _ekIssueRepository.GetIssues();  
        } 
        public async Task<EkIssue> GetIssueById(int id) 
        {
            return await _ekIssueRepository.GetIssue(id); 
        }
        public async Task<IEnumerable<IssueWithStatus>> GetIssuesWithStatus()
        {
            return await _ekIssueRepository.GetIssuesWithStatusAsync();
        }
        public async Task<int> CreateIssue(EkIssueDto issueDto)
        {
            var userRoles = await _ekUserRoleRepository.GetUserRolesWithRoleNamesAsync();
            var existingIssues = await _ekIssueRepository.GetIssuesWithStatusAsync();
            var userRole = userRoles.FirstOrDefault(role => role.UserId == issueDto.Assignedto);

            if (userRole != null && userRole.RoleName == "admin")
            {
                throw new InvalidOperationException("A task cannot be assigned to the admin.");
            }

            double totalTimestampForUser = existingIssues
                .Where(issue => issue.Assignedto == issueDto.Assignedto && (issue.Status == "Appointed" || issue.Status == "Continues"))
                .Sum(issue => issue.Timestamp ?? 0);

            double newTotalTimestampForUser = totalTimestampForUser + (issueDto.Timestamp ?? 0);

            if (newTotalTimestampForUser > 40)
            {
                throw new Exception("This task cannot be assigned because it exceeds the allowed limit of 40 hours for this user.");
            }

            var issue = new EkIssue
            {
                TaskName = issueDto.TaskName,
                Description = issueDto.Description,
                Createdby = issueDto.Createdby,
                Watcher = issueDto.Watcher,
                FirstRecDate = issueDto.FirstRecDate,
                Timestamp = issueDto.Timestamp,
                BegDate = issueDto.BegDate,
                EndDate = issueDto.EndDate
            };

            var issueCreated = await _ekIssueRepository.CreateIssue(issue);
            if (!issueCreated)
            {
                throw new Exception("Failed to create issue."); 
            }

            var taskLog = new EkTaskLog
            {
                TaskId = issue.TaskId,
                UserId = issueDto.Assignedto,
                Status = 0,
                LogDate= issue.FirstRecDate
            };

            var taskLogCreated = await _taskLogRepository.CreateTaskLog(taskLog);
            if (!taskLogCreated)
            {
                throw new Exception("Failed to create task log.");
            }

            return issue.TaskId;
        }
        public async Task<bool> UpdateIssue(int taskId, string description, string taskName, double timestamp)
        {
            var issue = await _ekIssueRepository.GetIssue(taskId);
            if (issue == null) return false;
             
            issue.Description = description;  
            issue.TaskName = taskName;
            issue.Timestamp = timestamp;

            return await _ekIssueRepository.UpdateIssue(issue);
        }

        public async Task<bool> UpdateIssueStatus(EkTaskLogDto updateStatusDto)
        {
            var taskLog = await _taskLogRepository.GetTaskLogByTaskUserId(updateStatusDto.TaskId, updateStatusDto.UserId);
            if (taskLog == null)
                return false;

            taskLog.Status = updateStatusDto.Status;

            var taskLogUpdated = await _taskLogRepository.UpdateTaskLog(taskLog);
            if (!taskLogUpdated)
                return false;

            if (updateStatusDto.Status == 2)
            {
                var issue = await _ekIssueRepository.GetIssue(updateStatusDto.TaskId);
                if (issue == null)
                    return false;

                issue.EndDate = DateTime.UtcNow;

                var issueUpdated = await _ekIssueRepository.UpdateIssue(issue);
                return issueUpdated;
            }

            return true;
        }


        public async Task<bool> UpdateIssueIsDeleted(int taskId)
        {
            var issue = await _ekIssueRepository.GetIssue(taskId);
            if (issue == null)
            {
                return false;
            }
            issue.IsDeleted = 1;
            return await _ekIssueRepository.UpdateIssueIsDeleted(issue);
        }

    } 
}
