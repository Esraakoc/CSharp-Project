using Microsoft.AspNetCore.Mvc;
using EK.Business.Dto;
using EK.Business.Services.Interfaces;

namespace EK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IEkUserService _ekUserService;

        public UserController(IEkUserService ekUserService)
        { 
            _ekUserService = ekUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _ekUserService.GetUsersAsync();
            var userDtos = users.Select(user => new EkUserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            }).ToList();
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _ekUserService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = new EkUserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };

            return Ok(userDto);
        }
    }
}
