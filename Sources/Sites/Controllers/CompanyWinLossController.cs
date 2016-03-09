using System;
using System.Configuration;
using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    public class CompanyWinLossController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var appUri = new Uri(Request.Url, Url.Content("~/"));
            var legacyPath = ConfigurationManager.AppSettings["LegacyPath"];
            var legacyUri = new Uri(appUri, legacyPath);
            ViewBag.LegacyPath = legacyUri.AbsoluteUri;
            return View();
        }
    }
}