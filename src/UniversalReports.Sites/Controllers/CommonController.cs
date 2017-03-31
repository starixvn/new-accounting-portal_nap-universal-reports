using System;
using System.Configuration;
using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult SessionExpired()
        {
            ViewBag.LegacyPath = LegacyUrlResolver.LegacyRootUri;
            return View();
        }
    }
}