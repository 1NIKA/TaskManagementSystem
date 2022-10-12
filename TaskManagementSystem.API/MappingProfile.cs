using AutoMapper;
using Entities.Models;
using Shared.DTOs;
using File = Entities.Models.File;
using Task = Entities.Models.Task;

namespace TaskManagementSystem.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Task, TaskDto>();
        CreateMap<File, FileDto>();
        CreateMap<Role, RoleDto>();
        CreateMap<Permission, PermissionDto>();
        CreateMap<User, UserDto>();
        CreateMap<TaskForCreationDto, Task>();
        CreateMap<RoleForCreationDto, Role>();
        CreateMap<PermissionForCreationDto, Permission>();
        CreateMap<FileForCreationDto, File>();
        CreateMap<UserForCreationDto, User>();
    }
}