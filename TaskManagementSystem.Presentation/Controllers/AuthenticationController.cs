using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DTOs;
using TaskManagementSystem.Presentation.ActionFilters;

namespace TaskManagementSystem.Presentation.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly IConfiguration _configuration;

    public AuthenticationController(IServiceManager serviceManager, IConfiguration configuration)
    {
        _serviceManager = serviceManager;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("token")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] AuthorizeDto authorizeDto)
    {
        var jwt = await _serviceManager.AuthenticationService
            .Authorize(authorizeDto.Email!, _configuration.GetSection("JWT:Secret").Value, trackChanges: false);
        
        return Ok(jwt);
    }
}