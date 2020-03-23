using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using System.Web.Mvc;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    public class AbnormalBetController : LegacyPathAdapterController
    {
        public AbnormalBetController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.AbnormalBet, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/ab-normal-bet/index.cshtml");
        }
    }
}