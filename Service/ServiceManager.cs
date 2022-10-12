using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthenticationService> _authenticationService;
    private readonly Lazy<ITaskService> _taskService;
    private readonly Lazy<IRoleService> _roleService;
    private readonly Lazy<IPermissionService> _permissionService;
    private readonly Lazy<IUserService> _userService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(repositoryManager, loggerManager, mapper));
        _taskService = new Lazy<ITaskService>(() =>
            new TaskService(repositoryManager, loggerManager, mapper));
        _roleService = new Lazy<IRoleService>(() =>
            new RoleService(repositoryManager, loggerManager, mapper));
        _permissionService = new Lazy<IPermissionService>(() =>
            new PermissionService(repositoryManager, loggerManager, mapper));
        _userService = new Lazy<IUserService>(() =>
            new UserService(repositoryManager, loggerManager, mapper));
    }

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
    public ITaskService TaskService => _taskService.Value;
    public IRoleService RoleService => _roleService.Value;
    public IPermissionService PermissionService => _permissionService.Value;
    public IUserService UserService => _userService.Value;
}