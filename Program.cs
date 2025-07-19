using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// -------------------------------------------
// Configure Services (Dependency Injection)
// -------------------------------------------

// Register EF Core with SQLite (can be swapped with InMemory DB for testing)
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=tasks.db")); // UseInMemoryDatabase("TaskDb") for testing

// Register the TaskRepository as the implementation for ITaskRepository
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Enable support for MVC-style controllers
builder.Services.AddControllers();

// Add Swagger for API documentation/testing UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable Cross-Origin Resource Sharing (CORS) for any origin, header, and method
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// -------------------------------------------
// Configure Middleware & HTTP Pipeline
// -------------------------------------------

var app = builder.Build();

// Enable CORS middleware
app.UseCors();

// Enable Swagger middleware (API docs and UI)
app.UseSwagger();
app.UseSwaggerUI();

// Simple test endpoint
app.MapGet("/", () => "Hello World!!");

// Map controller endpoints (e.g., /tasks from TasksController)
app.MapControllers();

// -------------------------------------------
// Ensure database is created at startup
// -------------------------------------------
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // Creates the database and tables if they don't exist
}

// Start the application
app.Run();