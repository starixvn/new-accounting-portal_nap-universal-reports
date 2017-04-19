using System.Web.Mvc;

namespace UniversalReports.Sites
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
#if !DEBUG
            filters.Add(new AuthorizeAttribute());
#endif
        }
    }
}
