using System;
using System.Collections;
using System.Collections.Generic;
using TodoApp.Domain.ValueObjects;

namespace TodoApp.Domain.User
{
    public class User
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public ICollection<Task.Task> Tasks { get; set; } = new List<Task.Task>();
    }
}