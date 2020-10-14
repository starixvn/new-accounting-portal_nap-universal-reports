using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SMAWinLoss.Filter
{
    [RoutePrefix("api/sma-win-loss/filter")]
    public class SMAWinLossFilterController : ApiController
    {
        private readonly IMediator mediator;

        public SMAWinLossFilterController(IMediator mediator)
        {
            this.mediator = mediator;
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
    }
}