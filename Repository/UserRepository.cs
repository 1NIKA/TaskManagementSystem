using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public async Task<User?> GetUserByEmailAsync(string? email, bool trackChanges) =>
        await FindByCondition(user => user.Email == email, trackChanges)
            .Include(user => user.Role).ThenInclude(role => role!.Permissions)
            .SingleOrDefaultAsync();

    public async Task<User?> GetUserByIdAsync(int id, bool trackChanges) =>
        await FindByCondition(user => user.Id == id, trackChanges)
            .Include(user => user.Role).ThenInclude(role => role!.Permissions)
            .SingleOrDefaultAsync();

    public async Task CreateUserAsync(User user) => await CreateAsync(user);
}