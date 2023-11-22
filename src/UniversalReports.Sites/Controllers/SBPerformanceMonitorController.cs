using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using System.Web.Mvc;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    using BalanceUpServices;

    public class SBPerformanceMonitorController : LegacyPathAdapterController
    {
        public SBPerformanceMonitorController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.SBPerformanceMonitor, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/sb-performance/index.cshtml");
        }
    }
}