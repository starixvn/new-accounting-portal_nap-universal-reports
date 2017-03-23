using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    [AllowAnonymous]
    public class CommonController : Controller
    {
        public ActionResult SessionExpired()
        {
            ViewBag.LegacyPath = LegacyUrlResolver.LegacyRootUri;
            return View();
        }
    }
}