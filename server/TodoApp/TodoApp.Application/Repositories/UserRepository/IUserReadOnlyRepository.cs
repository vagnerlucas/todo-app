using System;
using System.Threading.Tasks;
using TodoApp.Domain.User;

namespace TodoApp.Application.Repositories.UserRepository
{
    /// <summary>
    /// User read only repository service
    /// </summary>
    public interface IUserReadOnlyRepository
    {
        /// <summary>
        /// Gets an user
        /// </summary>
        /// <param name="name">Username</param>
        /// <returns>Domain user</returns>
        Task<User> GetUser(string name);
        /// <summary>
        /// Gets an user
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Domain user</returns>
        Task<User> GetUser(Guid id);
    }
}