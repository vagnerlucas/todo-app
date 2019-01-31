using System;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application.Repositories.TaskRepository;
using Task = TodoApp.Domain.Task.Task;

namespace TodoApp.Infrastructure.InMemory.Repositories
{
    public class TaskWriteOnlyRepository : BaseRepository, ITaskWriteOnlyRepository
    {
        public Task<bool> Create(Task task)
        {
            task.Id = Guid.NewGuid();
            _context.Tasks.Add(task);
            return System.Threading.Tasks.Task.FromResult(true);
        }

        public Task<bool> Delete(Task task)
        {
            var result = _context.Tasks.Remove(task);
            return System.Threading.Tasks.Task.FromResult(result);
        }

        public Task<bool> DeleteById(Guid id)
        {
            var task = _context.Tasks.FirstOrDefault(w => w.Id == id);

            if (task is null)
                return System.Threading.Tasks.Task.FromResult(false);

            return Delete(task);
        }

        public Task<bool> Update(Task task)
        {
            var existingTask = _context.Tasks.FirstOrDefault(w => w.Id == task.Id);

            if (existingTask is null)
                return System.Threading.Tasks.Task.FromResult(false);

            existingTask.Name = task.Name;
            return System.Threading.Tasks.Task.FromResult(true);
        }

        public Task<bool> MarkAsDone(Task task)
        {
            var existingTask = _context.Tasks.FirstOrDefault(w => w.Id == task.Id && w.Name.Equals(task.Name));

            if (existingTask is null)
                return System.Threading.Tasks.Task.FromResult(false);

            existingTask.Done = true;

            return System.Threading.Tasks.Task.FromResult(true);
        }
    }
}