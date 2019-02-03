using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application.Repositories.TaskRepository;
using TodoApp.Application.Repositories.UserRepository;
using TodoApp.Domain.Task;
using TodoApp.Domain.User;
using Task = TodoApp.Domain.Task.Task;

namespace TodoApp.Infrastructure.InMemory.Repositories
{
    public class TaskReadOnlyRepository : ITaskReadOnlyRepository
    {
        private readonly Context _context;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public TaskReadOnlyRepository(Context context, IUserReadOnlyRepository userReadOnlyRepository)
        {
            _context = context;
            _userReadOnlyRepository = userReadOnlyRepository;
        }

        private Task<User> GetUserById(Guid id) => _userReadOnlyRepository.GetUser(id);

        public async Task<ICollection<Task>> ListAll(Guid userId)
        {
            var user = await GetUserById(userId);
            var data = user?.Tasks ?? new List<Task>();
            return data;
        }
    }
}