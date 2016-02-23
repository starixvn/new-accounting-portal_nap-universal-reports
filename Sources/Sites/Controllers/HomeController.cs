using System.Configuration;
using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.LegacyPath = ConfigurationManager.AppSettings["LegacyPath"];
            return View();
        }
        public ActionResult SessionExpired()
        {
            return Content("Your session is expired. Please login again.");
        }
    }
}