using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;
using TaskManagementSystem.Presentation.ActionFilters;
using TaskManagementSystem.Presentation.Extensions;

namespace TaskManagementSystem.Presentation.Controllers;

[Route("api/tasks")]
[ApiController]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public TasksController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("{id:int}", Name = "TaskById")]
    [ValidationPermission(Permissions = new [] {"Task_Get"})]
    public async Task<IActionResult> GetTask(int id)
    {
        var assignedClient = await _serviceManager.TaskService.GetTaskAsync(id, false);
        return Ok(assignedClient);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ValidationPermission(Permissions = new [] {"Task_Create"})]
    public async Task<IActionResult> CreateTask([FromBody] TaskForCreationDto taskDto)
    {
        var creatorUserEmail = User.GetClaimValue(ClaimTypes.Email);
        
        var createdTask = await _serviceManager.TaskService.CreateTaskAsync(taskDto, creatorUserEmail);
        return CreatedAtRoute("TaskById", new {id = createdTask.Id}, createdTask);
    }
    
    [HttpPut("{id:int}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ValidationPermission(Permissions = new [] {"Task_Update"})]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskForUpdateDto taskDto)
    {
        await _serviceManager.TaskService.UpdateTaskAsync(id, taskDto, false);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    [ValidationPermission(Permissions = new [] {"Task_Delete"})]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await _serviceManager.TaskService.DeleteTaskAsync(id, false);
        return NoContent();
    }
}