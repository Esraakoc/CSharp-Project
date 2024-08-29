using EK.Business.Dto;
using EK.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.Business.Services.Interfaces
{
    public interface IEkTaskLogService  
    {
        Task<IEnumerable<EkTaskLog>> GetTaskLogs();
        Task<IEnumerable<EkTaskLog>> GetTaskLogsByUser(string userId);
        Task<int> CreateTaskLog(EkTaskLogDto taskLogDto);
        Task<bool> UpdateTaskLogNotification(int id, byte notification);
        Task<bool> UpdateTaskLogStatus(int id,string userId, byte status);
        Task<bool> DeleteIssue(int taskId); 

    }
} 
 