using System;
using TodoApp.Domain.ValueObjects;

namespace TodoApp.Domain.Task
{
    /// <summary>
    /// User Task
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Task Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Task Name
        /// </summary>
        public Name Name { get; set; }
        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Date when the task was done
        /// </summary>
        public DateTime? DoneAt { get; set; }
        /// <summary>
        /// Done status
        /// </summary>
        public bool Done { get; set; }
    }
}