﻿using System;
using System.Threading.Tasks;
using TodoApp.Domain.User;

namespace TodoApp.Application.Repositories.UserRepository
{
    /// <summary>
    /// User write only repository service
    /// </summary>
    public interface IUserWriteOnlyRepository
    {
        /// <summary>
        /// Creates an application user
        /// </summary>
        /// <param name="user">User model</param>
        /// <returns>Id of the created user</returns>
        Task<Guid> CreateUser(User user);
    }
}