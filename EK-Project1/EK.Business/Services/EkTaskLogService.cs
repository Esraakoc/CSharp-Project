using EK.Business.Dto;
using EK.Business.Services.Interfaces;
using EK.DataAccess;
using EK.DataAccess.Repositories;
using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;
using System;
using System.Threading.Tasks;

namespace EK.Business.Services
{  
    public class EkTaskLogService : IEkTaskLogService 
    { 
        private readonly IEkTaskLogRepository _ekTaskLogRepository;
        private readonly IEkIssueRepository _ekIssueRepository;
        public EkTaskLogService(IEkTaskLogRepository ekTaskLogRepository, IEkIssueRepository ekIssueRepository)
        {
            _ekTaskLogRepository = ekTaskLogRepository; 
            _ekIssueRepository = ekIssueRepository;
        }
        public async Task<IEnumerable<EkTaskLog>> GetTaskLogs()
        {
            return await _ekTaskLogRepository.GetTaskLogs();
        }
        public async Task<IEnumerable<EkTaskLog>> GetTaskLogsByUser(string userId)
        {
            return await _ekTaskLogRepository.GetTaskLogsByUser(userId);
        }

        public async Task<int> CreateTaskLog(EkTaskLogDto taskLogDto) 
        {
            var taskLog = await _ekTaskLogRepository.GetTaskLogByTaskId(taskLogDto.TaskId);
            var existingIssues = await _ekIssueRepository.GetIssuesWithStatusAsync();
            var currentIssue = existingIssues.FirstOrDefault(issue => issue.TaskId == taskLogDto.TaskId);
            var assignedLogs = await _ekTaskLogRepository.GetTaskLogsByUser(taskLogDto.UserId);

            if (assignedLogs.Any(log => log.TaskId == taskLogDto.TaskId))
            {
                return -1;
            }

            if (currentIssue?.Createdby == taskLogDto.UserId)
            {
                return -1; 
            }

            double totalTimestampForUser = existingIssues
                .Where(issue => issue.Assignedto == taskLogDto.UserId && (issue.Status == "Appointed" || issue.Status == "Continues"))
                .Sum(issue => issue.Timestamp ?? 0);

            double currentTimestamp = currentIssue?.Timestamp ?? 0;
            double newTotalTimestampForUser = totalTimestampForUser + currentTimestamp;


            if (newTotalTimestampForUser > 40)
            {
                return -1;
            }

            var newTaskLog = new EkTaskLog
            {
                TaskId = taskLogDto.TaskId,
                UserId = taskLogDto.UserId,
                Status = taskLogDto.Status,
                Comment = taskLogDto.Comment,
                LogDate = taskLogDto.LogDate
            };

            await _ekTaskLogRepository.CreateTaskLog(newTaskLog);

            return newTaskLog.Id;
        }


        public async Task<bool> UpdateTaskLogNotification(int id, byte notification)
        {
            var taskLog = await _ekTaskLogRepository.GetTaskLogById(id);

            if (taskLog == null)
            {
                return false;
            }

            if (notification < 0 || notification > 1) 
            {
                return false;
            } 

            taskLog.Notification = notification;
            await _ekTaskLogRepository.UpdateTaskLog(taskLog);

            return true;
        }
        public async Task<bool> UpdateTaskLogStatus(int id,string userId, byte status)
        {
            var taskLog = await _ekTaskLogRepository.GetTaskLogByTaskUserId(id, userId);

            if (taskLog == null)
            { 
                return false;
            }

            taskLog.Status = status;
            await _ekTaskLogRepository.UpdateTaskLog(taskLog);

            return true;
        }
        public async Task<bool> DeleteIssue(int taskId)
        {
            return await _ekTaskLogRepository.DeleteAsync(taskId);
        }
    }
}
