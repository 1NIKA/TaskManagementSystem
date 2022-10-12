using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DTOs;

namespace Service;

public class PermissionService : IPermissionService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public PermissionService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }
    
    public async Task<PermissionDto> GetPermissionAsync(int id, bool trackChanges)
    {
        var permission = await _repositoryManager.Permission.GetPermissionAsync(id, trackChanges);
        if (permission is null) throw new PermissionNotFoundException(id);

        return _mapper.Map<PermissionDto>(permission);
    }

    public async Task<PermissionDto> CreatePermissionAsync(PermissionForCreationDto permissionDto)
    {
        var role = await _repositoryManager.Role.GetRoleAsync(permissionDto.RoleId, false);
        if (role is null) throw new RoleNotFoundException(permissionDto.RoleId);
        
        var permission = _mapper.Map<Permission>(permissionDto);
        await _repositoryManager.Permission.CreatePermissionAsync(permission);
        
        await _repositoryManager.SaveAsync();
        return _mapper.Map<PermissionDto>(permission);
    }
}