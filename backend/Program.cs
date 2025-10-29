using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Api.Models;
using OnlineQuiz.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Database
builder.Services.AddDbContext<QuizDbContext>(options =>
    options.UseSqlite("Data Source=quiz.db"));

var app = builder.Build();

// Enable CORS
app.UseCors("AllowAll");

// Enable Swagger in both Development and Production
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Quiz API v1");
    c.RoutePrefix = "swagger"; // Swagger at /swagger
});

// Enable static files (optional)
app.UseStaticFiles();

// Routing
app.UseRouting();
app.MapControllers();

app.Run();
