#if !DEBUG
using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using UniversalReports.Sites.Settings;
#endif
using System.Web.Mvc;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.Sites.Controllers
{
    public class NG2StatisticsController : LegacyPathAdapterController
    {
        public NG2StatisticsController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

#if !DEBUG
        [NapAuth(FunctionKey = FunctionKeys.NG2Statistics, Policy = Constant.Policy.Read)]
#endif
        public ActionResult Index()
        {
            SetupGlobalJsObject();

            return View();
        }
    }
}