using Microsoft.AspNetCore.Mvc;
using EK.Business.Dto;
using EK.Entities.Models;
using EK.DataAccess;
using EK.Business.Services;
using EK.Business.Services.Interfaces;

namespace EK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase 
    {
        private readonly IEkUserRoleService _userRoleService;

        private readonly AppDbContext _context;
         
        public UserRolesController( AppDbContext context, IEkUserRoleService userRoleService)
        {
            _context = context;
            _userRoleService = userRoleService;
        }
         
        [HttpGet("with-role-names")]
        public async Task<ActionResult<List<UserRoleWithRoleName>>> GetUserRolesWithRoleNames()
        {
            var roles = await _context.GetUserRolesWithRoleNamesAsync();
            return Ok(roles);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserRole([FromBody] UserRoleDto userRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userRoleService.AddUserRoleAsync(userRoleDto);
                return Ok("User role added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
