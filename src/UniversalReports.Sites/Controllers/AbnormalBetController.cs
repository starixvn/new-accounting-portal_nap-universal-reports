using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using System.Web.Mvc;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    using BalanceUpServices;

    public class AbnormalBetController : LegacyPathAdapterController
    {
        public AbnormalBetController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.AbnormalBetReport, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/ab-normal-bet/index.cshtml");
        }
    }
}