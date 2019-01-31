using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Application.Repositories.TaskRepository;
using TodoApp.Domain.Task;

namespace TodoApp.Infrastructure.InMemory.Repositories
{
    public class TaskReadOnlyRepository : BaseRepository, ITaskReadOnlyRepository
    {
        public System.Threading.Tasks.Task<ICollection<Task>> ListAll()
        {
            var data = _context.Tasks.ToList();
            return System.Threading.Tasks.Task.FromResult<ICollection<Task>>(data);
        }
    }
}