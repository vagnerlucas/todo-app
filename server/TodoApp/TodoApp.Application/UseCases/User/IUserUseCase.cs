using System;
using System.Threading.Tasks;

namespace TodoApp.Application.UseCases.User
{
    public interface IUserUseCase
    {
        Task<UserOutput?> CreateUser(UserInput user);
        Task<UserOutput?> GetUser(string name);
    }

}