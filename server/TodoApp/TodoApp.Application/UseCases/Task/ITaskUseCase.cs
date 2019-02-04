using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Application.UseCases.Task
{
    public interface ITaskUseCase
    {
        Task<TaskOutput> Create(Guid userId, TaskInput task);
        Task<bool> Delete(Guid userId, Guid taskId);
        Task<TaskOutput> Update(Guid userId, TaskInput task);
        Task<bool> MarkAsDone(Guid userId, TaskInput task);
        Task<ICollection<TaskOutput>> ListAll(Guid userId);
    }
}