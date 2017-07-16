using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace UserRegistrationAndLoginDemo.Api.Core.Attributes
{
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            HandleException(filterContext.Exception);
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HandleException(actionExecutedContext.Exception);
        }

        static void HandleException(Exception exception)
        {
            //var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
            //{
            //    Content = new StringContent(exception.Message),
            //    ReasonPhrase = "Bad Request"
            //};
            //Trace.TraceError("An unhandled exception has occured {0}", exception);
            //throw new HttpResponseException(resp);
        }
    }
}