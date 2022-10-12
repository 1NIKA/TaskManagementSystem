using Task = Entities.Models.Task;

namespace Contracts;

public interface ITaskRepository
{
    Task<Task?> GetTaskAsync(int id, bool trackChanges);
    System.Threading.Tasks.Task CreateTaskAsync(Task task);
    void DeleteTask(Task task);
}