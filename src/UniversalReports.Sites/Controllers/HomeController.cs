using System.Web;
using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            Response.Cookies.Add(new HttpCookie("bullshit", "shit"));
            return RedirectToAction("Index", "HouseWinLossByProducts");
        }
    }
}