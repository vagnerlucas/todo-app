using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application;
using TodoApp.Application.Repositories.TaskRepository;
using TodoApp.Domain.User;
using Task = TodoApp.Domain.Task.Task;

namespace TodoApp.Infrastructure.InMemory.Repositories
{
    public class TaskWriteOnlyRepository : ITaskWriteOnlyRepository
    {
        private readonly Context _context;

        public TaskWriteOnlyRepository(Context context)
        {
            _context = context;
        }
        public Task<bool> Create(Guid userId, Task task)
        {
            task.Id = Guid.NewGuid();
            task.CreatedAt = DateTime.Now;

            var existingUser = GetUser(userId);

            existingUser.Tasks.Add(task);

            return System.Threading.Tasks.Task.FromResult(true);
        }

        public Task<bool> Delete(Guid userId, Task task)
        {
            var existingUser = GetUser(userId);

            var toRemove = existingUser.Tasks.FirstOrDefault(w => w.Id == task.Id);

            var result = existingUser.Tasks.Remove(toRemove);

            return System.Threading.Tasks.Task.FromResult(result);
        }

        public Task<bool> Update(Guid userId, Task task)
        {
            var existingUser = GetUser(userId);

            var existingTask = existingUser.Tasks.FirstOrDefault(w => w.Id == task.Id);

            if (existingTask is null)
                return System.Threading.Tasks.Task.FromResult(false);

            existingTask.Name = task.Name;
            return System.Threading.Tasks.Task.FromResult(true);
        }

        public Task<bool> MarkAsDone(Guid userId, Task task)
        {
            var existingUser = GetUser(userId);

            var existingTask = existingUser.Tasks.FirstOrDefault(w => w.Id == task.Id);

            if (existingTask is null)
                return System.Threading.Tasks.Task.FromResult(false);

            existingTask.Done = true;
            existingTask.DoneAt = DateTime.Now;

            return System.Threading.Tasks.Task.FromResult(true);
        }

        private User GetUser(Guid userId)
        {
            var existingUser = _context.Users.FirstOrDefault(user => user.Id == userId);

            if (existingUser is null)
                throw new UserNotFoundException("User not found");

            return existingUser;
        }
    }
}