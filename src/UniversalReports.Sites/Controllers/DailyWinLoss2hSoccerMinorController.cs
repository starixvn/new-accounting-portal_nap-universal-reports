using System.Collections.Generic;
using System.Web.Mvc;
using UniversalReports.Core.BalanceUpServices;


namespace UniversalReports.Sites.Controllers
{
    public class DailyWinLoss2hSoccerMinorController : LegacyPathAdapterController
    {
        public DailyWinLoss2hSoccerMinorController(BalanceUpService balanceUpService) : base(balanceUpService)
        {
        }

        // [NapAuth(FunctionKey = FunctionKeys.HouseWinLossByProducts, Policy = Constant.Policy.Read)]
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