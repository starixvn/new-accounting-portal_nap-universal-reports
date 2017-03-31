#if !DEBUG
using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using UniversalReports.Sites.Settings;
#endif

using System;
using System.Web.Mvc;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.Sites.Controllers
{
    public class PunterAnalysisController : Controller
    {
        private readonly BalanceUpService balanceUpService;

        public PunterAnalysisController(BalanceUpService balanceUpService)
        {
            this.balanceUpService = balanceUpService;
        }

#if !DEBUG
        [NapAuth(FunctionKey = FunctionKeys.PunterAnalysis, Policy = Constant.Policy.Read)]
#endif
        public ActionResult Index()
        {
            ViewBag.RootUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
            ViewBag.LegacyPath = LegacyUrlResolver.LegacyRootUri;
            ViewBag.BalanceUp = balanceUpService.Query();

            return View();
        }
    }
}