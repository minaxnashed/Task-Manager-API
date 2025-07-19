using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Repositories;
using Task = TaskManagerAPI.Models.Task;

namespace TaskManagerAPI.Controllers;

// This controller handles all HTTP endpoints related to "Task" management
[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repo;

    // Constructor injection of the task repository
    public TasksController(ITaskRepository repo)
    {
        _repo = repo;
    }

    // GET /tasks
    // Returns a list of all tasks
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _repo.GetAllAsync();
        return Ok(tasks);
    }

    // POST /tasks
    // Creates a new task from the incoming DTO
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
    {
        var task = new Task { Title = dto.Title };
        var created = await _repo.CreateAsync(task);
        return CreatedAtAction(nameof(GetAllTasks), new { id = created.Id }, created);
    }

    // PUT /tasks/{id}/toggle
    // Toggles the 'Completed' status of a task
    [HttpPut("{id}/toggle")]
    public async Task<IActionResult> ToggleTaskCompleted(int id)
    {
        var updated = await _repo.ToggleCompletedAsync(id);
        return updated is null ? NotFound() : Ok(updated);
    }

    // DELETE /tasks/{id}
    // Deletes the task with the specified ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var deleted = await _repo.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}