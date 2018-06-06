using System.Web.Mvc;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.Sites.Controllers
{
    public class ExchangeController : LegacyPathAdapterController
    {
        public ExchangeController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        //[NapAuth(FunctionKey = FunctionKeys.Exchange, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/exchange/index.cshtml");
        }
    }
}