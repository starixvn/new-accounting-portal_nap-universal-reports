using System.Collections.Generic;
using System.Web.Mvc;
using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Web.Attribute;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    using BalanceUpServices;

    public class DailyWinLoss2hSoccerMinorController : LegacyPathAdapterController
    {
        public DailyWinLoss2hSoccerMinorController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        [NapAuth(FunctionKey = FunctionKeys.DailyWinLoss2hSoccerMinorBettype, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();

            ViewBag.ProductPermissions = new List<string> { "HouseWinLossByProducts_AllProducts" };
            ViewBag.ModePermissions = new List<string> { "HouseWinLossByProducts_HistoryMode", "HouseWinLossByProducts_NormalMode" };
            return View();
        }
    }
}