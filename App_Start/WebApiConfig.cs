using Newtonsoft.Json.Converters;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using UserRegistrationAndLoginDemo.Api.App_Start;
using UserRegistrationAndLoginDemo.Api.Core.Attributes;
using UserRegistrationAndLoginDemo.Api.Core.Infrastructure;

namespace UserRegistrationAndLoginDemo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Web API configuration and services
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Filters.Add(new GlobalExceptionFilterAttribute());

            // Serialize with camelCase formatter for JSON.
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCaseIgnoreDictionaryKeys();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            AutofacConfig.RegisterComponents(config);
        }        
    }
}
