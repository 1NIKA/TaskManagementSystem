using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Repository;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public async Task<Role?> GetRoleAsync(int id, bool trackChanges) =>
        await FindByCondition(role => role.Id == id, trackChanges)
            .Include(role => role.Permissions)
            .FirstOrDefaultAsync();

    public async Task<Role?> GetRoleByNameAsync(string name, bool trackChanges) =>
        await FindByCondition(role => role.Name == name, trackChanges)
            .Include(role => role.Permissions)
            .FirstOrDefaultAsync();

    public async Task CreateRoleAsync(Role role) => await CreateAsync(role);
}