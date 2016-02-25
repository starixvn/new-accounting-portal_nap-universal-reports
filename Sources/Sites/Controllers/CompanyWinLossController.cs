using System.Configuration;
using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    public class CompanyWinLossController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.LegacyPath = ConfigurationManager.AppSettings["LegacyPath"];
            return View();
        }
    }
}