namespace TaskManagerAPI.DTOs;

/// <summary>
/// Data Transfer Object used for creating a new task.
/// Only includes the properties necessary for task creation.
/// </summary>
public class CreateTaskDto
{
    /// <summary>
    /// The title or description of the task to be created.
    /// </summary>
    public string Title { get; set; } = string.Empty;
}