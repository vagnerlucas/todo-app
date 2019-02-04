using System;
using System.Collections;
using System.Collections.Generic;
using TodoApp.Domain.ValueObjects;

namespace TodoApp.Domain.User
{
    /// <summary>
    /// Application user
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public Name Name { get; set; }
        /// <summary>
        /// List of user's tasks
        /// </summary>
        public ICollection<Task.Task> Tasks { get; set; } = new List<Task.Task>();
    }
}