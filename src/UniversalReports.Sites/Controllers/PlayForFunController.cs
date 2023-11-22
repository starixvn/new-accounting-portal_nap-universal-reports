using System.Web.Mvc;
using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    using BalanceUpServices;

    public class PlayForFunStatisticsController : LegacyPathAdapterController
    {
        public PlayForFunStatisticsController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.PlayForFunStatistics, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/play-for-fun/index.cshtml");
        }
    }
}