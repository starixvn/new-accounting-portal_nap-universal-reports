using System;
using System.Configuration;
using System.Web.Mvc;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;

namespace UniversalReports.Sites.Controllers
{
    public class CompanyWinLossController : Controller
    {
        private readonly BalanceUpService balanceUpService;

        public CompanyWinLossController(BalanceUpService balanceUpService)
        {
            this.balanceUpService = balanceUpService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var appUri = new Uri(Request.Url, Url.Content("~/"));
            var legacyPath = ConfigurationManager.AppSettings["LegacyPath"];
            var legacyUri = new Uri(appUri, legacyPath);
            ViewBag.LegacyPath = legacyUri.AbsoluteUri;
            ViewBag.BalanceUp = this.balanceUpService.Query();

            return View();
        }
    }
}