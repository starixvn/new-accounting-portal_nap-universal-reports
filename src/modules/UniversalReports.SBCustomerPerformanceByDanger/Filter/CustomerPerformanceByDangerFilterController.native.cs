using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBCustomerPerformanceByDanger.Filter
{
    [RoutePrefix("api/sb-customer-performance-by-danger/filter")]
    public class CustomerPerformanceByDangerFilterController : ApiController
    {
        private readonly IMediator mediator;

        public CustomerPerformanceByDangerFilterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("balance-up-date")]
        public async Task<IHttpActionResult> BalanceUpDate()
        {
            var viewModel = await mediator.Send(new BalanceUpDateQueryHttpParameter());
            return Json(viewModel);
        }

        [Route("sport")]
        public async Task<IHttpActionResult> Sport()
        {
            var viewModel = await mediator.Send(new SportQueryHttpParameter());
            return Json(viewModel);
        }

        [Route("division")]
        public async Task<IHttpActionResult> Division()
        {
            var viewModel = await mediator.Send(new DivisionQueryHttpParameter());
            return Json(viewModel);
        }

        [Route("league-group")]
        public async Task<IHttpActionResult> LeagueGroup(LeagueGroupQueryHttpParameter parameter)
        {
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }

        [Route("league-suggestion")]
        public async Task<IHttpActionResult> League(LeagueQueryHttpParameter parameter)
        {
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }
    }
}