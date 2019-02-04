using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Application.UseCases.Task
{
    /// <summary>
    /// Task service
    /// </summary>
    public interface ITaskUseCase
    {
        /// <summary>
        /// Creates user's task
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="task">Task model</param>
        /// <returns>Created task</returns>
        Task<TaskOutput> Create(Guid userId, TaskInput task);
        /// <summary>
        /// Deletes user's task by using task's id
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="taskId">Task Id</param>
        /// <returns>Boolean of the operation</returns>
        Task<bool> Delete(Guid userId, Guid taskId);
        /// <summary>
        /// Updates an user's task
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="task">Task model</param>
        /// <returns>Updated task</returns>
        Task<TaskOutput> Update(Guid userId, TaskInput task);
        /// <summary>
        /// Marks an user's task as done
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="task">Task model</param>
        /// <returns>Boolean of the operation</returns>
        Task<bool> MarkAsDone(Guid userId, TaskInput task);
        /// <summary>
        /// Lists all task for an user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of the user's tasks</returns>
        Task<ICollection<TaskOutput>> ListAll(Guid userId);
    }
}