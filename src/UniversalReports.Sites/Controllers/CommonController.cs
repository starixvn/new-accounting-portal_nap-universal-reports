using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    [AllowAnonymous]
    public class CommonController : Controller
    {
        public ActionResult SessionExpired()
        {
#if DEBUG
            return RedirectToAction("Index", "FakeLogin");
#else
            ViewBag.LegacyPath = LegacyUrlResolver.LegacyRootUri;
            return View();
#endif
        }
    }
}