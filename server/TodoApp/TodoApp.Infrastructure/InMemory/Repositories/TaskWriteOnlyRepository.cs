using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application;
using TodoApp.Application.Repositories.TaskRepository;
using TodoApp.Application.Repositories.UserRepository;
using TodoApp.Domain.User;
using Task = TodoApp.Domain.Task.Task;

namespace TodoApp.Infrastructure.InMemory.Repositories
{
    public class TaskWriteOnlyRepository : ITaskWriteOnlyRepository
    {
        private readonly Context _context;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public TaskWriteOnlyRepository(Context context, IUserReadOnlyRepository userReadOnlyRepository)
        {
            _context = context;
            _userReadOnlyRepository = userReadOnlyRepository;
        }

        private Task<User> GetUserById(Guid id) => _userReadOnlyRepository.GetUser(id);

        public async Task<Task> Create(Guid userId, Task task)
        {
            task.Id = Guid.NewGuid();
            task.CreatedAt = DateTime.Now;

            var existingUser = await GetUserById(userId);

            existingUser.Tasks.Add(task);

            return task;
        }

        public async Task<bool> Delete(Guid userId, Task task)
        {
            var existingUser = await GetUserById(userId);

            var toRemove = existingUser.Tasks.FirstOrDefault(w => w.Id == task.Id);

            var result = existingUser.Tasks.Remove(toRemove);

            return result;
        }

        public async Task<Task> Update(Guid userId, Task task)
        {
            var existingUser = await GetUserById(userId);

            var existingTask = existingUser.Tasks.FirstOrDefault(w => w.Id == task.Id);

            if (existingTask is null)
                return null;

            existingTask.Name = task.Name;
            return existingTask;
        }

        public async Task<bool> MarkAsDone(Guid userId, Task task)
        {
            var existingUser = await GetUserById(userId);

            var existingTask = existingUser.Tasks.FirstOrDefault(w => w.Id == task.Id);

            if (existingTask is null)
                return false;

            existingTask.Done = true;
            existingTask.DoneAt = DateTime.Now;

            return true;
        }

    }
}