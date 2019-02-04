//using TodoApp.Application.CommonInterfaces;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.Task;

namespace TodoApp.Application.Repositories.TaskRepository
{
    /// <summary>
    /// Task read only repository service
    /// </summary>
    public interface ITaskReadOnlyRepository
    {
        /// <summary>
        /// List all tasks from application's user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of an user tasks</returns>
        Task<ICollection<Domain.Task.Task>> ListAll(Guid userId);
    }
}