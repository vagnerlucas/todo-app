using System;

namespace TodoApp.Application.UseCases.Task
{
    public class TaskInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DoneAt { get; set; }
        public bool Done { get; set; }
    }
}