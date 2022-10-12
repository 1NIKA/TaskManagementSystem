using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DTOs;

namespace Service;

public class RoleService : IRoleService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RoleService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task<RoleDto> GetRoleAsync(int id, bool trackChanges)
    {
        var role = await _repositoryManager.Role.GetRoleAsync(id, trackChanges);
        if (role is null) throw new RoleNotFoundException(id);

        return _mapper.Map<RoleDto>(role);
    }

    public async Task<RoleDto> GetRoleByNameAsync(string name, bool trackChanges)
    {
        var role = await _repositoryManager.Role.GetRoleByNameAsync(name, trackChanges);
        if (role is null) throw new RoleNotFoundException(name);

        return _mapper.Map<RoleDto>(role);
    }

    public async Task<RoleDto> CreateRoleAsync(RoleForCreationDto roleDto)
    {
        var role = _mapper.Map<Role>(roleDto);
        await _repositoryManager.Role.CreateRoleAsync(role);
        
        await _repositoryManager.SaveAsync();
        return _mapper.Map<RoleDto>(role);
    }
}