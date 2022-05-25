using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Configuration;
using Fanex.NAP.Core.Service.Interface;
using Fanex.NAP.Core.Web.Session;
using System.Linq;
using System.Web.Http;

namespace UniversalReports.SBPerformance.Common
{
    [RoutePrefix("api/sb-performance/check-full-view")]
    public class SBPerformancePermissionController : ApiController
    {
        private readonly IUserService userService;

        private readonly ICurrentSession currentSession;

        public SBPerformancePermissionController(IUserService userService, ICurrentSession currentSession)
        {
            this.userService = userService;
            this.currentSession = currentSession;
        }

        [Route("")]
        public IHttpActionResult FullView()
        {
            var permissions = userService.GetPermissions(
                currentSession.UserId,
                NapSettings.Settings.SiteId,
                "SBPerformanceMonitor")
                .Where(p => p.Policy >= (int)Constant.Policy.Read)
                .Select(p => p.Key);
            return Json(permissions.Contains("FullView"));
        }
    }
}