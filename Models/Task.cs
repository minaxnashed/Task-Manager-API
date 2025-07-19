namespace TaskManagerAPI.Models;

/// <summary>
/// Represents a task item in the system.
/// This is the main model used to store task data in the database.
/// </summary>
public class Task
{
    /// <summary>
    /// Unique identifier for the task.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title or description of the task.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the task is completed.
    /// </summary>
    public bool IsCompleted { get; set; } = false;
}