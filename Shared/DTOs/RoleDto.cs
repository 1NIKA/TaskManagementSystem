namespace Shared.DTOs;

public record RoleDto(int Id, 
    string? Name, 
    string? Description, 
    DateTime CratedAt,
    IEnumerable<PermissionDto> Permissions);