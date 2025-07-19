using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using Task = TaskManagerAPI.Models.Task;

namespace TaskManagerAPI.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;
    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Task>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Task> CreateAsync(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Task?> ToggleCompletedAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return null;

        task.IsCompleted = !task.IsCompleted;
        await _context.SaveChangesAsync();
        return task;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
}