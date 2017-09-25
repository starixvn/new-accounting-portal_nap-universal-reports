#if !DEBUG
using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using UniversalReports.Sites.Settings;
#endif

using System.Web.Mvc;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.Sites.Controllers
{
    public class UpdatedUsernameAndGivenCreditController : LegacyPathAdapterController
    {
        public UpdatedUsernameAndGivenCreditController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }


#if !DEBUG
    [NapAuth(FunctionKey = FunctionKeys.UpdatedUsernameAndGivenCredit, Policy = Constant.Policy.Read)]
#endif
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/updated-username-and-given-credit/index.cshtml");
        }
    }
}