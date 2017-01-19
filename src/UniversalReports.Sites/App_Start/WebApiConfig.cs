using System.Net.Http.Formatting;
using System.Web.Http;
using UniversalReports.API.Attributes;

namespace UniversalReports.Sites
{
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

            configuration.Filters.Add(new LogExceptionFilterAttribute());
            configuration.Filters.Add(new AuthorizeAttribute());
        }
    }
}
