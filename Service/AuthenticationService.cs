using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DTOs;

namespace Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public AuthenticationService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task<JsonWebToken> Authorize(string email, string privateKey, bool trackChanges)
    {
        var user = await CheckUser(email, trackChanges);
        var (claims, expireTime) = GenerateClaims(user);

        return CreateToken(claims, expireTime, privateKey);
    }
    
    private async Task<User> CheckUser(string email, bool trackChanges)
    {
        var userEntity = await _repositoryManager.User.GetUserByEmailAsync(email, trackChanges);
        if (userEntity == null) throw new UserNotFoundException(email);

        return userEntity;
    }

    private static (List<Claim>, string) GenerateClaims(User user)
    {
        var expireTime = DateTime.UtcNow.AddMinutes(1).ToString(CultureInfo.InvariantCulture);
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email ?? ""),
            new(ClaimTypes.Role,  user.Role?.Name ?? ""),
            new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new(ClaimTypes.Expired, expireTime)
        };

        return (claims, expireTime);
    }

    private static JsonWebToken CreateToken(IEnumerable<Claim> claims, string expireTime, string privateKey)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: Convert.ToDateTime(expireTime),
            signingCredentials: signingCredentials);
        
        return new JsonWebToken
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token), 
            ExpiresIn = new DateTimeOffset(Convert.ToDateTime(expireTime)).ToUnixTimeSeconds()
        };
    }
}