//using TodoApp.Application.CommonInterfaces;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.Task;

namespace TodoApp.Application.Repositories.TaskRepository
{
    public interface ITaskReadOnlyRepository
    {
        Task<ICollection<Domain.Task.Task>> ListAll(Guid userId);
    }
}