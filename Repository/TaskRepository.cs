using Contracts;
using Microsoft.EntityFrameworkCore;
using Task = Entities.Models.Task;

namespace Repository;

public class TaskRepository : RepositoryBase<Task>, ITaskRepository
{
    public TaskRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

    public async Task<Task?> GetTaskAsync(int id, bool trackChanges) =>
        await FindByCondition(task => task.Id == id, trackChanges).FirstOrDefaultAsync();

    public async System.Threading.Tasks.Task CreateTaskAsync(Task task) => await CreateAsync(task);

    public void DeleteTask(Task task) => Delete(task);
}