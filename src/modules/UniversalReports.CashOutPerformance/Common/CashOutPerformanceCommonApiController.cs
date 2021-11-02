using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Configuration;
using Fanex.NAP.Core.Service.Interface;
using Fanex.NAP.Core.Web.Session;
using System.Linq;
using System.Web.Http;

namespace UniversalReports.CashOutPerformance.Common
{
    [RoutePrefix("api/cash-out-performance/common")]
    public class CashOutPerformanceCommonApiController : ApiController
    {
        private readonly IUserService userService;

        private readonly ICurrentSession currentSession;

        public CashOutPerformanceCommonApiController(IUserService userService, ICurrentSession currentSession)
        {
            this.userService = userService;
            this.currentSession = currentSession;
        }

        [Route("check-full-view")]
        public IHttpActionResult FullView()
        {
            var permissions = userService.GetPermissions(
                currentSession.UserId,
                NapSettings.Settings.SiteId,
                "CashOutPerformance",
                "LIVE")
                .Where(p => p.Policy >= (int)Constant.Policy.Read)
                .Select(p => p.Function.Key);
            return Json(permissions.Contains("CashOut_FullView"));
        }
    }
}