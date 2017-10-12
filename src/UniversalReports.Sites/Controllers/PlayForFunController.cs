using System.Web.Mvc;
using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    public class PlayForFunStatisticsController : LegacyPathAdapterController
    {
        public PlayForFunStatisticsController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.PlayForFunStatistics, Policy = Constant.Policy.Read)]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/play-for-fun/index.cshtml");
        }
    }
}