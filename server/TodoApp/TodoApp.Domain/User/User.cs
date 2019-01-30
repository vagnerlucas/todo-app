using System;
using System.Collections;
using System.Collections.Generic;

namespace TodoApp.Domain.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Task.Task> Tasks { get; set; }
    }
}