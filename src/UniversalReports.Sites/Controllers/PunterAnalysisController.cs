using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using System.Web.Mvc;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    public class PunterAnalysisController : LegacyPathAdapterController
    {
        public PunterAnalysisController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.PunterAnalysis, Policy = Constant.Policy.Read)]
        public ActionResult Index()
        {
            SetupGlobalJsObject();
            return View("~/wwwroot/punter-analysis/index.cshtml");
        }
    }
}