using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBPerformance.League
{
    [RoutePrefix("api/sb-performance/main")]
    public class SBPerformanceLeagueController : ApiController
    {
        private readonly IMediator mediator;

        public SBPerformanceLeagueController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("league")]
        public async Task<IHttpActionResult> Site(LeagueHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }
    }
}