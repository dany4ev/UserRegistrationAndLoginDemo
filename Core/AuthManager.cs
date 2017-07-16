using Autofac;
using merXcoin.Services;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using UserRegistrationAndLoginDemo.Api.Core.Enums;
using UserRegistrationAndLoginDemo.Core;
using UserRegistrationAndLoginDemo.Core.IService;

namespace UserRegistrationAndLoginDemo.Api.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AuthManager : ActionFilterAttribute
    {
        public RoleType RoleType { get; set; }

        public AuthManager(RoleType roleType)
        {
            RoleType = roleType;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var isValid = false;
            IDependencyInjection dependencyInjection = new DependencyInjection();
            var container = dependencyInjection.GetContainer();
            var authService = container.Resolve<IUserService>();
            var authorization = actionContext.Request.Headers.Authorization;
            if (authorization != null)
            {
                var token = authorization.Parameter;
                isValid = authService.ValidateToken(token);
            }

            var message = GetMessageByRoleType(isValid);

            // TODO: in case of unauthorized users must return unauthorized response instead of throwing this exception
            if (!isValid)
            {
                throw new HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(message),
                    ReasonPhrase = message,
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                });
            }
        }

        string GetMessageByRoleType(bool isValid)
        {
            var message = "";
            switch (RoleType)
            {
                case RoleType.User:
                    message = isValid ? "Invalid user." : "";
                    break;
                case RoleType.Admin:
                    message = isValid ? "Invalid admin." : "";
                    break;
            }

            return message;
        }
    }
}