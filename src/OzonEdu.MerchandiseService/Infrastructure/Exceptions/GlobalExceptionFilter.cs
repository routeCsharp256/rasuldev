using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Exceptions
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var e = context.Exception;
            context.Result = new JsonResult(new
            {
                ExceptionType = e.GetType().FullName,
                StackTrace = e.StackTrace
            })
            { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}
