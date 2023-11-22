using System.Web.Mvc;
using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    using BalanceUpServices;

    public class UpdatedUsernameAndGivenCreditController : LegacyPathAdapterController
    {
        public UpdatedUsernameAndGivenCreditController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.UpdatedUsernameAndGivenCredit, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/updated-username-credit/index.cshtml");
        }
    }
}