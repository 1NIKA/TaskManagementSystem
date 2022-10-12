using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;
using TaskManagementSystem.Presentation.ActionFilters;

namespace TaskManagementSystem.Presentation.Controllers;

[Route("api/users")]
[ApiController]
[Authorize(Roles = "Admin")]
public class UsersController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public UsersController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet("{id:int}", Name = "UserById")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _serviceManager.UserService.GetUserByIdAsync(id, false);
        return Ok(user);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateUser([FromBody] UserForCreationDto userDto)
    {
        var createdUser = await _serviceManager.UserService.CreateUserAsync(userDto);
        return CreatedAtRoute("UserById", new {id = createdUser.Id}, createdUser);
    }
}