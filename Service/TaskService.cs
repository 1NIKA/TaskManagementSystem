using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTOs;

namespace Service;

public class TaskService : ITaskService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public TaskService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task<TaskDto> GetTaskAsync(int id, bool trackChanges)
    {
        var task = await _repositoryManager.Task.GetTaskAsync(id, trackChanges);
        if (task is null) throw new TaskNotFoundException(id);

        return _mapper.Map<TaskDto>(task);
    }

    public async Task<TaskDto> CreateTaskAsync(TaskForCreationDto taskDto, string email)
    {
        var creatorUser = await _repositoryManager.User.GetUserByEmailAsync(email, false);
        if (creatorUser is null) throw new UserNotFoundException(email);
        
        var receiverUser = await _repositoryManager.User.GetUserByIdAsync(taskDto.ReceiverUserId, false);
        if (receiverUser is null) throw new UserNotFoundException(taskDto.ReceiverUserId);
        
        var task = _mapper.Map<Entities.Models.Task>(taskDto);
        task.CreatorUserId = creatorUser.Id;
        
        await _repositoryManager.Task.CreateTaskAsync(task);
        
        await _repositoryManager.SaveAsync();
        return _mapper.Map<TaskDto>(task);
    }

    public async Task UpdateTaskAsync(int id, TaskForUpdateDto taskDto, bool trackChanges)
    {
        var taskEntity = await _repositoryManager.Task.GetTaskAsync(id, trackChanges);
        if (taskEntity is null) throw new TaskNotFoundException(id);

        _mapper.Map(taskDto, taskEntity);
        await _repositoryManager.SaveAsync();
    }

    public async Task DeleteTaskAsync(int id, bool trackChanges)
    {
        var taskEntity = await _repositoryManager.Task.GetTaskAsync(id, trackChanges);
        if (taskEntity is null) throw new TaskNotFoundException(id);

        _repositoryManager.Task.DeleteTask(taskEntity);
    }
}