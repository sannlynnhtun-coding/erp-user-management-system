using System.Configuration;
using ERP_user_management_sys.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddDbContext<UserManagementDBContext>(
    options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")); },
    ServiceLifetime.Transient, ServiceLifetime.Transient);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(options =>
    options.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();