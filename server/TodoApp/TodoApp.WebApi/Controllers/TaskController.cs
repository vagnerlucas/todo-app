using System;
using System.Threading.Tasks;
using System.Web.Http;
using TodoApp.Application.UseCases.Task;

namespace TodoApp.WebApi.Controllers
{
    [RoutePrefix("todo-app/tasks")]
    public class TaskController : BaseController
    {
        private readonly ITaskUseCase _taskUseCase;

        public TaskController(ITaskUseCase taskUseCase)
        {
            _taskUseCase = taskUseCase;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ListAll()
        {
            try
            {
                var userId = GetUserIdFromRequest();

                if (userId == null)
                    return BadRequest("Invalid operation");

                var data = await _taskUseCase.ListAll((Guid)userId);
                return Ok(data);
            }
            catch (Exception e)
            {
                return GetFormattedError("Could not list user tasks", e);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateTask([FromBody] TaskInput task)
        {
            try
            {
                var userId = GetUserIdFromRequest();

                if (userId == null)
                    return BadRequest("Invalid operation");

                var data = await _taskUseCase.Create((Guid)userId, task);
                return Ok(data);
            }
            catch (Exception e)
            {
                return GetFormattedError("Could not create user tasks", e);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateTask([FromBody] TaskInput task)
        {
            try
            {
                var userId = GetUserIdFromRequest();

                if (userId == null)
                    return BadRequest("Invalid operation");

                var data = await _taskUseCase.Update((Guid)userId, task);
                return Ok(data);
            }
            catch (Exception e)
            {
                return GetFormattedError("Could not create user tasks", e);
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IHttpActionResult> DeleteTask([FromBody] TaskInput task)
        {
            try
            {
                var userId = GetUserIdFromRequest();

                if (userId == null)
                    return BadRequest("Invalid operation");

                var data = await _taskUseCase.Delete((Guid)userId, task);
                return Ok(data);
            }
            catch (Exception e)
            {
                return GetFormattedError("Could not delete user tasks", e);
            }
        }

        [HttpPost]
        [Route("done")]
        public async Task<IHttpActionResult> MarkTaskAsDone([FromBody] TaskInput task)
        {
            try
            {
                var userId = GetUserIdFromRequest();

                if (userId == null)
                    return BadRequest("Invalid operation");

                var data = await _taskUseCase.MarkAsDone((Guid)userId, task);
                return Ok(data);
            }
            catch (Exception e)
            {
                return GetFormattedError("Could not update user tasks", e);
            }
        }
    }
}
