using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using TodoApp.Application.UseCases.Task;

namespace TodoApp.WebApi.Controllers
{
    /// <summary>
    /// Task controller
    /// </summary>
    [RoutePrefix("todo-app/tasks")]
    public class TaskController : BaseController
    {
        /// <summary>
        /// Task service
        /// </summary>
        private readonly ITaskUseCase _taskUseCase;

        public TaskController(ITaskUseCase taskUseCase)
        {
            _taskUseCase = taskUseCase;
        }

        /// <summary>
        /// Gets all user's tasks
        /// </summary>
        /// <returns>List of user's tasks</returns>
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
                // returns a 500 Error
                return GetFormattedError("Could not list user tasks", e);
            }
        }

        /// <summary>
        /// Creates an user's task
        /// </summary>
        /// <param name="task">Task model</param>
        /// <returns>Created task</returns>
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
                return Created($"/tasks/{data.Id}", data);
            }
            catch (Exception e)
            {
                // returns a 500 Error
                return GetFormattedError("Could not create user tasks", e);
            }
        }

        /// <summary>
        /// Updates an user's task
        /// </summary>
        /// <param name="task">Task model</param>
        /// <returns>No content</returns>
        [HttpPost]
        [Route("update")]
        public async Task<IHttpActionResult> UpdateTask([FromBody] TaskInput task)
        {
            try
            {
                var userId = GetUserIdFromRequest();

                if (userId == null)
                    return BadRequest("Invalid operation");

                await _taskUseCase.Update((Guid)userId, task);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                // returns a 500 Error
                return GetFormattedError("Could not create user tasks", e);
            }
        }

        /// <summary>
        /// Deletes an user's task by id
        /// </summary>
        /// <param name="id">Task Id</param>
        /// <returns>No content</returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IHttpActionResult> DeleteTask(Guid id)
        {
            try
            {
                var userId = GetUserIdFromRequest();

                if (userId == null)
                    return BadRequest("Invalid operation");

                await _taskUseCase.Delete((Guid)userId, id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                // returns a 500 Error
                return GetFormattedError("Could not delete user tasks", e);
            }
        }

        /// <summary>
        /// Marks an user's task as done
        /// </summary>
        /// <param name="task">Task model</param>
        /// <returns>No content</returns>
        [HttpPost]
        [Route("done")]
        public async Task<IHttpActionResult> MarkTaskAsDone([FromBody] TaskInput task)
        {
            try
            {
                var userId = GetUserIdFromRequest();

                if (userId == null)
                    return BadRequest("Invalid operation");

                await _taskUseCase.MarkAsDone((Guid)userId, task);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                // returns a 500 Error
                return GetFormattedError("Could not update user tasks", e);
            }
        }
    }
}
