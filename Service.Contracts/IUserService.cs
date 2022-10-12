using Shared.DTOs;

namespace Service.Contracts;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(int id, bool trackChanges);
    Task<UserDto> CreateUserAsync(UserForCreationDto userDto);
}