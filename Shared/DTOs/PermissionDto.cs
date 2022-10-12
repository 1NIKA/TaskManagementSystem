namespace Shared.DTOs;

public record PermissionDto(int Id,
    int RoleId,
    string? Name, 
    string? Description, 
    DateTime CratedAt);