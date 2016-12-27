#if !DEBUG
#endif
using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    public class NG2StatisticController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "NG2Statistics");
        }
    }
}