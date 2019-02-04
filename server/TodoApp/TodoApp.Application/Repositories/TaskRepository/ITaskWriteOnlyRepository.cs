using System;
using System.Threading.Tasks;
using TodoApp.Domain.Task;
using Task = TodoApp.Domain.Task.Task;

namespace TodoApp.Application.Repositories.TaskRepository
{
    /// <summary>
    /// Task write only repository service
    /// </summary>
    public interface ITaskWriteOnlyRepository
    {
        /// <summary>
        /// Creates a task for user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="task">Domain Task model</param>
        /// <returns>Created task</returns>
        Task<Task> Create(Guid userId, Domain.Task.Task task);
        /// <summary>
        /// Deletes an user task by Id
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="taskId">Task Id</param>
        /// <returns>Boolean result of the operation</returns>
        Task<bool> Delete(Guid userId, Guid taskId);
        /// <summary>
        /// Updates an user task
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="task">Domain Task model</param>
        /// <returns>Updated task</returns>
        Task<Task> Update(Guid userId, Domain.Task.Task task);
        /// <summary>
        /// Marks a task as done
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="task">Domain Task model</param>
        /// <returns>Boolean result of the operation</returns>
        Task<bool> MarkAsDone(Guid userId, Domain.Task.Task task);
    }
}