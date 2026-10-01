using ClientService.DataAccess.ContextDb;
using ClientService.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using ClientService.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SportHallContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICoachRepository, CoachRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
