using EK.DataAccess.Repositories.Interfaces;
using EK.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK.DataAccess.Repositories
{
     
    public class EkTaskLogRepository : IEkTaskLogRepository 
    {
        private readonly AppDbContext _appDbContext;
         
        public EkTaskLogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        } 
        //...////
        public async Task<EkTaskLog?> GetTaskLogByTaskId(int taskId)
        {
            return await StatusAll(trackChanges: true).FirstOrDefaultAsync(t => t.TaskId == taskId); 
        } 
        //.../  
        public async Task<EkTaskLog?> GetTaskLogByTaskUserId(int taskId, string userId)
        {
            return await _appDbContext.EkTaskLogs
                .FirstOrDefaultAsync(log => log.TaskId == taskId && log.UserId == userId);
        }
        public IQueryable<EkTaskLog> StatusAll(bool trackChanges)
        {
            return trackChanges ? _appDbContext.EkTaskLogs : _appDbContext.EkTaskLogs.AsNoTracking();
        }

        public async Task<IEnumerable<EkTaskLog>> GetTaskLogs()  
        {
            return await StatusAll(trackChanges: false).ToListAsync();
        }
        public async Task<IEnumerable<EkTaskLog>> GetTaskLogsByUser(string userId)
        {
            return await StatusAll(trackChanges: false)
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }
        public void Create(EkTaskLog entity) 
        {
            _appDbContext.EkTaskLogs.Add(entity);
        }

        public async Task<bool> CreateTaskLog(EkTaskLog ekTaskLog)
        { 
            Create(ekTaskLog);
            return await SaveAsync();
        }
        public async Task<bool> SaveAsync()
        {
            var saved = await _appDbContext.SaveChangesAsync();
            return saved > 0;
        } 
        public async Task<EkTaskLog> GetTaskLogById(int id)
        {
            var taskLog = await StatusAll(trackChanges: true).FirstOrDefaultAsync(t => t.Id == id);  
            if (taskLog == null)
            {
                throw new KeyNotFoundException($"TaskLog with id {id} not found.");
            }
            return taskLog;
        }
        public async Task<bool> UpdateTaskLog(EkTaskLog taskLog)
        {
            _appDbContext.Update(taskLog);
            return await SaveAsync(); 
        }

       public async Task<bool> DeleteAsync(int taskId)
        {
            var taskLogs = await _appDbContext.EkTaskLogs
                .Where(t => t.TaskId == taskId)
                .ToListAsync();
      
            if (taskLogs.Count == 0)
            {
                return false;
            }

            _appDbContext.EkTaskLogs.RemoveRange(taskLogs);
            await _appDbContext.SaveChangesAsync();

            return true;

        }
    }
}
 