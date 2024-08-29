using EK.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.DataAccess.Repositories.Interfaces
{
    public interface IEkTaskLogRepository
    {
        IQueryable<EkTaskLog> StatusAll(bool trackChanges);
        Task<IEnumerable<EkTaskLog>> GetTaskLogs();
        Task<IEnumerable<EkTaskLog>> GetTaskLogsByUser(string userId);
        void Create(EkTaskLog entity);
        Task<bool> CreateTaskLog(EkTaskLog ekTaskLog);
        Task<bool> SaveAsync(); 
        Task<EkTaskLog> GetTaskLogById(int id); 
        Task<bool> UpdateTaskLog(EkTaskLog taskLog);
        Task<bool> DeleteAsync(int taskId); 
        Task<EkTaskLog?> GetTaskLogByTaskId(int taskId);
        Task<EkTaskLog?> GetTaskLogByTaskUserId(int taskId, string userId);
    } 
}
