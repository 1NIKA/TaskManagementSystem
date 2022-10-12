using Shared.DTOs;

namespace Service.Contracts;

public interface IRoleService
{
    Task<RoleDto> GetRoleAsync(int id, bool trackChanges);
    Task<RoleDto> GetRoleByNameAsync(string name, bool trackChanges);
    Task<RoleDto> CreateRoleAsync(RoleForCreationDto roleDto);
}