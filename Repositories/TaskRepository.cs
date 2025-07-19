using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using Task = TaskManagerAPI.Models.Task;

namespace TaskManagerAPI.Repositories;

/// <summary>
/// Implementation of the ITaskRepository interface.
/// Handles data access operations for Task entities using Entity Framework Core.
/// </summary>
public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the TaskRepository class.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all tasks from the database.
    /// </summary>
    /// <returns>A list of all tasks.</returns>
    public async Task<IEnumerable<Task>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    /// <summary>
    /// Adds a new task to the database.
    /// </summary>
    /// <param name="task">The task to add.</param>
    /// <returns>The created task with an assigned ID.</returns>
    public async Task<Task> CreateAsync(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    /// <summary>
    /// Toggles the completion status of a task by ID.
    /// </summary>
    /// <param name="id">The ID of the task to toggle.</param>
    /// <returns>The updated task if found; otherwise, null.</returns>
    public async Task<Task?> ToggleCompletedAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return null;

        task.IsCompleted = !task.IsCompleted;
        await _context.SaveChangesAsync();
        return task;
    }

    /// <summary>
    /// Deletes a task by ID.
    /// </summary>
    /// <param name="id">The ID of the task to delete.</param>
    /// <returns>True if the task was deleted; otherwise, false.</returns>
    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
}
