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
    [RoutePrefix("todo-app/user")]
    public class UserController : BaseController
    {
        private readonly IUserUseCase _userUseCase;

        public UserController(IUserUseCase userUseCase)
        {
            _userUseCase = userUseCase;
        }

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

        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser([FromBody] UserInput user)
        {
            try
            {
                var id = await _userUseCase.CreateUser(user);
                return Ok(id);
            }
            catch (Exception e)
            {
                return GetFormattedError("Could not create user", e);
            }
        }
    }
}
