using Microsoft.EntityFrameworkCore;
using Task = TaskManagerAPI.Models.Task;

namespace TaskManagerAPI.Data;

/// <summary>
/// Represents the application's database context.
/// It provides access to the Task table and manages database operations using Entity Framework Core.
/// </summary>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Represents the Tasks table in the database.
    /// </summary>
    public DbSet<Task> Tasks => Set<Task>();
}