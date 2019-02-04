using System;
using System.Threading.Tasks;
using TodoApp.Domain.Task;
using Task = TodoApp.Domain.Task.Task;

namespace TodoApp.Application.Repositories.TaskRepository
{
    public interface ITaskWriteOnlyRepository
    {
        Task<Task> Create(Guid userId, Domain.Task.Task task);
        Task<bool> Delete(Guid userId, Guid taskId);
        Task<Task> Update(Guid userId, Domain.Task.Task task);
        Task<bool> MarkAsDone(Guid userId, Domain.Task.Task task);
    }
}