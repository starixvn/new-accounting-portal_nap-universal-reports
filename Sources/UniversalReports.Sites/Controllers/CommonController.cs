using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult SessionExpired()
        {
            return Content("Your session is expired. Please login again.");
        }
    }
}