using TodoApp.Application.CommonInterfaces;
using TodoApp.Domain.Task;

namespace TodoApp.Application.Repositories.TaskRepository
{
    public interface ITaskReadOnlyRepository : IListable<Task>
    {
    }
}