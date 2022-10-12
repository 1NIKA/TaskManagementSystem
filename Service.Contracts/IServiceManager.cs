namespace Service.Contracts;

public interface IServiceManager
{
    IAuthenticationService AuthenticationService { get; }
    ITaskService TaskService { get; }
    IRoleService RoleService { get; }
    IPermissionService PermissionService { get; }
    IUserService UserService { get; }
}