using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Repositories;
using Task = TaskManagerAPI.Models.Task;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=tasks.db")); // or UseInMemoryDatabase("TaskDb")

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!!");

app.MapGet("/tasks", async (ITaskRepository repo) =>
{
    var tasks = await repo.GetAllAsync();
    return Results.Ok(tasks);
});

app.MapPost("/tasks", async (ITaskRepository repo, CreateTaskDto dto) =>
{
    var task = new Task { Title = dto.Title };
    var created = await repo.CreateAsync(task);
    return Results.Created($"/tasks/{created.Id}", created);
});

app.MapPut("/tasks/{id}/toggle", async (ITaskRepository repo, int id) =>
{
    var updated = await repo.ToggleCompletedAsync(id);
    return updated is null ? Results.NotFound() : Results.Ok(updated);
});

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // This creates the database and the schema if it doesn't exist
}


app.Run();