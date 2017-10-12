using System.Web.Mvc;
using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    public class NG2StatisticsController : LegacyPathAdapterController
    {
        public NG2StatisticsController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.NG2Statistics, Policy = Constant.Policy.Read)]
        public ActionResult Index()
        {
            SetupGlobalJsObject();

            return View();
        }
    }
}