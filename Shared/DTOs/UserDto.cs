namespace Shared.DTOs;

public record UserDto(
    int Id,
    string? FirstName, 
    string? LastName, 
    string? Email, 
    DateTime CratedAt, 
    RoleDto? Role);