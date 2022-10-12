using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<ITaskRepository> _taskRepository;
    private readonly Lazy<IRoleRepository> _roleRepository;
    private readonly Lazy<IPermissionRepository> _permissionRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
        _taskRepository = new Lazy<ITaskRepository>(() => new TaskRepository(repositoryContext));
        _roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(repositoryContext));
        _permissionRepository = new Lazy<IPermissionRepository>(() => new PermissionRepository(repositoryContext));
    }

    public IUserRepository User => _userRepository.Value;
    public ITaskRepository Task => _taskRepository.Value;
    public IRoleRepository Role => _roleRepository.Value;
    public IPermissionRepository Permission => _permissionRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}