using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebService.Extensions;

namespace AspNetCoreWebService.Filters
{
    public class CustomExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var result = new JsonResult(context.Exception.GetDeepExceptionMessage());
            result.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Result = result;
            base.OnException(context);
        }
    }
}