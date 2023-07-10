using CDExcellent.Models;
using CDExcellent.Repositories;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CDE_Dbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IChucVuRepository, ChucVuRepository>()
    .AddScoped<IKhuVucRepository, KhuVucRepository>()
    .AddScoped<INPPRepository, NPPRepository>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();

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
