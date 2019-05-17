using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace UniversalReports.ActualMemberBet.Filter
{
    [RoutePrefix("api/actual-member-bet/filter")]
    public class ActualMemberBetFilterController : ApiController
    {
        private readonly IMediator mediator;

        public ActualMemberBetFilterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("currency")]
        public async Task<IHttpActionResult> Currency()
        {
            var viewModel = await mediator.Send(new CurrencyHttpParameter());
            return Json(viewModel);
        }

        [Route("odds")]
        public async Task<IHttpActionResult> Odds()
        {
            var viewModel = await mediator.Send(new OddsHttpParameter());
            return Json(viewModel);
        }

        [Route("site")]
        public async Task<IHttpActionResult> Site()
        {
            var viewModel = await mediator.Send(new SiteHttpParameter());
            return Json(viewModel);
        }
    }
}
