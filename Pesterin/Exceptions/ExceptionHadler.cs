using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Pesterin.Responses;

namespace Pesterin.Exceptions
{
    public class ExceptionHadler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = context.Exception.Message;

            if (context.Exception is ArgumentException || context.Exception is ArgumentNullException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                statusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is KeyNotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound; 
            }

            context.Result = new ObjectResult(new ResponseResult<string>
            {
                IsSuccess = false,
                Error = new ErrorViewModel
                {
                    Code = statusCode,
                    Message = message
                }
            })
            {
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
