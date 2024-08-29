using EK.Business.Dto;
using EK.Business.Services.Interfaces;
using EK.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
 
namespace EK.Api.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase  
    {
        private readonly IMailService _mailService;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly AppDbContext _context;
        public PasswordController(IMailService mailService, IPasswordService passwordService, ITokenService tokenService, AppDbContext context)
        {
            _mailService = mailService;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _context = context;
        }
         
        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] string email)
        { 
            var user = await _passwordService.GetUserByEmailAsync(email); 
            if (user == null)
            {
                return NotFound("User not found"); 
            }

            string resetToken = _tokenService.GeneratePasswordResetToken(user);
            var resetLink = $"http://localhost:3000/password-reset/{resetToken}";

            await _mailService.SendPasswordResetEmailAsync(user.Email, resetLink);

            return Ok("Password reset email sent");
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ResetPasswordRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                return BadRequest("Passwords do not match");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                return BadRequest("Invalid email address.");
            }

            if (string.IsNullOrEmpty(model.NewPassword))
            {
                return BadRequest("The new password cannot be empty");
            }

            try
            { 
                var user = await _context.EkUsers.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);

                bool result = await _passwordService.UpdatePasswordAsync(user.UserId.ToString(), hashedPassword);
                if (!result)
                {
                    return StatusCode(500, "An error occurred while updating the password");
                }

                return Ok("Password has been updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
