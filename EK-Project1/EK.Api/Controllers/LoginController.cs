﻿using Microsoft.AspNetCore.Mvc;
using EK.Business.Dto;
using EK.Business.Services.Interfaces;

namespace EK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService) 
        {
            _loginService = loginService;
        }
         
        [HttpPost] 
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto) 
        {
            var userDto = await _loginService.LoginAsync(loginDto);
            if (userDto == null) 
            {
                return Unauthorized("Invalid user credentials"); 
            }
            return Ok(userDto);
        }
    }
}
