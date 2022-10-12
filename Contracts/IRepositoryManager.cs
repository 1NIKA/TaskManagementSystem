namespace Contracts;

public interface IRepositoryManager
{
    IUserRepository User { get; }
    ITaskRepository Task { get; }
    IRoleRepository Role { get; }
    IPermissionRepository Permission { get; }
    Task SaveAsync();
}