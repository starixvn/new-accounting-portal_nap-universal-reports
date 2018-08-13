using System.Web.Mvc;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.Sites.Controllers
{
    public class ActualMemberBetController : LegacyPathAdapterController
    {
        public ActualMemberBetController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        // [NapAuth(FunctionKey = FunctionKeys.ActualMemberBet, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/actual-member-bet/index.cshtml");
        }
    }
}