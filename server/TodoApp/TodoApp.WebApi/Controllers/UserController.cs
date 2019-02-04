using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TodoApp.Application.UseCases.User;

namespace TodoApp.WebApi.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [RoutePrefix("todo-app/user")]
    public class UserController : BaseController
    {
        /// <summary>
        /// User service
        /// </summary>
        private readonly IUserUseCase _userUseCase;

        public UserController(IUserUseCase userUseCase)
        {
            _userUseCase = userUseCase;
        }

        /// <summary>
        /// Gets an application user by name
        /// </summary>
        /// <param name="name">Username</param>
        /// <returns>Application user</returns>
        [HttpGet]
        [Route("{name}")]
        public async Task<IHttpActionResult> GetUser(string name)
        {
            try
            {
                var account = await _userUseCase.GetUser(name);
                return Ok(account);
            }
            catch (Exception e)
            {
                // returns a 500 Error
                return GetFormattedError("An error has occurred when trying to get account", e);
            }
        }

        /// <summary>
        /// Gets user information
        /// </summary>
        /// <returns>Application user information</returns>
        [HttpGet]
        [Route("info")]
        public async Task<IHttpActionResult> GetUserInfo()
        {
            try
            {
                var userId = GetUserIdFromRequest();
                if (userId == null)
                    return NotFound();
                var user = await _userUseCase.GetUser((Guid)userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                // returns a 500 error
                return GetFormattedError("An error has occurred when trying to get user info", e);
            }
        }

        /// <summary>
        /// Creates an application user
        /// </summary>
        /// <param name="user">User model</param>
        /// <returns>Application user</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser([FromBody] UserInput user)
        {
            try
            {
                var createdUser = await _userUseCase.CreateUser(user);
                return Created($"/user/{createdUser?.Id}", createdUser);
            }
            catch (Exception e)
            {
                // returns a 500 error
                return GetFormattedError("Could not create user", e);
            }
        }
    }
}
