using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetCoreWebService.Extensions
{
    public static class Extensions
    {
        public static string GetDeepExceptionMessage(this Exception exception)
        {
            return exception.InnerException != null ? GetDeepExceptionMessage(exception.InnerException) : exception.Message;
        }
    }
}