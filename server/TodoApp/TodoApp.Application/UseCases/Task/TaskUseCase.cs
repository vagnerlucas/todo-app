using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Repositories.TaskRepository;

namespace TodoApp.Application.UseCases.Task
{
    public class TaskUseCase : ITaskUseCase
    {
        private readonly ITaskReadOnlyRepository _taskReadOnlyRepository;
        private readonly ITaskWriteOnlyRepository _taskWriteOnlyRepository;

        public TaskUseCase(ITaskReadOnlyRepository taskReadOnlyRepository, ITaskWriteOnlyRepository taskWriteOnlyRepository)
        {
            _taskReadOnlyRepository = taskReadOnlyRepository;
            _taskWriteOnlyRepository = taskWriteOnlyRepository;
        }

        public async Task<ICollection<TaskOutput>> ListAll()
        {
            var data = await _taskReadOnlyRepository.ListAll();
            return data.Select(task => new TaskOutput(task)).ToList();
        }

        public Task<bool> Create(TaskInput task)
        {
            var taskDomain = GenerateInput(task);
            return _taskWriteOnlyRepository.Create(taskDomain);
        }

        public Task<bool> Delete(TaskInput task)
        {
            var taskDomain = GenerateInput(task);
            return _taskWriteOnlyRepository.Delete(taskDomain);
        }

        public Task<bool> DeleteById(Guid id)
        {
            return _taskWriteOnlyRepository.DeleteById(id);
        }

        public Task<bool> Update(TaskInput task)
        {
            var taskDomain = GenerateInput(task);
            return _taskWriteOnlyRepository.Update(taskDomain);
        }

        public Task<bool> MarkAsDone(TaskInput task)
        {
            var taskDomain = GenerateInput(task);
            return _taskWriteOnlyRepository.MarkAsDone(taskDomain);
        }

        internal static Domain.Task.Task GenerateInput(TaskInput task)
        {
            return new Domain.Task.Task
            {
                Id = task.Id,
                CreatedAt = task.CreatedAt,
                Done = task.Done,
                DoneAt = task.DoneAt,
                Name = task.Name
            };
        }
    }
}
