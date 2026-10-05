using AutoMapper;
using Day19_AutoMapper_Serilog.Data;
using Day19_AutoMapper_Serilog.Mapping;
using Day19_AutoMapper_Serilog.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// Serilog Configuration
// ----------------------------------------------------

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

// ----------------------------------------------------
// Add Controllers
// ----------------------------------------------------

builder.Services.AddControllers();

// ----------------------------------------------------
// Database
// ----------------------------------------------------

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ----------------------------------------------------
// AutoMapper
// ----------------------------------------------------

builder.Services.AddAutoMapper(typeof(MappingProfile));

// ----------------------------------------------------
// Dependency Injection
// ----------------------------------------------------

builder.Services.AddScoped<IProductService, ProductService>();

// ----------------------------------------------------
// Swagger
// ----------------------------------------------------

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ----------------------------------------------------
// HTTP Request Logging
// ----------------------------------------------------

app.UseSerilogRequestLogging();

// ----------------------------------------------------
// Development
// ----------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ----------------------------------------------------
// Middleware
// ----------------------------------------------------

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();