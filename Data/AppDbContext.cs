using Microsoft.EntityFrameworkCore;
using Task = TaskManagerAPI.Models.Task;

namespace TaskManagerAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks => Set<Task>();
}