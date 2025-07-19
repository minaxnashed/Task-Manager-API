using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Repositories;
using Task = TaskManagerAPI.Models.Task;

namespace TaskManagerAPI.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repo;

    public TasksController(ITaskRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _repo.GetAllAsync();
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
    {
        var task = new Task { Title = dto.Title };
        var created = await _repo.CreateAsync(task);
        return CreatedAtAction(nameof(GetAllTasks), new { id = created.Id }, created);
    }

    [HttpPut("{id}/toggle")]
    public async Task<IActionResult> ToggleTaskCompleted(int id)
    {
        var updated = await _repo.ToggleCompletedAsync(id);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var deleted = await _repo.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}