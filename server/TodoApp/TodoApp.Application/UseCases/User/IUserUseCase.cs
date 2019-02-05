using System;
using System.Threading.Tasks;

namespace TodoApp.Application.UseCases.User
{
    /// <summary>
    /// User service
    /// </summary>
    public interface IUserUseCase
    {
        /// <summary>
        /// Creates an application user
        /// </summary>
        /// <param name="user">User model</param>
        /// <returns>Created user</returns>
        Task<UserOutput?> CreateUser(UserInput user);
        /// <summary>
        /// Gets an user by name
        /// </summary>
        /// <param name="name">Username</param>
        /// <returns>Application user</returns>
        Task<UserOutput?> GetUser(string name);
        /// <summary>
        /// Gets an user by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Application user</returns>
        Task<UserOutput?> GetUser(Guid id);

        /// <summary>
        /// Removes an user from application
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Task</returns>
        System.Threading.Tasks.Task RemoveUserById(Guid userId);
    }

}