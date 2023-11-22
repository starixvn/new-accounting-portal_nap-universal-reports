using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.AspNet.WebApi.TrimmingFormatter;
using Olympus.HttpLogger;

namespace UniversalReports.Sites
{
    using Attributes;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();
            var defaultOption = new
            {
                id = RouteParameter.Optional
            };
            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: defaultOption);

            configuration.Formatters.Clear();
            configuration.Formatters.Add(new JsonMediaTypeFormatter());
            configuration.Formatters.JsonFormatter.SerializerSettings.Converters
               .Add(new TrimmingConverter());
            configuration.Filters.Add(new LogExceptionFilterAttribute());
            configuration.Filters.Add(new LoggingFilterApiAttribute(true,
                new List<string> { "api/punter-analysis/associated-account" },
                new List<string>()));
#if !DEBUG
            configuration.Filters.Add(new AuthorizeAttribute());
#endif
        }
    }
}