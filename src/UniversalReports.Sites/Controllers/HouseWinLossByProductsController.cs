using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Configuration;
using Fanex.NAP.Core.Service.Interface;
using Fanex.NAP.Core.Web.Attribute;
using Fanex.NAP.Core.Web.Session;
using System.Linq;
using System.Web.Mvc;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.Sites.Settings;

namespace UniversalReports.Sites.Controllers
{
    using BalanceUpServices;

    public class HouseWinLossByProductsController : LegacyPathAdapterController
    {
        private readonly IUserService userService;

        private readonly ICurrentSession currentSession;

        private readonly PermissionFilterService permissionService;

        public HouseWinLossByProductsController(
            IUserService userService, 
            ICurrentSession currentSession,
            BalanceUpService balanceUpService,
            PermissionFilterService permissionService
            ) : base(balanceUpService)
        {
            this.userService = userService;
            this.currentSession = currentSession;
            this.permissionService = permissionService;
        }

        [NapAuth(FunctionKey = FunctionKeys.HouseWinLossByProducts, Policy = Constant.Policy.Read)]
        [UserActivityFilter]
        public ActionResult Index()
        {
            SetupGlobalJsObject();

           var productPermissions  = this.userService.GetPermissions(
                currentSession.UserId,
                NapSettings.Settings.SiteId,
                FunctionKeys.HouseWinLossProductPermission)
                .Where(p => p.Policy >= (int)Constant.Policy.Read)
                .OrderBy(x => x.Name)
                .Select(p => p.Key);

            ViewBag.ProductPermissions = productPermissions;
            var permission = productPermissions.Any() ? productPermissions.FirstOrDefault() : string.Empty;
            ViewBag.PermissionProfileID = permissionService.GetPermissionProfileId(permission);
            ViewBag.ModePermissions = this.userService.GetPermissions(
                currentSession.UserId,
                NapSettings.Settings.SiteId,
                FunctionKeys.HouseWinLossModePermission)
                .Where(p => p.Policy >= (int)Constant.Policy.Read)
                .Select(p => p.Key);
            return View();
        }
    }
}