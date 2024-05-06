using CineTixx.Core;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;
using CineTixx.Core.Services;
using CineTixx.Persistence;
using CineTixx.Persistence.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


RepositoryDIConfiguration.Configure(builder.Services);
ServicesDIConfiguration.Configure(builder.Services, builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))

    };
});
//await RoleManagerUtil.CreateRoles(builder.Services.BuildServiceProvider());  For when we add the roles.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.MapControllers();

app.Run();
