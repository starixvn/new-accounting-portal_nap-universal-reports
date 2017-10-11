using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Configuration;
using Fanex.NAP.Core.Service.Interface;
using Fanex.NAP.Core.Web.Attribute;
using Fanex.NAP.Core.Web.Session;
using System.Linq;
using System.Web.Mvc;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Sites.Settings;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    public class HouseWinLossByProductsController : LegacyPathAdapterController
    {
        private readonly IUserService userService;

        private readonly ICurrentSession currentSession;

        public HouseWinLossByProductsController(IUserService userService, ICurrentSession currentSession, BalanceUpService balanceUpService) : base(balanceUpService)
        {
            this.userService = userService;
            this.currentSession = currentSession;
        }

        [NapAuth(FunctionKey = FunctionKeys.HouseWinLossByProducts, Policy = Constant.Policy.Read)]
        public ActionResult Index()
        {
            SetupGlobalJsObject();

            ViewBag.ProductPermissions = this.userService.GetPermissions(
                currentSession.UserId,
                NapSettings.Settings.SiteId,
                FunctionKeys.HouseWinLossProductPermission)
                .Where(p => p.Policy >= (int)Constant.Policy.Read)
                .Select(p => p.Function.Key);
            ViewBag.ModePermissions = this.userService.GetPermissions(
                currentSession.UserId,
                NapSettings.Settings.SiteId,
                FunctionKeys.HouseWinLossModePermission)
                .Where(p => p.Policy >= (int)Constant.Policy.Read)
                .Select(p => p.Function.Key);
            return View();
        }
    }
}