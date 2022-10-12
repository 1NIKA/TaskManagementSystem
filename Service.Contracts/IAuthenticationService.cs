using Shared.DTOs;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<JsonWebToken> Authorize(string email, string privateKey, bool trackChanges);
}