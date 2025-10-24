using InventoryMSApi.Data;
using InventoryMSApi.Jobs;
using InventoryMSApi.Notifications;
using InventoryMSApi.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

// 🔹 Register Repositories
builder.Services.AddScoped<ProductRepository, ProductRepository>();
builder.Services.AddScoped<NotificationRepository, NotificationRepository>();

// 🔹 Register Services
builder.Services.AddScoped<ProductService, ProductService>();
builder.Services.AddHostedService<BackgroundJob>();
builder.Services.AddScoped<Notification>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
