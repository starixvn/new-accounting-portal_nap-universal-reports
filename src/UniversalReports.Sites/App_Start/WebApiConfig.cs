using System.Net.Http.Formatting;
using System.Web.Http;

namespace UniversalReports.Sites.App_Start
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
        }
    }
}
