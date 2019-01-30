using System;

namespace TodoApp.Domain.Task
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }
}