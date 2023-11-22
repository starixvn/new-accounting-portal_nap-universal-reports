using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using System.Web.Mvc;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    using BalanceUpServices;

    public class SMAWinLossController : LegacyPathAdapterController
    {
        public SMAWinLossController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.SMAWinLossSummary, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/sma-win-loss/index.cshtml");
        }
    }
}