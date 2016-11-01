#if !DEBUG
using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using UniversalReports.Sites.Settings;
#endif
using System;
using System.Configuration;
using System.Web.Mvc;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.Sites.Controllers
{
    public class NG2StatisticController : Controller
    {
        private readonly BalanceUpService balanceUpService;

        public NG2StatisticController(BalanceUpService balanceUpService)
        {
            this.balanceUpService = balanceUpService;
        }

#if !DEBUG
        [NapAuth(FunctionKey = FunctionKeys.NG2Statistic, Policy = Constant.Policy.Read)]
#endif
        public ActionResult Index()
        {
            var appUri = new Uri(Request.Url, Url.Content("~/"));
            var legacyPath = ConfigurationManager.AppSettings["LegacyPath"];
            var legacyUri = new Uri(appUri, legacyPath);

            ViewBag.RootUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
            ViewBag.LegacyPath = legacyUri.AbsoluteUri;
            ViewBag.BalanceUp = balanceUpService.Query();

            return View();
        }
    }
}