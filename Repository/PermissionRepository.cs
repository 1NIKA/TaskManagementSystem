using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Repository;

public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
{
    public PermissionRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public async Task<Permission?> GetPermissionAsync(int id, bool trackChanges) =>
        await FindByCondition(permission => permission.Id == id, trackChanges)
            .FirstOrDefaultAsync();

    public async Task CreatePermissionAsync(Permission permission) => await CreateAsync(permission);
}