using System.Net.Http.Formatting;
using System.Web.Http;

namespace NAP.Reports.CompanyWinLoss.Sites
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
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
