using System;
using System.Threading.Tasks;

namespace TodoApp.Application.UseCases.User
{
    public interface IUserUseCase
    {
        Task<Guid> CreateUser(UserInput user);
        Task<UserOutput> GetUser(string name);
    }

}