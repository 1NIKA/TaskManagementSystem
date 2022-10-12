using Entities.Models;
using Task = System.Threading.Tasks.Task;

namespace Contracts;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string? email, bool trackChanges);
    Task<User?> GetUserByIdAsync(int id, bool trackChanges);
    Task CreateUserAsync(User user);
}