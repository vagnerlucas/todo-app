using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Application.Repositories.TaskRepository;
using TodoApp.Domain.Task;

namespace TodoApp.Infrastructure.InMemory.Repositories
{
    public class TaskReadOnlyRepository : ITaskReadOnlyRepository
    {
        private readonly Context _context;

        public TaskReadOnlyRepository(Context context)
        {
            _context = context;
        }

        public System.Threading.Tasks.Task<ICollection<Task>> ListAll(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(w => w.Id == userId);
            var data = user?.Tasks ?? new List<Task>();
            return System.Threading.Tasks.Task.FromResult<ICollection<Task>>(data);
        }
    }
}