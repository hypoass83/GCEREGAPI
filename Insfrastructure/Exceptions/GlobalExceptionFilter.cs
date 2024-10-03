using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.Exceptions
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode = 500; 
            string message = context.Exception.Message;

            if (context.Exception is CustomException customException)
            {
                statusCode = customException.StatusCode;
                message = context.Exception.Message;
            }

            context.Result = new JsonResult(new
            {
                error = message,
                statusCode = statusCode
            })
            {
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
