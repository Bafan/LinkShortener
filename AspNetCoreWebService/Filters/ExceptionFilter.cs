using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using AspNetCoreWebService.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebService.Filters
{
    public class CustomExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(context.Exception.GetDeepExceptionMessage());
            base.OnException(context);
        }
        
    }
}