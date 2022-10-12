using Shared.DTOs;

namespace Service.Contracts;

public interface IPermissionService
{
    Task<PermissionDto> GetPermissionAsync(int id, bool trackChanges);
    Task<PermissionDto> CreatePermissionAsync(PermissionForCreationDto permissionDto);
}