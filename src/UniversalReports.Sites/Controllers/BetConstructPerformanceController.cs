using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using System.Web.Mvc;
using UniversalReports.BalanceUpServices;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    public class BetConstructPerformanceController : LegacyPathAdapterController
    {
        public BetConstructPerformanceController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.BetConstructPerformance, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/bet-construct/index.cshtml");
        }
    }
}