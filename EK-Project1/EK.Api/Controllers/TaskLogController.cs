using EK.Business.Dto;
using EK.Business.Services.Interfaces;
using EK.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace EK.Api.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class TaskLogController : ControllerBase
    {
        private readonly IEkTaskLogService _taskLogService; 
        public TaskLogController(IEkTaskLogService taskLogService) 
        {
            _taskLogService = taskLogService; 
        } 
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<EkTaskLog>>> GetTaskLogsByUser(string userId)
        {
            var taskLogs = await _taskLogService.GetTaskLogsByUser(userId); 
            return Ok(taskLogs);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTaskLog([FromBody] EkTaskLogDto ekTaskLogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            } 
            ekTaskLogDto.LogDate = DateTime.UtcNow;
             
            var id = await _taskLogService.CreateTaskLog(ekTaskLogDto);

            if (id <= 0)
            { 
                return StatusCode(500, "Task assignment exceeds the allowed limit of 40 hours.");
            }

            return CreatedAtAction(nameof(GetTaskLogs), new { id }, new { id });
        }
        [HttpDelete("{taskId}")]
        public async Task<ActionResult> DeleteIssue(int taskId)
        {
            var result = await _taskLogService.DeleteIssue(taskId);
            if (!result)
            {
                return NotFound(); // 404
            }
            return NoContent(); // 204
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EkTaskLog>>> GetTaskLogs()
        {
            var takslogs = await _taskLogService.GetTaskLogs(); 
            return Ok(takslogs);
        }

        [HttpPut("{id}/notification")]
        public async Task<IActionResult> UpdateTaskLogNotification(int id, [FromBody] byte notification)
        {
            if (notification < 0 || notification > 1)
            {
                return BadRequest("Invalid notification value."); 
            }

            var result = await _taskLogService.UpdateTaskLogNotification(id, notification); 

            if (!result)
            {
                return NotFound(); // 404
            } 

            return NoContent(); // 204
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateTaskLogStatus(int id,string userId, [FromBody] byte status)
        {
            var result = await _taskLogService.UpdateTaskLogStatus(id, userId, status);
             
            if (!result)
            {
                return NotFound(); // 404
            }

            return NoContent();
        }
    }
}
