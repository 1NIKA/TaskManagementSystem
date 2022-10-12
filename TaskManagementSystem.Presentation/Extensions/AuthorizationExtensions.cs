using System.Security.Authentication;
using System.Security.Claims;

namespace TaskManagementSystem.Presentation.Extensions;

public static class AuthorizationExtensions
{
    public static string GetClaimValue(this ClaimsPrincipal user, object value)
    {
        var claim = user.Claims.FirstOrDefault(claim => claim.Type.Equals(value));
        if (claim is null) throw new AuthenticationException("User is not authenticated.");
        
        return claim.Value;
    }
}