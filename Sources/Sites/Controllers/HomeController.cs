using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "CompanyWinLoss");
        }
    }
}