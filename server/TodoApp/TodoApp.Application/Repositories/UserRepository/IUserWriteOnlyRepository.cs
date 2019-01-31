using System;
using System.Threading.Tasks;
using TodoApp.Domain.User;

namespace TodoApp.Application.Repositories.UserRepository
{
    public interface IUserWriteOnlyRepository
    {
        Task<Guid> CreateUser(User user);
    }
}