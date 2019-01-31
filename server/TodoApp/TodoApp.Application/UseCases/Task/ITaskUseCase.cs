using System;
using System.Threading.Tasks;
using TodoApp.Application.CommonInterfaces;

namespace TodoApp.Application.UseCases.Task
{
    public interface ITaskUseCase : IListable<TaskOutput>
    {
        Task<bool> Create(TaskInput task);
        Task<bool> Delete(TaskInput task);
        Task<bool> DeleteById(Guid id);
        Task<bool> Update(TaskInput task);
        Task<bool> MarkAsDone(TaskInput task);
    }
}