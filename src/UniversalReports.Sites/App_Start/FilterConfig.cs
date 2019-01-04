using System.Web.Mvc;
using ONEbook.UM.Filters;

namespace UniversalReports.Sites
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CheckUMFilter());
            filters.Add(new UserActivityDetailFilter());
#if !DEBUG
            filters.Add(new AuthorizeAttribute());
#endif
        }
    }
}