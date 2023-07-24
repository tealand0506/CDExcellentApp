using CDExcellent.Models;
using CDExcellent.Repositories;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CDExcellent.Middlewares;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CDE_Dbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
}
);
builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromMinutes(5));


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    IConfiguration configuration = builder.Configuration;
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "")),
        ClockSkew = TimeSpan.Zero
    };
});


builder.Services.AddAuthorization(option => {
    option.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    option.AddPolicy("Manager", policy => policy.RequireRole("Admin","Managser", "VPCD"));
    option.AddPolicy("BM", policy => policy.RequireRole("Admin","Managser", "VPCD"));
    option.AddPolicy("BAM", policy => policy.RequireRole("Admin","Managser", "VPCD", "BAM"));
    option.AddPolicy("CE", policy => policy.RequireRole("Admin","Managser", "VPCD", "CE"));
    option.AddPolicy("ASM", policy => policy.RequireRole("Admin","Managser", "VPCD", "ASM"));
    option.AddPolicy("Using", policy => policy.RequireRole("Admin", "Managser", "VPCD", "BAM", "CE","ASM"));
});


builder.Services.AddScoped<IChucVuRepository, ChucVuRepository>()
    .AddScoped<ICongViecRepository, CongViecRepository>()
    .AddScoped<IKhaoSatRepository, KhaoSatRepository>()
    .AddScoped<IKhuVucRepository, KhuVucRepository>()
    .AddScoped<ILichTrinhRepository, LichTrinhRepository>()
    .AddScoped<INPPRepository, NPPRepository>()
    .AddScoped<ITaiKhoanRepository, TaiKhoanRepository>()
    .AddScoped<IThongBaoRepository, ThongBaoRepository>()
    .AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}
app.UseStaticFiles();
app.UseHttpsRedirection();
    

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
