using Microsoft.AspNetCore.Mvc;
using EK.Entities.Models;
using EK.DataAccess.Repositories.Interfaces;
using EK.Business.Dto;
using EK.DataAccess.Repositories;
using EK.Business.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using EK.DataAccess;

namespace EK.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : ControllerBase 
    {
        private readonly IEkIssueService _issueService; 
        private readonly AppDbContext _context; 
        public IssueController(IEkIssueService ıssueService, AppDbContext context)
        {
            _issueService = ıssueService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EkIssue>>> GetIssues()
        {
            var issues = await _issueService.GetIssues();
            return Ok(issues);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EkIssue>> GetIssueById(int id)
        {
            var issue = await _issueService.GetIssueById(id);
            if (issue == null)
            {
                return NotFound(); //404
            } 
            return Ok(issue);
        }


        //....//
        [HttpGet("with-status")]
        public async Task<ActionResult<List<IssueWithStatus>>> GetIssuesWithStatus()
        {
            var issues = await _issueService.GetIssuesWithStatus(); 
            return Ok(issues); 
        }
        //...//
        [HttpPost]
        public async Task<ActionResult> CreateIssue([FromBody] EkIssueDto ekIssueDto)
        {
            if (!ModelState.IsValid)
            {  
                return BadRequest(ModelState); 
            }
            ekIssueDto.FirstRecDate = DateTime.UtcNow;
            ekIssueDto.BegDate = DateTime.UtcNow; 

            var taskId = await _issueService.CreateIssue(ekIssueDto);

            if (taskId <= 0)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return CreatedAtAction(nameof(GetIssueById), new { id = taskId }, new { id = taskId });
        }
        [HttpPut("{taskId}/status")]
        public async Task<ActionResult> UpdateIssueStatus(int taskId, [FromBody] EkTaskLogDto updateStatusDto) 
        {
            if (updateStatusDto.Status < 0) 
            { 
                return BadRequest("Invalid status value."); // 400
            }
             
            try
            {
                updateStatusDto.TaskId = taskId;   
                await _issueService.UpdateIssueStatus(updateStatusDto);
                return CreatedAtAction(nameof(GetIssueById), new { id = taskId }, new { id = taskId });// 204
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }
        [HttpPut("{taskId}")]
        public async Task<ActionResult> UpdateIssue(int taskId, [FromBody] IssueUpdateModel updateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(updateModel.Description) || string.IsNullOrEmpty(updateModel.TaskName))
            {
                return BadRequest("Description and TaskName cannot be null or empty.");
            }

            try
            {
                var result = await _issueService.UpdateIssue(taskId, updateModel.Description, updateModel.TaskName, updateModel.Timestamp);
                if (!result)
                {
                    return StatusCode(500, "A problem happened while updating the issue.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPut("{taskId}/delete")]
        public async Task<ActionResult> UpdateIssueIsDeleted(int taskId)
        {
            var result = await _issueService.UpdateIssueIsDeleted(taskId);
            if (!result)
            {
                return BadRequest("Issue not found."); 
            }

            return NoContent(); 
        }

    }
}
