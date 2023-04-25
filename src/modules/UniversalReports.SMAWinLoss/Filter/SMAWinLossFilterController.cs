using Fanex.NAP.Core.Business;
using Fanex.NAP.Core.Configuration;
using Fanex.NAP.Core.Service.Interface;
using Fanex.NAP.Core.Web.Session;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SMAWinLoss.Filter
{
    [RoutePrefix("api/sma-win-loss/filter")]
    public class SMAWinLossFilterController : ApiController
    {
        private readonly IMediator mediator;

        private readonly ICurrentSession currentSession;

        private readonly IUserService userService;

        public SMAWinLossFilterController(
            IMediator mediator,
            ICurrentSession currentSession,
            IUserService userService)
        {
            this.mediator = mediator;
            this.currentSession = currentSession;
            this.userService = userService;
        }

        [Route("currency")]
        public async Task<IHttpActionResult> Currency()
        {
            var viewModel = await mediator.Send(new CurrencyHttpParameter());
            return Json(viewModel);
        }

        [Route("site")]
        public async Task<IHttpActionResult> Site()
        {
            var viewModel = await mediator.Send(new SiteHttpParameter());
            return Json(viewModel);
        }

        [Route("sport")]
        public async Task<IHttpActionResult> Sport()
        {
            var viewModel = await mediator.Send(new SportHttpParameter());
            return Json(viewModel);
        }

        [Route("league-group")]
        public async Task<IHttpActionResult> LeagueGroup(LeagueGroupHttpParameter parameter)
        {
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }

        [Route("available-database")]
        public async Task<IHttpActionResult> AvailableDatabase()
        {
            var viewModel = await mediator.Send(new AvailableDatabaseHttpParameter());
            return Json(viewModel);
        }

        [Route("available-date-data")]
        public async Task<IHttpActionResult> AvailableDateData()
        {
            var viewModel = await mediator.Send(new AvailableDateDataHttpParameter());
            return Json(viewModel);
        }

        [Route("bet-from")]
        public async Task<IHttpActionResult> BetFrom()
        {
            var viewModel = await mediator.Send(new BetFromHttpParameter());
            return Json(viewModel);
        }

        [Route("permission")]
        public async Task<IHttpActionResult> Permission()
        {
            var permissions = this.userService.GetPermissions(
                currentSession.UserId,
                NapSettings.Settings.SiteId,
                "SMAWinLossSummary")
                .Where(p => p.Policy >= (int)Constant.Policy.Read)
                .OrderBy(x => x.Name)
                .Select(p => p.Key);

            var permission = permissions.Any() ? permissions.FirstOrDefault() : string.Empty;

            var permissionHttpParameter = new PermissionHttpParameter
            { 
                FunctionKey = permission 
            };

            var viewModel = await mediator.Send(permissionHttpParameter);
            return Json(viewModel);
        }
    }
}