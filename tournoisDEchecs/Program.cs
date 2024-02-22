using Be.Khunly.Security;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using tournoisDEchecs.BLL.Infrastructure;
using tournoisDEchecs.BLL.Interfaces;
using tournoisDEchecs.BLL.Services;
using tournoisDEchecs.DAL;
using tournoisDEchecs.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<tournoisDEchecsContext>(b => b.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<TournamentService>();
builder.Services.AddScoped<SecurityService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<JwtManager>();
builder.Services.AddScoped<JwtSecurityTokenHandler>();
builder.Services.AddSingleton(builder.Configuration.GetSection("Jwt").Get<JwtManager.JwtConfig>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
