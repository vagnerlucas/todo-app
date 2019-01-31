using System.Linq;
using System.Threading.Tasks;
using TodoApp.Application.Repositories.UserRepository;
using TodoApp.Domain.User;

namespace TodoApp.Infrastructure.InMemory.Repositories
{
    public class UserReadOnlyRepository : BaseRepository, IUserReadOnlyRepository
    {
        public Task<User> GetUser(string name)
        {
            var user = _context.Users.FirstOrDefault(w => w.Name.ToString().ToUpperInvariant() == name);
            return Task.FromResult(user);
        }
    }
}