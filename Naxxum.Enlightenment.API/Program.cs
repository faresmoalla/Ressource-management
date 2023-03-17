using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Nasxxum.Enlightenment.API.Extensions;
using Nasxxum.Enlightenment.API.Middlewares;
using Naxxum.Enlightenment.Application.Abstractions;
using Naxxum.Enlightenment.Application.Extensions;
using Naxxum.Enlightenment.Infrastructure.Data;
using Naxxum.Enlightenment.Infrastructure.Extensions;
using Naxxum.Enlightenment.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<AppDbContext>(
    builder.Configuration.GetConnectionString("DefaultConnection"), null,
    optionsBuilder => optionsBuilder.EnableSensitiveDataLogging(builder.Environment.IsDevelopment()));
// Add services to the container.
builder.Services
    .AddApiServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Naxxum.Enlightenmenet.API")));
//builder.Services.AddScoped<IMovieRepsitory, MovieRepository>();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
await AppDbContextSeeder.SeedAsync(app.Services);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();