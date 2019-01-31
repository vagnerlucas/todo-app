using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Application.UseCases.Task;

namespace TodoApp.Application.UseCases.User
{
    public struct UserOutput
    {
        public UserOutput(in Domain.User.User user)
        {
            Id = user.Id;
            Name = user.Name;
            Tasks = user.Tasks.Select(task => new TaskOutput(task)).ToList();
        }
        public Guid Id { get; }
        public string Name { get; }
        public ICollection<TaskOutput> Tasks { get; }
    }
}