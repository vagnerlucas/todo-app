using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TodoApp.Domain.Task;
using TodoApp.Domain.User;

namespace TodoApp.Infrastructure.InMemory
{
    public class Context
    {
        public ICollection<User> Users { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public Context()
        {
            Users = new Collection<User>();
            Tasks = new Collection<Task>();
        }
    }
}