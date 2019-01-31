using System;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application.Repositories.UserRepository;
using TodoApp.Domain.User;

namespace TodoApp.Infrastructure.InMemory.Repositories
{
    public class UserWriteOnlyRepository : IUserWriteOnlyRepository
    {
        private readonly Context _context;

        public UserWriteOnlyRepository(Context context)
        {
            _context = context;
        }

        public Task<Guid> CreateUser(User user)
        {
            if (_context.Users.Any(w => w.Name.Equals(user.Name)))
                throw new InvalidOperationException("Username already taken");

            user.Id = Guid.NewGuid();
            _context.Users.Add(user);

            return Task.FromResult(user.Id);
        }
    }
}