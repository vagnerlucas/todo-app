using System;
using System.Threading.Tasks;
using TodoApp.Domain.User;

namespace TodoApp.Application.Repositories.UserRepository
{
    public interface IUserReadOnlyRepository
    {
        Task<User> GetUser(string name);
        Task<User> GetUser(Guid id);
    }
}