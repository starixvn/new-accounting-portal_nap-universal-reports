using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.AbnormalBet.HttpParameter;

namespace UniversalReports.AbnormalBet.Filter
{
    [RoutePrefix("api/ab-normal-bet/filter")]
    public class AbnormalBetFilterController : ApiController
    {
        private readonly IMediator mediator;

        public AbnormalBetFilterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("sport")]
        public async Task<IHttpActionResult> Sport()
        {
            var viewModel = await mediator.Send(new SportHttpParameter());
            return Json(viewModel);
        }

        [Route("reason")]
        public async Task<IHttpActionResult> Reason()
        {
            var viewModel = await mediator.Send(new ReasonHttpParameter());
            return Json(viewModel);
        }

        [Route("site")]
        public async Task<IHttpActionResult> Site()
        {
            var viewModel = await mediator.Send(new SiteHttpParameter());
            return Json(viewModel);
        }

        [Route("bet-type")]
        public async Task<IHttpActionResult> BetType(BetTypeHttpParameter httpParameter)
        {
            var viewModel = await mediator.Send(httpParameter);
            return Json(viewModel);
        }

        [Route("currency")]
        public async Task<IHttpActionResult> Currency()
        {
            var viewModel = await mediator.Send(new CurrencyHttpParameter());
            return Json(viewModel);
        }

        [Route("league")]
        public async Task<IHttpActionResult> League(LeagueHttpParameter httpParameter)
        {
            var viewModel = await mediator.Send(httpParameter);
            return Json(viewModel);
        }
    }
}