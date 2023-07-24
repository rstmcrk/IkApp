using IkApp.Infrastructure;
using IkApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using IkApp.Services.AutoMapper;
using NLog;
using IkApp.Application.Services;
using StackExchange.Redis;
using Microsoft.AspNetCore.Identity;
using IkApp.Domain.Entities;
using IkApp.Services.Services;

var builder = WebApplication.CreateBuilder(args);

var filepath ="nlog.config";
LogManager.LoadConfiguration(filepath);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityOptions();
builder.Services.Lifetime();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);



var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
