using CarManagement.Application.Commands.Validators;
using CarManagement.Domain.Interfaces.Repositories;
using CarManagement.Infrastructure.Data;
using CarManagement.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()  // Agrega la(s) URL(s) permitidas
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblies(Assembly.Load("CarManagement.Application")));
//builder.Services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<CreateCarCommandValidator>());
builder.Services.AddDbContext<CarsManagementDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("CarsManagementDB")));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<CreateCarCommandValidator>();
builder.Services.AddScoped<UpdateCarCommandValidator>();
builder.Services.AddScoped<DeleteCarCommandValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
