using ElectionManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ElectionManagement.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = new Error
           (
               500,
               context.Exception.Message,
               context.Exception.StackTrace?.ToString()
           );

            context.Result = new JsonResult(error);
        }
    }
}
