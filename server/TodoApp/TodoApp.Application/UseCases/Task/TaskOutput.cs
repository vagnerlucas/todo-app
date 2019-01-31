using System;
using TodoApp.Domain.Task;

namespace TodoApp.Application.UseCases.Task
{
    public struct TaskOutput
    {
        public TaskOutput(Domain.Task.Task task)
        {
            Id = task.Id;
            Name = task.Name;
            CreatedAt = task.CreatedAt;
            DoneAt = task.DoneAt;
            Done = task.Done;
        }

        public Guid Id { get; }
        public string Name { get; }
        public DateTime CreatedAt { get; }
        public DateTime? DoneAt { get; }
        public bool Done { get; }
    }
}