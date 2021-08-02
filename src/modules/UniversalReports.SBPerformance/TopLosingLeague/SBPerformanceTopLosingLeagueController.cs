using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBPerformance.TopLosingLeague
{
    [RoutePrefix("api/sb-performance/main")]
    public class SBPerformanceTopLosingLeagueController : ApiController
    {
        private readonly IMediator mediator;

        public SBPerformanceTopLosingLeagueController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("top-losing-league")]
        public async Task<IHttpActionResult> League(TopLosingLeagueHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }
    }
}