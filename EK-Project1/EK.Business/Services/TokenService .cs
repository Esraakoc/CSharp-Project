using EK.Business.Services.Interfaces;
using EK.Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using EK.DataAccess;

namespace EK.Business.Services 
{ 
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expirationMinutes;

        private static readonly ConcurrentDictionary<string, DateTime> InvalidTokens = new ConcurrentDictionary<string, DateTime>();

        public TokenService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
            _secretKey = _configuration["JwtSettings:SecretKey"];
            _issuer = _configuration["JwtSettings:Issuer"];
            _audience = _configuration["JwtSettings:Audience"];
            _expirationMinutes = int.Parse(_configuration["JwtSettings:ExpirationMinutes"]);
        }

        public string GeneratePasswordResetToken(EkUser user)
        {
            try
            {
                //JWT Handler ve (Secret Key) Tanımlamama
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secretKey);
                //Token Tanımlayıcı Oluşturma
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("ResetToken", Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(_expirationMinutes), //geçerlilik süresi
                    Issuer = _issuer,//tokenı kimin oluşturduğu
                    Audience = _audience, //kim için geçerli olduğu
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) //güvenlik
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to generate password reset token.", ex);
            }
        }

        //token geçersiz kılmak amacıyla
        public async Task<EkUser> GetUserByResetTokenAsync(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secretKey);

                if (tokenHandler.ReadToken(token) is JwtSecurityToken jwtToken)
                {
                    if (jwtToken.ValidTo <= DateTime.UtcNow)
                    {
                        throw new SecurityTokenExpiredException("Token has expired.");
                    }

                    var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                    if (string.IsNullOrEmpty(userId))
                    {
                        throw new InvalidOperationException("Invalid token claims.");
                    }

                    var user = await _context.EkUsers
                        .FirstOrDefaultAsync(u => u.UserId.ToString() == userId); 

                    return user ?? throw new InvalidOperationException("User not found or token is invalid.");
                }
                else
                {
                    throw new InvalidOperationException("Invalid token.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to retrieve user by reset token.", ex);
            }
        }


        public static Task RevokeTokenAsync(string token)
        {
            InvalidTokens[token] = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
