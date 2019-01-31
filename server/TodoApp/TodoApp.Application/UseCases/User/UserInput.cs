using System;
using TodoApp.Application.UseCases.Task;

namespace TodoApp.Application.UseCases.User
{
    public class UserInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}