using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Contracts;
using TaskManagementSystem.Presentation.Extensions;

namespace TaskManagementSystem.Presentation.ActionFilters;

public class ValidationPermissionAttribute : Attribute, IAsyncActionFilter
{
    public string[] Permissions { get; set; } = Array.Empty<string>();
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var role = context.HttpContext.User.GetClaimValue(ClaimTypes.Role);
        var roleService = (IRoleService)context.HttpContext.RequestServices.GetService(typeof(IRoleService))!;

        var roleDto = await roleService.GetRoleByNameAsync(role, false);
        if (!roleDto.Permissions.Any(permission => Permissions.Any(p => p == permission.Name)))
        {
            throw new UnauthorizedAccessException("You have no permission to access this resource.");
        }
        
        if (context.Result == null) await next();
    }
}