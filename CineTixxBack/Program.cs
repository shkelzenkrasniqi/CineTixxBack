using CineTixx.Core;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;
using CineTixx.Core.Services;
using CineTixx.Persistence;
using CineTixx.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

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
