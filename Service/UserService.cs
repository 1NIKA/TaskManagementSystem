using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DTOs;

namespace Service;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }
    
    public async Task<UserDto> GetUserByIdAsync(int id, bool trackChanges)
    {
        var user = await _repositoryManager.User.GetUserByIdAsync(id, trackChanges);
        if (user is null) throw new UserNotFoundException(id);

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> CreateUserAsync(UserForCreationDto userDto)
    {
        var role = await _repositoryManager.Role.GetRoleAsync(userDto.RoleId, false);
        if (role is null) throw new RoleNotFoundException(userDto.RoleId);
        
        var user = _mapper.Map<User>(userDto);
        await _repositoryManager.User.CreateUserAsync(user);
        
        await _repositoryManager.SaveAsync();
        return _mapper.Map<UserDto>(user);
    }
}