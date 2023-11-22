using System;
using System.Web.Mvc;

namespace UniversalReports.Sites.Controllers
{
    using BalanceUpServices;

    public class LegacyPathAdapterController : Controller
    {
        private readonly BalanceUpService balanceUpService;

        public LegacyPathAdapterController(BalanceUpService balanceUpService)
        {
            this.balanceUpService = balanceUpService;
        }

        protected void SetupGlobalJsObject()
        {
            ViewBag.RootUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
            ViewBag.LegacyPath = LegacyUrlResolver.LegacyRootUri;
            ViewBag.BalanceUp = balanceUpService.Query();
        }
    }
}