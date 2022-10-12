using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;
using TaskManagementSystem.Presentation.ActionFilters;

namespace TaskManagementSystem.Presentation.Controllers;

[Route("api/permissions")]
[ApiController]
[Authorize(Roles = "Admin")]
public class PermissionsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PermissionsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("{id:int}", Name = "PermissionById")]
    public async Task<IActionResult> GetPermission(int id)
    {
        var assignedClient = await _serviceManager.PermissionService.GetPermissionAsync(id, false);
        return Ok(assignedClient);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreatePermission([FromBody] PermissionForCreationDto permissionDto)
    {
        var createdPermission = await _serviceManager.PermissionService.CreatePermissionAsync(permissionDto);
        return CreatedAtRoute("PermissionById", new {id = createdPermission.Id}, createdPermission);
    }
}