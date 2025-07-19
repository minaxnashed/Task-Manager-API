using Task = TaskManagerAPI.Models.Task;

namespace TaskManagerAPI.Repositories;

/// <summary>
/// Interface for task-related data access operations.
/// Defines the contract for interacting with the task storage mechanism (e.g., a database).
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Retrieves all tasks from the data source.
    /// </summary>
    /// <returns>A collection of all tasks.</returns>
    Task<IEnumerable<Task>> GetAllAsync();

    /// <summary>
    /// Creates a new task in the data source.
    /// </summary>
    /// <param name="task">The task to create.</param>
    /// <returns>The newly created task, including its generated ID.</returns>
    Task<Task> CreateAsync(Task task);

    /// <summary>
    /// Toggles the completion status of a task.
    /// </summary>
    /// <param name="id">The ID of the task to toggle.</param>
    /// <returns>The updated task if found, otherwise null.</returns>
    Task<Task?> ToggleCompletedAsync(int id);

    /// <summary>
    /// Deletes a task by its ID.
    /// </summary>
    /// <param name="id">The ID of the task to delete.</param>
    /// <returns>True if deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteAsync(int id);
}