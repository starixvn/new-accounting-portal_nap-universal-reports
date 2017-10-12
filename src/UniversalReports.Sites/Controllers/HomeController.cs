using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "HouseWinLossByProducts");
        }
    }
}