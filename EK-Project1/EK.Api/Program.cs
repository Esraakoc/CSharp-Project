using EK.Api.Configuration; 
using EK.DataAccess;
using AutoMapper;
using EK.Api.Profiles;
using EK.DataAccess.Repositories;
using EK.DataAccess.Repositories.Interfaces;
using EK.Business.Services.Interfaces;
using EK.Business.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using EK.Business.Dto;

var builder = WebApplication.CreateBuilder(args);

// MVC mimarisinin API controllerlarýný ekler
builder.Services.AddControllers();

// CORS'u etkinleþtir
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

if (string.IsNullOrEmpty(jwtSettings.SecretKey) ||
    string.IsNullOrEmpty(jwtSettings.Issuer) ||
    string.IsNullOrEmpty(jwtSettings.Audience))
{
    throw new InvalidOperationException("JWT settings are not configured properly.");
}

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(typeof(EkUserProfile).Assembly);

builder.Services.AddScoped<IEkUserRepository, EkUserRepository>();
builder.Services.AddScoped<IEkUserService, EkUserService>();
builder.Services.AddScoped<IEkIssueRepository, EkIssueRepository>();
builder.Services.AddScoped<IEkIssueService, EkIssueService>();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPasswordService, PasswordService>(); 
builder.Services.AddScoped<IEkTaskLogRepository, EkTaskLogRepository>();
builder.Services.AddScoped<IEkTaskLogService, EkTaskLogService>();
builder.Services.AddScoped<IEkUserRoleRepository, EkUserRoleRepository>();
builder.Services.AddScoped<IEkUserRoleService, EkUserRoleService>();

builder.Services.Configure<EmailConfigurationDto>(builder.Configuration.GetSection("EmailConfiguration"));

builder.Services.AddTransient<MailService>();

builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization(); 

app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
