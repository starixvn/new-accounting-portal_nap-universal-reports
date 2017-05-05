using System;
using System.Configuration;
using System.Web;

namespace UniversalReports.Sites.Controllers
{
    public static class LegacyUrlResolver
    {
        public static Uri LegacyRootUri
        {
            get
            {
                var reportUrl = VirtualPathUtility.ToAbsolute("~/");
                var reportFullUri = new Uri(HttpContext.Current.Request.Url, reportUrl);
                var legacyPath = ConfigurationManager.AppSettings["LegacyPath"];
                var legacyUri = new Uri(reportFullUri, legacyPath);

                return new Uri(legacyUri.AbsoluteUri);
            }
        }
    }
}
