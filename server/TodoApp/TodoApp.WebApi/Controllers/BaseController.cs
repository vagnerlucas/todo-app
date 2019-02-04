using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TodoApp.WebApi.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// Formats an exception from the action call
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Formatted error</returns>
        private string GetExceptionMessage(Exception exception)
        {
            if (exception == null)
                return string.Empty;

            var message = exception?.Message + Environment.NewLine;
            
            if (exception?.InnerException == null)
                return message;

            message += GetExceptionMessage(exception.InnerException) + Environment.NewLine;
            return message;
        }

        /// <summary>
        /// Gets the user Id form HTTP request
        /// </summary>
        /// <returns>Id of the user by it's request header</returns>
        protected Guid? GetUserIdFromRequest()
        {
            var id = Request.Headers.GetValues("X-User-Id").FirstOrDefault();

            if (string.IsNullOrWhiteSpace(id))
                return null;

            return Guid.Parse(id);
        }

        /// <summary>
        /// Formats the exception error from the action call
        /// </summary>
        /// <param name="errorMessage">Friendly message</param>
        /// <param name="exception">Exception</param>
        /// <returns>HTTP 500 error</returns>
        protected IHttpActionResult GetFormattedError(string errorMessage, Exception exception)
        {
            var exceptionMessage = GetExceptionMessage(exception);
            return Content(HttpStatusCode.InternalServerError, new { friendlyMsg = errorMessage, debugMessage = exceptionMessage });
        }
    }
}
