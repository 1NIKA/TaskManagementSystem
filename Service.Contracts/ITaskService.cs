using Shared.DTOs;

namespace Service.Contracts;

public interface ITaskService
{
    Task<TaskDto> GetTaskAsync(int id, bool trackChanges);
    Task<TaskDto> CreateTaskAsync(TaskForCreationDto taskDto, string email);
    Task UpdateTaskAsync(int id, TaskForUpdateDto taskDto, bool trackChanges);
    Task DeleteTaskAsync(int id, bool trackChanges);
}