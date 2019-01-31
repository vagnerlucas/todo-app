using System;
using System.Threading.Tasks;
using TodoApp.Domain.Task;

namespace TodoApp.Application.Repositories.TaskRepository
{
    public interface ITaskWriteOnlyRepository
    {
        Task<bool> Create(Guid userId, Domain.Task.Task task);
        Task<bool> Delete(Guid userId, Domain.Task.Task task);
        Task<bool> Update(Guid userId, Domain.Task.Task task);
        Task<bool> MarkAsDone(Guid userId, Domain.Task.Task task);
    }
}