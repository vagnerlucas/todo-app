using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TodoApp.WebApi.Controllers
{
    public class BaseController : ApiController
    {
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

        protected Guid? GetUserIdFromRequest()
        {
            var id = Request.Headers.GetValues("id").FirstOrDefault();

            if (string.IsNullOrWhiteSpace(id))
                return null;

            return Guid.Parse(id);
        }

        protected IHttpActionResult GetFormattedError(string errorMessage, Exception exception)
        {
            var exceptionMessage = GetExceptionMessage(exception);
            return Content(HttpStatusCode.InternalServerError, new { friendlyMsg = errorMessage, debugMessage = exceptionMessage });
        }
    }
}
