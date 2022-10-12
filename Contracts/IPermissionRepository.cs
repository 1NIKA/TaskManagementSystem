using Entities.Models;

namespace Contracts;

public interface IPermissionRepository
{
    Task<Permission?> GetPermissionAsync(int id, bool trackChanges);
    System.Threading.Tasks.Task CreatePermissionAsync(Permission permission);
}