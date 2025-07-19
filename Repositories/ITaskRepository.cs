using Task = TaskManagerAPI.Models.Task;

namespace TaskManagerAPI.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<Task>> GetAllAsync();
    Task<Task> CreateAsync(Task task);
    Task<Task?> ToggleCompletedAsync(int id);
    Task<bool> DeleteAsync(int id);
}