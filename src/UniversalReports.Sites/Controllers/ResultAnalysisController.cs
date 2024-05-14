using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using System.Web.Mvc;
using UniversalReports.BalanceUpServices;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
	public class ResultAnalysisController : LegacyPathAdapterController
	{
		public ResultAnalysisController(BalanceUpService balanceUpService) : base(balanceUpService)
		{
		}

		[NapAuth(FunctionKey = FunctionKeys.ResultAnalysis, Policy = Constant.Policy.Read)]
		[UserActivityFilter]
		public ActionResult Index()
		{
			SetupGlobalJsObject();
			return View("~/wwwroot/result-analysis/index.cshtml");
		}
	}
}