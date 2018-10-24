using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreWebService.Filters
{
    public class CustomExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //context.HttpContext.Request == context.HttpContext.Request.CreateResponse(HttpStatusCode.InternalServerError, actionExecutedContext.Exception.GetDeepExceptionMessage());
            base.OnException(context);
        }
        
    }
}