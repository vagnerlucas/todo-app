using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application;
using TodoApp.Application.Repositories.UserRepository;
using TodoApp.Domain.User;

namespace TodoApp.Infrastructure.InMemory.Repositories
{
    public class UserReadOnlyRepository : IUserReadOnlyRepository
    {
        private readonly Context _context;

        public UserReadOnlyRepository(Context context)
        {
            _context = context;
        }
        public Task<User> GetUser(string name)
        {
            var user = _context.Users.FirstOrDefault(w => w.Name.ToString().ToUpperInvariant() == name.ToUpperInvariant().Trim());
            if (user == null)
                throw new UserNotFoundException("User not found");

            return Task.FromResult(user);
        }
    }
}