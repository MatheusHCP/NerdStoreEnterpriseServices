using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NSE.Identidade.API.Data;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = "Server=localhost;Port=3307;Database=NerdStoreEnterpriseDB;Uid=root;Pwd=12345678Ka@";

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString))
);

builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();

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

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
