using Entities.Models;

namespace Contracts;

public interface IRoleRepository
{
    Task<Role?> GetRoleAsync(int id, bool trackChanges);
    Task<Role?> GetRoleByNameAsync(string name, bool trackChanges);
    System.Threading.Tasks.Task CreateRoleAsync(Role role);
}