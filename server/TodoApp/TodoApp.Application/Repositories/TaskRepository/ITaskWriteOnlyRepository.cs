using System;
using System.Threading.Tasks;
using TodoApp.Domain.Task;

namespace TodoApp.Application.Repositories.TaskRepository
{
    public interface ITaskWriteOnlyRepository
    {
        Task<bool> Create(Domain.Task.Task task);
        Task<bool> Delete(Domain.Task.Task task);
        Task<bool> DeleteById(Guid id);
        Task<bool> Update(Domain.Task.Task task);
        Task<bool> MarkAsDone(Domain.Task.Task task);
    }
}