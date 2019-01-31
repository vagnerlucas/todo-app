using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICollection<TaskOutput>> ListAll(Guid userId)
        {
            var data = await _taskReadOnlyRepository.ListAll(userId);
            return data.Select(task => new TaskOutput(task)).ToList();
        }

        public Task<bool> Create(Guid userId, TaskInput task)
        {
            var taskDomain = GenerateDomainInput(task);
            return _taskWriteOnlyRepository.Create(userId, taskDomain);
        }

        public Task<bool> Delete(Guid userId, TaskInput task)
        {
            var taskDomain = GenerateDomainInput(task);
            return _taskWriteOnlyRepository.Delete(userId, taskDomain);
        }

        public Task<bool> Update(Guid userId, TaskInput task)
        {
            var taskDomain = GenerateDomainInput(task);
            return _taskWriteOnlyRepository.Update(userId, taskDomain);
        }

        public Task<bool> MarkAsDone(Guid userId, TaskInput task)
        {
            var taskDomain = GenerateDomainInput(task);
            return _taskWriteOnlyRepository.MarkAsDone(userId, taskDomain);
        }

        internal static Domain.Task.Task GenerateDomainInput(TaskInput task)
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
