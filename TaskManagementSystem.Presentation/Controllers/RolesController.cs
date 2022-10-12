using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;
using TaskManagementSystem.Presentation.ActionFilters;

namespace TaskManagementSystem.Presentation.Controllers;

[Route("api/roles")]
[ApiController]
[Authorize(Roles = "Admin")]
public class RolesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public RolesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("{id:int}", Name = "RoleById")]
    public async Task<IActionResult> GetRole(int id)
    {
        var assignedClient = await _serviceManager.RoleService.GetRoleAsync(id, false);
        return Ok(assignedClient);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateRole([FromBody] RoleForCreationDto roleDto)
    {
        var createdRole = await _serviceManager.RoleService.CreateRoleAsync(roleDto);
        return CreatedAtRoute("RoleById", new {id = createdRole.Id}, createdRole);
    }
}